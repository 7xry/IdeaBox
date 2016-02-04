Imports IdeaBox.Utils.FileSystem.Files
Imports System.Text

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

        Function Clone() As Story
            Dim tmpStory As New Story
            tmpStory.BookName = BookName
            tmpStory.Author = Author
            tmpStory.Category = Category
            tmpStory.FileSize = FileSize
            tmpStory.Rating = Rating
            tmpStory.DownloadQuantity = DownloadQuantity
            tmpStory.UploadDate = UploadDate
            tmpStory.Abstract = Abstract
            tmpStory.DownloadAddr = DownloadAddr
            tmpStory.IsRead = IsRead
            Return tmpStory
        End Function

        Overrides Function ToString() As String
            Dim strBuff As New StringBuilder
            strBuff.AppendLine(String.Format("书名：{0}", BookName))
            strBuff.AppendLine(String.Format("作者：{0}", Author))
            strBuff.AppendLine(String.Format("分类：{0}", Category))
            strBuff.AppendLine(String.Format("评分：{0}", Rating))
            strBuff.AppendLine(String.Format("下载数量：{0}", DownloadQuantity))
            strBuff.AppendLine(String.Format("简介：{0}", Abstract))
            Return strBuff.ToString
        End Function

        Function IsNothing() As Boolean
            If BookName Is Nothing Then
                Return True
            End If
            If Author Is Nothing Then
                Return True
            End If
            If Category Is Nothing Then
                Return True
            End If
            If Rating Is Nothing Then
                Return True
            End If
            If Abstract Is Nothing Then
                Return True
            End If
            Return False
        End Function


    End Class
End Namespace