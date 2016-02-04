Imports System.Net
Imports IdeaBox.StoryManage.Model
Imports IdeaBox.Utils.FileSystem.Dict

Namespace StoryManage.Impl
    Public Class FileDownImpl

        Dim IsCompleted As Boolean = False
        Dim DownLoadFileInfo As FileDown

        ''' <summary>
        ''' 异步下载文件
        ''' </summary>
        ''' <param name="fDown">下载文件信息</param>
        ''' <remarks>异步下载文件</remarks>
        Public Sub DownLoadFiles(ByVal fDown As FileDown)
            DownLoadFileInfo = fDown
            Dim myWebClient As New WebClient
            AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadFileCompleted
            AddHandler myWebClient.DownloadProgressChanged, AddressOf ShowDownProgress
            IsCompleted = False
            myWebClient.DownloadFileAsync(New Uri(fDown.SourceFile), fDown.TargetFile)
            '如果还没有完成下载就等待吧
            Do While IsCompleted = False
                Application.DoEvents()
            Loop
        End Sub

        ''' <summary>
        ''' 下载完成事件
        ''' </summary>
        ''' <param name="sender">发送方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>下载完成事件</remarks>
        Public Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
            IsCompleted = True
        End Sub

        ''' <summary>
        ''' 显示进度事件
        ''' </summary>
        ''' <param name="sender">发送方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>显示进度事件</remarks>
        Public Sub ShowDownProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
            frStory.SetStatInvoke(String.Format("正在下载：{0}/{1} - {2}.{3}，进度：{4}%，累计耗时：{5} ", DownLoadFileInfo.CurrentIndex, DownLoadFileInfo.AllCount, DownLoadFileInfo.fileInfo.BookName, DownLoadFileInfo.FileExtension, e.ProgressPercentage, DownLoadFileInfo.timer.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")))
        End Sub

        ''' <summary>
        ''' 获取文件大小
        ''' </summary>
        ''' <param name="fDown">下载文件信息</param>
        ''' <returns>文件大小</returns>
        ''' <remarks>获取文件大小</remarks>
        Public Function getFileSize(ByVal fDown As FileDown) As Long
            Dim request As HttpWebRequest = CType(WebRequest.Create(fDown.SourceFile), HttpWebRequest)
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim sumLength As Long = response.ContentLength
            Return sumLength
        End Function

        ''' <summary>
        ''' 下载文件
        ''' </summary>
        ''' <param name="fDown">文件对象</param>
        ''' <returns>成功与否</returns>
        ''' <remarks>下载文件</remarks>
        Public Function DownloadFile(ByVal fDown As FileDown) As Boolean
            Try
                Dim request As HttpWebRequest = CType(HttpWebRequest.Create(fDown.SourceFile), HttpWebRequest)
                Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Dim stream As System.IO.Stream = response.GetResponseStream()
                Dim fStream As System.IO.Stream = New System.IO.FileStream(fDown.TargetFile, System.IO.FileMode.Create)
                Dim fByte As Byte() = New Byte(1023) {}
                Dim fSize As Integer = stream.Read(fByte, 0, CType(fByte.Length, Integer))
                While fSize > 0
                    fStream.Write(fByte, 0, fSize)
                    fSize = stream.Read(fByte, 0, CType(fByte.Length, Integer))
                End While
                fStream.Close()
                stream.Close()
                response.Close()
                request.Abort()
                Return True
            Catch ex As Exception
                Log.Showlog(ex.ToString, MsgType.ErrorMsg)
                Return False
            End Try
        End Function
    End Class
End Namespace
