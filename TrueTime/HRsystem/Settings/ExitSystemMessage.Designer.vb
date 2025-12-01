<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExitSystemMessage
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExitSystemMessage))
        Me.HtmlContentPopup1 = New DevExpress.XtraEditors.HtmlContentPopup(Me.components)
        CType(Me.HtmlContentPopup1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HtmlContentPopup1
        '
        Me.HtmlContentPopup1.HtmlTemplate.Styles = resources.GetString("HtmlContentPopup1.HtmlTemplate.Styles")
        Me.HtmlContentPopup1.HtmlTemplate.Template = resources.GetString("HtmlContentPopup1.HtmlTemplate.Template")
        '
        'ExitSystemMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 266)
        Me.Name = "ExitSystemMessage"
        Me.Text = "ExitSystemMessage"
        CType(Me.HtmlContentPopup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HtmlContentPopup1 As DevExpress.XtraEditors.HtmlContentPopup
End Class
