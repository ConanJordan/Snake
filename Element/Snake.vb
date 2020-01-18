' 游戏中的【蛇】类
Public Class Snake
    Private _headLocation As Point  ' 蛇头定位像素
    Private _bodyLocation As New ArrayList()  ' 蛇身定位像素
    Private _head As Block  ' 蛇头
    Private _body As New ArrayList()  ' 蛇身

    ' 构造函数
    Public Sub New(headLocation As Point, bodyLocation As ArrayList)
        Me.HeadLocation = headLocation  ' 蛇头定位像素
        Me.BodyLocation = bodyLocation  ' 蛇身定位像素
        Me.Head = New Block(Me._headLocation, Block.Color_SnakeHead)  ' 蛇头
        For Each bodyPoint In Me._bodyLocation
            Me.Body.Add(New Block(bodyPoint, Block.Color_SnakeBody))  ' 蛇身
        Next
    End Sub

    Public Property HeadLocation As Point
        Get
            Return _headLocation
        End Get
        Set(value As Point)
            _headLocation = value
        End Set
    End Property

    Public Property BodyLocation As ArrayList
        Get
            Return _bodyLocation
        End Get
        Set(value As ArrayList)
            _bodyLocation = value
        End Set
    End Property

    Public Property Head As Block
        Get
            Return _head
        End Get
        Set(value As Block)
            _head = value
        End Set
    End Property

    Public Property Body As ArrayList
        Get
            Return _body
        End Get
        Set(value As ArrayList)
            _body = value
        End Set
    End Property
End Class
