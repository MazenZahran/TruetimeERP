Imports System.IO
Imports System.Net
Imports System.Net.Http

Public Class SendGreenAPI
    Private Sub SendGreenAPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SendMessage()
    End Sub

    Private Function GetWhatsAppUrl(endpoint As String) As String
        If LogInMenue.HasWhatsAppPackage Then
            ' ✅ Real working URL
            Return $"https://api.green-api.com/waInstance7103903885/{endpoint}/83ac2143e09b4d45831e7b7423ae5a2c4bed9c1bed394c2389"
        Else
            ' ❌ Fake URL
            MsgBoxShowError("الخدمة غير مفعلة")
            Return "https://invalid.local/" & endpoint
        End If
    End Function

    Sub SendMessage(_MobileNo As String, _Message As String)
        Dim URL As String = GetWhatsAppUrl("sendMessage")
        Dim RequestBody As String
        Dim http As HttpWebRequest
        Dim dataStream As Stream
        Dim reader As StreamReader
        Dim response As WebResponse
        Dim responseText As String

        Select Case Len(_MobileNo)
            Case 10
                _MobileNo = "972" & _MobileNo.Substring(1)
            Case 9
                _MobileNo = "972" & _MobileNo
            Case Else
                _MobileNo = _MobileNo.TrimStart("0"c)
        End Select

        ' URL = GetURString()

        ' chatId is the number to send the message to (@c.us for private chats, @g.us for group chats)
        RequestBody = "{""chatId"":""MobileNo@c.us"",""message"":""MessageText""}"
        RequestBody = RequestBody.Replace("MobileNo", _MobileNo).Replace("MessageText", _Message)
        http = WebRequest.Create(URL)
        http.ContentType = "application/json"
        http.Method = "POST"
        Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(RequestBody)
        http.ContentLength = byteArray.Length
        dataStream = http.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Try
            response = http.GetResponse()
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            dataStream = response.GetResponseStream()
            reader = New StreamReader(dataStream)
            responseText = reader.ReadToEnd()
            Console.WriteLine(responseText)
            reader.Close()
            dataStream.Close()
            response.Close()
        Catch ex As WebException
            Console.WriteLine(ex.ToString())
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SendMessage("00972597505029", "Hello5")
    End Sub
    Sub SendMessageWithFile()
        Dim client As New HttpClient()
        Dim url As String = GetWhatsAppUrl("sendFileByUpload")

        Dim payload As New MultipartFormDataContent()
        Dim chatId As String = "972597505029@c.us"
        Dim caption As String = "Описание"
        Dim files As New List(Of String)() From {"D:\New.txt"}
        Dim response As HttpResponseMessage

        Try
            ' Add the chatId and caption to the payload
            payload.Add(New StringContent(chatId), "chatId")
            payload.Add(New StringContent(caption), "caption")

            ' Add the file to the payload
            For Each filePath As String In files
                Dim fileName As String = Path.GetFileName(filePath)
                Dim fileContent As New ByteArrayContent(File.ReadAllBytes(filePath))
                Dim fileInfo As New FileInfo(filePath)
                payload.Add(fileContent, "file", fileName)
            Next

            ' Send the POST request
            response = client.PostAsync(url, payload).Result

            ' Read and print the response
            Dim responseContent As String = response.Content.ReadAsStringAsync().Result
            Console.WriteLine(responseContent)
        Catch ex As Exception
            Console.WriteLine("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SendMessageWithFile()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim args As String() = {"argument1", "argument2"} ' Example arguments

        ' Call the async function using Task.Run to avoid "async void" usage in the event handler
        Task.Run(Function() SendFileWithWhatsApp2())
    End Sub
    Private Shared Async Function SendFileWithWhatsApp2() As Task
        'Dim url = "https://api.green-api.com/waInstance{{idInstance}}/sendFileByUpload/{{apiTokenInstance}}"
        Dim url As String = New SendGreenAPI().GetWhatsAppUrl("sendFileByUpload")
        Dim payload = New Dictionary(Of String, String) From {
            {"chatId", "972597505029@c.us"},
            {"caption", "True time"}
        }

        Using httpClient = New HttpClient()

            Using form = New MultipartFormDataContent()

                For Each item In payload
                    form.Add(New StringContent(item.Value), item.Key)
                Next


                Dim filePath = "D:\test.pdf"
                Dim fileName As String = Path.GetFileName(filePath)
                Dim fileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
                Dim fileContent = New StreamContent(fileStream)
                fileContent.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf")
                form.Add(fileContent, "file", filePath)
                Dim response = Await httpClient.PostAsync(url, form)
                Dim responseContent = Await response.Content.ReadAsStringAsync()
                Console.WriteLine(responseContent)
            End Using
        End Using
    End Function
End Class