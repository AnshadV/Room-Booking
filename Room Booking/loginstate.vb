Imports System.Data.SqlClient
Module loginstate
    Public loginstate As Boolean
    Public login_userid As Integer
    Public Email As String
    Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"

    Dim Conn As New SqlConnection(str)
    Public Sub setuserid()
        Conn.Open()
        Dim sql As String = "select Id from Users where CONVERT(VARCHAR, Email) = @email"
        Dim cmd As New SqlCommand(sql, Conn)
        cmd.Parameters.AddWithValue("@email", Email)
        login_userid = cmd.ExecuteScalar()
        loginstate = True
    End Sub

End Module
