<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LinkWhatsAppForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LinkWhatsAppForm))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.picQRCode = New System.Windows.Forms.PictureBox()
        Me.lblQRInstruction = New DevExpress.XtraEditors.LabelControl()
        Me.lblStatus = New DevExpress.XtraEditors.LabelControl()
        Me.lblPhoneNumber = New DevExpress.XtraEditors.LabelControl()
        Me.lblTitle = New DevExpress.XtraEditors.LabelControl()
        Me.btnConnect = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRetry = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDisconnect = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.checkTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Appearance.Control.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LayoutControl1.Appearance.Control.Options.UseBackColor = True
        Me.LayoutControl1.Controls.Add(Me.PanelControl1)
        Me.LayoutControl1.Controls.Add(Me.lblStatus)
        Me.LayoutControl1.Controls.Add(Me.lblPhoneNumber)
        Me.LayoutControl1.Controls.Add(Me.lblTitle)
        Me.LayoutControl1.Controls.Add(Me.btnConnect)
        Me.LayoutControl1.Controls.Add(Me.btnRetry)
        Me.LayoutControl1.Controls.Add(Me.btnDisconnect)
        Me.LayoutControl1.Controls.Add(Me.btnClose)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(716, 213, 650, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(650, 600)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.picQRCode)
        Me.PanelControl1.Controls.Add(Me.lblQRInstruction)
        Me.PanelControl1.Location = New System.Drawing.Point(22, 160)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(606, 380)
        Me.PanelControl1.TabIndex = 12
        '
        'picQRCode
        '
        Me.picQRCode.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picQRCode.BackColor = System.Drawing.Color.White
        Me.picQRCode.Location = New System.Drawing.Point(153, 30)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(300, 300)
        Me.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picQRCode.TabIndex = 4
        Me.picQRCode.TabStop = False
        Me.picQRCode.Visible = False
        '
        'lblQRInstruction
        '
        Me.lblQRInstruction.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblQRInstruction.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblQRInstruction.Appearance.Options.UseFont = True
        Me.lblQRInstruction.Appearance.Options.UseForeColor = True
        Me.lblQRInstruction.Appearance.Options.UseTextOptions = True
        Me.lblQRInstruction.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblQRInstruction.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblQRInstruction.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblQRInstruction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblQRInstruction.Location = New System.Drawing.Point(0, 340)
        Me.lblQRInstruction.Name = "lblQRInstruction"
        Me.lblQRInstruction.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.lblQRInstruction.Size = New System.Drawing.Size(606, 40)
        Me.lblQRInstruction.TabIndex = 7
        Me.lblQRInstruction.Text = "📱 افتح واتساب على هاتفك > الإعدادات > الأجهزة المرتبطة > ربط جهاز > امسح الرمز"
        Me.lblQRInstruction.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStatus.Appearance.Options.UseFont = True
        Me.lblStatus.Appearance.Options.UseForeColor = True
        Me.lblStatus.Appearance.Options.UseTextOptions = True
        Me.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblStatus.Location = New System.Drawing.Point(22, 72)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(606, 21)
        Me.lblStatus.StyleController = Me.LayoutControl1
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "جاري التحقق من الحالة..."
        '
        'lblTitle
        '
        Me.lblTitle.Appearance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblTitle.Appearance.Options.UseFont = True
        Me.lblTitle.Appearance.Options.UseForeColor = True
        Me.lblTitle.Appearance.Options.UseTextOptions = True
        Me.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTitle.Location = New System.Drawing.Point(22, 22)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(606, 32)
        Me.lblTitle.StyleController = Me.LayoutControl1
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "💬 ربط واتساب"
        '
        'lblPhoneNumber
        '
        Me.lblPhoneNumber.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblPhoneNumber.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblPhoneNumber.Appearance.Options.UseFont = True
        Me.lblPhoneNumber.Appearance.Options.UseForeColor = True
        Me.lblPhoneNumber.Appearance.Options.UseTextOptions = True
        Me.lblPhoneNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblPhoneNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblPhoneNumber.Location = New System.Drawing.Point(22, 107)
        Me.lblPhoneNumber.Name = "lblPhoneNumber"
        Me.lblPhoneNumber.Size = New System.Drawing.Size(606, 20)
        Me.lblPhoneNumber.StyleController = Me.LayoutControl1
        Me.lblPhoneNumber.TabIndex = 6
        Me.lblPhoneNumber.Text = "📞 رقم الهاتف: "
        Me.lblPhoneNumber.Visible = False
        '
        'btnConnect
        '
        Me.btnConnect.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.btnConnect.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnConnect.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnConnect.Appearance.Options.UseBackColor = True
        Me.btnConnect.Appearance.Options.UseFont = True
        Me.btnConnect.Appearance.Options.UseForeColor = True
        Me.btnConnect.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(103, Byte), Integer))
        Me.btnConnect.AppearanceHovered.Options.UseBackColor = True
        Me.btnConnect.Location = New System.Drawing.Point(437, 544)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(191, 34)
        Me.btnConnect.StyleController = Me.LayoutControl1
        Me.btnConnect.TabIndex = 8
        Me.btnConnect.Text = "🔗 ربط الواتساب"
        '
        'btnRetry
        '
        Me.btnRetry.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnRetry.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRetry.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnRetry.Appearance.Options.UseBackColor = True
        Me.btnRetry.Appearance.Options.UseFont = True
        Me.btnRetry.Appearance.Options.UseForeColor = True
        Me.btnRetry.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnRetry.AppearanceHovered.Options.UseBackColor = True
        Me.btnRetry.Enabled = False
        Me.btnRetry.Location = New System.Drawing.Point(298, 544)
        Me.btnRetry.Name = "btnRetry"
        Me.btnRetry.Size = New System.Drawing.Size(135, 34)
        Me.btnRetry.StyleController = Me.LayoutControl1
        Me.btnRetry.TabIndex = 9
        Me.btnRetry.Text = "🔄 إعادة المحاولة"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnDisconnect.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDisconnect.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnDisconnect.Appearance.Options.UseBackColor = True
        Me.btnDisconnect.Appearance.Options.UseFont = True
        Me.btnDisconnect.Appearance.Options.UseForeColor = True
        Me.btnDisconnect.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDisconnect.AppearanceHovered.Options.UseBackColor = True
        Me.btnDisconnect.Enabled = False
        Me.btnDisconnect.Location = New System.Drawing.Point(159, 544)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(135, 34)
        Me.btnDisconnect.StyleController = Me.LayoutControl1
        Me.btnDisconnect.TabIndex = 10
        Me.btnDisconnect.Text = "❌ قطع الاتصال"
        '
        'btnClose
        '
        Me.btnClose.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnClose.Appearance.Options.UseBackColor = True
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.Appearance.Options.UseForeColor = True
        Me.btnClose.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnClose.AppearanceHovered.Options.UseBackColor = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(22, 544)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(133, 34)
        Me.btnClose.StyleController = Me.LayoutControl1
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "إغلاق"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem1, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem4, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(650, 600)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PanelControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 138)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(610, 384)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.lblStatus
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(610, 25)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.lblPhoneNumber
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 85)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(610, 24)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnClose
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 522)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(137, 38)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnConnect
        Me.LayoutControlItem5.Location = New System.Drawing.Point(415, 522)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(195, 38)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnRetry
        Me.LayoutControlItem6.Location = New System.Drawing.Point(276, 522)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(139, 38)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnDisconnect
        Me.LayoutControlItem7.Location = New System.Drawing.Point(137, 522)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(139, 38)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.lblTitle
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(610, 36)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 109)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(610, 29)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'checkTimer
        '
        Me.checkTimer.Interval = 5000
        '
        'LinkWhatsAppForm
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 600)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.ShowIcon = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LinkWhatsAppForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ربط واتساب - WhatsApp Link"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents picQRCode As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatus As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPhoneNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblQRInstruction As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnConnect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRetry As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDisconnect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents checkTimer As System.Windows.Forms.Timer
End Class
