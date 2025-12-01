Public Class AttMonthlyAdjustmentSettings
    Private SqlString As String
    Private Sql As New SQLControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub AttMonthlyAdjustmentSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SrchAdditionTypeID.Properties.DataSource = Att_Get_AdditionsTypes_Table()
        Me.SrchDiscountTypeID.Properties.DataSource = Att_Get_DiscountsTypes_Table()
        Me.SrchAdditionTypeID.EditValue = Att_Get_DefualtAdditionTypeID()
        Me.SrchDiscountTypeID.EditValue = Att_Get_DefualtDiscountTypeID()
    End Sub
    Private Sub UpdateData()
        If Me.IsHandleCreated Then
            Sql.SqlTrueTimeRunQuery(" Update Settings set SettingValue = " & Me.SrchAdditionTypeID.EditValue & " Where SettingName='Att_DefualtAdditionTypeID'  ")
            Sql.SqlTrueTimeRunQuery(" Update Settings set SettingValue = " & Me.SrchDiscountTypeID.EditValue & " Where SettingName='Att_DefualtDiscountTypeID'  ")
            Me.Close()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UpdateData()
    End Sub
End Class