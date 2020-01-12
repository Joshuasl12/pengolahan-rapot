Public Class Form13
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call panggildata()
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
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tb_rayon where Kode_Rayon like '%" & TextBox1.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tb_rayon")
        DataGridView1.DataSource = DS.Tables("tb_rayon")
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If DataGridView1.CurrentRow.Index = DataGridView1.NewRowIndex Then
            MsgBox("Data Tidak Ada")
        Else
            Form4.TextBox7.Text = Me.DataGridView1.Item(0, i).Value
            Hide()
            Form4.Show()
        End If
    End Sub
End Class