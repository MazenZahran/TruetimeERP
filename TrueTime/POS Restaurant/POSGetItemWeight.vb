Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports TrueTime.uDefine
Public Class POSGetItemWeight
    Dim haveopencomm As Integer
    Dim NetWeight, TareWeight, IsStable, AtZero, AtTare As Integer
    Dim WeiOver As Integer
    Private _CheckIfHasScale As Boolean

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim retv As Integer
        If (haveopencomm = 1) Then
            retv = uDefine.pcbox_GetWeight(NetWeight, TareWeight, IsStable, AtZero, AtTare)
            If retv = 1 Then
                WeiOver = 0
                Showgetdata()
            ElseIf retv = 3 Then
                WeiOver = 1
                Showgetdata()
            Else
                ' ListBox1.Items.Add("get weight fail")
            End If
        End If
    End Sub


    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        uDefine.pcbox_zero()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        uDefine.pcbox_tare()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)
        uDefine.pcbox_reset()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim retv As Integer

        If haveopencomm = 1 Then
            retv = uDefine.pcbox_GetWeight(NetWeight, TareWeight, IsStable, AtZero, AtTare)

            If retv = 1 Then
                WeiOver = 0
                Showgetdata()
            ElseIf retv = 3 Then
                WeiOver = 1
                Showgetdata()
            End If
        Else
            ' ListBox1.Items.Add("الرجاء فتح الفتح التسلسلي أولا")
        End If
    End Sub



    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        GlobalVariables._TempWeight = -1
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GlobalVariables._TempWeight = Me.TextEdit1.EditValue
        Me.Close()
    End Sub
    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs)
        uDefine.pcbox_zero()
        XtraMessageBox.Show("تم تصفير الوزن بنجاح")
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        '  OpenScalePort()
        uDefine.pcbox_reset()
        XtraMessageBox.Show("send reset command")
    End Sub

    Private Sub mizan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TextEdittest.Text = 1
        '  TextEdit1.Text = 0.000
        OpenScalePort()
        '  Me.TextItemName.Text = GlobalVariables._TempItemName
        '   CheckEdit1.Checked = True
        SimpleButton1.Select()
        'If _CheckIfHasScale = False Then
        TextEdit1.Select()
        Me.LabelControlComNo.Text = "ComNo: " & GlobalVariables.ScaleComNO
        'End If
    End Sub

    Private Sub تصفيرالميزانToolStripMenuItem_Click(sender As Object, e As EventArgs)
        uDefine.pcbox_reset()
        XtraMessageBox.Show("send reset command")
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        Try
            TextAmount.EditValue = TextEdit1.EditValue * TextPrice.EditValue
        Catch ex As Exception
            TextAmount.EditValue = 0
        End Try
        If _CheckIfHasScale = False Then
            cGauge1.Scales(0).Value = CSng(TextEdit1.EditValue)
        End If
    End Sub
    Private Sub TextEdit1_MouseUp(sender As Object, e As MouseEventArgs) Handles TextEdit1.MouseUp
        TextEditSelectText(TextEdit1)
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        OpenScalePort()
    End Sub
    Private Sub OpenScalePort()
        Try
            If haveopencomm = 0 Then
                If uDefine.pcbox_InitAndOpenComm(GlobalVariables.ScaleComNO) = 1 Then
                    haveopencomm = 1
                    TextScaleStatus.BackColor = Color.Green
                    'TextScaleStatus.Text = "الميزان متصل"
                    TextScaleStatusLabel.Text = "الميزان متصل"
                    TextScaleStatusLabel.BackColor = Color.Green
                    ' SimpleButton1.Text = "إغلاق المنفذ التسلسلي"
                    _CheckIfHasScale = True
                Else
                    '  ListBox1.Items.Add("open comm error")
                    haveopencomm = 0
                    TextScaleStatusLabel.BackColor = Color.Red
                    TextScaleStatusLabel.Text = "الميزان غير متصل"
                    _CheckIfHasScale = False
                End If
            Else
                uDefine.pcbox_CloseComm()
                haveopencomm = 0
                TextScaleStatusLabel.BackColor = Color.Red
                TextScaleStatusLabel.Text = "الميزان غير متصل"
                _CheckIfHasScale = False
                ' SimpleButton1.Text = "فتح المنفذ التسلسلي"
            End If
        Catch ex As Exception
            TextScaleStatusLabel.Text = "الميزان غير متصل"
            TextScaleStatusLabel.BackColor = Color.Red
            MsgBox(ex.ToString)
            _CheckIfHasScale = False
        End Try
    End Sub
    Private Sub Showgetdata()
        If WeiOver = 1 Then
            TextEdit1.Text = "-----"
        Else
            If NetWeight = 123456 Then
                Return
            Else
                TextEdit1.Text = CInt(NetWeight.ToString()) / 1000
                cGauge1.Scales(0).Value = CSng(TextEdit1.EditValue)
            End If
        End If

        If IsStable > 0 Then
            CheckBox1.Checked = True
            SimpleButton1.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_32x32.png")
        Else
            CheckBox1.Checked = False
            SimpleButton1.ImageOptions.Image = Nothing
        End If

        If AtZero > 0 Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

        If AtTare > 0 Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub mizan_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        OpenScalePort()
        Me.Dispose()
    End Sub
End Class