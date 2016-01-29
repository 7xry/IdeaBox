Namespace StoryManage.View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Fr_Aqtxt
        Inherits DevExpress.XtraEditors.XtraForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Aqtxt))
            Me.XtraBar = New DevExpress.XtraBars.BarManager(Me.components)
            Me.ToolBar = New DevExpress.XtraBars.Bar()
            Me.DoScanBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.DoDownBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.DoReLoadBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.DoDeleteBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.SpcaceItem = New DevExpress.XtraBars.BarStaticItem()
            Me.DownNowStat = New DevExpress.XtraBars.BarHeaderItem()
            Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
            Me.ImageLs = New DevExpress.Utils.ImageCollection(Me.components)
            Me.ScanDateBox = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
            Me.DownProBar = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
            Me.GBox = New DevExpress.XtraEditors.GroupControl()
            Me.CategoryBox = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.BookNameBox = New DevExpress.XtraEditors.ButtonEdit()
            Me.AuthorBox = New DevExpress.XtraEditors.ButtonEdit()
            Me.AbstractBox = New DevExpress.XtraEditors.ButtonEdit()
            Me.RatingBox = New DevExpress.XtraEditors.ButtonEdit()
            Me.CategoryLbl = New DevExpress.XtraEditors.LabelControl()
            Me.AbstractLbl = New DevExpress.XtraEditors.LabelControl()
            Me.BookNameLbl = New DevExpress.XtraEditors.LabelControl()
            Me.AuthorLbl = New DevExpress.XtraEditors.LabelControl()
            Me.RatingLbl = New DevExpress.XtraEditors.LabelControl()
            Me.MainTree = New DevExpress.XtraTreeList.TreeList()
            Me.DataObjCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.BookNameCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.AuthorCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.CategoryCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.FileSizeCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.RatingCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.DownloadQuantityCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.UploadDateCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.AbstractCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.DownloadAddrCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.IsReadCol = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            CType(Me.XtraBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ImageLs, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ScanDateBox, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ScanDateBox.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DownProBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GBox.SuspendLayout()
            CType(Me.CategoryBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BookNameBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AuthorBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AbstractBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RatingBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MainTree, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'XtraBar
            '
            Me.XtraBar.AllowMoveBarOnToolbar = False
            Me.XtraBar.AllowQuickCustomization = False
            Me.XtraBar.AllowShowToolbarsPopup = False
            Me.XtraBar.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.ToolBar})
            Me.XtraBar.DockControls.Add(Me.barDockControlTop)
            Me.XtraBar.DockControls.Add(Me.barDockControlBottom)
            Me.XtraBar.DockControls.Add(Me.barDockControlLeft)
            Me.XtraBar.DockControls.Add(Me.barDockControlRight)
            Me.XtraBar.Form = Me
            Me.XtraBar.Images = Me.ImageLs
            Me.XtraBar.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.DoDownBtn, Me.DoReLoadBtn, Me.DoDeleteBtn, Me.SpcaceItem, Me.DoScanBtn, Me.DownNowStat})
            Me.XtraBar.LargeImages = Me.ImageLs
            Me.XtraBar.MaxItemId = 15
            Me.XtraBar.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ScanDateBox, Me.DownProBar})
            '
            'ToolBar
            '
            Me.ToolBar.BarName = "工具条"
            Me.ToolBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
            Me.ToolBar.DockCol = 0
            Me.ToolBar.DockRow = 0
            Me.ToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
            Me.ToolBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoScanBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoDownBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoReLoadBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoDeleteBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.SpcaceItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DownNowStat)})
            Me.ToolBar.OptionsBar.AllowQuickCustomization = False
            Me.ToolBar.OptionsBar.MinHeight = 30
            Me.ToolBar.Text = "工具条"
            '
            'DoScanBtn
            '
            Me.DoScanBtn.Caption = "查询"
            Me.DoScanBtn.Id = 3
            Me.DoScanBtn.ImageIndex = 5
            Me.DoScanBtn.LargeImageIndex = 0
            Me.DoScanBtn.Name = "DoScanBtn"
            '
            'DoDownBtn
            '
            Me.DoDownBtn.Caption = "下载"
            Me.DoDownBtn.Id = 3
            Me.DoDownBtn.ImageIndex = 1
            Me.DoDownBtn.LargeImageIndex = 1
            Me.DoDownBtn.Name = "DoDownBtn"
            '
            'DoReLoadBtn
            '
            Me.DoReLoadBtn.Caption = "采集"
            Me.DoReLoadBtn.Id = 3
            Me.DoReLoadBtn.ImageIndex = 2
            Me.DoReLoadBtn.LargeImageIndex = 0
            Me.DoReLoadBtn.Name = "DoReLoadBtn"
            '
            'DoDeleteBtn
            '
            Me.DoDeleteBtn.Caption = "删除"
            Me.DoDeleteBtn.Id = 3
            Me.DoDeleteBtn.ImageIndex = 3
            Me.DoDeleteBtn.LargeImageIndex = 0
            Me.DoDeleteBtn.Name = "DoDeleteBtn"
            '
            'SpcaceItem
            '
            Me.SpcaceItem.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
            Me.SpcaceItem.Id = 4
            Me.SpcaceItem.Name = "SpcaceItem"
            Me.SpcaceItem.TextAlignment = System.Drawing.StringAlignment.Near
            Me.SpcaceItem.Width = 32
            '
            'DownNowStat
            '
            Me.DownNowStat.Caption = "正在下载：{f}"
            Me.DownNowStat.Id = 13
            Me.DownNowStat.Name = "DownNowStat"
            Me.DownNowStat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            '
            'barDockControlTop
            '
            Me.barDockControlTop.CausesValidation = False
            Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
            Me.barDockControlTop.Size = New System.Drawing.Size(1138, 0)
            '
            'barDockControlBottom
            '
            Me.barDockControlBottom.CausesValidation = False
            Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.barDockControlBottom.Location = New System.Drawing.Point(0, 488)
            Me.barDockControlBottom.Size = New System.Drawing.Size(1138, 47)
            '
            'barDockControlLeft
            '
            Me.barDockControlLeft.CausesValidation = False
            Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
            Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
            Me.barDockControlLeft.Size = New System.Drawing.Size(0, 488)
            '
            'barDockControlRight
            '
            Me.barDockControlRight.CausesValidation = False
            Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.barDockControlRight.Location = New System.Drawing.Point(1138, 0)
            Me.barDockControlRight.Size = New System.Drawing.Size(0, 488)
            '
            'ImageLs
            '
            Me.ImageLs.ImageSize = New System.Drawing.Size(32, 32)
            Me.ImageLs.ImageStream = CType(resources.GetObject("ImageLs.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
            Me.ImageLs.Images.SetKeyName(0, "Refresh.png")
            Me.ImageLs.Images.SetKeyName(1, "Add.png")
            Me.ImageLs.Images.SetKeyName(2, "Edit.png")
            Me.ImageLs.Images.SetKeyName(3, "Delete.png")
            Me.ImageLs.Images.SetKeyName(4, "Clear.png")
            Me.ImageLs.Images.SetKeyName(5, "Search.png")
            '
            'ScanDateBox
            '
            Me.ScanDateBox.Appearance.Options.UseTextOptions = True
            Me.ScanDateBox.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.ScanDateBox.AutoHeight = False
            Me.ScanDateBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.ScanDateBox.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.ScanDateBox.DisplayFormat.FormatString = "yyyy-MM"
            Me.ScanDateBox.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.ScanDateBox.EditFormat.FormatString = "yyyy-MM"
            Me.ScanDateBox.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.ScanDateBox.Mask.EditMask = "yyyy-MM"
            Me.ScanDateBox.Name = "ScanDateBox"
            Me.ScanDateBox.ShowWeekNumbers = True
            Me.ScanDateBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            '
            'DownProBar
            '
            Me.DownProBar.Name = "DownProBar"
            Me.DownProBar.Step = 1
            '
            'GBox
            '
            Me.GBox.Appearance.BackColor = System.Drawing.Color.White
            Me.GBox.Appearance.Options.UseBackColor = True
            Me.GBox.AppearanceCaption.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.GBox.AppearanceCaption.Options.UseFont = True
            Me.GBox.Controls.Add(Me.CategoryBox)
            Me.GBox.Controls.Add(Me.BookNameBox)
            Me.GBox.Controls.Add(Me.AuthorBox)
            Me.GBox.Controls.Add(Me.AbstractBox)
            Me.GBox.Controls.Add(Me.RatingBox)
            Me.GBox.Controls.Add(Me.CategoryLbl)
            Me.GBox.Controls.Add(Me.AbstractLbl)
            Me.GBox.Controls.Add(Me.BookNameLbl)
            Me.GBox.Controls.Add(Me.AuthorLbl)
            Me.GBox.Controls.Add(Me.RatingLbl)
            Me.GBox.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.GBox.Location = New System.Drawing.Point(0, 359)
            Me.GBox.Name = "GBox"
            Me.GBox.Size = New System.Drawing.Size(1138, 129)
            Me.GBox.TabIndex = 4
            Me.GBox.Text = String.Format("小说查询 —— 支持以下关系表达式：并且（{0}） > 或者（{1}） > 排除（{2}） ", "&&&&", "||", "!=")
            '
            'CategoryBox
            '
            Me.CategoryBox.Location = New System.Drawing.Point(848, 39)
            Me.CategoryBox.Name = "CategoryBox"
            Me.CategoryBox.Properties.AllowFocused = False
            Me.CategoryBox.Properties.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CategoryBox.Properties.Appearance.Options.UseFont = True
            Me.CategoryBox.Properties.AutoHeight = False
            Me.CategoryBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.CategoryBox.Properties.DropDownItemHeight = 30
            Me.CategoryBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.CategoryBox.Size = New System.Drawing.Size(250, 30)
            Me.CategoryBox.TabIndex = 5
            '
            'BookNameBox
            '
            Me.BookNameBox.Cursor = System.Windows.Forms.Cursors.Hand
            Me.BookNameBox.Location = New System.Drawing.Point(132, 39)
            Me.BookNameBox.Name = "BookNameBox"
            Me.BookNameBox.Properties.AllowFocused = False
            Me.BookNameBox.Properties.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.BookNameBox.Properties.Appearance.Options.UseFont = True
            Me.BookNameBox.Properties.AutoHeight = False
            Me.BookNameBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
            Me.BookNameBox.Size = New System.Drawing.Size(250, 30)
            Me.BookNameBox.TabIndex = 1
            '
            'AuthorBox
            '
            Me.AuthorBox.Cursor = System.Windows.Forms.Cursors.Hand
            Me.AuthorBox.Location = New System.Drawing.Point(490, 39)
            Me.AuthorBox.Name = "AuthorBox"
            Me.AuthorBox.Properties.AllowFocused = False
            Me.AuthorBox.Properties.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.AuthorBox.Properties.Appearance.Options.UseFont = True
            Me.AuthorBox.Properties.AutoHeight = False
            Me.AuthorBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
            Me.AuthorBox.Size = New System.Drawing.Size(250, 30)
            Me.AuthorBox.TabIndex = 3
            '
            'AbstractBox
            '
            Me.AbstractBox.Cursor = System.Windows.Forms.Cursors.Hand
            Me.AbstractBox.Location = New System.Drawing.Point(132, 78)
            Me.AbstractBox.Name = "AbstractBox"
            Me.AbstractBox.Properties.AllowFocused = False
            Me.AbstractBox.Properties.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.AbstractBox.Properties.Appearance.Options.UseFont = True
            Me.AbstractBox.Properties.AutoHeight = False
            Me.AbstractBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
            Me.AbstractBox.Size = New System.Drawing.Size(250, 30)
            Me.AbstractBox.TabIndex = 7
            '
            'RatingBox
            '
            Me.RatingBox.Cursor = System.Windows.Forms.Cursors.Hand
            Me.RatingBox.Location = New System.Drawing.Point(490, 78)
            Me.RatingBox.Name = "RatingBox"
            Me.RatingBox.Properties.AllowFocused = False
            Me.RatingBox.Properties.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.RatingBox.Properties.Appearance.Options.UseFont = True
            Me.RatingBox.Properties.AutoHeight = False
            Me.RatingBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
            Me.RatingBox.Size = New System.Drawing.Size(250, 30)
            Me.RatingBox.TabIndex = 9
            '
            'CategoryLbl
            '
            Me.CategoryLbl.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.CategoryLbl.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
            Me.CategoryLbl.Location = New System.Drawing.Point(773, 47)
            Me.CategoryLbl.Name = "CategoryLbl"
            Me.CategoryLbl.Size = New System.Drawing.Size(42, 19)
            Me.CategoryLbl.TabIndex = 4
            Me.CategoryLbl.Text = "分类："
            '
            'AbstractLbl
            '
            Me.AbstractLbl.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.AbstractLbl.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
            Me.AbstractLbl.Location = New System.Drawing.Point(57, 86)
            Me.AbstractLbl.Name = "AbstractLbl"
            Me.AbstractLbl.Size = New System.Drawing.Size(42, 19)
            Me.AbstractLbl.TabIndex = 6
            Me.AbstractLbl.Text = "简介："
            '
            'BookNameLbl
            '
            Me.BookNameLbl.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.BookNameLbl.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
            Me.BookNameLbl.Location = New System.Drawing.Point(57, 47)
            Me.BookNameLbl.Name = "BookNameLbl"
            Me.BookNameLbl.Size = New System.Drawing.Size(42, 19)
            Me.BookNameLbl.TabIndex = 0
            Me.BookNameLbl.Text = "书名："
            '
            'AuthorLbl
            '
            Me.AuthorLbl.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.AuthorLbl.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
            Me.AuthorLbl.Location = New System.Drawing.Point(415, 47)
            Me.AuthorLbl.Name = "AuthorLbl"
            Me.AuthorLbl.Size = New System.Drawing.Size(42, 19)
            Me.AuthorLbl.TabIndex = 2
            Me.AuthorLbl.Text = "作者："
            '
            'RatingLbl
            '
            Me.RatingLbl.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.RatingLbl.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
            Me.RatingLbl.Location = New System.Drawing.Point(415, 86)
            Me.RatingLbl.Name = "RatingLbl"
            Me.RatingLbl.Size = New System.Drawing.Size(42, 19)
            Me.RatingLbl.TabIndex = 8
            Me.RatingLbl.Text = "评分："
            '
            'MainTree
            '
            Me.MainTree.ColumnPanelRowHeight = 30
            Me.MainTree.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.DataObjCol, Me.BookNameCol, Me.AuthorCol, Me.CategoryCol, Me.FileSizeCol, Me.RatingCol, Me.DownloadQuantityCol, Me.UploadDateCol, Me.AbstractCol, Me.DownloadAddrCol, Me.IsReadCol})
            Me.MainTree.Cursor = System.Windows.Forms.Cursors.Hand
            Me.MainTree.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MainTree.Location = New System.Drawing.Point(0, 0)
            Me.MainTree.Name = "MainTree"
            Me.MainTree.OptionsBehavior.AllowExpandOnDblClick = False
            Me.MainTree.OptionsPrint.AutoRowHeight = False
            Me.MainTree.OptionsPrint.AutoWidth = False
            Me.MainTree.OptionsPrint.PrintAllNodes = True
            Me.MainTree.OptionsPrint.PrintReportFooter = False
            Me.MainTree.OptionsPrint.PrintTree = False
            Me.MainTree.OptionsPrint.UsePrintStyles = False
            Me.MainTree.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.MainTree.OptionsSelection.MultiSelect = True
            Me.MainTree.OptionsSelection.UseIndicatorForSelection = True
            Me.MainTree.OptionsView.AutoWidth = False
            Me.MainTree.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None
            Me.MainTree.RowHeight = 30
            Me.MainTree.Size = New System.Drawing.Size(1138, 359)
            Me.MainTree.TabIndex = 14
            '
            'DataObjCol
            '
            Me.DataObjCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DataObjCol.AppearanceCell.Options.UseFont = True
            Me.DataObjCol.AppearanceCell.Options.UseTextOptions = True
            Me.DataObjCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.DataObjCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DataObjCol.AppearanceHeader.Options.UseFont = True
            Me.DataObjCol.AppearanceHeader.Options.UseTextOptions = True
            Me.DataObjCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.DataObjCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.DataObjCol.Caption = "数据源"
            Me.DataObjCol.FieldName = "数据源"
            Me.DataObjCol.Name = "DataObjCol"
            Me.DataObjCol.OptionsColumn.AllowEdit = False
            Me.DataObjCol.OptionsColumn.AllowFocus = False
            Me.DataObjCol.OptionsColumn.AllowMove = False
            Me.DataObjCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.DataObjCol.OptionsColumn.AllowSize = False
            Me.DataObjCol.OptionsColumn.AllowSort = False
            Me.DataObjCol.OptionsColumn.ShowInCustomizationForm = False
            Me.DataObjCol.Width = 150
            '
            'BookNameCol
            '
            Me.BookNameCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BookNameCol.AppearanceCell.Options.UseFont = True
            Me.BookNameCol.AppearanceCell.Options.UseTextOptions = True
            Me.BookNameCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.BookNameCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BookNameCol.AppearanceHeader.Options.UseFont = True
            Me.BookNameCol.AppearanceHeader.Options.UseTextOptions = True
            Me.BookNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.BookNameCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.BookNameCol.Caption = "书名"
            Me.BookNameCol.FieldName = "书名"
            Me.BookNameCol.Name = "BookNameCol"
            Me.BookNameCol.OptionsColumn.AllowEdit = False
            Me.BookNameCol.OptionsColumn.AllowFocus = False
            Me.BookNameCol.OptionsColumn.AllowMove = False
            Me.BookNameCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.BookNameCol.OptionsColumn.AllowSize = False
            Me.BookNameCol.OptionsColumn.AllowSort = False
            Me.BookNameCol.OptionsColumn.ShowInCustomizationForm = False
            Me.BookNameCol.Visible = True
            Me.BookNameCol.VisibleIndex = 0
            Me.BookNameCol.Width = 250
            '
            'AuthorCol
            '
            Me.AuthorCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AuthorCol.AppearanceCell.Options.UseFont = True
            Me.AuthorCol.AppearanceCell.Options.UseTextOptions = True
            Me.AuthorCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.AuthorCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.AuthorCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AuthorCol.AppearanceHeader.Options.UseFont = True
            Me.AuthorCol.AppearanceHeader.Options.UseTextOptions = True
            Me.AuthorCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.AuthorCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.AuthorCol.Caption = "作者"
            Me.AuthorCol.FieldName = "作者"
            Me.AuthorCol.Name = "AuthorCol"
            Me.AuthorCol.OptionsColumn.AllowEdit = False
            Me.AuthorCol.OptionsColumn.AllowFocus = False
            Me.AuthorCol.OptionsColumn.AllowMove = False
            Me.AuthorCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.AuthorCol.OptionsColumn.AllowSize = False
            Me.AuthorCol.OptionsColumn.AllowSort = False
            Me.AuthorCol.OptionsColumn.ShowInCustomizationForm = False
            Me.AuthorCol.Visible = True
            Me.AuthorCol.VisibleIndex = 1
            Me.AuthorCol.Width = 100
            '
            'CategoryCol
            '
            Me.CategoryCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CategoryCol.AppearanceCell.Options.UseFont = True
            Me.CategoryCol.AppearanceCell.Options.UseTextOptions = True
            Me.CategoryCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.CategoryCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.CategoryCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CategoryCol.AppearanceHeader.Options.UseFont = True
            Me.CategoryCol.AppearanceHeader.Options.UseTextOptions = True
            Me.CategoryCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.CategoryCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.CategoryCol.Caption = "分类"
            Me.CategoryCol.FieldName = "分类"
            Me.CategoryCol.Name = "CategoryCol"
            Me.CategoryCol.OptionsColumn.AllowEdit = False
            Me.CategoryCol.OptionsColumn.AllowFocus = False
            Me.CategoryCol.OptionsColumn.AllowMove = False
            Me.CategoryCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.CategoryCol.OptionsColumn.AllowSize = False
            Me.CategoryCol.OptionsColumn.AllowSort = False
            Me.CategoryCol.OptionsColumn.ShowInCustomizationForm = False
            Me.CategoryCol.Visible = True
            Me.CategoryCol.VisibleIndex = 2
            Me.CategoryCol.Width = 100
            '
            'FileSizeCol
            '
            Me.FileSizeCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FileSizeCol.AppearanceCell.Options.UseFont = True
            Me.FileSizeCol.AppearanceCell.Options.UseTextOptions = True
            Me.FileSizeCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.FileSizeCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.FileSizeCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FileSizeCol.AppearanceHeader.Options.UseFont = True
            Me.FileSizeCol.AppearanceHeader.Options.UseTextOptions = True
            Me.FileSizeCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.FileSizeCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.FileSizeCol.Caption = "文件大小"
            Me.FileSizeCol.FieldName = "文件大小"
            Me.FileSizeCol.Name = "FileSizeCol"
            Me.FileSizeCol.OptionsColumn.AllowEdit = False
            Me.FileSizeCol.OptionsColumn.AllowFocus = False
            Me.FileSizeCol.OptionsColumn.AllowMove = False
            Me.FileSizeCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.FileSizeCol.OptionsColumn.AllowSize = False
            Me.FileSizeCol.OptionsColumn.AllowSort = False
            Me.FileSizeCol.OptionsColumn.ShowInCustomizationForm = False
            Me.FileSizeCol.Visible = True
            Me.FileSizeCol.VisibleIndex = 3
            Me.FileSizeCol.Width = 100
            '
            'RatingCol
            '
            Me.RatingCol.AppearanceCell.Options.UseTextOptions = True
            Me.RatingCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.RatingCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.RatingCol.AppearanceHeader.Options.UseTextOptions = True
            Me.RatingCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.RatingCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.RatingCol.Caption = "评分"
            Me.RatingCol.FieldName = "评分"
            Me.RatingCol.Name = "RatingCol"
            Me.RatingCol.OptionsColumn.AllowEdit = False
            Me.RatingCol.OptionsColumn.AllowFocus = False
            Me.RatingCol.OptionsColumn.AllowMove = False
            Me.RatingCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.RatingCol.OptionsColumn.AllowSize = False
            Me.RatingCol.OptionsColumn.AllowSort = False
            Me.RatingCol.OptionsColumn.ShowInCustomizationForm = False
            Me.RatingCol.Visible = True
            Me.RatingCol.VisibleIndex = 4
            Me.RatingCol.Width = 80
            '
            'DownloadQuantityCol
            '
            Me.DownloadQuantityCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DownloadQuantityCol.AppearanceCell.Options.UseFont = True
            Me.DownloadQuantityCol.AppearanceCell.Options.UseTextOptions = True
            Me.DownloadQuantityCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.DownloadQuantityCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.DownloadQuantityCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DownloadQuantityCol.AppearanceHeader.Options.UseFont = True
            Me.DownloadQuantityCol.AppearanceHeader.Options.UseTextOptions = True
            Me.DownloadQuantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.DownloadQuantityCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.DownloadQuantityCol.Caption = "下载数量"
            Me.DownloadQuantityCol.FieldName = "下载数量"
            Me.DownloadQuantityCol.Name = "DownloadQuantityCol"
            Me.DownloadQuantityCol.OptionsColumn.AllowEdit = False
            Me.DownloadQuantityCol.OptionsColumn.AllowFocus = False
            Me.DownloadQuantityCol.OptionsColumn.AllowMove = False
            Me.DownloadQuantityCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.DownloadQuantityCol.OptionsColumn.AllowSize = False
            Me.DownloadQuantityCol.OptionsColumn.AllowSort = False
            Me.DownloadQuantityCol.OptionsColumn.ShowInCustomizationForm = False
            Me.DownloadQuantityCol.Visible = True
            Me.DownloadQuantityCol.VisibleIndex = 5
            Me.DownloadQuantityCol.Width = 100
            '
            'UploadDateCol
            '
            Me.UploadDateCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UploadDateCol.AppearanceCell.Options.UseFont = True
            Me.UploadDateCol.AppearanceCell.Options.UseTextOptions = True
            Me.UploadDateCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.UploadDateCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.UploadDateCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UploadDateCol.AppearanceHeader.Options.UseFont = True
            Me.UploadDateCol.AppearanceHeader.Options.UseTextOptions = True
            Me.UploadDateCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.UploadDateCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.UploadDateCol.Caption = "更新时间"
            Me.UploadDateCol.FieldName = "更新时间"
            Me.UploadDateCol.Name = "UploadDateCol"
            Me.UploadDateCol.OptionsColumn.AllowEdit = False
            Me.UploadDateCol.OptionsColumn.AllowFocus = False
            Me.UploadDateCol.OptionsColumn.AllowMove = False
            Me.UploadDateCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.UploadDateCol.OptionsColumn.AllowSize = False
            Me.UploadDateCol.OptionsColumn.AllowSort = False
            Me.UploadDateCol.OptionsColumn.ShowInCustomizationForm = False
            Me.UploadDateCol.Visible = True
            Me.UploadDateCol.VisibleIndex = 6
            Me.UploadDateCol.Width = 100
            '
            'AbstractCol
            '
            Me.AbstractCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AbstractCol.AppearanceCell.Options.UseFont = True
            Me.AbstractCol.AppearanceCell.Options.UseTextOptions = True
            Me.AbstractCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.AbstractCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AbstractCol.AppearanceHeader.Options.UseFont = True
            Me.AbstractCol.AppearanceHeader.Options.UseTextOptions = True
            Me.AbstractCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.AbstractCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.AbstractCol.Caption = "简介"
            Me.AbstractCol.FieldName = "简介"
            Me.AbstractCol.Name = "AbstractCol"
            Me.AbstractCol.OptionsColumn.AllowEdit = False
            Me.AbstractCol.OptionsColumn.AllowFocus = False
            Me.AbstractCol.OptionsColumn.AllowMove = False
            Me.AbstractCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.AbstractCol.OptionsColumn.AllowSize = False
            Me.AbstractCol.OptionsColumn.AllowSort = False
            Me.AbstractCol.OptionsColumn.ShowInCustomizationForm = False
            Me.AbstractCol.Visible = True
            Me.AbstractCol.VisibleIndex = 7
            Me.AbstractCol.Width = 260
            '
            'DownloadAddrCol
            '
            Me.DownloadAddrCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DownloadAddrCol.AppearanceCell.Options.UseFont = True
            Me.DownloadAddrCol.AppearanceCell.Options.UseTextOptions = True
            Me.DownloadAddrCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.DownloadAddrCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DownloadAddrCol.AppearanceHeader.Options.UseFont = True
            Me.DownloadAddrCol.AppearanceHeader.Options.UseTextOptions = True
            Me.DownloadAddrCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.DownloadAddrCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.DownloadAddrCol.Caption = "下载地址"
            Me.DownloadAddrCol.FieldName = "下载地址"
            Me.DownloadAddrCol.Name = "DownloadAddrCol"
            Me.DownloadAddrCol.OptionsColumn.AllowEdit = False
            Me.DownloadAddrCol.OptionsColumn.AllowFocus = False
            Me.DownloadAddrCol.OptionsColumn.AllowMove = False
            Me.DownloadAddrCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.DownloadAddrCol.OptionsColumn.AllowSize = False
            Me.DownloadAddrCol.OptionsColumn.AllowSort = False
            Me.DownloadAddrCol.OptionsColumn.ShowInCustomizationForm = False
            Me.DownloadAddrCol.Width = 150
            '
            'IsReadCol
            '
            Me.IsReadCol.AppearanceCell.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.IsReadCol.AppearanceCell.Options.UseFont = True
            Me.IsReadCol.AppearanceCell.Options.UseTextOptions = True
            Me.IsReadCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.IsReadCol.AppearanceHeader.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.IsReadCol.AppearanceHeader.Options.UseFont = True
            Me.IsReadCol.AppearanceHeader.Options.UseTextOptions = True
            Me.IsReadCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.IsReadCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.IsReadCol.Caption = "是否已读"
            Me.IsReadCol.FieldName = "是否已读"
            Me.IsReadCol.Name = "IsReadCol"
            Me.IsReadCol.OptionsColumn.AllowEdit = False
            Me.IsReadCol.OptionsColumn.AllowFocus = False
            Me.IsReadCol.OptionsColumn.AllowMove = False
            Me.IsReadCol.OptionsColumn.AllowMoveToCustomizationForm = False
            Me.IsReadCol.OptionsColumn.AllowSize = False
            Me.IsReadCol.OptionsColumn.AllowSort = False
            Me.IsReadCol.OptionsColumn.ShowInCustomizationForm = False
            Me.IsReadCol.Width = 100
            '
            'Fr_Aqtxt
            '
            Me.Appearance.BackColor = System.Drawing.Color.White
            Me.Appearance.Options.UseBackColor = True
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1138, 535)
            Me.Controls.Add(Me.MainTree)
            Me.Controls.Add(Me.GBox)
            Me.Controls.Add(Me.barDockControlLeft)
            Me.Controls.Add(Me.barDockControlRight)
            Me.Controls.Add(Me.barDockControlBottom)
            Me.Controls.Add(Me.barDockControlTop)
            Me.DoubleBuffered = True
            Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.Name = "Fr_Aqtxt"
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.Text = "书籍管理"
            CType(Me.XtraBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ImageLs, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ScanDateBox.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ScanDateBox, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DownProBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GBox.ResumeLayout(False)
            Me.GBox.PerformLayout()
            CType(Me.CategoryBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BookNameBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AuthorBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AbstractBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RatingBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MainTree, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents XtraBar As DevExpress.XtraBars.BarManager
        Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
        Friend WithEvents ImageLs As DevExpress.Utils.ImageCollection
        Friend WithEvents ToolBar As DevExpress.XtraBars.Bar
        Friend WithEvents DoDownBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents DoReLoadBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents DoDeleteBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents DoScanBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents SpcaceItem As DevExpress.XtraBars.BarStaticItem
        Friend WithEvents GBox As DevExpress.XtraEditors.GroupControl
        Friend WithEvents RatingBox As DevExpress.XtraEditors.ButtonEdit
        Friend WithEvents CategoryLbl As DevExpress.XtraEditors.LabelControl
        Friend WithEvents AbstractLbl As DevExpress.XtraEditors.LabelControl
        Friend WithEvents BookNameLbl As DevExpress.XtraEditors.LabelControl
        Friend WithEvents AuthorLbl As DevExpress.XtraEditors.LabelControl
        Friend WithEvents RatingLbl As DevExpress.XtraEditors.LabelControl
        Friend WithEvents ScanDateBox As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Friend WithEvents MainTree As DevExpress.XtraTreeList.TreeList
        Friend WithEvents DataObjCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents BookNameCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents AuthorCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents CategoryCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents FileSizeCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents RatingCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents DownloadQuantityCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents UploadDateCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents AbstractCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents DownloadAddrCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents IsReadCol As DevExpress.XtraTreeList.Columns.TreeListColumn
        Friend WithEvents DownProBar As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
        Friend WithEvents DownNowStat As DevExpress.XtraBars.BarHeaderItem
        Friend WithEvents CategoryBox As DevExpress.XtraEditors.ComboBoxEdit
        Friend WithEvents BookNameBox As DevExpress.XtraEditors.ButtonEdit
        Friend WithEvents AuthorBox As DevExpress.XtraEditors.ButtonEdit
        Friend WithEvents AbstractBox As DevExpress.XtraEditors.ButtonEdit
    End Class

End Namespace
