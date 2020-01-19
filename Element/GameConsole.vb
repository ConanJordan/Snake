' 游戏主机类
' 控制游戏的进程
Public Class GameConsole
    Private _gameForm As GameForm  ' 游戏主窗体

    ' 生成一条贪吃蛇
    Public Sub CreateSnake()

    End Sub

    ' 生成苹果
    Public Sub CreateApple()
        Dim location As Point = New Point(181, 181)
        Dim apple As Apple = New Apple(location)
    End Sub

    Public Sub New(gameForm As GameForm)
        _gameForm = gameForm
    End Sub

    Public Property GameForm As GameForm
        Get
            Return _gameForm
        End Get
        Set(value As GameForm)
            _gameForm = value
        End Set
    End Property
End Class
