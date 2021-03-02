Imports System.Data.SqlClient
Public Class adminDash
    Public count As Integer
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

        End Try
    End Sub

    Private Sub GroupBox14_Enter(sender As Object, e As EventArgs) Handles GroupBox14.Enter

    End Sub

    Private Sub GroupBox15_Enter(sender As Object, e As EventArgs) Handles GroupBox15.Enter

    End Sub

    Private Sub TabPage7_Enter(sender As Object, e As EventArgs) Handles TabPage7.Enter
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
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
            Case 2
                GroupBox15.Visible = True
                GroupBox17.Visible = True
                GroupBox21.Visible = False
            Case 3
                GroupBox15.Visible = True
                GroupBox17.Visible = True
                GroupBox21.Visible = True
        End Select

    End Sub
End Class