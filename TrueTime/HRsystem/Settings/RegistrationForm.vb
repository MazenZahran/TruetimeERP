Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports MySqlConnector

Public Class RegistrationForm

    Dim ActiveStatus As Boolean


    Private Sub Reg1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HyperlinkLabelControl1.Text = " <href=www.TrueTime.ps>الموقع الالكتروني</href> للمزيد من المعلومات يرجى زيارة    "
        Me.TextKey.Text = SystemSerialNumber()
        TextSoftID.Select()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        'Try
        '    If TextKey.Text = "" Or TextRegistrationCode.Text = "" Then
        '        If TextKey.Text = "" Then XtraMessageBox.Show(" مفتاح التسجيل فارغ") : TextKey.BackColor = Color.IndianRed
        '        If TextRegistrationCode.Text = "" Then XtraMessageBox.Show("   كود التسجيل فارغ") : TextRegistrationCode.BackColor = Color.IndianRed
        '        If TextSoftID.Text = "" Then XtraMessageBox.Show("    رقم النسخة فارغ") : TextSoftID.BackColor = Color.IndianRed
        '        Exit Sub
        '    End If


        '    Dim ActivationCode As String = GetCode(SystemSerialNumber, TextSoftID.Text)
        '    Dim SoftID As String = TextSoftID.Text

        '    If ActivationCode = TextRegistrationCode.Text Then
        '        ActiveStatus = True
        '        'Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\TTS\TTA")
        '        'My.Computer.Registry.LocalMachine.CreateSubKey("SOFTWARE\TTS")
        '        'My.Computer.Registry.LocalMachine.CreateSubKey("SOFTWARE\TTS\TTA")
        '        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\TTS\TTA", "SerialKey", ActivationCode)
        '        'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\TTS\TTA", "SoftID", SoftID)
        '        'Dim SS As String = key.GetValue("SerialKey")
        '        Dim Sqlstring As String = "Update CompanyData set SoftwareID = '" & TextSoftID.text & "' , TextRegistrationCode='" & TextRegistrationCode.Text  &"'"


        '        Dim sql As New SQLControl
        '        sql.SqlTrueTimeRunQuery(Sqlstring)

        '        XtraMessageBox.Show("تم تفعيل البرنامج", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Me.Close()
        '        Main.Show()
        '    Else
        '        XtraMessageBox.Show("كود التفعيل خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End If

        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.ToString)
        'End Try

        Try
            If TextKey.Text = String.Empty Or TextRegistrationCode.Text = String.Empty Then
                If TextKey.Text = String.Empty Then XtraMessageBox.Show(" مفتاح التسجيل فارغ")
                If TextRegistrationCode.Text = String.Empty Then XtraMessageBox.Show("   كود التسجيل فارغ")
                If TextSoftID.Text = String.Empty Then XtraMessageBox.Show("    رقم النسخة فارغ")
                Exit Sub
            End If


            Dim ActivationCode As String = GetCode(GlobalVariables.LocalDeviceKey, TextSoftID.Text)
            Dim SoftID As String = TextSoftID.Text

            If ActivationCode = TextRegistrationCode.Text Then
                ActiveStatus = True
                Dim Sqlstring As String = "Insert Into DevicesReg (DeviceKey,RegCode,ClientDevice,SoftwareID,RegDate,DeviceName)
               Values ( '" & TextKey.Text & "','" & TextRegistrationCode.Text & "','" & CheckEditClient.CheckState & "','" & TextSoftID.Text & "'
                       ,'" & Format(Now, "yyyy-MM-dd HH:mm") & "','" & Environ("ComputerName") & "' )"
                '  MsgBox(Sqlstring)
                '"set SoftwareID = '" & TextSoftID.Text & "' , TextRegistrationCode='" & TextRegistrationCode.Text & "'"
                Dim sql As New SQLControl
                sql.SqlTrueTimeRunQuery(Sqlstring)
                XtraMessageBox.Show("تم تفعيل البرنامج", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Main.Show()
            Else
                XtraMessageBox.Show("كود التفعيل خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try



        UploadData()


        '  UploadData()

    End Sub

    Private Sub AddReg()


    End Sub
    Private Sub UploadData()

        Try
            Dim NowString As String = Format(Now, "yyyy-MM-dd HH:mm")
            Dim MySqlConnection = New MySqlConnection
            MySqlConnection.ConnectionString = MySqlString()
            MySqlConnection.Open()
            Dim MyAdapter As New MySqlDataAdapter
            Dim SqlQuary = "insert into  RegistrationsLog 
                                         (CustomerKey,RegistrationCode,RegDate,ExternalIP,ActiveStatus,SoftwareID) 
                                          values ('" & TextKey.Text & "','" & TextRegistrationCode.Text & "','" & NowString & "','" & GetExternalIp() & "'," & ActiveStatus & ",'" & TextSoftID.Text & "') "
            Dim Command As New MySqlCommand
            Command.Connection = MySqlConnection
            Command.CommandText = SqlQuary
            MyAdapter.SelectCommand = Command
            Dim Mydata As MySqlDataReader
            Mydata = Command.ExecuteReader
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub CreatTextFile()
        Dim filepath As String = "C:\my files\2010\SomeFileName.txt"
        If Not System.IO.File.Exists(filepath) Then
            System.IO.File.Create(filepath).Dispose()
        End If
    End Sub
    Private Sub HyperlinkLabelControl1_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles HyperlinkLabelControl1.HyperlinkClick
        HyperlinkLabelControl1.LinkVisited = True
        System.Diagnostics.Process.Start(e.Link)
    End Sub



    Private Sub TextRegistrationCode_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles TextRegistrationCode.EditValueChanging, TextSoftID.EditValueChanging
        TextRegistrationCode.BackColor = DefaultBackColor
        TextSoftID.BackColor = DefaultBackColor
    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButtonClose.Click
        Application.Exit()
    End Sub

    Private Sub TextSoftID_EditValueChanged(sender As Object, e As EventArgs) Handles TextSoftID.EditValueChanged

    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        ChangeConnectionString.Show()
    End Sub
End Class