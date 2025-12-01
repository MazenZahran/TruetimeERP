Namespace Win_Dashboards
    Partial Public Class Dashboard2
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.DashboardObjectDataSource1 = New DevExpress.DashboardCommon.DashboardObjectDataSource()
            Me.TrueAccountingDataSet1 = New TrueTime.TrueAccountingDataSet()
            Me.ItemsTableAdapter1 = New TrueTime.TrueAccountingDataSetTableAdapters.ItemsTableAdapter()
            CType(Me.DashboardObjectDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TrueAccountingDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'DashboardObjectDataSource1
            '
            Me.DashboardObjectDataSource1.ComponentName = "DashboardObjectDataSource1"
            Me.DashboardObjectDataSource1.DataMember = "Items"
            Me.DashboardObjectDataSource1.DataSource = Me.TrueAccountingDataSet1
            Me.DashboardObjectDataSource1.Name = "Object Data Source 1"
            '
            'TrueAccountingDataSet1
            '
            Me.TrueAccountingDataSet1.DataSetName = "TrueAccountingDataSet"
            Me.TrueAccountingDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'ItemsTableAdapter1
            '
            Me.ItemsTableAdapter1.ClearBeforeFill = True
            '
            'Dashboard2
            '
            Me.Title.Text = "Dashboard"
            CType(Me.DashboardObjectDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TrueAccountingDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents DashboardObjectDataSource1 As DevExpress.DashboardCommon.DashboardObjectDataSource
        Friend WithEvents TrueAccountingDataSet1 As TrueAccountingDataSet
        Friend WithEvents ItemsTableAdapter1 As TrueAccountingDataSetTableAdapters.ItemsTableAdapter

#End Region
    End Class
End Namespace