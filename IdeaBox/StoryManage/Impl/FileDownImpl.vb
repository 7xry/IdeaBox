﻿Imports System.Net
Imports IdeaBox.StoryManage.Model
Imports System.IO
Imports IdeaBox.Utils.FileSystem.Dict

Namespace StoryManage.Impl
    Public Class FileDownImpl
        Dim DownFileOK As Boolean = False
        Public Sub DownLoadFiles(ByVal fDown As FileDown)
            Dim myWebClient As New WebClient
            AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadFileCompleted
            DownFileOK = False
            myWebClient.DownloadFileAsync(New Uri(fDown.SourceFile), fDown.TargetFile)
            '如果还没有完成下载就等待吧
            Do While DownFileOK = False
                Application.DoEvents()
            Loop
        End Sub
        Public Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
            DownFileOK = True
        End Sub

        Public Function getFileSize(ByVal fDown As FileDown)
            Dim request As HttpWebRequest = CType(WebRequest.Create(fDown.SourceFile), HttpWebRequest)
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim strem As Stream = response.GetResponseStream
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
                Dim request As System.Net.HttpWebRequest = CType(System.Net.HttpWebRequest.Create(fDown.SourceFile), System.Net.HttpWebRequest)
                Dim response As System.Net.HttpWebResponse = CType(request.GetResponse(), System.Net.HttpWebResponse)
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
            Catch ex As System.Exception
                Log.Showlog(ex.ToString, MsgType.ErrorMsg)
                Return False
            End Try
        End Function
    End Class
End Namespace
