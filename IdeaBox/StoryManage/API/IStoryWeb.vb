Imports IdeaBox.StoryManage.Model

Namespace StoryManage.API
    Public Interface IStoryWeb
        Property Url As String
        Function GetPageCount() As Integer
        Function GetBooks(ByVal timer As Stopwatch, ByVal TableName As String) As Boolean
        Function GetBookInfo(ByVal book As Story) As Story
    End Interface
End Namespace

