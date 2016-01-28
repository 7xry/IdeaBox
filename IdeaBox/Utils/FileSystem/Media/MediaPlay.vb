Imports System.Runtime.InteropServices

Namespace Utils.FileSystem.Media
    Public Class MediaPlay
        '/// KSG Comments: This code has only been tested for .NET 2.x
        Public Class Interop
            <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
            Public Shared Function GetShortPathName(ByVal longPath As String, _
          <MarshalAs(UnmanagedType.LPTStr)> ByVal ShortPath As System.Text.StringBuilder, _
          <MarshalAs(Runtime.InteropServices.UnmanagedType.U4)> ByVal bufferSize As Integer) As Integer
            End Function
        End Class
        'OR
        Declare Unicode Function GetShortPathName Lib "kernel32.dll" Alias "GetShortPathNameW" (ByVal longPath As String, <MarshalAs(UnmanagedType.LPTStr)> ByVal ShortPath As System.Text.StringBuilder, <MarshalAs(UnmanagedType.U4)> ByVal bufferSize As Integer) As Integer

        Function ShortPathName(ByVal Path As String) As String
            Dim sb As New System.Text.StringBuilder(1024)
            Dim tempVal As Integer = Interop.GetShortPathName(Path, sb, 1024)
            If tempVal <> 0 Then
                Dim Result As String = sb.ToString()
                Return Result
            Else
                Throw New Exception("Failed to return a short path")
            End If
        End Function


        ' 宣告 API    
        Private Declare Function mciSendStringA Lib "winmm.dll" _
            (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, _
             ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

        Public Function PlayMidiFile(ByVal MusicFile As String) As Boolean
            mciSendStringA("stop music", "", 0, 0)
            mciSendStringA("close music", "", 0, 0)
            mciSendStringA(String.Format("open {0}{1}{0} alias music", Chr(34), MusicFile), "", 0, 0)
            PlayMidiFile = mciSendStringA("play music", "", 0, 0) = 0
        End Function

    End Class
End Namespace