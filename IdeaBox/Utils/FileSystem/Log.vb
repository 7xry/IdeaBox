Imports log4net
Imports IdeaBox.Utils.FileSystem.Path
Imports IdeaBox.Utils.FileSystem.String
Imports IdeaBox.Utils.FileSystem.Dict


Namespace Utils.FileSystem
    Public Class Log
        Private Shared loginfo As ILog = LogManager.GetLogger(My.Application.Info.Title)

        Public Shared Sub Showlog(ByVal Msg As String, ByVal mType As MsgType)
            Select Case mType
                Case MsgType.DebugMsg
                    MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Log.WriteLog(Msg, MsgType.DebugMsg)
                Case MsgType.ErrorMsg
                    MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Log.WriteLog(Msg, MsgType.ErrorMsg)
                Case MsgType.FatalMsg
                    MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Log.WriteLog(Msg, MsgType.FatalMsg)
                Case MsgType.InfoMsg
                    MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Log.WriteLog(Msg, MsgType.InfoMsg)
                Case MsgType.WarnMsg
                    MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Log.WriteLog(Msg, MsgType.WarnMsg)
            End Select
        End Sub

        Public Shared Sub Showlog(ByVal Msg As String, ByVal mType As MsgType, ByVal showDialog As Boolean)
            Select Case showDialog
                Case True
                    Select Case mType
                        Case MsgType.DebugMsg
                            MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Log.WriteLog(Msg, MsgType.DebugMsg)
                        Case MsgType.ErrorMsg
                            MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Log.WriteLog(Msg, MsgType.ErrorMsg)
                        Case MsgType.FatalMsg
                            MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Log.WriteLog(Msg, MsgType.FatalMsg)
                        Case MsgType.InfoMsg
                            MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Log.WriteLog(Msg, MsgType.InfoMsg)
                        Case MsgType.WarnMsg
                            MessageBox.Show(Msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Log.WriteLog(Msg, MsgType.WarnMsg)
                    End Select
                Case Else
                    Select Case mType
                        Case MsgType.DebugMsg
                            Log.WriteLog(Msg, MsgType.DebugMsg)
                        Case MsgType.ErrorMsg
                            Log.WriteLog(Msg, MsgType.ErrorMsg)
                        Case MsgType.FatalMsg
                            Log.WriteLog(Msg, MsgType.FatalMsg)
                        Case MsgType.InfoMsg
                            Log.WriteLog(Msg, MsgType.InfoMsg)
                        Case MsgType.WarnMsg
                            Log.WriteLog(Msg, MsgType.WarnMsg)
                    End Select
            End Select
        End Sub

        Private Shared Sub SetConfig()
            Dim appender As New log4net.Appender.RollingFileAppender()
            appender.File = String.Format("{0}\Log\{1}\", AppPath.GetRunPath, JsDate.getNowStr("yyyy-MM-dd"))
            appender.AppendToFile = True
            appender.MaxSizeRollBackups = -1
            appender.MaximumFileSize = "1MB"
            appender.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Date
            appender.DatePattern = "yyyy-MM-dd"".log \ """
            appender.StaticLogFileName = False
            appender.LockingModel = New log4net.Appender.FileAppender.MinimalLock()
            'appender.Layout = New log4net.Layout.PatternLayout("%date [%thread] %-5level - %message%newline")
            appender.Layout = New log4net.Layout.PatternLayout("%n[时间]：%d%n[类型]：%level%n[线程]：%t%n[信息]：%m%n")
            appender.ActivateOptions()
            log4net.Config.BasicConfigurator.Configure(appender)
        End Sub

        Private Shared IsLoadConfig As Boolean = False
        ''' <summary>
        ''' 记录日志
        ''' </summary>
        ''' <param name="msg">日志内容</param>
        ''' <remarks>记录日志</remarks>
        Public Shared Sub WriteLog(ByVal msg As String)
            If Not IsLoadConfig Then
                SetConfig()
                IsLoadConfig = True
            End If
            If loginfo.IsInfoEnabled Then
                loginfo.Info(msg)
            End If
        End Sub

        ''' <summary>
        ''' 记录日志
        ''' </summary>
        ''' <param name="msg">日志内容</param>
        ''' <param name="ex">异常</param>
        ''' <remarks>记录日志</remarks>
        Public Shared Sub WriteLog(ByVal msg As String, ByVal ex As Exception)
            If Not IsLoadConfig Then
                SetConfig()
                IsLoadConfig = True
            End If
            If loginfo.IsErrorEnabled Then
                loginfo.Error(msg, ex)
            End If
        End Sub

        ''' <summary>
        ''' 记录日志
        ''' </summary>
        ''' <param name="msg">日志内容</param>
        ''' <param name="msgType">日志类型</param>
        ''' <remarks>记录日志</remarks>
        Public Shared Sub WriteLog(ByVal msg As String, ByVal msgType As MsgType)
            If Not IsLoadConfig Then
                SetConfig()
                IsLoadConfig = True
            End If
            Select Case msgType
                Case msgType.DebugMsg
                    If loginfo.IsDebugEnabled Then
                        loginfo.Debug(msg)
                    End If
                Case msgType.InfoMsg
                    If loginfo.IsInfoEnabled Then
                        loginfo.Info(msg)
                    End If
                Case msgType.ErrorMsg
                    If loginfo.IsErrorEnabled Then
                        loginfo.Error(msg)
                    End If
                Case msgType.FatalMsg
                    If loginfo.IsFatalEnabled Then
                        loginfo.Fatal(msg)
                    End If
                Case msgType.WarnMsg
                    If loginfo.IsWarnEnabled Then
                        loginfo.Warn(msg)
                    End If
                Case Else
                    If loginfo.IsInfoEnabled Then
                        loginfo.Info(msg)
                    End If
            End Select
        End Sub

        ''' <summary>
        ''' 记录日志
        ''' </summary>
        ''' <param name="msg">日志内容</param>
        ''' <param name="msgType">信息类型</param>
        ''' <param name="ex">异常</param>
        ''' <remarks>记录日志</remarks>
        Public Shared Sub WriteLog(ByVal msg As String, ByVal msgType As MsgType, ByVal ex As Exception)
            If Not IsLoadConfig Then
                SetConfig()
                IsLoadConfig = True
            End If
            Select Case msgType
                Case msgType.DebugMsg
                    If loginfo.IsDebugEnabled Then
                        If ex IsNot Nothing Then
                            loginfo.Debug(msg, ex)
                        Else
                            loginfo.Debug(msg)
                        End If
                    End If
                Case msgType.InfoMsg
                    If loginfo.IsInfoEnabled Then
                        If ex IsNot Nothing Then
                            loginfo.Info(msg, ex)
                        Else
                            loginfo.Info(msg)
                        End If
                    End If
                Case msgType.ErrorMsg
                    If loginfo.IsErrorEnabled Then
                        If ex IsNot Nothing Then
                            loginfo.Error(msg, ex)
                        Else
                            loginfo.Error(msg)
                        End If
                    End If
                Case msgType.FatalMsg
                    If loginfo.IsFatalEnabled Then
                        If ex IsNot Nothing Then
                            loginfo.Fatal(msg, ex)
                        Else
                            loginfo.Fatal(msg)
                        End If
                    End If
                Case msgType.WarnMsg
                    If loginfo.IsWarnEnabled Then
                        If ex IsNot Nothing Then
                            loginfo.Warn(msg, ex)
                        Else
                            loginfo.Warn(msg)
                        End If
                    End If
                Case Else
                    If loginfo.IsInfoEnabled Then
                        If ex IsNot Nothing Then
                            loginfo.Info(msg, ex)
                        Else
                            loginfo.Info(msg)
                        End If
                    End If
            End Select
        End Sub
    End Class
End Namespace