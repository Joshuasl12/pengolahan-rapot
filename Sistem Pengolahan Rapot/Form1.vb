Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Me.WindowState = FormWindowState.Maximized
        Label3.Hide()
        ProgressBar1.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        ProgressBar1.Maximum = (101)
        ProgressBar1.Minimum = 0
        Label3.Text = ProgressBar1.Value & "&" & "%"
        If ProgressBar1.Value = 101 Then
            Timer1.Stop()
            LoginForm1.Show()
            Hide()
        End If
    End Sub
End Class
