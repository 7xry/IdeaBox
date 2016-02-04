Imports DevExpress.XtraTab
Imports DevExpress.XtraEditors
Imports System.Reflection
Imports IdeaBox.Dict
Imports IdeaBox.Model

Namespace Impl
    Public Class FormImpl
        Public Shared Function GetSelectPage(ByVal tab As TabForm) As XtraTabPage
            Dim selectedPage As XtraTabPage = Nothing
            For Each page As XtraTabPage In tab.TabCtrl.TabPages
                If page.Tag IsNot Nothing AndAlso page.Tag.ToString() = tab.PageName Then
                    Dim dlg As XtraForm = CType(page.Controls(0), XtraForm)
                    'dlg.Tag = VaildKey
                    dlg.Text = tab.PageName
                    selectedPage = page
                End If
            Next
            Return selectedPage
        End Function
        ''' <summary>
        ''' 加载或者激活指定类型的对话框
        ''' </summary>
        ''' <param name="tab">TabForm对象</param>
        Public Overloads Shared Sub LoadTabPageForm(ByVal tab As TabForm)
            'VaildKey = CL_Config.VaildKey
            Dim selectedPage As XtraTabPage = GetSelectPage(tab)
            If selectedPage Is Nothing Then
                Dim dlg As New XtraForm
                Select Case tab.TabMod
                    Case TabModEnum.文件
                        dlg = CType(Assembly.LoadFile(String.Format("{0}\{1}", Application.StartupPath, tab.TabDll)).CreateInstance(tab.DllFromName), XtraForm)
                    Case TabModEnum.窗体
                        dlg = tab.TabFr
                    Case Else
                        Return
                End Select
                dlg.Text = tab.PageName
                dlg.Dock = DockStyle.Fill
                dlg.FormBorderStyle = FormBorderStyle.None
                dlg.Visible = True
                dlg.TopLevel = False
                '在这里一定要注意 
                'dlg.InitFunction(LoginUserInfo, FunctionDict)
                '给子窗体赋值用户权限信息
                'dlg.Tag = VaildKey
                selectedPage = New XtraTabPage
                selectedPage.Text = tab.PageName
                selectedPage.Image = tab.PageImage
                selectedPage.Tag = tab.PageName
                selectedPage.ShowCloseButton = tab.ShowCloseButton
                selectedPage.PageVisible = tab.TabVisiable
                selectedPage.Controls.Add(dlg)
                tab.TabCtrl.TabPages.Add(selectedPage)
            End If
            selectedPage.BringToFront()
            tab.TabCtrl.SelectedTabPage = selectedPage
        End Sub

        Public Overloads Shared Sub RemovePage(ByVal tab As TabForm)
            If tab.PageName <> String.Empty Then
                Dim selectPage As XtraTabPage = GetSelectPage(tab)
                If selectPage IsNot Nothing Then
                    If selectPage.Controls.Count > 0 Then
                        CType(selectPage.Controls(0), XtraForm).Close()
                    End If
                    tab.TabCtrl.TabPages.Remove(selectPage)
                End If
            Else
                If tab.TabCtrl.SelectedTabPage.Controls.Count > 0 Then
                    CType(tab.TabCtrl.SelectedTabPage.Controls(0), XtraForm).Close()
                End If
                tab.TabCtrl.TabPages.Remove(tab.TabCtrl.SelectedTabPage)
            End If
        End Sub


        Public Overloads Shared Sub RemoveAllPage(ByVal tab As TabForm)
            If Nothing IsNot tab And Nothing IsNot tab.TabCtrl Then
                tab.TabCtrl.TabPages.Clear()
            End If
        End Sub
    End Class

End Namespace
