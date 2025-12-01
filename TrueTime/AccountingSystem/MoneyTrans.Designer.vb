<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MoneyTrans
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MoneyTrans))
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim AppearanceObject1 As DevExpress.Utils.AppearanceObject = New DevExpress.Utils.AppearanceObject()
        Dim ButtonImageOptions1 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Me.ColTransNoInJournal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SalesPerson = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView9 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TextRefBalance = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.DocCode = New DevExpress.XtraEditors.TextEdit()
        Me.TextOpenFrom = New DevExpress.XtraEditors.TextEdit()
        Me.TextDocIDQuery = New DevExpress.XtraEditors.TextEdit()
        Me.TotalDocAmount = New DevExpress.XtraEditors.TextEdit()
        Me.DocCheqsAmount = New DevExpress.XtraEditors.TextEdit()
        Me.CashAccount = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TextMultiCurrency = New DevExpress.XtraEditors.TextEdit()
        Me.DocCashAmount = New DevExpress.XtraEditors.TextEdit()
        Me.DocCurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.ExchangePrice = New DevExpress.XtraEditors.TextEdit()
        Me.TextAmountInRefCurr = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.ExchangePriceForReferanceAcc = New DevExpress.XtraEditors.TextEdit()
        Me.DocName = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextDocManualNo = New DevExpress.XtraEditors.TextEdit()
        Me.AccountForRefranace = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColAccNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAccName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocDate = New DevExpress.XtraEditors.DateEdit()
        Me.TextDocID = New DevExpress.XtraEditors.TextEdit()
        Me.DocCurrencyForReferanceAcc = New DevExpress.XtraEditors.LookUpEdit()
        Me.LookDocSort = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TextDocNotes = New DevExpress.XtraEditors.MemoEdit()
        Me.SearchChecksBoxAccount = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControlChecks = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.حذفالشيكToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.تكرارالشيكToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.كشفحركةللشيكToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridViewChecks = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColCheckNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryChekNo = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ColCheckDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCheksDocAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryCheksDocAmount = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryChecksCurrency = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColCheksExchangePrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCheckBaseCurrAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCheckCustAccountId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCheckCustBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryLookUpBanks = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColCheckCustBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryLookUpBranches = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColAccountBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEditAccountBank = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColFinancialAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocNoteByAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryAccountBank = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColBankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryBankAccountID = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.LookCostCenter = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControlCash = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColCashAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryColCashAcc = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColOtherAccName2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColOtherAccNo2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAccType2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCashDocCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryOtherAccCurrency = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColCashDocAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryCashDocAmount = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ColCashExchangePrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryCashExchangePrice = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ColCashBaseAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCashBaseCurrAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.TextReferanceName = New DevExpress.XtraEditors.TextEdit()
        Me.Referance = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefMobile = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutDocCode = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutDelete = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutSave = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutDocCurrency = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutHeader = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem12 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.TabbedControlGroup2 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutReferance = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutCostCenter = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabbedControlGroup3 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup7 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlSalesPerson = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutCheqsInAccount = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlSave = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem12 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem4 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem10 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem9 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonMinimize = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonMaximize = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonMDI = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonRestore = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem11 = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarInputDateTime = New DevExpress.XtraBars.BarStaticItem()
        Me.BarDeviceName = New DevExpress.XtraBars.BarStaticItem()
        Me.BarInputUser = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.DisabledCellEvents1 = New DevExpress.Utils.Behaviors.Common.DisabledCellEvents(Me.components)
        Me.BarSubItem3 = New DevExpress.XtraBars.BarSubItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SalesPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRefBalance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOpenFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocIDQuery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalDocAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocCheqsAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CashAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMultiCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocCashAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExchangePrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextAmountInRefCurr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExchangePriceForReferanceAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocManualNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountForRefranace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocCurrencyForReferanceAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookDocSort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchChecksBoxAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlChecks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridViewChecks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryChekNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCheksDocAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryChecksCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryLookUpBanks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryLookUpBranches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEditAccountBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryAccountBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBankAccountID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookCostCenter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlCash, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryColCashAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryOtherAccCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCashDocAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCashExchangePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextReferanceName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutDocCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutDocCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutReferance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutCostCenter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlSalesPerson, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutCheqsInAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColTransNoInJournal
        '
        Me.ColTransNoInJournal.AppearanceCell.Options.UseTextOptions = True
        Me.ColTransNoInJournal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColTransNoInJournal, "ColTransNoInJournal")
        Me.ColTransNoInJournal.FieldName = "TransNoInJournal"
        Me.ColTransNoInJournal.MinWidth = 17
        Me.ColTransNoInJournal.Name = "ColTransNoInJournal"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SalesPerson)
        Me.LayoutControl1.Controls.Add(Me.TextRefBalance)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton6)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton5)
        Me.LayoutControl1.Controls.Add(Me.DocCode)
        Me.LayoutControl1.Controls.Add(Me.TextOpenFrom)
        Me.LayoutControl1.Controls.Add(Me.TextDocIDQuery)
        Me.LayoutControl1.Controls.Add(Me.TotalDocAmount)
        Me.LayoutControl1.Controls.Add(Me.DocCheqsAmount)
        Me.LayoutControl1.Controls.Add(Me.CashAccount)
        Me.LayoutControl1.Controls.Add(Me.TextMultiCurrency)
        Me.LayoutControl1.Controls.Add(Me.DocCashAmount)
        Me.LayoutControl1.Controls.Add(Me.DocCurrency)
        Me.LayoutControl1.Controls.Add(Me.ExchangePrice)
        Me.LayoutControl1.Controls.Add(Me.TextAmountInRefCurr)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.ExchangePriceForReferanceAcc)
        Me.LayoutControl1.Controls.Add(Me.DocName)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.TextDocManualNo)
        Me.LayoutControl1.Controls.Add(Me.AccountForRefranace)
        Me.LayoutControl1.Controls.Add(Me.DocDate)
        Me.LayoutControl1.Controls.Add(Me.TextDocID)
        Me.LayoutControl1.Controls.Add(Me.DocCurrencyForReferanceAcc)
        Me.LayoutControl1.Controls.Add(Me.LookDocSort)
        Me.LayoutControl1.Controls.Add(Me.TextDocNotes)
        Me.LayoutControl1.Controls.Add(Me.SearchChecksBoxAccount)
        Me.LayoutControl1.Controls.Add(Me.GridControlChecks)
        Me.LayoutControl1.Controls.Add(Me.LookCostCenter)
        Me.LayoutControl1.Controls.Add(Me.GridControlCash)
        Me.LayoutControl1.Controls.Add(Me.DocStatus)
        Me.LayoutControl1.Controls.Add(Me.TextReferanceName)
        Me.LayoutControl1.Controls.Add(Me.Referance)
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem7, Me.LayoutControlItem25, Me.LayoutControlItem19, Me.LayoutControlItem24, Me.LayoutDocCode, Me.LayoutControlItem13, Me.LayoutDelete, Me.LayoutControlItem11, Me.LayoutSave, Me.LayoutControlItem14, Me.LayoutControlItem5, Me.LayoutControlItem15})
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1228, 239, 650, 400)
        Me.LayoutControl1.OptionsFocus.AllowFocusControlOnActivatedTabPage = True
        Me.LayoutControl1.OptionsFocus.AllowFocusControlOnLabelClick = True
        Me.LayoutControl1.OptionsFocus.EnableAutoTabOrder = False
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        '
        'SalesPerson
        '
        resources.ApplyResources(Me.SalesPerson, "SalesPerson")
        Me.SalesPerson.Name = "SalesPerson"
        Me.SalesPerson.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("SalesPerson.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.SalesPerson.Properties.DisplayMember = "EmployeeName"
        Me.SalesPerson.Properties.NullText = resources.GetString("SalesPerson.Properties.NullText")
        Me.SalesPerson.Properties.PopupView = Me.GridView9
        Me.SalesPerson.Properties.ValueMember = "EmployeeID"
        Me.SalesPerson.StyleController = Me.LayoutControl1
        '
        'GridView9
        '
        Me.GridView9.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3})
        Me.GridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView9.Name = "GridView9"
        Me.GridView9.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView9.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView9.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        resources.ApplyResources(Me.GridColumn2, "GridColumn2")
        Me.GridColumn2.FieldName = "EmployeeID"
        Me.GridColumn2.MaxWidth = 100
        Me.GridColumn2.MinWidth = 100
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        resources.ApplyResources(Me.GridColumn3, "GridColumn3")
        Me.GridColumn3.FieldName = "EmployeeName"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'TextRefBalance
        '
        resources.ApplyResources(Me.TextRefBalance, "TextRefBalance")
        Me.TextRefBalance.Name = "TextRefBalance"
        Me.TextRefBalance.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextRefBalance.Properties.MaskSettings.Set("mask", "n")
        Me.TextRefBalance.Properties.ReadOnly = True
        Me.TextRefBalance.Properties.UseMaskAsDisplayFormat = CType(resources.GetObject("TextRefBalance.Properties.UseMaskAsDisplayFormat"), Boolean)
        Me.TextRefBalance.StyleController = Me.LayoutControl1
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton6.Appearance.Options.UseBackColor = True
        Me.SimpleButton6.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.ok_32px
        resources.ApplyResources(Me.SimpleButton6, "SimpleButton6")
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.StyleController = Me.LayoutControl1
        '
        'SimpleButton5
        '
        resources.ApplyResources(Me.SimpleButton5, "SimpleButton5")
        Me.SimpleButton5.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton5.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.StyleController = Me.LayoutControl1
        '
        'DocCode
        '
        resources.ApplyResources(Me.DocCode, "DocCode")
        Me.DocCode.Name = "DocCode"
        Me.DocCode.StyleController = Me.LayoutControl1
        '
        'TextOpenFrom
        '
        resources.ApplyResources(Me.TextOpenFrom, "TextOpenFrom")
        Me.TextOpenFrom.Name = "TextOpenFrom"
        Me.TextOpenFrom.StyleController = Me.LayoutControl1
        '
        'TextDocIDQuery
        '
        resources.ApplyResources(Me.TextDocIDQuery, "TextDocIDQuery")
        Me.TextDocIDQuery.Name = "TextDocIDQuery"
        Me.TextDocIDQuery.StyleController = Me.LayoutControl1
        '
        'TotalDocAmount
        '
        resources.ApplyResources(Me.TotalDocAmount, "TotalDocAmount")
        Me.TotalDocAmount.Name = "TotalDocAmount"
        Me.TotalDocAmount.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TotalDocAmount.Properties.MaskSettings.Set("mask", "n")
        Me.TotalDocAmount.Properties.ReadOnly = True
        Me.TotalDocAmount.Properties.UseMaskAsDisplayFormat = CType(resources.GetObject("TotalDocAmount.Properties.UseMaskAsDisplayFormat"), Boolean)
        Me.TotalDocAmount.StyleController = Me.LayoutControl1
        '
        'DocCheqsAmount
        '
        resources.ApplyResources(Me.DocCheqsAmount, "DocCheqsAmount")
        Me.DocCheqsAmount.Name = "DocCheqsAmount"
        Me.DocCheqsAmount.Properties.BeepOnError = CType(resources.GetObject("DocCheqsAmount.Properties.BeepOnError"), Boolean)
        Me.DocCheqsAmount.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.DocCheqsAmount.Properties.MaskSettings.Set("mask", "n")
        Me.DocCheqsAmount.Properties.ReadOnly = True
        Me.DocCheqsAmount.Properties.UseMaskAsDisplayFormat = CType(resources.GetObject("DocCheqsAmount.Properties.UseMaskAsDisplayFormat"), Boolean)
        Me.DocCheqsAmount.StyleController = Me.LayoutControl1
        '
        'CashAccount
        '
        resources.ApplyResources(Me.CashAccount, "CashAccount")
        Me.CashAccount.Name = "CashAccount"
        Me.CashAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("CashAccount.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.CashAccount.Properties.DisplayMember = "AccName"
        Me.CashAccount.Properties.NullText = resources.GetString("CashAccount.Properties.NullText")
        Me.CashAccount.Properties.PopupView = Me.GridView6
        Me.CashAccount.Properties.ValueMember = "AccNo"
        Me.CashAccount.StyleController = Me.LayoutControl1
        '
        'GridView6
        '
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn10})
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        resources.ApplyResources(Me.GridColumn1, "GridColumn1")
        Me.GridColumn1.FieldName = "AccNo"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn10
        '
        resources.ApplyResources(Me.GridColumn10, "GridColumn10")
        Me.GridColumn10.FieldName = "AccName"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'TextMultiCurrency
        '
        resources.ApplyResources(Me.TextMultiCurrency, "TextMultiCurrency")
        Me.TextMultiCurrency.Name = "TextMultiCurrency"
        Me.TextMultiCurrency.StyleController = Me.LayoutControl1
        '
        'DocCashAmount
        '
        resources.ApplyResources(Me.DocCashAmount, "DocCashAmount")
        Me.DocCashAmount.Name = "DocCashAmount"
        Me.DocCashAmount.Properties.BeepOnError = CType(resources.GetObject("DocCashAmount.Properties.BeepOnError"), Boolean)
        Me.DocCashAmount.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.DocCashAmount.Properties.MaskSettings.Set("mask", "n")
        Me.DocCashAmount.Properties.UseMaskAsDisplayFormat = CType(resources.GetObject("DocCashAmount.Properties.UseMaskAsDisplayFormat"), Boolean)
        Me.DocCashAmount.StyleController = Me.LayoutControl1
        '
        'DocCurrency
        '
        resources.ApplyResources(Me.DocCurrency, "DocCurrency")
        Me.DocCurrency.Name = "DocCurrency"
        Me.DocCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DocCurrency.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DocCurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("DocCurrency.Properties.Columns"), resources.GetString("DocCurrency.Properties.Columns1"), CType(resources.GetObject("DocCurrency.Properties.Columns2"), Integer), CType(resources.GetObject("DocCurrency.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("DocCurrency.Properties.Columns4"), CType(resources.GetObject("DocCurrency.Properties.Columns5"), Boolean), CType(resources.GetObject("DocCurrency.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("DocCurrency.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("DocCurrency.Properties.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("DocCurrency.Properties.Columns9"), resources.GetString("DocCurrency.Properties.Columns10"))})
        Me.DocCurrency.Properties.DisplayMember = "Code"
        Me.DocCurrency.Properties.NullText = resources.GetString("DocCurrency.Properties.NullText")
        Me.DocCurrency.Properties.ValueMember = "CurrID"
        Me.DocCurrency.StyleController = Me.LayoutControl1
        '
        'ExchangePrice
        '
        resources.ApplyResources(Me.ExchangePrice, "ExchangePrice")
        Me.ExchangePrice.Name = "ExchangePrice"
        Me.ExchangePrice.Properties.BeepOnError = CType(resources.GetObject("ExchangePrice.Properties.BeepOnError"), Boolean)
        Me.ExchangePrice.Properties.UseMaskAsDisplayFormat = CType(resources.GetObject("ExchangePrice.Properties.UseMaskAsDisplayFormat"), Boolean)
        Me.ExchangePrice.StyleController = Me.LayoutControl1
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Between
        ConditionValidationRule1.ErrorText = "This value is not valid"
        ConditionValidationRule1.Value1 = New Decimal(New Integer() {1, 0, 0, 327680})
        ConditionValidationRule1.Value2 = New Decimal(New Integer() {999999999, 0, 0, 65536})
        Me.DxValidationProvider1.SetValidationRule(Me.ExchangePrice, ConditionValidationRule1)
        '
        'TextAmountInRefCurr
        '
        resources.ApplyResources(Me.TextAmountInRefCurr, "TextAmountInRefCurr")
        Me.TextAmountInRefCurr.Name = "TextAmountInRefCurr"
        Me.TextAmountInRefCurr.Properties.DisplayFormat.FormatString = "n2"
        Me.TextAmountInRefCurr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextAmountInRefCurr.Properties.ReadOnly = True
        Me.TextAmountInRefCurr.StyleController = Me.LayoutControl1
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton3.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        resources.ApplyResources(Me.SimpleButton3, "SimpleButton3")
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.StyleController = Me.LayoutControl1
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        '
        'ExchangePriceForReferanceAcc
        '
        resources.ApplyResources(Me.ExchangePriceForReferanceAcc, "ExchangePriceForReferanceAcc")
        Me.ExchangePriceForReferanceAcc.Name = "ExchangePriceForReferanceAcc"
        Me.ExchangePriceForReferanceAcc.Properties.ReadOnly = True
        Me.ExchangePriceForReferanceAcc.StyleController = Me.LayoutControl1
        '
        'DocName
        '
        resources.ApplyResources(Me.DocName, "DocName")
        Me.DocName.Name = "DocName"
        Me.DocName.Properties.ReadOnly = True
        Me.DocName.StyleController = Me.LayoutControl1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        '
        'TextDocManualNo
        '
        resources.ApplyResources(Me.TextDocManualNo, "TextDocManualNo")
        Me.TextDocManualNo.Name = "TextDocManualNo"
        Me.TextDocManualNo.Properties.MaxLength = 20
        Me.TextDocManualNo.StyleController = Me.LayoutControl1
        '
        'AccountForRefranace
        '
        resources.ApplyResources(Me.AccountForRefranace, "AccountForRefranace")
        Me.AccountForRefranace.Name = "AccountForRefranace"
        Me.AccountForRefranace.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("AccountForRefranace.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.AccountForRefranace.Properties.DisplayMember = "AccName"
        Me.AccountForRefranace.Properties.NullText = resources.GetString("AccountForRefranace.Properties.NullText")
        Me.AccountForRefranace.Properties.NullValuePrompt = resources.GetString("AccountForRefranace.Properties.NullValuePrompt")
        Me.AccountForRefranace.Properties.PopupView = Me.GridView3
        Me.AccountForRefranace.Properties.ValueMember = "AccNo"
        Me.AccountForRefranace.StyleController = Me.LayoutControl1
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColAccNo, Me.ColAccName})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'ColAccNo
        '
        resources.ApplyResources(Me.ColAccNo, "ColAccNo")
        Me.ColAccNo.FieldName = "AccNo"
        Me.ColAccNo.Name = "ColAccNo"
        '
        'ColAccName
        '
        resources.ApplyResources(Me.ColAccName, "ColAccName")
        Me.ColAccName.FieldName = "AccName"
        Me.ColAccName.Name = "ColAccName"
        '
        'DocDate
        '
        resources.ApplyResources(Me.DocDate, "DocDate")
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DocDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DocDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DocDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DocDate.StyleController = Me.LayoutControl1
        '
        'TextDocID
        '
        resources.ApplyResources(Me.TextDocID, "TextDocID")
        Me.TextDocID.Name = "TextDocID"
        Me.TextDocID.Properties.ReadOnly = True
        Me.TextDocID.StyleController = Me.LayoutControl1
        '
        'DocCurrencyForReferanceAcc
        '
        resources.ApplyResources(Me.DocCurrencyForReferanceAcc, "DocCurrencyForReferanceAcc")
        Me.DocCurrencyForReferanceAcc.Name = "DocCurrencyForReferanceAcc"
        Me.DocCurrencyForReferanceAcc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DocCurrencyForReferanceAcc.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DocCurrencyForReferanceAcc.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("DocCurrencyForReferanceAcc.Properties.Columns"), resources.GetString("DocCurrencyForReferanceAcc.Properties.Columns1"), CType(resources.GetObject("DocCurrencyForReferanceAcc.Properties.Columns2"), Integer), CType(resources.GetObject("DocCurrencyForReferanceAcc.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("DocCurrencyForReferanceAcc.Properties.Columns4"), CType(resources.GetObject("DocCurrencyForReferanceAcc.Properties.Columns5"), Boolean), CType(resources.GetObject("DocCurrencyForReferanceAcc.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("DocCurrencyForReferanceAcc.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("DocCurrencyForReferanceAcc.Properties.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("DocCurrencyForReferanceAcc.Properties.Columns9"), resources.GetString("DocCurrencyForReferanceAcc.Properties.Columns10"))})
        Me.DocCurrencyForReferanceAcc.Properties.DisplayMember = "Code"
        Me.DocCurrencyForReferanceAcc.Properties.NullText = resources.GetString("DocCurrencyForReferanceAcc.Properties.NullText")
        Me.DocCurrencyForReferanceAcc.Properties.ReadOnly = True
        Me.DocCurrencyForReferanceAcc.Properties.ValueMember = "CurrID"
        Me.DocCurrencyForReferanceAcc.StyleController = Me.LayoutControl1
        '
        'LookDocSort
        '
        resources.ApplyResources(Me.LookDocSort, "LookDocSort")
        Me.LookDocSort.Name = "LookDocSort"
        Me.LookDocSort.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookDocSort.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookDocSort.Properties.DisplayMember = "SortName"
        Me.LookDocSort.Properties.NullText = resources.GetString("LookDocSort.Properties.NullText")
        Me.LookDocSort.Properties.PopupView = Me.GridView4
        Me.LookDocSort.Properties.ValueMember = "SortID"
        Me.LookDocSort.StyleController = Me.LayoutControl1
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'TextDocNotes
        '
        resources.ApplyResources(Me.TextDocNotes, "TextDocNotes")
        Me.TextDocNotes.Name = "TextDocNotes"
        Me.TextDocNotes.StyleController = Me.LayoutControl1
        '
        'SearchChecksBoxAccount
        '
        resources.ApplyResources(Me.SearchChecksBoxAccount, "SearchChecksBoxAccount")
        Me.SearchChecksBoxAccount.Name = "SearchChecksBoxAccount"
        Me.SearchChecksBoxAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("SearchChecksBoxAccount.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.SearchChecksBoxAccount.Properties.DisplayMember = "AccName"
        Me.SearchChecksBoxAccount.Properties.NullText = resources.GetString("SearchChecksBoxAccount.Properties.NullText")
        Me.SearchChecksBoxAccount.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchChecksBoxAccount.Properties.ValueMember = "AccNo"
        Me.SearchChecksBoxAccount.StyleController = Me.LayoutControl1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn11})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 686
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        resources.ApplyResources(Me.GridColumn9, "GridColumn9")
        Me.GridColumn9.FieldName = "AccNo"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn11
        '
        resources.ApplyResources(Me.GridColumn11, "GridColumn11")
        Me.GridColumn11.FieldName = "AccName"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridControlChecks
        '
        Me.GridControlChecks.ContextMenuStrip = Me.ContextMenuStrip1
        resources.ApplyResources(Me.GridControlChecks, "GridControlChecks")
        Me.GridControlChecks.MainView = Me.GridViewChecks
        Me.GridControlChecks.Name = "GridControlChecks"
        Me.GridControlChecks.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryChecksCurrency, Me.RepositoryCheksDocAmount, Me.RepositoryChekNo, Me.RepositoryAccountBank, Me.RepositoryBankAccountID, Me.RepositoryLookUpBranches, Me.RepositoryLookUpBanks, Me.RepositoryItemLookUpEditAccountBank})
        Me.GridControlChecks.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewChecks})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.حذفالشيكToolStripMenuItem, Me.تكرارالشيكToolStripMenuItem, Me.كشفحركةللشيكToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'حذفالشيكToolStripMenuItem
        '
        Me.حذفالشيكToolStripMenuItem.Image = Global.TrueTime.My.Resources.Resources.remove_48px
        Me.حذفالشيكToolStripMenuItem.Name = "حذفالشيكToolStripMenuItem"
        resources.ApplyResources(Me.حذفالشيكToolStripMenuItem, "حذفالشيكToolStripMenuItem")
        '
        'تكرارالشيكToolStripMenuItem
        '
        Me.تكرارالشيكToolStripMenuItem.Image = Global.TrueTime.My.Resources.Resources.add_48px
        Me.تكرارالشيكToolStripMenuItem.Name = "تكرارالشيكToolStripMenuItem"
        resources.ApplyResources(Me.تكرارالشيكToolStripMenuItem, "تكرارالشيكToolStripMenuItem")
        '
        'كشفحركةللشيكToolStripMenuItem
        '
        Me.كشفحركةللشيكToolStripMenuItem.Image = Global.TrueTime.My.Resources.Resources.grid_view_48px
        Me.كشفحركةللشيكToolStripMenuItem.Name = "كشفحركةللشيكToolStripMenuItem"
        resources.ApplyResources(Me.كشفحركةللشيكToolStripMenuItem, "كشفحركةللشيكToolStripMenuItem")
        '
        'GridViewChecks
        '
        Me.BehaviorManager1.SetBehaviors(Me.GridViewChecks, New DevExpress.Utils.Behaviors.Behavior() {CType(DevExpress.Utils.Behaviors.Common.DisabledCellBehavior.Create(GetType(DevExpress.XtraGrid.Extensions.GridViewDisabledCellSource), "[TransNoInJournal] > 1", AppearanceObject1, Me.DisabledCellEvents1), DevExpress.Utils.Behaviors.Behavior)})
        Me.GridViewChecks.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColCheckNo, Me.ColCheckDueDate, Me.ColCheksDocAmount, Me.GridColumn5, Me.ColCheksExchangePrice, Me.GridColumn7, Me.ColCheckBaseCurrAmount, Me.ColCheckCustAccountId, Me.ColCheckCustBank, Me.ColCheckCustBranch, Me.ColAccountBank, Me.ColFinancialAccount, Me.GridColumn6, Me.ColTransNoInJournal, Me.ColDocNoteByAccount})
        Me.GridViewChecks.GridControl = Me.GridControlChecks
        Me.GridViewChecks.Name = "GridViewChecks"
        Me.GridViewChecks.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
        Me.GridViewChecks.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append
        Me.GridViewChecks.OptionsCustomization.AllowFilter = False
        Me.GridViewChecks.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridViewChecks.OptionsFind.AllowFindPanel = False
        Me.GridViewChecks.OptionsNavigation.AutoFocusNewRow = True
        Me.GridViewChecks.OptionsView.EnableAppearanceEvenRow = True
        Me.GridViewChecks.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridViewChecks.OptionsView.ShowGroupPanel = False
        Me.GridViewChecks.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'ColCheckNo
        '
        Me.ColCheckNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColCheckNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColCheckNo, "ColCheckNo")
        Me.ColCheckNo.ColumnEdit = Me.RepositoryChekNo
        Me.ColCheckNo.FieldName = "CheckNo"
        Me.ColCheckNo.Name = "ColCheckNo"
        '
        'RepositoryChekNo
        '
        resources.ApplyResources(Me.RepositoryChekNo, "RepositoryChekNo")
        Me.RepositoryChekNo.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.RepositoryChekNo.MaskSettings.Set("mask", "d")
        Me.RepositoryChekNo.Name = "RepositoryChekNo"
        '
        'ColCheckDueDate
        '
        Me.ColCheckDueDate.AppearanceCell.Options.UseTextOptions = True
        Me.ColCheckDueDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColCheckDueDate, "ColCheckDueDate")
        Me.ColCheckDueDate.FieldName = "CheckDueDate"
        Me.ColCheckDueDate.Name = "ColCheckDueDate"
        '
        'ColCheksDocAmount
        '
        Me.ColCheksDocAmount.AppearanceCell.Options.UseTextOptions = True
        Me.ColCheksDocAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColCheksDocAmount, "ColCheksDocAmount")
        Me.ColCheksDocAmount.ColumnEdit = Me.RepositoryCheksDocAmount
        Me.ColCheksDocAmount.FieldName = "DocAmount"
        Me.ColCheksDocAmount.Name = "ColCheksDocAmount"
        Me.ColCheksDocAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("ColCheksDocAmount.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("ColCheksDocAmount.Summary1"), resources.GetString("ColCheksDocAmount.Summary2"))})
        '
        'RepositoryCheksDocAmount
        '
        resources.ApplyResources(Me.RepositoryCheksDocAmount, "RepositoryCheksDocAmount")
        Me.RepositoryCheksDocAmount.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.RepositoryCheksDocAmount.MaskSettings.Set("mask", "n")
        Me.RepositoryCheksDocAmount.Name = "RepositoryCheksDocAmount"
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.GridColumn5, "GridColumn5")
        Me.GridColumn5.ColumnEdit = Me.RepositoryChecksCurrency
        Me.GridColumn5.FieldName = "DocCheksCurr"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'RepositoryChecksCurrency
        '
        resources.ApplyResources(Me.RepositoryChecksCurrency, "RepositoryChecksCurrency")
        Me.RepositoryChecksCurrency.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryChecksCurrency.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryChecksCurrency.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryChecksCurrency.Columns"), resources.GetString("RepositoryChecksCurrency.Columns1"), CType(resources.GetObject("RepositoryChecksCurrency.Columns2"), Integer), CType(resources.GetObject("RepositoryChecksCurrency.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryChecksCurrency.Columns4"), CType(resources.GetObject("RepositoryChecksCurrency.Columns5"), Boolean), CType(resources.GetObject("RepositoryChecksCurrency.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryChecksCurrency.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryChecksCurrency.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryChecksCurrency.Columns9"), resources.GetString("RepositoryChecksCurrency.Columns10"))})
        Me.RepositoryChecksCurrency.DisplayMember = "Code"
        Me.RepositoryChecksCurrency.Name = "RepositoryChecksCurrency"
        Me.RepositoryChecksCurrency.ValueMember = "CurrID"
        '
        'ColCheksExchangePrice
        '
        Me.ColCheksExchangePrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColCheksExchangePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColCheksExchangePrice, "ColCheksExchangePrice")
        Me.ColCheksExchangePrice.FieldName = "ExchangePrice"
        Me.ColCheksExchangePrice.Name = "ColCheksExchangePrice"
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.GridColumn7, "GridColumn7")
        Me.GridColumn7.FieldName = "BaseAmount"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'ColCheckBaseCurrAmount
        '
        Me.ColCheckBaseCurrAmount.AppearanceCell.Options.UseTextOptions = True
        Me.ColCheckBaseCurrAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColCheckBaseCurrAmount, "ColCheckBaseCurrAmount")
        Me.ColCheckBaseCurrAmount.FieldName = "BaseCurrAmount"
        Me.ColCheckBaseCurrAmount.Name = "ColCheckBaseCurrAmount"
        Me.ColCheckBaseCurrAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("ColCheckBaseCurrAmount.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("ColCheckBaseCurrAmount.Summary1"), resources.GetString("ColCheckBaseCurrAmount.Summary2"))})
        '
        'ColCheckCustAccountId
        '
        Me.ColCheckCustAccountId.AppearanceCell.Options.UseTextOptions = True
        Me.ColCheckCustAccountId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColCheckCustAccountId, "ColCheckCustAccountId")
        Me.ColCheckCustAccountId.FieldName = "CheckCustAccountId"
        Me.ColCheckCustAccountId.Name = "ColCheckCustAccountId"
        '
        'ColCheckCustBank
        '
        Me.ColCheckCustBank.AppearanceCell.Options.UseTextOptions = True
        Me.ColCheckCustBank.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColCheckCustBank, "ColCheckCustBank")
        Me.ColCheckCustBank.ColumnEdit = Me.RepositoryLookUpBanks
        Me.ColCheckCustBank.FieldName = "CheckCustBank"
        Me.ColCheckCustBank.Name = "ColCheckCustBank"
        '
        'RepositoryLookUpBanks
        '
        Me.RepositoryLookUpBanks.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.RepositoryLookUpBanks, "RepositoryLookUpBanks")
        Me.RepositoryLookUpBanks.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryLookUpBanks.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryLookUpBanks.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryLookUpBanks.Columns"), resources.GetString("RepositoryLookUpBanks.Columns1"), CType(resources.GetObject("RepositoryLookUpBanks.Columns2"), Integer), CType(resources.GetObject("RepositoryLookUpBanks.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryLookUpBanks.Columns4"), CType(resources.GetObject("RepositoryLookUpBanks.Columns5"), Boolean), CType(resources.GetObject("RepositoryLookUpBanks.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryLookUpBanks.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryLookUpBanks.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryLookUpBanks.Columns9"), resources.GetString("RepositoryLookUpBanks.Columns10"), CType(resources.GetObject("RepositoryLookUpBanks.Columns11"), Integer), CType(resources.GetObject("RepositoryLookUpBanks.Columns12"), DevExpress.Utils.FormatType), resources.GetString("RepositoryLookUpBanks.Columns13"), CType(resources.GetObject("RepositoryLookUpBanks.Columns14"), Boolean), CType(resources.GetObject("RepositoryLookUpBanks.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryLookUpBanks.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryLookUpBanks.Columns17"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryLookUpBanks.Columns18"), resources.GetString("RepositoryLookUpBanks.Columns19"), CType(resources.GetObject("RepositoryLookUpBanks.Columns20"), Integer), CType(resources.GetObject("RepositoryLookUpBanks.Columns21"), DevExpress.Utils.FormatType), resources.GetString("RepositoryLookUpBanks.Columns22"), CType(resources.GetObject("RepositoryLookUpBanks.Columns23"), Boolean), CType(resources.GetObject("RepositoryLookUpBanks.Columns24"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryLookUpBanks.Columns25"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryLookUpBanks.Columns26"), DevExpress.Utils.DefaultBoolean))})
        Me.RepositoryLookUpBanks.DisplayMember = "BankName"
        Me.RepositoryLookUpBanks.Name = "RepositoryLookUpBanks"
        Me.RepositoryLookUpBanks.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch
        Me.RepositoryLookUpBanks.ValueMember = "ID"
        '
        'ColCheckCustBranch
        '
        Me.ColCheckCustBranch.AppearanceCell.Options.UseTextOptions = True
        Me.ColCheckCustBranch.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColCheckCustBranch, "ColCheckCustBranch")
        Me.ColCheckCustBranch.ColumnEdit = Me.RepositoryLookUpBranches
        Me.ColCheckCustBranch.FieldName = "CheckCustBranch"
        Me.ColCheckCustBranch.Name = "ColCheckCustBranch"
        '
        'RepositoryLookUpBranches
        '
        Me.RepositoryLookUpBranches.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.RepositoryLookUpBranches, "RepositoryLookUpBranches")
        Me.RepositoryLookUpBranches.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryLookUpBranches.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryLookUpBranches.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryLookUpBranches.Columns"), resources.GetString("RepositoryLookUpBranches.Columns1"), CType(resources.GetObject("RepositoryLookUpBranches.Columns2"), Integer), CType(resources.GetObject("RepositoryLookUpBranches.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryLookUpBranches.Columns4"), CType(resources.GetObject("RepositoryLookUpBranches.Columns5"), Boolean), CType(resources.GetObject("RepositoryLookUpBranches.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryLookUpBranches.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryLookUpBranches.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryLookUpBranches.Columns9"), resources.GetString("RepositoryLookUpBranches.Columns10"), CType(resources.GetObject("RepositoryLookUpBranches.Columns11"), Integer), CType(resources.GetObject("RepositoryLookUpBranches.Columns12"), DevExpress.Utils.FormatType), resources.GetString("RepositoryLookUpBranches.Columns13"), CType(resources.GetObject("RepositoryLookUpBranches.Columns14"), Boolean), CType(resources.GetObject("RepositoryLookUpBranches.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryLookUpBranches.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryLookUpBranches.Columns17"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryLookUpBranches.Columns18"), resources.GetString("RepositoryLookUpBranches.Columns19"), CType(resources.GetObject("RepositoryLookUpBranches.Columns20"), Integer), CType(resources.GetObject("RepositoryLookUpBranches.Columns21"), DevExpress.Utils.FormatType), resources.GetString("RepositoryLookUpBranches.Columns22"), CType(resources.GetObject("RepositoryLookUpBranches.Columns23"), Boolean), CType(resources.GetObject("RepositoryLookUpBranches.Columns24"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryLookUpBranches.Columns25"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryLookUpBranches.Columns26"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryLookUpBranches.Columns27"), resources.GetString("RepositoryLookUpBranches.Columns28"), CType(resources.GetObject("RepositoryLookUpBranches.Columns29"), Integer), CType(resources.GetObject("RepositoryLookUpBranches.Columns30"), DevExpress.Utils.FormatType), resources.GetString("RepositoryLookUpBranches.Columns31"), CType(resources.GetObject("RepositoryLookUpBranches.Columns32"), Boolean), CType(resources.GetObject("RepositoryLookUpBranches.Columns33"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryLookUpBranches.Columns34"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryLookUpBranches.Columns35"), DevExpress.Utils.DefaultBoolean))})
        Me.RepositoryLookUpBranches.DisplayMember = "BranchName"
        Me.RepositoryLookUpBranches.Name = "RepositoryLookUpBranches"
        Me.RepositoryLookUpBranches.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSuggest
        Me.RepositoryLookUpBranches.ValueMember = "ID"
        '
        'ColAccountBank
        '
        Me.ColAccountBank.AppearanceCell.Options.UseTextOptions = True
        Me.ColAccountBank.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColAccountBank, "ColAccountBank")
        Me.ColAccountBank.ColumnEdit = Me.RepositoryItemLookUpEditAccountBank
        Me.ColAccountBank.FieldName = "AccountBank"
        Me.ColAccountBank.Name = "ColAccountBank"
        '
        'RepositoryItemLookUpEditAccountBank
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEditAccountBank, "RepositoryItemLookUpEditAccountBank")
        Me.RepositoryItemLookUpEditAccountBank.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEditAccountBank.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryItemLookUpEditAccountBank.Columns"), resources.GetString("RepositoryItemLookUpEditAccountBank.Columns1"), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns2"), Integer), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryItemLookUpEditAccountBank.Columns4"), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns5"), Boolean), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryItemLookUpEditAccountBank.Columns9"), resources.GetString("RepositoryItemLookUpEditAccountBank.Columns10"), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns11"), Integer), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns12"), DevExpress.Utils.FormatType), resources.GetString("RepositoryItemLookUpEditAccountBank.Columns13"), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns14"), Boolean), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryItemLookUpEditAccountBank.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.RepositoryItemLookUpEditAccountBank.DisplayMember = "BankName"
        Me.RepositoryItemLookUpEditAccountBank.Name = "RepositoryItemLookUpEditAccountBank"
        Me.RepositoryItemLookUpEditAccountBank.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSuggest
        Me.RepositoryItemLookUpEditAccountBank.ShowFooter = False
        Me.RepositoryItemLookUpEditAccountBank.ShowLines = False
        Me.RepositoryItemLookUpEditAccountBank.ValueMember = "ID"
        '
        'ColFinancialAccount
        '
        Me.ColFinancialAccount.AppearanceCell.Options.UseTextOptions = True
        Me.ColFinancialAccount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColFinancialAccount, "ColFinancialAccount")
        Me.ColFinancialAccount.FieldName = "FinancialAccount"
        Me.ColFinancialAccount.Name = "ColFinancialAccount"
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.GridColumn6, "GridColumn6")
        Me.GridColumn6.FieldName = "CheckCode"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'ColDocNoteByAccount
        '
        Me.ColDocNoteByAccount.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocNoteByAccount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocNoteByAccount, "ColDocNoteByAccount")
        Me.ColDocNoteByAccount.FieldName = "DocNoteByAccount"
        Me.ColDocNoteByAccount.Name = "ColDocNoteByAccount"
        '
        'RepositoryAccountBank
        '
        resources.ApplyResources(Me.RepositoryAccountBank, "RepositoryAccountBank")
        Me.RepositoryAccountBank.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryAccountBank.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryAccountBank.DisplayMember = "BankName"
        Me.RepositoryAccountBank.Name = "RepositoryAccountBank"
        Me.RepositoryAccountBank.PopupView = Me.GridView7
        Me.RepositoryAccountBank.ValueMember = "ID"
        '
        'GridView7
        '
        Me.GridView7.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColBankName, Me.GridColumn4})
        Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView7.Name = "GridView7"
        Me.GridView7.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView7.OptionsView.ShowGroupPanel = False
        '
        'ColBankName
        '
        resources.ApplyResources(Me.ColBankName, "ColBankName")
        Me.ColBankName.FieldName = "BankName"
        Me.ColBankName.Name = "ColBankName"
        '
        'GridColumn4
        '
        resources.ApplyResources(Me.GridColumn4, "GridColumn4")
        Me.GridColumn4.FieldName = "ID"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'RepositoryBankAccountID
        '
        resources.ApplyResources(Me.RepositoryBankAccountID, "RepositoryBankAccountID")
        Me.RepositoryBankAccountID.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.RepositoryBankAccountID.MaskSettings.Set("mask", "d")
        Me.RepositoryBankAccountID.Name = "RepositoryBankAccountID"
        '
        'LookCostCenter
        '
        resources.ApplyResources(Me.LookCostCenter, "LookCostCenter")
        Me.LookCostCenter.Name = "LookCostCenter"
        Me.LookCostCenter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookCostCenter.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookCostCenter.Properties.DisplayMember = "CostName"
        Me.LookCostCenter.Properties.NullText = resources.GetString("LookCostCenter.Properties.NullText")
        Me.LookCostCenter.Properties.NullValuePrompt = resources.GetString("LookCostCenter.Properties.NullValuePrompt")
        Me.LookCostCenter.Properties.PopupView = Me.GridView8
        Me.LookCostCenter.Properties.ValueMember = "CostID"
        Me.LookCostCenter.StyleController = Me.LayoutControl1
        '
        'GridView8
        '
        Me.GridView8.DetailHeight = 284
        Me.GridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView8.Name = "GridView8"
        Me.GridView8.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView8.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView8.OptionsView.ShowGroupPanel = False
        '
        'GridControlCash
        '
        resources.ApplyResources(Me.GridControlCash, "GridControlCash")
        Me.GridControlCash.MainView = Me.GridView2
        Me.GridControlCash.Name = "GridControlCash"
        Me.GridControlCash.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryColCashAcc, Me.RepositoryOtherAccCurrency, Me.RepositoryCashDocAmount, Me.RepositoryCashExchangePrice})
        Me.GridControlCash.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColCashAcc, Me.ColCashDocCurrency, Me.ColCashDocAmount, Me.ColCashExchangePrice, Me.ColCashBaseAmount, Me.ColCashBaseCurrAmount, Me.ColDocCurrency})
        Me.GridView2.GridControl = Me.GridControlCash
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'ColCashAcc
        '
        resources.ApplyResources(Me.ColCashAcc, "ColCashAcc")
        Me.ColCashAcc.ColumnEdit = Me.RepositoryColCashAcc
        Me.ColCashAcc.FieldName = "DebitCredAcc"
        Me.ColCashAcc.Name = "ColCashAcc"
        '
        'RepositoryColCashAcc
        '
        resources.ApplyResources(Me.RepositoryColCashAcc, "RepositoryColCashAcc")
        Me.RepositoryColCashAcc.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryColCashAcc.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryColCashAcc.DisplayMember = "AccName"
        Me.RepositoryColCashAcc.Name = "RepositoryColCashAcc"
        Me.RepositoryColCashAcc.PopupView = Me.RepositoryItemSearchLookUpEdit1View
        Me.RepositoryColCashAcc.ValueMember = "AccNo"
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColOtherAccName2, Me.ColOtherAccNo2, Me.ColAccType2})
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 686
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'ColOtherAccName2
        '
        resources.ApplyResources(Me.ColOtherAccName2, "ColOtherAccName2")
        Me.ColOtherAccName2.FieldName = "AccName"
        Me.ColOtherAccName2.Name = "ColOtherAccName2"
        '
        'ColOtherAccNo2
        '
        resources.ApplyResources(Me.ColOtherAccNo2, "ColOtherAccNo2")
        Me.ColOtherAccNo2.FieldName = "AccNo"
        Me.ColOtherAccNo2.Name = "ColOtherAccNo2"
        '
        'ColAccType2
        '
        resources.ApplyResources(Me.ColAccType2, "ColAccType2")
        Me.ColAccType2.FieldName = "AccType"
        Me.ColAccType2.Name = "ColAccType2"
        '
        'ColCashDocCurrency
        '
        resources.ApplyResources(Me.ColCashDocCurrency, "ColCashDocCurrency")
        Me.ColCashDocCurrency.ColumnEdit = Me.RepositoryOtherAccCurrency
        Me.ColCashDocCurrency.FieldName = "AccountCurr"
        Me.ColCashDocCurrency.Name = "ColCashDocCurrency"
        Me.ColCashDocCurrency.OptionsColumn.ReadOnly = True
        '
        'RepositoryOtherAccCurrency
        '
        resources.ApplyResources(Me.RepositoryOtherAccCurrency, "RepositoryOtherAccCurrency")
        Me.RepositoryOtherAccCurrency.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryOtherAccCurrency.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryOtherAccCurrency.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryOtherAccCurrency.Columns"), resources.GetString("RepositoryOtherAccCurrency.Columns1"), CType(resources.GetObject("RepositoryOtherAccCurrency.Columns2"), Integer), CType(resources.GetObject("RepositoryOtherAccCurrency.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryOtherAccCurrency.Columns4"), CType(resources.GetObject("RepositoryOtherAccCurrency.Columns5"), Boolean), CType(resources.GetObject("RepositoryOtherAccCurrency.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryOtherAccCurrency.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryOtherAccCurrency.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryOtherAccCurrency.Columns9"), resources.GetString("RepositoryOtherAccCurrency.Columns10"))})
        Me.RepositoryOtherAccCurrency.DisplayMember = "Code"
        Me.RepositoryOtherAccCurrency.Name = "RepositoryOtherAccCurrency"
        Me.RepositoryOtherAccCurrency.ValueMember = "CurrID"
        '
        'ColCashDocAmount
        '
        resources.ApplyResources(Me.ColCashDocAmount, "ColCashDocAmount")
        Me.ColCashDocAmount.ColumnEdit = Me.RepositoryCashDocAmount
        Me.ColCashDocAmount.FieldName = "DocAmount"
        Me.ColCashDocAmount.Name = "ColCashDocAmount"
        '
        'RepositoryCashDocAmount
        '
        resources.ApplyResources(Me.RepositoryCashDocAmount, "RepositoryCashDocAmount")
        Me.RepositoryCashDocAmount.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.RepositoryCashDocAmount.MaskSettings.Set("MaskManagerSignature", "allowNull=False")
        Me.RepositoryCashDocAmount.MaskSettings.Set("mask", "n")
        Me.RepositoryCashDocAmount.Name = "RepositoryCashDocAmount"
        Me.RepositoryCashDocAmount.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        '
        'ColCashExchangePrice
        '
        resources.ApplyResources(Me.ColCashExchangePrice, "ColCashExchangePrice")
        Me.ColCashExchangePrice.ColumnEdit = Me.RepositoryCashExchangePrice
        Me.ColCashExchangePrice.FieldName = "ExchangePrice"
        Me.ColCashExchangePrice.Name = "ColCashExchangePrice"
        '
        'RepositoryCashExchangePrice
        '
        resources.ApplyResources(Me.RepositoryCashExchangePrice, "RepositoryCashExchangePrice")
        Me.RepositoryCashExchangePrice.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.RepositoryCashExchangePrice.MaskSettings.Set("MaskManagerSignature", "allowNull=False")
        Me.RepositoryCashExchangePrice.MaskSettings.Set("mask", "n3")
        Me.RepositoryCashExchangePrice.MaskSettings.Set("hideInsignificantZeros", True)
        Me.RepositoryCashExchangePrice.Name = "RepositoryCashExchangePrice"
        Me.RepositoryCashExchangePrice.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        '
        'ColCashBaseAmount
        '
        resources.ApplyResources(Me.ColCashBaseAmount, "ColCashBaseAmount")
        Me.ColCashBaseAmount.FieldName = "BaseAmount"
        Me.ColCashBaseAmount.Name = "ColCashBaseAmount"
        '
        'ColCashBaseCurrAmount
        '
        resources.ApplyResources(Me.ColCashBaseCurrAmount, "ColCashBaseCurrAmount")
        Me.ColCashBaseCurrAmount.FieldName = "BaseCurrAmount"
        Me.ColCashBaseCurrAmount.Name = "ColCashBaseCurrAmount"
        Me.ColCashBaseCurrAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("ColCashBaseCurrAmount.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("ColCashBaseCurrAmount.Summary1"), resources.GetString("ColCashBaseCurrAmount.Summary2"))})
        '
        'ColDocCurrency
        '
        resources.ApplyResources(Me.ColDocCurrency, "ColDocCurrency")
        Me.ColDocCurrency.FieldName = "DocCurrency"
        Me.ColDocCurrency.Name = "ColDocCurrency"
        '
        'DocStatus
        '
        resources.ApplyResources(Me.DocStatus, "DocStatus")
        Me.DocStatus.Name = "DocStatus"
        Me.DocStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DocStatus.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DocStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("DocStatus.Properties.Columns"), resources.GetString("DocStatus.Properties.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("DocStatus.Properties.Columns2"), resources.GetString("DocStatus.Properties.Columns3"))})
        Me.DocStatus.Properties.DisplayMember = "DocStatus"
        Me.DocStatus.Properties.NullText = resources.GetString("DocStatus.Properties.NullText")
        Me.DocStatus.Properties.ReadOnly = True
        Me.DocStatus.Properties.ValueMember = "ID"
        Me.DocStatus.StyleController = Me.LayoutControl1
        '
        'TextReferanceName
        '
        resources.ApplyResources(Me.TextReferanceName, "TextReferanceName")
        Me.TextReferanceName.Name = "TextReferanceName"
        Me.TextReferanceName.Properties.MaxLength = 50
        Me.TextReferanceName.StyleController = Me.LayoutControl1
        '
        'Referance
        '
        resources.ApplyResources(Me.Referance, "Referance")
        Me.Referance.Name = "Referance"
        Me.Referance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("Referance.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.Referance.Properties.DisplayMember = "RefNo"
        Me.Referance.Properties.NullText = resources.GetString("Referance.Properties.NullText")
        Me.Referance.Properties.PopupView = Me.GridView1
        Me.Referance.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth
        Me.Referance.Properties.ShowAddNewButton = True
        Me.Referance.Properties.ValueMember = "RefNo"
        Me.Referance.StyleController = Me.LayoutControl1
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.ColRefMobile})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsFind.SearchInPreview = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.PreviewFieldName = "ReMemo"
        '
        'GridColumn18
        '
        resources.ApplyResources(Me.GridColumn18, "GridColumn18")
        Me.GridColumn18.FieldName = "RefID"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn19
        '
        resources.ApplyResources(Me.GridColumn19, "GridColumn19")
        Me.GridColumn19.FieldName = "RefNo"
        Me.GridColumn19.MaxWidth = 80
        Me.GridColumn19.Name = "GridColumn19"
        '
        'GridColumn20
        '
        resources.ApplyResources(Me.GridColumn20, "GridColumn20")
        Me.GridColumn20.FieldName = "RefName"
        Me.GridColumn20.MinWidth = 200
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn21
        '
        resources.ApplyResources(Me.GridColumn21, "GridColumn21")
        Me.GridColumn21.FieldName = "RefTypeName"
        Me.GridColumn21.MaxWidth = 80
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn22
        '
        resources.ApplyResources(Me.GridColumn22, "GridColumn22")
        Me.GridColumn22.FieldName = "RefAccID"
        Me.GridColumn22.Name = "GridColumn22"
        '
        'GridColumn23
        '
        resources.ApplyResources(Me.GridColumn23, "GridColumn23")
        Me.GridColumn23.FieldName = "TypeID"
        Me.GridColumn23.Name = "GridColumn23"
        '
        'GridColumn24
        '
        resources.ApplyResources(Me.GridColumn24, "GridColumn24")
        Me.GridColumn24.FieldName = "Currency"
        Me.GridColumn24.Name = "GridColumn24"
        '
        'ColRefMobile
        '
        resources.ApplyResources(Me.ColRefMobile, "ColRefMobile")
        Me.ColRefMobile.FieldName = "RefMobile"
        Me.ColRefMobile.Name = "ColRefMobile"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DocName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(384, 426)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.OptionsPrint.AllowPrint = False
        Me.LayoutControlItem3.Size = New System.Drawing.Size(384, 24)
        resources.ApplyResources(Me.LayoutControlItem3, "LayoutControlItem3")
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(75, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.LookDocSort
        Me.LayoutControlItem7.Location = New System.Drawing.Point(290, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(141, 24)
        resources.ApplyResources(Me.LayoutControlItem7, "LayoutControlItem7")
        Me.LayoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(61, 13)
        Me.LayoutControlItem7.TextToControlDistance = 5
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.TextDocIDQuery
        Me.LayoutControlItem25.Location = New System.Drawing.Point(271, 0)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(177, 24)
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.TextMultiCurrency
        Me.LayoutControlItem19.Location = New System.Drawing.Point(271, 0)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(354, 24)
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.TextOpenFrom
        Me.LayoutControlItem24.Location = New System.Drawing.Point(540, 466)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(50, 21)
        '
        'LayoutDocCode
        '
        Me.LayoutDocCode.Control = Me.DocCode
        Me.LayoutDocCode.Location = New System.Drawing.Point(0, 512)
        Me.LayoutDocCode.Name = "LayoutDocCode"
        Me.LayoutDocCode.Size = New System.Drawing.Size(275, 24)
        Me.LayoutDocCode.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.TextAmountInRefCurr
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlItem13.MaxSize = New System.Drawing.Size(173, 24)
        Me.LayoutControlItem13.MinSize = New System.Drawing.Size(173, 24)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(202, 30)
        Me.LayoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlItem13, "LayoutControlItem13")
        Me.LayoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(54, 13)
        Me.LayoutControlItem13.TextToControlDistance = 5
        '
        'LayoutDelete
        '
        Me.LayoutDelete.Control = Me.SimpleButton2
        Me.LayoutDelete.Location = New System.Drawing.Point(561, 0)
        Me.LayoutDelete.MaxSize = New System.Drawing.Size(122, 40)
        Me.LayoutDelete.MinSize = New System.Drawing.Size(122, 40)
        Me.LayoutDelete.Name = "LayoutDelete"
        Me.LayoutDelete.OptionsPrint.AllowPrint = False
        Me.LayoutDelete.Size = New System.Drawing.Size(142, 49)
        Me.LayoutDelete.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutDelete.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutDelete.TextVisible = False
        Me.LayoutDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.SimpleButton3
        Me.LayoutControlItem11.Location = New System.Drawing.Point(703, 0)
        Me.LayoutControlItem11.MaxSize = New System.Drawing.Size(124, 40)
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(124, 40)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.OptionsPrint.AllowPrint = False
        Me.LayoutControlItem11.Size = New System.Drawing.Size(145, 49)
        Me.LayoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutSave
        '
        Me.LayoutSave.Control = Me.SimpleButton1
        Me.LayoutSave.Location = New System.Drawing.Point(848, 0)
        Me.LayoutSave.MaxSize = New System.Drawing.Size(122, 40)
        Me.LayoutSave.MinSize = New System.Drawing.Size(122, 40)
        Me.LayoutSave.Name = "LayoutSave"
        Me.LayoutSave.OptionsPrint.AllowPrint = False
        Me.LayoutSave.Size = New System.Drawing.Size(142, 49)
        Me.LayoutSave.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutSave.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutSave.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.SimpleButton5
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(38, 31)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(38, 31)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(990, 40)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.DocCurrencyForReferanceAcc
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(90, 26)
        resources.ApplyResources(Me.LayoutControlItem5, "LayoutControlItem5")
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.ExchangePriceForReferanceAcc
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(90, 112)
        resources.ApplyResources(Me.LayoutControlItem15, "LayoutControlItem15")
        Me.LayoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextToControlDistance = 0
        Me.LayoutControlItem15.TextVisible = False
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup4, Me.TabbedControlGroup1, Me.LayoutControlItem22, Me.LayoutControlSave, Me.EmptySpaceItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1197, 612)
        Me.Root.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem10, Me.LayoutControlGroup1, Me.LayoutHeader})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1171, 379)
        resources.ApplyResources(Me.LayoutControlGroup4, "LayoutControlGroup4")
        Me.LayoutControlGroup4.TextVisible = False
        '
        'EmptySpaceItem10
        '
        Me.EmptySpaceItem10.AllowHotTrack = False
        Me.EmptySpaceItem10.Location = New System.Drawing.Point(0, 100)
        Me.EmptySpaceItem10.MaxSize = New System.Drawing.Size(0, 10)
        Me.EmptySpaceItem10.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem10.Name = "EmptySpaceItem10"
        Me.EmptySpaceItem10.Size = New System.Drawing.Size(1139, 10)
        Me.EmptySpaceItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem10.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem10, Me.LayoutControlItem2, Me.LayoutDocCurrency, Me.LayoutControlItem17, Me.LayoutControlItem4, Me.EmptySpaceItem2, Me.EmptySpaceItem6})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1139, 100)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextDocID
        resources.ApplyResources(Me.LayoutControlItem1, "LayoutControlItem1")
        Me.LayoutControlItem1.Location = New System.Drawing.Point(844, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(263, 34)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(263, 34)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(263, 34)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(88, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.TextDocManualNo
        Me.LayoutControlItem10.Location = New System.Drawing.Point(333, 0)
        Me.LayoutControlItem10.MaxSize = New System.Drawing.Size(241, 34)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(241, 34)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(241, 34)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlItem10, "LayoutControlItem10")
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(88, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DocDate
        Me.LayoutControlItem2.Location = New System.Drawing.Point(844, 34)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(263, 34)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(263, 34)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(263, 34)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlItem2, "LayoutControlItem2")
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(88, 13)
        '
        'LayoutDocCurrency
        '
        Me.LayoutDocCurrency.Control = Me.DocCurrency
        Me.LayoutDocCurrency.Location = New System.Drawing.Point(333, 34)
        Me.LayoutDocCurrency.MaxSize = New System.Drawing.Size(241, 34)
        Me.LayoutDocCurrency.MinSize = New System.Drawing.Size(241, 34)
        Me.LayoutDocCurrency.Name = "LayoutDocCurrency"
        Me.LayoutDocCurrency.Size = New System.Drawing.Size(241, 34)
        Me.LayoutDocCurrency.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutDocCurrency, "LayoutDocCurrency")
        Me.LayoutDocCurrency.TextSize = New System.Drawing.Size(88, 13)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.ExchangePrice
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem17.MaxSize = New System.Drawing.Size(244, 34)
        Me.LayoutControlItem17.MinSize = New System.Drawing.Size(244, 34)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(244, 34)
        Me.LayoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlItem17, "LayoutControlItem17")
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(88, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DocStatus
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(244, 34)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(244, 34)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.OptionsPrint.AllowPrint = False
        Me.LayoutControlItem4.Size = New System.Drawing.Size(244, 34)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlItem4, "LayoutControlItem4")
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(88, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(244, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(89, 68)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(574, 0)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(270, 68)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutHeader
        '
        resources.ApplyResources(ButtonImageOptions1, "ButtonImageOptions1")
        ButtonImageOptions1.Location = DevExpress.XtraEditors.ButtonPanel.ImageLocation.BeforeText
        Me.LayoutHeader.CustomHeaderButtons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton(resources.GetString("LayoutHeader.CustomHeaderButtons"), CType(resources.GetObject("LayoutHeader.CustomHeaderButtons1"), Boolean), ButtonImageOptions1, CType(resources.GetObject("LayoutHeader.CustomHeaderButtons2"), DevExpress.XtraBars.Docking2010.ButtonStyle), resources.GetString("LayoutHeader.CustomHeaderButtons3"), CType(resources.GetObject("LayoutHeader.CustomHeaderButtons4"), Integer), CType(resources.GetObject("LayoutHeader.CustomHeaderButtons5"), Boolean), CType(resources.GetObject("LayoutHeader.CustomHeaderButtons6"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("LayoutHeader.CustomHeaderButtons7"), Boolean), CType(resources.GetObject("LayoutHeader.CustomHeaderButtons8"), Boolean), CType(resources.GetObject("LayoutHeader.CustomHeaderButtons9"), Boolean), resources.GetString("LayoutHeader.CustomHeaderButtons10"), CType(resources.GetObject("LayoutHeader.CustomHeaderButtons11"), Integer))})
        Me.LayoutHeader.ExpandButtonVisible = True
        Me.LayoutHeader.ExpandOnDoubleClick = True
        Me.LayoutHeader.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutHeader.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem23, Me.LayoutControlItem21, Me.LayoutControlItem20, Me.EmptySpaceItem12, Me.TabbedControlGroup2, Me.TabbedControlGroup3, Me.LayoutCheqsInAccount, Me.EmptySpaceItem5})
        Me.LayoutHeader.Location = New System.Drawing.Point(0, 110)
        Me.LayoutHeader.Name = "LayoutHeader"
        Me.LayoutHeader.Size = New System.Drawing.Size(1139, 237)
        resources.ApplyResources(Me.LayoutHeader, "LayoutHeader")
        Me.LayoutHeader.TextLocation = DevExpress.Utils.Locations.[Default]
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.TotalDocAmount
        Me.LayoutControlItem23.Location = New System.Drawing.Point(276, 144)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(277, 34)
        resources.ApplyResources(Me.LayoutControlItem23, "LayoutControlItem23")
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(88, 13)
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.DocCheqsAmount
        Me.LayoutControlItem21.Location = New System.Drawing.Point(553, 144)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(276, 34)
        resources.ApplyResources(Me.LayoutControlItem21, "LayoutControlItem21")
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(88, 13)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.DocCashAmount
        resources.ApplyResources(Me.LayoutControlItem20, "LayoutControlItem20")
        Me.LayoutControlItem20.Location = New System.Drawing.Point(829, 144)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(278, 34)
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(88, 13)
        '
        'EmptySpaceItem12
        '
        Me.EmptySpaceItem12.AllowHotTrack = False
        Me.EmptySpaceItem12.Location = New System.Drawing.Point(0, 134)
        Me.EmptySpaceItem12.MaxSize = New System.Drawing.Size(0, 10)
        Me.EmptySpaceItem12.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem12.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem12.Size = New System.Drawing.Size(1107, 10)
        Me.EmptySpaceItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem12.TextSize = New System.Drawing.Size(0, 0)
        '
        'TabbedControlGroup2
        '
        Me.TabbedControlGroup2.Location = New System.Drawing.Point(702, 0)
        Me.TabbedControlGroup2.Name = "TabbedControlGroup2"
        Me.TabbedControlGroup2.SelectedTabPage = Me.LayoutControlGroup6
        resources.ApplyResources(Me.TabbedControlGroup2, "TabbedControlGroup2")
        Me.TabbedControlGroup2.Size = New System.Drawing.Size(405, 134)
        Me.TabbedControlGroup2.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup6})
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutReferance, Me.LayoutControlItem8, Me.LayoutControlItem28, Me.LayoutControlItem9, Me.LayoutCostCenter})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(373, 102)
        '
        'LayoutReferance
        '
        Me.LayoutReferance.Control = Me.Referance
        Me.LayoutReferance.Location = New System.Drawing.Point(186, 0)
        Me.LayoutReferance.Name = "LayoutReferance"
        Me.LayoutReferance.Size = New System.Drawing.Size(187, 34)
        resources.ApplyResources(Me.LayoutReferance, "LayoutReferance")
        Me.LayoutReferance.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutReferance.TextSize = New System.Drawing.Size(28, 13)
        Me.LayoutReferance.TextToControlDistance = 5
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TextReferanceName
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(373, 34)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(373, 34)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(373, 34)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlItem8, "LayoutControlItem8")
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.TextRefBalance
        Me.LayoutControlItem28.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(186, 34)
        resources.ApplyResources(Me.LayoutControlItem28, "LayoutControlItem28")
        Me.LayoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem28.TextLocation = DevExpress.Utils.Locations.Right
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(30, 13)
        Me.LayoutControlItem28.TextToControlDistance = 5
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.AccountForRefranace
        Me.LayoutControlItem9.Location = New System.Drawing.Point(186, 68)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(187, 34)
        resources.ApplyResources(Me.LayoutControlItem9, "LayoutControlItem9")
        Me.LayoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(41, 13)
        Me.LayoutControlItem9.TextToControlDistance = 5
        '
        'LayoutCostCenter
        '
        Me.LayoutCostCenter.Control = Me.LookCostCenter
        Me.LayoutCostCenter.Location = New System.Drawing.Point(0, 68)
        Me.LayoutCostCenter.Name = "LayoutCostCenter"
        Me.LayoutCostCenter.Size = New System.Drawing.Size(186, 34)
        resources.ApplyResources(Me.LayoutCostCenter, "LayoutCostCenter")
        Me.LayoutCostCenter.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutCostCenter.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutCostCenter.TextToControlDistance = 5
        '
        'TabbedControlGroup3
        '
        Me.TabbedControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.TabbedControlGroup3.Name = "TabbedControlGroup3"
        Me.TabbedControlGroup3.SelectedTabPage = Me.LayoutControlGroup7
        resources.ApplyResources(Me.TabbedControlGroup3, "TabbedControlGroup3")
        Me.TabbedControlGroup3.Size = New System.Drawing.Size(368, 134)
        Me.TabbedControlGroup3.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup7})
        '
        'LayoutControlGroup7
        '
        Me.LayoutControlGroup7.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem16, Me.LayoutControlSalesPerson, Me.EmptySpaceItem3})
        Me.LayoutControlGroup7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup7.Name = "LayoutControlGroup7"
        Me.LayoutControlGroup7.Size = New System.Drawing.Size(336, 102)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.CashAccount
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem16.MaxSize = New System.Drawing.Size(336, 32)
        Me.LayoutControlItem16.MinSize = New System.Drawing.Size(336, 32)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(336, 32)
        Me.LayoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlItem16, "LayoutControlItem16")
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(88, 13)
        '
        'LayoutControlSalesPerson
        '
        Me.LayoutControlSalesPerson.Control = Me.SalesPerson
        Me.LayoutControlSalesPerson.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlSalesPerson.Name = "LayoutControlSalesPerson"
        Me.LayoutControlSalesPerson.Size = New System.Drawing.Size(336, 34)
        resources.ApplyResources(Me.LayoutControlSalesPerson, "LayoutControlSalesPerson")
        Me.LayoutControlSalesPerson.TextSize = New System.Drawing.Size(88, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 66)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(336, 36)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutCheqsInAccount
        '
        Me.LayoutCheqsInAccount.Control = Me.SearchChecksBoxAccount
        Me.LayoutCheqsInAccount.Location = New System.Drawing.Point(0, 144)
        Me.LayoutCheqsInAccount.Name = "LayoutCheqsInAccount"
        Me.LayoutCheqsInAccount.Size = New System.Drawing.Size(276, 34)
        resources.ApplyResources(Me.LayoutCheqsInAccount, "LayoutCheqsInAccount")
        Me.LayoutCheqsInAccount.TextSize = New System.Drawing.Size(88, 13)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(368, 0)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(334, 134)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 379)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup3
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(1171, 117)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        Me.TabbedControlGroup1.TextLocation = DevExpress.Utils.Locations.Right
        '
        'LayoutControlGroup3
        '
        resources.ApplyResources(Me.LayoutControlGroup3, "LayoutControlGroup3")
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1110, 85)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.GridControlChecks
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1110, 85)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlGroup2
        '
        resources.ApplyResources(Me.LayoutControlGroup2, "LayoutControlGroup2")
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1110, 85)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.GridControlCash
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(1110, 85)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.TextDocNotes
        Me.LayoutControlItem22.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight
        Me.LayoutControlItem22.ImageOptions.SvgImage = CType(resources.GetObject("LayoutControlItem22.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 496)
        Me.LayoutControlItem22.MaxSize = New System.Drawing.Size(0, 56)
        Me.LayoutControlItem22.MinSize = New System.Drawing.Size(61, 56)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(1171, 56)
        Me.LayoutControlItem22.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlItem22, "LayoutControlItem22")
        Me.LayoutControlItem22.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem22.TextLocation = DevExpress.Utils.Locations.Right
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(40, 32)
        Me.LayoutControlItem22.TextToControlDistance = 5
        '
        'LayoutControlSave
        '
        Me.LayoutControlSave.Control = Me.SimpleButton6
        Me.LayoutControlSave.Location = New System.Drawing.Point(0, 552)
        Me.LayoutControlSave.MaxSize = New System.Drawing.Size(121, 34)
        Me.LayoutControlSave.MinSize = New System.Drawing.Size(121, 34)
        Me.LayoutControlSave.Name = "LayoutControlSave"
        Me.LayoutControlSave.Size = New System.Drawing.Size(121, 34)
        Me.LayoutControlSave.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlSave, "LayoutControlSave")
        Me.LayoutControlSave.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlSave.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(121, 552)
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(0, 26)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(104, 26)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1050, 34)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockManager = Me.DockManager1
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSubItem1, Me.BarButtonItem1, Me.BarSubItem2, Me.BarSubItem4, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4, Me.BarButtonItem5, Me.BarButtonItem6, Me.BarButtonItem7, Me.BarButtonItem8, Me.BarButtonItem9, Me.BarButtonItem10, Me.BarButtonItem11, Me.BarButtonMaximize, Me.BarButtonRestore, Me.BarButtonMinimize, Me.BarButtonMDI, Me.BarButtonItem12, Me.BarInputDateTime, Me.BarDeviceName, Me.BarInputUser})
        Me.BarManager1.MaxItemId = 26
        Me.BarManager1.StatusBar = Me.Bar2
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarSubItem1, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarSubItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarSubItem4, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem7, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem10), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem8), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem9), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonMinimize, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonMaximize), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonMDI), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonRestore), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem11)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar1, "Bar1")
        '
        'BarSubItem1
        '
        resources.ApplyResources(Me.BarSubItem1, "BarSubItem1")
        Me.BarSubItem1.Id = 0
        Me.BarSubItem1.ImageOptions.Image = CType(resources.GetObject("BarSubItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BarButtonItem1
        '
        resources.ApplyResources(Me.BarButtonItem1, "BarButtonItem1")
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarSubItem2
        '
        resources.ApplyResources(Me.BarSubItem2, "BarSubItem2")
        Me.BarSubItem2.Id = 3
        Me.BarSubItem2.ImageOptions.Image = CType(resources.GetObject("BarSubItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem4), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem5), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem6), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem12)})
        Me.BarSubItem2.Name = "BarSubItem2"
        '
        'BarButtonItem4
        '
        resources.ApplyResources(Me.BarButtonItem4, "BarButtonItem4")
        Me.BarButtonItem4.Id = 9
        Me.BarButtonItem4.ImageOptions.Image = CType(resources.GetObject("BarButtonItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'BarButtonItem5
        '
        resources.ApplyResources(Me.BarButtonItem5, "BarButtonItem5")
        Me.BarButtonItem5.Id = 10
        Me.BarButtonItem5.ImageOptions.Image = CType(resources.GetObject("BarButtonItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem5.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem5.Name = "BarButtonItem5"
        '
        'BarButtonItem6
        '
        resources.ApplyResources(Me.BarButtonItem6, "BarButtonItem6")
        Me.BarButtonItem6.Id = 11
        Me.BarButtonItem6.ImageOptions.Image = CType(resources.GetObject("BarButtonItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem6.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem6.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem6.Name = "BarButtonItem6"
        '
        'BarButtonItem12
        '
        resources.ApplyResources(Me.BarButtonItem12, "BarButtonItem12")
        Me.BarButtonItem12.Id = 22
        Me.BarButtonItem12.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem12.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem12.Name = "BarButtonItem12"
        '
        'BarSubItem4
        '
        resources.ApplyResources(Me.BarSubItem4, "BarSubItem4")
        Me.BarSubItem4.Id = 4
        Me.BarSubItem4.ImageOptions.Image = CType(resources.GetObject("BarSubItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem3)})
        Me.BarSubItem4.Name = "BarSubItem4"
        '
        'BarButtonItem2
        '
        resources.ApplyResources(Me.BarButtonItem2, "BarButtonItem2")
        Me.BarButtonItem2.Id = 5
        Me.BarButtonItem2.ImageOptions.Image = CType(resources.GetObject("BarButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        resources.ApplyResources(Me.BarButtonItem3, "BarButtonItem3")
        Me.BarButtonItem3.Id = 6
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonItem7
        '
        resources.ApplyResources(Me.BarButtonItem7, "BarButtonItem7")
        Me.BarButtonItem7.Id = 12
        Me.BarButtonItem7.ImageOptions.Image = CType(resources.GetObject("BarButtonItem7.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem7.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem7.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem7.Name = "BarButtonItem7"
        '
        'BarButtonItem10
        '
        resources.ApplyResources(Me.BarButtonItem10, "BarButtonItem10")
        Me.BarButtonItem10.Id = 15
        Me.BarButtonItem10.ImageOptions.Image = CType(resources.GetObject("BarButtonItem10.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem10.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem10.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem10.Name = "BarButtonItem10"
        '
        'BarButtonItem8
        '
        resources.ApplyResources(Me.BarButtonItem8, "BarButtonItem8")
        Me.BarButtonItem8.Id = 13
        Me.BarButtonItem8.ImageOptions.Image = CType(resources.GetObject("BarButtonItem8.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem8.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem8.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem8.Name = "BarButtonItem8"
        '
        'BarButtonItem9
        '
        resources.ApplyResources(Me.BarButtonItem9, "BarButtonItem9")
        Me.BarButtonItem9.Id = 14
        Me.BarButtonItem9.ImageOptions.Image = CType(resources.GetObject("BarButtonItem9.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem9.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem9.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem9.Name = "BarButtonItem9"
        '
        'BarButtonMinimize
        '
        Me.BarButtonMinimize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.BarButtonMinimize, "BarButtonMinimize")
        Me.BarButtonMinimize.Id = 20
        Me.BarButtonMinimize.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonMinimize.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonMinimize.Name = "BarButtonMinimize"
        '
        'BarButtonMaximize
        '
        Me.BarButtonMaximize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.BarButtonMaximize, "BarButtonMaximize")
        Me.BarButtonMaximize.Id = 18
        Me.BarButtonMaximize.ImageOptions.Image = CType(resources.GetObject("BarButtonMaximize.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonMaximize.Name = "BarButtonMaximize"
        '
        'BarButtonMDI
        '
        Me.BarButtonMDI.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.BarButtonMDI, "BarButtonMDI")
        Me.BarButtonMDI.Id = 21
        Me.BarButtonMDI.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonMDI.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonMDI.Name = "BarButtonMDI"
        '
        'BarButtonRestore
        '
        Me.BarButtonRestore.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.BarButtonRestore, "BarButtonRestore")
        Me.BarButtonRestore.Id = 19
        Me.BarButtonRestore.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonRestore.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonRestore.Name = "BarButtonRestore"
        '
        'BarButtonItem11
        '
        Me.BarButtonItem11.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.BarButtonItem11, "BarButtonItem11")
        Me.BarButtonItem11.Id = 17
        Me.BarButtonItem11.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem11.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem11.Name = "BarButtonItem11"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Custom 3"
        Me.Bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarInputDateTime), New DevExpress.XtraBars.LinkPersistInfo(Me.BarDeviceName), New DevExpress.XtraBars.LinkPersistInfo(Me.BarInputUser)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar2, "Bar2")
        '
        'BarInputDateTime
        '
        resources.ApplyResources(Me.BarInputDateTime, "BarInputDateTime")
        Me.BarInputDateTime.Id = 23
        Me.BarInputDateTime.ImageOptions.SvgImage = CType(resources.GetObject("BarInputDateTime.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarInputDateTime.Name = "BarInputDateTime"
        Me.BarInputDateTime.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarDeviceName
        '
        resources.ApplyResources(Me.BarDeviceName, "BarDeviceName")
        Me.BarDeviceName.Id = 24
        Me.BarDeviceName.ImageOptions.SvgImage = CType(resources.GetObject("BarDeviceName.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarDeviceName.Name = "BarDeviceName"
        Me.BarDeviceName.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarInputUser
        '
        resources.ApplyResources(Me.BarInputUser, "BarInputUser")
        Me.BarInputUser.Id = 25
        Me.BarInputUser.ImageOptions.SvgImage = CType(resources.GetObject("BarInputUser.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarInputUser.Name = "BarInputUser"
        Me.BarInputUser.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager1
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager1
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager1
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager1
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.HiddenPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.MenuManager = Me.BarManager1
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float
        Me.DockPanel1.FloatLocation = New System.Drawing.Point(1203, 332)
        Me.DockPanel1.ID = New System.Guid("f75f2080-7637-4051-bf1c-f7afe8414416")
        resources.ApplyResources(Me.DockPanel1, "DockPanel1")
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(200, 200)
        Me.DockPanel1.SavedIndex = 0
        Me.DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden
        '
        'DockPanel1_Container
        '
        resources.ApplyResources(Me.DockPanel1_Container, "DockPanel1_Container")
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'BarSubItem3
        '
        resources.ApplyResources(Me.BarSubItem3, "BarSubItem3")
        Me.BarSubItem3.Id = 36
        Me.BarSubItem3.ImageOptions.Image = CType(resources.GetObject("BarSubItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem3.Name = "BarSubItem3"
        Me.BarSubItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'MoneyTrans
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.HelpButton = True
        Me.IconOptions.Image = CType(resources.GetObject("MoneyTrans.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "MoneyTrans"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SalesPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRefBalance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOpenFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocIDQuery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalDocAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocCheqsAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CashAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMultiCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocCashAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExchangePrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextAmountInRefCurr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExchangePriceForReferanceAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocManualNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountForRefranace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocCurrencyForReferanceAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookDocSort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchChecksBoxAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlChecks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridViewChecks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryChekNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCheksDocAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryChecksCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryLookUpBanks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryLookUpBranches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEditAccountBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryAccountBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryBankAccountID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookCostCenter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlCash, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryColCashAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryOtherAccCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCashDocAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCashExchangePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextReferanceName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutDocCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutDocCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutReferance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutCostCenter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlSalesPerson, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutCheqsInAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents DocDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextDocID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextDocManualNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents AccountForRefranace As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControlCash As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutSave As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColAccNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAccName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColCashAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryColCashAcc As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColOtherAccName2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColOtherAccNo2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCashDocAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCashDocCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryOtherAccCurrency As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColCashBaseAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExchangePriceForReferanceAcc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocCurrencyForReferanceAcc As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutDelete As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LookDocSort As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColCashExchangePrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCashBaseCurrAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAccType2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridControlChecks As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewChecks As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColCheckNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCheckDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCheksDocAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCheksExchangePrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCheckBaseCurrAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCheckCustAccountId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCheckCustBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCheckCustBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextAmountInRefCurr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextDocNotes As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryChecksCurrency As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents SearchChecksBoxAccount As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutCheqsInAccount As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryCashDocAmount As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryCashExchangePrice As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents DocCurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ExchangePrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutDocCurrency As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocCashAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextMultiCurrency As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColDocCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CashAccount As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocCheqsAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TotalDocAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents RepositoryChekNo As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryCheksDocAmount As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents TextDocIDQuery As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem10 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutHeader As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem12 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TextOpenFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColAccountBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryAccountBank As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColBankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColFinancialAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryBankAccountID As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents DocCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutDocCode As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTransNoInJournal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents DisabledCellEvents1 As DevExpress.Utils.Behaviors.Common.DisabledCellEvents
    Friend WithEvents LookCostCenter As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlSave As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TextRefBalance As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TabbedControlGroup2 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutReferance As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TabbedControlGroup3 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup7 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutCostCenter As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ColDocNoteByAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents TextReferanceName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SalesPerson As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView9 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlSalesPerson As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarSubItem3 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarSubItem4 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryLookUpBranches As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryLookUpBanks As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem9 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem10 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem11 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Referance As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEditAccountBank As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BarButtonMaximize As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonRestore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonMinimize As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonMDI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents حذفالشيكToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents تكرارالشيكToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents كشفحركةللشيكToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents BarButtonItem12 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ColRefMobile As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarInputDateTime As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarDeviceName As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarInputUser As DevExpress.XtraBars.BarStaticItem
End Class
