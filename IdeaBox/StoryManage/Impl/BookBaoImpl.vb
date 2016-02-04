Imports HtmlAgilityPack
Imports IdeaBox.Utils.FileSystem.Net
Imports IdeaBox.StoryManage.Model
Imports IdeaBox.StoryManage.API

Namespace StoryManage.Impl
    Public Class BookBaoImpl
        Implements IStoryWeb


        '采集网站网址
        Property Url As String Implements API.IStoryWeb.Url

        ''' <summary>
        ''' 构造函数
        ''' </summary>
        ''' <remarks></remarks>
        Sub New()
            Url = "http://m.BookBao.com"
        End Sub
        ''' <summary>
        ''' 获取网站书籍页数
        ''' </summary>
        ''' <returns>最大页数</returns>
        ''' <remarks>获取网站书籍页数</remarks>
        Public Function GetPageCount() As Integer Implements API.IStoryWeb.GetPageCount
            Dim rootNode As HtmlNode = HttpHelper.OpenUrl(String.Format("{0}/QuanBook/list_1.html", Url.Replace("//m", "//www")))
            Dim PageCount As String = HttpHelper.GetNodeStr(rootNode, "//*[@id='pager']/a[@title='尾页']", 1)
            Return CInt(PageCount.Replace(".html", "").Replace("list_", ""))
        End Function

        ''' <summary>
        ''' 采集书籍列表
        ''' </summary>
        ''' <param name="timer">计时器</param>
        ''' <remarks>采集书籍列表</remarks>
        Public Function GetBooks(ByVal timer As Stopwatch, ByVal TableName As String) As Boolean Implements API.IStoryWeb.GetBooks
            Dim pageCount As Integer = GetPageCount()
            Dim bookLs As New List(Of Story)
            For page As Integer = 1 To pageCount
                Dim rootNode As HtmlNode = HttpHelper.OpenUrl(String.Format("{0}/QuanBook/list_{1}.html", Url, page))
                Dim NodeCollection As HtmlNodeCollection = HttpHelper.GetNodeCollection(rootNode, "//li[@class='am-g']")
                For i As Integer = 1 To NodeCollection.Count
                    Dim book As New Story
                    Dim TmpStr As String = HttpHelper.GetNodeStr(rootNode, String.Format("//li[@class='am-g'][{0}]/a", i)).Trim
                    '书名
                    book.BookName = Mid(TmpStr, TmpStr.IndexOf("]") + 2, TmpStr.IndexOf("(") - TmpStr.IndexOf("]") - 1).Trim
                    '作者
                    book.Author = Mid(TmpStr, TmpStr.IndexOf("(") + 2, TmpStr.IndexOf(")") - TmpStr.IndexOf("(") - 1)
                    '分类
                    book.Category = Mid(TmpStr, TmpStr.IndexOf("[") + 2, TmpStr.IndexOf("]") - TmpStr.IndexOf("[") - 1)
                    '下载地址
                    book.DownloadAddr = String.Format("{0}{1}", Url, HttpHelper.GetNodeStr(rootNode, String.Format("//li[@class='am-g'][{0}]/a", i), 1)).Trim
                    Dim tmpBook As Story = GetBookInfo(book)
                    '小说简介
                    book.Abstract = tmpBook.Abstract
                    
                    '生成是否已读
                    book.IsRead = 0
                    bookLs.Add(book)
                    frStory.SetStatInvoke(String.Format("正在采集：第 {0} 页 / 共 {1} 页 , 累计耗时：{2}", page, pageCount, timer.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")))
                Next
                If bookLs.Count >= 300 Or page = pageCount Then
                    storyOpt.Add(bookLs, TableName)
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
                newBook.BookName = HttpHelper.GetNodeStr(rootNode, "//*[@class='am-list-main']/h3").Trim
                '作者
                newBook.Author = HttpHelper.GetNodeStr(rootNode, "//*[@class='am-list-main']/p[1]").Replace("作者: ", "").Trim
                '分类
                newBook.Category = HttpHelper.GetNodeStr(rootNode, "//*[@class='am-list-main']/p[2]").Replace("类别: ", "").Trim
                '文件大小
                newBook.FileSize = HttpHelper.GetNodeStr(rootNode, "//*[@class='am-list-main']/p[3]").Replace("大小: ", "").Trim
                '上传日期
                newBook.UploadDate = HttpHelper.GetNodeStr(rootNode, "//*[@class='am-list-main']/p[4]").Replace("更新时间: ", "").Trim
                '小说简介
                newBook.Abstract = HttpHelper.GetNodeStr(rootNode, "//div[@class='content']").Trim
                '下载地址
                newBook.DownloadAddr = String.Format("{0}{1}", Url, HttpHelper.GetNodeStr(rootNode, "//div[@class='book_readbtn']/span[2]/a", 1)).Trim
                '生成是否已读
                newBook.IsRead = 0
                Dim tmpBook As New Story()
                rootNode = HttpHelper.OpenUrl(newBook.DownloadAddr.Replace("//m", "//www"))
                Dim TmpStr As String = HttpHelper.GetNodeStr(rootNode, "//div[@class='info_buttondiv']", 3).Trim
                newBook.DownloadAddr = Mid(TmpStr, TmpStr.IndexOf("dl('") + 5, TmpStr.IndexOf("',1") - TmpStr.IndexOf("dl('") - 4)
                newBook.DownloadAddr = String.Format("http://down1.bookbao.com:81/dl.aspx?id=X{0}", newBook.DownloadAddr)
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Dict.MsgType.ErrorMsg, False)
            End Try
            Return newBook
        End Function

        ''' <summary>
        ''' 获取书籍详情
        ''' </summary>
        ''' <param name="book">书记对象</param>
        ''' <returns>书籍详情信息</returns>
        ''' <remarks>获取书籍详情</remarks>
        Public Function GetBookAbstract(ByVal book As Story) As String
            Dim BookAbstract As String = String.Empty
            Try
                Dim rootNode As HtmlNode = HttpHelper.OpenUrl(book.DownloadAddr)
                '书名
                BookAbstract = HttpHelper.GetNodeStr(rootNode, "//div[@class='content']").Trim
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Dict.MsgType.ErrorMsg, False)
            End Try
            Return BookAbstract
        End Function
    End Class
End Namespace
