Imports HtmlAgilityPack
Imports IdeaBox.Utils.FileSystem.Net
Imports IdeaBox.StoryManage.Model
Imports IdeaBox.StoryManage.API
Imports IdeaBox.StoryManage.View
Imports System.Threading

Namespace StoryManage.Impl
    Public Class AqTxtImpl
        Implements IStoryWeb


        '采集网站网址
        Property Url As String Implements API.IStoryWeb.Url

        ''' <summary>
        ''' 构造函数
        ''' </summary>
        ''' <remarks></remarks>
        Sub New()
            Url = "http://www.aqtxt.com"
        End Sub

        ''' <summary>
        ''' 获取网站书籍页数
        ''' </summary>
        ''' <returns>最大页数</returns>
        ''' <remarks>获取网站书籍页数</remarks>
        Public Function GetPageCount() As Integer Implements API.IStoryWeb.GetPageCount
            Dim rootNode As HtmlNode = HttpHelper.OpenUrl(String.Format("{0}/finished/1.htm", Url))
            Dim PageCount As String = HttpHelper.GetNodeStr(rootNode, "//*[@id='newbook']/div[16]/a[11]", 1)
            Return CInt(PageCount.Replace(".htm", ""))
        End Function

        ''' <summary>
        ''' 采集书籍列表
        ''' </summary>
        ''' <param name="timer">计时器</param>
        ''' <remarks>采集书籍列表</remarks>
        Public Function GetBooks(ByVal timer As Stopwatch, ByVal fr As Fr_Story, ByVal TableName As String) As Boolean Implements API.IStoryWeb.GetBooks
            Dim pageCount As Integer = GetPageCount()
            Dim bookLs As New List(Of Story)
            For page As Integer = 1 To pageCount
                Dim rootNode As HtmlNode = HttpHelper.OpenUrl(String.Format("{0}/finished/{1}.htm", Url, page))
                Dim NodeCollection As HtmlNodeCollection = HttpHelper.GetNodeCollection(rootNode, "//*[@id='newbook']/div/ul/li/a")
                For i As Integer = 1 To NodeCollection.Count
                    Dim book As New Story
                    '书名
                    book.BookName = NodeCollection(i - 1).InnerText.Replace("《", "").Replace("》", "").Trim
                    '作者
                    book.Author = HttpHelper.GetNodeStr(rootNode, String.Format("//*[@id='newbook']/div[{0}]/ul/li[@class='tj']/label[1]/font", i)).Trim
                    '分类
                    book.Category = HttpHelper.GetNodeStr(rootNode, String.Format("//*[@id='newbook']/div[{0}]/ul/li[@class='tj']/label[4]/font", i))
                    '评分
                    book.Rating = HttpHelper.GetNodeStr(rootNode, String.Format("//*[@id='newbook']/div[{0}]/ul/li[@class='title']/span", i)).Replace("分", "").Trim
                    '下载量
                    book.DownloadQuantity = HttpHelper.GetNodeStr(rootNode, String.Format("//*[@id='newbook']/div[{0}]/ul/li[@class='tj']/label[2]/font", i)).Replace("次", "").Trim
                    '小说简介
                    book.Abstract = HttpHelper.GetNodeStr(rootNode, String.Format("//*[@id='newbook']/div[{0}]/ul/li[@class='intro']", i)).Replace("简介：", "").Replace("&lt;", "").Replace("br/", "").Replace("&gt;", "").Replace("&amp;", "").Replace("nbsp;", "").Replace("'", "").Replace("&quot;", "").Trim
                    '下载地址
                    book.DownloadAddr = String.Format("{0}{1}", Url, HttpHelper.GetNodeStr(NodeCollection(i - 1), 1)).Trim
                    '生成是否已读
                    book.IsRead = 0
                    bookLs.Add(book)
                    fr.SetStatInvoke(String.Format("正在采集：第 {0} 页 / 共 {1} 页 , 累计耗时：{2}", page, pageCount, timer.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")))
                Next
                If bookLs.Count >= 300 Or page = pageCount Then
                    StoryOpt.Add(bookLs, TableName)
                    bookLs = New List(Of Story)
                End If
            Next
            Return True
        End Function

        ''' <summary>
        ''' 获取书籍详情
        ''' </summary>
        ''' <param name="book">书记对象</param>
        ''' <returns>书籍详情信息</returns>
        ''' <remarks>获取书籍详情</remarks>
        Public Function GetBookInfo(ByVal book As Story) As Story Implements API.IStoryWeb.GetBookInfo
            Dim newBook As New Story
            Try
                Dim rootNode As HtmlNode = HttpHelper.OpenUrl(book.DownloadAddr)
                '书名
                newBook.BookName = book.BookName.Replace("《", "").Replace("》", "").Trim
                '作者
                newBook.Author = HttpHelper.GetNodeStr(rootNode, "//*[@id='author']").Replace("作者：", "").Trim
                '分类
                newBook.Category = HttpHelper.GetNodeStr(rootNode, "//*[@id='submenu']/h2/a[@class='lan']").Replace("下载", "").Trim
                '文件大小
                newBook.FileSize = HttpHelper.GetNodeStr(rootNode, "//*[@class='in']/em").Trim
                '评分
                newBook.Rating = HttpHelper.GetNodeStr(rootNode, "//*[@id='pingfen']").Trim
                '下载量
                newBook.DownloadQuantity = HttpHelper.GetNodeStr(rootNode, "//*[@class='in']/label").Trim
                '上传日期
                newBook.UploadDate = HttpHelper.GetNodeStr(rootNode, "//*[@id='txtleft']/div/ul[1]/li[5]").Replace("上传日期:", "").Trim
                '小说简介
                newBook.Abstract = HttpHelper.GetNodeStr(rootNode, "//*[@class='item']/p").Replace("内容简介：", "").Trim
                '下载地址
                newBook.DownloadAddr = HttpHelper.GetNodeStr(rootNode, "//*[@id='txtdown']/ul/li[2]/a", 1).Trim
                '生成是否已读
                newBook.IsRead = 0
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Dict.MsgType.ErrorMsg, False)
            End Try
            Return newBook
        End Function
    End Class
End Namespace
