Imports IdeaBox.StoryManage.Model

Namespace StoryManage.API
    Public Interface IStory
        Sub Add(ByVal s As Story, ByVal TableName As String)
        Sub Add(ByVal sLs As List(Of Story), ByVal TableName As String)
        Sub Update(ByVal s As Story, ByVal TableName As String)
        Sub Update(ByVal sLs As List(Of Story), ByVal TableName As String)
        Sub Delete(ByVal s As Story, ByVal TableName As String)
        Sub Delete(ByVal sLs As List(Of Story), ByVal TableName As String)
        Sub ResetTable(ByVal TableName As String)
        Function GetList(ByVal s As Story, ByVal TableName As String) As List(Of Story)
        Function IsExist(ByVal s As Story, ByVal TableName As String) As Boolean
    End Interface
End Namespace
