<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.HWindowControl1 = New HalconDotNet.HWindowControl()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(708, 153)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 51)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "读取图片"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(708, 82)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(120, 21)
        Me.TextBox1.TabIndex = 2
        '
        'HWindowControl1
        '
        Me.HWindowControl1.AutoSize = True
        Me.HWindowControl1.BackColor = System.Drawing.Color.Black
        Me.HWindowControl1.BorderColor = System.Drawing.Color.Black
        Me.HWindowControl1.ImagePart = New System.Drawing.Rectangle(0, 0, 600, 600)
        Me.HWindowControl1.Location = New System.Drawing.Point(24, 21)
        Me.HWindowControl1.Name = "HWindowControl1"
        Me.HWindowControl1.Size = New System.Drawing.Size(600, 600)
        Me.HWindowControl1.TabIndex = 3
        Me.HWindowControl1.WindowSize = New System.Drawing.Size(600, 600)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(708, 237)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(152, 51)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "处理图片"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(708, 342)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(152, 51)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "相机初始化"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(708, 459)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(152, 51)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "采集显示"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(708, 550)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(152, 51)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "关闭相机"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 761)
        Me.Controls.Add(Me.HWindowControl1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents HWindowControl1 As HalconDotNet.HWindowControl
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button5 As System.Windows.Forms.Button

End Class
