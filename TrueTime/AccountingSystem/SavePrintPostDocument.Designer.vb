<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SavePrintPostDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SavePrintPostDocument))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.BtnPrintVoucher = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnIssueReceiptOrPayment = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton9 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton8 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextDocData = New DevExpress.XtraEditors.TextEdit()
        Me.TextDocCode = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItemPost = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItemPostAndPrint = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutPayVoucher = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlSendSMS = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutSendDocumentByWhatsApp = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlPayOrRec = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutPrintVoucher = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BtnSendToGroupWhatsApp = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutBtnSendToGroupWhatsApp = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TextDocData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemPost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemPostAndPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutPayVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlSendSMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutSendDocumentByWhatsApp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlPayOrRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutPrintVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutBtnSendToGroupWhatsApp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.BtnSendToGroupWhatsApp)
        Me.LayoutControl1.Controls.Add(Me.BtnPrintVoucher)
        Me.LayoutControl1.Controls.Add(Me.BtnIssueReceiptOrPayment)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton9)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton8)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton7)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton4)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton5)
        Me.LayoutControl1.Controls.Add(Me.TextDocData)
        Me.LayoutControl1.Controls.Add(Me.TextDocCode)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(800, 0, 650, 400)
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(566, 347)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'BtnPrintVoucher
        '
        Me.BtnPrintVoucher.Location = New System.Drawing.Point(16, 269)
        Me.BtnPrintVoucher.Name = "BtnPrintVoucher"
        Me.BtnPrintVoucher.Size = New System.Drawing.Size(534, 28)
        Me.BtnPrintVoucher.StyleController = Me.LayoutControl1
        Me.BtnPrintVoucher.TabIndex = 19
        Me.BtnPrintVoucher.Text = "طباعة الفاتورة"
        '
        'BtnIssueReceiptOrPayment
        '
        Me.BtnIssueReceiptOrPayment.Location = New System.Drawing.Point(16, 235)
        Me.BtnIssueReceiptOrPayment.Name = "BtnIssueReceiptOrPayment"
        Me.BtnIssueReceiptOrPayment.Size = New System.Drawing.Size(534, 28)
        Me.BtnIssueReceiptOrPayment.StyleController = Me.LayoutControl1
        Me.BtnIssueReceiptOrPayment.TabIndex = 18
        Me.BtnIssueReceiptOrPayment.Text = "9- اصدار سند قبض او صرف"
        '
        'SimpleButton9
        '
        Me.SimpleButton9.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton9.Appearance.Options.UseFont = True
        Me.SimpleButton9.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.whatsapp_16
        Me.SimpleButton9.Location = New System.Drawing.Point(16, 167)
        Me.SimpleButton9.Name = "SimpleButton9"
        Me.SimpleButton9.Size = New System.Drawing.Size(264, 28)
        Me.SimpleButton9.StyleController = Me.LayoutControl1
        Me.SimpleButton9.TabIndex = 16
        Me.SimpleButton9.Text = "7- ارسال PDF للذمة"
        '
        'SimpleButton8
        '
        Me.SimpleButton8.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton8.Appearance.Options.UseFont = True
        Me.SimpleButton8.Location = New System.Drawing.Point(16, 201)
        Me.SimpleButton8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton8.Name = "SimpleButton8"
        Me.SimpleButton8.Size = New System.Drawing.Size(534, 28)
        Me.SimpleButton8.StyleController = Me.LayoutControl1
        Me.SimpleButton8.TabIndex = 15
        Me.SimpleButton8.Text = "8- اغلاق الفواتير"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.Location = New System.Drawing.Point(16, 102)
        Me.SimpleButton7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(264, 25)
        Me.SimpleButton7.StyleController = Me.LayoutControl1
        Me.SimpleButton7.TabIndex = 14
        Me.SimpleButton7.Text = "3- معاينة الطباعة"
        '
        'LabelControl1
        '
        Me.LabelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.LabelControl1.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelControl1.ImageOptions.SvgImage = CType(resources.GetObject("LabelControl1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.LabelControl1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.LabelControl1.Location = New System.Drawing.Point(354, 16)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(196, 36)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 12
        Me.LabelControl1.Text = "         لقد تم حفظ السند بنجاح       "
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton4.Appearance.Options.UseFont = True
        Me.SimpleButton4.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.SimpleButton4.Location = New System.Drawing.Point(286, 167)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(264, 28)
        Me.SimpleButton4.StyleController = Me.LayoutControl1
        Me.SimpleButton4.TabIndex = 11
        Me.SimpleButton4.Text = "6- SMS"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton5.Appearance.Options.UseFont = True
        Me.SimpleButton5.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton5.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.ok_32px
        Me.SimpleButton5.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.SimpleButton5.Location = New System.Drawing.Point(16, 58)
        Me.SimpleButton5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(534, 38)
        Me.SimpleButton5.StyleController = Me.LayoutControl1
        Me.SimpleButton5.TabIndex = 0
        Me.SimpleButton5.Text = "1- اغلاق"
        '
        'TextDocData
        '
        Me.TextDocData.Location = New System.Drawing.Point(10, 103)
        Me.TextDocData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextDocData.Name = "TextDocData"
        Me.TextDocData.Size = New System.Drawing.Size(383, 28)
        Me.TextDocData.StyleController = Me.LayoutControl1
        Me.TextDocData.TabIndex = 10
        '
        'TextDocCode
        '
        Me.TextDocCode.Location = New System.Drawing.Point(203, 103)
        Me.TextDocCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextDocCode.Name = "TextDocCode"
        Me.TextDocCode.Size = New System.Drawing.Size(190, 28)
        Me.TextDocCode.StyleController = Me.LayoutControl1
        Me.TextDocCode.TabIndex = 9
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton3.Appearance.Options.UseFont = True
        Me.SimpleButton3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.SimpleButton3.Location = New System.Drawing.Point(16, 133)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(264, 28)
        Me.SimpleButton3.StyleController = Me.LayoutControl1
        Me.SimpleButton3.TabIndex = 7
        Me.SimpleButton3.Text = "5- ترحيل وطباعة"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.SimpleButton2.Location = New System.Drawing.Point(286, 133)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(264, 28)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "4- ترحيل السند"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.SimpleButton1.Location = New System.Drawing.Point(286, 102)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(264, 25)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "2- طباعة السند"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TextDocCode
        Me.LayoutControlItem6.Location = New System.Drawing.Point(225, 115)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(226, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TextDocData
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 115)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(451, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem1, Me.LayoutControlItem9, Me.LayoutControlItemPost, Me.LayoutControlItemPostAndPrint, Me.LayoutControlItem5, Me.LayoutPayVoucher, Me.LayoutControlSendSMS, Me.LayoutSendDocumentByWhatsApp, Me.LayoutControlPayOrRec, Me.LayoutPrintVoucher, Me.LayoutBtnSendToGroupWhatsApp})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(566, 347)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.LabelControl1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(540, 42)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(270, 86)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(106, 31)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(270, 31)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.SimpleButton5
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(540, 44)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItemPost
        '
        Me.LayoutControlItemPost.Control = Me.SimpleButton2
        Me.LayoutControlItemPost.Location = New System.Drawing.Point(270, 117)
        Me.LayoutControlItemPost.Name = "LayoutControlItemPost"
        Me.LayoutControlItemPost.Size = New System.Drawing.Size(270, 34)
        Me.LayoutControlItemPost.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItemPost.TextVisible = False
        Me.LayoutControlItemPost.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItemPostAndPrint
        '
        Me.LayoutControlItemPostAndPrint.Control = Me.SimpleButton3
        Me.LayoutControlItemPostAndPrint.Location = New System.Drawing.Point(0, 117)
        Me.LayoutControlItemPostAndPrint.MinSize = New System.Drawing.Size(115, 31)
        Me.LayoutControlItemPostAndPrint.Name = "LayoutControlItemPostAndPrint"
        Me.LayoutControlItemPostAndPrint.Size = New System.Drawing.Size(270, 34)
        Me.LayoutControlItemPostAndPrint.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItemPostAndPrint.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItemPostAndPrint.TextVisible = False
        Me.LayoutControlItemPostAndPrint.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SimpleButton7
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 86)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(81, 20)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(270, 31)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutPayVoucher
        '
        Me.LayoutPayVoucher.Control = Me.SimpleButton8
        Me.LayoutPayVoucher.Location = New System.Drawing.Point(0, 185)
        Me.LayoutPayVoucher.Name = "LayoutPayVoucher"
        Me.LayoutPayVoucher.Size = New System.Drawing.Size(540, 34)
        Me.LayoutPayVoucher.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutPayVoucher.TextVisible = False
        Me.LayoutPayVoucher.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlSendSMS
        '
        Me.LayoutControlSendSMS.Control = Me.SimpleButton4
        Me.LayoutControlSendSMS.Location = New System.Drawing.Point(270, 151)
        Me.LayoutControlSendSMS.Name = "LayoutControlSendSMS"
        Me.LayoutControlSendSMS.Size = New System.Drawing.Size(270, 34)
        Me.LayoutControlSendSMS.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlSendSMS.TextVisible = False
        '
        'LayoutSendDocumentByWhatsApp
        '
        Me.LayoutSendDocumentByWhatsApp.Control = Me.SimpleButton9
        Me.LayoutSendDocumentByWhatsApp.Location = New System.Drawing.Point(0, 151)
        Me.LayoutSendDocumentByWhatsApp.Name = "LayoutSendDocumentByWhatsApp"
        Me.LayoutSendDocumentByWhatsApp.Size = New System.Drawing.Size(270, 34)
        Me.LayoutSendDocumentByWhatsApp.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutSendDocumentByWhatsApp.TextVisible = False
        Me.LayoutSendDocumentByWhatsApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlPayOrRec
        '
        Me.LayoutControlPayOrRec.Control = Me.BtnIssueReceiptOrPayment
        Me.LayoutControlPayOrRec.Location = New System.Drawing.Point(0, 219)
        Me.LayoutControlPayOrRec.Name = "LayoutControlPayOrRec"
        Me.LayoutControlPayOrRec.Size = New System.Drawing.Size(540, 34)
        Me.LayoutControlPayOrRec.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlPayOrRec.TextVisible = False
        Me.LayoutControlPayOrRec.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutPrintVoucher
        '
        Me.LayoutPrintVoucher.Control = Me.BtnPrintVoucher
        Me.LayoutPrintVoucher.Location = New System.Drawing.Point(0, 253)
        Me.LayoutPrintVoucher.Name = "LayoutPrintVoucher"
        Me.LayoutPrintVoucher.Size = New System.Drawing.Size(540, 34)
        Me.LayoutPrintVoucher.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutPrintVoucher.TextVisible = False
        Me.LayoutPrintVoucher.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'BtnSendToGroupWhatsApp
        '
        Me.BtnSendToGroupWhatsApp.Location = New System.Drawing.Point(16, 303)
        Me.BtnSendToGroupWhatsApp.Name = "BtnSendToGroupWhatsApp"
        Me.BtnSendToGroupWhatsApp.Size = New System.Drawing.Size(534, 28)
        Me.BtnSendToGroupWhatsApp.StyleController = Me.LayoutControl1
        Me.BtnSendToGroupWhatsApp.TabIndex = 20
        Me.BtnSendToGroupWhatsApp.Text = "ارسال الى مجموعة واتس اب"
        '
        'LayoutBtnSendToGroupWhatsApp
        '
        Me.LayoutBtnSendToGroupWhatsApp.Control = Me.BtnSendToGroupWhatsApp
        Me.LayoutBtnSendToGroupWhatsApp.Location = New System.Drawing.Point(0, 287)
        Me.LayoutBtnSendToGroupWhatsApp.Name = "LayoutBtnSendToGroupWhatsApp"
        Me.LayoutBtnSendToGroupWhatsApp.Size = New System.Drawing.Size(540, 34)
        Me.LayoutBtnSendToGroupWhatsApp.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutBtnSendToGroupWhatsApp.TextVisible = False
        Me.LayoutBtnSendToGroupWhatsApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'SavePrintPostDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.SimpleButton5
        Me.ClientSize = New System.Drawing.Size(566, 347)
        Me.ControlBox = False
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "SavePrintPostDocument"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TextDocData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemPost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemPostAndPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutPayVoucher, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlSendSMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutSendDocumentByWhatsApp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlPayOrRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutPrintVoucher, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutBtnSendToGroupWhatsApp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextDocData As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextDocCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItemPost As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlSendSMS As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItemPostAndPrint As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton8 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutPayVoucher As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton9 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutSendDocumentByWhatsApp As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnIssueReceiptOrPayment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlPayOrRec As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnPrintVoucher As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutPrintVoucher As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnSendToGroupWhatsApp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutBtnSendToGroupWhatsApp As DevExpress.XtraLayout.LayoutControlItem
End Class
