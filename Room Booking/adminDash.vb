Imports System.Data.SqlClient
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Public Class adminDash
    Public count As Integer
    Public myDate As New DateTime
    Public roomno As Integer
    Public userId As Integer
    Dim dailyrent As Integer
    Dim price As Integer
    Public selectedmethod As String
    Public c1id As Integer
    Public c2id As Integer
    Public c3id As Integer
    Public c4id As Integer
    Public c5id As Integer
    Public c6id As Integer

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        roomAdder.Show()

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
        'ListView1.View = View.Details
        'ListView1.GridLines = True
        Try
            Conn.Open()
            Dim cmd2 As New SqlCommand(sql, Conn)
            count = cmd2.ExecuteScalar()

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
                    Dim sql1 As String = "Select rimage
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 1"
                    Dim cmd4 As New SqlCommand(sql1, Conn)
                    Dim ImgStream As New IO.MemoryStream(CType(cmd4.ExecuteScalar, Byte()))
                    PictureBox9.Image = Image.FromStream(ImgStream)

                    ImgStream.Dispose()


                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try

                Try
                    Dim sql1 As String = "Select roomno, minguest, maxguest from units where roomtype=(Select Id from roomType where name = '" & Label25.Text & "')"

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

                Try
                    Dim sql1 As String = "Select rimage
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 1"
                    Dim cmd4 As New SqlCommand(sql1, Conn)
                    Dim ImgStream As New IO.MemoryStream(CType(cmd4.ExecuteScalar, Byte()))
                    PictureBox9.Image = Image.FromStream(ImgStream)

                    ImgStream.Dispose()


                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
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

                Try
                    Dim sql1 As String = "Select rimage
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 2"
                    Dim cmd4 As New SqlCommand(sql1, Conn)
                    Dim ImgStream As New IO.MemoryStream(CType(cmd4.ExecuteScalar, Byte()))
                    PictureBox10.Image = Image.FromStream(ImgStream)

                    ImgStream.Dispose()


                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
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

                Try
                    Dim sql1 As String = "Select rimage
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 1"
                    Dim cmd4 As New SqlCommand(sql1, Conn)
                    Dim ImgStream As New IO.MemoryStream(CType(cmd4.ExecuteScalar, Byte()))
                    PictureBox9.Image = Image.FromStream(ImgStream)

                    ImgStream.Dispose()


                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
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

                Try
                    Dim sql1 As String = "Select rimage
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 2"
                    Dim cmd4 As New SqlCommand(sql1, Conn)
                    Dim ImgStream As New IO.MemoryStream(CType(cmd4.ExecuteScalar, Byte()))
                    PictureBox10.Image = Image.FromStream(ImgStream)

                    ImgStream.Dispose()


                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
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

                Try
                    Dim sql1 As String = "Select rimage
From 
(
    Select 
      Row_Number() Over (Order By id) As RowNum
    , *
    From roomType
) t2
Where RowNum = 3"
                    Dim cmd4 As New SqlCommand(sql1, Conn)
                    Dim ImgStream As New IO.MemoryStream(CType(cmd4.ExecuteScalar, Byte()))
                    PictureBox12.Image = Image.FromStream(ImgStream)

                    ImgStream.Dispose()


                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try
#End Region
        End Select

#End Region
    End Sub

    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "select count(*) from service_order where status <> 'Fulfilled'"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmdreq As New SqlCommand(sql, Conn)
            count = cmdreq.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

        Select Case count

#Region "Case 1 of Service requests"
            Case 0
                GroupBox12.Visible = False
                GroupBox23.Visible = False
                GroupBox25.Visible = False
                GroupBox27.Visible = False
                GroupBox24.Visible = False
                GroupBox26.Visible = False
            Case 1
                GroupBox12.Visible = True
                GroupBox23.Visible = False
                GroupBox25.Visible = False
                GroupBox27.Visible = False
                GroupBox24.Visible = False
                GroupBox26.Visible = False

                Try
                    Dim updatesql As String = "Select Id, roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c1id = reader("Id")
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
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c1id = reader("Id")
                    Label29.Text = reader("roomno")
                    Label62.Text = reader("name")
                    ComboBox2.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c2id = reader("Id")
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
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c1id = reader("Id")
                    Label29.Text = reader("roomno")
                    Label62.Text = reader("name")
                    ComboBox2.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c2id = reader("Id")
                    Label64.Text = reader("roomno")
                    Label63.Text = reader("name")
                    ComboBox3.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 3"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c3id = reader("Id")
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
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c1id = reader("Id")
                    Label29.Text = reader("roomno")
                    Label62.Text = reader("name")
                    ComboBox2.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c2id = reader("Id")
                    Label64.Text = reader("roomno")
                    Label63.Text = reader("name")
                    ComboBox3.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 3"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c3id = reader("Id")
                    Label68.Text = reader("roomno")
                    Label67.Text = reader("name")
                    ComboBox5.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try

                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 4"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c4id = reader("Id")
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
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c1id = reader("Id")
                    Label29.Text = reader("roomno")
                    Label62.Text = reader("name")
                    ComboBox2.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c2id = reader("Id")
                    Label64.Text = reader("roomno")
                    Label63.Text = reader("name")
                    ComboBox3.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 3"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c3id = reader("Id")
                    Label68.Text = reader("roomno")
                    Label67.Text = reader("name")
                    ComboBox5.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 4"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c4id = reader("Id")
                    Label72.Text = reader("roomno")
                    Label71.Text = reader("name")
                    ComboBox7.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 5"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c5id = reader("Id")
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
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c1id = reader("Id")
                    Label29.Text = reader("roomno")
                    Label62.Text = reader("name")
                    ComboBox2.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 2"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c2id = reader("Id")
                    Label64.Text = reader("roomno")
                    Label63.Text = reader("name")
                    ComboBox3.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 3"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c3id = reader("Id")
                    Label68.Text = reader("roomno")
                    Label67.Text = reader("name")
                    ComboBox5.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 4"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c4id = reader("Id")
                    Label72.Text = reader("roomno")
                    Label71.Text = reader("name")
                    ComboBox7.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 5"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c5id = reader("Id")
                    Label66.Text = reader("roomno")
                    Label65.Text = reader("name")
                    ComboBox4.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try

                Try
                    Dim updatesql As String = "Select Id,roomno, name, status From (Select Row_Number() Over (Order By id) As RowNum, *From service_order where status <> 'Fulfilled') t2 Where RowNum = 6"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    c6id = reader("Id")
                    Label70.Text = reader("roomno")
                    Label69.Text = reader("name")
                    ComboBox6.SelectedItem = reader("status")
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                End Try
#End Region
        End Select
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)
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
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "update service_order set status=@status where Id= @id"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@status", citem)
            cmd.Parameters.AddWithValue("@id", c1id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try


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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "insert into units(roomtype,minguest, maxguest, isoccuppied)values((select Id from roomType where name = '" & Label41.Text & "'),(select minguest from roomType where name='" & Label41.Text & "'),(select maxguest from roomType where name='" & Label41.Text & "'),@false)"
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

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "insert into units(roomtype,minguest, maxguest, isoccuppied)values((select Id from roomType where name = '" & Label61.Text & "'),(select minguest from roomType where name='" & Label61.Text & "'),(select maxguest from roomType where name='" & Label61.Text & "'),@false)"
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
        Dim sql As String = "insert into units(roomtype,minguest, maxguest, isoccuppied)values((select Id from roomType where name = '" & Label51.Text & "'),(select minguest from roomType where name='" & Label51.Text & "'),(select maxguest from roomType where name='" & Label51.Text & "'),@false)"
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
        GroupBox34.Visible = True


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

        Try
            Dim sql2 As String = "update Users set isbooked = @true where Id = @userid"
            Dim cmd1 As New SqlCommand(sql2, Conn)
            cmd1.Parameters.AddWithValue("@true", "true")
            cmd1.Parameters.AddWithValue("@userid", userId)
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
        GroupBox33.Visible = True



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
            Label12.Text = occupancy
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
            Dim sql As String = "select userid from reservation where roomno = @roomno and ispaid is null"
            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@roomno", TextBox3.Text)
            userId = cmd.ExecuteScalar

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql As String = "select price from billing where userid =@userid and Item=@roomcharges"


            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", userId)
            cmd.Parameters.AddWithValue("@roomcharges", "Room Charges")
            roomcharge = cmd.ExecuteScalar
            Console.WriteLine("room price: {0}", roomcharge)
            Label114.Text = roomcharge
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql As String = "select price from billing where userid =@userid and item=@services"


            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", userId)
            cmd.Parameters.AddWithValue("@services", "Services")
            services = cmd.ExecuteScalar
            Label115.Text = services
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
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql As String = "insert into payment(userid, date, method, amount) values(@userid,@date,@method,@amount)"
            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", userId)
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(theDate))
            cmd.Parameters.AddWithValue("@method", selectedmethod)
            cmd.Parameters.AddWithValue("@amount", Label117.Text)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Payment successfully registred")
            'Clear values hide payement methods
            Label120.Text = ""
            Label122.Text = ""
            TextBox9.Text = ""
            Label114.Text = ""
            Label115.Text = ""
            Label116.Text = ""
            Label117.Text = ""
            GroupBox35.Visible = False
            GroupBox28.Visible = False
            TextBox3.Text = ""

            'success message
            'update ispaid in reservation
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

    Private Sub TabPage5_Enter(sender As Object, e As EventArgs) Handles TabPage5.Enter
        Label114.Text = ""
        Label115.Text = ""
        Label116.Text = ""
        Label117.Text = ""
    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        Try

            Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
            Dim sql As String = "select name, price from services"
            Dim Conn As New SqlConnection(str)
            Dim cmd As New SqlCommand(sql, Conn)
            Dim adapter As New SqlDataAdapter(cmd)

            Dim table As New DataTable

            adapter.Fill(table)

            DataGridView5.DataSource = table
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
    End Sub




    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim dataAdapter As New SqlClient.SqlDataAdapter()
        Dim dataSet As New DataSet
        Dim command As New SqlClient.SqlCommand
        Dim datatableMain As New System.Data.DataTable()
        Dim connection As New SqlClient.SqlConnection

        'Assign your connection string to connection object
        connection.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        command.Connection = connection
        command.CommandType = CommandType.Text
        'You can use any command select
        command.CommandText = "Select * from reservation"
        dataAdapter.SelectCommand = command


        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                'This section help you if your language is not English.
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
                Dim oExcel As Excel.Application
                Dim oBook As Excel.Workbook
                Dim oSheet As Excel.Worksheet
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add(Type.Missing)
                oSheet = oBook.Worksheets(1)

                Dim misValue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer
                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                'Fill data to datatable
                connection.Open()
                dataAdapter.Fill(datatableMain)
                connection.Close()


                'Export the Columns to excel file
                For Each dc In datatableMain.Columns
                    colIndex = colIndex + 1
                    oSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                'Export the rows to excel file
                For Each dr In datatableMain.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In datatableMain.Columns
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                'Set final path
                Dim fileName As String = "\ExportedReservations" + ".xls"
                Dim finalPath = f.SelectedPath + fileName
                txtPath.Text = finalPath
                oSheet.Columns.AutoFit()
                'Save file in final path
                oBook.SaveAs(finalPath, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)



                'Release the objects
                ReleaseObject(oSheet)
                oBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(oBook)
                oExcel.Quit()
                ReleaseObject(oExcel)
                'Some time Office application does not quit after automation: so i am calling GC.Collect method.
                GC.Collect()

                MessageBox.Show("Export done successfully!")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        GroupBox41.Visible = True
        Dim dataAdapter As New SqlClient.SqlDataAdapter()
        Dim dataSet As New DataSet
        Dim command As New SqlClient.SqlCommand
        Dim datatableMain As New System.Data.DataTable()
        Dim connection As New SqlClient.SqlConnection

        'Assign your connection string to connection object
        connection.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        command.Connection = connection
        command.CommandType = CommandType.Text
        'You can use any command select
        command.CommandText = "Select * from service_order"
        dataAdapter.SelectCommand = command


        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                'This section help you if your language is not English.
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
                Dim oExcel As Excel.Application
                Dim oBook As Excel.Workbook
                Dim oSheet As Excel.Worksheet
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add(Type.Missing)
                oSheet = oBook.Worksheets(1)

                Dim misValue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer
                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                'Fill data to datatable
                connection.Open()
                dataAdapter.Fill(datatableMain)
                connection.Close()


                'Export the Columns to excel file
                For Each dc In datatableMain.Columns
                    colIndex = colIndex + 1
                    oSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                'Export the rows to excel file
                For Each dr In datatableMain.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In datatableMain.Columns
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                'Set final path
                Dim fileName As String = "\ExportedServices" + ".xls"
                Dim finalPath = f.SelectedPath + fileName
                txtPath.Text = finalPath
                oSheet.Columns.AutoFit()
                'Save file in final path
                oBook.SaveAs(finalPath, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)



                'Release the objects
                ReleaseObject1(oSheet)
                oBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject1(oBook)
                oExcel.Quit()
                ReleaseObject1(oExcel)
                'Some time Office application does not quit after automation: so i am calling GC.Collect method.
                GC.Collect()

                MessageBox.Show("Export done successfully!")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ReleaseObject1(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        GroupBox41.Visible = True
        Dim dataAdapter As New SqlClient.SqlDataAdapter()
        Dim dataSet As New DataSet
        Dim command As New SqlClient.SqlCommand
        Dim datatableMain As New System.Data.DataTable()
        Dim connection As New SqlClient.SqlConnection

        'Assign your connection string to connection object
        connection.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        command.Connection = connection
        command.CommandType = CommandType.Text
        'You can use any command select
        command.CommandText = "Select * from payment"
        dataAdapter.SelectCommand = command


        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                'This section help you if your language is not English.
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
                Dim oExcel As Excel.Application
                Dim oBook As Excel.Workbook
                Dim oSheet As Excel.Worksheet
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add(Type.Missing)
                oSheet = oBook.Worksheets(1)

                Dim misValue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer
                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                'Fill data to datatable
                connection.Open()
                dataAdapter.Fill(datatableMain)
                connection.Close()


                'Export the Columns to excel file
                For Each dc In datatableMain.Columns
                    colIndex = colIndex + 1
                    oSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                'Export the rows to excel file
                For Each dr In datatableMain.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In datatableMain.Columns
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                'Set final path
                Dim fileName As String = "\ExportedPayment" + ".xls"
                Dim finalPath = f.SelectedPath + fileName
                txtPath.Text = finalPath
                oSheet.Columns.AutoFit()
                'Save file in final path
                oBook.SaveAs(finalPath, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)



                'Release the objects
                ReleaseObject2(oSheet)
                oBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject2(oBook)
                oExcel.Quit()
                ReleaseObject2(oExcel)
                'Some time Office application does not quit after automation: so i am calling GC.Collect method.
                GC.Collect()

                MessageBox.Show("Export done successfully!")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ReleaseObject2(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        GroupBox41.Visible = True
        GroupBox43.Visible = False
        GroupBox45.Visible = False
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        GroupBox41.Visible = False
        GroupBox43.Visible = True
        GroupBox45.Visible = False
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        GroupBox41.Visible = False
        GroupBox43.Visible = False
        GroupBox45.Visible = True
    End Sub

    Private Sub TabPage6_Enter(sender As Object, e As EventArgs) Handles TabPage6.Enter
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim Conn As New SqlConnection(str)
        Try
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim sql2 As String = "select sum(amount) from payment"
            Dim cmd1 As New SqlCommand(sql2, Conn)
            Dim total As Integer = cmd1.ExecuteScalar
            Label124.Text = total

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql2 As String = "select sum(amount) from payment where method=@cash"
            Dim cmd1 As New SqlCommand(sql2, Conn)
            Dim total As Integer
            cmd1.Parameters.AddWithValue("@cash", "Cash")
            total = cmd1.ExecuteScalar

            If IsDBNull(cmd1.ExecuteScalar) Then
                Label128.Text = 0
            Else
                Label128.Text = total
            End If



        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql2 As String = "select sum(amount) from payment where method=@card"
            Dim cmd1 As New SqlCommand(sql2, Conn)
            Dim total As Integer
            cmd1.Parameters.AddWithValue("@card", "Card")
            total = cmd1.ExecuteScalar
            If IsDBNull(cmd1.ExecuteScalar) Then
                Label131.Text = 0
            Else
                Label131.Text = total
            End If

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql2 As String = "select sum(amount) from payment where method=@check"
            Dim cmd1 As New SqlCommand(sql2, Conn)
            Dim total As Integer
            cmd1.Parameters.AddWithValue("@check", "Check")
            total = cmd1.ExecuteScalar
            If IsDBNull(cmd1.ExecuteScalar) Then
                Label133.Text = 0
            Else
                Label133.Text = total
            End If

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql2 As String = "select sum(amount) from payment where method=@upi"
            Dim cmd1 As New SqlCommand(sql2, Conn)
            Dim total As Integer
            cmd1.Parameters.AddWithValue("@upi", "UPI")
            total = cmd1.ExecuteScalar
            If IsDBNull(cmd1.ExecuteScalar) Then
                Label135.Text = 0
            Else
                Label135.Text = total
            End If


        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim Conn As New SqlConnection(str)

        Try
            Dim sql As String = "select isoccuppied from units where roomno=@roomno"
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@roomno", TextBox1.Text)
            Conn.Open()
            Dim isoccupied = cmd.ExecuteScalar
            Console.WriteLine("Exception caught: {0}", isoccupied)
            If (isoccupied.Equals("false")) Then
                MessageBox.Show("Room is vacant")
                GroupBox11.Visible = False
                TextBox1.Text = ""
            Else
                GroupBox20.Visible = False
                GroupBox11.Visible = True
                Dim sql1 As String = "select userid from reservation where roomno = @roomno"
                Dim cmd1 As New SqlCommand(sql1, Conn)
                cmd1.Parameters.AddWithValue("@roomno", TextBox1.Text)
                Dim userid = cmd1.ExecuteScalar

                Dim sql2 As String = "select Name, Email, Phone from Users where userid = @userid"
                Dim cmd2 As New SqlCommand(sql2, Conn)
                cmd2.Parameters.AddWithValue("@userid", userid)
                Dim reader As SqlDataReader
                reader = cmd.ExecuteReader
                reader.Read()
                Label42.Text = reader("Name")
                Label43.Text = reader("Phone")
                Label74.Text = reader("Email")

                Dim sql3 As String = "select price where "


            End If

        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        citem = ComboBox5.SelectedItem
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "update service_order set status=@status where Id= @id"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@status", citem)
            cmd.Parameters.AddWithValue("@id", c3id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        citem = ComboBox3.SelectedItem
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "update service_order set status=@status where Id= @id"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@status", citem)
            cmd.Parameters.AddWithValue("@id", c2id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        citem = ComboBox7.SelectedItem
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "update service_order set status=@status where Id= @id"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@status", citem)
            cmd.Parameters.AddWithValue("@id", c4id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        citem = ComboBox4.SelectedItem
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "update service_order set status=@status where Id= @id and "
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@status", citem)
            cmd.Parameters.AddWithValue("@id", c5id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        citem = ComboBox6.SelectedItem
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "update service_order set status=@status where Id= @id"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@status", citem)
            cmd.Parameters.AddWithValue("@id", c6id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
    End Sub








#End Region
End Class
