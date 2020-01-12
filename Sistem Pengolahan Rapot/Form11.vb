Public Class Form11
    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_siswa where NIS like '%" & TextBox1.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_siswa")
        DataGridView1.DataSource = DS.Tables("tb_siswa")
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Form8.TextBox2.Text = Me.DataGridView1.Item(0, i).Value
        Form8.TextBox7.Text = Me.DataGridView1.Item("Nama", i).Value
        Form8.TextBox8.Text = Me.DataGridView1.Item("Rombel", i).Value
        Hide()
        Form8.Show()
    End Sub
End Class