Public Class GameForm

    Private console As GameConsole = New GameConsole(Me)
    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BTN_Start_Click(sender As Object, e As EventArgs) Handles BTN_Start.Click
        Block.InitGraphics(PN_GamePad.CreateGraphics)
        console.CreateApple()
        console.CreateSnake()
    End Sub

    Private Sub BTN_Right_Click(sender As Object, e As EventArgs) Handles BTN_Right.Click
        console.Move()
    End Sub
End Class
