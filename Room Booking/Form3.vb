Imports System.IO
Imports System.Data.SqlClient
Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim sql As String = "Insert into ImageData(ImageData) values (@img)"
        Dim Conn As New SqlConnection(str)

        Try
            Dim fop As OpenFileDialog = New OpenFileDialog()

            If fop.ShowDialog() = DialogResult.OK Then
                Dim FS As FileStream = New FileStream(fop.FileName, FileMode.Open, FileAccess.Read)
                Dim img As Byte() = New Byte(FS.Length - 1) {}
                FS.Read(img, 0, Convert.ToInt32(FS.Length))
                If Conn.State = ConnectionState.Closed Then Conn.Open()
                Dim cmd As New SqlCommand(sql, Conn)
                'Dim cmd As SqlCommand = New SqlCommand("SaveImage", Conn)
                'cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@img", SqlDbType.Image).Value = img

                'Dim imageParameter As New SqlParameter("@img", SqlDbType.Image)
                'imageParameter.Value = DBNull.Value
                'cmd.Parameters.Add(imageParameter)
                cmd.ExecuteNonQuery()
                loadImageIDs()
                MessageBox.Show("Image Save Successfully!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please Select a Image to save!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cmbImageID.SelectedValue IsNot Nothing Then
            If PictureBox1.Image IsNot Nothing Then PictureBox1.Image.Dispose()
            Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
            Dim Conn As New SqlConnection(str)
            Dim cmd As SqlCommand = New SqlCommand("SaveImage", Conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@imgId", SqlDbType.Int).Value = Convert.ToInt32(cmbImageID.SelectedValue.ToString())
            Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()

            Try
                If Conn.State = ConnectionState.Closed Then Conn.Open()
                adp.Fill(dt)

                If dt.Rows.Count > 0 Then
                    Dim ms As MemoryStream = New MemoryStream(CType(dt.Rows(0)("ImageData"), Byte()))
                    PictureBox1.Image = Image.FromStream(ms)
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                    PictureBox1.Refresh()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Finally
                If Conn.State = ConnectionState.Open Then Conn.Close()
            End Try
        Else
            MessageBox.Show("Please Select a Image ID to Display!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        loadImageIDs()
    End Sub

    Private Sub UsingSPs_Load(ByVal sender As Object, ByVal e As EventArgs)
        loadImageIDs()
    End Sub

    Private Sub loadImageIDs()
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=True"
        Dim Conn As New SqlConnection(str)
        Dim cmd As SqlCommand = New SqlCommand("ReadAllImageIDs", Conn)
        cmd.CommandType = CommandType.StoredProcedure
        Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()

        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
            adp.Fill(dt)

            If dt.Rows.Count > 0 Then
                cmbImageID.DataSource = dt
                cmbImageID.ValueMember = "ImageID"
                cmbImageID.DisplayMember = "ImageID"
                cmbImageID.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub
End Class