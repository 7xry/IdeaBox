Namespace Utils.Security
    Public Class MD5
        '****************************************************************************
        '   MD5 加密函数
        '   strSource   ——  加密对象
        '   Code        ——  密钥，选择项：16 or 32 or 128
        '****************************************************************************
        Public Shared Function MD5(ByVal strSource As String, ByVal Code As Int16) As String
            '这里用的是ascii编码密码原文，如果要用汉字做密码，可以用UnicodeEncoding，但会与ASP中的MD5函数不兼容 
            Dim dataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(strSource)
            Dim hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(dataToHash)
            Dim i As Integer
            MD5 = Nothing
            Select Case Code
                Case 16 '选择16位字符的加密结果 
                    For i = 4 To 11
                        MD5 += Hex(hashvalue(i)).ToLower
                    Next
                Case 32 '选择32位字符的加密结果 
                    For i = 0 To 15
                        MD5 += Hex(hashvalue(i)).ToLower
                    Next
                Case Else 'Code错误时，返回全部字符串，即32位字符 
                    For i = 0 To hashvalue.Length - 1
                        MD5 += Hex(hashvalue(i)).ToLower
                    Next
            End Select
        End Function
    End Class
End Namespace