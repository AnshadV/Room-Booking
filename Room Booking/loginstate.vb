Imports System.Data.SqlClient
Module loginstate
    Public loginstatus As Boolean
    Public checkinstatus As Boolean
    Public login_userid As Integer
    Public Email As String
    Public roomno As Integer
    Public roomtype As Integer
    Public phone As Long
    Public name As String
    Public roomprice As Integer

    Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"

    Dim Conn As New SqlConnection(str)
    Public Sub setuserid()
        If (Conn.State.Equals(ConnectionState.Closed)) Then
            Conn.Open()
        End If
        Dim sql As String = "select Id, Phone, Name from Users where CONVERT(VARCHAR, Email) =@email"
        Dim cmd As New SqlCommand(sql, Conn)
        Dim reader As SqlDataReader
        cmd.Parameters.AddWithValue("@email", Email)
        reader = cmd.ExecuteReader

        reader.Read()
        login_userid = reader("Id")
        phone = reader("Phone")
        name = reader("Name")
        loginstatus = True
    End Sub

End Module
