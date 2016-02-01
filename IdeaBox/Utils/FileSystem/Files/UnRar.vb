Namespace Utils.FileSystem.Files
    Public Class UnRAR
        ''' <summary>
        ''' 解压文件到指定目录,其他控制项可使用rarcmd传入提交rar参数
        ''' </summary>
        ''' <param name="RARfilePath">解压文件路径</param>
        ''' <param name="RARSavePath">解压到目标目录</param>
        ''' <param name="RARCMD">补充RAR命令行</param>
        ''' <remarks>解压文件到当前目录</remarks>
        Public Shared Sub RARFile(ByVal RARfilePath As String, ByVal RARSavePath As String, Optional ByVal RARCMD As String = Nothing)
            '解压缩
            If Mid(RARCMD, 1, 1) <> "" Then RARCMD = " " & RARCMD
            Dim sEnPWD As String = Nothing
            Dim info As New ProcessStartInfo("winrar.exe")
            Dim order As String = "e " & RARfilePath & " -o+ " & RARSavePath
            info.WindowStyle = ProcessWindowStyle.Hidden
            info.Arguments = order
            Process.Start(info)
        End Sub
    End Class
End Namespace
