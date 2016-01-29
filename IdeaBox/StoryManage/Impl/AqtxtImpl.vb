Imports System.Text
Imports IdeaBox.Utils.Database.API
Imports IdeaBox.Utils.Database
Imports IdeaBox.StoryManage.API
Imports IdeaBox.StoryManage.Model
Imports System.Net
Imports System.IO
Imports IdeaBox.Utils.FileSystem.Dict

Namespace StoryManage.Impl
    Public Class AqtxtImpl
        Const Url As String = "http://m.aqtxt.com"
        Public Function OpenUrl(ByVal UrlStr As String) As String
            Try
                Dim req As HttpWebRequest = WebRequest.Create(UrlStr)
                Dim res As HttpWebResponse = req.GetResponse()
                Dim strm As StreamReader = New StreamReader(res.GetResponseStream(), Encoding.UTF8)
                Return strm.ReadToEnd
            Catch ex As Exception
                Log.Showlog(ex.ToString, MsgType.ErrorMsg)
                Return String.Empty
            End Try
        End Function

        Public Function GetPageCount() As Integer
            Dim WebStr As String = OpenUrl(String.Format("{0}/finished/", Url))
            Dim StartIdx As Integer = InStr(1, WebStr, ".htm"">></a> <a href=""")
            Dim EndIdx As Integer = InStr(1, WebStr, ".htm"">>></a>")
            Dim PageCount As Integer = CInt(Mid(WebStr, StartIdx + 21, EndIdx - StartIdx - 21))
            Return PageCount
        End Function

        Public Function GetRowsCount() As Integer
            Dim PageCount As Integer = GetPageCount()
            Dim WebStr As String = OpenUrl(String.Format("{0}/finished/{1}.htm", Url, PageCount))
            Dim PageRows As Integer = UBound(Split(OpenUrl(String.Format("{0}/finished/1.htm", Url)), "<ul class=""listtxt"))
            Dim rows As Integer = 0
            Dim CurIdx As Integer = WebStr.IndexOf("<ul class=", CurIdx)
            Do Until 1 <> 1
                CurIdx = WebStr.IndexOf("<ul class=", CurIdx + 12)
                If CurIdx = -1 Then
                    Exit Do
                End If
                rows += 1
            Loop
            rows += (PageCount - 1) * PageRows
            Return rows
        End Function

        Public Function GetCollect(ByVal PageIdx As Integer) As List(Of Story)
            Dim WebStr As String = OpenUrl(String.Format("{0}/finished/{1}.htm", Url, PageIdx))
            Dim RowsData() As String = Split(WebStr, "<ul class=""listtxt")
            Dim PageRows As Integer = UBound(RowsData)
            Dim ls As New List(Of Story)
            For CurIdx As Integer = 1 To PageRows
                Dim st As New Story
                Dim RowStr As String = RowsData(CurIdx)
                Dim liStr() As String = Split(RowStr, String.Format("<li class={0}", Chr(34)))
                Dim StartIdx As Integer = InStr(1, liStr(1), String.Format("bookname{0}><a href={0}", Chr(34)))
                Dim EndIdx As Integer = InStr(StartIdx, liStr(1), String.Format(".htm{0}>", Chr(34)))
                WebStr = OpenUrl(String.Format("{0}/{1}", Url, Mid(liStr(1), StartIdx + 20, EndIdx - StartIdx - 16)))
                Dim TmpData() As String = Split(WebStr, String.Format("<div class={0}booki{0}>", Chr(34)))
                liStr = Split(TmpData(1), "<p>")
                '截取书名
                StartIdx = InStr(1, liStr(0), String.Format("<p class={0}bookname{0}>", Chr(34)))
                EndIdx = InStr(1, liStr(0), "</p>")
                st.BookName = Mid(liStr(0), StartIdx + 20, EndIdx - StartIdx - 20)
                '截取作者
                StartIdx = InStr(1, liStr(1), "作者：")
                EndIdx = InStr(1, liStr(1), "</p>")
                st.Author = Mid(liStr(1), StartIdx + 3, EndIdx - StartIdx - 3)
                st.Author = st.Author.Replace("&#183;", "·")
                '截取作者
                StartIdx = InStr(1, liStr(2), "分类：")
                EndIdx = InStr(1, liStr(2), "</p>")
                st.Category = Mid(liStr(2), StartIdx + 3, EndIdx - StartIdx - 3)
                '截取下载
                StartIdx = InStr(1, liStr(3), String.Format("下载：<label class={0}zise{0}>", Chr(34)))
                EndIdx = InStr(1, liStr(3), "</label></p>")
                st.DownloadQuantity = Mid(liStr(3), StartIdx + 23, EndIdx - StartIdx - 23)
                '截取大下
                StartIdx = InStr(1, liStr(4), "大小：")
                EndIdx = InStr(1, liStr(4), "</p>")
                st.FileSize = Mid(liStr(4), StartIdx + 3, EndIdx - StartIdx - 3)
                '截取上传时间
                StartIdx = InStr(1, liStr(5), "上传：")
                EndIdx = InStr(1, liStr(5), "</p>")
                st.UploadDate = Mid(liStr(5), StartIdx + 3, EndIdx - StartIdx - 3)
                '截取简介
                TmpData = Split(liStr(5), String.Format("<div class={0}bookdesd{0}>", Chr(34)))
                liStr = Split(TmpData(1), "</div>")
                st.Abstract = liStr(0).Replace("内容简介：          ", String.Empty)
                st.Abstract = st.Abstract.Replace("'", Chr(34))
                st.Abstract = st.Abstract.Replace("\", "")
                st.Abstract = st.Abstract.Replace("&quot;", Chr(34))
                TmpData = Split(TmpData(2), String.Format("<p class={0}bookdest mt10{0}>全集下载地址</p>", Chr(34)))
                liStr = Split(TmpData(1), String.Format("<a href={0}", Chr(34)))
                liStr = Split(liStr(1), String.Format("{0} target={0}_blank{0}", Chr(34)))
                st.DownloadAddr = liStr(0)
                '截取评分
                TmpData = Split(TmpData(0), "</label>人打分,当前<b>")
                TmpData = Split(TmpData(1), "</b>分<br/>")
                st.Rating = TmpData(0)
                '生成是否已读
                st.IsRead = 0
                ls.Add(st)
            Next
            Return ls
        End Function
    End Class
End Namespace
