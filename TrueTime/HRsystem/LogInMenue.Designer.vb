<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LogInMenue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogInMenue))
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnTest = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEdit3 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckRememberMe = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextPassword = New DevExpress.XtraEditors.TextEdit()
        Me.TextUserName = New DevExpress.XtraEditors.TextEdit()
        Me.HtmlTemplateCollection1 = New DevExpress.Utils.Html.HtmlTemplateCollection()
        Me.HtmlTemplate1 = New DevExpress.Utils.Html.HtmlTemplate()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PictureEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckRememberMe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = Global.TrueTime.My.Resources.Resources.TTS_Logo
        resources.ApplyResources(Me.PictureEdit1, "PictureEdit1")
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.BtnTest)
        Me.GroupControl1.Controls.Add(Me.PictureEdit3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.PictureEdit1)
        Me.GroupControl1.Controls.Add(Me.CheckRememberMe)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.TextPassword)
        Me.GroupControl1.Controls.Add(Me.TextUserName)
        resources.ApplyResources(Me.GroupControl1, "GroupControl1")
        Me.GroupControl1.Name = "GroupControl1"
        '
        'SimpleButton2
        '
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.Name = "SimpleButton2"
        '
        'BtnTest
        '
        Me.BtnTest.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.BtnTest.Appearance.Font = CType(resources.GetObject("BtnTest.Appearance.Font"), System.Drawing.Font)
        Me.BtnTest.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnTest.Appearance.Options.UseBackColor = True
        Me.BtnTest.Appearance.Options.UseFont = True
        Me.BtnTest.Appearance.Options.UseForeColor = True
        resources.ApplyResources(Me.BtnTest, "BtnTest")
        Me.BtnTest.Name = "BtnTest"
        '
        'PictureEdit3
        '
        resources.ApplyResources(Me.PictureEdit3, "PictureEdit3")
        Me.PictureEdit3.Name = "PictureEdit3"
        Me.PictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PictureEdit3.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = CType(resources.GetObject("LabelControl2.Appearance.Font"), System.Drawing.Font)
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        resources.ApplyResources(Me.LabelControl2, "LabelControl2")
        Me.LabelControl2.Name = "LabelControl2"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = CType(resources.GetObject("LabelControl1.Appearance.Font"), System.Drawing.Font)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'CheckRememberMe
        '
        resources.ApplyResources(Me.CheckRememberMe, "CheckRememberMe")
        Me.CheckRememberMe.Name = "CheckRememberMe"
        Me.CheckRememberMe.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.CheckRememberMe.Properties.Appearance.Options.UseForeColor = True
        Me.CheckRememberMe.Properties.Caption = resources.GetString("CheckRememberMe.Properties.Caption")
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.SimpleButton1.Appearance.Font = CType(resources.GetObject("SimpleButton1.Appearance.Font"), System.Drawing.Font)
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        '
        'TextPassword
        '
        resources.ApplyResources(Me.TextPassword, "TextPassword")
        Me.TextPassword.EnterMoveNextControl = True
        Me.TextPassword.Name = "TextPassword"
        Me.TextPassword.Properties.Appearance.Font = CType(resources.GetObject("TextPassword.Properties.Appearance.Font"), System.Drawing.Font)
        Me.TextPassword.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextPassword.Properties.Appearance.Options.UseFont = True
        Me.TextPassword.Properties.Appearance.Options.UseForeColor = True
        Me.TextPassword.Properties.Appearance.Options.UseTextOptions = True
        Me.TextPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TextPassword.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TextPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TextPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        '
        'TextUserName
        '
        resources.ApplyResources(Me.TextUserName, "TextUserName")
        Me.TextUserName.EnterMoveNextControl = True
        Me.TextUserName.Name = "TextUserName"
        Me.TextUserName.Properties.Appearance.Font = CType(resources.GetObject("TextUserName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.TextUserName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextUserName.Properties.Appearance.Options.UseFont = True
        Me.TextUserName.Properties.Appearance.Options.UseForeColor = True
        Me.TextUserName.Properties.Appearance.Options.UseTextOptions = True
        Me.TextUserName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TextUserName.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TextUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        '
        'HtmlTemplateCollection1
        '
        Me.HtmlTemplateCollection1.AddRange(New DevExpress.Utils.Html.HtmlTemplate() {Me.HtmlTemplate1})
        '
        'HtmlTemplate1
        '
        Me.HtmlTemplate1.Name = "HtmlTemplate1"
        resources.ApplyResources(Me.HtmlTemplate1, "HtmlTemplate1")
        '
        'LogInMenue
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IconOptions.Image = Global.TrueTime.My.Resources.Resources.TTS_Logo
        Me.LookAndFeel.SkinName = "Office 2013"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "LogInMenue"
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.PictureEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckRememberMe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckRememberMe As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextUserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PictureEdit3 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents HtmlTemplateCollection1 As DevExpress.Utils.Html.HtmlTemplateCollection
    Friend WithEvents HtmlTemplate1 As DevExpress.Utils.Html.HtmlTemplate
    Friend WithEvents BtnTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
