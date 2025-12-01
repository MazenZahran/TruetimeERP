Public Class AssetsList
    Private Sub AssetsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.AssetsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub AssetsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.AssetsType' table. You can move, or remove it, as needed.
        DateEdit1.DateTime = Today
        'TODO: This line of code loads data into the 'AccountingDataSet.Assets' table. You can move, or remove it, as needed.
        Me.AssetsTableAdapter.Fill(Me.AccountingDataSet.Assets)
        Me.AssetsTypeTableAdapter.Fill(Me.AccountingDataSet.AssetsType)
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim F As New AssetsAddEdit
        With F
            .TextNewOld.Text = "New"
            .AssetNameTextEdit.Select()
            If .ShowDialog() <> DialogResult.OK Then
                GetAssets()
            End If
        End With
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        AssetsType.ShowDialog()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'Me.AssetsTableAdapter.Fill(Me.AccountingDataSet.Assets)
        GetAssets()
    End Sub
    Private Sub GetAssets()
        If Me.IsHandleCreated = True Then
            Me.AssetsTypeTableAdapter.Fill(Me.AccountingDataSet.AssetsType)
            Dim _ToDate As String = Format(DateEdit1.DateTime.AddDays(1), "yyyy-MM-dd")
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  A.[ID]
      ,[AssetCode]
      ,[AssetName]
      ,[AssetLocation]
      ,[DepreciationPercentage]
      ,[AssetType]
      ,A.[Notes]
      ,A.[ItemNo]
	  ,I.LastPurchaseDate As PurchaseDate
	  ,I.LastPurchasePrice  As Cost
      ,I.LastPurchasePrice  * (CONVERT(DECIMAL(7,2),DATEDIFF(day, I.LastPurchaseDate,'" & _ToDate & "'))/365) *( [DepreciationPercentage]/100) As DepThisYear
  FROM [dbo].[Assets] A
  left join Items I on A.ItemNo=I.ItemNo  "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Me.AssetsGridControl.DataSource = sql.SQLDS.Tables(0)
        End If

    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        Dim _ItemNo As String
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("ItemNo")) Then
            _ItemNo = GridView1.GetFocusedRowCellValue("ItemNo")
            Dim F As New AssetsAddEdit
            With F
                .TextNewOld.Text = "Old"
                .ItemNoTextEdit.Text = _ItemNo
                If .ShowDialog <> DialogResult.OK Then
                    GetAssets()
                End If
            End With
        End If
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        GetAssets()
    End Sub
End Class