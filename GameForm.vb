Public Class GameForm

    Private console As GameConsole = New GameConsole(Me)
    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' 监听键盘的按键按下事件
    ' 四个方向键
    Private Sub KeyPressDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Up  'Up
                BTN_Up_Click(sender, e)
            Case Keys.Down  ' Down
                BTN_Down_Click(sender, e)
            Case Keys.Left  ' Left
                BTN_Left_Click(sender, e)
            Case Keys.Right  ' Right
                BTN_Right_Click(sender, e)
        End Select
    End Sub

    ' 开始
    Private Sub BTN_Start_Click(sender As Object, e As EventArgs) Handles BTN_Start.Click
        Block.InitGraphics(PN_GamePad.CreateGraphics)
        console.CreateSnake()
        console.CreateApple()
        console.Direction = GameConsole.Direction_Right  ' 初始方向朝右
        TI_Game.Enabled = True
    End Sub

    ' Right
    Private Sub BTN_Right_Click(sender As Object, e As EventArgs) Handles BTN_Right.Click
        LB_Score.Text = "Right"
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

    ' 计时器
    Private Sub TI_Game_Tick(sender As Object, e As EventArgs) Handles TI_Game.Tick

    End Sub
End Class
