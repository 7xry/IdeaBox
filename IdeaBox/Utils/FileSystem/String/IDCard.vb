Namespace Utils.FileSystem.String

    Public Class IDCard

        '位权值数组
        Dim Weight As Byte() = New Byte(16) {}
        '身份证行政区划代码部分长度
        Const fPart As Byte = 6
        '算法求模关键参数
        Const fMode As Byte = 11
        '旧身份证长度
        Const oIdLen As Byte = 15
        '新身份证长度
        Const nIdLen As Byte = 18
        '新身份证年份标记值
        Const yearFlag As String = "19"
        '校验字符串
        Const checkCode As String = "10X98765432"
        '最小行政区划分代码
        'Dim minCode As Integer = 110000
        '最大行政区划分代码
        'Dim maxCode As Integer = 820000
        'Dim rand As New Random

        '   <summary>
        '       计算位权值数组
        '   </summary>
        Private Sub SetWBuffer()
            For i As Integer = 0 To Weight.Length - 1
                Dim k As Integer = CInt(Math.Pow(2, (Weight.Length - i)))
                Weight(i) = CByte(k Mod fMode)
            Next
        End Sub

        '   <summary>
        '       获取新身份证最后一位校验位
        '   </summary>
        '   <param name="idCard">身份证号码</param>
        '   <returns></returns>
        Private Function GetCheckCode(ByVal idCard As String) As String
            Dim sum As Integer = 0
            '进行加权求和计算
            For i As Integer = 0 To Weight.Length - 1
                sum += Integer.Parse(idCard.Substring(i, 1)) * Weight(i)
            Next
            '求模运算得到模值
            Dim mode As Byte = CByte(sum Mod fMode)
            Return checkCode.Substring(mode, 1)
        End Function

        '   <summary>
        '       检查身份证长度是否合法
        '   </summary>
        '   <param name="idCard">身份证号码</param>
        '   <returns></returns>
        Private Function CheckLen(ByVal idCard As String) As Boolean
            If idCard.Length = oIdLen OrElse idCard.Length = nIdLen Then
                Return True
            End If
            Return False
        End Function

        '   <summary>
        '       验证是否是新身份证
        '   </summary>
        '   <param name="idCard">身份证号码</param>
        '   <returns></returns>
        Private Function IsNew(ByVal idCard As String) As Boolean
            If idCard.Length = nIdLen Then
                Return True
            End If
            Return False
        End Function

        '   <summary>
        '       获取时间串
        '   </summary>
        '   <param name="idCard">身份证号码</param>
        '   <returns></returns>
        Private Function GetDate(ByVal idCard As String) As String
            Dim str As String = ""
            If IsNew(idCard) Then
                str = idCard.Substring(fPart, 8)
            Else
                str = yearFlag & idCard.Substring(fPart, 6)
            End If
            Return str
        End Function

        '   <summary>
        '       检查时间是否合法
        '   </summary>
        '   <param name="idCard">身份证号码</param>
        '   <returns></returns>
        Private Function CheckDate(ByVal idCard As String) As Boolean
            '日期是否符合格式
            Dim flag As Boolean = False
            Dim strDate As String = GetDate(idCard)

            Dim year As Integer = Convert.ToInt32(strDate.Substring(0, 4))
            Dim month As Integer = Convert.ToInt32(strDate.Substring(4, 2))
            Dim day As Integer = Convert.ToInt32(strDate.Substring(6, 2))

            '年份是否合法，本例暂定年份在1900-1999之间为合法年份
            If (year > 1900) AndAlso (year < 2999) Then
                flag = True
            Else
                flag = False
            End If

            '检查月份是否合法
            If (month >= 1) AndAlso (month <= 12) Then
                flag = True
            Else
                flag = False
            End If

            '检查天是否合法，本例以农历为准
            If (day >= 1) AndAlso (day <= 30) Then
                flag = True
            Else
                flag = False
            End If
            Return flag
        End Function

        '   <summary>
        '       根据年份和月份检查天是否合法
        '   </summary>
        '   <param name="year">年份</param>
        '   <param name="month">月份</param>
        '   <param name="day">天</param>
        '   <returns></returns>
        Private Function CheckDay(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer) As Boolean
            '是否是闰年
            Dim rYearFlag As Boolean = False
            '天是否合法
            Dim rDayFlag As Boolean = False
            If ((year Mod 4 = 0) AndAlso (year Mod 3200 <> 0)) OrElse (year Mod 400 = 0) Then
                rYearFlag = True
            End If

            '检查天是否合法
            If month = 2 Then
                If rYearFlag Then
                    If day > 0 AndAlso day <= 29 Then
                        rDayFlag = True
                    End If
                Else
                    If day > 0 AndAlso day <= 28 Then
                        rDayFlag = True
                    End If
                End If
            ElseIf month = 1 OrElse month = 3 OrElse month = 5 OrElse month = 7 OrElse month = 8 OrElse month = 10 OrElse month = 12 Then
                If day > 0 AndAlso day <= 31 Then
                    rDayFlag = True
                End If
            Else
                If day > 0 AndAlso day <= 30 Then
                    rDayFlag = True
                End If
            End If
            Return rDayFlag
        End Function

        '   <summary>
        '       检查身份证是否合法
        '   </summary>
        '   <param name="idCard">身份证号</param>
        '   <returns></returns>
        Public Function CheckCard(ByVal idCard As String, ByRef msg As String) As Boolean
            '身份证是否合法标志
            Dim flag As Boolean = False
            msg = String.Empty
            SetWBuffer()
            If Not CheckLen(idCard) Then
                msg = "身份证长度不符合要求"
                flag = False
            Else
                If Not CheckDate(idCard) Then
                    msg = "身份证日期不符合要求"
                    flag = False
                Else
                    If Not IsNew(idCard) Then
                        idCard = GetNewIdCard(idCard)
                    End If
                    Dim XcheckCode As String = GetCheckCode(idCard)
                    Dim lastCode As String = idCard.Substring(idCard.Length - 1, 1)
                    If XcheckCode = lastCode Then
                        flag = True
                    Else
                        msg = "身份证验证错误"
                        flag = False
                    End If
                End If
            End If
            Return flag
        End Function

        '   <summary>
        '       旧身份证号码转换成新身份证号码
        '   </summary>
        '   <param name="newIdCard">旧身份证号码</param>
        '   <returns>新身份证号码</returns>
        Private Function GetNewIdCard(ByVal oldIdCard As String) As String
            If oldIdCard.Length = 15 Then
                Dim newIdCard As String = oldIdCard.Substring(0, fPart)
                newIdCard += yearFlag
                newIdCard += oldIdCard.Substring(fPart, 9)
                newIdCard += GetCheckCode(newIdCard)
                Return newIdCard
            End If
            Return String.Empty
        End Function

        '   <summary>
        '       新身份证号码转换成旧身份证号码
        '   </summary>
        '   <param name="newIdCard">新身份证号码</param>
        '   <returns>旧身份证号码</returns>
        Private Function GetOldIdCard(ByVal newIdCard As String) As String
            If newIdCard.Length = 18 Then
                Dim oldIdCard As String = newIdCard.Substring(0, fPart)
                oldIdCard += newIdCard.Substring(8, 9)
                Return oldIdCard
            End If
            Return String.Empty
        End Function
    End Class
End Namespace