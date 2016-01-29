Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports IdeaBox.Utils.Security
Imports IdeaBox.Utils.FileSystem.Enum
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Controls
Imports IdeaBox.Utils.Windows
Imports IdeaBox.StoryManage.Model
Imports IdeaBox.Utils.FileSystem.Path
Imports System.IO
Imports DevExpress.LookAndFeel
Imports IdeaBox.StoryManage.Impl

Namespace StoryManage.View
    Public Class Fr_Aqtxt
        Property TableName As String
        Sub New(ByVal TName As String)

            ' 此调用是设计器所必需的。
            InitializeComponent()
            TableName = TName
        End Sub

        Overloads Sub LoadList(ByVal Tree As TreeList)
            Tree.BeginUnboundLoad()
            '清除列表显示
            Tree.Nodes.Clear()
            Dim parentForRootNodes As TreeListNode = Nothing
            Dim xScan As New Story(BookNameBox.Text, AuthorBox.Text, CategoryBox.Text, AbstractBox.Text, RatingBox.Text)

            Dim ls As List(Of Story) = StoryOpt.GetList(xScan, TableName)
            If ls IsNot Nothing Then
                Dim Article As TreeListNode = Tree.AppendNode(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, ls.Count)}, parentForRootNodes)
                '创建根节点
                For Each xStory As Story In ls
                    Tree.AppendNode(New Object() {xStory,
                                                  xStory.BookName,
                                                  xStory.Author,
                                                  xStory.Category,
                                                  xStory.FileSize,
                                                  xStory.Rating,
                                                  xStory.DownloadQuantity,
                                                  xStory.Abstract,
                                                  xStory.DownloadAddr,
                                                  xStory.IsRead
                                                 }, Article)
                Next
            Else
                Tree.AppendNode(New Object() {Nothing, String.Format("所有{0}  [ 共 {1} 本 ]", CategoryBox.Text, ls.Count)}, parentForRootNodes)
            End If
            Tree.ExpandAll()
            Tree.EndUnboundLoad()
        End Sub

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
            LoadList(MainTree)
        End Sub

        Private Sub DoScanBtn_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DoScanBtn.ItemClick
            Dim ThreadTask As Threading.Thread
            '创建线程加载showloadlist子程序加载内容
            ThreadTask = New Threading.Thread(AddressOf showloadlist)
            ThreadTask.Start()

        End Sub
        Private Sub showloadlist()
            '加载显示列表内容
            LoadList(MainTree)
        End Sub


        Private Sub DoAddBtn_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DoDownBtn.ItemClick
            'If AddSign() = True Then
            '    ClearEdit()
            'End If
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

        Private Sub DoDeleteBtn_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DoDeleteBtn.ItemClick

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
            For Each Category In StoryOpt.GetCategory(TableName)
                CategoryBox.Properties.Items.Add(Category)
            Next
            If CategoryBox.Properties.Items.Count > 0 Then
                CategoryBox.SelectedItem = CategoryBox.Properties.Items(0)
            End If
            '除了数据库中类型，新增全部小说筛选
            CategoryBox.Properties.Items.Add("全部小说")
            AbstractBox.Properties.EndUpdate()
        End Sub

        Private Sub CategoryBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryBox.SelectedIndexChanged
            If CategoryBox.SelectedItem Is Nothing Then
                Return
            End If
            LoadList(MainTree)
        End Sub

        Private Sub DoReLoadBtn_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DoReLoadBtn.ItemClick
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
        End Sub
    End Class
End Namespace