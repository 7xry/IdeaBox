Namespace Utils.Database.Model
    Public Class QueryParameter
        Property Name() As String
        Property Value() As Object
        Property DbType() As DbType
        Property Direction() As ParameterDirection = ParameterDirection.Input

        Sub New(ByVal QName As String, ByVal QValue As Object, ByVal QType As DbType)
            Name = QName
            Value = QValue
            DbType = QType
        End Sub
    End Class
End Namespace