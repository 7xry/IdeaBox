Imports IdeaBox.StoryManage.Impl
Imports IdeaBox.StoryManage.View
Imports IdeaBox.Model
Imports IdeaBox.View
Imports IdeaBox.Utils.FileSystem.Files
Imports DevExpress.LookAndFeel

Module IdeaBoxMod
    '操作类实例
    Public StoryOpt As New StoryImpl
    Public FileDownOpt As New FileDownImpl
    Public StoryImplOpt As AqTxtImpl
    '窗体实例
    Public frMain As Fr_MainForm
    Public frStory As Fr_Aqtxt
    '全局参数
    Public Property skinMask As String
    Public Property DefaultExportPath As String
    Public Property DefaultImportPath As String
    Public perPage As Integer = 20


    Public Sub LoadConfig()
        XmlDoc.ConfStr = Application.StartupPath & "\Config\Global.xml"
        skinMask = XmlDoc.GetValue("skinMask", "Value")
        DefaultExportPath = XmlDoc.GetValue("DefaultExportPath", "Value")
        DefaultImportPath = XmlDoc.GetValue("DefaultImportPath", "Value")
    End Sub

    Public Sub SaveConfig()
        XmlDoc.ConfStr = Application.StartupPath & "\Config\Global.xml"
        skinMask = UserLookAndFeel.Default.SkinName
        XmlDoc.SaveValue("skinMask", "Value", skinMask)
    End Sub

End Module
