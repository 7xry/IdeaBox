Imports System.Text
Imports IdeaBox.Utils.Database.API
Imports IdeaBox.Utils.Database
Imports IdeaBox.StoryManage.API
Imports IdeaBox.StoryManage.Model
Imports IdeaBox.Impl

Namespace StoryManage.Impl
    Public Class StoryImpl
        Implements IStory

        Public Sub ResetTable(ByVal TableName As String) Implements IStory.ResetTable
            Dim data As IDataAccess = DBFactory.Create
            Try
                data.Open()
                data.BeginTran()
                data.ExecuteNonQuery(DBImpl.GetCreateStorySql(TableName))
                data.CommitTran()
            Catch ex As Exception
                data.RollBackTran()
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
            Finally
                data.Close()
            End Try
        End Sub

        Public Sub Add(ByVal s As Story, ByVal TableName As String) Implements IStory.Add
            Dim data As IDataAccess = DBFactory.Create
            Dim sql As String = String.Empty
            sql += String.Format("Insert Into {0} (", TableName)
            sql += "     BookName, Author, Category, "
            sql += "     FileSize, Rating, DownloadQuantity, "
            sql += "     UploadDate, Abstract, DownloadAddr, IsRead)"
            sql += "Values( "
            sql += String.Format("'{0}','{1}','{2}', ", s.BookName, s.Author, s.Category)
            sql += String.Format("'{0}','{1}','{2}', ", s.FileSize, s.Rating, s.DownloadQuantity)
            sql += String.Format("'{0}','{1}','{2}','{3}' ", s.UploadDate, s.Abstract, s.DownloadAddr, s.IsRead)
            sql += ") "
            Try
                data.Open()
                data.BeginTran()
                data.ExecuteNonQuery(sql)
                data.CommitTran()
            Catch ex As Exception
                data.RollBackTran()
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
            Finally
                data.Close()
            End Try
        End Sub

        Public Sub Add(ByVal sLs As List(Of Story), ByVal TableName As String) Implements IStory.Add
            Dim data As IDataAccess = DBFactory.Create
            Dim sql As String = String.Empty
            sql += String.Format("Insert Into {0} (", TableName)
            sql += "     BookName, Author, Category, "
            sql += "     FileSize, Rating, DownloadQuantity, "
            sql += "     UploadDate, Abstract, DownloadAddr, IsRead)"
            sql += "Values "
            For Each s As Story In sLs
                sql += "( "
                sql += String.Format("'{0}','{1}','{2}', ", s.BookName, s.Author, s.Category)
                sql += String.Format("'{0}','{1}','{2}', ", s.FileSize, s.Rating, s.DownloadQuantity)
                sql += String.Format("'{0}','{1}','{2}','{3}' ", s.UploadDate, s.Abstract, s.DownloadAddr, s.IsRead)
                sql += "), "
            Next
            If sql.Length > 0 Then
                sql = sql.Substring(0, sql.Length - 2)
            End If
            Try
                data.Open()
                data.BeginTran()
                data.ExecuteNonQuery(sql)
                data.CommitTran()
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
                data.RollBackTran()
            Finally
                data.Close()
            End Try
        End Sub

        Public Sub Update(ByVal s As Story, ByVal TableName As String) Implements IStory.Update
            Dim data As IDataAccess = DBFactory.Create
            Dim sql As String = String.Empty
            sql += String.Format("Update {0} Set", TableName)
            sql += String.Format("     BookName='{0}', Author='{1}', Category='{2}', ", s.BookName, s.Author, s.Category)
            sql += String.Format("     FileSize='{0}', Rating='{1}', DownloadQuantity='{2}', ", s.FileSize, s.Rating, s.DownloadQuantity)
            sql += String.Format("     UploadDate='{0}', Abstract='{1}', DownloadAddr='{2}', IsRead='{3}' ", s.UploadDate, s.Abstract, s.DownloadAddr, s.IsRead)
            sql += "Where "
            sql += String.Format("     BookName='{0}'; ", s.BookName)
            Try
                data.Open()
                data.BeginTran()
                data.ExecuteNonQuery(sql)
                data.CommitTran()
            Catch ex As Exception
                data.RollBackTran()
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
            Finally
                data.Close()
            End Try
        End Sub

        Public Sub Update(ByVal sLs As List(Of Story), ByVal TableName As String) Implements IStory.Update
            Dim data As IDataAccess = DBFactory.Create
            Dim sqlBuff As New StringBuilder
            For Each s As Story In sLs
                Dim Sql As New StringBuilder
                Sql.AppendLine(String.Format("Update {0} Set", TableName))
                Sql.AppendLine(String.Format("     BookName='{0}', Author='{1}', Category='{2}', ", s.BookName, s.Author, s.Category))
                Sql.AppendLine(String.Format("     FileSize='{0}', Rating='{1}', DownloadQuantity='{2}', ", s.FileSize, s.Rating, s.DownloadQuantity))
                Sql.AppendLine(String.Format("     UploadDate='{0}', Abstract='{1}', DownloadAddr='{2}', IsRead='{3}' ", s.UploadDate, s.Abstract, s.DownloadAddr, s.IsRead))
                Sql.AppendLine("Where ")
                Sql.AppendLine(String.Format("     BookName='{0}'; ", s.BookName))
                sqlBuff.AppendLine(Sql.ToString)
            Next
            Try
                data.Open()
                data.BeginTran()
                data.ExecuteNonQuery(sqlBuff.ToString)
                data.CommitTran()
            Catch ex As Exception
                data.RollBackTran()
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
            Finally
                data.Close()
            End Try
        End Sub

        Public Sub Delete(ByVal s As Story, ByVal TableName As String) Implements IStory.Delete
            Dim data As IDataAccess = DBFactory.Create
            Dim sql As String = String.Empty
            sql += String.Format("Delete From {0} ", TableName)
            sql += "Where "
            sql += String.Format("     BookName='{0}' ", s.BookName)
            Try
                data.Open()
                data.BeginTran()
                data.ExecuteNonQuery(sql)
                data.CommitTran()
            Catch ex As Exception
                data.RollBackTran()
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
            Finally
                data.Close()
            End Try
        End Sub

        Public Sub Delete(ByVal sLs As List(Of Story), ByVal TableName As String) Implements IStory.Delete
            Dim data As IDataAccess = DBFactory.Create
            Dim sql As String = String.Empty
            sql += String.Format("Delete From {0} ", TableName)
            sql += "Where "
            Dim TmpStr As String = String.Empty
            For Each s As Story In sLs
                TmpStr += String.Format("'{0}',", s.BookName)
            Next
            TmpStr = TmpStr.Substring(0, TmpStr.Length - 1)
            sql += String.Format("     BookName in ({0}) ", TmpStr)
            Try
                data.Open()
                data.BeginTran()
                data.ExecuteNonQuery(sql)
                data.CommitTran()
            Catch ex As Exception
                data.RollBackTran()
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
            Finally
                data.Close()
            End Try
        End Sub

        Public Function GetList(ByVal s As Story, ByVal TableName As String) As List(Of Story) Implements IStory.GetList
            Dim dt As New DataTable
            Dim data As IDataAccess = DBFactory.Create
            Dim sql As String = String.Empty
            sql = "Select "
            sql += "     BookName, Author, Category, "
            sql += "     FileSize, Rating, DownloadQuantity, "
            sql += "     UploadDate, Abstract, DownloadAddr, IsRead "
            sql += "From "
            sql += String.Format("     {0} ", TableName)
            sql += "Where "
            sql += "     1=1 "
            If s.BookName <> String.Empty Then
                sql += "And "
                sql += String.Format("BookName like '%{0}%' ", s.BookName)
            End If
            If s.Author <> String.Empty Then
                sql += "And "
                sql += String.Format("Author like '%{0}%' ", s.Author)
            End If
            If s.Category <> "全部小说" Then
                sql += "And "
                sql += String.Format("Category like '%{0}%' ", s.Category)
            End If
            If s.Rating <> String.Empty Then
                sql += "And "
                sql += String.Format("Rating = '{0}' ", s.Rating)
            End If
            If s.Abstract <> String.Empty Then
                sql += "And "
                sql += String.Format("Abstract like '%{0}%' ", s.Abstract)
            End If
            If s.IsRead <> String.Empty Then
                sql += "And "
                sql += String.Format("IsRead = '{0}' ", s.IsRead)
            End If
            sql += "Order By "
            sql += "     UploadDate desc, BookName "
            Try
                data.Open()
                dt = data.GetTable(sql)
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
            Finally
                data.Close()
            End Try
            Dim StoryLs As New List(Of Story)
            If dt.Rows.Count <= 0 Then
                Return StoryLs
            End If
            For Each dr As DataRow In dt.Rows
                Dim st As New Story
                st.BookName = dr("BookName")
                st.Author = dr("Author")
                st.Category = dr("Category")
                st.FileSize = dr("FileSize")
                st.Rating = dr("Rating")
                st.DownloadQuantity = dr("DownloadQuantity")
                st.UploadDate = dr("UploadDate")
                st.Abstract = dr("Abstract")
                st.DownloadAddr = dr("DownloadAddr")
                st.IsRead = dr("IsRead")
                StoryLs.Add(st)
            Next
            Return StoryLs
        End Function

        Public Function GetCategory(ByVal TableName As String) As List(Of String)
            Dim dt As New DataTable
            Dim data As IDataAccess = DBFactory.Create
            Dim sql As String = String.Empty
            sql = "Select Distinct"
            sql += "     Category "
            sql += "From "
            sql += String.Format("     {0} ", TableName)
            Try
                data.Open()
                dt = data.GetTable(sql)
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
            Finally
                data.Close()
            End Try
            If dt.Rows.Count <= 0 Then
                Return New List(Of String)
            End If
            Dim ls As New List(Of String)
            For Each dr As DataRow In dt.Rows
                If Convert.IsDBNull(dr("Category")) = False Then
                    ls.Add(dr("Category"))
                End If
            Next
            Return ls
        End Function

        Public Function IsExist(ByVal s As Story, ByVal TableName As String) As Boolean Implements IStory.IsExist
            Dim dt As New DataTable
            Dim data As IDataAccess = DBFactory.Create
            Dim sql As String = String.Empty
            sql = "Select "
            sql += "     BookName, Author, Category, "
            sql += "     FileSize, Rating, DownloadQuantity, "
            sql += "     UploadDate, Abstract, DownloadAddr, IsRead "
            sql += "From "
            sql += String.Format("     {0} ", TableName)
            sql += "Where "
            sql += "     1=1 "
            sql += "Order By "
            sql += "     BookName "
            If s.BookName <> String.Empty Then
                sql += "And "
                sql += String.Format("BookName = '{0}' ", s.BookName)
            End If
            Try
                data.Open()
                dt = data.GetTable(sql)
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.ErrorMsg, False)
            Finally
                data.Close()
            End Try
            If dt.Rows.Count <= 0 Then
                Return False
            End If
            Return True
        End Function
    End Class
End Namespace
