Imports System.Net

Public Module NameCheck

    Public Function CheckTwitter(name As String) As Boolean
        Try
            Dim Request As HttpWebRequest = DirectCast(WebRequest.Create("http://twitter.com/" + name), HttpWebRequest)
            Dim Response As HttpWebResponse = Request.GetResponse()
            Return False
        Catch ex As WebException
            If ex.Status = 7 Then
                Return True
            End If
        End Try
        Return False
    End Function

    Public Function CheckMinecraft(name As String) As Boolean

        Try
            Dim Request As HttpWebRequest = DirectCast(WebRequest.Create("https://api.mojang.com/users/profiles/minecraft/" + name), HttpWebRequest)
            Dim Response As HttpWebResponse = Request.GetResponse()

            If Response.StatusCode = HttpStatusCode.NoContent Then
                Return True
            End If
            Response.Close()
            Return False
        Catch ex As WebException
            Console.WriteLine("The server returned a remote error: " + ex.Status)
            Return False
        End Try

        Return False
    End Function


    Public Function CheckSteam(name As String) As Boolean
        Dim WC As New WebClient
        Try
            Dim page As String = WC.DownloadString("http://steamcommunity.com/id/" + name)
            If page.Contains("The specified profile could not be found.") Then
                Return True
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try

    End Function

End Module

