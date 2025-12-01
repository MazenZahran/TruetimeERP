Public Class TimeFunctions
    Public Function ConvertText_hhmm_ToTimeSpan(_Text) As TimeSpan
        Dim _TimeSpan As TimeSpan = TimeSpan.Zero
        Try
            Dim _Time As String = _Text
            Dim _Hour As Integer = 0
            Dim _Minute As Integer = 0
            Dim _Second As Integer = 0
            If _Time.Contains(":") Then
                _Hour = CInt(_Time.Split(":")(0))
                _Minute = CInt(_Time.Split(":")(1))
            Else
                _Hour = CInt(_Time)
            End If
            _TimeSpan = New TimeSpan(_Hour, _Minute, 0)
        Catch ex As Exception
            _TimeSpan = TimeSpan.Zero
        End Try

        Return _TimeSpan

    End Function
    Public Function ConvertTimeSpan_hhmmm_ToString(_TimeSpan As TimeSpan) As String
        Dim _Time As String = String.Empty
        Try
            _Time = (_TimeSpan.Days * 24 + _TimeSpan.Hours).ToString("00") & ":" & _TimeSpan.Minutes.ToString("00")
        Catch ex As Exception
            _Time = "00:00"
        End Try
        Return _Time
    End Function
    Public Function ConvertFromDecimalToTimeSpan(_Decimal As Decimal) As TimeSpan
        Dim _TimeSpan As TimeSpan = TimeSpan.Zero
        Try
            Dim hours As Double = _Decimal
            Dim totalMinutes As Integer = CInt(hours * 60) ' Convert hours to total minutes

            ' Create a TimeSpan
            _TimeSpan = TimeSpan.FromMinutes(totalMinutes)

            ' Extract hours and minutes
            'Dim formattedTime As String = String.Format("{0:00}:{1:00}", timeSpan.Hours, timeSpan.Minutes)
        Catch ex As Exception
            _TimeSpan = TimeSpan.Zero
        End Try

        Return _TimeSpan

    End Function
End Class
