<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistrationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistrationForm))
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckEditClient = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButtonClose = New DevExpress.XtraEditors.SimpleButton()
        Me.HyperlinkLabelControl1 = New DevExpress.XtraEditors.HyperlinkLabelControl()
        Me.TextSoftID = New DevExpress.XtraEditors.TextEdit()
        Me.TextRegistrationCode = New DevExpress.XtraEditors.TextEdit()
        Me.TextKey = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit6 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CheckEditClient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextSoftID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRegistrationCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextKey.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.CheckEditClient)
        Me.LayoutControl1.Controls.Add(Me.SimpleButtonClose)
        Me.LayoutControl1.Controls.Add(Me.HyperlinkLabelControl1)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.TextSoftID)
        Me.LayoutControl1.Controls.Add(Me.TextRegistrationCode)
        Me.LayoutControl1.Controls.Add(Me.TextKey)
        Me.LayoutControl1.Controls.Add(Me.TextEdit6)
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        '
        'CheckEditClient
        '
        resources.ApplyResources(Me.CheckEditClient, "CheckEditClient")
        Me.CheckEditClient.Name = "CheckEditClient"
        Me.CheckEditClient.Properties.Appearance.Font = CType(resources.GetObject("CheckEditClient.Properties.Appearance.Font"), System.Drawing.Font)
        Me.CheckEditClient.Properties.Appearance.Options.UseFont = True
        Me.CheckEditClient.Properties.Caption = resources.GetString("CheckEditClient.Properties.Caption")
        Me.CheckEditClient.StyleController = Me.LayoutControl1
        '
        'SimpleButtonClose
        '
        Me.SimpleButtonClose.ImageOptions.Image = CType(resources.GetObject("SimpleButtonClose.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButtonClose, "SimpleButtonClose")
        Me.SimpleButtonClose.Name = "SimpleButtonClose"
        Me.SimpleButtonClose.StyleController = Me.LayoutControl1
        '
        'HyperlinkLabelControl1
        '
        Me.HyperlinkLabelControl1.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.HyperlinkLabelControl1, "HyperlinkLabelControl1")
        Me.HyperlinkLabelControl1.Name = "HyperlinkLabelControl1"
        Me.HyperlinkLabelControl1.StyleController = Me.LayoutControl1
        '
        'TextSoftID
        '
        Me.BehaviorManager1.SetBehaviors(Me.TextSoftID, New DevExpress.Utils.Behaviors.Behavior() {CType(DevExpress.Utils.Behaviors.Common.FileIconBehavior.Create(GetType(DevExpress.XtraEditors.Behaviors.FileIconBehaviorSourceForTextEdit), DevExpress.Utils.Behaviors.Common.FileIconSize.Small, CType(resources.GetObject("TextSoftID.Behaviors"), System.Drawing.Image), CType(resources.GetObject("TextSoftID.Behaviors1"), System.Drawing.Image)), DevExpress.Utils.Behaviors.Behavior)})
        resources.ApplyResources(Me.TextSoftID, "TextSoftID")
        Me.TextSoftID.Name = "TextSoftID"
        Me.TextSoftID.Properties.Appearance.Font = CType(resources.GetObject("TextSoftID.Properties.Appearance.Font"), System.Drawing.Font)
        Me.TextSoftID.Properties.Appearance.Options.UseFont = True
        Me.TextSoftID.Properties.DisplayFormat.FormatString = "TTA{0}"
        Me.TextSoftID.StyleController = Me.LayoutControl1
        '
        'TextRegistrationCode
        '
        Me.BehaviorManager1.SetBehaviors(Me.TextRegistrationCode, New DevExpress.Utils.Behaviors.Behavior() {CType(DevExpress.Utils.Behaviors.Common.FileIconBehavior.Create(GetType(DevExpress.XtraEditors.Behaviors.FileIconBehaviorSourceForTextEdit), DevExpress.Utils.Behaviors.Common.FileIconSize.Small, CType(resources.GetObject("TextRegistrationCode.Behaviors"), System.Drawing.Image), CType(resources.GetObject("TextRegistrationCode.Behaviors1"), System.Drawing.Image)), DevExpress.Utils.Behaviors.Behavior)})
        resources.ApplyResources(Me.TextRegistrationCode, "TextRegistrationCode")
        Me.TextRegistrationCode.Name = "TextRegistrationCode"
        Me.TextRegistrationCode.Properties.Appearance.Font = CType(resources.GetObject("TextRegistrationCode.Properties.Appearance.Font"), System.Drawing.Font)
        Me.TextRegistrationCode.Properties.Appearance.Options.UseFont = True
        Me.TextRegistrationCode.StyleController = Me.LayoutControl1
        '
        'TextKey
        '
        Me.BehaviorManager1.SetBehaviors(Me.TextKey, New DevExpress.Utils.Behaviors.Behavior() {CType(DevExpress.Utils.Behaviors.Common.FileIconBehavior.Create(GetType(DevExpress.XtraEditors.Behaviors.FileIconBehaviorSourceForTextEdit), DevExpress.Utils.Behaviors.Common.FileIconSize.Small, Global.TrueTime.My.Resources.Resources.key_32, Global.TrueTime.My.Resources.Resources.key_32), DevExpress.Utils.Behaviors.Behavior)})
        resources.ApplyResources(Me.TextKey, "TextKey")
        Me.TextKey.Name = "TextKey"
        Me.TextKey.Properties.Appearance.Font = CType(resources.GetObject("TextKey.Properties.Appearance.Font"), System.Drawing.Font)
        Me.TextKey.Properties.Appearance.Options.UseFont = True
        Me.TextKey.Properties.ReadOnly = True
        Me.TextKey.StyleController = Me.LayoutControl1
        '
        'TextEdit6
        '
        resources.ApplyResources(Me.TextEdit6, "TextEdit6")
        Me.TextEdit6.Name = "TextEdit6"
        Me.TextEdit6.Properties.Appearance.Font = CType(resources.GetObject("TextEdit6.Properties.Appearance.Font"), System.Drawing.Font)
        Me.TextEdit6.Properties.Appearance.Options.UseFont = True
        Me.TextEdit6.Properties.ReadOnly = True
        Me.TextEdit6.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextEdit6.StyleController = Me.LayoutControl1
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AppearanceGroup.Font = CType(resources.GetObject("LayoutControlGroup1.AppearanceGroup.Font"), System.Drawing.Font)
        Me.LayoutControlGroup1.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem2, Me.LayoutControlItem1, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(662, 317)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(264, 162)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(138, 42)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(402, 162)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(89, 19)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(89, 42)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextKey
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(640, 54)
        resources.ApplyResources(Me.LayoutControlItem1, "LayoutControlItem1")
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TextRegistrationCode
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 108)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(640, 54)
        resources.ApplyResources(Me.LayoutControlItem6, "LayoutControlItem6")
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TextEdit6
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 204)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(12, 19)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(640, 63)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.HyperlinkLabelControl1
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 267)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(105, 17)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(640, 28)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SimpleButtonClose
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 162)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(81, 28)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(119, 42)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.TextSoftID
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 54)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(640, 54)
        resources.ApplyResources(Me.LayoutControlItem11, "LayoutControlItem11")
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.CheckEditClient
        Me.LayoutControlItem3.Location = New System.Drawing.Point(491, 162)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(149, 42)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SimpleButton2
        Me.LayoutControlItem4.Location = New System.Drawing.Point(119, 162)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(145, 42)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'RegistrationForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RegistrationForm"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CheckEditClient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextSoftID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRegistrationCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextKey.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextKey As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TextRegistrationCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents HyperlinkLabelControl1 As DevExpress.XtraEditors.HyperlinkLabelControl
    Friend WithEvents TextEdit6 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButtonClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextSoftID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckEditClient As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
End Class
