<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PN_GamePad = New System.Windows.Forms.Panel()
        Me.GB_Items = New System.Windows.Forms.GroupBox()
        Me.BTN_Stop = New System.Windows.Forms.Button()
        Me.BTN_Pause = New System.Windows.Forms.Button()
        Me.BTN_Start = New System.Windows.Forms.Button()
        Me.GB_Operate = New System.Windows.Forms.GroupBox()
        Me.BTN_Right = New System.Windows.Forms.Button()
        Me.BTN_Left = New System.Windows.Forms.Button()
        Me.BTN_Down = New System.Windows.Forms.Button()
        Me.BTN_Up = New System.Windows.Forms.Button()
        Me.GB_Items.SuspendLayout()
        Me.GB_Operate.SuspendLayout()
        Me.SuspendLayout()
        '
        'PN_GamePad
        '
        Me.PN_GamePad.BackColor = System.Drawing.Color.LightGray
        Me.PN_GamePad.Location = New System.Drawing.Point(0, 0)
        Me.PN_GamePad.Name = "PN_GamePad"
        Me.PN_GamePad.Size = New System.Drawing.Size(361, 361)
        Me.PN_GamePad.TabIndex = 0
        '
        'GB_Items
        '
        Me.GB_Items.Controls.Add(Me.BTN_Stop)
        Me.GB_Items.Controls.Add(Me.BTN_Pause)
        Me.GB_Items.Controls.Add(Me.BTN_Start)
        Me.GB_Items.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GB_Items.Location = New System.Drawing.Point(372, 12)
        Me.GB_Items.Name = "GB_Items"
        Me.GB_Items.Size = New System.Drawing.Size(200, 150)
        Me.GB_Items.TabIndex = 1
        Me.GB_Items.TabStop = False
        Me.GB_Items.Text = "选项"
        '
        'BTN_Stop
        '
        Me.BTN_Stop.Location = New System.Drawing.Point(64, 107)
        Me.BTN_Stop.Name = "BTN_Stop"
        Me.BTN_Stop.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Stop.TabIndex = 2
        Me.BTN_Stop.Text = "结束"
        Me.BTN_Stop.UseVisualStyleBackColor = True
        '
        'BTN_Pause
        '
        Me.BTN_Pause.Location = New System.Drawing.Point(63, 64)
        Me.BTN_Pause.Name = "BTN_Pause"
        Me.BTN_Pause.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Pause.TabIndex = 1
        Me.BTN_Pause.Text = "暂停"
        Me.BTN_Pause.UseVisualStyleBackColor = True
        '
        'BTN_Start
        '
        Me.BTN_Start.Location = New System.Drawing.Point(64, 21)
        Me.BTN_Start.Name = "BTN_Start"
        Me.BTN_Start.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Start.TabIndex = 0
        Me.BTN_Start.Text = "开始"
        Me.BTN_Start.UseVisualStyleBackColor = True
        '
        'GB_Operate
        '
        Me.GB_Operate.Controls.Add(Me.BTN_Right)
        Me.GB_Operate.Controls.Add(Me.BTN_Left)
        Me.GB_Operate.Controls.Add(Me.BTN_Down)
        Me.GB_Operate.Controls.Add(Me.BTN_Up)
        Me.GB_Operate.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GB_Operate.Location = New System.Drawing.Point(372, 199)
        Me.GB_Operate.Name = "GB_Operate"
        Me.GB_Operate.Size = New System.Drawing.Size(200, 150)
        Me.GB_Operate.TabIndex = 2
        Me.GB_Operate.TabStop = False
        Me.GB_Operate.Text = "操作"
        '
        'BTN_Right
        '
        Me.BTN_Right.Location = New System.Drawing.Point(119, 65)
        Me.BTN_Right.Name = "BTN_Right"
        Me.BTN_Right.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Right.TabIndex = 3
        Me.BTN_Right.Text = "Right"
        Me.BTN_Right.UseVisualStyleBackColor = True
        '
        'BTN_Left
        '
        Me.BTN_Left.Location = New System.Drawing.Point(6, 65)
        Me.BTN_Left.Name = "BTN_Left"
        Me.BTN_Left.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Left.TabIndex = 2
        Me.BTN_Left.Text = "Left"
        Me.BTN_Left.UseVisualStyleBackColor = True
        '
        'BTN_Down
        '
        Me.BTN_Down.Location = New System.Drawing.Point(64, 94)
        Me.BTN_Down.Name = "BTN_Down"
        Me.BTN_Down.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Down.TabIndex = 1
        Me.BTN_Down.Text = "Down"
        Me.BTN_Down.UseVisualStyleBackColor = True
        '
        'BTN_Up
        '
        Me.BTN_Up.Location = New System.Drawing.Point(64, 36)
        Me.BTN_Up.Name = "BTN_Up"
        Me.BTN_Up.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Up.TabIndex = 0
        Me.BTN_Up.Text = "Up"
        Me.BTN_Up.UseVisualStyleBackColor = True
        '
        'GameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.GB_Operate)
        Me.Controls.Add(Me.GB_Items)
        Me.Controls.Add(Me.PN_GamePad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "GameForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "贪吃蛇"
        Me.GB_Items.ResumeLayout(False)
        Me.GB_Operate.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PN_GamePad As Panel
    Friend WithEvents GB_Items As GroupBox
    Friend WithEvents GB_Operate As GroupBox
    Friend WithEvents BTN_Start As Button
    Friend WithEvents BTN_Stop As Button
    Friend WithEvents BTN_Pause As Button
    Friend WithEvents BTN_Up As Button
    Friend WithEvents BTN_Down As Button
    Friend WithEvents BTN_Right As Button
    Friend WithEvents BTN_Left As Button
End Class
