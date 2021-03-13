Imports System.Data.SqlClient
Imports System.IO
Public Class roomAdder

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "insert into roomType(name, rimage, minguest, maxguest, price, objtype) values(@name,@rimage,@minguest,@maxguest,@price,@objtype)"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@name", TextBox1.Text)

            Dim ms As New MemoryStream()
            PictureBox1.BackgroundImage.Save(ms, PictureBox1.BackgroundImage.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@rimage", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)

            cmd.Parameters.AddWithValue("@minguest", ComboBox1.SelectedItem)
            cmd.Parameters.AddWithValue("@maxguest", ComboBox2.SelectedItem)
            cmd.Parameters.AddWithValue("@price", TextBox3.Text)
            cmd.Parameters.AddWithValue("@objtype", ComboBox3.SelectedItem)
            cmd.ExecuteNonQuery()
            'setting up amenities table
            Dim sqlgetid As String = "select id from roomType where name = @name"
            Dim cmd1 As New SqlCommand(sqlgetid, Conn)
            cmd1.Parameters.AddWithValue("@name", TextBox1.Text)
            Dim id = cmd1.ExecuteScalar() 'retrieving id from roomType 


            Dim sqlpop As String = "insert into amenitiesbin values(@Id,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)"
            Dim cmd2 As New SqlCommand(sqlpop, Conn)
            cmd2.Parameters.AddWithValue("@id", id)
            cmd2.ExecuteNonQuery()



            Console.WriteLine("Default values: {0}", "Done")
            For Each item In CheckedListBox1.CheckedItems
                Dim checkeditem As String = item.ToString()
                Dim sqlchecked As String = "update amenitiesbin set " & checkeditem & "=1 where Id='" & id & "'"
                Dim cmd3 As New SqlCommand(sqlchecked, Conn)
                cmd3.Parameters.AddWithValue("@id", id)
                Console.WriteLine("loop: {0}", checkeditem)
                cmd3.ExecuteNonQuery()
            Next

            Me.Close()
            adminDash.Refresh()
            MessageBox.Show("Done")
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class

'Dim cmd As New SqlCommand("INSERT INTO Information VALUES(@name,@photo)", con)
'cmd.Parameters.AddWithValue("@name", TextBox1.Text)
'Dim ms As New MemoryStream()
'PictureBox1.BackgroundImage.Save(ms, PictureBox1.BackgroundImage.RawFormat)
'Dim data As Byte() = ms.GetBuffer()
'Dim p As New SqlParameter("@photo", SqlDbType.Image)
'p.Value = data
'cmd.Parameters.Add(p)
'cmd.ExecuteNonQuery()

'If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
'PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
'Label1.Visible = True
'TextBox1.Visible = True
'Label1.Text = "Name"
'TextBox1.Clear()
'End If