Imports DevExpress.XtraEditors
Imports DevExpress.XtraLayout

Public Class SendToWhatsAppNo
    Inherits XtraUserControl

    Public textMobileNo As TextEdit
    Public Sub New()
        Dim lc As New LayoutControl()
        lc.Dock = DockStyle.Fill
        Me.textMobileNo = New TextEdit()
        lc.AddItem(String.Empty, textMobileNo).TextVisible = False
        Me.Controls.Add(lc)
        Me.Height = 100
        Me.Dock = DockStyle.Top
        Me.textMobileNo.Select()
        'AddHandler Me.Load, AddressOf OnLoad
    End Sub

    Public ReadOnly Property Mobile() As String
        Get
            Return textMobileNo.Text
        End Get
    End Property

End Class
