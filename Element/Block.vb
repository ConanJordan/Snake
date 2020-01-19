' 游戏的方块类
' 包括：（蛇头：一个方块，蛇身：若干个方块，苹果：一个方块。)
' 每个方块是一个近似19 * 19的正方形，具体式样见【像素设计.xlsx】
Public Class Block
    Private _locatingPoint As Point  ' 定位点(在方块的中心)
    Private _bodyPoints As New ArrayList()  ' 方块体的点集合
    Private _color As Color  ' 方块颜色
    Public Shared graphics As Graphics  ' 画板
    Private _brush As SolidBrush  ' 画刷
    Private _rec As Rectangle  ' 用于绘制的矩形(一个点)

    ' 蛇头：橘红
    Public Shared ReadOnly Color_SnakeHead As Color = Color.OrangeRed
    ' 蛇身：天空蓝
    Public Shared ReadOnly Color_SnakeBody As Color = Color.SkyBlue
    ' 苹果：绿色
    Public Shared ReadOnly Color_Apple As Color = Color.LawnGreen
    ' 游戏背景板：浅灰
    Public Shared ReadOnly Color_GamePad As Color = Color.LightGray

    ' 构造函数
    Public Sub New(locatingPoint As Point, color As Color)
        _locatingPoint = locatingPoint
        Me.Color = color
        CreateBody()  ' 生成方块体
        DrawSelf()  ' 绘制本方块
    End Sub

    ' 绘制本方块
    Public Sub DrawSelf()
        Brush = New SolidBrush(Color)  ' 画刷上色
        DrawPoint(LocatingPoint)  ' 绘制定位像素
        ' 绘制方块体
        For Each point In BodyPoints
            DrawPoint(point)
        Next
    End Sub

    Public Sub DrawPoint(point As Point)
        Rec = New Rectangle(point.X, point.Y, 1, 1)
        graphics.FillRectangle(Brush, Rec)
    End Sub

    ' 生成方块体
    Private Sub CreateBody()
        BodyPoints.Clear()  ' 清空方块体的点集合
        For locationX As Integer = LocatingPoint.X - 9 To LocatingPoint.X + 9  ' 横坐标范围
            For locationY As Integer = LocatingPoint.Y - 9 To LocatingPoint.Y + 9  ' 纵坐标范围
                If Math.Abs(locationX - LocatingPoint.X) = 9 AndAlso Math.Abs(locationY - LocatingPoint.Y) >= 7 Then  ' 不在方块内
                    Continue For
                End If
                If Math.Abs(locationX - LocatingPoint.X) = 8 AndAlso Math.Abs(locationY - LocatingPoint.Y) >= 8 Then  ' 不在方块内
                    Continue For
                End If
                If Math.Abs(locationX - LocatingPoint.X) = 7 AndAlso Math.Abs(locationY - LocatingPoint.Y) >= 9 Then  ' 不在方块内
                    Continue For
                End If

                Dim point As Point = New Point(locationX, locationY)  ' 新建像素点
                BodyPoints.Add(point)  ' 放入方块体
            Next
        Next
    End Sub

    ' 初始化用于绘制的对象
    Public Shared Sub InitGraphics(_graphics As Graphics)
        graphics = _graphics
    End Sub

    Public Property LocatingPoint As Point
        Get
            Return _locatingPoint
        End Get
        Set(value As Point)
            _locatingPoint = value
        End Set
    End Property

    Public Property BodyPoints As ArrayList
        Get
            Return _bodyPoints
        End Get
        Set(value As ArrayList)
            _bodyPoints = value
        End Set
    End Property

    Public Property Color As Color
        Get
            Return _color
        End Get
        Set(value As Color)
            _color = value
        End Set
    End Property

    Public Property Brush As SolidBrush
        Get
            Return _brush
        End Get
        Set(value As SolidBrush)
            _brush = value
        End Set
    End Property

    Public Property Rec As Rectangle
        Get
            Return _rec
        End Get
        Set(value As Rectangle)
            _rec = value
        End Set
    End Property
End Class
