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
        TI_Game.Enabled = True  ' 计时器开始计时

        PN_GamePad.Focus()

        BTN_Start.Enabled = False
        BTN_Pause.Enabled = True
        BTN_Stop.Enabled = True
    End Sub

    ' Right
    Private Sub BTN_Right_Click(sender As Object, e As EventArgs) Handles BTN_Right.Click
        If console.Direction = GameConsole.Direction_Left Then  ' 当前方向朝左时不可调整方向
            Exit Sub
        End If
        console.Direction = GameConsole.Direction_Right  ' 调整方向
    End Sub

    ' Left
    Private Sub BTN_Left_Click(sender As Object, e As EventArgs) Handles BTN_Left.Click
        If console.Direction = GameConsole.Direction_Right Then  ' 当前方向朝右时不可调整方向
            Exit Sub
        End If
        console.Direction = GameConsole.Direction_Left  ' 调整方向
    End Sub

    ' Up
    Private Sub BTN_Up_Click(sender As Object, e As EventArgs) Handles BTN_Up.Click
        If console.Direction = GameConsole.Direction_Down Then  ' 当前方向朝下时不可调整方向
            Exit Sub
        End If
        console.Direction = GameConsole.Direction_Up  ' 调整方向
    End Sub

    ' Down
    Private Sub BTN_Down_Click(sender As Object, e As EventArgs) Handles BTN_Down.Click
        If console.Direction = GameConsole.Direction_Up Then  ' 当前方向朝上时不可调整方向
            Exit Sub
        End If
        console.Direction = GameConsole.Direction_Down  ' 调整方向
    End Sub

    ' 结束
    Private Sub BTN_Stop_Click(sender As Object, e As EventArgs) Handles BTN_Stop.Click
        Application.Exit()
    End Sub

    ' 计时器
    Private Sub TI_Game_Tick(sender As Object, e As EventArgs) Handles TI_Game.Tick
        Select Case console.Direction  ' 判断贪吃蛇当前移动的方向
            Case GameConsole.Direction_Up  ' Up
                console.Move(0, -GameConsole.Delta)
            Case GameConsole.Direction_Down  ' Down
                console.Move(0, GameConsole.Delta)
            Case GameConsole.Direction_Left  ' Left
                console.Move(-GameConsole.Delta, 0)
            Case GameConsole.Direction_Right  ' Right
                console.Move(GameConsole.Delta, 0)
        End Select
    End Sub

    ' 暂停
    Private Sub BTN_Pause_Click(sender As Object, e As EventArgs) Handles BTN_Pause.Click
        TI_Game.Enabled = False  ' 暂停计时器
    End Sub
End Class
