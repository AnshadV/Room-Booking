﻿Imports System.Data.SqlClient
Public Class SignUp
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "insert into Users(Name, Email, Phone, Password, isbooked) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox3.Text & "',@false)"
        Dim Conn As New SqlConnection(str)
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
    End Sub

End Class