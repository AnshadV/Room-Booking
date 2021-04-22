Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Room_Booking.loginstate
Imports Room_Booking.controlModule
Public Class login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim regex As Regex = New Regex("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
        Dim isValid As Boolean = regex.IsMatch(TextBox1.Text.Trim)
        If TextBox1.Text.Length <= 0 Then
            MessageBox.Show("Please enter Username!")
        ElseIf TextBox2.Text.Length <= 0 Then
            MessageBox.Show("Please enter Password!")
        ElseIf Not isValid Then
            MessageBox.Show("Invalid Email.")
        Else
            Dim sql As String = "select count(*) from Users where CONVERT(VARCHAR, Email) =@Username and CONVERT(VARCHAR, Password)=@Password"
            Dim Conn As New SqlConnection(str)
            If TextBox1.Text = "admin@exe.com" And TextBox2.Text = "passf" Then
                adminDash.Show()
                Me.Hide()

            Else
                Try
                    Conn.Open()
                    Dim cmd As New SqlCommand(sql, Conn)
                    cmd.Parameters.AddWithValue("@Username", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@Password", TextBox2.Text)
                    Dim value = cmd.ExecuteScalar()
                    If value > 0 Then
                        Email = TextBox1.Text
                        setuserid()
                        MessageBox.Show("Login sucessfully!")
                        Home.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("The username Or password incorrect")
                    End If
                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try
            End If
        End If
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        SignUp.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        test.Show()

    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class