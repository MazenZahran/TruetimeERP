Imports System.ComponentModel

Public Class ReservationShortList
    Public _ReservationDate As DateTime
    Public Sub ReservationShortList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDate()
    End Sub
    Private Sub GetDate()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "   select R.RefName,I.ItemName  from [dbo].[ReservationsList] S
                        left join Referencess R on S.ReferanceNo=R.RefNo 
                        left join Items I on I.ItemNo=S.TheService 
                        where [DocStatus]=0 and ReservationDate='" & Format(_ReservationDate, "yyyy-MM-dd") & "'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ReservationShortList_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub
End Class