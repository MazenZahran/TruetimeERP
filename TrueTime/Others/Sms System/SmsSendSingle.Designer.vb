<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmsSendSingle
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SmsSendSingle))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.RadioGroupSendType = New DevExpress.XtraEditors.RadioGroup()
        Me.TextSMSResult = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.RefMobile = New DevExpress.XtraEditors.TextEdit()
        Me.Referance = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SMSDetails = New DevExpress.XtraEditors.MemoEdit()
        Me.RefName = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ColRefID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefAccID = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.RadioGroupSendType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextSMSResult.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RefMobile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SMSDetails.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RefName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.RadioGroupSendType)
        Me.LayoutControl1.Controls.Add(Me.TextSMSResult)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.RefMobile)
        Me.LayoutControl1.Controls.Add(Me.Referance)
        Me.LayoutControl1.Controls.Add(Me.SMSDetails)
        Me.LayoutControl1.Controls.Add(Me.RefName)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(597, 80, 650, 400)
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(481, 481)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'RadioGroupSendType
        '
        Me.RadioGroupSendType.EditValue = "SMS"
        Me.RadioGroupSendType.Location = New System.Drawing.Point(21, 269)
        Me.RadioGroupSendType.Name = "RadioGroupSendType"
        Me.RadioGroupSendType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("SMS", "SMS"), New DevExpress.XtraEditors.Controls.RadioGroupItem("WhatsApp", "WhatsApp")})
        Me.RadioGroupSendType.Size = New System.Drawing.Size(358, 70)
        Me.RadioGroupSendType.StyleController = Me.LayoutControl1
        Me.RadioGroupSendType.TabIndex = 13
        '
        'TextSMSResult
        '
        Me.TextSMSResult.Location = New System.Drawing.Point(37, 416)
        Me.TextSMSResult.Name = "TextSMSResult"
        Me.TextSMSResult.Properties.ReadOnly = True
        Me.TextSMSResult.Size = New System.Drawing.Size(407, 28)
        Me.TextSMSResult.StyleController = Me.LayoutControl1
        Me.TextSMSResult.TabIndex = 12
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(21, 345)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(110, 28)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 11
        Me.SimpleButton1.Text = "ارسال"
        '
        'RefMobile
        '
        Me.RefMobile.Location = New System.Drawing.Point(37, 126)
        Me.RefMobile.Name = "RefMobile"
        Me.RefMobile.Size = New System.Drawing.Size(326, 28)
        Me.RefMobile.StyleController = Me.LayoutControl1
        Me.RefMobile.TabIndex = 10
        '
        'Referance
        '
        Me.Referance.EnterMoveNextControl = True
        Me.Referance.Location = New System.Drawing.Point(37, 58)
        Me.Referance.Name = "Referance"
        Me.Referance.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.Referance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Referance.Properties.DisplayMember = "RefNo"
        Me.Referance.Properties.NullText = "0"
        Me.Referance.Properties.NullValuePrompt = "اختر الذمة"
        Me.Referance.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.Referance.Properties.ShowAddNewButton = True
        Me.Referance.Properties.ValueMember = "RefNo"
        Me.Referance.Size = New System.Drawing.Size(326, 28)
        Me.Referance.StyleController = Me.LayoutControl1
        Me.Referance.TabIndex = 9
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColRefID, Me.ColRefNo, Me.ColRefName, Me.ColRefTypeName, Me.ColRefAccID})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 686
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'SMSDetails
        '
        Me.SMSDetails.Location = New System.Drawing.Point(37, 213)
        Me.SMSDetails.Name = "SMSDetails"
        Me.SMSDetails.Size = New System.Drawing.Size(407, 34)
        Me.SMSDetails.StyleController = Me.LayoutControl1
        Me.SMSDetails.TabIndex = 5
        '
        'RefName
        '
        Me.RefName.Location = New System.Drawing.Point(37, 92)
        Me.RefName.Name = "RefName"
        Me.RefName.Size = New System.Drawing.Size(326, 28)
        Me.RefName.StyleController = Me.LayoutControl1
        Me.RefName.TabIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlGroup3, Me.LayoutControlItem6, Me.LayoutControlItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(481, 481)
        Me.Root.Spacing = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(116, 324)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(329, 34)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem1, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(445, 155)
        Me.LayoutControlGroup1.Text = "بيانات المرسل"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Referance
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(413, 34)
        Me.LayoutControlItem4.Text = "الجهة:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(65, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.RefName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(413, 34)
        Me.LayoutControlItem1.Text = "اسم الجهة:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(65, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.RefMobile
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(413, 34)
        Me.LayoutControlItem5.Text = "رقم الموبايل:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(65, 13)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 155)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(445, 93)
        Me.LayoutControlGroup2.Text = "النص"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SMSDetails
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(413, 40)
        Me.LayoutControlItem2.Text = "نص الرسالة:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 358)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(445, 87)
        Me.LayoutControlGroup3.Text = "بيانات الارسال"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TextSMSResult
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(413, 34)
        Me.LayoutControlItem7.Text = "."
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.SimpleButton1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 324)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(116, 34)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.RadioGroupSendType
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 248)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(445, 76)
        Me.LayoutControlItem3.Text = "طريقة الارسال"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(65, 13)
        '
        'ColRefID
        '
        Me.ColRefID.Caption = "ID"
        Me.ColRefID.FieldName = "RefID"
        Me.ColRefID.Name = "ColRefID"
        '
        'ColRefNo
        '
        Me.ColRefNo.Caption = "رقم المرجع"
        Me.ColRefNo.FieldName = "RefNo"
        Me.ColRefNo.MaxWidth = 80
        Me.ColRefNo.Name = "ColRefNo"
        Me.ColRefNo.Visible = True
        Me.ColRefNo.VisibleIndex = 0
        '
        'ColRefName
        '
        Me.ColRefName.Caption = "المرجع"
        Me.ColRefName.FieldName = "RefName"
        Me.ColRefName.MinWidth = 200
        Me.ColRefName.Name = "ColRefName"
        Me.ColRefName.Visible = True
        Me.ColRefName.VisibleIndex = 1
        Me.ColRefName.Width = 200
        '
        'ColRefTypeName
        '
        Me.ColRefTypeName.Caption = "نوع المرجع"
        Me.ColRefTypeName.FieldName = "RefTypeName"
        Me.ColRefTypeName.MaxWidth = 80
        Me.ColRefTypeName.Name = "ColRefTypeName"
        Me.ColRefTypeName.Visible = True
        Me.ColRefTypeName.VisibleIndex = 2
        '
        'ColRefAccID
        '
        Me.ColRefAccID.Caption = "رقم الحساب"
        Me.ColRefAccID.FieldName = "RefAccID"
        Me.ColRefAccID.Name = "ColRefAccID"
        '
        'SmsSendSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 481)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("SmsSendSingle.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Name = "SmsSendSingle"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة رسالة موبايل"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.RadioGroupSendType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextSMSResult.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RefMobile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SMSDetails.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RefName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SMSDetails As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents RefName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RefMobile As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Referance As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColRefID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefAccID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TextSMSResult As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RadioGroupSendType As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
End Class
