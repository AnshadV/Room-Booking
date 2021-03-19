Imports System.Data.SqlClient
Imports Room_Booking.loginstate
Public Class Booking
    Private Sub Booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.amenitiesbin' table. You can move, or remove it, as needed
        TextBox1.Text = roomno
        TextBox2.Text = loginstate.name
        TextBox3.Text = Email
        TextBox4.Text = phone
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        'Try
        '    If (Conn.State.Equals(ConnectionState.Closed)) Then
        '        Conn.Open()
        '    End If
        '    Dim updatesql As String = "Select price from roomType where Id = (select roomType from units where roomno = '" & roomno & "')"
        '    Dim cmd3 As New SqlCommand(updatesql, Conn)
        '    Dim reader As SqlDataReader
        '    reader = cmd3.ExecuteReader
        '    cmd3.Parameters.AddWithValue("@roomno", roomno)
        '    reader.Read()

        '    TextBox5.Text = reader("price")
        'Catch ex As Exception
        '    MessageBox.Show(String.Format("Error: {0}", ex.Message))
        'End Try

        TextBox5.Text = roomprice




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "insert into reservation(userid, roomno, ischeckedin, bookingtime) values(@userid,'" & roomno & "',@checkedin,@bookingtime)"
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Dim theDate As DateTime = System.DateTime.Now
        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            MessageBox.Show(String.Format("Error: {0}", login_userid))
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@userid", login_userid)
            cmd.Parameters.AddWithValue("@checkedin", "false")
            cmd.Parameters.AddWithValue("@bookingtime", DateTime.Parse(theDate))
            cmd.ExecuteNonQuery()
            Me.Close()
            Home.Show()
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try
    End Sub
End Class

