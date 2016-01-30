Imports System.Text
Imports IdeaBox.Utils.Database
Imports IdeaBox.Utils.Database.Dict

Namespace Impl
    Public Class DBImpl

        Public Shared Function GetCreateStorySql(ByVal TableName As String) As String
            Dim SqlBuff As New StringBuilder
            Select Case DBFactory.SqlType
                Case DBTypeEnum.MYSQL
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
                    SqlBuff.AppendLine(String.Format("  `IsRead` int(1) DEFAULT NULL"))
                    SqlBuff.AppendLine(String.Format(") ENGINE=MyISAM DEFAULT CHARSET=utf8;"))
                Case DBTypeEnum.SQLITE
                    SqlBuff.AppendLine(String.Format("DROP TABLE IF EXISTS {0};", TableName))
                    SqlBuff.AppendLine(String.Format("CREATE TABLE {0} (", TableName))
                    SqlBuff.AppendLine(String.Format("BookName  TEXT(255),"))
                    SqlBuff.AppendLine(String.Format("Author  TEXT(255),"))
                    SqlBuff.AppendLine(String.Format("Category  TEXT(255),"))
                    SqlBuff.AppendLine(String.Format("FileSize  TEXT(255),"))
                    SqlBuff.AppendLine(String.Format("Rating  TEXT(255),"))
                    SqlBuff.AppendLine(String.Format("DownloadQuantity  INTEGER(11),"))
                    SqlBuff.AppendLine(String.Format("UploadDate  TEXT(255),"))
                    SqlBuff.AppendLine(String.Format("Abstract  TEXT,"))
                    SqlBuff.AppendLine(String.Format("DownloadAddr  TEXT,"))
                    SqlBuff.AppendLine(String.Format("IsRead  INTEGER(1)"))
                    SqlBuff.AppendLine(String.Format(");"))
                Case Else

            End Select
            Return SqlBuff.ToString
        End Function

        Public Shared Function GetDropSignSql(ByVal TableName As String) As String
            Dim SqlBuff As New StringBuilder
            SqlBuff.AppendLine(String.Format("DROP TABLE IF EXISTS `{0}`;", TableName.ToUpper))
            Return SqlBuff.ToString
        End Function
    End Class
End Namespace
