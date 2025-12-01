<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContractDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlStats = New System.Windows.Forms.Panel()
        Me.pnlTotalServices = New System.Windows.Forms.Panel()
        Me.lblTotalServicesCount = New System.Windows.Forms.Label()
        Me.lblTotalServicesTitle = New System.Windows.Forms.Label()
        Me.pnlActiveServices = New System.Windows.Forms.Panel()
        Me.lblActiveServicesCount = New System.Windows.Forms.Label()
        Me.lblActiveServicesTitle = New System.Windows.Forms.Label()
        Me.pnlInactiveServices = New System.Windows.Forms.Panel()
        Me.lblInactiveServicesCount = New System.Windows.Forms.Label()
        Me.lblInactiveServicesTitle = New System.Windows.Forms.Label()
        Me.pnlDeviceInfo = New System.Windows.Forms.Panel()
        Me.lblDeviceKey = New System.Windows.Forms.Label()
        Me.lblDeviceName = New System.Windows.Forms.Label()
        Me.pnlServices = New System.Windows.Forms.Panel()
        Me.flowLayoutServices = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblCompanyDeviceId = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlStats.SuspendLayout()
        Me.pnlTotalServices.SuspendLayout()
        Me.pnlActiveServices.SuspendLayout()
        Me.pnlInactiveServices.SuspendLayout()
        Me.pnlDeviceInfo.SuspendLayout()
        Me.pnlServices.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblCompanyDeviceId)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1200, 100)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(450, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitle.Size = New System.Drawing.Size(333, 45)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "تفاصيل العقد والخدمات"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlStats
        '
        Me.pnlStats.Controls.Add(Me.pnlTotalServices)
        Me.pnlStats.Controls.Add(Me.pnlActiveServices)
        Me.pnlStats.Controls.Add(Me.pnlInactiveServices)
        Me.pnlStats.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStats.Location = New System.Drawing.Point(0, 100)
        Me.pnlStats.Name = "pnlStats"
        Me.pnlStats.Padding = New System.Windows.Forms.Padding(20, 20, 20, 10)
        Me.pnlStats.Size = New System.Drawing.Size(1200, 120)
        Me.pnlStats.TabIndex = 1
        '
        'pnlTotalServices
        '
        Me.pnlTotalServices.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.pnlTotalServices.Controls.Add(Me.lblTotalServicesCount)
        Me.pnlTotalServices.Controls.Add(Me.lblTotalServicesTitle)
        Me.pnlTotalServices.Location = New System.Drawing.Point(820, 20)
        Me.pnlTotalServices.Name = "pnlTotalServices"
        Me.pnlTotalServices.Size = New System.Drawing.Size(360, 90)
        Me.pnlTotalServices.TabIndex = 0
        '
        'lblTotalServicesCount
        '
        Me.lblTotalServicesCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalServicesCount.Font = New System.Drawing.Font("Segoe UI", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalServicesCount.ForeColor = System.Drawing.Color.White
        Me.lblTotalServicesCount.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalServicesCount.Name = "lblTotalServicesCount"
        Me.lblTotalServicesCount.Size = New System.Drawing.Size(360, 55)
        Me.lblTotalServicesCount.TabIndex = 0
        Me.lblTotalServicesCount.Text = "0"
        Me.lblTotalServicesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalServicesTitle
        '
        Me.lblTotalServicesTitle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTotalServicesTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalServicesTitle.ForeColor = System.Drawing.Color.White
        Me.lblTotalServicesTitle.Location = New System.Drawing.Point(0, 55)
        Me.lblTotalServicesTitle.Name = "lblTotalServicesTitle"
        Me.lblTotalServicesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTotalServicesTitle.Size = New System.Drawing.Size(360, 35)
        Me.lblTotalServicesTitle.TabIndex = 1
        Me.lblTotalServicesTitle.Text = "إجمالي الخدمات"
        Me.lblTotalServicesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlActiveServices
        '
        Me.pnlActiveServices.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.pnlActiveServices.Controls.Add(Me.lblActiveServicesCount)
        Me.pnlActiveServices.Controls.Add(Me.lblActiveServicesTitle)
        Me.pnlActiveServices.Location = New System.Drawing.Point(440, 20)
        Me.pnlActiveServices.Name = "pnlActiveServices"
        Me.pnlActiveServices.Size = New System.Drawing.Size(360, 90)
        Me.pnlActiveServices.TabIndex = 1
        '
        'lblActiveServicesCount
        '
        Me.lblActiveServicesCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblActiveServicesCount.Font = New System.Drawing.Font("Segoe UI", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveServicesCount.ForeColor = System.Drawing.Color.White
        Me.lblActiveServicesCount.Location = New System.Drawing.Point(0, 0)
        Me.lblActiveServicesCount.Name = "lblActiveServicesCount"
        Me.lblActiveServicesCount.Size = New System.Drawing.Size(360, 55)
        Me.lblActiveServicesCount.TabIndex = 0
        Me.lblActiveServicesCount.Text = "0"
        Me.lblActiveServicesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblActiveServicesTitle
        '
        Me.lblActiveServicesTitle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblActiveServicesTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveServicesTitle.ForeColor = System.Drawing.Color.White
        Me.lblActiveServicesTitle.Location = New System.Drawing.Point(0, 55)
        Me.lblActiveServicesTitle.Name = "lblActiveServicesTitle"
        Me.lblActiveServicesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblActiveServicesTitle.Size = New System.Drawing.Size(360, 35)
        Me.lblActiveServicesTitle.TabIndex = 1
        Me.lblActiveServicesTitle.Text = "الخدمات النشطة"
        Me.lblActiveServicesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlInactiveServices
        '
        Me.pnlInactiveServices.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.pnlInactiveServices.Controls.Add(Me.lblInactiveServicesCount)
        Me.pnlInactiveServices.Controls.Add(Me.lblInactiveServicesTitle)
        Me.pnlInactiveServices.Location = New System.Drawing.Point(60, 20)
        Me.pnlInactiveServices.Name = "pnlInactiveServices"
        Me.pnlInactiveServices.Size = New System.Drawing.Size(360, 90)
        Me.pnlInactiveServices.TabIndex = 2
        '
        'lblInactiveServicesCount
        '
        Me.lblInactiveServicesCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInactiveServicesCount.Font = New System.Drawing.Font("Segoe UI", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInactiveServicesCount.ForeColor = System.Drawing.Color.White
        Me.lblInactiveServicesCount.Location = New System.Drawing.Point(0, 0)
        Me.lblInactiveServicesCount.Name = "lblInactiveServicesCount"
        Me.lblInactiveServicesCount.Size = New System.Drawing.Size(360, 55)
        Me.lblInactiveServicesCount.TabIndex = 0
        Me.lblInactiveServicesCount.Text = "0"
        Me.lblInactiveServicesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInactiveServicesTitle
        '
        Me.lblInactiveServicesTitle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblInactiveServicesTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInactiveServicesTitle.ForeColor = System.Drawing.Color.White
        Me.lblInactiveServicesTitle.Location = New System.Drawing.Point(0, 55)
        Me.lblInactiveServicesTitle.Name = "lblInactiveServicesTitle"
        Me.lblInactiveServicesTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblInactiveServicesTitle.Size = New System.Drawing.Size(360, 35)
        Me.lblInactiveServicesTitle.TabIndex = 1
        Me.lblInactiveServicesTitle.Text = "الخدمات غير النشطة"
        Me.lblInactiveServicesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDeviceInfo
        '
        Me.pnlDeviceInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlDeviceInfo.Controls.Add(Me.lblDeviceKey)
        Me.pnlDeviceInfo.Controls.Add(Me.lblDeviceName)
        Me.pnlDeviceInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDeviceInfo.Location = New System.Drawing.Point(0, 220)
        Me.pnlDeviceInfo.Name = "pnlDeviceInfo"
        Me.pnlDeviceInfo.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlDeviceInfo.Size = New System.Drawing.Size(1200, 120)
        Me.pnlDeviceInfo.TabIndex = 2
        '
        'lblDeviceKey
        '
        Me.lblDeviceKey.AutoSize = True
        Me.lblDeviceKey.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceKey.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblDeviceKey.Location = New System.Drawing.Point(1038, 70)
        Me.lblDeviceKey.Name = "lblDeviceKey"
        Me.lblDeviceKey.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDeviceKey.Size = New System.Drawing.Size(78, 19)
        Me.lblDeviceKey.TabIndex = 1
        Me.lblDeviceKey.Text = "المعرف: ---"
        '
        'lblDeviceName
        '
        Me.lblDeviceName.AutoSize = True
        Me.lblDeviceName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblDeviceName.Location = New System.Drawing.Point(1020, 10)
        Me.lblDeviceName.Name = "lblDeviceName"
        Me.lblDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDeviceName.Size = New System.Drawing.Size(96, 19)
        Me.lblDeviceName.TabIndex = 2
        Me.lblDeviceName.Text = "اسم الجهاز: ---"
        '
        'pnlServices
        '
        Me.pnlServices.AutoScroll = True
        Me.pnlServices.Controls.Add(Me.flowLayoutServices)
        Me.pnlServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlServices.Location = New System.Drawing.Point(0, 340)
        Me.pnlServices.Name = "pnlServices"
        Me.pnlServices.Padding = New System.Windows.Forms.Padding(20, 10, 20, 20)
        Me.pnlServices.Size = New System.Drawing.Size(1200, 360)
        Me.pnlServices.TabIndex = 3
        '
        'flowLayoutServices
        '
        Me.flowLayoutServices.AutoScroll = True
        Me.flowLayoutServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutServices.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowLayoutServices.Location = New System.Drawing.Point(20, 10)
        Me.flowLayoutServices.Name = "flowLayoutServices"
        Me.flowLayoutServices.Padding = New System.Windows.Forms.Padding(5)
        Me.flowLayoutServices.Size = New System.Drawing.Size(1160, 330)
        Me.flowLayoutServices.TabIndex = 0
        '
        'lblCompanyDeviceId
        '
        Me.lblCompanyDeviceId.AutoSize = True
        Me.lblCompanyDeviceId.Location = New System.Drawing.Point(588, 72)
        Me.lblCompanyDeviceId.Name = "lblCompanyDeviceId"
        Me.lblCompanyDeviceId.Size = New System.Drawing.Size(23, 13)
        Me.lblCompanyDeviceId.TabIndex = 1
        Me.lblCompanyDeviceId.Text = "CId"
        '
        'ContractDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.pnlServices)
        Me.Controls.Add(Me.pnlDeviceInfo)
        Me.Controls.Add(Me.pnlStats)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ContractDetails"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تفاصيل العقد والخدمات"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlStats.ResumeLayout(False)
        Me.pnlTotalServices.ResumeLayout(False)
        Me.pnlActiveServices.ResumeLayout(False)
        Me.pnlInactiveServices.ResumeLayout(False)
        Me.pnlDeviceInfo.ResumeLayout(False)
        Me.pnlDeviceInfo.PerformLayout()
        Me.pnlServices.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlStats As Panel
    Friend WithEvents pnlTotalServices As Panel
    Friend WithEvents lblTotalServicesCount As Label
    Friend WithEvents lblTotalServicesTitle As Label
    Friend WithEvents pnlActiveServices As Panel
    Friend WithEvents lblActiveServicesCount As Label
    Friend WithEvents lblActiveServicesTitle As Label
    Friend WithEvents pnlInactiveServices As Panel
    Friend WithEvents lblInactiveServicesCount As Label
    Friend WithEvents lblInactiveServicesTitle As Label
    Friend WithEvents pnlDeviceInfo As Panel
    Friend WithEvents lblDeviceKey As Label
    Friend WithEvents lblDeviceName As Label
    Friend WithEvents pnlServices As Panel
    Friend WithEvents flowLayoutServices As FlowLayoutPanel
    Friend WithEvents lblCompanyDeviceId As Label
End Class
