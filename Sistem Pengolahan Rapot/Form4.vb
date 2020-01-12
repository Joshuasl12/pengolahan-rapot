Public Class Form4
    Dim gam As String
    Dim i As Integer
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.IndianRed
        ComboBox4.Items.Add("RPL")
        ComboBox4.Items.Add("BDP")
        ComboBox4.Items.Add("TKJ")
        ComboBox4.Items.Add("MMD")
        ComboBox4.Items.Add("OTKP")
        ComboBox4.Items.Add("HTL")
        ComboBox4.Items.Add("TBG")
        TextBox7.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Dim tgl As Integer
        For tgl = 1 To 23
            If tgl < 24 Then
                ComboBox6.Items.Add(tgl)
            End If
        Next
        Call panggildata()
    End Sub

    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_siswa", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_siswa")
        DataGridView1.DataSource = DS.Tables("tb_siswa")
        DataGridView1.Enabled = True
    End Sub

    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        objcmd.Dispose()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox7.Text = ""
        TextBox6.Text = ""
        ComboBox6.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        PictureBox1.Image = Nothing
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call panggildata()
        Timer1.Stop()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim jks As String
        i = DataGridView1.CurrentRow.Index

        If RadioButton1.Checked = True Then
            jks = "Laki-laki"
        ElseIf RadioButton2.Checked = True Then
            jks = "Perempuan"
        End If
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox7.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("Maaf Data yang Anda masukan masih kurang lengkap")
        ElseIf val(TextBox1.Text) = DataGridView1.Item("NIS", i).Value Then
            MsgBox("Maaf NIS tidak boleh sama")
            TextBox1.Clear()
        Else
            sqlnya = "insert into tb_siswa(`NIS`,`Nama`,`Jenis_Kelamin`,`Tempat_Lahir`,`Tanggal_Lahir`,`Rombel`,`Kode_Rayon`,`Lokasi_Foto`,`Angkatan`) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & jks & "','" & TextBox3.Text & "','" & DateTimePicker1.Value & "','" & ComboBox4.Text & "','" & TextBox7.Text & "','" & TextBox4.Text & "','" & ComboBox6.Text & "')"
            Call jalan()
            MsgBox("Data Berhasil Tersimpan")
            Timer1.Start()
        End If
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If i = -1 Then
            MsgBox("Data Telah Habis")
        Else
            TextBox1.Text = DataGridView1.Item(0, i).Value
            TextBox2.Text = DataGridView1.Item(1, i).Value
            If DataGridView1.Item(2, i).Value = "Laki-laki" Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
            TextBox3.Text = DataGridView1.Item(3, i).Value
            DateTimePicker1.Value = DataGridView1.Item(4, 1).Value
            ComboBox4.Text = DataGridView1.Item(5, i).Value
            TextBox7.Text = DataGridView1.Item(6, i).Value
            TextBox4.Text = DataGridView1.Item(7, i).Value
            PictureBox1.ImageLocation = DataGridView1.Item(7, i).Value
            ComboBox6.Text = DataGridView1.Item(8, i).Value
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        End If
        Button5.Enabled = True
        Button6.Enabled = True
        Button4.Enabled = False
        TextBox1.Enabled = False
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Not IsNumeric(TextBox1.Text) And TextBox1.Text <> "" Then
            MsgBox("NIS tidak bisa diisi Huruf")
            TextBox1.Clear()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ko As String
        ko = MsgBox("Apakah Anda yakin?", vbYesNo, "Sistem Lab Say")
        If ko = vbYes Then
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox5.Clear()
            TextBox7.Clear()
            TextBox4.Clear()
            ComboBox4.SelectedIndex = -1
            ComboBox6.SelectedIndex = -1
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            PictureBox1.ImageLocation = ""
            Button4.Enabled = True
            Button5.Enabled = False
            Button6.Enabled = False
            TextBox1.Enabled = True
        Else
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form5.Show()
        Hide()
    End Sub


    Private PathFile As String = Nothing
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        OpenFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|BMP Files(*.bmp)|*.bmp|TIFF Files(*.tiff)|*.tiff"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Image = New Bitmap(OpenFileDialog1.FileName)
            Button8.Enabled = True
            PathFile = OpenFileDialog1.FileName
            TextBox6.Text = PathFile.Substring(PathFile.LastIndexOf("\") + 1)
            TextBox4.Text = OpenFileDialog1.FileName
            gam = OpenFileDialog1.FileName
            PictureBox1.Image = Image.FromFile(TextBox4.Text)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sqlnya = "delete from tb_siswa where Kode_Rayon='" & TextBox7.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil Terhapus")
        Timer1.Start()
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub
    'update'
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim jk As String
        If RadioButton1.Checked = True Then
            jk = "Laki-laki"
        ElseIf RadioButton2.Checked = True Then
            jk = "Perempuan"
        End If
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox7.Text = "" Or ComboBox4.Text = "" Or ComboBox6.Text = "" Or RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("Maaf Data yang Anda masukan masih kurang lengkap")
        Else
            sqlnya = "UPDATE tb_siswa set Nama='" & TextBox2.Text & "',Jenis_Kelamin='" & jk & "',Tempat_Lahir='" & TextBox3.Text & "',Tanggal_Lahir='" & DateTimePicker1.Value & "',Rombel='" & ComboBox4.Text & "', Angkatan='" & ComboBox6.Text & "',Lokasi_Foto='" & TextBox4.Text & "' where Kode_rayon='" & TextBox7.Text & "'"
            Call jalan()
            MsgBox("Data Berhasil Terubah")
            Timer1.Start()
        End If
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
        PictureBox1.ImageLocation = ""
    End Sub
    'pencarian'
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_siswa where NIS like '%" & TextBox5.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_siswa")
        DataGridView1.DataSource = DS.Tables("tb_siswa")
    End Sub

    Private Sub TextBox1_Gotfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.BackColor = Color.AliceBlue
    End Sub
    Private Sub TextBox1_lostfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        TextBox1.BackColor = Color.White
    End Sub
    Private Sub TextBox2_Gotfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.BackColor = Color.AliceBlue
    End Sub
    Private Sub TextBox2_lostfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        TextBox2.BackColor = Color.White
    End Sub
    Private Sub TextBox3_Gotfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.BackColor = Color.AliceBlue
    End Sub
    Private Sub TextBox3_lostfocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        TextBox3.BackColor = Color.White
    End Sub
    Private Sub TextBox5_Gotfocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBox5.BackColor = Color.AliceBlue
    End Sub
    Private Sub TextBox5_lostfocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBox5.BackColor = Color.White
    End Sub
    Private Sub ComboBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.GotFocus
        ComboBox4.BackColor = Color.AliceBlue
    End Sub
    Private Sub ComboBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.LostFocus
        ComboBox4.BackColor = Color.White
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        form13.show()
    End Sub
End Class