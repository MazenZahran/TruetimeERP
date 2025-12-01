<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ZenHrSyncData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ZenHrSyncData))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelConnectionResult = New DevExpress.XtraEditors.LabelControl()
        Me.LabelUnreadTransResult = New DevExpress.XtraEditors.LabelControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItemUnreadTransontts = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItemTestConnection = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItemProgress = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LabelreadTransResult = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlItemreadTransontts = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LabelResult = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlItemResult = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemUnreadTransontts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemTestConnection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemreadTransontts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.LabelResult)
        Me.LayoutControl1.Controls.Add(Me.LabelreadTransResult)
        Me.LayoutControl1.Controls.Add(Me.ProgressBarControl1)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.LabelConnectionResult)
        Me.LayoutControl1.Controls.Add(Me.LabelUnreadTransResult)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(485, 243, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(437, 504)
        Me.LayoutControl1.TabIndex = 3
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(12, 482)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Size = New System.Drawing.Size(413, 10)
        Me.ProgressBarControl1.StyleController = Me.LayoutControl1
        Me.ProgressBarControl1.TabIndex = 5
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(12, 48)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(204, 22)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 4
        Me.SimpleButton2.Text = "Sync Data ..."
        '
        'LabelConnectionResult
        '
        Me.LabelConnectionResult.Location = New System.Drawing.Point(325, 97)
        Me.LabelConnectionResult.Name = "LabelConnectionResult"
        Me.LabelConnectionResult.Size = New System.Drawing.Size(100, 17)
        Me.LabelConnectionResult.StyleController = Me.LayoutControl1
        Me.LabelConnectionResult.TabIndex = 2
        Me.LabelConnectionResult.Text = "                         "
        '
        'LabelUnreadTransResult
        '
        Me.LabelUnreadTransResult.Location = New System.Drawing.Point(325, 118)
        Me.LabelUnreadTransResult.Name = "LabelUnreadTransResult"
        Me.LabelUnreadTransResult.Size = New System.Drawing.Size(100, 17)
        Me.LabelUnreadTransResult.StyleController = Me.LayoutControl1
        Me.LabelUnreadTransResult.TabIndex = 1
        Me.LabelUnreadTransResult.Text = "                         "
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItemUnreadTransontts, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem4, Me.LayoutControlItemTestConnection, Me.LayoutControlItemProgress, Me.LayoutControlItemreadTransontts, Me.LayoutControlItemResult})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(437, 504)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton2
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 36)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(208, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 169)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(417, 301)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItemUnreadTransontts
        '
        Me.LayoutControlItemUnreadTransontts.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItemUnreadTransontts.Control = Me.LabelUnreadTransResult
        Me.LayoutControlItemUnreadTransontts.Location = New System.Drawing.Point(0, 106)
        Me.LayoutControlItemUnreadTransontts.Name = "LayoutControlItemUnreadTransontts"
        Me.LayoutControlItemUnreadTransontts.Size = New System.Drawing.Size(417, 21)
        Me.LayoutControlItemUnreadTransontts.Text = "The number of unread transactions:"
        Me.LayoutControlItemUnreadTransontts.TextSize = New System.Drawing.Size(208, 17)
        Me.LayoutControlItemUnreadTransontts.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(0, 36)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(10, 36)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(417, 36)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(208, 36)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(209, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 62)
        Me.EmptySpaceItem4.MaxSize = New System.Drawing.Size(0, 23)
        Me.EmptySpaceItem4.MinSize = New System.Drawing.Size(10, 23)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(417, 23)
        Me.EmptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItemTestConnection
        '
        Me.LayoutControlItemTestConnection.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItemTestConnection.Control = Me.LabelConnectionResult
        Me.LayoutControlItemTestConnection.Location = New System.Drawing.Point(0, 85)
        Me.LayoutControlItemTestConnection.Name = "LayoutControlItemTestConnection"
        Me.LayoutControlItemTestConnection.Size = New System.Drawing.Size(417, 21)
        Me.LayoutControlItemTestConnection.Text = "Testing connection with Zen:"
        Me.LayoutControlItemTestConnection.TextSize = New System.Drawing.Size(208, 17)
        Me.LayoutControlItemTestConnection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItemProgress
        '
        Me.LayoutControlItemProgress.Control = Me.ProgressBarControl1
        Me.LayoutControlItemProgress.Location = New System.Drawing.Point(0, 470)
        Me.LayoutControlItemProgress.Name = "LayoutControlItemProgress"
        Me.LayoutControlItemProgress.Size = New System.Drawing.Size(417, 14)
        Me.LayoutControlItemProgress.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItemProgress.TextVisible = False
        Me.LayoutControlItemProgress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LabelreadTransResult
        '
        Me.LabelreadTransResult.Location = New System.Drawing.Point(369, 139)
        Me.LabelreadTransResult.Name = "LabelreadTransResult"
        Me.LabelreadTransResult.Size = New System.Drawing.Size(56, 17)
        Me.LabelreadTransResult.StyleController = Me.LayoutControl1
        Me.LabelreadTransResult.TabIndex = 6
        Me.LabelreadTransResult.Text = "              "
        '
        'LayoutControlItemreadTransontts
        '
        Me.LayoutControlItemreadTransontts.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItemreadTransontts.Control = Me.LabelreadTransResult
        Me.LayoutControlItemreadTransontts.Location = New System.Drawing.Point(0, 127)
        Me.LayoutControlItemreadTransontts.Name = "LayoutControlItemreadTransontts"
        Me.LayoutControlItemreadTransontts.Size = New System.Drawing.Size(417, 21)
        Me.LayoutControlItemreadTransontts.Text = "The number of read tranactions:"
        Me.LayoutControlItemreadTransontts.TextSize = New System.Drawing.Size(208, 17)
        Me.LayoutControlItemreadTransontts.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LabelResult
        '
        Me.LabelResult.Location = New System.Drawing.Point(349, 160)
        Me.LabelResult.Name = "LabelResult"
        Me.LabelResult.Size = New System.Drawing.Size(76, 17)
        Me.LabelResult.StyleController = Me.LayoutControl1
        Me.LabelResult.TabIndex = 7
        Me.LabelResult.Text = "                   "
        '
        'LayoutControlItemResult
        '
        Me.LayoutControlItemResult.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItemResult.Control = Me.LabelResult
        Me.LayoutControlItemResult.Location = New System.Drawing.Point(0, 148)
        Me.LayoutControlItemResult.Name = "LayoutControlItemResult"
        Me.LayoutControlItemResult.Size = New System.Drawing.Size(417, 21)
        Me.LayoutControlItemResult.Text = "Sync Result:"
        Me.LayoutControlItemResult.TextSize = New System.Drawing.Size(208, 17)
        Me.LayoutControlItemResult.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'ZenHrSyncData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 504)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("ZenHrSyncData.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Name = "ZenHrSyncData"
        Me.Text = "Sync Data With Zen Hr Sysytem"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemUnreadTransontts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemTestConnection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemProgress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemreadTransontts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LabelConnectionResult As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LabelUnreadTransResult As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItemUnreadTransontts As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItemTestConnection As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents LayoutControlItemProgress As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LabelreadTransResult As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItemreadTransontts As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LabelResult As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItemResult As DevExpress.XtraLayout.LayoutControlItem
End Class
