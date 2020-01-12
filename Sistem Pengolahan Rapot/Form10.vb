Public Class Form10
    Dim gam As String
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

        DataGridView1.RowHeadersVisible = False
        Me.WindowState = FormWindowState.Maximized
        Call panggildata()
        Dim sum As Integer = 0
        Call panggildata()

        For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
            sum = sum + DataGridView1.Rows(i).Cells(1).Value
        Next
        Label12.Text = sum.ToString
        Dim a As Integer = Val(Label12.Text)
        Label14.Text = a / DataGridView1.NewRowIndex

    End Sub

    Dim sqlnya As String
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM qw_rapot", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "qw_rapot")
        DataGridView1.DataSource = DS.Tables("qw_rapot")
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Visible = False
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        PrintForm1.Print()
    End Sub
End Class


