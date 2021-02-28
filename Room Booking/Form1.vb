Imports System.Data.SqlClient
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length <= 0 Then
            MessageBox.Show("Please enter Username!")
        ElseIf TextBox2.Text.Length <= 0 Then
            MessageBox.Show("Please enter Password!")
        End If
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "select count(*) from USERPROFILE where Username=@Username and Password=@Password"
        Dim Conn As New SqlConnection(str)

        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@Username", TextBox1.Text)
            cmd.Parameters.AddWithValue("@Password", TextBox2.Text)
            Dim value = cmd.ExecuteScalar()
            If value > 0 Then
                MessageBox.Show("Login sucessfully!")
            End If
        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class