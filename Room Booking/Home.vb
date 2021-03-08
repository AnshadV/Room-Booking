Imports System.Data.SqlClient
Public Class Home
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
        Try
            Conn.Open()
            Dim cmdreq As New SqlCommand(sql, Conn)
            count = cmdreq.ExecuteScalar()
            MessageBox.Show(count)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

#Region "Services List"
        Select Case count
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
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
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
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
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
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
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
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
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
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
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
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
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
                Dim sql As String = "insert into service_order(status, price, service_id, name) values('" & status & " ', '" & total(i) & "','" & id & "','" & names(i) & "')"
                Dim cmd As New SqlCommand(sql, Conn)

                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(String.Format("Error: {0}", ex.Message))
            End Try
        Next

    End Sub
End Class