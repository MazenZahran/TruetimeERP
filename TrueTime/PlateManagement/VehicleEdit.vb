Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class VehicleEdit

    'Private con As SqlConnection
    'Private cmd As SqlCommand
    'Private adapter As SqlDataAdapter
    'Private ds As DataSet
    'Private rno As Integer = 0
    'Private ms As MemoryStream
    'Private photo_aray As Byte()
    Private Sub VehicleEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        'con = New SqlConnection(My.Settings.TrueTimeConnectionString)
        GetCarTypes()
        GetCarModel()
        GetAccounts()
        GetServices()
        GetMaintenance()
        CreateDocStatusTable()
        TabbedControlGroup1.SelectedTabPage = LayoutControlGroupAccounts
        'Referance.Properties.DataSource = GetReferences(-1,-1,-1)
    End Sub
    Private Sub GetMaintenance()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  M.[ID]  As DocID
                        ,V.CARNO  ,[DocDate]
                        ,R.RefName 
                        ,M.[Notes] ,[OdometerCurrent]
                        ,[OdometerNext] ,E.EmployeeName 
                        ,[Cost],[Paid]              
                      FROM [dbo].[Vehicle Maintenance] M
					  left join Vehicles V on V.CarID=M.CarID 
					  left join EmployeesData E on E.EmployeeID=M.Driver 
					  left join Referencess R on R.RefNo=M.RefNo  where M.CarID=" & Me.TextSearchCarID.Text
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl3.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SaveCarData()
    End Sub
    Private Sub SaveCarData()
        Try
            If TextSearchCarID.Text = -1 Then
                Dim con As SqlConnection
                Dim cmd As SqlCommand
                con = New SqlConnection(My.Settings.TrueTimeConnectionString)
                Dim SqlInsert As String = "Insert into Vehicles(CARNO,ChassiNoCar,CarType,CarModel,CarImage,             
                                        [active],YearCar,FuelsCar,MaintenanceAccountNo,AssetsAccountNo,
                                        RelatedService,CarCostCenter,CarDetails,Engine,OwnByReferance) values( 
                                        N'" & TextCARNO.Text & "',
                                        '" & TextChassiNoCar.EditValue & "',
                                        '" & Me.LookCarType.EditValue & "',
                                        '" & LookCarModel.EditValue & "'
                                        ,@photo, " & CheckActive.CheckState & ",
                                        " & TextYearCar.Text & "
                                        ,N'" & ComboFuelsCar.Text & "',
                                        '" & SearchMaintenanceAccountNo.EditValue & "',
                                        '" & SearchAssetsAccountNo.EditValue & "',
                                        '" & SearchRelatedService.EditValue & "',
                                        '" & SearchCarCostCenter.EditValue & "',
                                        N'" & MemoCarDetails.Text & "',
                                        '" & Engine.Text & "',
                                        '" & "" & "')"
                cmd = New SqlCommand(SqlInsert, con)
                Dim ms As MemoryStream
                If Me.PictureEdit1.Image IsNot Nothing Then
                    ms = New MemoryStream()
                    PictureEdit1.Image.Save(ms, ImageFormat.Jpeg)
                    Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
                    ms.Position = 0
                    ms.Read(photo_aray, 0, photo_aray.Length)
                    cmd.Parameters.AddWithValue("@photo", photo_aray)
                Else
                    ms = New MemoryStream()
                    My.Resources.EmptyCar.Save(ms, ImageFormat.Jpeg)
                    Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
                    ms.Position = 0
                    ms.Read(photo_aray, 0, photo_aray.Length)
                    cmd.Parameters.AddWithValue("@photo", photo_aray)
                End If
                con.Open()
                Dim n As Integer = cmd.ExecuteNonQuery()
                con.Close()

                If n > 0 Then
                    MessageBox.Show("تم تعريف المركبة")
                Else
                    MessageBox.Show("insertion failed")
                End If
            Else
                Dim con As SqlConnection
                con = New SqlConnection(My.Settings.TrueTimeConnectionString)
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Update [dbo].[Vehicles] set
                                              CARNO=N'" & TextCARNO.Text & "', ChassiNoCar='" & TextChassiNoCar.Text & "',
                                              CarType='" & LookCarType.EditValue & "',CarModel='" & LookCarModel.EditValue & "',
                                              YearCar=N'" & TextYearCar.Text & "', FuelsCar=N'" & Me.ComboFuelsCar.Text & "' ,
                                              AssetsAccountNo='" & SearchAssetsAccountNo.EditValue & "',
                                              MaintenanceAccountNo='" & SearchMaintenanceAccountNo.EditValue & "',
                                              RelatedService='" & SearchRelatedService.EditValue & "',
                                              CarCostCenter='" & SearchCarCostCenter.EditValue & "',
                                              CarDetails=N'" & MemoCarDetails.Text & "',
                                              OwnByReferance='" & "" & "',
                                              Engine='" & Engine.EditValue & "',[active]= " & CheckActive.CheckState & ",
                                              CarImage=@photo where CarID=" & TextCarID.Text, con)
                Dim ms As MemoryStream
                If Me.PictureEdit1.Image IsNot Nothing Then
                    ms = New MemoryStream()
                    PictureEdit1.Image.Save(ms, ImageFormat.Jpeg)
                    Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
                    ms.Position = 0
                    ms.Read(photo_aray, 0, photo_aray.Length)
                    cmd.Parameters.AddWithValue("@photo", photo_aray)
                Else
                    ms = New MemoryStream()
                    My.Resources.EmptyCar.Save(ms, ImageFormat.Jpeg)
                    Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
                    ms.Position = 0
                    ms.Read(photo_aray, 0, photo_aray.Length)
                    cmd.Parameters.AddWithValue("@photo", photo_aray)
                End If
                con.Open()
                Dim n As Integer = cmd.ExecuteNonQuery()
                con.Close()
                SavingInsuranceTarkhesTables()
                If n > 0 Then
                    MessageBox.Show("تم حفظ البيانات")
                Else
                    MessageBox.Show("Updation Failed")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GetInsuranceTarkhesTables()
    End Sub
    Private Sub conv_photo()
        Dim cmd As New SqlCommand
        Dim ms As MemoryStream
        If Me.PictureEdit1.Image IsNot Nothing Then
            ms = New MemoryStream()
            PictureEdit1.Image.Save(ms, ImageFormat.Jpeg)
            Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
            ms.Position = 0
            ms.Read(photo_aray, 0, photo_aray.Length)
            cmd.Parameters.AddWithValue("@photo", photo_aray)
        Else
            ms = New MemoryStream()
            My.Resources.EmptyCar.Save(ms, ImageFormat.Jpeg)
            Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
            ms.Position = 0
            ms.Read(photo_aray, 0, photo_aray.Length)
            cmd.Parameters.AddWithValue("@photo", photo_aray)
        End If
    End Sub

    Private Sub GetCarTypes()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select CarTypeID,CarType from [dbo].[CarsTypes]"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            LookCarType.Properties.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GetCarModel()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select CarModelID,CarModel from [dbo].[CarsModel]"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            LookCarModel.Properties.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GetAccounts()
        SearchAssetsAccountNo.Properties.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
        SearchMaintenanceAccountNo.Properties.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
        SearchCarCostCenter.Properties.DataSource = GetCostCenter(False)
    End Sub

    Private Sub TextSearchCarID_EditValueChanged(sender As Object, e As EventArgs) Handles TextSearchCarID.EditValueChanged
        Showdata()
        If TextSearchCarID.EditValue > 0 Then
            GridControl1.Enabled = True
            GridControl2.Enabled = True
            GridControlAccidant.Enabled = True
            GridVehiclesReceiptDeliveryEmloyees.Enabled = True
        Else
            GridControl1.Enabled = False
            GridControl2.Enabled = False
            GridControlAccidant.Enabled = False
            GridVehiclesReceiptDeliveryEmloyees.Enabled = False
        End If
    End Sub
    Private Sub Showdata()
        If Me.TextSearchCarID.Text = -1 Then
            SearchCarCostCenter.EditValue = 1
            Exit Sub
        End If
        Dim Sql As New SQLControl
        Dim SQlString As String
        SQlString = " Select [CarID],[CARNO],[ChassiNoCar],[CarType],CarModel,YearCar,FuelsCar,
                             [active],[Available],[CarImage],MaintenanceAccountNo,
                             AssetsAccountNo,RelatedService,CarCostCenter,[CarDetails],OwnByReferance,Engine
                      From [dbo].[Vehicles] where CarID= " & Me.TextSearchCarID.Text
        Sql.SqlTrueAccountingRunQuery(SQlString)
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("CarID")) Then TextCarID.Text = Sql.SQLDS.Tables(0).Rows(0).Item("CarID")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("CARNO")) Then TextCARNO.Text = Sql.SQLDS.Tables(0).Rows(0).Item("CARNO")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("ChassiNoCar")) Then TextChassiNoCar.Text = Sql.SQLDS.Tables(0).Rows(0).Item("ChassiNoCar")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("CarType")) Then LookCarType.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("CarType")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("CarModel")) Then LookCarModel.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("CarModel")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("YearCar")) Then TextYearCar.Text = Sql.SQLDS.Tables(0).Rows(0).Item("YearCar")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("FuelsCar")) Then ComboFuelsCar.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("FuelsCar")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("CarDetails")) Then MemoCarDetails.Text = Sql.SQLDS.Tables(0).Rows(0).Item("CarDetails")
        CheckActive.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("active")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("MaintenanceAccountNo")) Then SearchMaintenanceAccountNo.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("MaintenanceAccountNo")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("AssetsAccountNo")) Then SearchAssetsAccountNo.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("AssetsAccountNo")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("RelatedService")) Then SearchRelatedService.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("RelatedService")
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("CarCostCenter")) Then SearchCarCostCenter.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("CarCostCenter")
        ' If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("OwnByReferance")) Then Referance.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("OwnByReferance")
        '  CheckRented.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("Rented")

        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Engine")) Then Engine.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("Engine")


        Me.PictureEdit1.Image = Nothing
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("CarImage")) Then
            Dim photo_aray As Byte()
            photo_aray = CType(Sql.SQLDS.Tables(0).Rows(0).Item("CarImage"), Byte())
            Dim ms As MemoryStream = New MemoryStream(photo_aray)
            PictureEdit1.Image = Image.FromStream(ms)
        End If
        GetInsuranceTarkhesTables()
    End Sub
    Private Sub PictureEdit1_DoubleClick(sender As Object, e As EventArgs) Handles PictureEdit1.DoubleClick
        XtraOpenFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*"
        Dim res As DialogResult = XtraOpenFileDialog1.ShowDialog()

        If res = DialogResult.OK Then
            PictureEdit1.Image = Image.FromFile(XtraOpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub UpdateData()

    End Sub
    Dim Con As SqlConnection
    Dim InsuranceAdapter, TarkhesAdapter, AccidantAdapter, VehiclesReceiptDeliveryEmloyeesAdapter As SqlDataAdapter
    Dim DS As DataSet
    Private Sub GetInsuranceTarkhesTables()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            InsuranceAdapter = New SqlDataAdapter("SELECT [CarID],[InsuranceComapny],[StartDate],[EndDate],[Amount],[Notes],[TransID]  FROM dbo.[CarsInsurance] where CarID=" & TextCarID.Text & " Order By TransID Desc", Con)
            TarkhesAdapter = New SqlDataAdapter("SELECT [CarID],[StartDate],[EndDate],[Amount],[Notes],[TransID]  FROM [dbo].[CarsTarkhes]  where CarID=" & TextCarID.Text & " Order By TransID Desc", Con)
            AccidantAdapter = New SqlDataAdapter("SELECT [ID],[CarID],[AccidantDate],[DriverID],[Notes]  FROM [dbo].[CarsAccidant]  where [CarID]=" & TextCarID.Text & " Order By [ID] Desc", Con)
            VehiclesReceiptDeliveryEmloyeesAdapter = New SqlDataAdapter(" SELECT *  FROM [dbo].[VehiclesReceiptDeliveryEmloyees] where [CarID]= " & TextCarID.Text & " Order By [ID] Desc", Con)
            DS = New System.Data.DataSet()
            InsuranceAdapter.Fill(DS, "CarsInsurance")
            TarkhesAdapter.Fill(DS, "CarsTarkhes")
            AccidantAdapter.Fill(DS, "CarsAccidant")
            VehiclesReceiptDeliveryEmloyeesAdapter.Fill(DS, "VehiclesReceiptDeliveryEmloyees")
            GridControl1.DataSource = DS.Tables(0)
            GridControl2.DataSource = DS.Tables(1)
            GridControlAccidant.DataSource = DS.Tables(2)
            GridVehiclesReceiptDeliveryEmloyees.DataSource = DS.Tables(3)
        Catch ex As Exception
            '  Throw
        End Try


    End Sub
    Private Sub GridView2_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView2.InitNewRow
        GridView2.SetRowCellValue(e.RowHandle, "TransID", -1)
        GridView2.SetRowCellValue(e.RowHandle, "CarID", TextCarID.EditValue)
    End Sub
    Private Sub GridView3_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView3.InitNewRow
        GridView3.SetRowCellValue(e.RowHandle, "TransID", -1)
        GridView3.SetRowCellValue(e.RowHandle, "CarID", TextCarID.EditValue)
    End Sub
    Private Sub GridView7_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView7.InitNewRow
        GridView7.SetRowCellValue(e.RowHandle, "ID", -1)
        GridView7.SetRowCellValue(e.RowHandle, "CarID", TextCarID.EditValue)
    End Sub
    Private Sub GridView4_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView4.InitNewRow
        GridView4.SetRowCellValue(e.RowHandle, "ID", -1)
        GridView4.SetRowCellValue(e.RowHandle, "CarID", TextCarID.EditValue)
    End Sub
    Private Sub SavingInsuranceTarkhesTables()
        Dim SqlCommBuil As SqlCommandBuilder
        SqlCommBuil = New SqlCommandBuilder(InsuranceAdapter)
        InsuranceAdapter.Update(DS, "CarsInsurance")
        SqlCommBuil = New SqlCommandBuilder(TarkhesAdapter)
        TarkhesAdapter.Update(DS, "CarsTarkhes")
        SqlCommBuil = New SqlCommandBuilder(AccidantAdapter)
        AccidantAdapter.Update(DS, "CarsAccidant")
        SqlCommBuil = New SqlCommandBuilder(VehiclesReceiptDeliveryEmloyeesAdapter)
        VehiclesReceiptDeliveryEmloyeesAdapter.Update(DS, "VehiclesReceiptDeliveryEmloyees")
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)
        GridView2.DeleteRow(GridView2.FocusedRowHandle)
    End Sub
    Private Sub GridControl1_ProcessGridKey(ByVal sender As Object, ByVal e As KeyEventArgs) Handles GridControl1.ProcessGridKey, GridControl2.ProcessGridKey
        Dim grid = TryCast(sender, GridControl)
        Dim view = TryCast(grid.FocusedView, GridView)
        If e.KeyData = Keys.Delete Then
            view.DeleteSelectedRows()
            e.Handled = True
        End If
    End Sub
    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        With GridView2
            Try
                If e.Column.FieldName = "StartDate" Then
                    Try
                        Dim _StartDate As Date = CDate(.GetRowCellValue(.FocusedRowHandle, "StartDate")).AddYears(1).AddDays(-1)
                        .SetRowCellValue(.FocusedRowHandle, .Columns("EndDate"), _StartDate)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If
            Catch ex As Exception
            End Try
        End With
    End Sub
    Private Sub GridView3_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView3.CellValueChanged
        With GridView3
            Try
                If e.Column.FieldName = "StartDate" Then
                    Try
                        Dim _StartDate As Date = CDate(.GetRowCellValue(.FocusedRowHandle, "StartDate")).AddYears(1).AddDays(-1)
                        .SetRowCellValue(.FocusedRowHandle, .Columns("EndDate"), _StartDate)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If
            Catch ex As Exception
            End Try
        End With
    End Sub
    Private Sub GridView2_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView2.ValidateRow
        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)

            Dim _StartDate As GridColumn = view.Columns("StartDate")
            If IsDBNull(Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "StartDate")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال تاريخ البداية"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StartDate
                view.ShowEditor()
            End If
            Dim _EndDate As GridColumn = view.Columns("EndDate")
            If IsDBNull(Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "EndDate")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال تاريخ النهاية"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _EndDate
                view.ShowEditor()
            End If
            Dim _CarID As GridColumn = view.Columns("CarID")
            If IsDBNull(Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "CarID")) = True Then
                e.Valid = False
                e.ErrorText = "يجب اختيار المركبة"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StartDate
                view.ShowEditor()
            End If
            Dim _Amount As GridColumn = view.Columns("Amount")
            If IsDBNull(Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Amount")) = True Then
                e.Valid = False
                e.ErrorText = "خطا: يجب كتابة المبلغ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _Amount
                view.ShowEditor()
            End If
            Dim _InsuranceComapny As GridColumn = view.Columns("InsuranceComapny")
            If IsDBNull(Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "InsuranceComapny")) = True Then
                e.Valid = False
                e.ErrorText = "خطا: يجب كتابة اسم شركة التامين"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _InsuranceComapny
                view.ShowEditor()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl1.Paint

    End Sub

    Private Sub GridView3_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView3.ValidateRow
        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)

            Dim _StartDate As GridColumn = view.Columns("StartDate")
            If IsDBNull(Me.GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "StartDate")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال تاريخ البداية"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StartDate
                view.ShowEditor()
            End If
            Dim _EndDate As GridColumn = view.Columns("EndDate")
            If IsDBNull(Me.GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "EndDate")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال تاريخ النهاية"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _EndDate
                view.ShowEditor()
            End If
            Dim _CarID As GridColumn = view.Columns("CarID")
            If IsDBNull(Me.GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "CarID")) = True Then
                e.Valid = False
                e.ErrorText = "يجب اختيار المركبة"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StartDate
                view.ShowEditor()
            End If
            Dim _Amount As GridColumn = view.Columns("Amount")
            If IsDBNull(Me.GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Amount")) = True Then
                e.Valid = False
                e.ErrorText = "خطا: يجب كتابة المبلغ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _Amount
                view.ShowEditor()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GridView4_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView4.ValidateRow
        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)

            Dim _DocDate As GridColumn = view.Columns("DocDate")
            If IsDBNull(Me.GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "DocDate")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال التاريخ "
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _DocDate
                view.ShowEditor()
            End If

            Dim _DocStatus As GridColumn = view.Columns("DocStatus")
            If IsDBNull(Me.GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "DocStatus")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال حالة الحركة"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _DocStatus
                view.ShowEditor()
            End If

            Dim _EmployeeNo As GridColumn = view.Columns("EmployeeNo")
            If IsDBNull(Me.GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "EmployeeNo")) = True Then
                e.Valid = False
                e.ErrorText = "يجب اختيار الموظف"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _EmployeeNo
                view.ShowEditor()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub SearchCarCostCenter_EditValueChanged(sender As Object, e As EventArgs) Handles SearchCarCostCenter.AddNewValue
        CostCenters.ShowDialog()
    End Sub

    Private Sub SearchCarCostCenter_EditValueChanged_1(sender As Object, e As EventArgs) Handles SearchCarCostCenter.BeforePopup
        SearchCarCostCenter.Properties.DataSource = GetCostCenter(False)
    End Sub

    Private Sub SearchCarCostCenter_EditValueChanged_2(sender As Object, e As EventArgs) Handles SearchCarCostCenter.EditValueChanged

    End Sub

    Private Sub GetServices()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select [ItemNo],[ItemName] From [dbo].[Items] where [Type]=1 "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            SearchRelatedService.Properties.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextCARNO_EditValueChanged(sender As Object, e As EventArgs) Handles TextCARNO.EditValueChanged

    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        'Dim f As New VehicleMaintenance
        'With f
        '    .TextDocID.EditValue = Me.TextSearchCarID.Text
        '    .GetMaintenanceDocument()
        '    If .ShowDialog <> DialogResult.OK Then
        '        GetMaintenance()
        '    End If
        'End With

        Dim f As New VehicleMaintenance
        With f
            .TextDocID.EditValue = GridView1.GetFocusedRowCellValue("DocID")
            .GetMaintenanceDocument()
            If .ShowDialog <> DialogResult.OK Then
                GetMaintenance()
            End If
        End With

    End Sub



    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim f As New VehicleMaintenance
        With f
            .AddNewMaintenanceDocument()
            .CarIDLookUp.EditValue = Me.TextSearchCarID.Text
            If .ShowDialog <> DialogResult.OK Then
                GetMaintenance()
            End If
        End With
    End Sub

    Private Sub CheckActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckActive.CheckedChanged

    End Sub

    Private Sub VehicleEdit_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub
    Private Sub CreateDocStatusTable()
        ' Declare DataTable
        Dim Table1 As New DataTable()
        ' Define columns
        Table1.Columns.Add("ID", GetType(System.Int32))
        Table1.Columns.Add("DocStatus", GetType(System.String))
        Table1.Rows.Add(1, "تسليم")
        Table1.Rows.Add(2, "استلام")
        RepositoryItemDocStatus.DataSource = Table1
    End Sub
End Class