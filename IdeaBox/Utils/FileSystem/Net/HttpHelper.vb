Imports HtmlAgilityPack
Imports System.Net
Imports System.Text

Namespace Utils.FileSystem.Net
    Public Class HttpHelper
        ''' <summary>
        ''' 打开网址，获取HTML节点
        ''' </summary>
        ''' <param name="URL">网址</param>
        ''' <param name="Encode">编码</param>
        ''' <returns>HTML节点</returns>
        ''' <remarks>打开网址，获取HTML节点</remarks>
        Public Shared Function OpenUrl(ByVal URL As String, ByVal Encode As Encoding) As HtmlNode
            Dim wc As New WebClient '这个htmlweb是HtmlAgilityPack中的一个对象
            wc.Encoding = Encode
            Dim doc As New HtmlDocument  '这个HTMLDocument也是HtmlAgilityPack中的对象,而不是平时使用的System.Windows.Forms.HtmlDocument
            Dim htmlStr As String = wc.DownloadString(URL)
            doc.LoadHtml(htmlStr)
            Return doc.DocumentNode()
        End Function

        ''' <summary>
        ''' 打开网址，获取HTML节点
        ''' </summary>
        ''' <param name="URL">网址</param>
        ''' <returns>HTML节点</returns>
        ''' <remarks>打开网址，获取HTML节点</remarks>
        Public Shared Function OpenUrl(ByVal URL As String) As HtmlNode
            Dim wc As New WebClient '这个htmlweb是HtmlAgilityPack中的一个对象
            wc.Encoding = Encoding.Default
            Dim doc As New HtmlDocument  '这个HTMLDocument也是HtmlAgilityPack中的对象,而不是平时使用的System.Windows.Forms.HtmlDocument
            Dim htmlStr As String = wc.DownloadString(URL)
            doc.LoadHtml(htmlStr)
            Return doc.DocumentNode()
        End Function

        ''' <summary>
        ''' 获取节点文本
        ''' </summary>
        ''' <param name="Node">节点</param>
        ''' <param name="xpathStr">XPath</param>
        ''' <param name="NodeType">节点类型</param>
        ''' <returns>节点文本</returns>
        ''' <remarks>获取节点文本</remarks>
        Public Shared Function GetNodeStr(ByVal Node As HtmlNode, ByVal xpathStr As String, Optional ByVal NodeType As Integer = 0) As String
            Dim nodeCollect As HtmlNodeCollection = Node.SelectNodes(xpathStr)
            If nodeCollect Is Nothing Then
                Return String.Empty
            End If
            Dim RtStr As String = String.Empty
            Try
                Select Case NodeType
                    Case 0  '返回InnerText
                        RtStr = nodeCollect(0).InnerText.Trim.ToString
                    Case 1  '返回href Text
                        RtStr = nodeCollect(0).GetAttributeValue("href", "").Trim.ToString()
                    Case 2  '返回src Text
                        RtStr = nodeCollect(0).GetAttributeValue("src", "").Trim.ToString()
                    Case 3  '返回src Text
                        RtStr = nodeCollect(0).InnerHtml.Trim.ToString()
                    Case Else
                        RtStr = nodeCollect(0).InnerText.Trim.ToString
                End Select
            Catch ex As Exception
                Log.Showlog(ex.ToString, Dict.MsgType.ErrorMsg, False)
                RtStr = String.Empty
            End Try
            Return RtStr
        End Function

        Public Shared Function GetNodeStr(ByVal Node As HtmlNode, Optional ByVal NodeType As Integer = 0) As String
            Dim RtStr As String = String.Empty
            Try
                Select Case NodeType
                    Case 0  '返回InnerText
                        RtStr = Node.InnerText.Trim.ToString
                    Case 1  '返回href Text
                        RtStr = Node.GetAttributeValue("href", "").Trim.ToString()
                    Case 2  '返回src Text
                        RtStr = Node.GetAttributeValue("src", "").Trim.ToString()
                    Case Else
                        RtStr = Node.InnerText.Trim.ToString
                End Select
            Catch ex As Exception
                Log.Showlog(ex.ToString, Dict.MsgType.ErrorMsg, False)
                RtStr = String.Empty
            End Try
            Return RtStr
        End Function

        ''' <summary>
        ''' 获取节点
        ''' </summary>
        ''' <param name="rootNode">根节点</param>
        ''' <param name="xpathStr">XPath</param>
        ''' <returns></returns>
        ''' <remarks>获取节点</remarks>
        Public Shared Function GetNode(ByVal rootNode As HtmlNode, ByVal xpathStr As String) As HtmlNode
            Dim nodeCollect As HtmlNodeCollection = rootNode.SelectNodes(xpathStr)
            If nodeCollect Is Nothing Then
                Return Nothing
            End If
            Return nodeCollect(0)
        End Function

        ''' <summary>
        ''' 获取节点集
        ''' </summary>
        ''' <param name="rootNode">根节点</param>
        ''' <param name="xpathStr">XPath</param>
        ''' <returns>节点集</returns>
        ''' <remarks>获取节点集</remarks>
        Public Shared Function GetNodeCollection(ByVal rootNode As HtmlNode, ByVal xpathStr As String) As HtmlNodeCollection
            Dim nodeCollect As HtmlNodeCollection = rootNode.SelectNodes(xpathStr)
            If nodeCollect Is Nothing Then
                Return Nothing
            End If
            Return nodeCollect
        End Function
    End Class
End Namespace
