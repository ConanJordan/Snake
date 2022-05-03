Public Class GameForm

    Private console As GameConsole = New GameConsole(Me)  ' 游戏主机

    Private graphics As Graphics  ' 画板

    Private brush As SolidBrush = New SolidBrush(Block.Color_GamePad)  ' 画刷

    Shared Interval As Integer  ' 计时间隔

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
        console.Score = 0  ' 得分清零
        console.CreateSnake()  ' 生成贪吃蛇
        console.CreateApple()  ' 生成苹果
        console.Direction = GameConsole.Direction_Right  ' 初始方向朝右
        console.GameStatus = GameConsole.Status_Running
        SetInterval()  ' 设置计时器的计时间隔
        TI_Game.Enabled = True  ' 计时器开始计时

        PN_GamePad.Focus()

        BTN_Start.Enabled = False
        BTN_Pause.Enabled = True
        BTN_Stop.Enabled = True

        MI_Game.Enabled = False
    End Sub

    ' 设置计时间隔
    Private Sub SetInterval()
        If MI_Diff_Rookie.Checked Then  ' 菜鸟
            TI_Game.Interval = 500
        End If
        If MI_Diff_Junior.Checked Then  ' 新手
            TI_Game.Interval = 400
        End If
        If MI_Diff_Normal.Checked Then  ' 一般
            TI_Game.Interval = 300
        End If
        If MI_Diff_Veteran.Checked Then  ' 高手
            TI_Game.Interval = 200
        End If
        If MI_Diff_Master.Checked Then  ' 大师
            TI_Game.Interval = 100
        End If
    End Sub

    ' Right
    Private Sub BTN_Right_Click(sender As Object, e As EventArgs) Handles BTN_Right.Click
        If console.DirectionChangable = False OrElse console.Direction = GameConsole.Direction_Left Then  ' 当前方向朝左时不可调整方向
            Exit Sub
        End If
        console.DirectionChangable = False  ' 不可调整方向
        console.Direction = GameConsole.Direction_Right  ' 调整方向
    End Sub

    ' Left
    Private Sub BTN_Left_Click(sender As Object, e As EventArgs) Handles BTN_Left.Click
        If console.DirectionChangable = False OrElse console.Direction = GameConsole.Direction_Right Then  ' 当前方向朝右时不可调整方向
            Exit Sub
        End If
        console.DirectionChangable = False  ' 不可调整方向
        console.Direction = GameConsole.Direction_Left  ' 调整方向
    End Sub

    ' Up
    Private Sub BTN_Up_Click(sender As Object, e As EventArgs) Handles BTN_Up.Click
        If console.DirectionChangable = False OrElse console.Direction = GameConsole.Direction_Down Then  ' 当前方向朝下时不可调整方向
            Exit Sub
        End If
        console.DirectionChangable = False  ' 不可调整方向
        console.Direction = GameConsole.Direction_Up  ' 调整方向
    End Sub

    ' Down
    Private Sub BTN_Down_Click(sender As Object, e As EventArgs) Handles BTN_Down.Click
        If console.DirectionChangable = False OrElse console.Direction = GameConsole.Direction_Up Then  ' 当前方向朝上时不可调整方向
            Exit Sub
        End If
        console.DirectionChangable = False  ' 不可调整方向
        console.Direction = GameConsole.Direction_Down  ' 调整方向
    End Sub

    ' 结束
    Private Sub BTN_Stop_Click(sender As Object, e As EventArgs) Handles BTN_Stop.Click
        TI_Game.Enabled = False
        BTN_Pause.Text = "Pause"
        BTN_Start.Enabled = True
        BTN_Pause.Enabled = False
        BTN_Stop.Enabled = False
        MI_Game.Enabled = True
        LB_Score.Text = 0

        ' 清空游戏主面板
        ClearGamePad()
    End Sub

    Private Sub ClearGamePad()
        graphics = PN_GamePad.CreateGraphics
        Dim rec As Rectangle = New Rectangle(0, 0, 19 * 19, 19 * 19)
        graphics.FillRectangle(brush, rec)
    End Sub

    ' 计时器
    Private Sub TI_Game_Tick(sender As Object, e As EventArgs) Handles TI_Game.Tick
        If console.Snake.Body.Count = GameConsole.Delta * GameConsole.Delta - 4 Then  ' 蛇身的方块数达到上限，游戏胜利。
            MessageBox.Show("You Win!")
        End If
        Select Case console.Direction  ' 判断贪吃蛇当前移动的方向
            Case GameConsole.Direction_Up  ' 上
                console.Move(0, -GameConsole.Delta)
            Case GameConsole.Direction_Down  ' 下
                console.Move(0, GameConsole.Delta)
            Case GameConsole.Direction_Left  ' 左
                console.Move(-GameConsole.Delta, 0)
            Case GameConsole.Direction_Right  ' 右
                console.Move(GameConsole.Delta, 0)
        End Select
        console.DirectionChangable = True  ' 可调整方向
        LB_Score.Text = console.Score  ' 显示最新得分
    End Sub

    ' 暂停(继续)
    Private Sub BTN_Pause_Click(sender As Object, e As EventArgs) Handles BTN_Pause.Click
        TI_Game.Enabled = Not TI_Game.Enabled
        If TI_Game.Enabled Then
            BTN_Pause.Text = "Pause"
            PN_GamePad.Focus() '游戏面板获取焦点
        Else
            BTN_Pause.Text = "Continue"
        End If
    End Sub

    ' 关于贪吃蛇
    Private Sub MI_AboutSnake_Click(sender As Object, e As EventArgs) Handles MI_AboutSnake.Click
        MessageBox.Show("A classic snake game." & vbCrLf & "@Author Conan Jordan", "Snake")
    End Sub

    ' 菜鸟
    Private Sub MI_Diff_Rookie_Click(sender As Object, e As EventArgs) Handles MI_Diff_Rookie.Click
        MI_Diff_Rookie.Checked = True
        MI_Diff_Junior.Checked = False
        MI_Diff_Normal.Checked = False
        MI_Diff_Veteran.Checked = False
        MI_Diff_Master.Checked = False
    End Sub

    ' 新手
    Private Sub MI_Diff_Junior_Click(sender As Object, e As EventArgs) Handles MI_Diff_Junior.Click
        MI_Diff_Rookie.Checked = False
        MI_Diff_Junior.Checked = True
        MI_Diff_Normal.Checked = False
        MI_Diff_Veteran.Checked = False
        MI_Diff_Master.Checked = False
    End Sub

    ' 一般
    Private Sub MI_Diff_Normal_Click(sender As Object, e As EventArgs) Handles MI_Diff_Normal.Click
        MI_Diff_Rookie.Checked = False
        MI_Diff_Junior.Checked = False
        MI_Diff_Normal.Checked = True
        MI_Diff_Veteran.Checked = False
        MI_Diff_Master.Checked = False
    End Sub

    ' 高手
    Private Sub MI_Diff_Veteran_Click(sender As Object, e As EventArgs) Handles MI_Diff_Veteran.Click
        MI_Diff_Rookie.Checked = False
        MI_Diff_Junior.Checked = False
        MI_Diff_Normal.Checked = False
        MI_Diff_Veteran.Checked = True
        MI_Diff_Master.Checked = False
    End Sub

    Private Sub MI_Diff_Master_Click(sender As Object, e As EventArgs) Handles MI_Diff_Master.Click
        MI_Diff_Rookie.Checked = False
        MI_Diff_Junior.Checked = False
        MI_Diff_Normal.Checked = False
        MI_Diff_Veteran.Checked = False
        MI_Diff_Master.Checked = True
    End Sub

    Private Sub GB_Items_Enter(sender As Object, e As EventArgs) Handles GB_Items.Enter

    End Sub
End Class
