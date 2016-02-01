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

        Overrides Function ToString() As String
            Dim strBuff As New StringBuilder
            strBuff.AppendLine(String.Format("书名：{0}", BookName))
            strBuff.AppendLine(String.Format("作者：{0}", Author))
            strBuff.AppendLine(String.Format("分类：{0}", Category))
            strBuff.AppendLine(String.Format("文件大小：{0}", FileSize))
            strBuff.AppendLine(String.Format("评分：{0}", Rating))
            strBuff.AppendLine(String.Format("下载数量：{0}", DownloadQuantity))
            strBuff.AppendLine(String.Format("上传日期：{0}", UploadDate))
            strBuff.AppendLine(String.Format("简介：{0}", Abstract))
            strBuff.AppendLine(String.Format("下载地址：{0}", DownloadAddr))
            Return strBuff.ToString
        End Function


    End Class
End Namespace