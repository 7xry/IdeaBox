Imports DevExpress.LookAndFeel
Imports IdeaBox.View

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
            Log.Showlog(ex.ToString, Utils.FileSystem.Enum.MsgType.FatalMsg)
            Return
        End Try
    End Sub
End Class
