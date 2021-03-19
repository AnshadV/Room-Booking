Imports System.Data.SqlClient
Imports Room_Booking.loginstate
Public Class Home
    Public indate As New DateTime
    Public outdate As New DateTime
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim itemcoll(100) As String
    Dim totalprice As Integer
    Private Sub MonthCalendar1_DateChanged(ByVal sender As Object,
           ByVal e As System.Windows.Forms.DateRangeEventArgs)
        TextBox1.Text = e.Start.ToShortDateString()
    End Sub
    Private Sub MonthCalendar2_DateChanged(ByVal sender As Object,
           ByVal e As System.Windows.Forms.DateRangeEventArgs)
        TextBox2.Text = e.Start.ToShortDateString()
    End Sub



    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        ListView1.Columns.Add("Service", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("Price", 150, HorizontalAlignment.Left)
        ListView1.View = View.Details
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim sql As String = "select count(*) from services"
        Dim Conn As New SqlConnection(str)
        Dim count
        Dim count1 As Integer
        Try
            Conn.Open()
            Dim cmdreq As New SqlCommand(sql, Conn)
            count = cmdreq.ExecuteScalar()
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql1 As String = "select count(*) from service_order where roomno=@roomno"
            Dim cmdreq As New SqlCommand(sql1, Conn)
            cmdreq.Parameters.AddWithValue("@roomno", roomno)
            count1 = cmdreq.ExecuteScalar()
            Console.WriteLine("room no: {0}", roomno)
            Console.WriteLine("count: {0}", count1)
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        If (count1 > 0) Then
            Try


                Dim sql1 As String = "select name, status from service_order where roomno=@roomno"
                Dim cmd As New SqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@roomno", roomno)
                Dim adapter As New SqlDataAdapter(cmd)

                Dim table As New DataTable

                adapter.Fill(table)

                DataGridView2.DataSource = table
            Catch ex As Exception
                MessageBox.Show(String.Format("Error: {0}", ex.Message))
            End Try
        End If


#Region "Services List"
        Select Case count
            Case 0
                Label1.Visible = False
                Label2.Visible = False
                Label4.Visible = False
                Label3.Visible = False
                Label6.Visible = False
                Label5.Visible = False
                Label8.Visible = False
                Label7.Visible = False
                Label10.Visible = False
                Label9.Visible = False
                Label12.Visible = False
                Label11.Visible = False

                Button1.Visible = False
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = False
                Button5.Visible = False
                Button6.Visible = False
            Case 1
                Label1.Visible = True
                Label2.Visible = True
                Label4.Visible = False
                Label3.Visible = False
                Label6.Visible = False
                Label5.Visible = False
                Label8.Visible = False
                Label7.Visible = False
                Label10.Visible = False
                Label9.Visible = False
                Label12.Visible = False
                Label11.Visible = False

                Button1.Visible = True
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = False
                Button5.Visible = False
                Button6.Visible = False


                Try
                    Dim updatesql As String = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label1.Text = reader("name")
                    Label2.Text = reader("price")
                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try

            Case 2
                Label1.Visible = True
                Label2.Visible = True
                Label4.Visible = True
                Label3.Visible = True
                Label6.Visible = False
                Label5.Visible = False
                Label8.Visible = False
                Label7.Visible = False
                Label10.Visible = False
                Label9.Visible = False
                Label12.Visible = False
                Label11.Visible = False

                Button1.Visible = True
                Button2.Visible = True
                Button3.Visible = False
                Button4.Visible = False
                Button5.Visible = False
                Button6.Visible = False
                Button7.Visible = False

                Try
                    Dim updatesql As String = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label1.Text = reader("name")
                    Label2.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 2"
                    Dim cmd4 As New SqlCommand(updatesql, Conn)
                    reader = cmd4.ExecuteReader
                    reader.Read()
                    Label4.Text = reader("name")
                    Label3.Text = reader("price")

                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try

            Case 3
                Label1.Visible = True
                Label3.Visible = True
                Label4.Visible = True
                Label2.Visible = True
                Label6.Visible = True
                Label5.Visible = True
                Label11.Visible = True
                Label10.Visible = False
                Label13.Visible = False
                Label12.Visible = False
                Label15.Visible = False
                Label14.Visible = False

                Button2.Visible = True
                Button3.Visible = True
                Button4.Visible = True
                Button5.Visible = False
                Button6.Visible = False
                Button7.Visible = False

                Try
                    Dim updatesql As String = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label1.Text = reader("name")
                    Label2.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 2"
                    Dim cmd4 As New SqlCommand(updatesql, Conn)
                    reader = cmd4.ExecuteReader
                    reader.Read()
                    Label4.Text = reader("name")
                    Label3.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 3"
                    Dim cmd5 As New SqlCommand(updatesql, Conn)
                    reader = cmd5.ExecuteReader
                    reader.Read()
                    Label6.Text = reader("name")
                    Label5.Text = reader("price")
                    reader.Close()
                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try

            Case 4
                Label1.Visible = True
                Label3.Visible = True
                Label4.Visible = True
                Label2.Visible = True
                Label6.Visible = True
                Label5.Visible = True
                Label11.Visible = True
                Label10.Visible = True
                Label13.Visible = False
                Label12.Visible = False
                Label15.Visible = False
                Label14.Visible = False

                Button2.Visible = True
                Button3.Visible = True
                Button4.Visible = True
                Button5.Visible = True
                Button6.Visible = False
                Button7.Visible = False

                Try
                    Dim updatesql As String = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label1.Text = reader("name")
                    Label2.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 2"
                    Dim cmd4 As New SqlCommand(updatesql, Conn)
                    reader = cmd4.ExecuteReader
                    reader.Read()
                    Label4.Text = reader("name")
                    Label3.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 3"
                    Dim cmd5 As New SqlCommand(updatesql, Conn)
                    reader = cmd5.ExecuteReader
                    reader.Read()
                    Label6.Text = reader("name")
                    Label5.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 4"
                    Dim cmd6 As New SqlCommand(updatesql, Conn)
                    reader = cmd6.ExecuteReader
                    reader.Read()
                    Label8.Text = reader("name")
                    Label7.Text = reader("price")
                    reader.Close()

                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try

            Case 5
                Label1.Visible = True
                Label3.Visible = True
                Label4.Visible = True
                Label2.Visible = True
                Label6.Visible = True
                Label5.Visible = True
                Label11.Visible = True
                Label10.Visible = True
                Label13.Visible = True
                Label12.Visible = True
                Label15.Visible = False
                Label14.Visible = False

                Button2.Visible = True
                Button3.Visible = True
                Button4.Visible = True
                Button5.Visible = True
                Button6.Visible = True
                Button7.Visible = False
                Try
                    Dim updatesql As String = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label1.Text = reader("name")
                    Label2.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 2"
                    Dim cmd4 As New SqlCommand(updatesql, Conn)
                    reader = cmd4.ExecuteReader
                    reader.Read()
                    Label4.Text = reader("name")
                    Label3.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 3"
                    Dim cmd5 As New SqlCommand(updatesql, Conn)
                    reader = cmd5.ExecuteReader
                    reader.Read()
                    Label6.Text = reader("name")
                    Label5.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 4"
                    Dim cmd6 As New SqlCommand(updatesql, Conn)
                    reader = cmd6.ExecuteReader
                    reader.Read()
                    Label8.Text = reader("name")
                    Label7.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 5"
                    Dim cmd7 As New SqlCommand(updatesql, Conn)
                    reader = cmd7.ExecuteReader
                    reader.Read()
                    Label10.Text = reader("name")
                    Label9.Text = reader("price")
                    reader.Close()

                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try

            Case 6

                Label1.Visible = True
                Label3.Visible = True
                Label4.Visible = True
                Label2.Visible = True
                Label6.Visible = True
                Label5.Visible = True
                Label11.Visible = True
                Label10.Visible = True
                Label13.Visible = True
                Label12.Visible = True
                Label15.Visible = True
                Label14.Visible = True

                Button2.Visible = True
                Button3.Visible = True
                Button4.Visible = True
                Button5.Visible = True
                Button6.Visible = True
                Button7.Visible = True

                Try
                    Dim updatesql As String = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 1"
                    Dim cmd3 As New SqlCommand(updatesql, Conn)
                    Dim reader As SqlDataReader
                    reader = cmd3.ExecuteReader
                    reader.Read()
                    Label1.Text = reader("name")
                    Label2.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 2"
                    Dim cmd4 As New SqlCommand(updatesql, Conn)
                    reader = cmd4.ExecuteReader
                    reader.Read()
                    Label4.Text = reader("name")
                    Label3.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 3"
                    Dim cmd5 As New SqlCommand(updatesql, Conn)
                    reader = cmd5.ExecuteReader
                    reader.Read()
                    Label6.Text = reader("name")
                    Label5.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 4"
                    Dim cmd6 As New SqlCommand(updatesql, Conn)
                    reader = cmd6.ExecuteReader
                    reader.Read()
                    Label8.Text = reader("name")
                    Label7.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 5"
                    Dim cmd7 As New SqlCommand(updatesql, Conn)
                    reader = cmd7.ExecuteReader
                    reader.Read()
                    Label10.Text = reader("name")
                    Label9.Text = reader("price")
                    reader.Close()

                    updatesql = "Select name, price From (Select Row_Number() Over (Order By id) As RowNum, *From services) t2 Where RowNum = 6"
                    Dim cmd8 As New SqlCommand(updatesql, Conn)
                    reader = cmd8.ExecuteReader
                    reader.Read()
                    Label2.Text = reader("name")
                    Label11.Text = reader("price")
                    reader.Close()

                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try
        End Select
#End Region

    End Sub

    Dim total(7) As Integer
    Dim names(7) As String
    Public sum As Integer
    Public index As Integer

#Region "Service button"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str(1) As String
        Dim itm As ListViewItem
        str(0) = Label1.Text
        str(1) = Label2.Text
        itm = New ListViewItem(str)
        ListView1.Items.Add(itm)
        Dim ct = total.Last - 1
        Console.WriteLine("Index at beginning: {0}", total)
        Console.WriteLine("Index at beginning: {0}", ct)
        If ct = -1 Then
            names(0) = Label1.Text
            total(0) = Label2.Text
            ct = 0
        Else
            names(ct - 1) = Label1.Text
            total(ct - 1) = Label2.Text
        End If
        index = ct + 1
        calcTotal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str(1) As String
        Dim itm As ListViewItem
        str(0) = Label4.Text
        str(1) = Label3.Text
        itm = New ListViewItem(str)
        ListView1.Items.Add(itm)
        Dim ct = total.GetUpperBound(total.Last)
        total(ct - 1) = Label3.Text
        names(ct - 1) = Label4.Text
        calcTotal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim str(1) As String
        Dim itm As ListViewItem
        str(0) = Label6.Text
        str(1) = Label5.Text
        itm = New ListViewItem(str)
        ListView1.Items.Add(itm)
        Dim ct = total.GetUpperBound(total.Last)
        total(ct - 1) = Label5.Text
        names(ct - 1) = Label6.Text
        calcTotal()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim str(1) As String
        Dim itm As ListViewItem
        str(0) = Label8.Text
        str(1) = Label7.Text
        itm = New ListViewItem(str)
        ListView1.Items.Add(itm)
        total.Append(Label7.Text)
        Dim ct = total.GetUpperBound(total.Last)
        total(ct - 1) = Label7.Text
        names(ct - 1) = Label8.Text
        calcTotal()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim str(1) As String
        Dim itm As ListViewItem
        str(0) = Label10.Text
        str(1) = Label9.Text
        itm = New ListViewItem(str)
        Dim ct = total.GetUpperBound(total.Last)
        total(ct - 1) = Label9.Text
        names(ct - 1) = Label10.Text
        calcTotal()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim str(1) As String
        Dim itm As ListViewItem
        str(0) = Label12.Text
        str(1) = Label11.Text
        itm = New ListViewItem(str)
        ListView1.Items.Add(itm)
        Dim ct = total.GetUpperBound(total.Last)
        total(ct - 1) = Label11.Text
        names(ct - 1) = Label12.Text
        calcTotal()
    End Sub
    Private Sub calcTotal()
        For ctr As Integer = 0 To total.Length - 1
            sum += total(ctr)
        Next
        Label17.Text = sum
        totalprice = sum
    End Sub



#End Region
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim Conn As New SqlConnection(str)
        Dim id As Integer
        Dim status As String = "Request recieved"
        Conn.Open()
        Console.WriteLine("Db: {0}", "Connecting")
        'Dim ctr = total.GetUpperBound(ct)
        Console.WriteLine("index: {0}", index)
        For i As Integer = 0 To index - 1
            Console.WriteLine("name: {0},", names(i))
            Console.WriteLine("price: {0},", total(i))
            Try
                Dim sql1 As String = "select id from services where name = '" & names(i) & "'"
                Dim cmd1 As New SqlCommand(sql1, Conn)
                id = cmd1.ExecuteScalar()
                Console.WriteLine(names(i))
                Console.WriteLine("loop: {0}", i)
            Catch ex As Exception
                MessageBox.Show(String.Format("Error: {0}", ex.Message))
            End Try
            Try
                Dim sql As String = "insert into service_order(status, price, service_id, name, roomno) values('" & status & " ', '" & total(i) & "','" & id & "','" & names(i) & "',(select roomno from reservation where userid = @userid))"
                Dim cmd As New SqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@userid", login_userid)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                Console.WriteLine("Exception caught: {0}", ex)
            End Try
        Next

        Try
            Dim sql2 As String = "update billing set price = price+@price where userid= @userid and item = @services"
            Dim cmd1 As New SqlCommand(sql2, Conn)
            cmd1.Parameters.AddWithValue("@userid", login_userid)
            cmd1.Parameters.AddWithValue("@services", "Services")
            cmd1.Parameters.AddWithValue("@price", totalprice)
            cmd1.ExecuteNonQuery()
            MessageBox.Show(String.Format("Order Placed Successfully"))
            ListView1.Clear()
            Label17.Text = ""
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try



    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        DateTimePicker2.Format = DateTimePickerFormat.Time
        DateTimePicker2.ShowUpDown = True
        DateTimePicker4.Format = DateTimePickerFormat.Time
        DateTimePicker4.ShowUpDown = True
        ListView1.View = View.Details
        ListView1.GridLines = True
    End Sub



    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.Format = DateTimePickerFormat.Time
        DateTimePicker2.ShowUpDown = True
        indate = DateTimePicker1.Value.Date +
                    DateTimePicker2.Value.TimeOfDay
        TextBox1.Text = indate
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker2.Format = DateTimePickerFormat.Time
        DateTimePicker2.ShowUpDown = True
        indate = DateTimePicker1.Value.Date +
                    DateTimePicker2.Value.TimeOfDay
        TextBox1.Text = indate
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        DateTimePicker4.Format = DateTimePickerFormat.Time
        DateTimePicker4.ShowUpDown = True
        outdate = DateTimePicker3.Value.Date +
                    DateTimePicker4.Value.TimeOfDay
        TextBox2.Text = outdate
    End Sub

    Private Sub DateTimePicker4_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged
        DateTimePicker4.Format = DateTimePickerFormat.Time
        DateTimePicker4.ShowUpDown = True
        outdate = DateTimePicker3.Value.Date +
                    DateTimePicker4.Value.TimeOfDay
        TextBox2.Text = outdate
    End Sub

    'Private Sub Button7_Click(sender As Object, e As EventArgs)
    '    Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
    '    Dim sql As String = "select roomno from units where (date > '" & myDate & "' or date is null) and minguest > '" & ComboBox1.SelectedItem & "'"
    '    Dim Conn As New SqlConnection(str)
    '    Dim cmd As New SqlCommand(sql, Conn)
    '    Dim adapter As New SqlDataAdapter(cmd)

    '    Dim table As New DataTable

    '    adapter.Fill(table)

    '    DataGridView1.DataSource = table
    '    Try
    '        Dim sqlb As String = "select
    '        CASE 
    '            when Wifi = 1 then 'Wifi'
    '        end, 
    '        CASE 
    '            when refrigerator = 1 then 'referigerator'
    '        end,
    '        CASE
    '            when Shower = 1 then 'Shower'
    '        end,
    '        CASE        
    '            when Pool = 1 then 'Pool'
    '        end
    '    from amenitiesbin where Id = 1044;"
    '        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"

    '        Dim Conn As New SqlConnection(str)
    '        Dim cmd7 As New SqlCommand(sqlb, Conn)
    '        da = New SqlDataAdapter(cmd7)
    '        ds = New DataSet
    '        da.Fill(ds, "Table")
    '        Dim i As Integer = 0
    '        Dim j As Integer = 0
    '        ' adding the columns in ListView    
    '        For i = 0 To ds.Tables(0).Columns.Count - 1
    '            Me.ListView2.Columns.Add(ds.Tables(0).Columns(i).ColumnName.ToString())
    '        Next
    '        'Now adding the Items in Listview
    '        For i = 0 To ds.Tables(0).Rows.Count - 1
    '            For j = 0 To ds.Tables(0).Columns.Count - 1
    '                itemcoll(j) = ds.Tables(0).Rows(i)(j).ToString()
    '            Next
    '            Dim lvi As New ListViewItem(itemcoll)
    '            Me.ListView2.Items.Add(lvi)
    '            Me.ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    '        Next
    '    Catch ex As Exception
    '        MessageBox.Show(String.Format("Error: {0}", ex.Message))
    '    End Try


    'End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        roomno = TextBox6.Text
        Dim checkin As DateTime = TextBox1.Text
        Dim checkout As DateTime = TextBox2.Text
        Dim price As Integer
        Dim dailyrent As Integer

        Try
            Dim Conn As New SqlConnection(str)
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim updatesql As String = "Select price from roomType where Id = (select roomType from units where roomno = '" & roomno & "')"
            Dim cmd3 As New SqlCommand(updatesql, Conn)
            Dim reader As SqlDataReader
            reader = cmd3.ExecuteReader
            cmd3.Parameters.AddWithValue("@roomno", roomno)
            reader.Read()

            dailyrent = reader("price")
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

        If (checkout >= checkin.AddHours(24)) And (checkout <= checkin.AddHours(26)) Then
            price = dailyrent
        ElseIf (checkout >= checkin.AddHours(48)) And (checkout <= checkin.AddHours(50)) Then
            price = dailyrent + dailyrent
        ElseIf (checkout <= checkin.AddHours(24)) Then
            price = dailyrent
        End If
        roomprice = price
        Booking.Show()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click


        Try

            Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
            Dim sql As String = "select roomno from units where (date > @time or date is null) and minguest >= '" & ComboBox1.SelectedItem & "'"
            Dim Conn As New SqlConnection(str)
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@time", DateTime.Parse(indate))
            Dim adapter As New SqlDataAdapter(cmd)

            Dim table As New DataTable

            adapter.Fill(table)

            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try



    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        GroupBox4.Visible = True
    End Sub

    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Dim roomcharge As Integer
        Dim services As Integer
        Try
            Dim sql As String = "select price from billing where userid =@userid and item=@roomcharges"
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If

            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", login_userid)
            cmd.Parameters.AddWithValue("@roomcharges", "Room charges")
            reader = cmd.ExecuteReader
            reader.Read()
            roomcharge = reader("price")
            Label114.Text = roomcharge
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try

        Try
            Dim sql As String = "select price from billing where userid =@userid and item=@services"
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If

            Dim cmd As New SqlCommand(sql, Conn)
            Dim reader As SqlDataReader
            cmd.Parameters.AddWithValue("@userid", login_userid)
            cmd.Parameters.AddWithValue("@services", "Services")
            reader = cmd.ExecuteReader
            reader.Read()
            services = reader("price")
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

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=true"
        Dim Conn As New SqlConnection(str)
        Dim isbooked As String
        Dim ispaid As String
        Button7.Visible = True
        Try
            Dim sql As String = "select isbooked from Users where Id=@userid"
            If (Conn.State.Equals(ConnectionState.Closed)) Then
                Conn.Open()
            End If
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@userid", login_userid)
            isbooked = cmd.ExecuteScalar
            If isbooked.Equals("false") Then
                Panel1.Visible = True
                Panel2.Visible = True
                GroupBox28.SendToBack()
                GroupBox1.SendToBack()
                GroupBox2.SendToBack()

            Else
                Try
                    Dim sql1 As String = "select ispaid from reservation where userid =@userid"
                    If (Conn.State.Equals(ConnectionState.Closed)) Then
                        Conn.Open()
                    End If
                    Dim cmd1 As New SqlCommand(sql1, Conn)
                    cmd1.Parameters.AddWithValue("@userid", login_userid)
                    ispaid = cmd.ExecuteScalar
                    If ispaid.Equals("true") Then
                        Button9.Visible = False
                        Label113.Visible = False
                        Label117.Visible = False
                        Label27.Visible = True
                    End If
                Catch ex As Exception
                    Console.WriteLine("Exception caught: {0}", ex)
                End Try
            End If
        Catch ex As Exception
            Console.WriteLine("Exception caught: {0}", ex)
        End Try





    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

    End Sub
End Class