' 游戏主机类
' 控制游戏的进程
Public Class GameConsole
    Private _gameForm As GameForm  ' 游戏主窗体
    Private _snake As Snake  ' 贪吃蛇
    Private _apple As Apple  ' 苹果
    Private _eraseBlock As Block = New Block()  ' 用于清除的方块
    Private _direction As Integer  ' 当前移动方向

    ' 每次移动的偏移距离(19个像素点)
    Public Shared ReadOnly Delta As Integer = 19

    ' 方向：上
    Public Shared ReadOnly Direction_Up = 1

    ' 方向：下
    Public Shared ReadOnly Direction_Down = 2

    ' 方向：左
    Public Shared ReadOnly Direction_Left = 3

    ' 方向：右
    Public Shared ReadOnly Direction_Right = 4

    ' 可以放置方块的定位像素集合
    Public Shared BlockPointList As ArrayList = InitBlockList()

    ' 随机数生成器，用于生成新的苹果对象
    Public Shared PointRandom As Random = New Random()

    ' 初始化可以放置方块的定位像素集合
    Shared Function InitBlockList() As ArrayList
        Dim list As ArrayList = New ArrayList()
        For x As Integer = 0 To 18
            For y As Integer = 0 To 18
                list.Add(New Point(10 + x * Delta, 10 + y * Delta))
            Next
        Next
        Return list
    End Function

    ' 生成一条贪吃蛇
    Public Sub CreateSnake()
        Dim head As Point = New Point(10 + 19 * 2, 10)
        Dim body As ArrayList = New ArrayList()
        body.Add(New Point(10 + 19, 10))
        body.Add(New Point(10, 10))

        Snake = New Snake(head, body)
    End Sub

    ' 贪吃蛇前行
    Public Sub Move(vectorX As Integer, vectorY As Integer)

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
        ' 蛇头移动一个方块的距离
        Snake.Head.LocatingPoint = New Point(Snake.Head.LocatingPoint.X + vectorX, Snake.Head.LocatingPoint.Y + vectorY)

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
        Dim pointIndex As Integer
        Do
            pointIndex = PointRandom.Next(0, 19 * 19 - 1)
        Loop Until Setable(pointIndex)

        Apple = New Apple(BlockPointList(pointIndex))
    End Sub

    ' 判断像素位置是否可以放置苹果
    Public Function Setable(index As Integer) As Boolean
        Dim targetPoint As Point = BlockPointList(index)
        If IsCoiside(targetPoint, Snake.Head.LocatingPoint) Then  ' 目标像素点与蛇头重合
            Return False
        End If
        For Each block In Snake.Body  ' 目标像素点与蛇身的某一处重合
            If IsCoiside(targetPoint, block.LocatingPoint) Then
                Return False
            End If
        Next
        Return True  ' 目标像素点不与贪吃蛇重合
    End Function

    ' 判断两个像素点的位置是否重合
    Public Function IsCoiside(pointA As Point, pointB As Point) As Boolean
        Return pointA.X = pointB.X AndAlso pointA.Y = pointB.Y
    End Function

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

    Public Property Direction As Integer
        Get
            Return _direction
        End Get
        Set(value As Integer)
            _direction = value
        End Set
    End Property
End Class
