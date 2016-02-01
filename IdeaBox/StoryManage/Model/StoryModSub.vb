Namespace StoryManage.Model
    Public Class StoryModSub
        '清除字符串不良字符，ClearStr(网址 as string)as string
        ''' <summary>
        ''' 清除字符串不良字符
        ''' </summary>
        ''' <param name="Str">源文本 as string</param>
        ''' <returns>清除掉不良字符 as string</returns>
        ''' <remarks>清除字符串不良字符</remarks>
        Public Function ClearStr(ByVal Str As String) As String
            Dim i, n As Integer
            Dim s As String = "《丨》丨 丨&nbsp;丨<br />丨<br/>丨-"
            Str = Replace(Str, Chr(9), "")
            Str = Replace(Str, vbCrLf, "")
            n = UBound(Split(s, "丨"))
            Try
                For i = 0 To n : Str = Replace(Str, Split(s, "丨")(i), "") : Next i
            Catch ex As Exception

            End Try
            Return Str
        End Function
        '拆解字段，GetTxtStr(文本源 as string,起始字标 as string,终止字标 as string ,起始位  as integer ,终止位 as integer)as string
        ''' <summary>
        ''' 拆解字段【仅作备用拆解字段】
        ''' </summary>
        ''' <param name="TxtStr">源文本 as string</param>
        ''' <param name="BegStr">起始字标 as string</param>
        ''' <param name="EndStr">终止字标 as string</param>
        ''' <param name="BegNum">起始补偿位 as integer</param>
        ''' <param name="EndNum">终止补偿位 as integer</param>
        ''' <returns>获取拆解到的指定文本 as string</returns>
        ''' <remarks>拆解字段【仅作备用拆解字段】</remarks>
        Public Function GetTxtStr(ByVal TxtStr As String, ByVal BegStr As String, ByVal EndStr As String, Optional ByVal BegNum As Integer = 0, Optional ByVal EndNum As Integer = 0) As String
            Dim p1, p2 As Integer
            Dim s As String
            Try
                p1 = InStr(1, TxtStr, BegStr)
                p2 = InStr(p1, TxtStr, EndStr)
                s = ClearStr(Trim(Mid(TxtStr, p1 + Len(BegStr) + BegNum, p2 - p1 - Len(BegStr) - EndNum)))
            Catch ex As Exception
                Return ex.Message
            End Try
            Return s
        End Function

        '分类差异性统一化
        ''' <summary>
        ''' 解决各个不同电子书网站分类差异性统一化
        ''' </summary>
        ''' <param name="TxtItem">源分类 as string</param>
        ''' <returns>差异统一化的分类 as string</returns>
        ''' <remarks>解决各个不同电子书网站分类差异性统一化</remarks>
        Public Function ToTxtItem(ByVal TxtItem As String) As String
            ' 差异性处置, 玄幻奇幻,武侠修真,都市小说,科幻小说,恐怖小说,历史军事,网游小说,文学名著
            Select Case TxtItem
                Case "玄幻魔法" : TxtItem = "玄幻奇幻"
                Case "都市言情" : TxtItem = "都市小说"
                Case "历史军事" : TxtItem = "历史军事"
                Case "网游竞技" : TxtItem = "网游小说"
                Case "恐怖灵异" : TxtItem = "恐怖小说"
                Case "官场职场" : TxtItem = "都市小说"
            End Select
            Return TxtItem
        End Function
    End Class
End Namespace
