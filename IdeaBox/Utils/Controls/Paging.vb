Namespace Utils.Controls
    Public Class Paging
        '每页记录数
        Property RowsPerPage As Integer
        '总页数
        Property TotalPage As Integer
        '当前页数
        Property curPage As Integer = 0
        '要分页的DataGridView
        Property SetDataGridView As DataGridView
        '与需要分页显示的的DataView
        Property SetDataView As Data.DataView

        Public Sub New()
        End Sub
        '重载NEW函数，在构造时就可以对成员赋值
        Public Sub New(ByVal datagridview As DataGridView, ByVal dv As Data.DataView, ByVal NRowsPerPage As Integer)
            SetDataGridView = datagridview
            SetDataView = dv
            RowsPerPage = NRowsPerPage
        End Sub

        '开始分页啦
        Public Sub Paging()
            '首先判断DataView中的记录数是否足够形成多页，
            '如果不能，那么就只有一页，且DataGridView需要显示的记录等同于“最后一页”的记录
            If SetDataView.Count <= RowsPerPage Then
                TotalPage = 1
                GoLastPage()
                Exit Sub
            End If
            '可以分为多页的话就要计算总的页数咯，然后DataGridView显示第一页
            If SetDataView.Count Mod RowsPerPage = 0 Then
                TotalPage = Int(SetDataView.Count / RowsPerPage)
            Else
                TotalPage = Int(SetDataView.Count / RowsPerPage) + 1
            End If
            GoFirstPage()
        End Sub

        '到第一页
        Public Sub GoFirstPage()
            '如果只有一页，那么显示的记录等同于“最后一页”的记录
            If TotalPage = 1 Then
                GoLastPage()
                Exit Sub
            End If
            '如果有多页，就到第“1”页
            curPage = 0
            GoNoPage(curPage)
        End Sub
        Public Sub GoNextPage()
            '这段代码主要是为了防止当前页号溢出
            curPage += 1
            If curPage > TotalPage - 1 Then
                curPage = TotalPage - 1
                Exit Sub
            End If
            '如果到了最后一页，那就显示最后一页的记录
            If curPage = TotalPage - 1 Then
                GoLastPage()
                Exit Sub
            End If
            '如果没到最后一页，就到指定的“下一页”
            GoNoPage(curPage)
        End Sub
        Public Sub GoPrevPage()
            '防止不合法的当前页号
            curPage -= 1
            If curPage < 0 Then
                curPage = 0
                Exit Sub
            End If
            '到指定的“上一页”
            GoNoPage(curPage)
        End Sub
        '到最后一页
        Public Sub GoLastPage()
            curPage = TotalPage - 1
            Dim i As Integer
            Dim dt As New DataTable
            'dt只是个临时的DataTable，用来获取所需页数的记录
            dt = SetDataView.ToTable.Clone
            For i = (TotalPage - 1) * RowsPerPage To SetDataView.Count - 1
                'i值上下限很关键，调试的时候常常这里报错找不到行
                '就是因为i值溢出
                Dim dr As DataRow = dt.NewRow
                dr.ItemArray = SetDataView.ToTable.Rows(i).ItemArray
                dt.Rows.Add(dr)
            Next
            SetDataGridView.DataSource = dt
        End Sub
        '到指定的页
        Public Sub GoNoPage(ByVal PageNo As Integer)
            curPage = PageNo
            '防止不合法的页号
            If curPage < 0 Then
                MsgBox("页号不能小于1")
                Exit Sub
            End If
            '防止页号溢出
            If curPage >= TotalPage Then
                MsgBox("页号超出上限")
                Exit Sub
            End If
            '如果页号是最后一页，就显示最后一页
            If curPage = TotalPage - 1 Then
                GoLastPage()
                Exit Sub
            End If
            '不是最后一页，那显示指定页号的页
            Dim dt As New DataTable
            dt = SetDataView.ToTable.Clone
            Dim i As Integer
            For i = PageNo * RowsPerPage To (PageNo + 1) * RowsPerPage - 1
                Dim dr As DataRow = dt.NewRow
                dr.ItemArray = SetDataView.ToTable.Rows(i).ItemArray
                dt.Rows.Add(dr)
            Next
            SetDataGridView.DataSource = dt
        End Sub
    End Class
End Namespace