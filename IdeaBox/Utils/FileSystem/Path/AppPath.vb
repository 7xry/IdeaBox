Namespace Utils.FileSystem.Path
    Public Class AppPath
        Public Shared Function GetRunPath() As String
            Return Environment.CurrentDirectory
        End Function

        Public Shared Function IsExistPath(ByVal path As String) As Boolean
            If IO.Directory.Exists(path) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Shared Sub IsExistAndCreate(ByVal path As String)
            If IO.Directory.Exists(path) = False Then
                IO.Directory.CreateDirectory(path)
            End If
        End Sub
    End Class
End Namespace
