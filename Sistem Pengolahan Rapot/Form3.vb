Public Class Form3
    Private Sub Form3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Panel3.Hide()
        Panel4.Hide()
        Panel5.Hide()
        Panel6.Hide()
        Panel7.Hide()
        Label2.Text = LoginForm1.TextBox1.Text
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form4.Show()
        Panel3.Show()
        Panel4.Hide()
        Panel5.Hide()
        Panel6.Hide()
        Panel7.Hide()
        Form4.StartPosition = Form5.StartPosition
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form5.Show()
        Panel3.Hide()
        Panel4.Hide()
        Panel5.Hide()
        Panel6.Show()
        Panel7.Hide()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Hide()
        LoginForm1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form6.Show()
        Panel3.Hide()
        Panel4.Hide()
        Panel5.Show()
        Panel6.Hide()
        Panel7.Hide()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form7.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form8.Show()
        Panel3.Hide()
        Panel4.Show()
        Panel5.Hide()
        Panel6.Hide()
        Panel7.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form9.Show()
        Panel3.Hide()
        Panel4.Hide()
        Panel5.Hide()
        Panel6.Hide()
        Panel7.Show()
    End Sub
    Private Sub Panel9_Click(sender As Object, e As EventArgs) Handles Panel9.Click
        Me.Close()
    End Sub
End Class