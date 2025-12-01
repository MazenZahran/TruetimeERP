Imports System.Net

Public Class UpdateOurSystem
    Dim WEB_ As New WebClient
    Dim Process_() As Process = Process.GetProcessesByName("File") ' Name file your program
    Dim VProject As Integer = WEB_.DownloadString("D:\v.txt") ' You can use link Example: http://www.mysite.com/file.txt  (Link Direct...)
    Private Sub UpdateOurSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleButton1.Visible = False
        If VProject > My.Settings.VersionNo Then
            LabelControl1.Text = "Download the new version"
            SimpleButton1.Visible = True
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If VProject > My.Settings.VersionNo Then
            If Process_.Count > 0 Then
                For Each MyProject_ In Process_
                    MyProject_.Kill()              ' Close Your Project.
                Next
                GoTo GoDownlod_
            Else
GoDownlod_:
                WEB_.DownloadFileAsync(New Uri("D:\File.exe"), Application.StartupPath & "\File.exe", True) ' You can use link Example: http://www.mysite.com/File.exe  (Link Direct...)
                My.Settings.VersionNo = VProject
                My.Settings.Save()
                MsgBox("تم تحديث البرنامج.")
                Process.Start(Application.StartupPath & "\File.exe") ' Open Your Project After Finish Update.
                Application.Exit()
            End If
        End If
    End Sub
End Class