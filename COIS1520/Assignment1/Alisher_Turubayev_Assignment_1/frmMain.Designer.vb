<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDefault = New System.Windows.Forms.Button()
        Me.btnRed = New System.Windows.Forms.Button()
        Me.btnBlue = New System.Windows.Forms.Button()
        Me.lblMain = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.txtChange = New System.Windows.Forms.TextBox()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.lblDefault = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(197, 308)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDefault
        '
        Me.btnDefault.Location = New System.Drawing.Point(12, 261)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.Size = New System.Drawing.Size(75, 23)
        Me.btnDefault.TabIndex = 1
        Me.btnDefault.Text = "&Default"
        Me.btnDefault.UseVisualStyleBackColor = True
        '
        'btnRed
        '
        Me.btnRed.Location = New System.Drawing.Point(12, 54)
        Me.btnRed.Name = "btnRed"
        Me.btnRed.Size = New System.Drawing.Size(75, 23)
        Me.btnRed.TabIndex = 2
        Me.btnRed.Text = "&Red"
        Me.btnRed.UseVisualStyleBackColor = True
        '
        'btnBlue
        '
        Me.btnBlue.Location = New System.Drawing.Point(94, 54)
        Me.btnBlue.Name = "btnBlue"
        Me.btnBlue.Size = New System.Drawing.Size(75, 23)
        Me.btnBlue.TabIndex = 3
        Me.btnBlue.Text = "&Blue"
        Me.btnBlue.UseVisualStyleBackColor = True
        '
        'lblMain
        '
        Me.lblMain.Location = New System.Drawing.Point(9, 9)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(263, 42)
        Me.lblMain.TabIndex = 4
        Me.lblMain.Text = "Hello! This is a Very Small Program. These two buttons below change color of the " &
    "program to red or blue. Try them out! "
        '
        'lblChange
        '
        Me.lblChange.Location = New System.Drawing.Point(9, 89)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(263, 53)
        Me.lblChange.TabIndex = 5
        Me.lblChange.Text = "This text will change to whatever you write in the text box below if you press th" &
    "e button. Try it!"
        '
        'txtChange
        '
        Me.txtChange.Location = New System.Drawing.Point(12, 145)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(100, 20)
        Me.txtChange.TabIndex = 6
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(12, 171)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(75, 23)
        Me.btnChange.TabIndex = 7
        Me.btnChange.Text = "&Change text"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'lblDefault
        '
        Me.lblDefault.AutoSize = True
        Me.lblDefault.Location = New System.Drawing.Point(12, 245)
        Me.lblDefault.Name = "lblDefault"
        Me.lblDefault.Size = New System.Drawing.Size(195, 13)
        Me.lblDefault.TabIndex = 9
        Me.lblDefault.Text = "This button changes the color to default"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 343)
        Me.Controls.Add(Me.lblDefault)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.txtChange)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.lblMain)
        Me.Controls.Add(Me.btnBlue)
        Me.Controls.Add(Me.btnRed)
        Me.Controls.Add(Me.btnDefault)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "Main"
        Me.Text = "Very Small Program"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnDefault As Button
    Friend WithEvents btnRed As Button
    Friend WithEvents btnBlue As Button
    Friend WithEvents lblMain As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents txtChange As TextBox
    Friend WithEvents btnChange As Button
    Friend WithEvents lblDefault As Label
End Class
