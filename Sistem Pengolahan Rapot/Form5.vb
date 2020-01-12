Public Class Form5
    Dim gam As String
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ko As String
        ko = MsgBox("Apakah Anda yakin?", vbYesNo, "Sistem Lab Say")
        If ko = vbYes Then
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            Button4.Enabled = True
            Button5.Enabled = False
            Button6.Enabled = False
            TextBox1.Enabled = True
        Else
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form6.Show()
        Hide()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If IsNumeric(TextBox2.Text) And TextBox2.Text <> "" Then
            MsgBox("Pembimbing harus diisi dengan huruf")
            TextBox2.Clear()
        End If
    End Sub

    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_rayon", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_rayon")
        DataGridView1.DataSource = DS.Tables("tb_rayon")
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
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Maaf Data yang Anda masukan masih kurang lengkap")
        Else
            sqlnya = "insert into tb_rayon(`Kode_Rayon`,`Rayon`,`Pembimbing`) values('" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox2.Text & "')"
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
            Button4.Visible = True
            TextBox1.Text = DataGridView1.Item(0, i).Value
            TextBox3.Text = DataGridView1.Item(1, i).Value
            TextBox2.Text = DataGridView1.Item(2, i).Value
        End If
        Button5.Enabled = True
        Button6.Enabled = True
        Button4.Enabled = False
        TextBox1.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Maaf Data yang Anda masukan masih kurang lengkap")
        Else
            sqlnya = "UPDATE tb_rayon set Pembimbing='" & TextBox2.Text & "',Rayon='" & TextBox3.Text & "' where Kode_Rayon='" & TextBox1.Text & "'"
            Call jalan()
            MsgBox("Data Berhasil Terubah")
            Timer1.Start()
        End If
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sqlnya = "delete from tb_rayon where Kode_Rayon='" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil Terhapus")
        Timer1.Start()
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
        TextBox1.Enabled = True
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_rayon where Pembimbing like '%" & TextBox6.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_rayon")
        DataGridView1.DataSource = DS.Tables("tb_rayon")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call panggildata()
        Timer1.Stop()
    End Sub
End Class