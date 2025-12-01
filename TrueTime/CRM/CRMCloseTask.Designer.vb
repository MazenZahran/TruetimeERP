<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMCloseTask
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRMCloseTask))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CurrentTaskStatus = New DevExpress.XtraEditors.TextEdit()
        Me.LastTaskStatus = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SearchCreationUser = New DevExpress.XtraEditors.TextEdit()
        Me.UniqueID = New DevExpress.XtraEditors.TextEdit()
        Me.DateOfDone = New DevExpress.XtraEditors.DateEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.MemoCloseNote = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CurrentTaskStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LastTaskStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchCreationUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UniqueID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateOfDone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateOfDone.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoCloseNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.CurrentTaskStatus)
        Me.LayoutControl1.Controls.Add(Me.LastTaskStatus)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.SearchCreationUser)
        Me.LayoutControl1.Controls.Add(Me.UniqueID)
        Me.LayoutControl1.Controls.Add(Me.DateOfDone)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.MemoCloseNote)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(800, 347)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CurrentTaskStatus
        '
        Me.CurrentTaskStatus.Location = New System.Drawing.Point(13, 162)
        Me.CurrentTaskStatus.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CurrentTaskStatus.Name = "CurrentTaskStatus"
        Me.CurrentTaskStatus.Size = New System.Drawing.Size(121, 34)
        Me.CurrentTaskStatus.StyleController = Me.LayoutControl1
        Me.CurrentTaskStatus.TabIndex = 11
        '
        'LastTaskStatus
        '
        Me.LastTaskStatus.Location = New System.Drawing.Point(280, 162)
        Me.LastTaskStatus.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.LastTaskStatus.Name = "LastTaskStatus"
        Me.LastTaskStatus.Size = New System.Drawing.Size(121, 34)
        Me.LastTaskStatus.StyleController = Me.LayoutControl1
        Me.LastTaskStatus.TabIndex = 10
        '
        'SimpleButton2
        '
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton2.Location = New System.Drawing.Point(16, 285)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(379, 46)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 9
        Me.SimpleButton2.Text = "الغاء الامر"
        '
        'SearchCreationUser
        '
        Me.SearchCreationUser.Location = New System.Drawing.Point(13, 199)
        Me.SearchCreationUser.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.SearchCreationUser.Name = "SearchCreationUser"
        Me.SearchCreationUser.Size = New System.Drawing.Size(385, 34)
        Me.SearchCreationUser.StyleController = Me.LayoutControl1
        Me.SearchCreationUser.TabIndex = 8
        '
        'UniqueID
        '
        Me.UniqueID.Location = New System.Drawing.Point(279, 199)
        Me.UniqueID.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.UniqueID.Name = "UniqueID"
        Me.UniqueID.Size = New System.Drawing.Size(120, 34)
        Me.UniqueID.StyleController = Me.LayoutControl1
        Me.UniqueID.TabIndex = 7
        '
        'DateOfDone
        '
        Me.DateOfDone.EditValue = Nothing
        Me.DateOfDone.Location = New System.Drawing.Point(234, 16)
        Me.DateOfDone.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.DateOfDone.Name = "DateOfDone"
        Me.DateOfDone.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateOfDone.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateOfDone.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateOfDone.Size = New System.Drawing.Size(470, 34)
        Me.DateOfDone.StyleController = Me.LayoutControl1
        Me.DateOfDone.TabIndex = 6
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton1.Location = New System.Drawing.Point(401, 285)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(383, 46)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "انجاز"
        '
        'MemoCloseNote
        '
        Me.MemoCloseNote.Location = New System.Drawing.Point(16, 56)
        Me.MemoCloseNote.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.MemoCloseNote.Name = "MemoCloseNote"
        Me.MemoCloseNote.Properties.NullValuePrompt = "ملاحظة الانجاز"
        Me.MemoCloseNote.Size = New System.Drawing.Size(768, 223)
        Me.MemoCloseNote.StyleController = Me.LayoutControl1
        Me.MemoCloseNote.TabIndex = 4
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.UniqueID
        Me.LayoutControlItem4.Location = New System.Drawing.Point(232, 188)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(232, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(57, 20)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SearchCreationUser
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 188)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(464, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(57, 20)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.LastTaskStatus
        Me.LayoutControlItem7.Location = New System.Drawing.Point(233, 150)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(233, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(57, 20)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.CurrentTaskStatus
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 150)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(233, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(57, 20)
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem6, Me.EmptySpaceItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(800, 347)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.MemoCloseNote
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(774, 229)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(385, 269)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(389, 52)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DateOfDone
        Me.LayoutControlItem3.Location = New System.Drawing.Point(218, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(556, 40)
        Me.LayoutControlItem3.Text = "تاريخ الانجاز"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(64, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.SimpleButton2
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 269)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(385, 52)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(218, 40)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'CRMCloseTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.SimpleButton2
        Me.ClientSize = New System.Drawing.Size(800, 347)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Name = "CRMCloseTask"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ملاحظة الانجاز"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CurrentTaskStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LastTaskStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchCreationUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UniqueID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateOfDone.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateOfDone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoCloseNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MemoCloseNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DateOfDone As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents UniqueID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SearchCreationUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LastTaskStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CurrentTaskStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
End Class
