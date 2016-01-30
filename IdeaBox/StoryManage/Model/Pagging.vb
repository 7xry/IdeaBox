Imports IdeaBox.Utils.FileSystem.Files

Namespace StoryManage.Model
    Public Class Pagging
        Property PageCount As Integer
        Property RowCount As Integer
        Property CurrentIndex As Integer

        Sub New(ByVal xRowCount As Integer)
            RowCount = xRowCount
            Dim TempInt As Integer = RowCount Mod perPage
            If TempInt > 0 Then
                PageCount = RowCount \ perPage + 1
            Else
                PageCount = RowCount \ perPage
            End If
            CurrentIndex = 1
        End Sub

    End Class
End Namespace