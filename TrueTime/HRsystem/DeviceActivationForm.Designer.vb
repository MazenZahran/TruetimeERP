<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DeviceActivationForm
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblDeviceName = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblDBName = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.btnRequestActivation = New System.Windows.Forms.Button()
        Me.btnCheckActivation = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtRequestedBy = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DBName = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(190, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitle.Size = New System.Drawing.Size(153, 23)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "الجهاز غير مفعل"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblMessage.Location = New System.Drawing.Point(30, 60)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(520, 40)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = " الجهاز غير مفعل . يرجى طلب التفعيل" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "أو فحص حالة التفعيل إذا كنت قد أرسلت طلباً م" &
    "سبقاً."
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDeviceName
        '
        Me.lblDeviceName.AutoSize = True
        Me.lblDeviceName.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblDeviceName.Location = New System.Drawing.Point(330, 29)
        Me.lblDeviceName.Name = "lblDeviceName"
        Me.lblDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDeviceName.Size = New System.Drawing.Size(71, 14)
        Me.lblDeviceName.TabIndex = 2
        Me.lblDeviceName.Text = "اسم الجهاز: "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.lblDBName)
        Me.GroupBox1.Controls.Add(Me.lblDeviceName)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(520, 110)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معلومات الجهاز"
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblStatus.Location = New System.Drawing.Point(20, 85)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblStatus.Size = New System.Drawing.Size(480, 20)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "في انتظار الطلب..."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDBName
        '
        Me.lblDBName.AutoSize = True
        Me.lblDBName.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblDBName.Location = New System.Drawing.Point(330, 71)
        Me.lblDBName.Name = "lblDBName"
        Me.lblDBName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDBName.Size = New System.Drawing.Size(27, 14)
        Me.lblDBName.TabIndex = 2
        Me.lblDBName.Text = "....."
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtNotes.Location = New System.Drawing.Point(30, 274)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(520, 80)
        Me.txtNotes.TabIndex = 5
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblNotes.ForeColor = System.Drawing.Color.Red
        Me.lblNotes.Location = New System.Drawing.Point(447, 257)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNotes.Size = New System.Drawing.Size(103, 14)
        Me.lblNotes.TabIndex = 6
        Me.lblNotes.Text = "الملاحظة (إجبارية):"
        '
        'btnRequestActivation
        '
        Me.btnRequestActivation.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnRequestActivation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequestActivation.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRequestActivation.ForeColor = System.Drawing.Color.White
        Me.btnRequestActivation.Location = New System.Drawing.Point(360, 360)
        Me.btnRequestActivation.Name = "btnRequestActivation"
        Me.btnRequestActivation.Size = New System.Drawing.Size(190, 40)
        Me.btnRequestActivation.TabIndex = 7
        Me.btnRequestActivation.Text = "طلب التفعيل"
        Me.btnRequestActivation.UseVisualStyleBackColor = False
        '
        'btnCheckActivation
        '
        Me.btnCheckActivation.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnCheckActivation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckActivation.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheckActivation.ForeColor = System.Drawing.Color.White
        Me.btnCheckActivation.Location = New System.Drawing.Point(195, 360)
        Me.btnCheckActivation.Name = "btnCheckActivation"
        Me.btnCheckActivation.Size = New System.Drawing.Size(150, 40)
        Me.btnCheckActivation.TabIndex = 8
        Me.btnCheckActivation.Text = "فحص التفعيل"
        Me.btnCheckActivation.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(30, 360)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(150, 40)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "إغلاق "
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TrueTime.My.Resources.Resources.TTS_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(30, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'txtRequestedBy
        '
        Me.txtRequestedBy.Location = New System.Drawing.Point(42, 230)
        Me.txtRequestedBy.Name = "txtRequestedBy"
        Me.txtRequestedBy.Size = New System.Drawing.Size(387, 20)
        Me.txtRequestedBy.TabIndex = 11
        Me.txtRequestedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(435, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(115, 14)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "طلب التفعيل بواسطة:"
        '
        'DBName
        '
        Me.DBName.AutoSize = True
        Me.DBName.Location = New System.Drawing.Point(507, 10)
        Me.DBName.Name = "DBName"
        Me.DBName.Size = New System.Drawing.Size(13, 13)
        Me.DBName.TabIndex = 13
        Me.DBName.Text = ".."
        Me.DBName.UseMnemonic = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(415, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(31, 24)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "⭮"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DeviceActivationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 420)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DBName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRequestedBy)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCheckActivation)
        Me.Controls.Add(Me.btnRequestActivation)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Image = Global.TrueTime.My.Resources.Resources.TTS_Logo
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DeviceActivationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تفعيل الجهاز - TrueTime System"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents lblDeviceName As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents btnRequestActivation As Button
    Friend WithEvents btnCheckActivation As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblDBName As Label
    Friend WithEvents txtRequestedBy As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DBName As Label
    Friend WithEvents Button1 As Button
End Class