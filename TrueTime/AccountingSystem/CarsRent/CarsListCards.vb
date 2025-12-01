Public Class CarsListCards
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub

    Private Sub RefreshData()
        Me.RepositoryCostCenter.DataSource = GetCostCenter(False)
        Dim CarModel As String = CStr(SearchLookUpEditModel.EditValue)
        Dim MarkaCar As String = CStr(SearchLookUpEditMarka.EditValue)
        Dim CarNo As String = CStr(SearchLookUpEditCar.EditValue)
        Dim SqlString As String
        Dim sql As New SQLControl
        SqlString = " SELECT  [CarID]      ,[CARNO]      ,[ChassiNoCar]      ,[CarType] as MarkaCar     ,[CarModel] as ModelCar,
                              [YearCar]      ,[ColorCar]      ,[FuelsCar]      ,[ReferanceID]      ,[DatePurchase]      ,[CostCar],CarCostCenter,
                              [Vender]      ,[DateSale]      ,[SaleCar]      ,left([Customer],20) as  Customer    ,[CarImage] as  Picture   ,[SortCar],
                              [active]      ,[BegSpedometaer]      ,[CarDetails]      ,[Rented]      ,[MaintenanceAccountNo]      ,[AssetsAccountNo],
                              (SELECT top 1 [EndDate] FROM [dbo].[CarsTarkhes] T   WHERE     T.CarID=C.[CarID]     ORDER BY [EndDate] desc) as TarkhesEndDate,
                              (SELECT top 1 [EndDate] FROM [dbo].[CarsInsurance] I WHERE     I.CarID=C.[CarID]     ORDER BY [EndDate] desc) as InsuranceEndDat,
                              (SELECT top 1 DocStartDate FROM [dbo].CarRentDocuments D WHERE     D.CarID=C.[CarID] and C.Rented=1  ORDER BY DocStartDate desc) as DocStartDate,
							                              (	SELECT	top 1   CONCAT( case when GETDATE() > [DocStartDate] then (DATEPART(YEAR,   GETDATE () - [DocStartDate])-1900) * 365 +
                                 (DATEPART(MONTH,   GETDATE() - [DocStartDate])-1) *30 +(DATEPART(DAY,   GETDATE() - [DocStartDate])-1) else '' End, N'يوم و ' ,
	                             Case when GETDATE() > [DocStartDate] then DATEPART(HOUR,   GETDATE() - [DocStartDate]) else '' End,N'س' ) as CarPeriod             
                   FROM  [dbo].[CarRentDocuments] P 
                   left join dbo.CarsRent on P.CarID=dbo.CarsRent.CarID  
                   where dbo.CarsRent.Rented='True' and P.CarID=C.CarID order by P.DocID desc )   As CarPeriod          
                   FROM [dbo].[CarsRent] C "
        SqlString = SqlString + "  where CarID > 0   "
        Select Case CStr(RadioGroup2.EditValue)
            Case "1"
                SqlString = SqlString + " and [active] = 1 "
            Case "2"
                SqlString = SqlString + " and [active] = 0 "
        End Select
        sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
        GetCarsModel()
        GetCarsTypes()
        If CStr(RadioGroup1.EditValue) = "Grid" Then GridControl1.MainView = GridView1
        If CStr(RadioGroup1.EditValue) = "Cards" Then GridControl1.MainView = TileView1
        GridView1.BestFitColumns()
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        Dim CarID As String = CType(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CarID"), String)
        My.Forms.CarEdit.TextSearchCarID.Text = CarID
        My.Forms.CarEdit.ShowDialog()
    End Sub

    Private Sub CarsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()
        'h
    End Sub

    Private Sub RepositoryEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryEdit.ButtonClick
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            Dim ChassiNoCar As String = GridView1.GetFocusedRowCellValue("ChassiNoCar").ToString
            Dim MarkaCar As String = GridView1.GetFocusedRowCellValue("MarkaCar").ToString
            Dim ModelCar As String = GridView1.GetFocusedRowCellValue("ModelCar").ToString
            Dim YearCar As String = GridView1.GetFocusedRowCellValue("YearCar").ToString
            Dim ColorCar As String = GridView1.GetFocusedRowCellValue("ColorCar").ToString
            Dim FuelsCar As String = GridView1.GetFocusedRowCellValue("FuelsCar").ToString
            Dim DriverID As String = GridView1.GetFocusedRowCellValue("DriverID").ToString
            Dim DatePurchase As String = GridView1.GetFocusedRowCellValue("DatePurchase").ToString
            Dim CostCar As String = GridView1.GetFocusedRowCellValue("CostCar").ToString
            Dim Vender As String = GridView1.GetFocusedRowCellValue("Vender").ToString
            Dim DateSale As String = GridView1.GetFocusedRowCellValue("DateSale").ToString
            Dim SaleCar As String = GridView1.GetFocusedRowCellValue("SaleCar").ToString
            Dim Customer As String = GridView1.GetFocusedRowCellValue("Customer").ToString
            Dim SortCar As String = GridView1.GetFocusedRowCellValue("SortCar").ToString
            Dim active As String = GridView1.GetFocusedRowCellValue("active").ToString
            Dim AccountKey As String = GridView1.GetFocusedRowCellValue("AccountKey").ToString
            Dim OrpakCar As String = GridView1.GetFocusedRowCellValue("OrpakCar").ToString
            Dim BegSpedometaer As String = GridView1.GetFocusedRowCellValue("BegSpedometaer").ToString
            Dim CarVolume As String = GridView1.GetFocusedRowCellValue("CarVolume").ToString
            Dim RegPerson As String = GridView1.GetFocusedRowCellValue("RegPerson").ToString
            Dim TeboGraphDate As String = GridView1.GetFocusedRowCellValue("TeboGraphDate").ToString
            Dim CarDetails As String = GridView1.GetFocusedRowCellValue("CarDetails").ToString
            Dim NoOnExcel As String = GridView1.GetFocusedRowCellValue("NoOnExcel").ToString
            SqlString = " UPDATE [CRM].[dbo].[cars]
                          SET
                               [ChassiNoCar] = '" & ChassiNoCar & "' 
                              ,[MarkaCar] = '" & MarkaCar & "' 
                              ,[ModelCar] = '" & ModelCar & "'
                              ,[YearCar] = '" & YearCar & "'
                              ,[ColorCar] = '" & ColorCar & "'
                              ,[FuelsCar] = '" & FuelsCar & "'
                              ,[DriverID] = '" & DriverID & "'
                              ,[DatePurchase] = '" & DatePurchase & "'
                              ,[CostCar] = '" & CostCar & "'
                              ,[Vender] = '" & Vender & "'
                              ,[DateSale] = '" & DateSale & "'
                              ,[SaleCar] = '" & SaleCar & "'
                              ,[Customer] = '" & Customer & "'
                              ,[SortCar] = '" & SortCar & "'
                              ,[AccountKey] = '" & AccountKey & "'
                              ,[OrpakCar] = '" & OrpakCar & "'
                              ,[BegSpedometaer] = '" & BegSpedometaer & "'
                              ,[CarVolume] = '" & CarVolume & "'
                              ,[RegPerson] = '" & RegPerson & "'
                              ,[TeboGraphDate] = '" & TeboGraphDate & "'
                              ,[CarDetails] = '" & CarDetails & "' 
                              ,[active] = '" & active & "' 
                              ,[NoOnExcel] = '" & NoOnExcel & "' 
                           WHERE CarID ='" & GridView1.GetFocusedRowCellValue("CarID").ToString & "'"
            '   sql.CRMRunQuery(SqlString)
            RefreshData()
            MsgBox("تم تعديل بيانات المركبة")
        Catch ex As Exception
            MsgBox(ex.ToString)
            RefreshData()
        End Try
    End Sub

    Private Sub FillOrpakCar()
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " SELECT        [plate] as OrpakCar ,case when [means].[status]=2 then N'فعالة' else N'موقوفة' end as status
                          FROM [HO_DATA].[dbo].[means]
                          left join ho_data.dbo.fleets on [HO_DATA].[dbo].[means].[fleet_id]=[HO_DATA].[dbo].[fleets].id
                          where [fleets].code='1000'  "
            '   sql.RunQuery(SqlString)
            RepositoryCarOnOrpak.DataSource = sql.SQLDS.Tables(0)
            RepositoryCarOnOrpak.DisplayMember = "OrpakCar"
            RepositoryCarOnOrpak.ValueMember = "OrpakCar"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub RepositoryCarOnOrpak_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryCarOnOrpak.BeforePopup

    End Sub

    Private Sub FillCarsAccount()
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " Select [AccountKey],[FullName] FROM [ALHUDA].[dbo].[Accounts] where SortGroup = 6105 "
            '   sql.WizCountRunQuery(SqlString)
            RepositoryRepairAccount.DataSource = sql.SQLDS.Tables(0)
            RepositoryRepairAccount.DisplayMember = "FullName"
            RepositoryRepairAccount.ValueMember = "AccountKey"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        GridControl1.MainView = TileView1
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        GridControl1.MainView = GridView1
    End Sub


    Private Sub TileView1_ItemCustomize(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs) Handles TileView1.ItemCustomize
        'If CBool(TileView1.GetRowCellValue(e.RowHandle, TileViewColumn18)) = False Then
        '    e.Item.Elements(11).Image = My.Resources.Sold
        '    e.Item.Elements(11).Text = "مباعة"
        'Else
        '    e.Item.Elements(11).Text = "متوفرة"
        'End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim CarID As String = CType(Me.TileView1.GetRowCellValue(TileView1.FocusedRowHandle, "CarID"), String)
        '   My.Forms.CarsEdit.TextEditCarID.Text = CarID
        '   My.Forms.CarsEdit.Show()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        If CStr(RadioGroup1.EditValue) = "Grid" Then GridControl1.MainView = GridView1
        If CStr(RadioGroup1.EditValue) = "Cards" Then GridControl1.MainView = TileView1
    End Sub

    Private Sub RepositorySort_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles RepositorySort.QueryPopUp
        '   Me.CarsSortTableAdapter.Fill(Me.CRMDataSet.CarsSort)
    End Sub

    Private Sub RepositoryRepairAccount_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles RepositoryRepairAccount.QueryPopUp
        '   Me.Accounts1TableAdapter.Fill(Me.WizCountDataSet.Accounts1)
    End Sub

    Private Sub RepositoryMarka_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles RepositoryType.QueryPopUp
        GetCarsTypes()
    End Sub

    Private Sub RepositoryModel_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles RepositoryModel.QueryPopUp
        GetCarsModel()
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        CarRentLists.Show()
    End Sub

    Private Sub RadioGroup2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup2.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub GridView1_PrintInitialize(sender As System.Object,
            e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) _
            Handles GridView1.PrintInitialize
        Dim pb As DevExpress.XtraPrinting.PrintingSystemBase = CType(e.PrintingSystem, DevExpress.XtraPrinting.PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 1
        pb.PageSettings.RightMargin = 1
        pb.PageSettings.TopMargin = 1
        pb.PageSettings.BottomMargin = 1
        pb.Pages.AddRange(pb.Pages)
        pb.ContinuousPageNumbering = True
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        My.Forms.CarEdit.LabelFormName.Text = " اضافة مركبة جديدة "
        My.Forms.CarEdit.CheckActive.Checked = True
        My.Forms.CarEdit.TextSearchCarID.Text = -1
        My.Forms.CarEdit.TextCARNO.Select()
        If CarEdit.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshData()
        End If
    End Sub

    Private Sub TileView1_DoubleClick(sender As Object, e As EventArgs) Handles TileView1.DoubleClick
        Dim CarID As String = CType(Me.TileView1.GetRowCellValue(TileView1.FocusedRowHandle, "CarID"), String)
        My.Forms.CarEdit.TextSearchCarID.Text = CarID
        If CarEdit.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshData()
        End If
    End Sub
    Private Sub GetCarsTypes()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " SELECT [CarTypeID],[CarType]  FROM [dbo].[CarsTypes] "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            RepositoryType.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetCarsModel()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " SELECT [CarModelID],[CarModel]  FROM [dbo].[CarsModel] "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            RepositoryModel.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
End Class