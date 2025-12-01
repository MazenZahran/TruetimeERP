Imports System.Data.Entity.SqlServer
Imports System.Data.OleDb
Imports DevExpress.XtraCharts.Native
Imports DevExpress.XtraEditors
Imports GMap.NET

Public Class OtherTools
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Try
            Dim SqlDeleteDublicate As String
            Dim sql As New SQLControl
            SqlDeleteDublicate = "SELECT COUNT(*) as CountDublicate
FROM 
[AttCHECKINOUT] a
INNER JOIN
(
 SELECT MAX(ID) AS ID, [CHECKTIME] 
 FROM [AttCHECKINOUT]
 GROUP BY [CHECKTIME] 
 HAVING COUNT([CHECKTIME]) > 1
) b
ON a.ID < b.ID AND a.[CHECKTIME]=b.[CHECKTIME]"

            sql.SqlTrueTimeRunQuery(SqlDeleteDublicate)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                TextCountDublicate.Text = "عدد الحركات المكررة " & ": " & sql.SQLDS.Tables(0).Rows(0).Item("CountDublicate")
                SimpleButton2.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try




    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        Try
            Dim DeleteDublicate As String
            DeleteDublicate = " DELETE a
FROM [AttCHECKINOUT] a
INNER JOIN
(SELECT ID, RANK() OVER(PARTITION BY [CHECKTIME] ORDER BY ID DESC) AS rnk FROM [AttCHECKINOUT] ) b 
ON a.ID=b.ID
WHERE b.rnk>1"
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(DeleteDublicate)
            MsgBox("تم حذف الحركات المكررة")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        My.Forms.ChangeConnectionString.ConnectionName.Text = "TrueTime.My.MySettings.TrueTimeConnectionString"
        My.Forms.ChangeConnectionString.Show()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        My.Forms.ChangeConnectionString.ConnectionName.Text = "TrueTime.My.MySettings.TrueTimeConnectionString"
        My.Forms.ChangeConnectionString.Show()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim _Table As New DataTable

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " SELECT   J.DocID,[DocName],
                          SUM(DocAmount) AS DocAmount
                          From journal J where DocCode is Null or DocCode=''
                          Group by DocID,docname  "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If _Table.Rows.Count = 0 Then
            XtraMessageBox.Show("لا يوجد بيانات للتعديل")
            Exit Sub
        End If
        If XtraMessageBox.Show("هل تريد تعديل " & _Table.Rows.Count, "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim i, _Rows As Integer
            _Rows = _Table.Rows.Count
            If _Rows > 0 Then
                For i = 0 To _Rows - 1
                    Try
                        Dim _DocID As Integer = _Table.Rows(i).Item("DocID")
                        Dim _DocName As Integer = _Table.Rows(i).Item("DocName")
                        Dim Sql As New SQLControl
                        Dim _DocCode As String = CreateRandomCode()
                        Sql.SqlTrueAccountingRunQuery("Update Journal Set DocCode ='" & _DocCode & "'
                Where  DocID =" & _DocID & " and DocName=" & _DocName & " and DocCode is null ")
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                Next
            End If
            MsgBox("تم التعديل ")
        End If



    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        If XtraMessageBox.Show("هل تريد تعديل أسعار الشراء؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Try
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = " UPDATE A
                          SET A.LastPurchasePrice = B.Price,A.LastPurchaseDate=B.DocDate
                          FROM Items A
                          JOIN (SELECT StockID, DocDate ,BaseAmount/StockQuantityByMainUnit As Price
                          FROM (SELECT  *, ROW_NUMBER() OVER (PARTITION BY stockid ORDER By DocDate DESC) AS rn
                          FROM Journal where StockID<>0 and StockID is not null and DocName=1) x
                    WHERE rn = 1) B
                        ON A.ItemNo = b.StockID  "
                sql.SqlTrueAccountingRunQuery(SqlString)
                MsgBox("Done")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Dim f As New SecuritySettings
        With f
            .ShowDialog()
        End With
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Dim f As New QuickSettings
        With f
            .ShowDialog()
        End With
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        Dim con = New System.Data.OleDb.OleDbConnection With {.ConnectionString = AttConectionString()}
        Try
            con.Open()
            Dim _CHECKTIME_ As String = Format(CDate(DateEdit1.DateTime), "MM-dd-yyyy")
            Dim SqlStringUpdate As String = " Update  [CHECKINOUT] 
                                                         Set [AttProcess]= null where [AttProcess]=1 and  CHECKTIME >=#" & _CHECKTIME_ & "#"
            Dim AccessCmd As OleDbCommand = New OleDbCommand(SqlStringUpdate, con)
            AccessCmd.ExecuteNonQuery() ' Update Row in Access
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        con.Close()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(" 
select count(DocCode),DocCode from
( select Count(ID) As IDCount,DocCode,DocID from Journal  group by DocCode,DocID  ) A
group by DocCode
having count(DocCode) >  1 ")
        Me.GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        Dim F As New SequenceTable
        F.ShowDialog()
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        Dim F As New ContractDetails
        F.ShowDialog()
    End Sub
End Class