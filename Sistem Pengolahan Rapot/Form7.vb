Public Class Form7
    Dim gam As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ko As String
        ko = MsgBox("Apakah Anda yakin?", vbYesNo, "Sistem Lab Say")
        If ko = vbYes Then
            Call kodeauto()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            Button4.Enabled = True
            Button5.Enabled = False
            Button6.Enabled = False
            TextBox1.Enabled = True
        Else
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form8.Show()
        Hide()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
        Call kodeauto()
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub
    Sub kodeauto()
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        TextBox1.Enabled = False
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_admin", conn)
        CMD = New OleDb.OleDbCommand("SELECT * FROM tb_admin order by Kode_Admin desc", conn)
        RD = CMD.ExecuteReader
        If RD.Read Then
            strSementara = Mid(RD.Item("Kode_Admin").ToString, 4, 3)
            strIsi = Val(strSementara) + 1
            TextBox1.Text = "a00" + Mid("0", 1, 2 + strIsi.Length) & strIsi
        Else
            TextBox1.Text = "a0001"
        End If
        TextBox2.Focus()
    End Sub

    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_admin", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_admin")
        DataGridView1.DataSource = DS.Tables("tb_admin")
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
        Call kodeauto()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Maaf Data yang Anda masukan masih kurang lengkap")
        Else
            sqlnya = "insert into tb_admin(`Kode_Admin`,`Nama`,`Username`,`Pass`) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
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
            TextBox2.Text = DataGridView1.Item(1, i).Value
            TextBox3.Text = DataGridView1.Item(2, i).Value
            TextBox4.Text = DataGridView1.Item(3, i).Value
        End If
        Button5.Enabled = True
        Button6.Enabled = True
        Button4.Enabled = False
        TextBox1.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Maaf Data yang Anda masukan masih kurang lengkap")
        Else
            sqlnya = "UPDATE tb_admin set Nama='" & TextBox2.Text & "',Username='" & TextBox3.Text & "',Pass='" & TextBox4.Text & "' where Kode_Admin='" & TextBox1.Text & "'"
            Call jalan()
            MsgBox("Data Berhasil Terubah")
            Timer1.Start()
        End If
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sqlnya = "delete from tb_admin where Kode_Admin='" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil Terhapus")
        Timer1.Start()
        Call kodeauto()
        Button4.Enabled = True
        Button5.Enabled = False
        Button6.Enabled = False
        TextBox1.Enabled = False
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_admin where Nama like '%" & TextBox5.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_admin")
        DataGridView1.DataSource = DS.Tables("tb_admin")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call panggildata()
        Timer1.Stop()
    End Sub
End Class