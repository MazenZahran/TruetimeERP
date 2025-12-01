<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmItemColorImages
    Inherits DevExpress.XtraEditors.XtraForm

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelInfo = New DevExpress.XtraEditors.PanelControl()
        Me.FlowLayoutImages = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelImagesFor = New DevExpress.XtraEditors.LabelControl()
        Me.BtnAddImage = New DevExpress.XtraEditors.SimpleButton()
        Me.ListBoxColors = New DevExpress.XtraEditors.ListBoxControl()
        Me.LabelAvailableColors = New DevExpress.XtraEditors.LabelControl()
        Me.LabelProductName = New DevExpress.XtraEditors.LabelControl()
        Me.PanelImages = New DevExpress.XtraEditors.PanelControl()
        Me.TxtProductName = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelInfo.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.ListBoxColors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelImages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelImages.SuspendLayout()
        CType(Me.TxtProductName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelInfo
        '
        Me.PanelInfo.Controls.Add(Me.FlowLayoutImages)
        Me.PanelInfo.Controls.Add(Me.FlowLayoutPanel1)
        Me.PanelInfo.Controls.Add(Me.BtnAddImage)
        Me.PanelInfo.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelInfo.Location = New System.Drawing.Point(274, 0)
        Me.PanelInfo.Name = "PanelInfo"
        Me.PanelInfo.Size = New System.Drawing.Size(769, 522)
        Me.PanelInfo.TabIndex = 0
        '
        'FlowLayoutImages
        '
        Me.FlowLayoutImages.AutoScroll = True
        Me.FlowLayoutImages.Location = New System.Drawing.Point(12, 53)
        Me.FlowLayoutImages.Name = "FlowLayoutImages"
        Me.FlowLayoutImages.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlowLayoutImages.Size = New System.Drawing.Size(751, 464)
        Me.FlowLayoutImages.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelImagesFor)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(249, 5)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(520, 40)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'LabelImagesFor
        '
        Me.LabelImagesFor.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelImagesFor.Appearance.Options.UseFont = True
        Me.LabelImagesFor.Appearance.Options.UseTextOptions = True
        Me.LabelImagesFor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelImagesFor.Location = New System.Drawing.Point(420, 3)
        Me.LabelImagesFor.Name = "LabelImagesFor"
        Me.LabelImagesFor.Size = New System.Drawing.Size(97, 25)
        Me.LabelImagesFor.TabIndex = 2
        Me.LabelImagesFor.Text = "صور الصنف"
        '
        'BtnAddImage
        '
        Me.BtnAddImage.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnAddImage.Appearance.Options.UseFont = True
        Me.BtnAddImage.Location = New System.Drawing.Point(12, 5)
        Me.BtnAddImage.Name = "BtnAddImage"
        Me.BtnAddImage.Size = New System.Drawing.Size(179, 40)
        Me.BtnAddImage.TabIndex = 0
        Me.BtnAddImage.Text = "+ إضافة صورة جديدة"
        '
        'ListBoxColors
        '
        Me.ListBoxColors.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ListBoxColors.Appearance.Options.UseFont = True
        Me.ListBoxColors.Location = New System.Drawing.Point(18, 149)
        Me.ListBoxColors.Name = "ListBoxColors"
        Me.ListBoxColors.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListBoxColors.Size = New System.Drawing.Size(244, 370)
        Me.ListBoxColors.TabIndex = 0
        '
        'LabelAvailableColors
        '
        Me.LabelAvailableColors.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelAvailableColors.Appearance.Options.UseFont = True
        Me.LabelAvailableColors.Appearance.Options.UseTextOptions = True
        Me.LabelAvailableColors.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelAvailableColors.Location = New System.Drawing.Point(164, 107)
        Me.LabelAvailableColors.Name = "LabelAvailableColors"
        Me.LabelAvailableColors.Size = New System.Drawing.Size(98, 23)
        Me.LabelAvailableColors.TabIndex = 1
        Me.LabelAvailableColors.Text = "الألوان المتاحة"
        '
        'LabelProductName
        '
        Me.LabelProductName.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelProductName.Appearance.Options.UseFont = True
        Me.LabelProductName.Appearance.Options.UseTextOptions = True
        Me.LabelProductName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelProductName.Location = New System.Drawing.Point(179, 11)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(83, 23)
        Me.LabelProductName.TabIndex = 3
        Me.LabelProductName.Text = "اسم الصنف"
        '
        'PanelImages
        '
        Me.PanelImages.Controls.Add(Me.TxtProductName)
        Me.PanelImages.Controls.Add(Me.ListBoxColors)
        Me.PanelImages.Controls.Add(Me.LabelProductName)
        Me.PanelImages.Controls.Add(Me.LabelAvailableColors)
        Me.PanelImages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelImages.Location = New System.Drawing.Point(0, 0)
        Me.PanelImages.Name = "PanelImages"
        Me.PanelImages.Size = New System.Drawing.Size(274, 522)
        Me.PanelImages.TabIndex = 1
        '
        'TxtProductName
        '
        Me.TxtProductName.Location = New System.Drawing.Point(18, 44)
        Me.TxtProductName.Name = "TxtProductName"
        Me.TxtProductName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TxtProductName.Properties.Appearance.Options.UseFont = True
        Me.TxtProductName.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtProductName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TxtProductName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtProductName.Size = New System.Drawing.Size(244, 40)
        Me.TxtProductName.TabIndex = 2
        '
        'FrmItemColorImages
        '
        Me.Appearance.Options.UseFont = True
        Me.ClientSize = New System.Drawing.Size(1043, 522)
        Me.Controls.Add(Me.PanelImages)
        Me.Controls.Add(Me.PanelInfo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Name = "FrmItemColorImages"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "تفاصيل الألوان والصور"
        CType(Me.PanelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelInfo.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.ListBoxColors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelImages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelImages.ResumeLayout(False)
        Me.PanelImages.PerformLayout()
        CType(Me.TxtProductName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelInfo As DevExpress.XtraEditors.PanelControl
    Friend WithEvents ListBoxColors As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents LabelAvailableColors As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtProductName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelProductName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelImages As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAddImage As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FlowLayoutImages As FlowLayoutPanel
    Friend WithEvents LabelImagesFor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
