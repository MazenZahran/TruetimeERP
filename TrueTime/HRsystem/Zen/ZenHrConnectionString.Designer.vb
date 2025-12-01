<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZenHrConnectionString
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ZenHrConnectionString))
        Me.cboServer = New System.Windows.Forms.ComboBox()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtUsername = New DevExpress.XtraEditors.TextEdit()
        Me.txtDatabase = New DevExpress.XtraEditors.TextEdit()
        Me.TablePanel1 = New DevExpress.Utils.Layout.TablePanel()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TablePanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TablePanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboServer
        '
        Me.TablePanel1.SetColumn(Me.cboServer, 2)
        Me.cboServer.FormattingEnabled = True
        Me.cboServer.Location = New System.Drawing.Point(111, 30)
        Me.cboServer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboServer.Name = "cboServer"
        Me.TablePanel1.SetRow(Me.cboServer, 1)
        Me.cboServer.Size = New System.Drawing.Size(469, 25)
        Me.cboServer.TabIndex = 10
        '
        'txtPassword
        '
        Me.TablePanel1.SetColumn(Me.txtPassword, 2)
        Me.txtPassword.Location = New System.Drawing.Point(111, 108)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Properties.UseSystemPasswordChar = True
        Me.TablePanel1.SetRow(Me.txtPassword, 4)
        Me.txtPassword.Size = New System.Drawing.Size(469, 24)
        Me.txtPassword.TabIndex = 7
        '
        'txtUsername
        '
        Me.TablePanel1.SetColumn(Me.txtUsername, 2)
        Me.txtUsername.Location = New System.Drawing.Point(111, 82)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUsername.Name = "txtUsername"
        Me.TablePanel1.SetRow(Me.txtUsername, 3)
        Me.txtUsername.Size = New System.Drawing.Size(469, 24)
        Me.txtUsername.TabIndex = 8
        '
        'txtDatabase
        '
        Me.TablePanel1.SetColumn(Me.txtDatabase, 2)
        Me.txtDatabase.Location = New System.Drawing.Point(111, 56)
        Me.txtDatabase.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDatabase.Name = "txtDatabase"
        Me.TablePanel1.SetRow(Me.txtDatabase, 2)
        Me.txtDatabase.Size = New System.Drawing.Size(469, 24)
        Me.txtDatabase.TabIndex = 9
        '
        'TablePanel1
        '
        Me.TablePanel1.AutoScroll = True
        Me.TablePanel1.AutoSize = True
        Me.TablePanel1.Columns.AddRange(New DevExpress.Utils.Layout.TablePanelColumn() {New DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5.0!), New DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 15.17!), New DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 89.83!)})
        Me.TablePanel1.Controls.Add(Me.SimpleButton1)
        Me.TablePanel1.Controls.Add(Me.LabelControl4)
        Me.TablePanel1.Controls.Add(Me.txtPassword)
        Me.TablePanel1.Controls.Add(Me.LabelControl3)
        Me.TablePanel1.Controls.Add(Me.LabelControl2)
        Me.TablePanel1.Controls.Add(Me.LabelControl1)
        Me.TablePanel1.Controls.Add(Me.txtUsername)
        Me.TablePanel1.Controls.Add(Me.cboServer)
        Me.TablePanel1.Controls.Add(Me.txtDatabase)
        Me.TablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.TablePanel1.Name = "TablePanel1"
        Me.TablePanel1.Rows.AddRange(New DevExpress.Utils.Layout.TablePanelRow() {New DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26.0!), New DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26.0!), New DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26.0!), New DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26.0!), New DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26.0!), New DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26.0!), New DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26.0!)})
        Me.TablePanel1.Size = New System.Drawing.Size(584, 196)
        Me.TablePanel1.TabIndex = 11
        '
        'LabelControl1
        '
        Me.TablePanel1.SetColumn(Me.LabelControl1, 1)
        Me.LabelControl1.Location = New System.Drawing.Point(30, 30)
        Me.LabelControl1.Name = "LabelControl1"
        Me.TablePanel1.SetRow(Me.LabelControl1, 1)
        Me.LabelControl1.Size = New System.Drawing.Size(40, 17)
        Me.LabelControl1.TabIndex = 11
        Me.LabelControl1.Text = "Server:"
        '
        'LabelControl2
        '
        Me.TablePanel1.SetColumn(Me.LabelControl2, 1)
        Me.LabelControl2.Location = New System.Drawing.Point(30, 59)
        Me.LabelControl2.Name = "LabelControl2"
        Me.TablePanel1.SetRow(Me.LabelControl2, 2)
        Me.LabelControl2.Size = New System.Drawing.Size(30, 16)
        Me.LabelControl2.TabIndex = 12
        Me.LabelControl2.Text = "Data:"
        '
        'LabelControl3
        '
        Me.TablePanel1.SetColumn(Me.LabelControl3, 1)
        Me.LabelControl3.Location = New System.Drawing.Point(30, 86)
        Me.LabelControl3.Name = "LabelControl3"
        Me.TablePanel1.SetRow(Me.LabelControl3, 3)
        Me.LabelControl3.Size = New System.Drawing.Size(30, 15)
        Me.LabelControl3.TabIndex = 13
        Me.LabelControl3.Text = "User:"
        '
        'LabelControl4
        '
        Me.TablePanel1.SetColumn(Me.LabelControl4, 1)
        Me.LabelControl4.Location = New System.Drawing.Point(30, 111)
        Me.LabelControl4.Name = "LabelControl4"
        Me.TablePanel1.SetRow(Me.LabelControl4, 4)
        Me.LabelControl4.Size = New System.Drawing.Size(59, 16)
        Me.LabelControl4.TabIndex = 14
        Me.LabelControl4.Text = "Password:"
        '
        'SimpleButton1
        '
        Me.TablePanel1.SetColumn(Me.SimpleButton1, 2)
        Me.SimpleButton1.Location = New System.Drawing.Point(110, 164)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.TablePanel1.SetRow(Me.SimpleButton1, 6)
        Me.SimpleButton1.Size = New System.Drawing.Size(471, 23)
        Me.SimpleButton1.TabIndex = 15
        Me.SimpleButton1.Text = "Save"
        '
        'ZenHrConnectionString
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 196)
        Me.Controls.Add(Me.TablePanel1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("ZenHrConnectionString.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ZenHrConnectionString"
        Me.Text = "ZenHrConnectionString"
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TablePanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TablePanel1.ResumeLayout(False)
        Me.TablePanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboServer As ComboBox
    Friend WithEvents TablePanel1 As DevExpress.Utils.Layout.TablePanel
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDatabase As DevExpress.XtraEditors.TextEdit
End Class
