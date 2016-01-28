Imports System.Drawing.Imaging
Imports System.IO

Namespace Utils.FileSystem.Images
    Public Class ImageOpt

#Region "生成缩略图函数"
        ''' <summary>
        ''' 生成缩略图
        ''' </summary>
        ''' <param name="ImgPath">源图片路径</param>
        ''' <param name="WInt">缩放宽度</param>
        ''' <param name="HInt">缩放高度</param>
        ''' <returns>图像二进制流</returns>
        ''' <remarks>生成缩略图</remarks>
        Public Overloads Shared Function MakeSmallImg(ByVal ImgPath As String, ByVal WInt As Integer, ByVal HInt As Integer) As MemoryStream
            '从文件取得图片对象
            Dim Img As Image = Image.FromFile(ImgPath)
            '取得图片信息
            Dim oldH As Integer = Img.Height
            Dim oldW As Integer = Img.Width
            Dim h1 As Double = Double.Parse(oldH.ToString()) / WInt
            Dim w1 As Double = Double.Parse(oldW.ToString()) / HInt
            Dim f As Double = IIf(h1 > w1, h1, w1)
            Dim newH, newW As Integer
            If (f < 1.0) Then
                newH = oldH
                newW = oldW
            Else
                newH = CType(oldH / f, Integer)
                newW = CType(oldW / f, Integer)
            End If
            '取图片大小
            Dim ImgSize As New Size(newW, newH)
            '新建一个bmp
            Dim bmp As Image = New Bitmap(ImgSize.Width, ImgSize.Height)
            '新建一个画板
            Dim g As Graphics = Graphics.FromImage(bmp)
            '设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            '清空一下画布
            g.Clear(Color.Transparent)
            '在指定位置画图
            g.DrawImage(Img, New Rectangle(0, 0, bmp.Width, bmp.Height), New Rectangle(0, 0, Img.Width, Img.Height), GraphicsUnit.Pixel)
            '保存高清晰的缩略图
            Dim ms As New MemoryStream
            bmp.Save(ms, ImageFormat.Png)
            g.Dispose()
            Img.Dispose()
            bmp.Dispose()
            Return ms
        End Function

        ''' <summary>
        ''' 生成缩略图
        ''' </summary>
        ''' <param name="ImgPath">源图片路径</param>
        ''' <param name="saveImgPath">目标图片路径</param>
        ''' <param name="WInt">缩放宽度</param>
        ''' <param name="HInt">缩放高度</param>
        ''' <remarks>生成缩略图</remarks>
        Public Overloads Shared Sub MakeSmallImg(ByVal ImgPath As String, ByVal saveImgPath As String, ByVal WInt As Integer, ByVal HInt As Integer)
            '从文件取得图片对象
            Dim Img As Image = Image.FromFile(ImgPath)
            '取得图片信息
            Dim oldH As Integer = Img.Height
            Dim oldW As Integer = Img.Width
            Dim h1 As Double = Double.Parse(oldH.ToString()) / WInt
            Dim w1 As Double = Double.Parse(oldW.ToString()) / HInt
            Dim f As Double = IIf(h1 > w1, h1, w1)
            Dim newH, newW As Integer
            If (f < 1.0) Then
                newH = oldH
                newW = oldW
            Else
                newH = CType(oldH / f, Integer)
                newW = CType(oldW / f, Integer)
            End If
            '取图片大小
            Dim ImgSize As New Size(newW, newH)
            '新建一个bmp
            Dim bmp As Image = New Bitmap(ImgSize.Width, ImgSize.Height)
            '新建一个画板
            Dim g As Graphics = Graphics.FromImage(bmp)
            '设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            '清空一下画布
            g.Clear(Color.Transparent)
            '在指定位置画图
            g.DrawImage(Img, New Rectangle(0, 0, bmp.Width, bmp.Height), New Rectangle(0, 0, Img.Width, Img.Height), GraphicsUnit.Pixel)
            '保存高清晰的缩略图
            bmp.Save(saveImgPath, ImageFormat.Png)
            g.Dispose()
            Img.Dispose()
            bmp.Dispose()
        End Sub

        ''' <summary>
        ''' 生成缩略图
        ''' </summary>
        ''' <param name="ImgByte">源图片二进制流</param>
        ''' <param name="WInt">缩放宽度</param>
        ''' <param name="HInt">缩放高度</param>
        ''' <returns>图片二进制流</returns>
        ''' <remarks>生成缩略图</remarks>
        Public Overloads Shared Function MakeSmallImg(ByVal ImgByte As Byte(), ByVal WInt As Integer, ByVal HInt As Integer) As MemoryStream
            '从文件取得图片对象
            Dim FMs As New MemoryStream(ImgByte)
            Dim Img As Image = Image.FromStream(FMs)
            '取得图片信息
            Dim oldH As Integer = Img.Height
            Dim oldW As Integer = Img.Width
            Dim h1 As Double = Double.Parse(oldH.ToString()) / WInt
            Dim w1 As Double = Double.Parse(oldW.ToString()) / HInt
            Dim f As Double = IIf(h1 > w1, h1, w1)
            Dim newH, newW As Integer
            If (f < 1.0) Then
                newH = oldH
                newW = oldW
            Else
                newH = CType(oldH / f, Integer)
                newW = CType(oldW / f, Integer)
            End If
            '取图片大小
            Dim ImgSize As New Size(newW, newH)
            '新建一个bmp
            Dim bmp As Image = New Bitmap(ImgSize.Width, ImgSize.Height)
            '新建一个画板
            Dim g As Graphics = Graphics.FromImage(bmp)
            '设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            '清空一下画布
            g.Clear(Color.Transparent)
            '在指定位置画图
            g.DrawImage(Img, New Rectangle(0, 0, bmp.Width, bmp.Height), New Rectangle(0, 0, Img.Width, Img.Height), GraphicsUnit.Pixel)
            '保存高清晰的缩略图
            Dim ms As New MemoryStream
            bmp.Save(ms, ImageFormat.Png)
            g.Dispose()
            Img.Dispose()
            bmp.Dispose()
            Return ms
        End Function
#End Region

#Region "获取图像"
        ''' <summary>
        ''' 获取图像
        ''' </summary>
        ''' <param name="ImagePath">源图片路径</param>
        ''' <returns>图片对象</returns>
        ''' <remarks>获取图像</remarks>
        Public Overloads Shared Function GetImage(ByVal ImagePath As String) As Image
            Dim myFileStream As New FileStream(ImagePath, FileMode.Open)
            Dim data() As Byte
            ReDim data(myFileStream.Length - 1)
            myFileStream.Read(data, 0, myFileStream.Length)
            myFileStream.Close()
            Dim ms As New MemoryStream(data)
            Return Image.FromStream(ms)
        End Function
#End Region

    End Class
End Namespace