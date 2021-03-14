Imports System.Data.SqlClient
Imports System.IO

Public Class adminDash
    Public count As Integer
    Public myDate As New DateTime
    Public roomno As Integer
    Public userId As Integer
    Dim dailyrent As Integer
    Dim price As Integer
    Public selectedmethod As String

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


    Private Sub TabPage7_Enter(sender As Object, e As EventArgs) Handles TabPage7.Enter
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "select count(*) from roomType"
        Dim Conn As New SqlConnection(str)
        ListView1.View = View.Details
        ListView1.GridLines = True
        Try
            Conn.Open()
            Dim cmd2 As New SqlCommand(sql, Conn)
            count = cmd2.ExecuteScalar()
            MessageBox.Show(count)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
#Region "Room type"
        Select Case count
#Region "Case 1 of roomType"
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

                Try
                    Dim sql1 As String = "select roomno, minguest, maxguest from units where roomtype=(select Id from roomType where name = '" & Label25.Text & "')"

                    Dim cmd As New SqlCommand(sql1, Conn)
                    Dim adapter As New SqlDataAdapter(cmd)

                    Dim table As New DataTable

                    adapter.Fill(table)

                    DataGridView2.DataSource = table
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
#End Region
#Region "Case 2 of roomtype"
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

                Try
                    Dim sql1 As String = "select roomno, minguest, maxguest from units where roomtype=(select Id from roomType where name = '" & Label25.Text & "')"

                    Dim cmd As New SqlCommand(sql1, Conn)
                    Dim adapter As New SqlDataAdapter(cmd)

                    Dim table As New DataTable

                    adapter.Fill(table)

                    DataGridView2.DataSource = table
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

                Try
                    Dim sql1 As String = "select roomno, minguest, maxguest from units where roomtype=(select Id from roomType where name = '" & Label41.Text & "')"

                    Dim cmd As New SqlCommand(sql1, Conn)
                    Dim adapter As New SqlDataAdapter(cmd)

                    Dim table As New DataTable

                    adapter.Fill(table)

                    DataGridView3.DataSource = table
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
#End Region
#Region "Case 3 of roomtype"
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

                Try
                    Dim sql1 As String = "select roomno, minguest, maxguest from units where roomtype=(select Id from roomType where name = '" & Label25.Text & "')"

                    Dim cmd As New SqlCommand(sql1, Conn)
                    Dim adapter As New SqlDataAdapter(cmd)

                    Dim table As New DataTable

                    adapter.Fill(table)

                    DataGridView2.DataSource = table
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

                Try
                    Dim sql1 As String = "select roomno, minguest, maxguest from units where roomtype=(select Id from roomType where name = '" & Label41.Text & "')"

                    Dim cmd As New SqlCommand(sql1, Conn)
                    Dim adapter As New SqlDataAdapter(cmd)

                    Dim table As New DataTable

                    adapter.Fill(table)

                    DataGridView3.DataSource = table
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

                Try
                    Dim sql1 As String = "select roomno, minguest, maxguest from units where roomtype=(select Id from roomType where name = '" & Label61.Text & "')"

                    Dim cmd As New SqlCommand(sql1, Conn)
                    Dim adapter As New SqlDataAdapter(cmd)

                    Dim table As New DataTable

                    adapter.Fill(table)

                    DataGridView4.DataSource = table
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
#End Region
        End Select

#End Region
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
#Region "Case 1 of Service requests"
            Case 1
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
#End Region
#Region "Case 2 of service requests"
            Case 2
                GroupBox12.Visible = True
                GroupBox23.Visible = True
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

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label64.Text = reader("roomno")
                    Label63.Text = reader("name")
                    ComboBox3.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
#End Region
#Region "Case 3 of Service requests"
            Case 3
                GroupBox12.Visible = True
                GroupBox23.Visible = True
                GroupBox25.Visible = True
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

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label64.Text = reader("roomno")
                    Label63.Text = reader("name")
                    ComboBox3.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label68.Text = reader("roomno")
                    Label67.Text = reader("name")
                    ComboBox5.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
#End Region
#Region "Case 4 of Service requests"
            Case 4
                GroupBox12.Visible = True
                GroupBox23.Visible = True
                GroupBox25.Visible = True
                GroupBox27.Visible = True
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

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label64.Text = reader("roomno")
                    Label63.Text = reader("name")
                    ComboBox3.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label68.Text = reader("roomno")
                    Label67.Text = reader("name")
                    ComboBox5.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label72.Text = reader("roomno")
                    Label71.Text = reader("name")
                    ComboBox7.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
#End Region
#Region "Case 5 of Service requests"
            Case 5
                GroupBox12.Visible = True
                GroupBox23.Visible = True
                GroupBox25.Visible = True
                GroupBox27.Visible = True
                GroupBox24.Visible = True
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

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label64.Text = reader("roomno")
                    Label63.Text = reader("name")
                    ComboBox3.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label68.Text = reader("roomno")
                    Label67.Text = reader("name")
                    ComboBox5.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label72.Text = reader("roomno")
                    Label71.Text = reader("name")
                    ComboBox7.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label66.Text = reader("roomno")
                    Label65.Text = reader("name")
                    ComboBox7.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
#End Region
#Region "Case 6 of Service requests"
            Case 6
                GroupBox12.Visible = True
                GroupBox23.Visible = True
                GroupBox25.Visible = True
                GroupBox27.Visible = True
                GroupBox24.Visible = True
                GroupBox26.Visible = True

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

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label64.Text = reader("roomno")
                    Label63.Text = reader("name")
                    ComboBox3.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label68.Text = reader("roomno")
                    Label67.Text = reader("name")
                    ComboBox5.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label72.Text = reader("roomno")
                    Label71.Text = reader("name")
                    ComboBox7.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label66.Text = reader("roomno")
                    Label65.Text = reader("name")
                    ComboBox4.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From services_order) t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label70.Text = reader("roomno")
                    Label69.Text = reader("name")
                    ComboBox6.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
#End Region
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

    '    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
    '        Dim sql As String = "select count(*) from units where date > '" & myDate & "' or date is null"
    '        Dim Conn As New SqlConnection(str)
    '        Try
    '            Conn.Open()
    '            Dim cmdreq As New SqlCommand(sql, Conn)
    '            count = cmdreq.ExecuteScalar()
    '            'cmdreq.Parameters.AddWithValue("@date", myDate)
    '            MessageBox.Show(count)
    '        Catch ex As Exception
    '            MessageBox.Show(String.Format("Erroree: {0}", ex.Message))
    '        End Try

    '        Select Case count
    '            Case 1
    '                GroupBox29.Visible = True
    '                GroupBox30.Visible = False

    '                Try
    '                    Dim updatesql As String = "Select units.roomno, roomType.name, roomType.rimage, roomType.price From (Select Row_Number() Over (Order By units.roomno) As RowNum, *From units) t2 left join units on roomType.Id= units.roomtype Where RowNum = 1 And units.date > '" & myDate & "' or units.date is null"
    '                    Dim upsql As String = "select roomno, date (select units.roomno from units where units.roomno = roomType.Id) as rt from (
    '    Select 
    '      Row_Number() Over (Order By id) As RowNum
    '    , *
    '    From roomType
    ') t2
    'Where RowNum = 1"
    '                    Dim cmd3 As New SqlCommand(updatesql, Conn)
    '                    Dim reader As SqlDataReader
    '                    reader = cmd3.ExecuteReader
    '                    cmd3.Parameters.AddWithValue("@date", myDate)
    '                    reader.Read()
    '                    Label37.Text = reader("roomType.name")
    '                    Label74.Text = reader("roomType.price")
    '                Catch ex As Exception
    '                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
    '                End Try

    '            Case 2
    '                GroupBox29.Visible = True
    '                GroupBox30.Visible = True
    '        End Select
    '    End Sub

    '    Private Sub GroupBox30_Enter(sender As Object, e As EventArgs)

    '    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "insert into units(roomtype,minguest, maxguest, isoccuppied)values((select Id from roomType where name = '" & Label25.Text & "'),(select minguest from roomType where name='" & Label25.Text & "'),(select maxguest from roomType where name='" & Label25.Text & "'),@false)"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmdreq As New SqlCommand(sql, Conn)
            cmdreq.Parameters.AddWithValue("false", False)
            cmdreq.ExecuteNonQuery()
            'cmdreq.Parameters.AddWithValue("@type", Label25.Text)
            MessageBox.Show("Done")
            DataGridView2.Refresh()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "select roomno from units where (date > '" & myDate & "' or date is null) and minguest > '" & ComboBox1.SelectedItem & "'"
        Dim Conn As New SqlConnection(str)
        Dim cmd As New SqlCommand(sql, Conn)
        Dim adapter As New SqlDataAdapter(cmd)

        Dim table As New DataTable

        adapter.Fill(table)

        DataGridView1.DataSource = table
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        roomno = TextBox6.Text
        Booking.Show()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
#Region "Check-in"
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "select Name,Email, Id from Users where Phone = '" & TextBox7.Text & "'"
        Dim Conn As New SqlConnection(str)

        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            reader.Read()
            Label91.Text = reader("Name")
            Label92.Text = TextBox7.Text
            Label94.Text = reader("Email")
            userId = reader("Id")
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql1 As String = "select roomno from reservation where userid = '" & userId & "'"
            Dim cmd As New SqlCommand(sql1, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", userId)
            reader = cmd.ExecuteReader
            reader.Read()
            Label98.Text = reader("roomno")
            roomno = Label98.Text

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql1 As String = "select price from roomType where Id = (select roomtype from units where roomno = @roomno)"
            Dim cmd As New SqlCommand(sql1, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@roomno", roomno)
            reader = cmd.ExecuteReader
            reader.Read()
            Label96.Text = reader("price")

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try



    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Dim theDate As DateTime = System.DateTime.Now
        Dim theDatestr = theDate.ToString("yyyyMMddHHmmss")

        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql1 As String = "update reservation set checkin=@time where userid = @userId"
            Dim cmd As New SqlCommand(sql1, Conn)
            cmd.Parameters.AddWithValue("@time", DateTime.Parse(theDate))
            cmd.Parameters.AddWithValue("@userid", userId)
            Console.WriteLine("Exception caught: {0}", theDate)
            Console.WriteLine("Exception caught: {0}", theDatestr)
            cmd.ExecuteNonQuery()
            Dim sql2 As String = "update reservation set ischeckedin = @true where userid = @userid"
            Dim Conn1 As New SqlConnection(str)
            Dim cmd1 As New SqlCommand(sql2, Conn1)
            cmd1.Parameters.AddWithValue("@true", "true")
            cmd1.Parameters.AddWithValue("@userid", userId)
            If (Conn1.State.Equals(ConnectionState.Closed)) Then
                Conn1.Open()
            End If
            cmd1.ExecuteNonQuery()

            MessageBox.Show(String.Format("Checked-In Successfully"))
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql2 As String = "insert into billing(userid, item, price) values(@userid, @services, @price)"
            Dim cmd1 As New SqlCommand(sql2, Conn)
            cmd1.Parameters.AddWithValue("@userid", userId)
            cmd1.Parameters.AddWithValue("@services", "Services")
            cmd1.Parameters.AddWithValue("@price", 0)
            cmd1.ExecuteNonQuery()
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try
    End Sub
#End Region
#Region "Checkout"
    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Dim checkin As DateTime
        Dim currenttime As DateTime = System.DateTime.Now

        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql1 As String = "select userid from reservation where roomno = @roomno and checkout is null"
            Dim cmd As New SqlCommand(sql1, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@roomno", TextBox8.Text)
            reader = cmd.ExecuteReader

            reader.Read()
            userId = reader("userid")

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql As String = "select Name,Email, Phone from Users where Id = @userid"


            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", userId)
            reader = cmd.ExecuteReader
            reader.Read()
            Label107.Text = reader("Name")
            Label105.Text = reader("Phone")
            Label103.Text = reader("Email")
            Label90.Text = TextBox8.Text
            roomno = Label90.Text
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try



        Try
            Dim sql1 As String = "select price from roomType where Id = (select roomtype from units where roomno = @roomno)"
            Dim cmd As New SqlCommand(sql1, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("roomno", roomno)
            reader = cmd.ExecuteReader
            reader.Read()
            dailyrent = reader("price")
            Label101.Text = dailyrent

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql1 As String = "select checkin from reservation where userid = @userid"
            Dim cmd As New SqlCommand(sql1, Conn)
            cmd.Parameters.AddWithValue("@userid", userId)
            checkin = cmd.ExecuteScalar

            If (currenttime > checkin.AddHours(26)) Then
                price = price + dailyrent
                Label101.Text = price
            ElseIf (currenttime > checkin.AddHours(49)) Then
                price = price + dailyrent + dailyrent
                Label101.Text = price
            ElseIf (currenttime < checkin.AddHours(24)) Then
                price = dailyrent
            End If
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try




    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Dim theDate As DateTime = System.DateTime.Now
        Dim checkin As DateTime
        Dim price As Integer
        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql1 As String = "update reservation set checkout=@time where userid = @userid"
            Dim cmd As New SqlCommand(sql1, Conn)
            cmd.Parameters.AddWithValue("@time", DateTime.Parse(theDate))
            cmd.Parameters.AddWithValue("@userid", userId)
            cmd.ExecuteNonQuery()
            MessageBox.Show(String.Format("Checked-Out Successfully"))
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

        Try
            Dim sql1 As String = "select checkin from reservation where userid = @userid"
            Dim cmd As New SqlCommand(sql1, Conn)
            cmd.Parameters.AddWithValue("@userid", userId)
            checkin = cmd.ExecuteScalar

            If (theDate > checkin.AddHours(26)) Then
                price = price + dailyrent
                Console.WriteLine("checkin.AddHours(26)): {0}", checkin.AddHours(26))
            ElseIf (theDate > checkin.AddHours(48)) Then
                price = price + dailyrent + dailyrent
                Console.WriteLine("checkin.AddHours(48)): {0}", checkin.AddHours(48))
            ElseIf (theDate < checkin.AddHours(24)) Then
                price = dailyrent
                Console.WriteLine("<checkin.AddHours(26)): {0}", checkin.AddHours(26))
            End If
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql2 As String = "insert into billing(userid, item, price) values(@userid, @room, @price)"
            Dim cmd1 As New SqlCommand(sql2, Conn)
            cmd1.Parameters.AddWithValue("@userid", userId)
            cmd1.Parameters.AddWithValue("@room", "Room Charges")
            cmd1.Parameters.AddWithValue("@price", price)
            cmd1.ExecuteNonQuery()
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Dim newbookings As Integer
        Dim theDate As DateTime = System.DateTime.Now
        Dim totalunits As Integer
        Dim occupancy As Integer
        Dim unitsavailable As Integer
        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql1 As String = "select count(*) from reservation where ischeckedin = @false"
            Dim cmd As New SqlCommand(sql1, Conn)
            cmd.Parameters.AddWithValue("@false", "false")
            newbookings = cmd.ExecuteScalar
            Label4.Text = newbookings
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql1 As String = "select count(*) from reservation where checkin < DATEADD(HOUR,-24,@time)"
            Dim cmd As New SqlCommand(sql1, Conn)
            cmd.Parameters.AddWithValue("@time", DateTime.Parse(theDate))
            Label6.Text = cmd.ExecuteScalar
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql1 As String = "select count(*) from reservation where checkout < DATEADD(HOUR,-24,@time)"
            Dim cmd As New SqlCommand(sql1, Conn)
            cmd.Parameters.AddWithValue("@time", DateTime.Parse(theDate))
            Label5.Text = cmd.ExecuteScalar
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql1 As String = "select count(*) from units where isoccuppied != @true"
            Dim cmd As New SqlCommand(sql1, Conn)
            cmd.Parameters.AddWithValue("@true", "true")
            Label10.Text = cmd.ExecuteScalar
            unitsavailable = Label10.Text
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql1 As String = "select count(*) from units"
            Dim cmd As New SqlCommand(sql1, Conn)
            cmd.Parameters.AddWithValue("@true", "true")
            totalunits = cmd.ExecuteScalar
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        If (totalunits <> 0) Then
            occupancy = (unitsavailable / totalunits) * 100
        Else
            Label12.Text = 0
        End If


    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Dim roomcharge As Integer
        Dim services As Integer
        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql As String = "select userid from reservation where roomno = @roomno and ispaid is not null"
            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@roomno", TextBox3.Text)
            userId = cmd.ExecuteScalar

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql As String = "select price from billing where userid =@userid and item=@roomcharges"


            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", userId)
            cmd.Parameters.AddWithValue("@roomcharges", "Room charges")
            reader = cmd.ExecuteReader
            reader.Read()
            Label114.Text = reader("price")
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql As String = "select price from billing where userid =@userid and item=@services"


            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", userId)
            cmd.Parameters.AddWithValue("@services", "Services")
            reader = cmd.ExecuteReader
            reader.Read()
            Label115.Text = reader("price")
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Dim total As Integer = roomcharge + services
        Dim tax As Integer = (6 * total) / 100
        Label116.Text = tax
        Dim grandtotal As Integer = total + tax
        Label117.Text = grandtotal
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Dim theDate As DateTime = System.DateTime.Now
        Try
            Dim sql As String = "insert into payment(userid, date, method, amount) values(@userid,@date,@method,@amount)"
            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", userId)
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(theDate))
            cmd.Parameters.AddWithValue("@method", selectedmethod)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        selectedmethod = RadioButton1.Text
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        selectedmethod = RadioButton2.Text
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        selectedmethod = RadioButton3.Text
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        selectedmethod = RadioButton4.Text
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox9.Text = Label117.Text
        Label120.Text = Label117.Text
        Label122.Text = Label117.Text
        GroupBox35.Visible = True

    End Sub


#End Region
End Class
