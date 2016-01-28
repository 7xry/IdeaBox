Imports IdeaBox.Utils.FileSystem.Files

Namespace StoryManage.Model
    Public Class Story
        Inherits BaseVo
        Property BookName As String
        Property Author As String
        Property Category As String
        Property FileSize As String
        Property Rating As String
        Property DownloadQuantity As String
        Property UploadDate As String
        Property Abstract As String
        Property DownloadAddr As String
        Property IsRead As String

        Sub New()
        End Sub

        Sub New(ByVal xBookName As String)
            BookName = xBookName
        End Sub

        Sub New(ByVal xBookName As String, ByVal xAuthor As String, ByVal xCategory As String, ByVal xAbstract As String, ByVal xRating As String)
            BookName = xBookName
            Author = xAuthor
            Category = xCategory
            Rating = xRating
            Abstract = xAbstract
        End Sub


    End Class
End Namespace