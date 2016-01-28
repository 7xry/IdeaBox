Imports System.IO
Imports System.Xml
Imports System.Text

Namespace Utils.FileSystem.String
    Public Class StrConvert
        '****************************************************************************
        '   截取指定长度的文本（包含全角、半角、英文、数字模式）
        '****************************************************************************
        Public Shared Function InterceptStr(ByVal Str As String, ByVal Length As Integer) As String
            Dim i As Integer = 0, j As Integer = 0
            For Each cs As Char In Str
                If CType(AscW(cs) > 127, Integer) Then
                    i += 2
                Else
                    i = i + 1
                End If
                If i > Length Then
                    Str = Str.Substring(0, j)
                    Exit For
                End If
                j = j + 1
            Next
            Return Str
        End Function

        '****************************************************************************
        '   数字转汉字
        '****************************************************************************
        Public Shared Function ConvertToChineseNum(ByVal Str As String, ByVal IsSimplified As Boolean) As String
            ConvertToChineseNum = Nothing
            For i As Integer = 0 To Len(Trim(Str)) - 1
                Dim tmp As String = Str.Substring(i, 1)
                Select Case tmp
                    Case 0 To 9
                        Select Case IsSimplified
                            Case True
                                Dim CNum() As String = {"〇", "一", "二", "三", "四", "五", "六", "七", "八", "九"}
                                tmp = CNum(tmp)
                            Case False
                                Dim CNum() As String = {"零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖"}
                                tmp = CNum(tmp)
                        End Select

                    Case Else
                        tmp = tmp
                End Select
                ConvertToChineseNum += tmp
            Next
            Return ConvertToChineseNum
        End Function

        '****************************************************************************
        '   根据ID获取数字位标识符
        '****************************************************************************
        Public Shared Function GetNumFlag(ByVal index As Integer, ByVal IsSimplified As Boolean) As String
            Select Case index
                Case 1
                    If IsSimplified = True Then
                        Return "十"
                    Else
                        Return "拾"
                    End If
                Case 2
                    If IsSimplified = True Then
                        Return "百"
                    Else
                        Return "佰"
                    End If
                Case 3
                    If IsSimplified = True Then
                        Return "千"
                    Else
                        Return "仟"
                    End If
                Case 4
                    If IsSimplified = True Then
                        Return "万"
                    Else
                        Return "萬"
                    End If
                Case Else
                    Return String.Empty
            End Select
        End Function

        '****************************************************************************
        '   数字转汉字
        '****************************************************************************
        Public Shared Function ToChineseNumer(ByVal Str As String, ByVal IsSimplified As Boolean) As String
            ToChineseNumer = Nothing
            Dim StrLen As Integer = Str.Length - 1
            Dim tmpChineseNumber As String = String.Empty
            Dim tmpValue As String = String.Empty
            Dim l As Long = CType(Str, Long)
            If l > 99999 Then
                Return Nothing
            End If
            For i As Integer = 0 To StrLen
                Dim q As Integer = (l Mod 10)
                l = l \ 10
                Select Case IsSimplified
                    Case True
                        Dim CNum() As String = {"〇", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "百", "千", "万", "亿"}
                        If q >= 0 Then
                            tmpChineseNumber = CNum(q)
                            If tmpValue = "〇" And tmpChineseNumber = "〇" Then
                                tmpChineseNumber = String.Empty
                            ElseIf tmpChineseNumber = "〇" And i = 0 Then
                                tmpChineseNumber = String.Empty
                            ElseIf tmpChineseNumber = "〇" And ToChineseNumer = String.Empty Then
                                tmpChineseNumber = String.Empty
                            End If
                        End If
                    Case False
                        Dim CNum() As String = {"零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾", "佰", "仟", "萬", "億"}
                        If q >= 0 Then
                            tmpChineseNumber = CNum(q)
                            If tmpValue = "零" And tmpChineseNumber = "零" Then
                                tmpChineseNumber = String.Empty
                            ElseIf tmpChineseNumber = "零" And i = 0 Then
                                tmpChineseNumber = String.Empty
                            ElseIf tmpChineseNumber = "零" And ToChineseNumer = String.Empty Then
                                tmpChineseNumber = String.Empty
                            End If
                        End If
                End Select
                ToChineseNumer = tmpChineseNumber & IIf(q > 0, GetNumFlag(i, IsSimplified), String.Empty) & ToChineseNumer
                If tmpChineseNumber <> String.Empty Then
                    tmpValue = tmpChineseNumber
                End If
            Next
            Return ToChineseNumer
        End Function

        '****************************************************************************
        '   字符串转日期
        '****************************************************************************
        Public Shared Function ConvertToDate(ByVal DateString As String) As Date
            Try
                If DateString.Length <> 8 Then
                    Return Nothing
                End If
                Return New Date(Mid(DateString, 1, 4), Mid(DateString, 5, 2), Mid(DateString, 7, 2))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '****************************************************************************
        '   DataTable 转 XML
        '****************************************************************************
        Public Shared Function ConvertDataTableToXML(ByVal xmlDS As DataTable) As String
            Dim stream As MemoryStream = Nothing
            Dim writer As XmlTextWriter = Nothing
            Try
                stream = New MemoryStream()
                writer = New XmlTextWriter(stream, Encoding.Default)
                xmlDS.WriteXml(writer)
                Dim count As Integer = CInt(stream.Length)
                Dim arr As Byte() = New Byte(count) {}
                stream.Seek(0, SeekOrigin.Begin)
                stream.Read(arr, 0, count)
                Dim utf As New UTF8Encoding
                Return utf.GetString(arr)
            Catch ex As Exception
                Throw New Exception(ex.ToString())
            Finally
                If writer IsNot Nothing Then
                    writer.Close()
                End If
            End Try
        End Function

        '****************************************************************************
        '   XML 转 DateSet
        '****************************************************************************
        Public Shared Function ConvertXMLToDataSet(ByVal XmlData As String) As DataSet
            Dim stream As StringReader = Nothing
            Dim reader As XmlTextReader = Nothing
            Try
                Dim xmlDS As New DataSet
                stream = New StringReader(XmlData)
                reader = New XmlTextReader(stream)
                xmlDS.ReadXml(reader)
                Return xmlDS
            Catch ex As Exception
                Throw New Exception(ex.ToString())
            Finally
                If reader IsNot Nothing Then
                    reader.Close()
                End If
            End Try
        End Function

        '****************************************************************************
        '   XML 转 DataTable
        '****************************************************************************
        Public Shared Function ConvertXMLToDataTable(ByVal XmlData As String) As DataTable
            Dim stream As StringReader = Nothing
            Dim reader As XmlTextReader = Nothing
            Try
                Dim xmlDS As New DataSet
                stream = New StringReader(XmlData)
                reader = New XmlTextReader(stream)
                xmlDS.ReadXml(reader)
                Return xmlDS.Tables(0)
            Catch ex As Exception
                Return Nothing
            Finally
                If reader IsNot Nothing Then
                    reader.Close()
                End If
            End Try
        End Function

        '****************************************************************************
        '   XML 转 DataTable
        '****************************************************************************
        Public Shared Function TransformStr(ByVal OStr As String, ByVal MaxLen As Integer, ByVal IsRight As Boolean) As String
            Dim ML As Integer = MaxLen
            Try
                TransformStr = String.Empty
                If OStr = String.Empty Then
                    Return Space(ML)
                End If
                Dim VL As Integer = Encoding.Default.GetByteCount(OStr)
                Select Case IsRight
                    Case True
                        If VL <= ML Then
                            TransformStr = Space(ML - VL) & OStr
                        Else
                            TransformStr = InterceptStr(OStr, ML)
                        End If
                    Case Else
                        If VL <= ML Then
                            TransformStr = OStr & Space(ML - VL)
                        Else
                            TransformStr = InterceptStr(OStr, ML)
                        End If
                End Select
                Return TransformStr
            Catch ex As Exception
                MsgBox(ex.ToString())
                Return Space(ML)
            End Try
        End Function

        Public Shared Function IsNeedTransform(ByVal OStr As String, ByVal MaxLen As Integer) As Boolean
            Dim ML As Integer = MaxLen
            Try
                IsNeedTransform = False
                If OStr = String.Empty Then
                    Return True
                End If
                Dim VL As Integer = Encoding.Default.GetByteCount(OStr)
                If VL <= ML Then
                    IsNeedTransform = True
                Else
                    IsNeedTransform = False
                End If
                Return IsNeedTransform
            Catch ex As Exception
                MsgBox(ex.ToString())
                Return False
            End Try
        End Function

        Public Shared Function StringToURLUTF8(ByVal Target As String) As String
            If Target = "" Then Return ""
            Dim Resault As String = ""
            For Each b As Byte In Encoding.UTF8.GetBytes(Target)
                Resault &= "%" & b.ToString("X")
            Next
            Return Resault
        End Function

        Public Shared Function StringAsUtf8Bytes(ByVal strData As String) As Byte()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(strData)
            Return bytes
        End Function

        ''' <summary>
        ''' IP地址输入格式化
        ''' </summary>
        ''' <param name="IpAddr">IP地址</param>
        ''' <returns>格式化的IP地址</returns>
        ''' <remarks>IP地址输入格式化，例：080.096.121.6  →  80.96.121.6</remarks>
        Public Shared Function MaskIpAddr(ByVal IpAddr As String) As String
            Dim Ip() As String = IpAddr.Split(".")
            If Ip.Length <> 4 Then
                Return String.Empty
            End If
            Dim FormatIp As String = String.Empty
            For i As Integer = 0 To Ip.Length - 1
                If Ip(i).StartsWith("0") And Ip(i).Length = 2 Then
                    FormatIp += Mid(Ip(i), 2, Ip(i).Length - 1)
                Else
                    FormatIp += Ip(i)
                End If
                If i < Ip.Length - 1 Then
                    FormatIp += "."
                End If
            Next
            Return FormatIp
        End Function

    End Class
End Namespace