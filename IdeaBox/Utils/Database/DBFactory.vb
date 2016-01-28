Imports IdeaBox.Utils.Database.Enum
Imports IdeaBox.Utils.Database.API
Imports IdeaBox.Utils.Database.Impl
Imports IdeaBox.Utils.FileSystem.Path

Namespace Utils.Database
    Public Class DBFactory
        Shared SqlType As DBTypeEnum = DBTypeEnum.MYSQL
        Shared AccessConn As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\{1};User ID={1};Password={2};", AppPath.GetRunPath, "db_access.mdb", "admin", "admin")
        Shared MySqlStr As String = String.Format("Server={0};Database={1};uid={2};pwd={3};pooling={4};port={5};Charset={6};", "localhost", "db_attendance", "root", "root", False, "3306", "utf8")
        'Shared MySqlStr As String = String.Format("Server={0};Database={1};uid={2};pwd={3};pooling={4};port={5};Charset={6};", "18.1.2.42", "db_attendance", "root", "root", False, "3306", "utf8")
        Shared SqliteConn As String = String.Format("Data Source={0}\{1}", Application.StartupPath, "db_attendance.db")

        Public Shared Function Create() As IDataAccess
            Select Case SqlType
                Case DBTypeEnum.ACCESS
                    Return New AccessImpl(AccessConn)
                Case DBTypeEnum.MYSQL
                    Return New MySqlImpl(MySqlStr)
                Case DBTypeEnum.SQLITE
                    Return New SqliteImpl(SqliteConn)
                Case Else
                    Return New SqliteImpl(SqliteConn)
            End Select
        End Function

        Public Shared Function GetConn() As String
            Select Case SqlType
                Case DBTypeEnum.ACCESS
                    Return AccessConn
                Case DBTypeEnum.MYSQL
                    Return MySqlStr
                Case DBTypeEnum.SQLITE
                    Return SqliteConn
                Case Else
                    Return SqliteConn
            End Select
        End Function

    End Class
End Namespace