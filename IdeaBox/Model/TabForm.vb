Imports DevExpress.XtraTab
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports IdeaBox.Dict

Namespace Model
    Public Class TabForm
        Property TabCtrl As XtraTabControl
        Property TabMod As TabModEnum
        Property TabDll As String
        Property DllFromName As String
        Property TabFr As XtraForm
        Property PageName As String
        Property ImageIndex As Integer
        Property TabVisiable As Boolean
        Property ShowCloseButton As DefaultBoolean

        Sub New()

        End Sub

        Sub New(ByVal xTabCtrl As XtraTabControl)
            TabCtrl = xTabCtrl
        End Sub

        Sub New(ByVal xTabCtrl As XtraTabControl, ByVal xPageName As String)
            TabCtrl = xTabCtrl
            PageName = xPageName
        End Sub

        Sub New(ByVal xTabCtrl As XtraTabControl, ByVal xTabMod As TabModEnum, ByVal xTabFr As XtraForm, ByVal xPageName As String, ByVal xImageIndex As Integer, ByVal xTabVisiable As Boolean, ByVal xShowCloseButton As Boolean)
            TabCtrl = xTabCtrl
            TabMod = xTabMod
            TabFr = xTabFr
            PageName = xPageName
            ImageIndex = xImageIndex
            TabVisiable = xTabVisiable
            ShowCloseButton = xShowCloseButton
        End Sub


        Sub New(ByVal xTabCtrl As XtraTabControl, ByVal xTabMod As TabModEnum, ByVal xTabDll As String, ByVal xDllFromName As String, ByVal xPageName As String, ByVal xImageIndex As Integer, ByVal xTabVisiable As Boolean, ByVal xShowCloseButton As Boolean)
            TabCtrl = xTabCtrl
            TabMod = xTabMod
            TabDll = xTabDll
            DllFromName = xDllFromName
            PageName = xPageName
            ImageIndex = xImageIndex
            TabVisiable = xTabVisiable
            ShowCloseButton = xShowCloseButton
        End Sub
    End Class
End Namespace
