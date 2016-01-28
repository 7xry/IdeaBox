Imports System.Management

Namespace Utils.Windows
    Public Class NetWork
        '****************************************************************************
        '   获取本机IP地址
        '****************************************************************************
        Public Shared Function GetIPAddr() As String
            GetIPAddr = String.Empty
            Dim Wmi As New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration")
            For Each WmiObj As ManagementObject In Wmi.Get
                If CBool(WmiObj("IPEnabled")) Then
                    GetIPAddr = WmiObj("IPAddress")(0)
                End If
            Next
            Return GetIPAddr
        End Function

        Public Shared Function GetMacAddr() As String
            GetMacAddr = String.Empty
            Dim Wmi As New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration")
            For Each WmiObj As ManagementObject In Wmi.Get
                If CBool(WmiObj("IPEnabled")) Then
                    GetMacAddr = WmiObj("MacAddress")
                End If
            Next
            Return GetMacAddr
        End Function
    End Class
End Namespace