﻿Imports System.Data.SqlClient
Imports System.IO

Public Class adminDash
    Public count As Integer
    Public myDate As New DateTime
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        roomAdder.Show()

    End Sub
    Private Sub MonthCalendar1_DateChanged(ByVal sender As Object,
           ByVal e As System.Windows.Forms.DateRangeEventArgs)
        TextBox1.Text = e.Start.ToShortDateString()
    End Sub

    Private Sub MonthCalendar2_DateChanged(ByVal sender As Object,
           ByVal e As System.Windows.Forms.DateRangeEventArgs)
        TextBox2.Text = e.Start.ToShortDateString()
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "insert into services(name, price) values(@name, @price)"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@name", TextBox4.Text)
            cmd.Parameters.AddWithValue("@price", TextBox5.Text)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
    End Sub

    Private Sub GroupBox14_Enter(sender As Object, e As EventArgs) Handles GroupBox14.Enter

    End Sub

    Private Sub GroupBox15_Enter(sender As Object, e As EventArgs) Handles GroupBox15.Enter

    End Sub

    Private Sub TabPage7_Enter(sender As Object, e As EventArgs) Handles TabPage7.Enter
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "select count(*) from roomType"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd2 As New SqlCommand(sql, Conn)
            count = cmd2.ExecuteScalar()
            MessageBox.Show(count)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

        Select Case count
            Case 1
                GroupBox15.Visible = True
                GroupBox17.Visible = False
                GroupBox21.Visible = False
                Try
                    Dim updatesql As String = "Select name,maxguest,price,objtype
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label25.Text = reader("name")
                    Label26.Text = reader("maxguest")
                    Label27.Text = reader("objtype")
                    Label28.Text = reader("price")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

            Case 2
                GroupBox15.Visible = True
                GroupBox17.Visible = True
                GroupBox21.Visible = False
                Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable()
                Try   'block 1
                    Dim updatesql As String = "Select name,rimage,maxguest,price,objtype
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label25.Text = reader("name")
                    Label26.Text = reader("maxguest")
                    Label27.Text = reader("objtype")
                    Label28.Text = reader("price")

                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try   'block 2
                    Dim updatesql As String = "Select name,maxguest,price,objtype
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 2"
                    Dim cmd4 As New SqlCommand(updatesql, Conn)
                    Dim reader2 As SqlDataReader
                    reader2 = cmd4.ExecuteReader
                    reader2.Read()
                    Label41.Text = reader2("name")
                    Label36.Text = reader2("maxguest")
                    Label35.Text = reader2("objtype")
                    Label34.Text = reader2("price")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try


            Case 3
                GroupBox15.Visible = True
                GroupBox17.Visible = True
                GroupBox21.Visible = True

                Try   'block 1
                    Dim updatesql As String = "Select name,maxguest,price,objtype
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label25.Text = reader("name")
                    Label26.Text = reader("maxguest")
                    Label27.Text = reader("objtype")
                    Label28.Text = reader("price")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try   'block 2
                    Dim updatesql As String = "Select name,maxguest,price,objtype
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label25.Text = reader("name")
                    Label26.Text = reader("maxguest")
                    Label27.Text = reader("objtype")
                    Label28.Text = reader("price")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try   'block 3
                    Dim updatesql As String = "Select name,maxguest,price,objtype
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 3"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label25.Text = reader("name")
                    Label26.Text = reader("maxguest")
                    Label27.Text = reader("objtype")
                    Label28.Text = reader("price")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

        End Select


    End Sub

    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "select count(*) from service_order"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmdreq As New SqlCommand(sql, Conn)
            count = cmdreq.ExecuteScalar()
            MessageBox.Show(count)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

        Select Case count
            Case 10
                GroupBox12.Visible = True
                GroupBox23.Visible = False
                GroupBox25.Visible = False
                GroupBox27.Visible = False
                GroupBox24.Visible = False
                GroupBox26.Visible = False

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label29.Text = reader("roomno")
                    Label62.Text = reader("name")
                    ComboBox2.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

            Case 2
                GroupBox12.Visible = True
                GroupBox23.Visible = True
                GroupBox25.Visible = False
                GroupBox27.Visible = False
                GroupBox24.Visible = False
                GroupBox26.Visible = False

            Case 3
                GroupBox12.Visible = True
                GroupBox23.Visible = True
                GroupBox25.Visible = True
                GroupBox27.Visible = False
                GroupBox24.Visible = False
                GroupBox26.Visible = False
            Case 4
                GroupBox12.Visible = True
                GroupBox23.Visible = True
                GroupBox25.Visible = True
                GroupBox27.Visible = True
                GroupBox24.Visible = False
                GroupBox26.Visible = False

            Case 5
                GroupBox12.Visible = True
                GroupBox23.Visible = True
                GroupBox25.Visible = True
                GroupBox27.Visible = True
                GroupBox24.Visible = True
                GroupBox26.Visible = False

            Case 6
                GroupBox12.Visible = True
                GroupBox23.Visible = True
                GroupBox25.Visible = True
                GroupBox27.Visible = True
                GroupBox24.Visible = True
                GroupBox26.Visible = True

        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "insert into service_order(status) values(@status)"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@status", "processed")
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
    End Sub
    Private Sub cbUpdate()

    End Sub
    Dim citem As String
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        citem = ComboBox2.SelectedItem

    End Sub


    Private Sub TabPage8_Enter(sender As Object, e As EventArgs) Handles TabPage8.Enter
        DateTimePicker2.Format = DateTimePickerFormat.Time
        DateTimePicker2.ShowUpDown = True
        DateTimePicker4.Format = DateTimePickerFormat.Time
        DateTimePicker4.ShowUpDown = True
    End Sub



    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.Format = DateTimePickerFormat.Time
        DateTimePicker2.ShowUpDown = True
        myDate = DateTimePicker1.Value.Date +
                    DateTimePicker2.Value.TimeOfDay
        TextBox1.Text = myDate
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker2.Format = DateTimePickerFormat.Time
        DateTimePicker2.ShowUpDown = True
        myDate = DateTimePicker1.Value.Date +
                    DateTimePicker2.Value.TimeOfDay
        TextBox1.Text = myDate
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        DateTimePicker4.Format = DateTimePickerFormat.Time
        DateTimePicker4.ShowUpDown = True
        myDate = DateTimePicker1.Value.Date +
                    DateTimePicker2.Value.TimeOfDay
        TextBox2.Text = myDate
    End Sub

    Private Sub DateTimePicker4_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged
        DateTimePicker4.Format = DateTimePickerFormat.Time
        DateTimePicker4.ShowUpDown = True
        myDate = DateTimePicker1.Value.Date +
                    DateTimePicker2.Value.TimeOfDay
        TextBox2.Text = myDate
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "select count(*) from units where date > @mydate or date = NULL"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmdreq As New SqlCommand(sql, Conn)
            count = cmdreq.ExecuteScalar()
            cmdreq.Parameters.AddWithValue("@mydate", myDate)
            MessageBox.Show(count)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

        Select Case count
            Case 1
                GroupBox29.Visible = True
                GroupBox30.Visible = False
            Case 2
                GroupBox29.Visible = True
                GroupBox30.Visible = True
        End Select
    End Sub

    Private Sub GroupBox30_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "insert into units(roomtype)values((select Id from roomType where name = '" & Label25.Text & "'))"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmdreq As New SqlCommand(sql, Conn)
            cmdreq.ExecuteNonQuery()
            'cmdreq.Parameters.AddWithValue("@type", Label25.Text)
            MessageBox.Show("Done")
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

    End Sub
End Class
