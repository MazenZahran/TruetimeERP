sub main()
Dim sServer, sConn, oConn, sDatabaseName, sUser, sPassword
sDatabaseName="Truetime"
sServer=".\SQLEXPRESS"
sUser="sa"
sPassword="Admin@1234"
sConn="provider=sqloledb;data source=" & sServer & ";initial catalog=" & sDatabaseName

Set oConn = CreateObject("ADODB.Connection")
oConn.CommandTimeout=520
oConn.Open sConn, sUser, sPassword
oConn.Execute "EXEC [dbo].[ReadCSTMRTrans]"

oConn.Close
Set oConn = Nothing
end sub

On Error Resume Next
  Main
  If Err.Number Then
     WScript.Quit 4711
  End If