' 游戏主机类
' 控制游戏的进程
Public Class GameConsole
    Private _gameForm As GameForm  ' 游戏主窗体
    Private _snake As Snake  ' 贪吃蛇
    Private _apple As Apple  ' 苹果
    Private _eraseBlock As Block = New Block()  ' 用于清除的方块
    Private _direction As Integer  ' 当前移动方向
    Private _score As Integer  ' 当前得分
    Private _gameStatus As Integer = Status_OK ' 游戏状态（未开始，进行中，游戏结束）
    Private _directionChangable As Boolean  ' 判断是否可以变换方向。防止方向键按得过快，使蛇头直接掉头向反方向走位了。

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

    ' 游戏状态：未开始
    Public Shared ReadOnly Status_OK As Integer = 1

    ' 游戏状态：进行中
    Public Shared ReadOnly Status_Running As Integer = 2

    ' 游戏状态：游戏结束
    Public Shared ReadOnly Status_Stop As Integer = 3

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
        If IsDead(vectorX, vectorY) Then  ' 贪吃蛇头铁撞墙或咬到自己
            Me.GameStatus = Status_Stop  ' 游戏结束
            Me.GameForm.TI_Game.Enabled = False  ' 计时器停止计时
            MessageBox.Show("Game Over")
            Exit Sub
        End If

        If Eatable(vectorX, vectorY) Then  ' 贪吃蛇可以吃苹果
            EatApple()  ' 贪吃蛇吃苹果
            Exit Sub  ' 结束本方法
        End If

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

    ' 贪吃蛇吃苹果
    Private Sub EatApple()
        ' 擦除原来的贪吃蛇
        DoErase(Snake.Head.LocatingPoint)
        For Each block In Snake.Body
            DoErase(block.LocatingPoint)
        Next

        ' 蛇头放到苹果的位置上
        Snake.Head.LocatingPoint = Apple.Location

        ' 记录下蛇尾的位置，之后在这里新增一个方块
        Dim tailPoint As Point = Snake.Body(Snake.Body.Count - 1).LocatingPoint

        ' 蛇身的每个方块向前一个方块移动一个方块的距离
        For index As Integer = Snake.Body.Count - 1 To 0 Step -1
            If index = 0 Then
                Snake.Body(index).LocatingPoint = Snake.Head.LocatingPoint
                Continue For
            End If
            ' 在蛇尾添加一个方块
            Dim TailBlock As Block = New Block(Block.Color_SnakeBody)
            TailBlock.LocatingPoint = tailPoint
            Snake.Body.Add(TailBlock)
        Next

        ' 绘制新的贪吃蛇
        Snake.Head.CreateBody()
        Snake.Head.DrawSelf()
        For index As Integer = 0 To Snake.Body.Count - 1
            Snake.Body(index).CreateBody()
            Snake.Body(index).DrawSelf()
        Next

        Score = +1  ' 得分加1

        CreateApple()  ' 生成新苹果
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
        If IsCoinside(targetPoint, Snake.Head.LocatingPoint) Then  ' 目标像素点与蛇头重合
            Return False
        End If
        For Each block In Snake.Body  ' 目标像素点与蛇身的某一处重合
            If IsCoinside(targetPoint, block.LocatingPoint) Then
                Return False
            End If
        Next
        Return True  ' 目标像素点不与贪吃蛇重合
    End Function

    ' 判断两个像素点的位置是否重合
    Public Function IsCoinside(pointA As Point, pointB As Point) As Boolean
        Return pointA.X = pointB.X AndAlso pointA.Y = pointB.Y
    End Function

    ' 构造函数
    Public Sub New(gameForm As GameForm)
        _gameForm = gameForm
        EraseBlock.Color = Block.Color_GamePad
        Score = 0
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

    Public Property Score As Integer
        Get
            Return _score
        End Get
        Set(value As Integer)
            _score = value
        End Set
    End Property

    Public Property GameStatus As Integer
        Get
            Return _gameStatus
        End Get
        Set(value As Integer)
            _gameStatus = value
        End Set
    End Property

    Public Property DirectionChangable As Boolean
        Get
            Return _directionChangable
        End Get
        Set(value As Boolean)
            _directionChangable = value
        End Set
    End Property

    ' 判断能否吃到苹果
    Private Function Eatable(vectorX As Integer, vectorY As Integer) As Boolean
        Dim nextPoint = New Point(Snake.Head.LocatingPoint.X + vectorX, Snake.Head.LocatingPoint.Y + vectorY)  ' 蛇头的下一个位置
        Return IsCoinside(nextPoint, Apple.Location)  ' 判断蛇头与苹果是否重合
    End Function

    ' 判断贪吃蛇是否要凉
    Private Function IsDead(vectorX As Integer, vectorY As Integer) As Boolean
        Return IsKnocking(vectorX, vectorY) OrElse IsBitingSelf(vectorX, vectorY)
    End Function

    ' 判断贪吃蛇是否会撞墙
    ' Return Boolean (True:头铁，False:头不铁)
    Private Function IsKnocking(vectorX As Integer, vectorY As Integer) As Boolean
        Dim currentX As Integer = Snake.Head.LocatingPoint.X  ' 当前蛇头的X坐标
        Dim currentY As Integer = Snake.Head.LocatingPoint.Y  ' 当前蛇头的Y坐标

        If currentX + vectorX < 0 Then  ' 蛇头撞西墙(左)
            Return True
        End If
        If currentX + vectorX > 19 * 19 Then  ' 蛇头撞东墙(右)
            Return True
        End If
        If currentY + vectorY < 0 Then  ' 蛇头撞北墙(上)
            Return True
        End If
        If currentY + vectorY > 19 * 19 Then  ' 蛇头撞南墙(下)
            Return True
        End If

        Return False  ' 蛇头不撞墙，很皮
    End Function

    ' 判断贪吃蛇是否会咬到自己
    ' Return Boolean (True:头铁，False:头不铁)
    Private Function IsBitingSelf(vectorX As Integer, vectorY As Integer) As Boolean
        Dim nextHeadPoint = New Point(Snake.Head.LocatingPoint.X + vectorX, Snake.Head.LocatingPoint.Y + vectorY)  ' 蛇头的下一个移动位置
        Dim nextBodyPoint As Point  ' 蛇身的下一个移动位置
        For index As Integer = 1 To Snake.Body.Count - 1  ' 蛇头不会咬到紧跟在后面的蛇身方块，所以循环从蛇身的第二个方块开始
            nextBodyPoint = New Point(Snake.Body(index - 1).LocatingPoint.X, Snake.Body(index - 1).LocatingPoint.Y)
            If IsCoinside(nextHeadPoint, nextBodyPoint) Then
                Return True
            End If
        Next
        Return False
    End Function

End Class
