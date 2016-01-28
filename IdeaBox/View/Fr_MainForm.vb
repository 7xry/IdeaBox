Imports DevExpress.XtraEditors
Imports System.IO
Imports IdeaBox.Impl
Imports DevExpress.XtraNavBar
Imports DevExpress.Utils
Imports IdeaBox.Utils.FileSystem.Files
Imports DevExpress.LookAndFeel
Imports IdeaBox.SignManage.View
Imports IdeaBox.StoryManage.View
Imports IdeaBox.Dict
Imports IdeaBox.Model

Namespace View
    Partial Public Class Fr_MainForm
        Private CurrentPage As DevExpress.XtraTab.XtraTabPage = Nothing

        Public Sub New()
            InitializeComponent()
            Me.Text = String.Format("{0}", My.Application.Info.Title)
            FormImpl.RemoveAllPage(New TabForm(MainTab))
            SayHello()
            ShowTime()
        End Sub

        Sub ShowTime()
            TimeLbl.Caption = String.Format("当前时间： {0}", DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒"))
            Me.Text = String.Format("{0}", My.Application.Info.Title)
        End Sub

        Sub SayHello()
            WelComeLbl.Caption = String.Format("您好！ 欢迎使用 {0} ", My.Application.Info.Title)
        End Sub

        Private Sub Tm_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Tm.Tick
            ShowTime()
        End Sub

        Private Sub MainTab_HotTrackedPageChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles MainTab.HotTrackedPageChanged
            Try
                CurrentPage = e.Page
            Catch ex As Exception
                CurrentPage = Nothing
            End Try
        End Sub

        Private Sub MainTab_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles MainTab.DoubleClick
            If CurrentPage IsNot Nothing Then
                FormImpl.RemovePage(New TabForm(MainTab, CurrentPage.Text))
            End If
        End Sub

        Private Sub MainTab_CloseButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles MainTab.CloseButtonClick
            FormImpl.RemovePage(New TabForm(MainTab))
        End Sub

        Private Sub ExitSystemBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitSystemBtn.Click
            If XtraMessageBox.Show("是否退出系统？", "退出？", MessageBoxButtons.YesNo, MessageBoxIcon.Question, DevExpress.Utils.DefaultBoolean.True) = DialogResult.No Then
                Return
            End If
            SaveConfig()
            Application.Exit()
        End Sub

        Private Sub Btn_LinkClicked(ByVal sender As Object, ByVal e As NavBarLinkEventArgs) Handles StoryManageBtn.LinkClicked, UserManagerBtn.LinkClicked
            Select Case CType(sender, NavBarItem).Name
                Case "StoryManageBtn"
                    frStory = New Fr_Aqtxt("DS_TB_AQTXT")
                    FormImpl.LoadTabPageForm(New TabForm(MainTab, TabModEnum.窗体, frStory, "爱奇小说网", 1, True, DefaultBoolean.True))
                Case "UserManagerBtn"
                    'frUser = New Fr_User()
                    'FormImpl.LoadTabPageForm(New TabForm(MainTab, TabModEnum.窗体, frUser, "员工管理", 2, True, DefaultBoolean.True))
            End Select

        End Sub

        Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
            SaveConfig()
            Application.Exit()
        End Sub


        'Private Sub DoRegKeyBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DoRegKeyBtn.Click
        '    Dim fr As New Fr_Reg
        '    fr.ShowDialog()
        'End Sub

        Private Sub ManualBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ManualBtn.Click
            Dim manualPath As String = String.Format("{0}\Manual\进出件管理系统使用手册.pdf", Application.StartupPath)
            If File.Exists(manualPath) = False Then
                Log.Showlog("帮助手册不存在！", Utils.FileSystem.Enum.MsgType.InfoMsg)
                Return
            End If
            Try
                Dim p As New Process
                p.StartInfo.FileName = manualPath
                p.Start()
            Catch ex As Exception
                Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.InfoMsg)
            End Try
        End Sub


    End Class

End Namespace
