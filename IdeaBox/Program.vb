Imports DevExpress.LookAndFeel
Imports IdeaBox.View
Imports IdeaBox.Utils.FileSystem.Dict

Friend NotInheritable Class Program
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    Private Sub New()
    End Sub
    <STAThread()>
    Shared Sub Main()
        Try
            DevExpress.Skins.SkinManager.EnableFormSkins()
            DevExpress.UserSkins.BonusSkins.Register()
            LoadConfig()            '
            If skinMask <> String.Empty Then
                UserLookAndFeel.Default.SetSkinStyle(skinMask)
            Else
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")
            End If
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            frMain = New Fr_MainForm
            Application.Run(frMain)
        Catch ex As Exception
            Log.Showlog(ex.ToString, MsgType.FatalMsg)
            Return
        End Try
    End Sub
End Class
