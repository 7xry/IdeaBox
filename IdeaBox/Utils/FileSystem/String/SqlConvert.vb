Imports System.IO
Imports System.Xml
Imports System.Text
Imports IdeaBox.Utils.FileSystem.Dict

Namespace Utils.FileSystem.String
    Public Class SqlConvert
        ''' <summary>
        ''' 根据条件表达式，获取SQL语句
        ''' </summary>
        ''' <param name="DbKey">字段名</param>
        ''' <param name="ExStr">待转换表达式</param>
        ''' <returns>转换后的SQL</returns>
        ''' <remarks>根据条件表达式，获取SQL语句</remarks>
        Public Shared Function GetSql(ByVal DbKey As String, ByVal ExStr As String) As String
            Dim IsExact As Boolean = False
            '如果以双引号开头并且以双引号结尾，则采取精确查找
            If ExStr.StartsWith(Chr(34)) And ExStr.EndsWith(Chr(34)) Then
                ExStr = Mid(ExStr, 2, ExStr.Length - 2)
                IsExact = True
            End If
            '过滤特殊字符
            Dim filterStr() As String = New String() {"'", "%", Chr(34)}
            For Each fStr As String In filterStr
                If ExStr.Contains(fStr) Then
                    ExStr = ExStr.Replace(fStr, String.Empty)
                End If
            Next
            Return GetSqlByExact(DbKey, ExStr, IsExact)
        End Function
        ''' <summary>
        ''' 根据条件表达式，获取SQL语句（私有）
        ''' </summary>
        ''' <param name="DbKey">字段名</param>
        ''' <param name="ExStr">待转换表达式</param>
        ''' <param name="IsExact">是否精确查找</param>
        ''' <returns>转换后的SQL</returns>
        ''' <remarks>根据条件表达式，获取SQL语句（私有）</remarks>
        Private Shared Function GetSqlByExact(ByVal DbKey As String, ByVal ExStr As String, ByVal IsExact As Boolean) As String
            '判断是否为精确查询
            Select Case IsExact
                Case True
                    ExStr = String.Format("{0} = '{1}'", DbKey, ExStr)
                    Return ExStr
                Case Else
                    Return GetSqlByAnd(DbKey, ExStr)
            End Select
        End Function
        ''' <summary>
        ''' 01、拼接AND条件（私有）
        ''' </summary>
        ''' <param name="DbKey">字段名</param>
        ''' <param name="ExStr">待转换表达式</param>
        ''' <returns>转换后的SQL</returns>
        ''' <remarks>01、拼接AND条件（私有）</remarks>
        Private Shared Function GetSqlByAnd(ByVal DbKey As String, ByVal ExStr As String) As String
            Dim SpliteByAnd() As String = ExStr.Trim.Split(New String() {"&&"}, StringSplitOptions.None)
            Dim TmpStr As String = String.Empty
            '判断是否存在And条件
            Select Case SpliteByAnd.Length
                Case 1
                    ExStr = GetSqlByOr(DbKey, SpliteByAnd(0))
                    Return ExStr
                Case Else
                    Dim OrStr As String = GetSqlByOr(DbKey, SpliteByAnd(0))
                    '判断第一位是否为空
                    If OrStr <> String.Empty Then
                        ExStr = String.Format("{0} And ", OrStr)
                        If SpliteByAnd.Length > 2 Then
                            ExStr += " "
                            For i As Integer = 1 To SpliteByAnd.Length - 1
                                TmpStr += String.Format("{0} And ", String.Format("{0} ", GetSqlByOr(DbKey, SpliteByAnd(i))))
                            Next
                            ExStr += String.Format("{0} ", Mid(TmpStr, 1, TmpStr.Length - 4))
                        Else
                            ExStr += String.Format("{0} ", GetSqlByOr(DbKey, SpliteByAnd(1)))
                        End If
                    Else
                        ExStr = String.Empty
                        For i As Integer = 1 To SpliteByAnd.Length - 1
                            TmpStr += String.Format("{0} And ", String.Format("{0} ", GetSqlByOr(DbKey, SpliteByAnd(i))))
                        Next
                        If TmpStr.Length > 4 Then
                            ExStr += String.Format("{0} ", Mid(TmpStr, 1, TmpStr.Length - 4))
                        End If
                    End If
                    If ExStr.Trim <> String.Empty Then
                        ExStr = String.Format("({0})", ExStr.Trim)
                    End If
                    Return ExStr.Trim
            End Select
        End Function

        ''' <summary>
        ''' 02、拼接Or条件（私有）
        ''' </summary>
        ''' <param name="DbKey">字段名</param>
        ''' <param name="ExStr">待转换表达式</param>
        ''' <returns>转换后的SQL</returns>
        ''' <remarks>02、拼接Or条件（私有）</remarks>
        Private Shared Function GetSqlByOr(ByVal DbKey As String, ByVal ExStr As String) As String
            Dim SpliteByOr() As String = ExStr.Trim.Split(New String() {"||"}, StringSplitOptions.None)
            Dim TmpStr As String = String.Empty
            Select Case SpliteByOr.Length
                Case 1
                    ExStr = GetSqlByNot(DbKey, SpliteByOr(0))
                    Return ExStr
                Case Else
                    Dim NotStr As String = GetSqlByNot(DbKey, SpliteByOr(0))
                    '判断第一位是否为空
                    If NotStr <> String.Empty Then
                        ExStr = String.Format("{0} Or ", NotStr)
                        If SpliteByOr.Length > 2 Then
                            ExStr += " "
                            For i As Integer = 1 To SpliteByOr.Length - 1
                                TmpStr += String.Format("{0} Or ", String.Format("{0} ", GetSqlByNot(DbKey, SpliteByOr(i))))
                            Next
                            ExStr += String.Format("{0} ", Mid(TmpStr, 1, TmpStr.Length - 3))
                        Else
                            ExStr += String.Format("{0} ", GetSqlByNot(DbKey, SpliteByOr(1)))
                        End If
                    Else
                        ExStr = String.Empty
                        For i As Integer = 1 To SpliteByOr.Length - 1
                            TmpStr += String.Format("{0} Or ", String.Format("{0} ", GetSqlByNot(DbKey, SpliteByOr(i))))
                        Next
                        If TmpStr.Length > 3 Then
                            ExStr += String.Format("{0} ", Mid(TmpStr, 1, TmpStr.Length - 3))
                        End If
                    End If
                    If ExStr.Trim <> String.Empty Then
                        ExStr = String.Format("({0})", ExStr.Trim)
                    End If
                    Return ExStr.Trim
            End Select
        End Function

        ''' <summary>
        ''' 03、拼接Not条件（私有）
        ''' </summary>
        ''' <param name="DbKey">字段名</param>
        ''' <param name="ExStr">待转换表达式</param>
        ''' <returns>转换后的SQL</returns>
        ''' <remarks>03、拼接Not条件（私有）</remarks>
        Private Shared Function GetSqlByNot(ByVal DbKey As String, ByVal ExStr As String) As String
            Dim SpliteByNot() As String = ExStr.Trim.Split(New String() {"!="}, StringSplitOptions.None)
            Dim TmpStr As String = String.Empty
            Select Case SpliteByNot.Length
                Case 1
                    If SpliteByNot(0) = String.Empty Then
                        Return String.Empty
                    End If
                    ExStr = String.Format("{0} like '%{1}%'", DbKey, SpliteByNot(0))
                    Return ExStr
                Case Else
                    '判断第一位是否为空
                    If SpliteByNot(0) <> String.Empty Then
                        ExStr = String.Format("{0} Like '%{1}%' And ", DbKey, SpliteByNot(0))
                        If SpliteByNot.Length > 2 Then
                            ExStr += "("
                            For i As Integer = 1 To SpliteByNot.Length - 1
                                TmpStr += String.Format("{0} Not Like '%{1}%' Or ", DbKey, SpliteByNot(i))
                            Next
                            ExStr += String.Format("{0})", Mid(TmpStr, 1, TmpStr.Length - 3))
                        Else
                            ExStr += String.Format("{0} Not Like '%{1}%' ", DbKey, SpliteByNot(1))
                        End If
                    Else
                        ExStr = String.Empty
                        For i As Integer = 1 To SpliteByNot.Length - 1
                            If SpliteByNot(i) = String.Empty Then
                                Continue For
                            End If
                            TmpStr += String.Format("{0} Not Like '%{1}%' Or ", DbKey, SpliteByNot(i))
                        Next
                        If TmpStr.Length > 3 Then
                            ExStr += String.Format("{0} ", Mid(TmpStr, 1, TmpStr.Length - 3))
                        End If
                    End If
                    If ExStr.Trim <> String.Empty Then
                        ExStr = String.Format("({0})", ExStr.Trim)
                    End If
                    Return ExStr.Trim
            End Select
        End Function

    End Class
End Namespace