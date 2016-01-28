Imports IdeaBox.Utils.Security

Namespace Utils.FileSystem.String
    Public Class RandStr
        '****************************************************************************
        '   产生一个6位的随机数，主要用于验证码
        '****************************************************************************
        Public Overloads Shared Function AttachCode() As String
            AttachCode = String.Empty
            Dim rnd As New Random
            Dim CodeList() As String = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A",
                                        "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                                        "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W",
                                        "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h",
                                        "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s",
                                        "t", "u", "v", "w", "x", "y", "z"}
            For I As Integer = 0 To 5
                AttachCode += CodeList(rnd.Next(0, CodeList.Length - 1))
            Next
            Return AttachCode
        End Function

        '****************************************************************************
        '   产生一个指定长度（不为0）的随机数，主要用于验证码
        '****************************************************************************
        Public Overloads Shared Function AttachCode(ByVal Len As Integer) As String
            AttachCode = String.Empty
            Dim rnd As New Random
            Dim CodeList() As String = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A",
                                        "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                                        "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W",
                                        "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h",
                                        "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s",
                                        "t", "u", "v", "w", "x", "y", "z"}
            If Len <= 0 Then
                Throw New Exception("长度不能小于等于0")
            End If
            For I As Integer = 0 To Len - 1
                AttachCode += CodeList(rnd.Next(0, CodeList.Length - 1))
            Next
            Return AttachCode
        End Function

        Public Shared Function GetUUID() As String
            Dim TmpStr As String = String.Format("{0:yyyy-MM-dd HH:mm:ss.fffffff}{1}", DateTime.Now, RandStr.AttachCode(6))
            Dim TmpUUId As String = MD5.MD5(TmpStr, 32)
            Dim UULen As Integer = System.Text.Encoding.Default.GetBytes(TmpUUId).Length
            Select Case UULen
                Case 32
                    Return TmpUUId.ToLower
                Case Is < 32
                    Dim TmpLen As Integer = 32 - UULen
                    Return (TmpUUId & AttachCode(TmpLen, True)).ToLower
                Case Else
                    Return Mid(TmpUUId, 1, 32).ToLower
            End Select
        End Function

        '****************************************************************************
        '   产生一个指定长度（不为0）的随机数，主要用于验证码
        '****************************************************************************
        Public Overloads Shared Function AttachCode(ByVal Len As Integer, ByVal IsNumStr As Boolean) As String
            AttachCode = String.Empty
            Dim rnd As New Random
            Dim CodeList() As String = Nothing
            If IsNumStr = True Then
                CodeList = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
            Else
                CodeList = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A",
                            "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                            "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W",
                            "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h",
                            "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s",
                            "t", "u", "v", "w", "x", "y", "z"}
            End If
            If Len <= 0 Then
                Throw New Exception("长度不能小于等于0")
            End If
            For I As Integer = 0 To Len - 1
                AttachCode += CodeList(rnd.Next(0, CodeList.Length - 1))
            Next
            Return AttachCode
        End Function

        Public Shared Function GetRandomStr() As String
            Dim generator As New Random
            Dim randomValue As Integer = generator.Next(10000, 99999)
            Return randomValue.ToString & Now.Date.ToString("_ssmm")
        End Function
    End Class
End Namespace