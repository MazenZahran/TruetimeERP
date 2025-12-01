Imports System.Net
Imports System.Net.Http
Imports System.Threading

Public Class forTest
    Async Function SendRequestsAsync() As Task
        Dim url As String = "http://ordersapp.truetime.ps/api/orders/get?DocID=1000&Docdate=2025-05-05&DocName=11&DocAmount=120&referance=814&inputuser=1&inputdatetime=2025-05-05&Stockid=1&stockunit=1&stockquantity=1&Stockprice=10&doccode=444&devicename=4141&deliverdate=2021-01-01&docnotes=notes&Latitude=36.3251&Longitude=36.2145&BonusQuantity=1&DocNoteByAccount=mazen"

        Dim totalRequests As Integer = 1000
        Dim successfulRequests As Integer = 0
        Dim failedRequests As Integer = 0
        Dim totalResponseTime As Long = 0

        Console.WriteLine($"Starting to send {totalRequests} requests...")
        Console.WriteLine()

        Dim stopwatch As New Stopwatch()
        stopwatch.Start()

        ' Use SemaphoreSlim to control concurrency (limit to 10 concurrent requests)
        Dim semaphore As New SemaphoreSlim(10)
        Dim tasks As New List(Of Task)()

        For i As Integer = 1 To totalRequests
            ' Wait for semaphore before starting new request
            Await semaphore.WaitAsync()

            Dim task As Task = task.Run(Async Function()
                                            Dim requestStopwatch As New Stopwatch()
                                            requestStopwatch.Start()

                                            Try
                                                ' Using HttpClient for better performance
                                                Using client As New HttpClient()
                                                    client.Timeout = TimeSpan.FromSeconds(30)

                                                    Dim response As HttpResponseMessage = Await client.GetAsync(url)
                                                    If response.IsSuccessStatusCode Then
                                                        Interlocked.Increment(successfulRequests)
                                                    Else
                                                        Interlocked.Increment(failedRequests)
                                                        Console.WriteLine({response.StatusCode})
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                Interlocked.Increment(failedRequests)
                                                Console.WriteLine({ex.Message})
                                            Finally
                                                semaphore.Release()
                                            End Try

                                            requestStopwatch.Stop()
                                            Interlocked.Add(totalResponseTime, requestStopwatch.ElapsedMilliseconds)

                                            ' Show progress
                                            Console.Write($"\rProgress: {successfulRequests + failedRequests}/{totalRequests} | " &
                                                         $"Success: {successfulRequests} | " &
                                                         $"Failed: {failedRequests}       ")
                                        End Function)

            tasks.Add(task)

            ' Small delay to avoid overwhelming the server
            Await Task.Delay(50)
        Next

        ' Wait for all tasks to complete
        Await Task.WhenAll(tasks)

        stopwatch.Stop()

        ' Calculate statistics
        Dim averageResponseTime As Double = If((successfulRequests + failedRequests) > 0,
                                            totalResponseTime / (successfulRequests + failedRequests),
                                            0)
        Dim requestsPerSecond As Double = If(stopwatch.ElapsedMilliseconds > 0,
                                          totalRequests / (stopwatch.ElapsedMilliseconds / 1000),
                                          0)

        ' Print final results
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("Test Results:")
        Console.WriteLine("------------")
        Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms")
        Console.WriteLine($"Successful requests: {successfulRequests}")
        Console.WriteLine($"Failed requests: {failedRequests}")
        Console.WriteLine($"Average response time: {averageResponseTime.ToString("0.00")} ms")
        Console.WriteLine($"Requests per second: {requestsPerSecond.ToString("0.00")}")
    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        ' Configure maximum concurrent connections
        ServicePointManager.DefaultConnectionLimit = 20
        ServicePointManager.Expect100Continue = False
        ServicePointManager.UseNagleAlgorithm = False

        Try
            SendRequestsAsync().GetAwaiter().GetResult()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Console.WriteLine()
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub
End Class