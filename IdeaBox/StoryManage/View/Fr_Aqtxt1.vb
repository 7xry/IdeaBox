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
    Public Class Fr_Aqtxt1
        ' ''' <summary>
        ' ''' 表名属性
        ' ''' </summary>
        ' ''' <value>表名</value>
        ' ''' <returns>表名</returns>
        ' ''' <remarks>表名属性</remarks>
        'Property TableName As String
        ' ''' <summary>
        ' ''' 线程任务
        ' ''' </summary>
        ' ''' <remarks>线程任务</remarks>
        'Dim ThreadTask As Threading.Thread
        ' ''' <summary>
        ' ''' 异步结果
        ' ''' </summary>
        ' ''' <remarks>异步结果</remarks>
        'Private asyncResult As IAsyncResult
        ' ''' <summary>
        ' ''' 线程不在工作
        ' ''' </summary>
        ' ''' <remarks>线程不在工作</remarks>
        'Private ThreadIsNotWork As Boolean = True
        ' ''' <summary>
        ' ''' 分页信息
        ' ''' </summary>
        ' ''' <remarks></remarks>
        'Private pg As Pagging

        ' ''' <summary>
        ' ''' 构造方法
        ' ''' </summary>
        ' ''' <param name="TName">表名</param>
        ' ''' <remarks>构造方法</remarks>
        'Sub New(ByVal TName As String)
        '    ' 此调用是设计器所必需的。
        '    InitializeComponent()
        '    TableName = TName
        'End Sub

        ' ''' <summary>
        ' ''' 执行线程
        ' ''' </summary>
        ' ''' <param name="addrOf">线程事件</param>
        ' ''' <remarks>执行线程</remarks>
        'Sub DoThread(ByVal addrOf As Threading.ParameterizedThreadStart)
        '    If ThreadIsNotWork <> True Then
        '        Return
        '    End If
        '    '创建线程加载showloadlist子程序加载内容
        '    ThreadTask = New Threading.Thread(addrOf)
        '    ThreadTask.Start()
        'End Sub

        ' ''' <summary>
        ' ''' 委托下载文件
        ' ''' </summary>
        ' ''' <returns>成功与否</returns>
        ' ''' <remarks>委托下载文件</remarks>
        'Private Delegate Function SetDownLoad() As Boolean

        ' ''' <summary>
        ' ''' 委托采集
        ' ''' </summary>
        ' ''' <returns>成功与否</returns>
        ' ''' <remarks>委托采集</remarks>
        'Private Delegate Function SetCollect() As Boolean

        ' ''' <summary>
        ' ''' 委托屏蔽
        ' ''' </summary>
        ' ''' <returns>成功与否</returns>
        ' ''' <remarks>委托屏蔽</remarks>
        'Private Delegate Function SetShield() As Boolean

        ' ''' <summary>
        ' ''' 委托状态
        ' ''' </summary>
        ' ''' <remarks>委托状态</remarks>
        'Public Delegate Sub SetStatLbl(ByVal CaptionStr As String)

        ' ''' <summary>
        ' ''' 获取委托结果
        ' ''' </summary>
        ' ''' <param name="myIar">委托返回值</param>
        ' ''' <returns>成功与否</returns>
        ' ''' <remarks>获取委托结果</remarks>
        'Private Function GetCallBack(ByVal myIar As IAsyncResult) As Boolean
        '    Return MainTree.EndInvoke(myIar)
        'End Function

        ' ''' <summary>
        ' ''' 委托下载事件
        ' ''' </summary>
        ' ''' <remarks>委托下载事件</remarks>
        'Private Sub DoDownLoad()
        '    ThreadIsNotWork = False
        '    asyncResult = frMain.BeginInvoke(New SetDownLoad(AddressOf DownLoadFile))
        '    ThreadIsNotWork = GetCallBack(asyncResult)
        'End Sub

        ' ''' <summary>
        ' ''' 委托采集事件
        ' ''' </summary>
        ' ''' <remarks>委托采集事件</remarks>
        'Private Sub DoCollect()
        '    ThreadIsNotWork = False
        '    asyncResult = frMain.BeginInvoke(New SetCollect(AddressOf Collect))
        '    ThreadIsNotWork = GetCallBack(asyncResult)
        'End Sub

        ' ''' <summary>
        ' ''' 委托屏蔽事件
        ' ''' </summary>
        ' ''' <remarks>委托屏蔽事件</remarks>
        'Private Sub DoShield()
        '    ThreadIsNotWork = False
        '    asyncResult = frMain.BeginInvoke(New SetShield(AddressOf Shield))
        '    ThreadIsNotWork = GetCallBack(asyncResult)
        'End Sub

        ' ''' <summary>
        ' ''' 委托屏蔽事件
        ' ''' </summary>
        ' ''' <remarks>委托屏蔽事件</remarks>
        'Public Sub StatLbl(ByVal CaptionStr As String)
        '    DownNowStat.Caption = CaptionStr
        '    DownNowStat.Refresh()
        'End Sub

        ' ''' <summary>
        ' ''' 加载列表事件
        ' ''' </summary>
        ' ''' <param name="xScan">查询条件</param>
        ' ''' <returns>成功与否</returns>
        ' ''' <remarks>加载列表事件</remarks>
        'Private Function LoadList(ByVal xScan As Story) As Boolean
        '    MainTree.BeginUnboundLoad()
        '    '清除列表显示
        '    MainTree.Nodes.Clear()
        '    Dim parentForRootNodes As TreeListNode = Nothing
        '    If xScan Is Nothing Then
        '        MainTree.AppendNode(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, 0)}, parentForRootNodes)
        '        MainTree.ExpandAll()
        '        MainTree.EndUnboundLoad()
        '        Return True
        '    End If
        '    Dim ls As List(Of Story) = StoryOpt.GetList(xScan, TableName, (pg.CurrentIndex - 1) * perPage)
        '    If ls IsNot Nothing Then
        '        Dim Article As TreeListNode = MainTree.AppendNode(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, pg.RowCount)}, parentForRootNodes)
        '        '创建根节点
        '        For Each xStory As Story In ls
        '            MainTree.AppendNode(New Object() {xStory, xStory.BookName, xStory.Author,
        '                                          xStory.Category, xStory.FileSize, xStory.Rating,
        '                                          xStory.DownloadQuantity, xStory.UploadDate, xStory.Abstract, xStory.DownloadAddr,
        '                                          xStory.IsRead}, Article)
        '        Next
        '    Else
        '        MainTree.AppendNode(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, pg.RowCount)}, parentForRootNodes)
        '    End If
        '    MainTree.ExpandAll()
        '    MainTree.EndUnboundLoad()
        '    Return True
        'End Function

        ' ''' <summary>
        ' ''' 下载文件事件
        ' ''' </summary>
        ' ''' <returns>成功与否</returns>
        ' ''' <remarks>下载文件事件</remarks>
        'Private Function DownLoadFile() As Boolean
        '    DownNowStat.Visibility = BarItemVisibility.Always
        '    PaggingInfo.Visibility = BarItemVisibility.Never
        '    SetPaggingBtnVisiable(BarItemVisibility.Never)
        '    Dim timer As New Stopwatch
        '    Dim setStat As SetStatLbl = New SetStatLbl(AddressOf frStory.StatLbl)
        '    timer.Start()
        '    setStat.Invoke("正在获取下载列表，请稍后……")
        '    Dim fileLs As List(Of Story) = GetSelectFiles()
        '    If fileLs.Count <= 0 Then
        '        Log.Showlog("请选择要下载的记录！", MsgType.WarnMsg)
        '        Return True
        '    End If
        '    Dim CurIndex As Integer = 1
        '    For Each f As Story In fileLs
        '        Dim fDown As New FileDown
        '        fDown.fileInfo = AqtxtImplOpt.GetCollect(f)
        '        fDown.SourceFile = fDown.fileInfo.DownloadAddr
        '        fDown.TargetFile = String.Format("{0}\{1}", AppPath.GetRunPath, fDown.fileInfo.Category)
        '        If Directory.Exists(fDown.TargetFile) = False Then
        '            Directory.CreateDirectory(fDown.TargetFile)
        '        End If
        '        fDown.FileExtension = Mid(fDown.SourceFile, fDown.SourceFile.LastIndexOf(".") + 2)
        '        fDown.TargetFile = String.Format("{0}\{1}.{2}", fDown.TargetFile, fDown.fileInfo.BookName, fDown.FileExtension)
        '        fDown.CurrentIndex = CurIndex
        '        fDown.AllCount = fileLs.Count
        '        fDown.timer = timer
        '        FileDownOpt.DownLoadFiles(fDown)
        '        'setStat.Invoke(String.Format("正在下载：{0}/{1} - {2}.{3}，累计耗时：{4}", CurIndex, fileLs.Count, fDown.fileInfo.BookName, fDown.FileExtension, timer.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")))
        '        CurIndex += 1
        '    Next
        '    timer.Stop()
        '    DownNowStat.Visibility = BarItemVisibility.Never
        '    PaggingInfo.Visibility = BarItemVisibility.Always
        '    SetPaggingBtnVisiable(BarItemVisibility.Always)
        '    Log.Showlog(String.Format("下载完成，共计下载：{0} 本，累计耗时：{1}", fileLs.Count, timer.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")), Utils.FileSystem.Dict.MsgType.InfoMsg)
        '    Return True
        'End Function

        ' ''' <summary>
        ' ''' 采集事件
        ' ''' </summary>
        ' ''' <returns>成功与否</returns>
        ' ''' <remarks>采集事件</remarks>
        'Function Collect() As Boolean
        '    DownNowStat.Visibility = BarItemVisibility.Always
        '    PaggingInfo.Visibility = BarItemVisibility.Never
        '    SetPaggingBtnVisiable(BarItemVisibility.Never)
        '    AqtxtImplOpt = New WebAqTxtImpl(TableName)
        '    StoryOpt.ResetTable(TableName)
        '    DownNowStat.Caption = String.Format("正在准备开始采集，请稍后……")
        '    DownNowStat.Refresh()
        '    AqtxtImplOpt.GetBooks()
        '    SetPaggingBtnVisiable(BarItemVisibility.Always)
        '    DownNowStat.Visibility = BarItemVisibility.Never
        '    PaggingInfo.Visibility = BarItemVisibility.Always
        '    Return True
        'End Function

        ' ''' <summary>
        ' ''' 屏蔽事件
        ' ''' </summary>
        ' ''' <returns>成功与否</returns>
        ' ''' <remarks>屏蔽事件</remarks>
        'Function Shield() As Boolean
        '    Dim fileLs As List(Of Story) = GetSelectFiles()
        '    Dim sLs As New List(Of Story)
        '    Select Case DoShieldBtn.Caption
        '        Case "屏蔽"
        '            If fileLs.Count <= 0 Then
        '                Log.Showlog("请选择要屏蔽的记录！", MsgType.WarnMsg)
        '                Return True
        '            End If
        '            For Each f As Story In fileLs
        '                f.IsRead = 1
        '                sLs.Add(f)
        '            Next
        '        Case "解除屏蔽"
        '            If fileLs.Count <= 0 Then
        '                Log.Showlog("请选择要解除屏蔽的记录！", MsgType.WarnMsg)
        '                Return True
        '            End If
        '            For Each f As Story In fileLs
        '                f.IsRead = 0
        '                sLs.Add(f)
        '            Next
        '    End Select
        '    StoryOpt.Update(sLs, TableName)
        '    ResetPagging()
        '    LoadList(GetScanCondition)
        '    Return True
        'End Function

        ' ''' <summary>
        ' ''' 获取选择的记录
        ' ''' </summary>
        ' ''' <returns>选择文件信息</returns>
        ' ''' <remarks>获取选择的记录</remarks>
        'Function GetSelectFiles() As List(Of Story)
        '    Dim fileLs As New List(Of Story)
        '    Dim dr As TreeListMultiSelection = MainTree.Selection
        '    If dr.Count <= 0 Then
        '        Return fileLs
        '    End If
        '    For Each r As TreeListNode In dr
        '        Dim book As Story = r.GetValue(0)
        '        If book Is Nothing Then
        '            Continue For
        '        End If
        '        fileLs.Add(book)
        '    Next
        '    Return fileLs
        'End Function

        ' ''' <summary>
        ' ''' 加载小说分类
        ' ''' </summary>
        ' ''' <remarks>加载小说分类</remarks>
        'Sub LoadCategoryList()
        '    CategoryBox.Properties.BeginUpdate()
        '    CategoryBox.Properties.Items.Clear()
        '    CategoryBox.Properties.Items.Add("全部小说")
        '    For Each Category In StoryOpt.GetCategory(TableName)
        '        CategoryBox.Properties.Items.Add(Category)
        '    Next
        '    If CategoryBox.Properties.Items.Count > 1 Then
        '        CategoryBox.SelectedItem = CategoryBox.Properties.Items(1)
        '    End If
        '    '除了数据库中类型，新增全部小说筛选
        '    AbstractBox.Properties.EndUpdate()
        'End Sub

        ' ''' <summary>
        ' ''' 获取查询条件
        ' ''' </summary>
        ' ''' <returns>查询条件</returns>
        ' ''' <remarks>获取查询条件</remarks>
        'Function GetScanCondition() As Story
        '    Dim xScan As New Story(BookNameBox.Text, AuthorBox.Text, CategoryBox.EditValue, AbstractBox.Text, RatingBox.Text)
        '    Select Case ShieldBox.SelectedIndex
        '        Case 0
        '            xScan.IsRead = String.Empty
        '        Case 1
        '            xScan.IsRead = 1
        '        Case 2
        '            xScan.IsRead = 0
        '    End Select
        '    Return xScan
        'End Function

        ' ''' <summary>
        ' ''' 设置分页按钮
        ' ''' </summary>
        ' ''' <param name="FirstBol">首页</param>
        ' ''' <param name="PrevBol">前页</param>
        ' ''' <param name="NextBol">后页</param>
        ' ''' <param name="LastBol">末页</param>
        ' ''' <remarks>设置分页按钮</remarks>
        'Private Sub SetPaggingBtn(ByVal FirstBol As Boolean, ByVal PrevBol As Boolean, ByVal NextBol As Boolean, ByVal LastBol As Boolean)
        '    GoFirstBtn.Enabled = FirstBol
        '    GoPrevBtn.Enabled = PrevBol
        '    GoNextBtn.Enabled = NextBol
        '    GoLastBtn.Enabled = LastBol
        'End Sub

        'Private Sub SetPaggingBtnVisiable(ByVal bol As BarItemVisibility)
        '    GoFirstBtn.Visibility = bol
        '    GoPrevBtn.Visibility = bol
        '    GoNextBtn.Visibility = bol
        '    GoLastBtn.Visibility = bol
        'End Sub

        ' ''' <summary>
        ' ''' 重置分页信息
        ' ''' </summary>
        ' ''' <remarks>重置分页信息</remarks>
        'Private Sub ResetPagging()
        '    pg = New Pagging(StoryOpt.GetCount(GetScanCondition, TableName))
        '    ShowPaggingInfo()
        '    If pg.RowCount <> 0 Then
        '        SetPaggingBtn(False, False, True, True)
        '    Else
        '        SetPaggingBtn(False, False, False, False)
        '    End If
        'End Sub

        ' ''' <summary>
        ' ''' 显示分页信息
        ' ''' </summary>
        ' ''' <remarks>显示分页信息</remarks>
        'Private Sub ShowPaggingInfo()
        '    PaggingInfo.Caption = String.Format("当前第 {0} 页，共 {1} 页", pg.CurrentIndex, pg.PageCount)
        'End Sub

        ' ''' <summary>
        ' ''' 窗体初始化
        ' ''' </summary>
        ' ''' <param name="sender">发送方</param>
        ' ''' <param name="e">事件</param>
        ' ''' <remarks>窗体初始化</remarks>
        'Private Sub Fr_User_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '    LoadCategoryList()
        '    LoadList(Nothing)
        'End Sub

        ' ''' <summary>
        ' ''' 按钮事件
        ' ''' </summary>
        ' ''' <param name="sender">发起方</param>
        ' ''' <param name="e">事件</param>
        ' ''' <remarks>按钮事件</remarks>
        'Private Sub Btn_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles DoScanBtn.ItemClick, DoDownBtn.ItemClick, DoCollectBtn.ItemClick, DoShieldBtn.ItemClick, GoFirstBtn.ItemClick, GoPrevBtn.ItemClick, GoNextBtn.ItemClick, GoLastBtn.ItemClick
        '    Select Case e.Item.Name
        '        Case "DoScanBtn"
        '            pg = New Pagging(StoryOpt.GetCount(GetScanCondition, TableName))
        '            ResetPagging()
        '            LoadList(GetScanCondition)
        '        Case "DoDownBtn"
        '            DoThread(AddressOf DoDownLoad)
        '        Case "DoCollectBtn"
        '            If Log.ShowConfirm("采集将清空现有数据重新从网站同步，是否需要采集？【该操作不可逆，不可取消！】") = False Then
        '                Return
        '            End If
        '            DoThread(AddressOf DoCollect)
        '        Case "DoShieldBtn"
        '            DoThread(AddressOf DoShield)
        '        Case "GoFirstBtn"
        '            pg.CurrentIndex = 1
        '            SetPaggingBtn(False, False, True, True)
        '            ShowPaggingInfo()
        '            LoadList(GetScanCondition)
        '        Case "GoPrevBtn"
        '            pg.CurrentIndex -= 1
        '            If pg.CurrentIndex = 1 Then
        '                SetPaggingBtn(False, False, True, True)
        '            Else
        '                SetPaggingBtn(True, True, True, True)
        '            End If
        '            ShowPaggingInfo()
        '            LoadList(GetScanCondition)
        '        Case "GoNextBtn"
        '            pg.CurrentIndex += 1
        '            If pg.CurrentIndex = pg.PageCount - 1 Then
        '                SetPaggingBtn(True, True, False, False)
        '            Else
        '                SetPaggingBtn(True, True, True, True)
        '            End If
        '            ShowPaggingInfo()
        '            LoadList(GetScanCondition)
        '        Case "GoLastBtn"
        '            pg.CurrentIndex = pg.PageCount
        '            SetPaggingBtn(True, True, False, False)
        '            ShowPaggingInfo()
        '            LoadList(GetScanCondition)
        '    End Select
        'End Sub

        ' ''' <summary>
        ' ''' 清除按钮事件
        ' ''' </summary>
        ' ''' <param name="sender">发起方</param>
        ' ''' <param name="e">事件</param>
        ' ''' <remarks>清除按钮事件</remarks>
        'Private Sub ClearBtn_ButtonClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs) Handles RatingBox.ButtonClick, AuthorBox.ButtonClick, BookNameBox.ButtonClick, AbstractBox.ButtonClick
        '    If e.Button.Kind = ButtonPredefines.Delete Then
        '        CType(sender, ButtonEdit).Text = String.Empty
        '        CType(sender, ButtonEdit).EditValue = Nothing
        '    End If
        'End Sub

        ' ''' <summary>
        ' ''' 列表焦点变换事件
        ' ''' </summary>
        ' ''' <param name="sender">发起方</param>
        ' ''' <param name="e">事件</param>
        ' ''' <remarks>列表焦点变换事件</remarks>
        'Private Sub MainTree_FocusedNodeChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles MainTree.FocusedNodeChanged
        '    DoShieldBtn.Caption = "屏蔽"
        '    If e.Node Is Nothing Then
        '        Return
        '    End If
        '    If e.Node.GetValue(0) Is Nothing Then
        '        Return
        '    End If
        '    If CType(e.Node.GetValue(0), Story).IsRead = 1 Then
        '        DoShieldBtn.Caption = "解除屏蔽"
        '    End If
        'End Sub

        ' ''' <summary>
        ' ''' 分类框关闭事件
        ' ''' </summary>
        ' ''' <param name="sender">发起方</param>
        ' ''' <param name="e">事件</param>
        ' ''' <remarks>分类框关闭事件</remarks>
        'Private Sub CategoryBox_Properties_Closed(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles CategoryBox.Properties.Closed
        '    ResetPagging()
        '    LoadList(GetScanCondition)
        '    MainTree.Focus()
        'End Sub
    End Class
End Namespace