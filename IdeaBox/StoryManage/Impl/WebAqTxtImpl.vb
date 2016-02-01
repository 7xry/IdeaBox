Imports HtmlAgilityPack
Imports IdeaBox.Utils.FileSystem.Net
Imports IdeaBox.StoryManage.Model

Namespace StoryManage.Impl
    Public Class WebAqTxtImpl
        Const Url As String = "http://www.aqtxt.com"

        Public Function GetPageCount() As Integer
            Dim rootNode As HtmlNode = HttpHelper.OpenUrl(String.Format("{0}/finished/1.htm", Url))
            Dim PageCount As String = HttpHelper.GetNodeStr(rootNode, "//*[@id='newbook']/div[16]/a[11]", 1)
            Return CInt(PageCount.Replace(".htm", ""))
        End Function

        Public Function GetBooks() As List(Of Story)
            Dim pageCount As Integer = GetPageCount()
            Dim bookLs As New List(Of Story)
            Dim tm As New Stopwatch
            tm.Start()
            For page As Integer = 1 To pageCount
                Dim rootNode As HtmlNode = HttpHelper.OpenUrl(String.Format("{0}/finished/{1}.htm", Url, page))
                Dim NodeCollection As HtmlNodeCollection = HttpHelper.GetNodeCollection(rootNode, "//*[@id='newbook']/div/ul/li/a")
                For Each node As HtmlNode In NodeCollection
                    Dim s As New Story
                    s.BookName = node.InnerText
                    s.DownloadAddr = String.Format("{0}{1}", Url, HttpHelper.GetNodeStr(node, 1))
                    bookLs.Add(s)
                Next
            Next
            tm.Stop()
            Return bookLs
        End Function

        Public Function GetCollect(ByRef book As Story) As Story
            Try
                Dim rootNode As HtmlNode = HttpHelper.OpenUrl(book.DownloadAddr)
                '作者
                book.Author = HttpHelper.GetNodeStr(rootNode, "//*[@id='author']").Replace("作者：", "").Trim
                '分类
                book.Category = HttpHelper.GetNodeStr(rootNode, "//*[@id='submenu']/h2/a[@class='lan']").Replace("下载", "").Trim
                '文件大小
                book.FileSize = HttpHelper.GetNodeStr(rootNode, "//*[@class='in']/em").Trim
                '评分
                book.Rating = HttpHelper.GetNodeStr(rootNode, "//*[@id='pingfen']").Trim
                '下载量
                book.DownloadQuantity = HttpHelper.GetNodeStr(rootNode, "//*[@class='in']/label").Trim
                '上传日期
                book.UploadDate = HttpHelper.GetNodeStr(rootNode, "//*[@id='txtleft']/div/ul[1]/li[5]").Replace("上传日期:", "").Trim
                '小说简介
                book.Abstract = HttpHelper.GetNodeStr(rootNode, "//*[@class='item']/p").Replace("内容简介：", "").Trim
                '下载地址
                book.DownloadAddr = HttpHelper.GetNodeStr(rootNode, "//*[@id='txtdown']/ul/li[2]/a", 1).Trim
                '生成是否已读
                book.IsRead = 0
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Dict.MsgType.ErrorMsg, False)
                Return New Story
            End Try
            Return book
        End Function
    End Class
End Namespace
