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
Imports System.Threading
Imports IdeaBox.StoryManage.API

Namespace StoryManage.View
    Public Class Fr_Story

#Region "变量"
        '多线程
        Dim ThreadTask As Thread
        '分页信息
        Private page As Pagging
        Public StoryImplOpt As IStoryWeb
#End Region

#Region "属性"
        '设置动态表名
        Property TName As String
        '当前线程是否已经完成
        Property IsCompleted As Boolean = True
#End Region

#Region "委托"
        '安全委托
        Public Delegate Sub InvokeHandler()
        Public Shared Sub SafeInvoke(ByVal control As Control, ByVal handler As InvokeHandler)
            If control.InvokeRequired Then
                control.Invoke(handler)
            Else
                handler()
            End If
        End Sub

        '委托设置状态栏
        Public Sub SetStatInvoke(ByVal Caption As String)
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 StatLbl.Caption = Caption
                                             End Sub))
        End Sub

        '委托设置分页按钮是否可见
        Public Sub SetStatVisibilityInvoke(ByVal bol As BarItemVisibility)
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 StatLbl.Visibility = bol
                                             End Sub))
        End Sub

        '委托设置分页按钮是否可用
        Public Sub SetStatEnableInvoke(ByVal bol As Boolean)
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 StatLbl.Enabled = bol
                                             End Sub))
        End Sub

        '委托分页状态栏
        Public Sub SetPaggingInvoke()
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 PaggingLbl.Caption = String.Format("当前第 {0} 页，共 {1} 页", page.CurrentIndex, page.PageCount)
                                             End Sub))
        End Sub

        '委托设置分页状态栏是否可见
        Public Sub SetPaggingVisibilityInvoke(ByVal bol As BarItemVisibility)
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 PaggingLbl.Visibility = bol
                                             End Sub))
        End Sub

        '委托设置分页状态栏是否可用
        Public Sub SetPaggingEnableInvoke(ByVal bol As Boolean)
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 PaggingLbl.Enabled = bol
                                             End Sub))
        End Sub

        '委托设置分页按钮是否可见
        Public Sub SetPaggingBtnVisibilityInvoke(ByVal bol As BarItemVisibility)
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 GoFirstBtn.Visibility = bol
                                                 GoPrevBtn.Visibility = bol
                                                 GoNextBtn.Visibility = bol
                                                 GoLastBtn.Visibility = bol
                                             End Sub))
        End Sub

        '委托设置分页按钮是否可用
        Public Sub SetPaggingBtnEnableInvoke(ByVal FirstBol As Boolean, ByVal PrevBol As Boolean, ByVal NextBol As Boolean, ByVal LastBol As Boolean)
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 GoFirstBtn.Enabled = FirstBol
                                                 GoPrevBtn.Enabled = PrevBol
                                                 GoNextBtn.Enabled = NextBol
                                                 GoLastBtn.Enabled = LastBol
                                             End Sub))
        End Sub

        '委托加载列表信息
        Public Sub SetTreeStartInvoke()
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 MainTree.BeginUnboundLoad()
                                             End Sub))
        End Sub

        '委托加载列表信息
        Public Sub SetTreeEndInvoke()
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 MainTree.ExpandAll()
                                                 MainTree.EndUnboundLoad()
                                                 MainTree.Focus()
                                             End Sub))
        End Sub

        '委托加载列表信息
        Public Sub SetTreeInvoke()
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 MainTree.Nodes.Clear()
                                             End Sub))
        End Sub

        '委托加载列表信息
        Public Function SetTreeInvoke(ByVal nodeDate As Object, ByVal parentNode As TreeListNode) As TreeListNode
            Dim Article As TreeListNode = Nothing
            SafeInvoke(Me, New InvokeHandler(Sub()
                                                 Article = MainTree.AppendNode(nodeDate, parentNode)
                                             End Sub))
            Return Article
        End Function


#End Region

#Region "构造方法"
        Sub New(ByVal TableName As String, ByVal StoryOpt As IStoryWeb)
            ' 此调用是设计器所必需的。
            InitializeComponent()
            ' 在 InitializeComponent() 调用之后添加任何初始化。
            TName = TableName
            StoryImplOpt = StoryOpt
            LoadCategoryList()
        End Sub
#End Region

#Region "多线程"
        ''' <summary>
        ''' 执行线程（无参数）
        ''' </summary>
        ''' <param name="addrOf">线程事件</param>
        ''' <remarks>执行线程（无参数）</remarks>
        Sub DoThread(ByVal addrOf As ThreadStart)
            If ThreadTaskIsRun() = True Then
                Return
            End If
            '创建线程加载showloadlist子程序加载内容
            ThreadTask = New Thread(addrOf)
            ThreadTask.Start()
        End Sub

        ''' <summary>
        ''' 执行线程（有参数）
        ''' </summary>
        ''' <param name="addrOf">线程事件</param>
        ''' <param name="obj">参数</param>
        ''' <remarks>执行线程（有参数）</remarks>
        Sub DoThread(ByVal addrOf As ParameterizedThreadStart, ByVal obj As Object)
            If ThreadTaskIsRun() = True Then
                Return
            End If
            '创建线程加载showloadlist子程序加载内容
            ThreadTask = New Thread(addrOf)
            ThreadTask.Start(obj)
        End Sub

        ''' <summary>
        ''' 关闭线程
        ''' </summary>
        ''' <remarks>关闭线程</remarks>
        Sub DoThreadDispose()
            If ThreadTask.IsAlive Then
                ThreadTask.Abort()
            End If
        End Sub
#End Region

#Region "公用函数"
        ''' <summary>
        ''' 获取查询条件
        ''' </summary>
        ''' <returns>查询条件</returns>
        ''' <remarks>获取查询条件</remarks>
        Function GetScanCondition() As Story
            Dim xScan As New Story(BookNameBox.Text, AuthorBox.Text, CategoryBox.EditValue, AbstractBox.Text, RatingBox.Text)
            Select Case ShieldBox.SelectedIndex
                Case 0
                    xScan.IsRead = String.Empty
                Case 1
                    xScan.IsRead = 1
                Case 2
                    xScan.IsRead = 0
            End Select
            Return xScan
        End Function

        ''' <summary>
        ''' 重置分页信息
        ''' </summary>
        ''' <remarks>重置分页信息</remarks>
        Private Sub ResetPagging(ByVal xScan As Story)
            If xScan.IsNothing = False Then
                page = New Pagging(StoryOpt.GetCount(xScan, TName))
            Else
                page = New Pagging(0)
            End If
            SetPaggingInvoke()
            If page.PageCount > 1 Then
                SetPaggingBtnEnableInvoke(False, False, True, True)
            Else
                SetPaggingBtnEnableInvoke(False, False, False, False)
            End If
        End Sub

        ''' <summary>
        ''' 获取选择的记录
        ''' </summary>
        ''' <returns>选择文件信息</returns>
        ''' <remarks>获取选择的记录</remarks>
        Function GetSelectFiles() As List(Of Story)
            Dim fileLs As New List(Of Story)
            Dim dr As TreeListMultiSelection = MainTree.Selection
            If dr.Count <= 0 Then
                Return fileLs
            End If
            For Each r As TreeListNode In dr
                Dim book As Story = r.GetValue(0)
                If book Is Nothing Then
                    Continue For
                End If
                fileLs.Add(book)
            Next
            Return fileLs
        End Function

        ''' <summary>
        ''' 检查多线程是否正在工作
        ''' </summary>
        ''' <returns>是否工作</returns>
        ''' <remarks>检查多线程是否正在工作</remarks>
        Function ThreadTaskIsRun() As Boolean
            If IsCompleted <> True Then
                Log.Showlog("当前有任务正在执行，请稍后……", MsgType.WarnMsg)
                Return True
            End If
            Return False
        End Function
#End Region

#Region "公用方法"
        ''' <summary>
        ''' 加载小说分类
        ''' </summary>
        ''' <remarks>加载小说分类</remarks>
        Sub LoadCategoryList()
            CategoryBox.Properties.BeginUpdate()
            CategoryBox.Properties.Items.Clear()
            CategoryBox.Properties.Items.Add("全部小说")
            For Each Category In StoryOpt.GetCategory(TName)
                CategoryBox.Properties.Items.Add(Category)
            Next
            If CategoryBox.Properties.Items.Count > 1 Then
                CategoryBox.SelectedItem = CategoryBox.Properties.Items(1)
            End If
            '除了数据库中类型，新增全部小说筛选
            CategoryBox.Properties.EndUpdate()
        End Sub
#End Region

#Region "事件"

        Private Sub Scan(ByVal xScan As Story)
            IsCompleted = False
            SetTreeStartInvoke()
            SetTreeInvoke()
            Dim parentForRootNodes As TreeListNode = Nothing
            If xScan.IsNothing Then
                SetTreeInvoke(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, 0)}, parentForRootNodes)
                SetTreeEndInvoke()
                IsCompleted = True
                Return
            End If
            Dim ls As List(Of Story) = StoryOpt.GetList(xScan, TName, (page.CurrentIndex - 1) * perPage)
            If ls IsNot Nothing Then
                Dim Article As TreeListNode = SetTreeInvoke(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, page.RowCount)}, parentForRootNodes)
                '创建根节点
                For Each xStory As Story In ls
                    SetTreeInvoke(New Object() {xStory, xStory.BookName, xStory.Author,
                                                  xStory.Category, xStory.FileSize, xStory.Rating,
                                                  xStory.DownloadQuantity, xStory.UploadDate, xStory.Abstract, xStory.DownloadAddr,
                                                  xStory.IsRead}, Article)
                Next
            Else
                SetTreeInvoke(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, page.RowCount)}, parentForRootNodes)
            End If
            SetTreeEndInvoke()
            IsCompleted = True
        End Sub

        Private Sub Download()
            IsCompleted = False
            Dim timer As New Stopwatch
            timer.Start()
            Dim fileLs As List(Of Story) = GetSelectFiles()
            If fileLs.Count <= 0 Then
                Log.Showlog("请选择要下载的记录！", MsgType.WarnMsg)
                IsCompleted = True
                Return
            End If
            SetStatInvoke(String.Format("正在获取下载列表，请稍后……"))
            SetStatVisibilityInvoke(BarItemVisibility.Always)
            SetPaggingVisibilityInvoke(BarItemVisibility.Never)
            SetPaggingBtnVisibilityInvoke(BarItemVisibility.Never)
            Dim CurIndex As Integer = 1
            For Each f As Story In fileLs
                Dim fDown As New FileDown
                fDown.fileInfo = StoryImplOpt.GetBookInfo(f)
                fDown.SourceFile = fDown.fileInfo.DownloadAddr
                fDown.TargetFile = String.Format("{0}\{1}", AppPath.GetRunPath, fDown.fileInfo.Category)
                If Directory.Exists(fDown.TargetFile) = False Then
                    Directory.CreateDirectory(fDown.TargetFile)
                End If
                fDown.FileExtension = Mid(fDown.SourceFile, fDown.SourceFile.LastIndexOf(".") + 2)
                If fDown.FileExtension.StartsWith("aspx") Then
                    fDown.FileExtension = "txt"
                End If
                fDown.TargetFile = String.Format("{0}\{1}.{2}", fDown.TargetFile, fDown.fileInfo.BookName, fDown.FileExtension)
                fDown.CurrentIndex = CurIndex
                fDown.AllCount = fileLs.Count
                fDown.timer = timer
                FileDownOpt.DownLoadFiles(fDown)
                CurIndex += 1
            Next
            timer.Stop()
            SetStatVisibilityInvoke(BarItemVisibility.Never)
            SetPaggingVisibilityInvoke(BarItemVisibility.Always)
            SetPaggingBtnVisibilityInvoke(BarItemVisibility.Always)
            Log.Showlog(String.Format("下载完成，共计下载：{0} 本，累计耗时：{1}", fileLs.Count, timer.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")), Utils.FileSystem.Dict.MsgType.InfoMsg)
            IsCompleted = True
        End Sub

        Private Sub Collect()
            IsCompleted = False
            SetStatInvoke(String.Format("正在准备开始采集，请稍后……"))
            SetStatVisibilityInvoke(BarItemVisibility.Always)
            SetPaggingVisibilityInvoke(BarItemVisibility.Never)
            SetPaggingBtnVisibilityInvoke(BarItemVisibility.Never)
            Dim timer As New Stopwatch
            timer.Start()
            StoryOpt.ResetTable(TName)
            StoryImplOpt.GetBooks(timer, TName)
            timer.Stop()
            SetStatVisibilityInvoke(BarItemVisibility.Never)
            SetPaggingVisibilityInvoke(BarItemVisibility.Always)
            SetPaggingBtnVisibilityInvoke(BarItemVisibility.Always)
            Log.Showlog(String.Format("采集完成，共计耗时：{0}", timer.Elapsed.ToString("hh\ \小\时\ mm\ \分\ ss\ \秒\ ")), Utils.FileSystem.Dict.MsgType.InfoMsg)
            IsCompleted = True
        End Sub

        Private Sub Shield()
            IsCompleted = False
            Dim fileLs As List(Of Story) = GetSelectFiles()
            Dim sLs As New List(Of Story)
            Select Case DoShieldBtn.Caption
                Case "屏蔽"
                    If fileLs.Count <= 0 Then
                        Log.Showlog("请选择要屏蔽的记录！", MsgType.WarnMsg)
                        Return
                        IsCompleted = True
                    End If
                    For Each f As Story In fileLs
                        f.IsRead = 1
                        sLs.Add(f)
                    Next
                Case "解除屏蔽"
                    If fileLs.Count <= 0 Then
                        Log.Showlog("请选择要解除屏蔽的记录！", MsgType.WarnMsg)
                        Return
                        IsCompleted = True
                    End If
                    For Each f As Story In fileLs
                        f.IsRead = 0
                        sLs.Add(f)
                    Next
            End Select
            StoryOpt.Update(sLs, TName)
            ResetPagging(GetScanCondition)
            Scan(GetScanCondition)
            IsCompleted = True
        End Sub
#End Region

#Region "窗体事件"
        ''' <summary>
        ''' 窗体初始化
        ''' </summary>
        ''' <param name="sender">发送方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>窗体初始化</remarks>
        Private Sub Fr_User_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ResetPagging(New Story)
            DoThread(AddressOf Scan, New Story)
        End Sub

        ''' <summary>
        ''' 窗体关闭事件
        ''' </summary>
        ''' <param name="sender">发送方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>关闭窗体时自动终止后台线程</remarks>
        Private Sub Fr_Aqtxt_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
            DoThreadDispose()
        End Sub

        ''' <summary>
        ''' 按钮事件
        ''' </summary>
        ''' <param name="sender">发起方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>按钮事件</remarks>
        Private Sub Btn_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles DoScanBtn.ItemClick, DoDownBtn.ItemClick, DoCollectBtn.ItemClick, DoShieldBtn.ItemClick, GoFirstBtn.ItemClick, GoPrevBtn.ItemClick, GoNextBtn.ItemClick, GoLastBtn.ItemClick
            Select Case e.Item.Name
                Case "DoScanBtn"
                    If ThreadTaskIsRun() = True Then
                        Return
                    End If
                    ResetPagging(GetScanCondition)
                    DoThread(AddressOf Scan, GetScanCondition)
                Case "DoDownBtn"
                    DoThread(AddressOf Download)
                Case "DoCollectBtn"
                    If ThreadTaskIsRun() = True Then
                        Return
                    End If
                    If Log.ShowConfirm("采集将清空现有数据重新从网站同步，是否需要采集？【该操作不可逆，不可取消！】") = False Then
                        Return
                    End If
                    DoThread(AddressOf Collect)
                Case "DoShieldBtn"
                    DoThread(AddressOf Shield)
                Case "GoFirstBtn"
                    page.CurrentIndex = 1
                    If page.PageCount > 1 Then
                        SetPaggingBtnEnableInvoke(False, False, True, True)
                    Else
                        SetPaggingBtnEnableInvoke(False, False, False, False)
                    End If
                    SetPaggingInvoke()
                    DoThread(AddressOf Scan, GetScanCondition)
                Case "GoPrevBtn"
                    If page.CurrentIndex > 1 Then
                        page.CurrentIndex -= 1
                    Else
                        page.CurrentIndex = 1
                    End If
                    If page.CurrentIndex = 1 Then
                        SetPaggingBtnEnableInvoke(False, False, True, True)
                    Else
                        SetPaggingBtnEnableInvoke(True, True, True, True)
                    End If
                    SetPaggingInvoke()
                    DoThread(AddressOf Scan, GetScanCondition)
                Case "GoNextBtn"
                    If page.CurrentIndex < page.PageCount Then
                        page.CurrentIndex += 1
                    Else
                        page.CurrentIndex = page.PageCount
                    End If
                    If page.CurrentIndex = page.PageCount Then
                        SetPaggingBtnEnableInvoke(True, True, False, False)
                    Else
                        SetPaggingBtnEnableInvoke(True, True, True, True)
                    End If
                    SetPaggingInvoke()
                    DoThread(AddressOf Scan, GetScanCondition)
                Case "GoLastBtn"
                    page.CurrentIndex = page.PageCount
                    If page.PageCount > 1 Then
                        SetPaggingBtnEnableInvoke(True, True, False, False)
                    Else
                        SetPaggingBtnEnableInvoke(False, False, False, False)
                    End If
                    SetPaggingInvoke()
                    DoThread(AddressOf Scan, GetScanCondition)
            End Select
        End Sub

        ''' <summary>
        ''' 列表焦点变换事件
        ''' </summary>
        ''' <param name="sender">发起方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>列表焦点变换事件</remarks>
        Private Sub MainTree_FocusedNodeChanged(ByVal sender As Object, ByVal e As FocusedNodeChangedEventArgs) Handles MainTree.FocusedNodeChanged
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

        ''' <summary>
        ''' 分类框关闭事件
        ''' </summary>
        ''' <param name="sender">发起方</param>
        ''' <param name="e">事件</param>
        ''' <remarks>分类框关闭事件</remarks>
        Private Sub CategoryBox_Properties_Closed(ByVal sender As Object, ByVal e As ClosedEventArgs) Handles CategoryBox.Properties.Closed
            ResetPagging(GetScanCondition)
            DoThread(AddressOf Scan, GetScanCondition)
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
#End Region

    End Class
End Namespace