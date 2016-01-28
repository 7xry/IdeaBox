Namespace SignManage.View
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Fr_BaseForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_BaseForm))
            Me.XtraBar = New DevExpress.XtraBars.BarManager(Me.components)
            Me.ToolBar = New DevExpress.XtraBars.Bar()
            Me.DoRefreshBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.DoAddBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.DoModifyBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.DoDeleteBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.DoClearBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.SpcaceItem = New DevExpress.XtraBars.BarStaticItem()
            Me.DoScanBtn = New DevExpress.XtraBars.BarButtonItem()
            Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
            Me.ImageLs = New DevExpress.Utils.ImageCollection(Me.components)
            CType(Me.XtraBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ImageLs, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.XtraBar.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.DoRefreshBtn, Me.DoAddBtn, Me.DoModifyBtn, Me.DoDeleteBtn, Me.DoClearBtn, Me.SpcaceItem, Me.DoScanBtn})
            Me.XtraBar.LargeImages = Me.ImageLs
            Me.XtraBar.MaxItemId = 6
            '
            'ToolBar
            '
            Me.ToolBar.BarName = "工具条"
            Me.ToolBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
            Me.ToolBar.DockCol = 0
            Me.ToolBar.DockRow = 0
            Me.ToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
            Me.ToolBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoRefreshBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoAddBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoModifyBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoDeleteBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoClearBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.SpcaceItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DoScanBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
            Me.ToolBar.OptionsBar.AllowQuickCustomization = False
            Me.ToolBar.OptionsBar.MinHeight = 30
            Me.ToolBar.Text = "工具条"
            '
            'DoRefreshBtn
            '
            Me.DoRefreshBtn.Caption = "刷新"
            Me.DoRefreshBtn.Id = 3
            Me.DoRefreshBtn.ImageIndex = 0
            Me.DoRefreshBtn.LargeImageIndex = 0
            Me.DoRefreshBtn.Name = "DoRefreshBtn"
            '
            'DoAddBtn
            '
            Me.DoAddBtn.Caption = "新增"
            Me.DoAddBtn.Id = 3
            Me.DoAddBtn.ImageIndex = 1
            Me.DoAddBtn.LargeImageIndex = 1
            Me.DoAddBtn.Name = "DoAddBtn"
            '
            'DoModifyBtn
            '
            Me.DoModifyBtn.Caption = "修改"
            Me.DoModifyBtn.Id = 3
            Me.DoModifyBtn.ImageIndex = 2
            Me.DoModifyBtn.LargeImageIndex = 0
            Me.DoModifyBtn.Name = "DoModifyBtn"
            '
            'DoDeleteBtn
            '
            Me.DoDeleteBtn.Caption = "删除"
            Me.DoDeleteBtn.Id = 3
            Me.DoDeleteBtn.ImageIndex = 3
            Me.DoDeleteBtn.LargeImageIndex = 0
            Me.DoDeleteBtn.Name = "DoDeleteBtn"
            '
            'DoClearBtn
            '
            Me.DoClearBtn.Caption = "清空"
            Me.DoClearBtn.Id = 3
            Me.DoClearBtn.ImageIndex = 4
            Me.DoClearBtn.LargeImageIndex = 0
            Me.DoClearBtn.Name = "DoClearBtn"
            '
            'SpcaceItem
            '
            Me.SpcaceItem.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
            Me.SpcaceItem.Id = 4
            Me.SpcaceItem.Name = "SpcaceItem"
            Me.SpcaceItem.TextAlignment = System.Drawing.StringAlignment.Near
            Me.SpcaceItem.Width = 32
            '
            'DoScanBtn
            '
            Me.DoScanBtn.Caption = "查询"
            Me.DoScanBtn.Id = 3
            Me.DoScanBtn.ImageIndex = 5
            Me.DoScanBtn.LargeImageIndex = 0
            Me.DoScanBtn.Name = "DoScanBtn"
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
            'Fr_BaseForm
            '
            Me.Appearance.BackColor = System.Drawing.Color.White
            Me.Appearance.Options.UseBackColor = True
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1138, 535)
            Me.Controls.Add(Me.barDockControlLeft)
            Me.Controls.Add(Me.barDockControlRight)
            Me.Controls.Add(Me.barDockControlBottom)
            Me.Controls.Add(Me.barDockControlTop)
            Me.DoubleBuffered = True
            Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.Name = "Fr_BaseForm"
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.Text = "首页"
            CType(Me.XtraBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ImageLs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents XtraBar As DevExpress.XtraBars.BarManager
        Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
        Friend WithEvents ImageLs As DevExpress.Utils.ImageCollection
        Friend WithEvents ToolBar As DevExpress.XtraBars.Bar
        Friend WithEvents DoRefreshBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents DoAddBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents DoModifyBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents DoDeleteBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents DoClearBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents DoScanBtn As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents SpcaceItem As DevExpress.XtraBars.BarStaticItem
    End Class

End Namespace
