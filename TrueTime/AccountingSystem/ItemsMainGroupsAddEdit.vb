Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO

Public Class ItemsMainGroupsAddEdit
    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SaveData()
        If TextGroupName.Text = "" Then
            MsgBox("يجب تعبئة اسم المجموعة")
            Exit Sub
        End If
        Try
            If TextID.EditValue = -1 Then
                Dim con As SqlConnection
                Dim cmd As SqlCommand
                con = New SqlConnection(My.Settings.TrueTimeConnectionString)
                Dim SqlInsert As String = " Insert into ItemsGroups (GroupName,AvailableOnPOS,AvailableOnline,GroupImage) values( 
                                        N'" & TextGroupName.Text & "',
                                        '" & CheckShowInPos.EditValue & "',
                                        '" & CheckShowInMatjar.EditValue & "',
                                        @photo)"
                cmd = New SqlCommand(SqlInsert, con)
                Dim ms As MemoryStream
                If Me.PictureEdit1.Image IsNot Nothing Then
                    ms = New MemoryStream()
                    PictureEdit1.Image.Save(ms, ImageFormat.Jpeg)
                    Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
                    ms.Position = 0
                    ms.Read(photo_aray, 0, photo_aray.Length)
                    cmd.Parameters.AddWithValue("@photo", photo_aray)
                Else
                    ms = New MemoryStream()
                    My.Resources.list_48px.Save(ms, ImageFormat.Jpeg)
                    Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
                    ms.Position = 0
                    ms.Read(photo_aray, 0, photo_aray.Length)
                    cmd.Parameters.AddWithValue("@photo", photo_aray)
                End If
                con.Open()
                Dim n As Integer = cmd.ExecuteNonQuery()
                con.Close()

                If n > 0 Then
                    MessageBox.Show("تم تعريف المركبة")
                    Me.Close()
                Else
                    MessageBox.Show("insertion failed")
                End If
            Else
                Dim con As SqlConnection
                con = New SqlConnection(My.Settings.TrueTimeConnectionString)
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Update [dbo].[ItemsGroups] set
                                              GroupName=N'" & TextGroupName.Text & "', AvailableOnPOS='" & CheckShowInPos.EditValue & "',
                                              AvailableOnline='" & CheckShowInMatjar.EditValue & "',
                                              GroupImage=@photo where GroupID=" & TextID.Text, con)
                Dim ms As MemoryStream
                If Me.PictureEdit1.Image IsNot Nothing Then
                    ms = New MemoryStream()
                    PictureEdit1.Image.Save(ms, ImageFormat.Jpeg)
                    Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
                    ms.Position = 0
                    ms.Read(photo_aray, 0, photo_aray.Length)
                    cmd.Parameters.AddWithValue("@photo", photo_aray)
                Else
                    ms = New MemoryStream()
                    My.Resources.EmptyCar.Save(ms, ImageFormat.Jpeg)
                    Dim photo_aray As Byte() = New Byte(ms.Length - 1) {}
                    ms.Position = 0
                    ms.Read(photo_aray, 0, photo_aray.Length)
                    cmd.Parameters.AddWithValue("@photo", photo_aray)
                End If
                con.Open()
                Dim n As Integer = cmd.ExecuteNonQuery()
                con.Close()
                If n > 0 Then
                    MessageBox.Show("تم حفظ البيانات")
                    Me.Close()
                Else
                    MessageBox.Show("Updation Failed")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ItemsMainGroups_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        SaveData()
        Me.TextID.EditValue = -1
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        Me.TextID.EditValue = -1
    End Sub



    Private Sub TextID_EditValueChanged(sender As Object, e As EventArgs) Handles TextID.EditValueChanged
        Select Case TextID.EditValue
            Case -1
                TextGroupName.Text = ""
                CheckShowInPos.Checked = True
                CheckShowInMatjar.Checked = True
                PictureEdit1.Image = Nothing
            Case Else
                Dim sql As New SQLControl
                sql.SqlTrueAccountingRunQuery(" select [GroupName],[AvailableOnPOS],[AvailableOnline],[GroupImage] 
                                                from   [ItemsGroups] 
                                                where  [GroupID]=" & TextID.EditValue)
                Me.TextGroupName.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("GroupName")
                Me.CheckShowInPos.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("AvailableOnPOS")
                Me.CheckShowInMatjar.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("AvailableOnline")
                Me.PictureEdit1.Image = Nothing
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("GroupImage")) Then
                    Dim photo_aray As Byte()
                    photo_aray = CType(sql.SQLDS.Tables(0).Rows(0).Item("GroupImage"), Byte())
                    Dim ms As MemoryStream = New MemoryStream(photo_aray)
                    PictureEdit1.Image = Image.FromStream(ms)
                End If
        End Select
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class