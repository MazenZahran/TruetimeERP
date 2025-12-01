Imports Microsoft.Win32
Imports System.Security.Cryptography
Imports System.Text

Public Class RegistryCredentialManager
    ' Registry path for storing credentials
    Private Const RegistryPath As String = "SOFTWARE\tts\tts"

    ' Encrypt credentials before storing in registry
    Public Shared Function EncryptCredentials(username As String, password As String) As String
        Try
            ' Basic encryption to obfuscate credentials
            Dim combinedCreds = username & "|" & password
            Dim credBytes = Encoding.Unicode.GetBytes(combinedCreds)

            ' Convert to Base64 to make it registry-safe
            Return Convert.ToBase64String(credBytes)
        Catch
            Return String.Empty
        End Try
    End Function

    ' Decrypt credentials from registry
    Public Shared Function DecryptCredentials(encryptedData As String) As (username As String, password As String)
        Try
            ' Decode from Base64
            Dim credBytes = Convert.FromBase64String(encryptedData)
            Dim combinedCreds = Encoding.Unicode.GetString(credBytes)

            ' Split credentials
            Dim parts = combinedCreds.Split("|"c)
            Return (parts(0), parts(1))
        Catch
            Return (String.Empty, String.Empty)
        End Try
    End Function

    ' Save credentials to registry
    Public Shared Sub SaveCredentials(username As String, password As String)
        Try
            ' Open or create registry key
            Using key As RegistryKey = Registry.CurrentUser.CreateSubKey(RegistryPath)
                ' Encrypt and save credentials
                key.SetValue("SavedUsername", EncryptCredentials(username, password))
                key.SetValue("RememberMe", "1")
            End Using
        Catch ex As Exception
            ' Handle potential write errors
            MessageBox.Show("Error saving credentials: " & ex.Message)
        End Try
    End Sub

    ' Retrieve credentials from registry
    Public Shared Function LoadCredentials() As (username As String, password As String)
        Try
            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryPath)
                ' Check if credentials are saved
                If key IsNot Nothing AndAlso
                   key.GetValue("RememberMe")?.ToString() = "1" Then
                    Dim encryptedCreds = key.GetValue("SavedUsername")?.ToString()

                    If Not String.IsNullOrEmpty(encryptedCreds) Then
                        Return DecryptCredentials(encryptedCreds)
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading credentials: " & ex.Message)
        End Try

        Return (String.Empty, String.Empty)
    End Function

    ' Clear saved credentials
    Public Shared Sub ClearCredentials()
        Try
            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryPath, True)
                If key IsNot Nothing Then
                    key.SetValue("RememberMe", "0")
                    key.SetValue("SavedUsername", "")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error clearing credentials: " & ex.Message)
        End Try
    End Sub
End Class