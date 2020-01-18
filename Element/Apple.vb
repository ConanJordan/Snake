' 贪吃蛇游戏【苹果】类
Public Class Apple
    Private _location As Point  ' 苹果的定位像素
    Private _body As Block  ' 苹果

    Public Sub New(location As Point, body As Block)
        _location = location
        _body = body
    End Sub

    Public Property Location As Point
        Get
            Return _location
        End Get
        Set(value As Point)
            _location = value
        End Set
    End Property

    Public Property Body As Block
        Get
            Return _body
        End Get
        Set(value As Block)
            _body = value
        End Set
    End Property
End Class
