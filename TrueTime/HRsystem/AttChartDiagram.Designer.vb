<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttChartDiagram
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
        Me.DiagramControl1 = New DevExpress.XtraDiagram.DiagramControl()
        Me.DiagramShape1 = New DevExpress.XtraDiagram.DiagramShape()
        CType(Me.DiagramControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DiagramControl1
        '
        Me.DiagramControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DiagramControl1.Items.AddRange(New DevExpress.XtraDiagram.DiagramItem() {Me.DiagramShape1})
        Me.DiagramControl1.Location = New System.Drawing.Point(0, 0)
        Me.DiagramControl1.Name = "DiagramControl1"
        Me.DiagramControl1.OptionsBehavior.SelectedStencils = New DevExpress.Diagram.Core.StencilCollection(New String() {"BasicShapes", "BasicFlowchartShapes", "ArrowShapes", "SDLDiagramShapes", "SoftwareIcons", "DecorativeShapes"})
        Me.DiagramControl1.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Letter
        Me.DiagramControl1.Size = New System.Drawing.Size(653, 493)
        Me.DiagramControl1.TabIndex = 0
        Me.DiagramControl1.Text = "DiagramControl1"
        '
        'DiagramShape1
        '
        Me.DiagramShape1.CanEdit = False
        Me.DiagramShape1.Content = "System.Data.DataViewManagerListItemTypeDescriptor"
        Me.DiagramShape1.Position = New DevExpress.Utils.PointFloat(478.0!, 24.0!)
        Me.DiagramShape1.Size = New System.Drawing.SizeF(100.0!, 75.0!)
        '
        'AttChartDiagram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 493)
        Me.Controls.Add(Me.DiagramControl1)
        Me.Name = "AttChartDiagram"
        Me.Text = "AttChartDiagram"
        CType(Me.DiagramControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DiagramControl1 As DevExpress.XtraDiagram.DiagramControl
    Friend WithEvents DiagramShape1 As DevExpress.XtraDiagram.DiagramShape
End Class
