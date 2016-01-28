Imports System.Xml.Serialization
Imports System.IO


Namespace Utils.FileSystem.Files
    Public Class XmlDoc
        Public Shared Property ConfStr() As String

        '****************************************************************************
        '   读取xml文件，一级节点的属性值
        '****************************************************************************
        Overloads Shared Function GetValue(ByVal INameLv1 As String, ByVal attributeName As String) As String
            Try
                Dim XRead As Xml.XmlDocument = New Xml.XmlDocument
                XRead.Load(ConfStr)
                Dim cfg As Xml.XmlNode = XRead.DocumentElement
                GetValue = cfg.Item(INameLv1).Attributes.GetNamedItem(attributeName).Value
            Catch ex As Exception
                GetValue = String.Empty
            End Try
        End Function

        '********************************************************************************
        '    保存配置文件，一级节点的属性值
        '********************************************************************************
        Overloads Shared Sub SaveValue(ByVal INameLv1 As String, ByVal attributeName As String, ByVal value As String)
            If File.Exists(ConfStr) Then
                Dim xmlReader As Xml.XmlDocument = New Xml.XmlDocument
                xmlReader.Load(ConfStr)
                Dim root As Xml.XmlNode = xmlReader.DocumentElement
                root.Item(INameLv1).Attributes.GetNamedItem(attributeName).Value = value
                xmlReader.Save(ConfStr)
            End If
        End Sub

        '****************************************************************************
        '   读取xml文件，二级节点的属性值
        '****************************************************************************
        Overloads Shared Function GetValue(ByVal INameLv1 As String, ByVal INameLv2 As String, ByVal attributeName As String) As String
            Try
                Dim XRead As Xml.XmlDocument = New Xml.XmlDocument
                XRead.Load(ConfStr)
                Dim cfg As Xml.XmlNode = XRead.DocumentElement
                GetValue = cfg.Item(INameLv1).Item(INameLv2).Attributes.GetNamedItem(attributeName).Value
            Catch ex As Exception
                GetValue = String.Empty
            End Try
        End Function

        '********************************************************************************
        '    保存配置文件，一级节点的属性值
        '********************************************************************************
        Overloads Shared Sub SaveValue(ByVal INameLv1 As String, ByVal INameLv2 As String, ByVal attributeName As String, ByVal value As String)
            If File.Exists(ConfStr) Then
                Dim xmlReader As Xml.XmlDocument = New Xml.XmlDocument
                xmlReader.Load(ConfStr)
                Dim root As Xml.XmlNode = xmlReader.DocumentElement
                root.Item(INameLv1).Item(INameLv2).Attributes.GetNamedItem(attributeName).Value = value
                xmlReader.Save(ConfStr)
            End If
        End Sub

        '****************************************************************************
        '   读取xml文件，三级节点的属性值
        '****************************************************************************
        Overloads Shared Function GetValue(ByVal INameLv1 As String, ByVal INameLv2 As String, ByVal INameLv3 As String, ByVal attributeName As String) As String
            Try
                Dim XRead As Xml.XmlDocument = New Xml.XmlDocument
                XRead.Load(ConfStr)
                Dim cfg As Xml.XmlNode = XRead.DocumentElement
                GetValue = cfg.Item(INameLv1).Item(INameLv2).Item(INameLv3).Attributes.GetNamedItem(attributeName).Value
            Catch ex As Exception
                GetValue = String.Empty
            End Try
        End Function

        '********************************************************************************
        '    保存配置文件，一级节点的属性值
        '********************************************************************************
        Overloads Shared Sub SaveValue(ByVal INameLv1 As String, ByVal INameLv2 As String, ByVal INameLv3 As String, ByVal attributeName As String, ByVal value As String)
            If File.Exists(ConfStr) Then
                Dim xmlReader As Xml.XmlDocument = New Xml.XmlDocument
                xmlReader.Load(ConfStr)
                Dim root As Xml.XmlNode = xmlReader.DocumentElement
                root.Item(INameLv1).Item(INameLv2).Item(INameLv3).Attributes.GetNamedItem(attributeName).Value = value
                xmlReader.Save(ConfStr)
            End If
        End Sub

        '****************************************************************************
        '   读取xml文件，四级节点的属性值
        '****************************************************************************
        Overloads Shared Function GetValue(ByVal INameLv1 As String, ByVal INameLv2 As String, ByVal INameLv3 As String, ByVal INameLv4 As String, ByVal attributeName As String) As String
            Try
                Dim XRead As Xml.XmlDocument = New Xml.XmlDocument
                XRead.Load(ConfStr)
                Dim cfg As Xml.XmlNode = XRead.DocumentElement
                GetValue = cfg.Item(INameLv1).Item(INameLv2).Item(INameLv3).Item(INameLv4).Attributes.GetNamedItem(attributeName).Value
            Catch ex As Exception
                GetValue = String.Empty
            End Try
        End Function

        '********************************************************************************
        '    保存配置文件，一级节点的属性值
        '********************************************************************************
        Overloads Shared Sub SaveValue(ByVal INameLv1 As String, ByVal INameLv2 As String, ByVal INameLv3 As String, ByVal INameLv4 As String, ByVal attributeName As String, ByVal value As String)
            If File.Exists(ConfStr) Then
                Dim xmlReader As Xml.XmlDocument = New Xml.XmlDocument
                xmlReader.Load(ConfStr)
                Dim root As Xml.XmlNode = xmlReader.DocumentElement
                root.Item(INameLv1).Item(INameLv2).Item(INameLv3).Item(INameLv4).Attributes.GetNamedItem(attributeName).Value = value
                xmlReader.Save(ConfStr)
            End If
        End Sub

        '********************************************************************************
        '    序列化XML对象
        '********************************************************************************
        Public Shared Function Serialize(ByVal instance As Object) As String
            If IsNothing(instance) = True Then
                Return String.Empty
            End If
            Try
                Dim serializer As New XmlSerializer(instance.GetType())
                Dim writer As New StringWriter
                serializer.Serialize(CType(writer, TextWriter), instance)
                Return writer.ToString()
            Catch ex As Exception
                Return ex.ToString()
            End Try
        End Function
    End Class
End Namespace