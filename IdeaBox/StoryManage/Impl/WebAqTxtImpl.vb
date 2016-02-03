Imports HtmlAgilityPack
Imports IdeaBox.Utils.FileSystem.Net
Imports IdeaBox.StoryManage.Model
Imports IdeaBox.StoryManage.View.Fr_Aqtxt

Namespace StoryManage.Impl
    Public Class WebAqTxtImpl
        Const Url As String = "http://www.aqtxt.com"
        Dim Category As Dictionary(Of String, String)
        Dim TName As String

        Sub New()

        End Sub

        Sub New(ByVal TableName As String)
            SetCategory()
            TName = TableName
        End Sub

        Sub SetCategory()
            Category = New Dictionary(Of String, String)
            Category.Add("全部小说", "/finished/")
            Category.Add("最新全本", "/newbook/")
            Category.Add("玄幻奇幻", "/xuanhuan/")
            Category.Add("都市小说", "/dushi/")
            Category.Add("武侠修真", "/wuxia/")
            Category.Add("历史军事", "/lishi/")
            Category.Add("网游小说", "/wangyou/")
            Category.Add("科幻小说", "/kehuan/")
            Category.Add("恐怖小说", "/kongbu/")
            Category.Add("女生言情", "/yanqing/")
            Category.Add("文学名著", "/mingzhu/")
            Category.Add("人物传记", "/zhuanji/")
            Category.Add("经管励志", "/jingji/")
            Category.Add("法律教育", "/jiaoyu/")
            Category.Add("外国名著", "/waiguo/")
        End Sub

        Public Function GetPageCount() As Integer
            Dim rootNode As HtmlNode = HttpHelper.OpenUrl(String.Format("{0}/finished/1.htm", Url))
            Dim PageCount As String = HttpHelper.GetNodeStr(rootNode, "//*[@id='newbook']/div[16]/a[11]", 1)
            Return CInt(PageCount.Replace(".htm", ""))
        End Function

        Public Sub GetBooks(ByVal TableName As String)
            Dim tm As New Stopwatch
            tm.Start()
            Dim pageCount As Integer = GetPageCount()
            For page As Integer = 1 To pageCount
                Dim rootNode As HtmlNode = HttpHelper.OpenUrl(String.Format("{0}/finished/{1}.htm", Url, page))
                Dim NodeCollection As HtmlNodeCollection = HttpHelper.GetNodeCollection(rootNode, "//*[@id='newbook']/div/ul/li/a")
                For Each node As HtmlNode In NodeCollection
                    Dim s As New Story
                    s.BookName = node.InnerText
                    s.DownloadAddr = String.Format("{0}{1}", Url, HttpHelper.GetNodeStr(node, 1))
                    GetCollect(s)
                    StoryOpt.Add(s, TableName)
                    Dim setStat As SetStatLbl = New SetStatLbl(AddressOf frStory.StatLbl)
                    setStat.Invoke(String.Format("正在采集：第 {0} 页 / 共 {1} 页 , 累计耗时：{2}", page, pageCount, tm.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")))
                Next
            Next
            tm.Stop()
            Log.Showlog(String.Format("采集完成，共计耗时：{0}", tm.Elapsed.ToString), Utils.FileSystem.Dict.MsgType.InfoMsg)
        End Sub

        Public Sub GetBooks()
            Dim tm As New Stopwatch
            tm.Start()
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
                    book.Rating = HttpHelper.GetNodeStr(rootNode, String.Format("//*[@id='newbook']/div[{0}]/ul/li[@class='title']/span", i)).Trim
                    '下载量
                    book.DownloadQuantity = HttpHelper.GetNodeStr(rootNode, String.Format("//*[@id='newbook']/div[{0}]/ul/li[@class='tj']/label[2]/font", i)).Replace("次", "").Trim
                    '小说简介
                    book.Abstract = HttpHelper.GetNodeStr(rootNode, String.Format("//*[@id='newbook']/div[{0}]/ul/li[@class='intro']", i)).Replace("简介：", "").Replace("&lt;", "").Replace("br/", "").Replace("&gt;", "").Replace("&amp;", "").Replace("nbsp;", "").Replace("'", "").Replace("&quot;", "").Trim
                    '下载地址
                    book.DownloadAddr = String.Format("{0}{1}", Url, HttpHelper.GetNodeStr(NodeCollection(i - 1), 1)).Trim
                    '生成是否已读
                    book.IsRead = 0
                    bookLs.Add(book)
                    Dim setStat As SetStatLbl = New SetStatLbl(AddressOf frStory.StatLbl)
                    setStat.Invoke(String.Format("正在采集：第 {0} 页 / 共 {1} 页 , 累计耗时：{2}", page, pageCount, tm.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")))
                Next
                If bookLs.Count >= 300 Or page = pageCount Then
                    Log.Showlog(page, Utils.FileSystem.Dict.MsgType.InfoMsg, False)
                    StoryOpt.Add(bookLs, TName)
                    bookLs = New List(Of Story)
                End If
            Next
            tm.Stop()
            Log.Showlog(String.Format("采集完成，共计耗时：{0}", tm.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")), Utils.FileSystem.Dict.MsgType.InfoMsg)
        End Sub

        Public Function GetCollect(ByVal book As Story) As Story
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


        Public Function GetDownloadAddr(ByVal book As Story) As String
            Dim DownLoad As String = String.Empty
            Try
                Dim rootNode As HtmlNode = HttpHelper.OpenUrl(book.DownloadAddr)
                DownLoad = HttpHelper.GetNodeStr(rootNode, "//*[@id='txtdown']/ul/li[2]/a", 1).Trim
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Dict.MsgType.ErrorMsg, False)
            End Try
            Return DownLoad
        End Function
    End Class
End Namespace
