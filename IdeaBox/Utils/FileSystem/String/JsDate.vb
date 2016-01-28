Namespace Utils.FileSystem.String
    Public Class JsDate
        Overloads Shared Function getTimeInMillis() As Long
            Return Decimal.ToInt64(Decimal.Divide(DateTime.Now.Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
        End Function

        Overloads Shared Function getTimeInMillis(ByVal AfterSet As Int16) As Long
            Return Decimal.ToInt64(Decimal.Divide(DateTime.Now.AddSeconds(AfterSet).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
        End Function

        Overloads Shared Function getTimeInMillis(ByVal AfterSet As Int16, ByVal AfterType As Int16) As Long
            Select Case AfterType
                Case 0
                    Return Decimal.ToInt64(Decimal.Divide(DateTime.Now.AddSeconds(AfterSet).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
                Case 1
                    Return Decimal.ToInt64(Decimal.Divide(DateTime.Now.AddMinutes(AfterSet).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
                Case 2
                    Return Decimal.ToInt64(Decimal.Divide(DateTime.Now.AddHours(AfterSet).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
                Case 3
                    Return Decimal.ToInt64(Decimal.Divide(DateTime.Now.AddDays(AfterSet).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
                Case 4
                    Return Decimal.ToInt64(Decimal.Divide(DateTime.Now.AddMonths(AfterSet).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
                Case Else
                    Return Decimal.ToInt64(Decimal.Divide(DateTime.Now.AddYears(AfterSet).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
            End Select
        End Function

        Overloads Shared Function getTimeInMillis(ByVal dTime As Date) As Long
            Return Decimal.ToInt64(Decimal.Divide(dTime.Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
        End Function

        Overloads Shared Function getTimeInMillis(ByVal year As Integer) As Long
            Return Decimal.ToInt64(Decimal.Divide(New Date(year, 1, 1).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
        End Function

        Overloads Shared Function getTimeInMillis(ByVal year As Integer, ByVal month As Integer) As Long
            Return Decimal.ToInt64(Decimal.Divide(New Date(year, month, 1).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
        End Function

        Overloads Shared Function getTimeInMillis(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer) As Long
            Return Decimal.ToInt64(Decimal.Divide(New Date(year, month, day).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
        End Function

        Overloads Shared Function getTimeInMillis(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal hour As Integer) As Long
            Return Decimal.ToInt64(Decimal.Divide(New Date(year, month, day, hour, 0, 0).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
        End Function

        Overloads Shared Function getTimeInMillis(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal hour As Integer, ByVal minute As Integer) As Long
            Return Decimal.ToInt64(Decimal.Divide(New Date(year, month, day, hour, minute, 0).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
        End Function

        Overloads Shared Function getTimeInMillis(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal hour As Integer, ByVal minute As Integer, ByVal second As Integer) As Long
            Return Decimal.ToInt64(Decimal.Divide(New Date(year, month, day, hour, minute, second).Ticks - New DateTime(1970, 1, 1, 8, 0, 0).Ticks, 10000))
        End Function

        Overloads Shared Function getDateFromTimeInMillis(ByVal TimeInMillis As Long) As Date
            Return DateTime.FromBinary(Long.Parse(Decimal.Multiply(TimeInMillis, 10000) + New DateTime(1970, 1, 1, 8, 0, 0).Ticks))
        End Function

        Overloads Shared Function getDateFromTimeInMillis(ByVal TimeInMillis As String) As Date
            Try
                Return DateTime.FromBinary(Long.Parse(Decimal.Multiply(TimeInMillis, 10000) + New DateTime(1970, 1, 1, 8, 0, 0).Ticks))
            Catch ex As Exception
                Return New DateTime(1970, 1, 1, 8, 0, 0)
            End Try
        End Function

        Overloads Shared Function getDateStringFromTimeInMillis(ByVal TimeInMillis As Long, ByVal StringFormat As String) As String
            Try
                Return DateTime.FromBinary(Long.Parse(Decimal.Multiply(TimeInMillis, 10000) + New DateTime(1970, 1, 1, 8, 0, 0).Ticks)).ToString(StringFormat)
            Catch ex As Exception
                Return New DateTime(1970, 1, 1, 8, 0, 0).ToString("yyyy-MM-dd HH:mm:ss")
            End Try
        End Function

        Shared Function getNowDateTimeExStr() As String
            Return String.Format("{0:yyyyMMdd_HHmmss_ffffff}", Now)
        End Function

        Shared Function getNowDateTimeStr() As String
            Return String.Format("{0:yyyyMMdd_HHmmss}", Now)
        End Function

        Shared Function getNowDateStr() As String
            Return String.Format("{0:yyyyMMdd}", Now)
        End Function

        Shared Function getNowTimeStr() As String
            Return String.Format("{0:HHmmss}", Now)
        End Function

        Shared Function getNowStr(ByVal StringFormat As String) As String
            Dim NowStr As String = String.Empty
            Try
                NowStr = Now.ToString(StringFormat)
            Catch ex As Exception
                NowStr = String.Format("{0:yyyy-MM-dd HH:mm:ss}", Now)
            End Try
            Return NowStr
        End Function
    End Class
End Namespace
