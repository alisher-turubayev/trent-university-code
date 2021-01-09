<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalculator
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
        Me.rdoStandard = New System.Windows.Forms.RadioButton()
        Me.rdoInline = New System.Windows.Forms.RadioButton()
        Me.txtInputOne = New System.Windows.Forms.TextBox()
        Me.txtInputTwo = New System.Windows.Forms.TextBox()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.lblOutput = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblInput = New System.Windows.Forms.Label()
        Me.lblHistory = New System.Windows.Forms.Label()
        Me.btnOne = New System.Windows.Forms.Button()
        Me.btnTwo = New System.Windows.Forms.Button()
        Me.btnThree = New System.Windows.Forms.Button()
        Me.btnFour = New System.Windows.Forms.Button()
        Me.btnFive = New System.Windows.Forms.Button()
        Me.btnSix = New System.Windows.Forms.Button()
        Me.btnSeven = New System.Windows.Forms.Button()
        Me.btnEight = New System.Windows.Forms.Button()
        Me.btnNine = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSubstract = New System.Windows.Forms.Button()
        Me.btnMultiply = New System.Windows.Forms.Button()
        Me.btnDivide = New System.Windows.Forms.Button()
        Me.btnEqual = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnZero = New System.Windows.Forms.Button()
        Me.lbxHistory = New System.Windows.Forms.ListBox()
        Me.txtInline = New System.Windows.Forms.TextBox()
        Me.btnDot = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rdoStandard
        '
        Me.rdoStandard.AutoSize = True
        Me.rdoStandard.Checked = True
        Me.rdoStandard.Location = New System.Drawing.Point(12, 12)
        Me.rdoStandard.Name = "rdoStandard"
        Me.rdoStandard.Size = New System.Drawing.Size(68, 17)
        Me.rdoStandard.TabIndex = 0
        Me.rdoStandard.TabStop = True
        Me.rdoStandard.Text = "&Standard"
        Me.rdoStandard.UseVisualStyleBackColor = True
        '
        'rdoInline
        '
        Me.rdoInline.AutoSize = True
        Me.rdoInline.Location = New System.Drawing.Point(87, 12)
        Me.rdoInline.Name = "rdoInline"
        Me.rdoInline.Size = New System.Drawing.Size(50, 17)
        Me.rdoInline.TabIndex = 1
        Me.rdoInline.Text = "I&nline"
        Me.rdoInline.UseVisualStyleBackColor = True
        '
        'txtInputOne
        '
        Me.txtInputOne.Location = New System.Drawing.Point(12, 60)
        Me.txtInputOne.Name = "txtInputOne"
        Me.txtInputOne.Size = New System.Drawing.Size(125, 20)
        Me.txtInputOne.TabIndex = 2
        '
        'txtInputTwo
        '
        Me.txtInputTwo.Location = New System.Drawing.Point(12, 86)
        Me.txtInputTwo.Name = "txtInputTwo"
        Me.txtInputTwo.Size = New System.Drawing.Size(125, 20)
        Me.txtInputTwo.TabIndex = 3
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(12, 125)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(125, 20)
        Me.txtOutput.TabIndex = 4
        '
        'lblOutput
        '
        Me.lblOutput.AutoSize = True
        Me.lblOutput.Location = New System.Drawing.Point(12, 109)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput.TabIndex = 5
        Me.lblOutput.Text = "Output:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(216, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(44, 23)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.Location = New System.Drawing.Point(12, 44)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(34, 13)
        Me.lblInput.TabIndex = 8
        Me.lblInput.Text = "Input:"
        '
        'lblHistory
        '
        Me.lblHistory.AutoSize = True
        Me.lblHistory.Location = New System.Drawing.Point(140, 44)
        Me.lblHistory.Name = "lblHistory"
        Me.lblHistory.Size = New System.Drawing.Size(42, 13)
        Me.lblHistory.TabIndex = 9
        Me.lblHistory.Text = "History:"
        '
        'btnOne
        '
        Me.btnOne.Location = New System.Drawing.Point(12, 169)
        Me.btnOne.Name = "btnOne"
        Me.btnOne.Size = New System.Drawing.Size(57, 43)
        Me.btnOne.TabIndex = 10
        Me.btnOne.Text = "&1"
        Me.btnOne.UseVisualStyleBackColor = True
        Me.btnOne.Visible = False
        '
        'btnTwo
        '
        Me.btnTwo.Location = New System.Drawing.Point(75, 169)
        Me.btnTwo.Name = "btnTwo"
        Me.btnTwo.Size = New System.Drawing.Size(57, 43)
        Me.btnTwo.TabIndex = 11
        Me.btnTwo.Text = "&2"
        Me.btnTwo.UseVisualStyleBackColor = True
        Me.btnTwo.Visible = False
        '
        'btnThree
        '
        Me.btnThree.Location = New System.Drawing.Point(138, 169)
        Me.btnThree.Name = "btnThree"
        Me.btnThree.Size = New System.Drawing.Size(57, 43)
        Me.btnThree.TabIndex = 12
        Me.btnThree.Text = "&3"
        Me.btnThree.UseVisualStyleBackColor = True
        Me.btnThree.Visible = False
        '
        'btnFour
        '
        Me.btnFour.Location = New System.Drawing.Point(12, 218)
        Me.btnFour.Name = "btnFour"
        Me.btnFour.Size = New System.Drawing.Size(57, 43)
        Me.btnFour.TabIndex = 13
        Me.btnFour.Text = "&4"
        Me.btnFour.UseVisualStyleBackColor = True
        Me.btnFour.Visible = False
        '
        'btnFive
        '
        Me.btnFive.Location = New System.Drawing.Point(75, 218)
        Me.btnFive.Name = "btnFive"
        Me.btnFive.Size = New System.Drawing.Size(57, 43)
        Me.btnFive.TabIndex = 14
        Me.btnFive.Text = "&5"
        Me.btnFive.UseVisualStyleBackColor = True
        Me.btnFive.Visible = False
        '
        'btnSix
        '
        Me.btnSix.Location = New System.Drawing.Point(138, 218)
        Me.btnSix.Name = "btnSix"
        Me.btnSix.Size = New System.Drawing.Size(57, 43)
        Me.btnSix.TabIndex = 15
        Me.btnSix.Text = "&6"
        Me.btnSix.UseVisualStyleBackColor = True
        Me.btnSix.Visible = False
        '
        'btnSeven
        '
        Me.btnSeven.Location = New System.Drawing.Point(12, 267)
        Me.btnSeven.Name = "btnSeven"
        Me.btnSeven.Size = New System.Drawing.Size(57, 43)
        Me.btnSeven.TabIndex = 16
        Me.btnSeven.Text = "&7"
        Me.btnSeven.UseVisualStyleBackColor = True
        Me.btnSeven.Visible = False
        '
        'btnEight
        '
        Me.btnEight.Location = New System.Drawing.Point(75, 267)
        Me.btnEight.Name = "btnEight"
        Me.btnEight.Size = New System.Drawing.Size(57, 43)
        Me.btnEight.TabIndex = 17
        Me.btnEight.Text = "&8"
        Me.btnEight.UseVisualStyleBackColor = True
        Me.btnEight.Visible = False
        '
        'btnNine
        '
        Me.btnNine.Location = New System.Drawing.Point(138, 267)
        Me.btnNine.Name = "btnNine"
        Me.btnNine.Size = New System.Drawing.Size(57, 43)
        Me.btnNine.TabIndex = 18
        Me.btnNine.Text = "&9"
        Me.btnNine.UseVisualStyleBackColor = True
        Me.btnNine.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 169)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(57, 43)
        Me.btnAdd.TabIndex = 19
        Me.btnAdd.Text = "&+"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnSubstract
        '
        Me.btnSubstract.Location = New System.Drawing.Point(75, 169)
        Me.btnSubstract.Name = "btnSubstract"
        Me.btnSubstract.Size = New System.Drawing.Size(57, 43)
        Me.btnSubstract.TabIndex = 20
        Me.btnSubstract.Text = "&-"
        Me.btnSubstract.UseVisualStyleBackColor = True
        '
        'btnMultiply
        '
        Me.btnMultiply.Location = New System.Drawing.Point(138, 169)
        Me.btnMultiply.Name = "btnMultiply"
        Me.btnMultiply.Size = New System.Drawing.Size(57, 43)
        Me.btnMultiply.TabIndex = 21
        Me.btnMultiply.Text = "&*"
        Me.btnMultiply.UseVisualStyleBackColor = True
        '
        'btnDivide
        '
        Me.btnDivide.Location = New System.Drawing.Point(201, 169)
        Me.btnDivide.Name = "btnDivide"
        Me.btnDivide.Size = New System.Drawing.Size(57, 43)
        Me.btnDivide.TabIndex = 22
        Me.btnDivide.Text = "&/"
        Me.btnDivide.UseVisualStyleBackColor = True
        '
        'btnEqual
        '
        Me.btnEqual.Location = New System.Drawing.Point(139, 316)
        Me.btnEqual.Name = "btnEqual"
        Me.btnEqual.Size = New System.Drawing.Size(57, 43)
        Me.btnEqual.TabIndex = 23
        Me.btnEqual.Text = "&="
        Me.btnEqual.UseVisualStyleBackColor = True
        Me.btnEqual.Visible = False
        '
        'btnClearAll
        '
        Me.btnClearAll.Location = New System.Drawing.Point(166, 12)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(44, 23)
        Me.btnClearAll.TabIndex = 24
        Me.btnClearAll.Text = "&Clear"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnZero
        '
        Me.btnZero.Location = New System.Drawing.Point(75, 316)
        Me.btnZero.Name = "btnZero"
        Me.btnZero.Size = New System.Drawing.Size(57, 43)
        Me.btnZero.TabIndex = 25
        Me.btnZero.Text = "&0"
        Me.btnZero.UseVisualStyleBackColor = True
        Me.btnZero.Visible = False
        '
        'lbxHistory
        '
        Me.lbxHistory.FormattingEnabled = True
        Me.lbxHistory.Location = New System.Drawing.Point(143, 60)
        Me.lbxHistory.Name = "lbxHistory"
        Me.lbxHistory.Size = New System.Drawing.Size(116, 82)
        Me.lbxHistory.TabIndex = 27
        '
        'txtInline
        '
        Me.txtInline.Location = New System.Drawing.Point(12, 60)
        Me.txtInline.Multiline = True
        Me.txtInline.Name = "txtInline"
        Me.txtInline.ReadOnly = True
        Me.txtInline.Size = New System.Drawing.Size(247, 82)
        Me.txtInline.TabIndex = 28
        Me.txtInline.Visible = False
        '
        'btnDot
        '
        Me.btnDot.Location = New System.Drawing.Point(12, 316)
        Me.btnDot.Name = "btnDot"
        Me.btnDot.Size = New System.Drawing.Size(57, 43)
        Me.btnDot.TabIndex = 29
        Me.btnDot.Text = "&."
        Me.btnDot.UseVisualStyleBackColor = True
        Me.btnDot.Visible = False
        '
        'frmCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(272, 231)
        Me.Controls.Add(Me.btnDot)
        Me.Controls.Add(Me.lbxHistory)
        Me.Controls.Add(Me.btnZero)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.btnEqual)
        Me.Controls.Add(Me.btnDivide)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnNine)
        Me.Controls.Add(Me.btnEight)
        Me.Controls.Add(Me.btnSeven)
        Me.Controls.Add(Me.btnSix)
        Me.Controls.Add(Me.btnFive)
        Me.Controls.Add(Me.btnFour)
        Me.Controls.Add(Me.btnOne)
        Me.Controls.Add(Me.lblHistory)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblOutput)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.txtInputTwo)
        Me.Controls.Add(Me.txtInputOne)
        Me.Controls.Add(Me.rdoInline)
        Me.Controls.Add(Me.rdoStandard)
        Me.Controls.Add(Me.txtInline)
        Me.Controls.Add(Me.btnSubstract)
        Me.Controls.Add(Me.btnTwo)
        Me.Controls.Add(Me.btnMultiply)
        Me.Controls.Add(Me.btnThree)
        Me.Name = "frmCalculator"
        Me.Text = "Calculator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rdoStandard As RadioButton
    Friend WithEvents rdoInline As RadioButton
    Friend WithEvents txtInputOne As TextBox
    Friend WithEvents txtInputTwo As TextBox
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents lblOutput As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents lblInput As Label
    Friend WithEvents lblHistory As Label
    Friend WithEvents btnOne As Button
    Friend WithEvents btnTwo As Button
    Friend WithEvents btnThree As Button
    Friend WithEvents btnFour As Button
    Friend WithEvents btnFive As Button
    Friend WithEvents btnSix As Button
    Friend WithEvents btnSeven As Button
    Friend WithEvents btnEight As Button
    Friend WithEvents btnNine As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnSubstract As Button
    Friend WithEvents btnMultiply As Button
    Friend WithEvents btnDivide As Button
    Friend WithEvents btnEqual As Button
    Friend WithEvents btnClearAll As Button
    Friend WithEvents btnZero As Button
    Friend WithEvents lbxHistory As ListBox
    Friend WithEvents txtInline As TextBox
    Friend WithEvents btnDot As Button
End Class
