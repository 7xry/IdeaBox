Namespace Utils.Controls.DataView
    Public Class GridNum
        Public Shared Sub GetGridNum(ByVal dv As DataGridView, ByVal e As DataGridViewRowPostPaintEventArgs)
            '在DataGridView的RowPostPaint事件中这样调用：GridNo.NO(datagridview1,e)
            Dim Color As Color = dv.RowHeadersDefaultCellStyle.ForeColor
            If dv.Rows(e.RowIndex).Selected Then
                Color = dv.RowHeadersDefaultCellStyle.SelectionForeColor
            Else
                Color = dv.RowHeadersDefaultCellStyle.ForeColor
            End If


            Dim b As SolidBrush = New SolidBrush(Color)
            If e.RowIndex < 9 Then
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 6)
            ElseIf e.RowIndex < 99 Then
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 17, e.RowBounds.Location.Y + 6)
            ElseIf e.RowIndex < 999 Then
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 14, e.RowBounds.Location.Y + 6)
            ElseIf e.RowIndex < 9999 Then
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 11, e.RowBounds.Location.Y + 6)
            Else
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 8, e.RowBounds.Location.Y + 6)
            End If
            b.Dispose()
        End Sub
    End Class
End Namespace