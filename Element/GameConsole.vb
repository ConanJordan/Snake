' 游戏主机类
' 控制游戏的进程
Public Class GameConsole
    Private _gameForm As GameForm  ' 游戏主窗体
    Private _snake As Snake  ' 贪吃蛇
    Private _apple As Apple  ' 苹果
    Private _eraseBlock As Block = New Block()  ' 用于清除的方块

    ' 每次移动的偏移距离(19个像素点)
    Public Shared ReadOnly Delta As Integer = 19

    ' 生成一条贪吃蛇
    Public Sub CreateSnake()
        Dim head As Point = New Point(10 + 19 * 2, 10)
        Dim body As ArrayList = New ArrayList()
        body.Add(New Point(10 + 19, 10))
        body.Add(New Point(10, 10))

        Snake = New Snake(head, body)
    End Sub

    ' 贪吃蛇前行
    Public Sub Move()
        ' 向右前行

        ' 擦除原来的贪吃蛇
        DoErase(Snake.Head.LocatingPoint)
        For Each block In Snake.Body
            DoErase(block.LocatingPoint)
        Next

        ' 蛇身的每个方块向前一个方块移动一个方块的距离
        For index As Integer = Snake.Body.Count - 1 To 0 Step -1
            If index = 0 Then
                Snake.Body(index).LocatingPoint = Snake.Head.LocatingPoint
                Continue For
            End If
            Snake.Body(index).LocatingPoint = Snake.Body(index - 1).LocatingPoint
        Next
        ' 蛇头向右移动一个方块的距离
        Snake.Head.LocatingPoint = New Point(Snake.Head.LocatingPoint.X + Delta, Snake.Head.LocatingPoint.Y)

        ' 绘制新的贪吃蛇
        Snake.Head.CreateBody()
        Snake.Head.DrawSelf()
        For index As Integer = 0 To Snake.Body.Count - 1
            Snake.Body(index).CreateBody()
            Snake.Body(index).DrawSelf()
        Next
    End Sub

    ' 擦除方块
    Public Sub DoErase(point As Point)
        EraseBlock.LocatingPoint = point
        EraseBlock.CreateBody()
        EraseBlock.DrawSelf()
    End Sub

    ' 擦除方块
    Public Sub DoErase(block As Block)
        EraseBlock = block
        EraseBlock.Brush.Color = Block.Color_GamePad
        EraseBlock.DrawSelf()
    End Sub

    ' 生成苹果
    Public Sub CreateApple()
        Dim location As Point = New Point(181, 181)
        Apple = New Apple(location)
    End Sub

    ' 构造函数
    Public Sub New(gameForm As GameForm)
        _gameForm = gameForm
        EraseBlock.Color = Block.Color_GamePad
    End Sub

    Public Property GameForm As GameForm
        Get
            Return _gameForm
        End Get
        Set(value As GameForm)
            _gameForm = value
        End Set
    End Property

    Public Property Snake As Snake
        Get
            Return _snake
        End Get
        Set(value As Snake)
            _snake = value
        End Set
    End Property

    Public Property Apple As Apple
        Get
            Return _apple
        End Get
        Set(value As Apple)
            _apple = value
        End Set
    End Property

    Public Property EraseBlock As Block
        Get
            Return _eraseBlock
        End Get
        Set(value As Block)
            _eraseBlock = value
        End Set
    End Property
End Class
