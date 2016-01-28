Imports System.Data.OleDb
Imports System.Windows.Forms

Namespace Utils.FileSystem.Files
    Public Class Excel
        Public Overloads Shared Function LoadFromExcel(ByVal FileName As String, ByVal SheetName As String) As DataTable
            If FileName = String.Empty Then
                Dim olg As New OpenFileDialog
                olg.Filter = "Excel 工作簿 (*.xls)|*.xls"
                If olg.ShowDialog() = DialogResult.OK Then
                    FileName = olg.FileName
                Else
                    Return Nothing
                End If
            End If
            Dim ConnStr As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}{1}{0};Extended Properties={0}Excel 8.0;HDR=YES;IMEX=1{0}", Chr(34), FileName)
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Dim ds As New DataSet
                Dim dt As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                Dim SheetsList As New List(Of String)
                For Each r As DataRow In dt.Rows
                    If r("TABLE_TYPE") = "TABLE" Then
                        If SheetName <> String.Empty Then
                            If r("TABLE_NAME").ToString.Replace("$", "") = SheetName Then
                                SheetsList.Add(SheetName)
                            End If
                        Else
                            SheetsList.Add(r("TABLE_NAME").ToString.Replace("$", ""))
                        End If
                    End If
                Next
                If SheetsList.Count <= 0 Then
                    Return Nothing
                End If
                Dim TableName As String = SheetsList.Item(0).ToString
                Dim sql As String = String.Format("Select * from [{0}$]", TableName)
                Using da As New OleDbDataAdapter(sql, conn)
                    da.Fill(ds, TableName)
                    Return ds.Tables(TableName)
                End Using
            End Using
        End Function

        Public Overloads Shared Function LoadFromExcel(ByVal FileName As String, ByVal SheetName As String, ByVal Range As String) As DataTable
            If FileName = String.Empty Then
                Dim olg As New OpenFileDialog
                olg.Filter = "Excel 工作簿 (*.xls)|*.xls"
                If olg.ShowDialog() = DialogResult.OK Then
                    FileName = olg.FileName
                Else
                    Return Nothing
                End If
            End If
            Dim ConnStr As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}{1}{0};Extended Properties={0}Excel 8.0;HDR=YES;IMEX=1{0}", Chr(34), FileName)
            Using conn As New OleDbConnection(ConnStr)
                conn.Open()
                Dim ds As New DataSet
                Dim dt As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                Dim SheetsList As New List(Of String)
                For Each r As DataRow In dt.Rows
                    If r("TABLE_TYPE") = "TABLE" Then
                        If SheetName <> String.Empty Then
                            If r("TABLE_NAME").ToString.Replace("$", "") = SheetName Then
                                SheetsList.Add(SheetName)
                            End If
                        Else
                            SheetsList.Add(r("TABLE_NAME").ToString.Replace("$", ""))
                        End If
                    End If
                Next
                If SheetsList.Count <= 0 Then
                    Return Nothing
                End If
                Dim TableName As String = SheetsList.Item(0).ToString
                Dim sql As String = String.Format("Select * from [{0}$]", TableName)
                If Range <> String.Empty Then
                    sql = sql.Replace("]", Range & "]")
                End If
                Using da As New OleDbDataAdapter(sql, conn)
                    da.Fill(ds, TableName)
                    Return ds.Tables(TableName)
                End Using
            End Using
        End Function

        Public Shared Sub ExportToExcel(ByVal dt As DataTable, ByVal Filter As String, ByVal FileName As String, ByVal SheetName As String)
            If FileName = String.Empty Then
                Dim slg As New SaveFileDialog
                slg.Filter = "Excel 工作簿 (*.xls)|*.xls"
                If slg.ShowDialog() = DialogResult.OK Then
                    FileName = slg.FileName
                Else
                    Return
                End If
            End If
            Try
                System.IO.File.Delete(FileName)
            Catch ex As Exception
                MessageBox.Show("该文件已经存在，删除文件时出错！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
            Dim ConnStr As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}{1}{0};Extended Properties={0}Excel 8.0;HDR=YES;{0}", Chr(34), FileName)
            Dim conn_excel As New OleDbConnection(ConnStr)
            Dim cmd_excel As New OleDbCommand()
            Dim sql As String = SqlCreate(dt, SheetName)
            conn_excel.Open()
            cmd_excel.Connection = conn_excel
            cmd_excel.CommandText = sql
            cmd_excel.ExecuteNonQuery()
            conn_excel.Close()
            Dim da_excel As New OleDbDataAdapter(String.Format("Select * From [{0}$]", SheetName), conn_excel)
            Dim dt_excel As New DataTable
            da_excel.Fill(dt_excel)
            da_excel.InsertCommand = SqlInsert(SheetName, dt, conn_excel)
            Dim dr_excel As DataRow
            Dim ColumnName As String
            For Each dr As DataRow In dt.Select(Filter)
                dr_excel = dt_excel.NewRow()
                For Each dc As DataColumn In dt.Columns
                    ColumnName = dc.ColumnName
                    dr_excel(ColumnName) = dr(ColumnName)
                Next
                dt_excel.Rows.Add(dr_excel)
            Next
            da_excel.Update(dt_excel)
            conn_excel.Close()
            MessageBox.Show(String.Format("数据导出成功！{0}{0}文件保存在：{0}{1}", ControlChars.CrLf, FileName), "导出", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        'Private Shared Sub CheckColumn(ByVal dt As DataTable, ByVal dt_v As DataTable)
        '    For Each dr As DataRow In dt_v.Select()
        '        If (Not dt.Columns.Contains(dr("列名").ToString())) Then
        '            dr.Delete()
        '        End If
        '    Next
        '    dt_v.AcceptChanges()
        'End Sub

        '错误：String→Char，因数据长度问题，容易导致溢出
        Private Shared Function GetDataType(ByVal i As Type) As String
            Select Case i.Name
                Case "String"
                    Return "Text"
                Case "Int32"
                    Return "Int"
                Case "Int64"
                    Return "Int"
                Case "Int16"
                    Return "Int"
                Case "Double"
                    Return "Double"
                Case "Decimal"
                    Return "Double"
                Case Else
                    Return "Text"
            End Select
        End Function

        Private Shared Function StringToOleDbType(ByVal i As Type) As OleDbType
            Select Case i.Name
                Case "String"
                    Return OleDbType.Char
                Case "Int32"
                    Return OleDbType.Integer
                Case "Int64"
                    Return OleDbType.Integer
                Case "Int16"
                    Return OleDbType.Integer
                Case "Double"
                    Return OleDbType.Double
                Case "Decimal"
                    Return OleDbType.Decimal
                Case Else
                    Return OleDbType.Char
            End Select
        End Function

        Private Shared Function SqlCreate(ByVal dt As DataTable, ByVal SheetName As String) As String
            Dim sql As String = String.Format("Create Table {0} (", SheetName)
            For Each dc As DataColumn In dt.Columns
                sql += String.Format("[{0}] {1} ,", dc.ColumnName, GetDataType(dc.DataType))
            Next
            sql = sql.Substring(0, sql.Length - 1)
            sql += ")"
            Return sql
        End Function

        '生成 InsertCommand 并设置参数
        Private Shared Function SqlInsert(ByVal SheetName As String, ByVal dt As DataTable, ByVal conn_excel As OleDbConnection) As OleDbCommand
            Dim i As OleDbCommand
            Dim sql As String = String.Format("Insert Into [{0}$](", SheetName)
            For Each dc As DataColumn In dt.Columns
                sql += String.Format("[{0}],", dc.ColumnName)
            Next
            sql = sql.Substring(0, sql.Length - 1)
            sql += ") Values ("
            For Each dc As DataColumn In dt.Columns
                sql += "?,"
            Next
            sql = sql.Substring(0, sql.Length - 1)
            sql += ")"
            i = New OleDbCommand(sql, conn_excel)
            For Each dc As DataColumn In dt.Columns
                i.Parameters.Add(String.Format("@{0}", dc.Caption), StringToOleDbType(dc.DataType), 0, dc.Caption)
            Next
            Return i
        End Function


    End Class
End Namespace