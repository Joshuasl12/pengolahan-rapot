Public Class Form8
    Dim gam, a As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form9.Show()
        Hide()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ko As String
        ko = MsgBox("Apakah Anda yakin?", vbYesNo, "Sistem Lab Say")
        If ko = vbYes Then
            Call jalan()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()
            ComboBox1.SelectedIndex = -1
            ComboBox2.SelectedIndex = -1
            ComboBox4.SelectedIndex = -1
            Button4.Enabled = True
            Button5.Enabled = False
            Button6.Enabled = False
            TextBox1.Enabled = False
        Else
        End If
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("UTS")
        ComboBox1.Items.Add("UAS")
        ComboBox2.Items.Add("GENAP")
        ComboBox2.Items.Add("GANJIL")
        TextBox2.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Dim tgl As Integer
        For tgl = 2009 To 2099
            If tgl < 2099 Then
                ComboBox4.Items.Add(tgl)
            End If
        Next
        Call panggildata()
        Call kodeauto()
    End Sub
    Sub kodeauto()
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        TextBox1.Enabled = False
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM qw_nilai", conn)
        CMD = New OleDb.OleDbCommand("SELECT * FROM qw_nilai order by Kode_Nilai desc", conn)
        RD = CMD.ExecuteReader
        If RD.Read Then
            strSementara = Mid(RD.Item("Kode_Nilai").ToString, 4, 3)
            strIsi = Val(strSementara) + 1
            TextBox1.Text = "n00" + Mid("0", 1, 2 + strIsi.Length) & strIsi
        Else
            TextBox1.Text = "n0001"
        End If
        TextBox2.Focus()
    End Sub

    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM qw_nilai", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "qw_nilai")
        DataGridView1.DataSource = DS.Tables("qw_nilai")
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
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        Call kodeauto()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Maaf Data yang Anda masukan masih kurang lengkap")
        Else
            sqlnya = "insert into tb_nilai(`Kode_Nilai`,`Jenis_Ulangan`,`Semester`,`NIS`,`Kode_Mapel`,`Nilai`,`Keterangan`,`Tahun_Pelajaran`) values('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox2.Text & "','" & TextBox6.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox4.Text & "')"
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
            a = DataGridView1.Item("Kode_Nilai", i).Value
            'MsgBox(a)
            TextBox1.Text = DataGridView1.Item(0, i).Value
            ComboBox1.Text = DataGridView1.Item(1, i).Value
            ComboBox2.Text = DataGridView1.Item(2, i).Value
            TextBox2.Text = DataGridView1.Item(3, i).Value

            Dim objcmd As New System.Data.OleDb.OleDbCommand
            Call konek()
            objcmd.Connection = conn
            objcmd.CommandType = CommandType.Text
            objcmd.CommandText = "select * from qw_nilai where NIS='" & TextBox2.Text & "'"
            RD = objcmd.ExecuteReader()
            RD.Read()
            If RD.HasRows Then
                TextBox7.Text = RD.Item("Nama")
                TextBox8.Text = RD.Item("Rombel")
            End If
            TextBox6.Text = DataGridView1.Item(6, i).Value
            TextBox3.Text = DataGridView1.Item(7, i).Value
            TextBox4.Text = DataGridView1.Item(8, i).Value
            ComboBox4.Text = DataGridView1.Item(9, i).Value

        End If
        Button5.Enabled = True
        Button6.Enabled = True
        Button4.Enabled = False
        TextBox1.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Maaf Data yang Anda masukan masih kurang lengkap")
        Else
            sqlnya = "UPDATE tb_nilai set NIS='" & TextBox2.Text & "',Nilai='" & TextBox3.Text & "',Keterangan='" & TextBox4.Text & "',Jenis_Ulangan='" & ComboBox1.Text & "',Semester='" & ComboBox2.Text & "',Tahun_Pelajaran='" & ComboBox4.Text & "',Kode_Mapel='" & TextBox6.Text & "',Kode_Nilai='" & TextBox1.Text & "' where Kode_Nilai='" & a & "'"
            Call jalan()
            MsgBox("Data Berhasil Terubah")
            Timer1.Start()
        End If
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sqlnya = "delete from tb_nilai where Kode_Nilai='" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil Terhapus")
        Timer1.Start()
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
        TextBox1.Enabled = False
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If Not IsNumeric(TextBox2.Text) And TextBox2.Text <> "" Then
            MsgBox("NIS tidak bisa diisi Huruf")
            TextBox2.Clear()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click, Button7.Click
        Form11.Show()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form12.Show()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If Val(TextBox3.Text) >= 90 Then
            TextBox4.Text = "Lulus"
        ElseIf Val(TextBox3.Text) >= 80 Then
            TextBox4.Text = "Lulus"
        ElseIf Val(TextBox3.Text) >= 75 Then
            TextBox4.Text = "Lulus"
        ElseIf Val(TextBox3.Text) >= 70 Then
            TextBox4.Text = "Tidak lulus"
        ElseIf Val(TextBox3.Text) >= 60 Then
            TextBox4.Text = "Tidak lulus"
        Else
            TextBox4.Text = "Tidak lulus"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call panggildata()
        Timer1.Stop()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM qw_nilai where Kode_Nilai like '%" & TextBox5.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "qw_nilai")
        DataGridView1.DataSource = DS.Tables("qw_nilai")
    End Sub
End Class