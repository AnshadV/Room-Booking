Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class SignUp
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim regex As Regex = New Regex("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
        Dim isValid As Boolean = regex.IsMatch(TextBox2.Text.Trim)
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "insert into Users(Name, Email, Phone, Password, isbooked) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox3.Text & "',@false)"
        Dim Conn As New SqlConnection(str)
        If Not isValid Then
            MessageBox.Show("Invalid Email.")
        ElseIf TextBox4.Text.Length < 9 Then
            MsgBox("Phone numbers must be at least 10 digits long")
            TextBox4.Focus()
        ElseIf TextBox4.Text.Length > 10 Then
            MsgBox("Phone numbers must be of a maximum of 10 digits long")
            TextBox4.Focus()
        Else


            Try
                Conn.Open()
                Dim cmd As New SqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@false", "false")
                cmd.ExecuteNonQuery()
                login.Show()
                Me.Close()
            Catch ex As Exception
                Console.WriteLine("Exception caught: {0}", ex)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        login.Show()
    End Sub
End Class