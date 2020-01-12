Public Class Form9
    Dim gam As String
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("UTS")
        ComboBox1.Items.Add("UAS")
        ComboBox3.Items.Add("GENAP")
        ComboBox3.Items.Add("GANJIL")
        Dim tgl As Integer
        For tgl = 2009 To 2099
            If tgl < 2099 Then
                ComboBox2.Items.Add(tgl)
            End If
        Next
        Call panggildata()
        Button1.Enabled = False
    End Sub

    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM qw_cetak", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "qw_cetak")
        DataGridView1.DataSource = DS.Tables("qw_cetak")
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
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If i = -1 Then
            MsgBox("Data Telah Habis")
        Else
            Form10.Label7.Text = DataGridView1.Item(0, i).Value
            Form10.Label8.Text = DataGridView1.Item(1, i).Value
            Form10.Label9.Text = DataGridView1.Item(2, i).Value
            Form10.Label10.Text = DataGridView1.Item(3, i).Value
            Form10.PictureBox2.ImageLocation = DataGridView1.Item(9, i).Value
            Form10.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        End If
        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form10.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM qw_cetak where Jenis_Ulangan like '%" & ComboBox1.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "qw_cetak")
        DataGridView1.DataSource = DS.Tables("qw_cetak")
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM qw_cetak where Tahun_Pelajaran like '%" & ComboBox2.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "qw_cetak")
        DataGridView1.DataSource = DS.Tables("qw_cetak")
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM qw_cetak where Semester like '%" & ComboBox3.Text & "%'", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "qw_cetak")
        DataGridView1.DataSource = DS.Tables("qw_cetak")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class