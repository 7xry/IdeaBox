Namespace View
    Partial Public Class Fr_MainForm
        Inherits DevExpress.XtraEditors.XtraForm
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_MainForm))
            Me.BarBox = New DevExpress.XtraBars.BarManager(Me.components)
            Me.StatusBar = New DevExpress.XtraBars.Bar()
            Me.WelComeLbl = New DevExpress.XtraBars.BarStaticItem()
            Me.BarStaticItem2 = New DevExpress.XtraBars.BarStaticItem()
            Me.TimeLbl = New DevExpress.XtraBars.BarStaticItem()
            Me.iPaintStyle = New DevExpress.XtraBars.SkinBarSubItem()
            Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
            Me.BannerBox = New DevExpress.XtraEditors.PanelControl()
            Me.BocimLogo = New System.Windows.Forms.PictureBox()
            Me.ExitSystemBtn = New DevExpress.XtraEditors.LabelControl()
            Me.ImageLs = New DevExpress.Utils.ImageCollection(Me.components)
            Me.ManualBtn = New DevExpress.XtraEditors.LabelControl()
            Me.DoRegKeyBtn = New DevExpress.XtraEditors.LabelControl()
            Me.NavBar = New DevExpress.XtraNavBar.NavBarControl()
            Me.SignGroup = New DevExpress.XtraNavBar.NavBarGroup()
            Me.StoryManageBtn = New DevExpress.XtraNavBar.NavBarItem()
            Me.ScanExpress = New DevExpress.XtraNavBar.NavBarItem()
            Me.InputExpressForIn = New DevExpress.XtraNavBar.NavBarItem()
            Me.InputExpressForOut = New DevExpress.XtraNavBar.NavBarItem()
            Me.CollectReport = New DevExpress.XtraNavBar.NavBarItem()
            Me.ConfigGroup = New DevExpress.XtraNavBar.NavBarGroup()
            Me.UserManagerBtn = New DevExpress.XtraNavBar.NavBarItem()
            Me.DeptManager = New DevExpress.XtraNavBar.NavBarItem()
            Me.ExComManager = New DevExpress.XtraNavBar.NavBarItem()
            Me.StatusManager = New DevExpress.XtraNavBar.NavBarItem()
            Me.MainTab = New DevExpress.XtraTab.XtraTabControl()
            Me.Tm = New System.Windows.Forms.Timer(Me.components)
            CType(Me.BarBox, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BannerBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BannerBox.SuspendLayout()
            CType(Me.BocimLogo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ImageLs, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NavBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MainTab, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'BarBox
            '
            Me.BarBox.AllowCustomization = False
            Me.BarBox.AllowMoveBarOnToolbar = False
            Me.BarBox.AllowQuickCustomization = False
            Me.BarBox.AllowShowToolbarsPopup = False
            Me.BarBox.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.StatusBar})
            Me.BarBox.DockControls.Add(Me.barDockControlTop)
            Me.BarBox.DockControls.Add(Me.barDockControlBottom)
            Me.BarBox.DockControls.Add(Me.barDockControlLeft)
            Me.BarBox.DockControls.Add(Me.barDockControlRight)
            Me.BarBox.Form = Me
            Me.BarBox.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.TimeLbl, Me.WelComeLbl, Me.BarStaticItem2, Me.iPaintStyle})
            Me.BarBox.MaxItemId = 6
            Me.BarBox.StatusBar = Me.StatusBar
            '
            'StatusBar
            '
            Me.StatusBar.BarName = "Status bar"
            Me.StatusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
            Me.StatusBar.DockCol = 0
            Me.StatusBar.DockRow = 0
            Me.StatusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
            Me.StatusBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.WelComeLbl), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.TimeLbl), New DevExpress.XtraBars.LinkPersistInfo(Me.iPaintStyle)})
            Me.StatusBar.OptionsBar.AllowQuickCustomization = False
            Me.StatusBar.OptionsBar.DrawDragBorder = False
            Me.StatusBar.OptionsBar.UseWholeRow = True
            Me.StatusBar.Text = "Status bar"
            '
            'WelComeLbl
            '
            Me.WelComeLbl.Caption = "WelCome"
            Me.WelComeLbl.Id = 1
            Me.WelComeLbl.Name = "WelComeLbl"
            Me.WelComeLbl.TextAlignment = System.Drawing.StringAlignment.Near
            '
            'BarStaticItem2
            '
            Me.BarStaticItem2.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
            Me.BarStaticItem2.Caption = "BarStaticItem2"
            Me.BarStaticItem2.Id = 2
            Me.BarStaticItem2.Name = "BarStaticItem2"
            Me.BarStaticItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
            Me.BarStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near
            Me.BarStaticItem2.Width = 32
            '
            'TimeLbl
            '
            Me.TimeLbl.Caption = "Time is？"
            Me.TimeLbl.Id = 0
            Me.TimeLbl.Name = "TimeLbl"
            Me.TimeLbl.TextAlignment = System.Drawing.StringAlignment.Near
            '
            'iPaintStyle
            '
            Me.iPaintStyle.Caption = "主题样式"
            Me.iPaintStyle.Id = 4
            Me.iPaintStyle.Name = "iPaintStyle"
            '
            'barDockControlTop
            '
            Me.barDockControlTop.CausesValidation = False
            Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
            Me.barDockControlTop.Size = New System.Drawing.Size(1294, 0)
            '
            'barDockControlBottom
            '
            Me.barDockControlBottom.CausesValidation = False
            Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.barDockControlBottom.Location = New System.Drawing.Point(0, 644)
            Me.barDockControlBottom.Size = New System.Drawing.Size(1294, 27)
            '
            'barDockControlLeft
            '
            Me.barDockControlLeft.CausesValidation = False
            Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
            Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
            Me.barDockControlLeft.Size = New System.Drawing.Size(0, 644)
            '
            'barDockControlRight
            '
            Me.barDockControlRight.CausesValidation = False
            Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.barDockControlRight.Location = New System.Drawing.Point(1294, 0)
            Me.barDockControlRight.Size = New System.Drawing.Size(0, 644)
            '
            'BannerBox
            '
            Me.BannerBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.BannerBox.ContentImage = Global.IdeaBox.My.Resources.Resources.TopBanner
            Me.BannerBox.ContentImageAlignment = System.Drawing.ContentAlignment.BottomLeft
            Me.BannerBox.Controls.Add(Me.BocimLogo)
            Me.BannerBox.Controls.Add(Me.ExitSystemBtn)
            Me.BannerBox.Controls.Add(Me.ManualBtn)
            Me.BannerBox.Controls.Add(Me.DoRegKeyBtn)
            Me.BannerBox.Dock = System.Windows.Forms.DockStyle.Top
            Me.BannerBox.Location = New System.Drawing.Point(0, 0)
            Me.BannerBox.Name = "BannerBox"
            Me.BannerBox.Size = New System.Drawing.Size(1294, 80)
            Me.BannerBox.TabIndex = 4
            '
            'BocimLogo
            '
            Me.BocimLogo.BackColor = System.Drawing.Color.Transparent
            Me.BocimLogo.Location = New System.Drawing.Point(12, 23)
            Me.BocimLogo.Name = "BocimLogo"
            Me.BocimLogo.Size = New System.Drawing.Size(300, 40)
            Me.BocimLogo.TabIndex = 1
            Me.BocimLogo.TabStop = False
            '
            'ExitSystemBtn
            '
            Me.ExitSystemBtn.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.ExitSystemBtn.Appearance.ForeColor = System.Drawing.Color.White
            Me.ExitSystemBtn.Appearance.ImageIndex = 8
            Me.ExitSystemBtn.Appearance.ImageList = Me.ImageLs
            Me.ExitSystemBtn.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ExitSystemBtn.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
            Me.ExitSystemBtn.Location = New System.Drawing.Point(1189, 12)
            Me.ExitSystemBtn.Name = "ExitSystemBtn"
            Me.ExitSystemBtn.Size = New System.Drawing.Size(93, 36)
            Me.ExitSystemBtn.TabIndex = 0
            Me.ExitSystemBtn.Text = "退出系统"
            '
            'ImageLs
            '
            Me.ImageLs.ImageSize = New System.Drawing.Size(32, 32)
            Me.ImageLs.ImageStream = CType(resources.GetObject("ImageLs.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
            Me.ImageLs.InsertGalleryImage("Config", "images/programming/ide_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/ide_32x32.png"), 0)
            Me.ImageLs.Images.SetKeyName(0, "Config")
            Me.ImageLs.InsertGalleryImage("Express", "images/support/packageproduct_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/packageproduct_32x32.png"), 1)
            Me.ImageLs.Images.SetKeyName(1, "Express")
            Me.ImageLs.InsertGalleryImage("UserManager", "images/people/publicfix_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/publicfix_32x32.png"), 2)
            Me.ImageLs.Images.SetKeyName(2, "UserManager")
            Me.ImageLs.InsertGalleryImage("DeptManager", "images/people/team_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/team_32x32.png"), 3)
            Me.ImageLs.Images.SetKeyName(3, "DeptManager")
            Me.ImageLs.InsertGalleryImage("InputExpress", "images/tasks/edittask_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/tasks/edittask_32x32.png"), 4)
            Me.ImageLs.Images.SetKeyName(4, "InputExpress")
            Me.ImageLs.InsertGalleryImage("ScanExpress", "images/zoom/zoom_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/zoom/zoom_32x32.png"), 5)
            Me.ImageLs.Images.SetKeyName(5, "ScanExpress")
            Me.ImageLs.InsertGalleryImage("BackHome", "images/navigation/home_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/home_32x32.png"), 6)
            Me.ImageLs.Images.SetKeyName(6, "BackHome")
            Me.ImageLs.InsertGalleryImage("ResetLogin", "images/actions/convert_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/convert_32x32.png"), 7)
            Me.ImageLs.Images.SetKeyName(7, "ResetLogin")
            Me.ImageLs.InsertGalleryImage("Close", "images/programming/operatingsystem_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/operatingsystem_32x32.png"), 8)
            Me.ImageLs.Images.SetKeyName(8, "Close")
            Me.ImageLs.InsertGalleryImage("ExComManager", "images/programming/build_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/build_32x32.png"), 9)
            Me.ImageLs.Images.SetKeyName(9, "ExComManager")
            Me.ImageLs.InsertGalleryImage("StatusManager", "images/programming/tag_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/tag_32x32.png"), 10)
            Me.ImageLs.Images.SetKeyName(10, "StatusManager")
            Me.ImageLs.InsertGalleryImage("CollectReport", "images/reports/groupheader_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/reports/groupheader_32x32.png"), 11)
            Me.ImageLs.Images.SetKeyName(11, "CollectReport")
            Me.ImageLs.InsertGalleryImage("RegKey.png", "images/programming/showtestreport_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/showtestreport_32x32.png"), 12)
            Me.ImageLs.Images.SetKeyName(12, "RegKey.png")
            Me.ImageLs.InsertGalleryImage("Role", "images/people/role_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/role_32x32.png"), 13)
            Me.ImageLs.Images.SetKeyName(13, "Role")
            Me.ImageLs.InsertGalleryImage("Path", "images/actions/open_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/open_32x32.png"), 14)
            Me.ImageLs.Images.SetKeyName(14, "Path")
            Me.ImageLs.InsertGalleryImage("Manual", "images/support/knowledgebasearticle_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/knowledgebasearticle_32x32.png"), 15)
            Me.ImageLs.Images.SetKeyName(15, "Manual")
            '
            'ManualBtn
            '
            Me.ManualBtn.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.ManualBtn.Appearance.ForeColor = System.Drawing.Color.White
            Me.ManualBtn.Appearance.ImageIndex = 15
            Me.ManualBtn.Appearance.ImageList = Me.ImageLs
            Me.ManualBtn.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ManualBtn.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
            Me.ManualBtn.Location = New System.Drawing.Point(1090, 12)
            Me.ManualBtn.Name = "ManualBtn"
            Me.ManualBtn.Size = New System.Drawing.Size(93, 36)
            Me.ManualBtn.TabIndex = 0
            Me.ManualBtn.Text = "帮助手册"
            '
            'DoRegKeyBtn
            '
            Me.DoRegKeyBtn.Appearance.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            Me.DoRegKeyBtn.Appearance.ForeColor = System.Drawing.Color.White
            Me.DoRegKeyBtn.Appearance.ImageIndex = 12
            Me.DoRegKeyBtn.Appearance.ImageList = Me.ImageLs
            Me.DoRegKeyBtn.Cursor = System.Windows.Forms.Cursors.Hand
            Me.DoRegKeyBtn.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
            Me.DoRegKeyBtn.Location = New System.Drawing.Point(991, 12)
            Me.DoRegKeyBtn.Name = "DoRegKeyBtn"
            Me.DoRegKeyBtn.Size = New System.Drawing.Size(93, 36)
            Me.DoRegKeyBtn.TabIndex = 0
            Me.DoRegKeyBtn.Text = "软件授权"
            Me.DoRegKeyBtn.Visible = False
            '
            'NavBar
            '
            Me.NavBar.ActiveGroup = Me.SignGroup
            Me.NavBar.Dock = System.Windows.Forms.DockStyle.Left
            Me.NavBar.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.SignGroup, Me.ConfigGroup})
            Me.NavBar.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.UserManagerBtn, Me.DeptManager, Me.ScanExpress, Me.InputExpressForIn, Me.ExComManager, Me.InputExpressForOut, Me.StatusManager, Me.CollectReport, Me.StoryManageBtn})
            Me.NavBar.LargeImages = Me.ImageLs
            Me.NavBar.Location = New System.Drawing.Point(0, 80)
            Me.NavBar.Name = "NavBar"
            Me.NavBar.OptionsNavPane.ExpandedWidth = 150
            Me.NavBar.OptionsNavPane.ShowGroupImageInHeader = True
            Me.NavBar.OptionsNavPane.ShowOverflowButton = False
            Me.NavBar.OptionsNavPane.ShowOverflowPanel = False
            Me.NavBar.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
            Me.NavBar.Size = New System.Drawing.Size(150, 564)
            Me.NavBar.SmallImages = Me.ImageLs
            Me.NavBar.TabIndex = 5
            Me.NavBar.Text = "功能导航"
            Me.NavBar.View = New DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator()
            '
            'SignGroup
            '
            Me.SignGroup.Caption = "小说管理"
            Me.SignGroup.Expanded = True
            Me.SignGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText
            Me.SignGroup.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.StoryManageBtn), New DevExpress.XtraNavBar.NavBarItemLink(Me.ScanExpress), New DevExpress.XtraNavBar.NavBarItemLink(Me.InputExpressForIn), New DevExpress.XtraNavBar.NavBarItemLink(Me.InputExpressForOut), New DevExpress.XtraNavBar.NavBarItemLink(Me.CollectReport)})
            Me.SignGroup.LargeImageIndex = 1
            Me.SignGroup.Name = "SignGroup"
            Me.SignGroup.SmallImageIndex = 1
            '
            'StoryManageBtn
            '
            Me.StoryManageBtn.Caption = "爱奇小说网"
            Me.StoryManageBtn.LargeImageIndex = 1
            Me.StoryManageBtn.Name = "StoryManageBtn"
            Me.StoryManageBtn.SmallImageIndex = 1
            '
            'ScanExpress
            '
            Me.ScanExpress.Caption = "查询快件"
            Me.ScanExpress.LargeImageIndex = 5
            Me.ScanExpress.Name = "ScanExpress"
            Me.ScanExpress.SmallImageIndex = 0
            Me.ScanExpress.Visible = False
            '
            'InputExpressForIn
            '
            Me.InputExpressForIn.Caption = "进件管理"
            Me.InputExpressForIn.LargeImageIndex = 4
            Me.InputExpressForIn.Name = "InputExpressForIn"
            Me.InputExpressForIn.SmallImageIndex = 4
            Me.InputExpressForIn.Visible = False
            '
            'InputExpressForOut
            '
            Me.InputExpressForOut.Caption = "出件管理"
            Me.InputExpressForOut.LargeImageIndex = 4
            Me.InputExpressForOut.Name = "InputExpressForOut"
            Me.InputExpressForOut.SmallImageIndex = 4
            Me.InputExpressForOut.Visible = False
            '
            'CollectReport
            '
            Me.CollectReport.Caption = "快件统计"
            Me.CollectReport.LargeImageIndex = 11
            Me.CollectReport.Name = "CollectReport"
            Me.CollectReport.SmallImageIndex = 11
            Me.CollectReport.Visible = False
            '
            'ConfigGroup
            '
            Me.ConfigGroup.Caption = "电影管理"
            Me.ConfigGroup.Expanded = True
            Me.ConfigGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText
            Me.ConfigGroup.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.UserManagerBtn), New DevExpress.XtraNavBar.NavBarItemLink(Me.DeptManager), New DevExpress.XtraNavBar.NavBarItemLink(Me.ExComManager), New DevExpress.XtraNavBar.NavBarItemLink(Me.StatusManager)})
            Me.ConfigGroup.LargeImageIndex = 0
            Me.ConfigGroup.Name = "ConfigGroup"
            '
            'UserManagerBtn
            '
            Me.UserManagerBtn.Caption = "破晓电影网"
            Me.UserManagerBtn.LargeImageIndex = 10
            Me.UserManagerBtn.Name = "UserManagerBtn"
            '
            'DeptManager
            '
            Me.DeptManager.Caption = "部门管理"
            Me.DeptManager.LargeImageIndex = 3
            Me.DeptManager.Name = "DeptManager"
            Me.DeptManager.Visible = False
            '
            'ExComManager
            '
            Me.ExComManager.Caption = "快件类型管理"
            Me.ExComManager.LargeImageIndex = 9
            Me.ExComManager.Name = "ExComManager"
            Me.ExComManager.SmallImageIndex = 9
            Me.ExComManager.Visible = False
            '
            'StatusManager
            '
            Me.StatusManager.Caption = "快件状态管理"
            Me.StatusManager.LargeImageIndex = 10
            Me.StatusManager.Name = "StatusManager"
            Me.StatusManager.SmallImageIndex = 10
            Me.StatusManager.Visible = False
            '
            'MainTab
            '
            Me.MainTab.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader
            Me.MainTab.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MainTab.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[False]
            Me.MainTab.Images = Me.ImageLs
            Me.MainTab.Location = New System.Drawing.Point(150, 80)
            Me.MainTab.Name = "MainTab"
            Me.MainTab.Size = New System.Drawing.Size(1144, 564)
            Me.MainTab.TabIndex = 10
            '
            'Tm
            '
            Me.Tm.Enabled = True
            Me.Tm.Interval = 500
            '
            'Fr_MainForm
            '
            Me.Appearance.Options.UseFont = True
            Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile
            Me.BackgroundImageStore = Global.IdeaBox.My.Resources.Resources.MainBg
            Me.ClientSize = New System.Drawing.Size(1294, 671)
            Me.Controls.Add(Me.MainTab)
            Me.Controls.Add(Me.NavBar)
            Me.Controls.Add(Me.BannerBox)
            Me.Controls.Add(Me.barDockControlLeft)
            Me.Controls.Add(Me.barDockControlRight)
            Me.Controls.Add(Me.barDockControlBottom)
            Me.Controls.Add(Me.barDockControlTop)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Me.DoubleBuffered = True
            Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.MaximizeBox = False
            Me.MaximumSize = New System.Drawing.Size(1300, 700)
            Me.MinimumSize = New System.Drawing.Size(1300, 699)
            Me.Name = "Fr_MainForm"
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "灵感盒子"
            CType(Me.BarBox, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BannerBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BannerBox.ResumeLayout(False)
            Me.BannerBox.PerformLayout()
            CType(Me.BocimLogo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ImageLs, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NavBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MainTab, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents BarBox As DevExpress.XtraBars.BarManager
        Friend WithEvents StatusBar As DevExpress.XtraBars.Bar
        Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
        Friend WithEvents NavBar As DevExpress.XtraNavBar.NavBarControl
        Friend WithEvents ConfigGroup As DevExpress.XtraNavBar.NavBarGroup
        Friend WithEvents BannerBox As DevExpress.XtraEditors.PanelControl
        Friend WithEvents SignGroup As DevExpress.XtraNavBar.NavBarGroup
        Friend WithEvents ScanExpress As DevExpress.XtraNavBar.NavBarItem
        Friend WithEvents InputExpressForIn As DevExpress.XtraNavBar.NavBarItem
        Friend WithEvents UserManagerBtn As DevExpress.XtraNavBar.NavBarItem
        Friend WithEvents DeptManager As DevExpress.XtraNavBar.NavBarItem
        Friend WithEvents ImageLs As DevExpress.Utils.ImageCollection
        Friend WithEvents MainTab As DevExpress.XtraTab.XtraTabControl
        Friend WithEvents ExitSystemBtn As DevExpress.XtraEditors.LabelControl
        Friend WithEvents TimeLbl As DevExpress.XtraBars.BarStaticItem
        Friend WithEvents Tm As System.Windows.Forms.Timer
        Friend WithEvents WelComeLbl As DevExpress.XtraBars.BarStaticItem
        Friend WithEvents BarStaticItem2 As DevExpress.XtraBars.BarStaticItem
        Friend WithEvents ExComManager As DevExpress.XtraNavBar.NavBarItem
        Friend WithEvents InputExpressForOut As DevExpress.XtraNavBar.NavBarItem
        Friend WithEvents StatusManager As DevExpress.XtraNavBar.NavBarItem
        Friend WithEvents CollectReport As DevExpress.XtraNavBar.NavBarItem
        Friend WithEvents BocimLogo As System.Windows.Forms.PictureBox
        Friend WithEvents iPaintStyle As DevExpress.XtraBars.SkinBarSubItem
        Friend WithEvents StoryManageBtn As DevExpress.XtraNavBar.NavBarItem
        Friend WithEvents DoRegKeyBtn As DevExpress.XtraEditors.LabelControl
        Friend WithEvents ManualBtn As DevExpress.XtraEditors.LabelControl

#End Region

    End Class
End Namespace
