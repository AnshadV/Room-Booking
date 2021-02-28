Imports System.Data.SqlClient
Public Class login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length <= 0 Then
            MessageBox.Show("Please enter Username!")
        ElseIf TextBox2.Text.Length <= 0 Then
            MessageBox.Show("Please enter Password!")
        End If
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "select count(*) from Users where CONVERT(VARCHAR, Email) =@Username and CONVERT(VARCHAR, Password)=@Password"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@Username", TextBox1.Text)
            cmd.Parameters.AddWithValue("@Password", TextBox2.Text)
            Dim value = cmd.ExecuteScalar()
            If value > 0 Then
                MessageBox.Show("Login sucessfully!")
                adminDash.Show()
                Me.Hide()
            Else
                MessageBox.Show("The username Or password incorrect")
            End If
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class