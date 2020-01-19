Public Class GameForm

    Private console As GameConsole = New GameConsole(Me)
    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BTN_Start_Click(sender As Object, e As EventArgs) Handles BTN_Start.Click
        'Block.InitGraphics(PN_GamePad.CreateGraphics)
        'console.CreateApple()
        Dim graphics As Graphics = PN_GamePad.CreateGraphics
        Dim pen As Pen = New Pen(Color.Red, 0)
        Dim rec As Rectangle = New Rectangle(0, 0, 1, 1)
        graphics.DrawRectangle(pen, rec)
        'graphics.DrawEllipse(pen, 0, 1, 1, 1)
        pen.Color = Color.LightGray
        'graphics.DrawEllipse(pen, 0, 2, 1, 1)
        rec.X = 1
        graphics.DrawRectangle(pen, rec)
        rec.X = 0
        rec.Y = 1
        graphics.DrawRectangle(pen, rec)
    End Sub
End Class
