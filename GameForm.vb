Public Class GameForm

    Private console As GameConsole = New GameConsole(Me)
    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BTN_Start_Click(sender As Object, e As EventArgs) Handles BTN_Start.Click
        Block.InitGraphics(PN_GamePad.CreateGraphics)
        console.CreateSnake()
        console.CreateApple()
    End Sub

    ' Right
    Private Sub BTN_Right_Click(sender As Object, e As EventArgs) Handles BTN_Right.Click

    End Sub

    ' Left
    Private Sub BTN_Left_Click(sender As Object, e As EventArgs) Handles BTN_Left.Click

    End Sub

    ' Up
    Private Sub BTN_Up_Click(sender As Object, e As EventArgs) Handles BTN_Up.Click

    End Sub

    ' Down
    Private Sub BTN_Down_Click(sender As Object, e As EventArgs) Handles BTN_Down.Click

    End Sub

    ' 结束
    Private Sub BTN_Stop_Click(sender As Object, e As EventArgs) Handles BTN_Stop.Click
        Application.Exit()
    End Sub
End Class
