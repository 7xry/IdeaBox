Imports IdeaBox.Utils.FileSystem.Files

Namespace StoryManage.Model
    Public Class FileDown
        Property fileInfo As Story
        Property SourceFile As String
        Property TargetFile As String
        Property FileExtension As String

        Sub New()
        End Sub

        Sub New(ByVal xSourceFile As String, ByVal xTargetFile As String)
            SourceFile = xSourceFile
            TargetFile = xTargetFile
        End Sub


    End Class
End Namespace