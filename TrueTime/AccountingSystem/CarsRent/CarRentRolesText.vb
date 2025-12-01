Imports System.Configuration
Imports System.Data.SqlClient

Public Class CarRentRolesText
    Private Sub CarRentRolesText_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.RichEditControl1.LoadDocument("roles2.docx")
        'Dim bytes As Byte()
        'Dim constr As String = My.Settings.TrueTimeConnectionString
        'Using con As New SqlConnection(constr)
        '    Using cmd As New SqlCommand()
        '        cmd.CommandText = "select DocFile as  Data from [ArchiveDocs] where DocID=@Id"
        '        cmd.Parameters.AddWithValue("@Id", 35)
        '        cmd.Connection = con
        '        con.Open()
        '        Using sdr As SqlDataReader = cmd.ExecuteReader()
        '            sdr.Read()
        '            bytes = DirectCast(sdr("Data"), Byte())
        '        End Using
        '        con.Close()
        '    End Using
        'End Using
        'Me.RichEditControl1.LoadDocument(bytes)
        'hghg
    End Sub
End Class