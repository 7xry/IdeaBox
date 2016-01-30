Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Controls
Imports IdeaBox.StoryManage.Model
Imports IdeaBox.Utils.FileSystem.Path
Imports System.IO
Imports IdeaBox.StoryManage.Impl
Imports IdeaBox.Utils.FileSystem.Dict
Imports IdeaBox.Utils.FileSystem.String
Imports System.Threading

Namespace StoryManage.View
    Public Class Fr_Aqtxt
        ''' <summary>
        ''' 表名属性
        ''' </summary>
        ''' <value>表名</value>
        ''' <returns>表名</returns>
        ''' <remarks>表名属性</remarks>
        Property TableName As String
        ''' <summary>
        ''' 线程任务
        ''' </summary>
        ''' <remarks>线程任务</remarks>
        Dim ThreadTask As Threading.Thread
        ''' <summary>
        ''' 异步结果
        ''' </summary>
        ''' <remarks>异步结果</remarks>
        Private asyncResult As IAsyncResult
        ''' <summary>
        ''' 线程不在工作
        ''' </summary>
        ''' <remarks>线程不在工作</remarks>
        Private ThreadIsNotWork As Boolean = True

        ''' <summary>
        ''' 构造方法
        ''' </summary>
        ''' <param name="TName">表名</param>
        ''' <remarks>构造方法</remarks>
        Sub New(ByVal TName As String)
            ' 此调用是设计器所必需的。
            InitializeComponent()
            TableName = TName
        End Sub

        ''' <summary>
        ''' 执行线程
        ''' </summary>
        ''' <param name="addrOf">线程事件</param>
        ''' <remarks>执行线程</remarks>
        Sub DoThread(ByVal addrOf As Threading.ParameterizedThreadStart)
            If ThreadIsNotWork <> True Then
                Return
            End If
            '创建线程加载showloadlist子程序加载内容
            ThreadTask = New Threading.Thread(addrOf)
            ThreadTask.Start()
        End Sub

        ''' <summary>
        ''' 委托显示列表
        ''' </summary>
        ''' <param name="xScan">查询条件</param>
        ''' <returns>成功与否</returns>
        ''' <remarks>委托显示列表</remarks>
        Private Delegate Function SetLoadList(ByVal xScan As Story) As Boolean

        ''' <summary>
        ''' 委托下载文件
        ''' </summary>
        ''' <returns>成功与否</returns>
        ''' <remarks>委托下载文件</remarks>
        Private Delegate Function SetDownLoad() As Boolean

        ''' <summary>
        ''' 委托采集
        ''' </summary>
        ''' <returns>成功与否</returns>
        ''' <remarks>委托采集</remarks>
        Private Delegate Function SetCollect() As Boolean

        ''' <summary>
        ''' 委托屏蔽
        ''' </summary>
        ''' <returns>成功与否</returns>
        ''' <remarks>委托屏蔽</remarks>
        Private Delegate Function SetShield() As Boolean

        ''' <summary>
        ''' 获取委托结果
        ''' </summary>
        ''' <param name="myIar">委托返回值</param>
        ''' <returns>成功与否</returns>
        ''' <remarks>获取委托结果</remarks>
        Private Function GetCallBack(ByVal myIar As IAsyncResult) As Boolean
            Return MainTree.EndInvoke(myIar)
        End Function

        ''' <summary>
        ''' 委托显示列表事件
        ''' </summary>
        ''' <remarks>委托显示列表事件</remarks>
        Private Sub DoScan()
            ThreadIsNotWork = False
            Dim xScan As New Story(BookNameBox.Text, AuthorBox.Text, CategoryBox.Text, AbstractBox.Text, RatingBox.Text)
            Select Case ShieldBox.SelectedIndex
                Case 0
                    xScan.IsRead = String.Empty
                Case 1
                    xScan.IsRead = 1
                Case 2
                    xScan.IsRead = 0
            End Select
            asyncResult = frMain.BeginInvoke(New SetLoadList(AddressOf LoadList), xScan)
            ThreadIsNotWork = GetCallBack(asyncResult)
        End Sub

        ''' <summary>
        ''' 委托下载事件
        ''' </summary>
        ''' <remarks>委托下载事件</remarks>
        Private Sub DoDownLoad()
            ThreadIsNotWork = False
            asyncResult = frMain.BeginInvoke(New SetDownLoad(AddressOf DownLoadFile))
            ThreadIsNotWork = GetCallBack(asyncResult)
        End Sub

        ''' <summary>
        ''' 委托采集事件
        ''' </summary>
        ''' <remarks>委托采集事件</remarks>
        Private Sub DoCollect()
            ThreadIsNotWork = False
            asyncResult = frMain.BeginInvoke(New SetCollect(AddressOf Collect))
            ThreadIsNotWork = GetCallBack(asyncResult)
        End Sub

        ''' <summary>
        ''' 委托屏蔽事件
        ''' </summary>
        ''' <remarks>委托屏蔽事件</remarks>
        Private Sub DoShield()
            ThreadIsNotWork = False
            asyncResult = frMain.BeginInvoke(New SetShield(AddressOf Shield))
            ThreadIsNotWork = GetCallBack(asyncResult)
        End Sub

        ''' <summary>
        ''' 加载列表事件
        ''' </summary>
        ''' <param name="xScan">查询条件</param>
        ''' <returns>成功与否</returns>
        ''' <remarks>加载列表事件</remarks>
        Private Function LoadList(ByVal xScan As Story) As Boolean
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

        ''' <summary>
        ''' 下载文件事件
        ''' </summary>
        ''' <returns>成功与否</returns>
        ''' <remarks>下载文件事件</remarks>
        Private Function DownLoadFile() As Boolean
            Dim fileLs As List(Of FileDown) = GetSelectFiles()
            If fileLs.Count <= 0 Then
                Log.Showlog("请选择要下载的记录！", MsgType.WarnMsg)
                Return True
            End If
            Dim timer As New Stopwatch
            Dim CurIndex As Integer = 1
            Dim sumTime As Long = 0
            DownNowStat.Visibility = BarItemVisibility.Always
            For Each f As FileDown In fileLs
                timer = New Stopwatch
                timer.Start()
                f.SourceFile = f.fileInfo.DownloadAddr
                f.TargetFile = String.Format("{0}\{1}", AppPath.GetRunPath, f.fileInfo.Category)
                If Directory.Exists(f.TargetFile) = False Then
                    Directory.CreateDirectory(f.TargetFile)
                End If
                f.FileExtension = Mid(f.SourceFile, f.SourceFile.LastIndexOf(".") + 2)
                f.TargetFile = String.Format("{0}\{1}.{2}", f.TargetFile, f.fileInfo.BookName, f.FileExtension)
                DownNowStat.Caption = String.Format("正在下载：{0}/{1} - {2}.{3}，累计耗时：{4}", CurIndex, fileLs.Count, f.fileInfo.BookName, f.FileExtension, TimeSpan.FromTicks(sumTime).ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ "))
                FileDownOpt.DownLoadFiles(f)
                timer.Stop()
                sumTime += timer.ElapsedTicks
                DownNowStat.Caption = String.Format("正在下载：{0}/{1} - {2}.{3}，累计耗时：{4}", CurIndex, fileLs.Count, f.fileInfo.BookName, f.FileExtension, TimeSpan.FromTicks(sumTime).ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ "))
                DownNowStat.Refresh()
                CurIndex += 1
            Next
            Thread.Sleep(1000)
            DownNowStat.Visibility = BarItemVisibility.Never
            Return True
        End Function

        ''' <summary>
        ''' 采集事件
        ''' </summary>
        ''' <returns>成功与否</returns>
        ''' <remarks>采集事件</remarks>
        Function Collect() As Boolean
            AqtxtImplOpt = New AqtxtImpl
            StoryOpt.ResetTable(TableName)
            Dim pageCount As Integer = AqtxtImplOpt.GetPageCount
            Dim RowsCount As Integer = AqtxtImplOpt.GetRowsCount
            Dim SumList As Integer = 0
            Dim sumTime As Long = 0
            Dim timer As New Stopwatch
            DownNowStat.Visibility = BarItemVisibility.Always
            DownNowStat.Caption = String.Format("正在采集：{0} / {1}，累计耗时：00 小时 00 分 00 秒 ", SumList, RowsCount)
            DownNowStat.Refresh()
            For pageIdx As Integer = 1 To pageCount
                DownNowStat.Caption = String.Format("正在采集：{0} / {1}，累计耗时：{2}", SumList, RowsCount, TimeSpan.FromTicks(sumTime).ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ "))
                DownNowStat.Refresh()
                timer = New Stopwatch
                timer.Start()
                Dim tmpLs As List(Of Story) = AqtxtImplOpt.GetCollect(pageIdx)
                StoryOpt.Add(tmpLs, TableName)
                timer.Stop()
                SumList += tmpLs.Count
                sumTime += timer.ElapsedTicks
            Next
            DownNowStat.Visibility = BarItemVisibility.Never
            Return True
        End Function

        ''' <summary>
        ''' 屏蔽事件
        ''' </summary>
        ''' <returns>成功与否</returns>
        ''' <remarks>屏蔽事件</remarks>
        Function Shield() As Boolean
            Dim fileLs As List(Of FileDown) = GetSelectFiles()
            Dim sLs As New List(Of Story)
            Select Case DoShieldBtn.Caption
                Case "屏蔽"
                    If fileLs.Count <= 0 Then
                        Log.Showlog("请选择要屏蔽的记录！", MsgType.WarnMsg)
                        Return True
                    End If
                    For Each f As FileDown In fileLs
                        f.fileInfo.IsRead = 1
                        sLs.Add(f.fileInfo)
                    Next
                Case "解除屏蔽"
                    If fileLs.Count <= 0 Then
                        Log.Showlog("请选择要解除屏蔽的记录！", MsgType.WarnMsg)
                        Return True
                    End If
                    For Each f As FileDown In fileLs
                        f.fileInfo.IsRead = 0
                        sLs.Add(f.fileInfo)
                    Next
            End Select
            StoryOpt.Update(sLs, TableName)
            Dim xScan As New Story(BookNameBox.Text, AuthorBox.Text, CategoryBox.Text, AbstractBox.Text, RatingBox.Text)
            Select Case ShieldBox.SelectedIndex
                Case 0
                    xScan.IsRead = String.Empty
                Case 1
                    xScan.IsRead = 1
                Case 2
                    xScan.IsRead = 0
            End Select
            LoadList(xScan)
            Return True
        End Function

        ''' <summary>
        ''' 获取选择的记录
        ''' </summary>
        ''' <returns>选择文件信息</returns>
        ''' <remarks>获取选择的记录</remarks>
        Function GetSelectFiles() As List(Of FileDown)
            Dim fileLs As New List(Of FileDown)
            Dim dr As TreeListMultiSelection = MainTree.Selection
            If dr.Count <= 0 Then
                Return fileLs
            End If
            For Each r As TreeListNode In dr
                Dim f As New FileDown
                f.fileInfo = r.GetValue(0)
                If f.fileInfo Is Nothing Then
                    Continue For
                End If
                fileLs.Add(f)
            Next
            Return fileLs
        End Function

        ''' <summary>
        ''' 加载小说分类
        ''' </summary>
        ''' <remarks>加载小说分类</remarks>
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

        ''' <summary>
        ''' 窗体初始化
        ''' </summary>
        ''' <param name="sender">发送方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>窗体初始化</remarks>
        Private Sub Fr_User_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            LoadCategoryList()
            LoadList(Nothing)
        End Sub

        ''' <summary>
        ''' 按钮事件
        ''' </summary>
        ''' <param name="sender">发起方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>按钮事件</remarks>
        Private Sub Btn_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles DoScanBtn.ItemClick, DoDownBtn.ItemClick, DoCollectBtn.ItemClick, DoShieldBtn.ItemClick

            Select Case e.Item.Name
                Case "DoScanBtn"
                    DoThread(AddressOf DoScan)
                Case "DoDownBtn"
                    DoThread(AddressOf DoDownLoad)
                Case "DoCollectBtn"
                    DoThread(AddressOf DoCollect)
                Case "DoShieldBtn"
                    DoThread(AddressOf DoShield)
            End Select
        End Sub

        ''' <summary>
        ''' 清除按钮事件
        ''' </summary>
        ''' <param name="sender">发起方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>清除按钮事件</remarks>
        Private Sub ClearBtn_ButtonClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs) Handles RatingBox.ButtonClick, AuthorBox.ButtonClick, BookNameBox.ButtonClick, AbstractBox.ButtonClick
            If e.Button.Kind = ButtonPredefines.Delete Then
                CType(sender, ButtonEdit).Text = String.Empty
                CType(sender, ButtonEdit).EditValue = Nothing
            End If
        End Sub

        Private Sub MainTree_FocusedNodeChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles MainTree.FocusedNodeChanged
            DoShieldBtn.Caption = "屏蔽"
            If e.Node Is Nothing Then
                Return
            End If
            If e.Node.GetValue(0) Is Nothing Then
                Return
            End If
            If CType(e.Node.GetValue(0), Story).IsRead = 1 Then
                DoShieldBtn.Caption = "解除屏蔽"
            End If
        End Sub
    End Class
End Namespace