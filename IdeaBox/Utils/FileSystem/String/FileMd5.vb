Imports System.Text
Imports System.Security.Cryptography

Namespace Utils.FileSystem.String
    Public Class FileMd5
        '获取字符串MD5值的函数，可获取文件MD5
        ''' <summary>
        ''' 获取文件的MD5值
        ''' </summary>
        ''' <param name="filePath">文件的绝对路径</param>
        ''' <returns>返回32位MD5值</returns>
        ''' <remarks></remarks>
        Public Shared Function getFileMd5Hash(ByVal filePath As String) As String
            '创建MD5实例
            Dim md5Hasher As MD5 = MD5.Create()

            '以字节形式读取文件
            Dim originalDate As Byte() = My.Computer.FileSystem.ReadAllBytes(filePath)

            '计算MD5，Imports System.Security.Cryptography
            Dim data As Byte() = md5Hasher.ComputeHash(originalDate)

            '创建可变字符串，Imports System.Text
            Dim sBuilder As New StringBuilder()

            ' 连接每一个 byte 的 hash 码，并格式化为十六进制字符串
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i

            Return sBuilder.ToString
        End Function

        '下面的代码示例计算字符串的 MD5 哈希值，并将该哈希作为 32 字符的十六进制格式字符串返回。
        '此代码示例中创建的哈希字符串与能创建 32 字符的十六进制格式哈希字符串的任何 MD5 哈希函数（在任何平台上）兼容。
        Public Shared Function getStrMd5Hash(ByVal input As String) As String
            '重载函数，此函数返回字符串的 hash 值

            '创建MD5类实例

            Dim md5Hasher As MD5 = MD5.Create()

            '将输入内容转换为byte数组并计算其hash值
            Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

            '创建一个 Stringbuilder 存储 bytes
            '并创建一个字符串
            Dim sBuilder As New StringBuilder()

            ' 连接每一个 byte 的 hash 码，并格式化为十六进制字符串
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i

            ' 返回十六进制字符串
            Return sBuilder.ToString()

        End Function
    End Class
End Namespace

