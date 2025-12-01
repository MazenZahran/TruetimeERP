Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Web.Script.Serialization
Imports DevExpress.CodeParser
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class SubServices

    Private ReadOnly _connString As String

    Public Sub New()
        _connString = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString
    End Sub
    Public Class ServiceInfo
        Public Property ServiceId As Integer
        Public Property Active As Boolean
        Public Property Title As String
        Public Property ServiceEndDate As String
    End Class

    Public Async Function GetKey() As Task(Of Object)
        Dim result As New Dictionary(Of String, Object)()
        Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString

        Try
            Using conn As New SqlConnection(connString)
                conn.Open()
                Using cmd As New SqlCommand("SELECT CONVERT(NVARCHAR(MAX), DECRYPTBYPASSPHRASE('TTsAaBb2023', [Value]))
                                            FROM [dbo].[Module]
                                            WHERE [Text] = 'StaticContractKey';", conn)
                    Dim staticContractKeyValue As Object = cmd.ExecuteScalar()
                    If staticContractKeyValue IsNot Nothing And Not String.IsNullOrWhiteSpace(staticContractKeyValue.ToString()) Then
                        result("success") = True
                        result("staticContractKey") = staticContractKeyValue.ToString()
                    Else
                        Await SaveStaticKeyToDatabase()
                        result("success") = False
                        result("error") = "StaticContractKey not found in Module table"
                    End If
                End Using
            End Using
        Catch ex As Exception
            result("success") = False
            result("error") = ex.Message
        End Try

        Return result
    End Function
    Public Shared Function GetModuleInfo(StaticContractKey As String) As Object
        Dim result As New Dictionary(Of String, Object)()
        Try
            Dim apiUrl As String = $"{GlobalVariables.ttsSystemsAPI}Access/GetServices"
            Console.WriteLine($"API URL: {apiUrl}")

            Dim requestObj = New With {
            .staticContractKey = If(String.IsNullOrWhiteSpace(StaticContractKey), Nothing, StaticContractKey)
        }
            Dim requestJson As String = JsonConvert.SerializeObject(requestObj)
            Console.WriteLine($"Request JSON: {requestJson}")

            Using client As New HttpClient()
                Dim response As HttpResponseMessage =
                client.PostAsync(apiUrl, New StringContent(requestJson, System.Text.Encoding.UTF8, "application/json")).Result

                Console.WriteLine($"HTTP Status Code: {response.StatusCode}")

                response.EnsureSuccessStatusCode()

                Dim jsonString As String = response.Content.ReadAsStringAsync().Result
                Console.WriteLine($"Response JSON: {jsonString}")

                If Not String.IsNullOrWhiteSpace(jsonString) Then
                    Dim responseList As List(Of Dictionary(Of String, Object)) =
                    JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(jsonString)

                    If responseList IsNot Nothing AndAlso responseList.Count > 0 Then
                        result("success") = True
                        result("data") = responseList
                        Console.WriteLine($"Data count: {responseList.Count}")
                    Else
                        result("success") = False
                        result("error") = "No data found"
                        Console.WriteLine("No data found in response list")
                    End If
                Else
                    result("success") = False
                    result("error") = "Empty response from API"
                    Console.WriteLine("Empty response from API")
                End If
            End Using
        Catch ex As Exception
            result("success") = False
            result("error") = ex.Message
            Console.WriteLine($"Exception: {ex.Message}")
        End Try

        Return result
    End Function
    Public Async Sub UpdateModuleBodyValue()
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString
            Dim keyResult As Object = Await GetKey()
            Dim staticContractKey As String = ""



            If keyResult("success") = False OrElse String.IsNullOrEmpty(keyResult("staticContractKey").ToString()) Then
                Dim keyResult2 As Object = Await GetKey()
                staticContractKey = keyResult2("staticContractKey").ToString()

            Else
                staticContractKey = keyResult("staticContractKey").ToString()
            End If

            Using con As New SqlConnection(connString)
                con.Open()

                Dim checkBodyCmd As New SqlCommand("SELECT COUNT(*) FROM Module WHERE Text = @text", con)
                checkBodyCmd.Parameters.AddWithValue("@text", "Body")
                Dim bodyExists As Integer = CInt(checkBodyCmd.ExecuteScalar())

                If bodyExists = 0 Then
                    Dim insertBodyQuery As String = "INSERT INTO Module (Text, Value, CreatedAt, UpdatedAt)
                                         VALUES (@text, ENCRYPTBYPASSPHRASE('TTsAaBb2023',''), @createdAt, @updatedAt)"
                    Using insertBodyCmd As New SqlCommand(insertBodyQuery, con)
                        insertBodyCmd.Parameters.AddWithValue("@text", "Body")
                        insertBodyCmd.Parameters.AddWithValue("@createdAt", DateTime.Now)
                        insertBodyCmd.Parameters.AddWithValue("@updatedAt", DateTime.Now)
                        insertBodyCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Dim moduleInfo As Object = GetModuleInfo(staticContractKey)

            If TypeOf moduleInfo Is Dictionary(Of String, Object) Then
                Dim resultDict = CType(moduleInfo, Dictionary(Of String, Object))

                If CBool(resultDict("success")) AndAlso resultDict.ContainsKey("data") Then
                    Dim jsonData As String = JsonConvert.SerializeObject(resultDict("data"))

                    Using con As New SqlConnection(connString)
                        Dim updateBodyQuery As String = "UPDATE Module
                                            SET Value = ENCRYPTBYPASSPHRASE('TTsAaBb2023', @value),
                                                UpdatedAt = @updatedAt
                                            WHERE Text = @text"
                        Using updateBodyCmd As New SqlCommand(updateBodyQuery, con)
                            updateBodyCmd.Parameters.AddWithValue("@value", jsonData)
                            updateBodyCmd.Parameters.AddWithValue("@updatedAt", DateTime.Now)
                            updateBodyCmd.Parameters.AddWithValue("@text", "Body")

                            con.Open()
                            updateBodyCmd.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Function GetServicesUserHave() As List(Of ServiceInfo)
        Dim services As New List(Of ServiceInfo)

        Try
            Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString)
                connection.Open()

                Dim query As String = "SELECT CONVERT(NVARCHAR(MAX), 
                                   DECRYPTBYPASSPHRASE('TTsAaBb2023', Value)) 
                                   FROM Module 
                                   WHERE Text = 'Body'"

                Using command As New SqlCommand(query, connection)
                    Dim result As Object = command.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Dim jsonString As String = result.ToString()

                        Dim serializer As New JavaScriptSerializer()
                        Dim jsonObject As Object = serializer.DeserializeObject(jsonString)

                        If TypeOf jsonObject Is Object() Then
                            Dim serviceArray As Object() = DirectCast(jsonObject, Object())

                            For Each item As Object In serviceArray
                                If TypeOf item Is Dictionary(Of String, Object) Then
                                    Dim serviceDict As Dictionary(Of String, Object) = DirectCast(item, Dictionary(Of String, Object))
                                    Dim serviceInfo As New ServiceInfo()

                                    If serviceDict.ContainsKey("serviceId") Then
                                        serviceInfo.ServiceId = Convert.ToInt32(serviceDict("serviceId"))
                                    End If

                                    If serviceDict.ContainsKey("active") Then
                                        serviceInfo.Active = Convert.ToBoolean(serviceDict("active"))
                                    End If

                                    If serviceDict.ContainsKey("title") Then
                                        serviceInfo.Title = serviceDict("title").ToString()
                                    End If

                                    If serviceDict.ContainsKey("serviceEndDate") Then
                                        serviceInfo.ServiceEndDate = serviceDict("serviceEndDate").ToString()
                                    End If

                                    services.Add(serviceInfo)
                                End If
                            Next

                        End If
                    End If
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("خطأ في جلب بيانات الخدمات: " & ex.Message)
        End Try

        Return services

    End Function

    Public Async Function SaveStaticKeyToDatabase() As Task
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString
            Dim result As String = Await DeviceActivationForm.CheckDeviceStatus()

            Dim json = JObject.Parse(result)
            Dim staticContractKey As String = json("staticContractKey")

            Using con As New SqlConnection(connString)
                con.Open()

                Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM Module WHERE Text = @text", con)
                checkCmd.Parameters.AddWithValue("@text", "staticContractKey")
                Dim exists As Integer = CInt(checkCmd.ExecuteScalar())

                Dim query As String
                If exists > 0 Then
                    query = "UPDATE Module
                                SET Value = ENCRYPTBYPASSPHRASE('TTsAaBb2023', @value),
                                    UpdatedAt = @updatedAt
                                WHERE Text = @text"
                Else
                    query = "INSERT INTO Module (Text, Value, CreatedAt, UpdatedAt) VALUES (@text, ENCRYPTBYPASSPHRASE('TTsAaBb2023', @value), @createdAt, @updatedAt)"
                End If

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@value", staticContractKey)
                    cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now)
                    cmd.Parameters.AddWithValue("@text", "staticContractKey")
                    If exists = 0 Then
                        cmd.Parameters.AddWithValue("@createdAt", DateTime.Now)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error saving device status: " & ex.Message)
        End Try
    End Function
End Class
