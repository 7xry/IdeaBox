Imports System.Text

Namespace Impl
    Public Class DBImpl

        Public Shared Function GetCreateStorySql(ByVal TableName As String) As String
            Dim SqlBuff As New StringBuilder
            SqlBuff.AppendLine(String.Format("DROP TABLE IF EXISTS `{0}`;", TableName))
            SqlBuff.AppendLine(String.Format("CREATE TABLE `{0}` (", TableName))
            SqlBuff.AppendLine(String.Format("  `BookName` varchar(255) DEFAULT NULL,"))
            SqlBuff.AppendLine(String.Format("  `Author` varchar(255) DEFAULT NULL,"))
            SqlBuff.AppendLine(String.Format("  `Category` varchar(255) DEFAULT NULL,"))
            SqlBuff.AppendLine(String.Format("  `FileSize` varchar(255) DEFAULT NULL,"))
            SqlBuff.AppendLine(String.Format("  `Rating` varchar(255) DEFAULT NULL,"))
            SqlBuff.AppendLine(String.Format("  `DownloadQuantity` int(11) DEFAULT NULL,"))
            SqlBuff.AppendLine(String.Format("  `UploadDate` varchar(255) DEFAULT NULL,"))
            SqlBuff.AppendLine(String.Format("  `Abstract` text,"))
            SqlBuff.AppendLine(String.Format("  `DownloadAddr` text,"))
            SqlBuff.AppendLine(String.Format("  `IsRead` int(11) DEFAULT NULL"))
            SqlBuff.AppendLine(String.Format(") ENGINE=MyISAM DEFAULT CHARSET=utf8;"))
            Return SqlBuff.ToString
        End Function

        Public Shared Function GetDropSignSql(ByVal TableName As String) As String
            Dim SqlBuff As New StringBuilder
            SqlBuff.AppendLine(String.Format("DROP TABLE IF EXISTS `{0}`;", TableName.ToUpper))
            Return SqlBuff.ToString
        End Function
    End Class
End Namespace
