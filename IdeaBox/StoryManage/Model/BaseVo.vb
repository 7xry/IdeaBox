Namespace StoryManage.Model
    Public MustInherit Class BaseVo
        Property CreateDate As String
        Property LastModifyDate As String
        Property IsDelete As String = 0
        Property Memo As String = String.Empty
    End Class
End Namespace