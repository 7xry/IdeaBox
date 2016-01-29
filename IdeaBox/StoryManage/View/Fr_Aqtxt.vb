Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports IdeaBox.Utils.FileSystem.Enum
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Controls
Imports IdeaBox.StoryManage.Model
Imports IdeaBox.Utils.FileSystem.Path
Imports System.IO
Imports IdeaBox.StoryManage.Impl

Namespace StoryManage.View
    Public Class Fr_Aqtxt
        Property TableName As String
        Dim ThreadTask As Threading.Thread
        Private asyncResult As IAsyncResult
        Private ThreadIsNotWork As Boolean = True
        Sub New(ByVal TName As String)
            ' 此调用是设计器所必需的。
            InitializeComponent()
            TableName = TName
        End Sub

        '多线程
        Sub DoThread(ByVal para As Threading.ParameterizedThreadStart)
            If ThreadIsNotWork <> True Then
                Return
            End If
            '创建线程加载showloadlist子程序加载内容
            ThreadTask = New Threading.Thread(para)
            ThreadTask.Start()
        End Sub

        '委托异步处理
        Private Delegate Function Showlist(ByVal xScan As Story) As Boolean
        Private Sub DoScan()
            ThreadIsNotWork = False
            Dim xScan As New Story(BookNameBox.Text, AuthorBox.Text, CategoryBox.Text, AbstractBox.Text, RatingBox.Text)
            asyncResult = MainTree.BeginInvoke(New Showlist(AddressOf LoadList), xScan)
            ThreadIsNotWork = LoadListCallBack(asyncResult)
        End Sub

        '加载列表
        Function LoadList(ByVal xScan As Story) As Boolean
            MainTree.BeginUnboundLoad()
            '清除列表显示
            MainTree.Nodes.Clear()
            Dim parentForRootNodes As TreeListNode = Nothing
            If xScan Is Nothing Then
                MainTree.AppendNode(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, 0)}, parentForRootNodes)
                MainTree.ExpandAll()
                MainTree.EndUnboundLoad()
                Return True
            End If
            Dim ls As List(Of Story) = StoryOpt.GetList(xScan, TableName)
            If ls IsNot Nothing Then
                Dim Article As TreeListNode = MainTree.AppendNode(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, ls.Count)}, parentForRootNodes)
                '创建根节点
                For Each xStory As Story In ls
                    MainTree.AppendNode(New Object() {xStory, xStory.BookName, xStory.Author,
                                                  xStory.Category, xStory.FileSize, xStory.Rating,
                                                  xStory.DownloadQuantity, xStory.UploadDate, xStory.Abstract, xStory.DownloadAddr,
                                                  xStory.IsRead}, Article)
                Next
            Else
                MainTree.AppendNode(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, ls.Count)}, parentForRootNodes)
            End If
            MainTree.ExpandAll()
            MainTree.EndUnboundLoad()
            Return True
        End Function


        '获取处理结果
        Private Function LoadListCallBack(ByVal myIar As IAsyncResult) As Boolean
            Return MainTree.EndInvoke(myIar)
        End Function

        Private Sub ClearEdit()
            BookNameBox.EditValue = String.Empty
            AuthorBox.EditValue = String.Empty
            CategoryBox.EditValue = String.Empty
            AbstractBox.EditValue = String.Empty
            RatingBox.EditValue = String.Empty
            LoadCategoryList()
        End Sub

        Private Sub Fr_User_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            LoadCategoryList()
            LoadList(Nothing)
        End Sub

        Private Sub DoScanBtn_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles DoScanBtn.ItemClick
            DoThread(AddressOf DoScan)
        End Sub

        Private Sub DoDownBtn_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles DoDownBtn.ItemClick
            Dim dr As TreeListMultiSelection = MainTree.Selection
            If dr.Count <= 0 Then
                Log.Showlog("请选择要下载的记录！", MsgType.WarnMsg)
                Return
            End If
            DownNowStat.Visibility = BarItemVisibility.Always
            Dim CurIndex As Integer = 1
            DownProBar.Minimum = CurIndex
            DownProBar.Maximum = dr.Count
            For Each r As TreeListNode In dr
                Dim f As New FileDown
                f.fileInfo = r.GetValue(0)
                If f.fileInfo Is Nothing Then
                    Continue For
                End If
                f.SourceFile = f.fileInfo.DownloadAddr
                f.TargetFile = String.Format("{0}\{1}", AppPath.GetRunPath, f.fileInfo.Category)
                If Directory.Exists(f.TargetFile) = False Then
                    Directory.CreateDirectory(f.TargetFile)
                End If
                f.FileExtension = Mid(f.SourceFile, f.SourceFile.LastIndexOf(".") + 2)
                f.TargetFile = String.Format("{0}\{1}.{2}", f.TargetFile, f.fileInfo.BookName, f.FileExtension)
                DownNowStat.Caption = String.Format("正在下载：{0}/{1} - {2}.{3}", CurIndex, dr.Count, f.fileInfo.BookName, f.FileExtension)
                FileDownOpt.DownLoadFiles(f)
                CurIndex += 1
            Next
            DownNowStat.Visibility = BarItemVisibility.Never
        End Sub

        Private Sub ClearBtn_ButtonClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs) Handles RatingBox.ButtonClick, AuthorBox.ButtonClick, BookNameBox.ButtonClick, AbstractBox.ButtonClick
            If e.Button.Kind = ButtonPredefines.Delete Then
                CType(sender, ButtonEdit).Text = String.Empty
                CType(sender, ButtonEdit).EditValue = Nothing
            End If
        End Sub

        Sub LoadCategoryList()
            CategoryBox.Properties.BeginUpdate()
            CategoryBox.Properties.Items.Clear()
            CategoryBox.Properties.Items.Add("全部小说")
            For Each Category In StoryOpt.GetCategory(TableName)
                CategoryBox.Properties.Items.Add(Category)
            Next
            If CategoryBox.Properties.Items.Count > 1 Then
                CategoryBox.SelectedItem = CategoryBox.Properties.Items(1)
            End If
            '除了数据库中类型，新增全部小说筛选
            AbstractBox.Properties.EndUpdate()
        End Sub

        Private Sub DoReLoadBtn_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles DoReLoadBtn.ItemClick
            DoThread(AddressOf DoReLoad)
        End Sub

        '委托异步处理
        Private Delegate Function SetReLoad() As Boolean
        '委托采集
        Private Sub DoReLoad()
            ThreadIsNotWork = False
            asyncResult = MainTree.BeginInvoke(New SetReLoad(AddressOf ReLoad))
            ThreadIsNotWork = LoadListCallBack(asyncResult)
        End Sub
        '采集
        Function ReLoad() As Boolean
            StoryDownOpt = New AqtxtImpl
            StoryOpt.ResetTable(TableName)
            Dim pageCount As Integer = StoryDownOpt.GetPageCount
            Dim RowsCount As Integer = StoryDownOpt.GetRowsCount
            Dim SumList As Integer = 0
            Dim sumTime As Long = 0
            Dim ls As New List(Of Story)
            Dim timer As New Stopwatch
            DownNowStat.Visibility = BarItemVisibility.Always
            DownNowStat.Caption = String.Format("正在采集：{0} / {1}，累计耗时：{2}", SumList, RowsCount, sumTime / 1000)
            DownNowStat.Refresh()
            For pageIdx As Integer = 1 To pageCount
                DownNowStat.Caption = String.Format("正在采集：{0} / {1}，累计耗时：{2} 秒", SumList, RowsCount, sumTime / 1000)
                DownNowStat.Refresh()
                timer = New Stopwatch
                timer.Start()
                Dim tmpLs As List(Of Story) = StoryDownOpt.GetCollect(pageIdx)
                StoryOpt.Add(tmpLs, TableName)
                timer.Stop()
                SumList += tmpLs.Count
                sumTime += timer.ElapsedMilliseconds
            Next
            DownNowStat.Visibility = BarItemVisibility.Never
            Return True
        End Function
    End Class
End Namespace