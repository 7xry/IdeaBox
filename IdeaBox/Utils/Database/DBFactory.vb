Imports IdeaBox.Utils.Database.Enum
Imports IdeaBox.Utils.Database.API
Imports IdeaBox.Utils.Database.Impl
Imports IdeaBox.Utils.FileSystem.Path

Namespace Utils.Database
    Public Class DBFactory
        Public Shared Property SqlType As DBTypeEnum = DBTypeEnum.SQLITE
        Public Shared Property Conn As String = String.Format("Data Source={0}\{1}", AppPath.GetRunPath, "db_IdeaBox.db")
        'String.Format("Server={0};Database={1};uid={2};pwd={3};pooling={4};port={5};Charset={6};", "localhost", "db_attendance", "root", "root", False, "3306", "utf8")
        'String.Format("Server={0};Database={1};uid={2};pwd={3};pooling={4};port={5};Charset={6};", "18.1.2.42", "db_attendance", "root", "root", False, "3306", "utf8")
        'String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\{1};User ID={1};Password={2};", AppPath.GetRunPath, "db_access.mdb", "admin", "admin")
        'String.Format("Data Source={0}\{1}", AppPath.GetRunPath, "db_IdeaBox.db")

        Public Shared Function Create() As IDataAccess
            Select Case SqlType
                Case DBTypeEnum.ACCESS
                    Return New AccessImpl(Conn)
                Case DBTypeEnum.MYSQL
                    Return New MySqlImpl(Conn)
                Case DBTypeEnum.SQLITE
                    Return New SqliteImpl(Conn)
                Case Else
                    Return New SqliteImpl(Conn)
            End Select
        End Function

        Public Shared Function GetConn() As String
            Return Conn
        End Function

    End Class
End Namespace