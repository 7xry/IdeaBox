Imports System.Runtime.InteropServices

Namespace Utils.Windows
    Public Class SysOpt

        <DllImport("kernel32.dll", ExactSpelling:=True)> _
        Friend Shared Function GetCurrentProcess() As IntPtr
        End Function

        <DllImport("advapi32.dll", ExactSpelling:=True, SetLastError:=True)> _
        Friend Shared Function OpenProcessToken(ByVal h As IntPtr, ByVal acc As Integer, ByRef phtok As IntPtr) As Boolean
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)> _
        Friend Shared Function LookupPrivilegeValue(ByVal host As String, ByVal name As String, ByRef pluid As Long) As Boolean
        End Function

        <DllImport("advapi32.dll", ExactSpelling:=True, SetLastError:=True)> _
        Friend Shared Function AdjustTokenPrivileges(ByVal htok As IntPtr, ByVal disall As Boolean, ByRef newst As TokPriv1Luid, ByVal len As Integer, ByVal prev As IntPtr, ByVal relen As IntPtr) As Boolean
        End Function

        <DllImport("user32.dll", ExactSpelling:=True, SetLastError:=True)> _
        Friend Shared Function ExitWindowsEx(ByVal flg As Integer, ByVal rea As Integer) As Boolean
        End Function

        Friend Const SE_PRIVILEGE_ENABLED As Integer = &H2
        Friend Const TOKEN_QUERY As Integer = &H8
        Friend Const TOKEN_ADJUST_PRIVILEGES As Integer = &H20
        Friend Const SE_SHUTDOWN_NAME As String = "SeShutdownPrivilege"
        Friend Const EWX_LOGOFF As Integer = &H0 '注销计算机
        Friend Const EWX_SHUTDOWN As Integer = &H1 '关闭计算机
        Friend Const EWX_REBOOT As Integer = &H2 '重新启动计算机
        Friend Const EWX_FORCE As Integer = &H4 '关闭所有进程，注销计算机
        Friend Const EWX_POWEROFF As Integer = &H8
        Friend Const EWX_FORCEIFHUNG As Integer = &H10

        <StructLayout(LayoutKind.Sequential, Pack:=1)> _
        Friend Structure TokPriv1Luid
            Public Count As Integer
            Public Luid As Long
            Public Attr As Integer
        End Structure

        Private Shared Sub DoExitWin(ByVal flg As Integer)
            Dim xc As Boolean  '判断语句
            Dim tp As TokPriv1Luid
            Dim hproc As IntPtr = GetCurrentProcess() '调用进程值
            Dim htok As IntPtr = IntPtr.Zero
            xc = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, htok)
            tp.Count = 1
            tp.Luid = 0
            tp.Attr = SE_PRIVILEGE_ENABLED
            xc = LookupPrivilegeValue(Nothing, SE_SHUTDOWN_NAME, tp.Luid)
            xc = AdjustTokenPrivileges(htok, False, tp, 0, IntPtr.Zero, IntPtr.Zero)
            xc = ExitWindowsEx(flg, 0)
        End Sub

        Public Shared Sub Reboot()
            DoExitWin((EWX_FORCE Or EWX_REBOOT)) '重新启动计算机
        End Sub

        Public Shared Sub PowerOff()
            DoExitWin((EWX_FORCE Or EWX_POWEROFF)) '关闭计算机
        End Sub

        Public Shared Sub LogoOff()
            DoExitWin((EWX_FORCE Or EWX_LOGOFF)) '注销计算机
        End Sub
        Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwngnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer

    End Class
End Namespace