Imports IdeaBox.Utils.Database.Model

Namespace Utils.Database.API
    Public Interface IDataAccess
        '打开数据库连接
        Sub Open()
        '关闭数据库连接
        Sub Close()
        '开始事务
        Sub BeginTran()
        '提交事务
        Sub CommitTran()
        '回滚事务
        Sub RollBackTran()
        '执行增删改
        Function ExecuteNonQuery(ByVal sql As String, ByVal ParamArray para As QueryParameter()) As Integer
        '返回单个值
        Function ExecuteScalar(ByVal sql As String, ByVal ParamArray para As QueryParameter()) As Object
        '返回查询结果表格
        Function GetTable(ByVal sql As String, ByVal ParamArray para As QueryParameter()) As DataTable
        '返回一个DataReader
        Function GetReader(ByVal sql As String, ByVal ParamArray para As QueryParameter()) As IDataReader
    End Interface
End Namespace