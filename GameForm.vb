Public Class GameForm

    Private console As GameConsole = New GameConsole(Me)
    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BTN_Start_Click(sender As Object, e As EventArgs) Handles BTN_Start.Click
        Block.InitGraphics(PN_GamePad.CreateGraphics)
        console.CreateApple()
        console.CreateSnake()
    End Sub

    Private Sub GB_Score_Enter(sender As Object, e As EventArgs) Handles GB_Score.Enter

    End Sub
End Class
