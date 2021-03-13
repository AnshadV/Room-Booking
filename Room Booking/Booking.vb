Imports System.Data.SqlClient
Imports Room_Booking.loginstate
Public Class Booking
    Private Sub Booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = roomno
        TextBox3.Text = Email
        TextBox4.Text = phone
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim updatesql As String = "Select price from roomType where Id = (select roomType from units where roomno = '" & roomno & "')"
            Dim cmd3 As New SqlCommand(updatesql, Conn)
            Dim reader As SqlDataReader
            reader = cmd3.ExecuteReader
            cmd3.Parameters.AddWithValue("@roomno", roomno)
            reader.Read()
            TextBox5.Text = reader("price")
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "insert into reservation(userid, roomno, ischeckedin) values(@userid,'" & roomno & "',@checkedin)"
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            MessageBox.Show(String.Format("Error: {0}", login_userid))
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@userid", login_userid)
            cmd.Parameters.AddWithValue("@checkedin", "False")
            cmd.ExecuteNonQuery()
            cmd.Parameters.AddWithValue("@checkedin", "False")
            Me.Close()
            Home.Show()
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try
    End Sub
End Class