Partial Class AccountingDataSet
    Partial Public Class ReferencessDataTable
        Private Sub ReferencessDataTable_ReferencessRowChanging(sender As Object, e As ReferencessRowChangeEvent) Handles Me.ReferencessRowChanging

        End Sub

    End Class

    Partial Public Class ItemsDataTable
        Private Sub ItemsDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.ItemNoColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class

Namespace AccountingDataSetTableAdapters
    Partial Public Class AppointmentsTableAdapter
    End Class
End Namespace
