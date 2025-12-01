Imports System.IO

Public Class VehicleMaintenance

    Private Sub VehicleMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        'TODO: This line of code loads data into the 'AccountingDataSet1.Referencess' table. You can move, or remove it, as needed.
        Me.ReferencessTableAdapter.Fill(Me.AccountingDataSet1.Referencess)
        'TODO: This line of code loads data into the 'AccountingDataSet.Vehicle_Maintenance' table. You can move, or remove it, as needed.

        '  Me.LookUpCars.Properties.DataSource = VehiclesFunctions.GetCarsList(True)
        CarIDLookUp.Properties.DataSource = GetCarsList(True)
    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Validate()
        Me.Vehicle_MaintenanceBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
        Me.Dispose()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Me.Validate()
        Me.Vehicle_MaintenanceBindingSource.RemoveCurrent()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
        Me.Dispose()
    End Sub
    Public Sub AddNewMaintenanceDocument()
        Me.Vehicle_MaintenanceBindingSource.AddNew()
    End Sub
    Public Sub GetMaintenanceDocument()
        Me.Vehicle_MaintenanceTableAdapter.FillByDocID(Me.AccountingDataSet.Vehicle_Maintenance, TextDocID.EditValue)
    End Sub

    Private Sub IDSpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles IDSpinEdit.EditValueChanged

    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextDocID.EditValueChanged
        'GetMaintenanceDocument()
    End Sub

    Private Sub CarIDLookUp_EditValueChanged(sender As Object, e As EventArgs) Handles CarIDLookUp.EditValueChanged
        If Me.CarIDLookUp.EditValue = 0 Then Exit Sub
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select CarImage from Vehicles where CarID=" & Me.CarIDLookUp.EditValue
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Me.PictureEdit1.Image = Nothing
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CarImage")) Then
                Dim photo_aray As Byte()
                photo_aray = CType(sql.SQLDS.Tables(0).Rows(0).Item("CarImage"), Byte())
                Dim ms As MemoryStream = New MemoryStream(photo_aray)
                PictureEdit1.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RefNoSpinEdit_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles RefNoSpinEdit.Properties.AddNewValue
        ' Dim _New As String = "0"
        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            '.LoaddefaultDataSourceforReferences()
            .TextRefName.Text = ""
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .LookRefType.EditValue = 1
            .TextRefName.Select()
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            Else
                Me.ReferencessTableAdapter.Fill(Me.AccountingDataSet1.Referencess)
                '   Me.Referance.EditValue = .TextRefNo.EditValue
                '     _New = .TextRefNo.EditValue
            End If
        End With
        '    Me.Referance.Text = _New
    End Sub
End Class