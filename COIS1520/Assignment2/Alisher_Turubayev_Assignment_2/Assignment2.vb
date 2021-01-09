' This is a calculator for assignment 2
' 
' Written by: Alisher Turubayev - February 2018
' 
' Purpose: demonstration of VB skills
' 
' Parameters: none
'
' Subroutine required: none, each button, as well as the main form, has their own subroutines
'                      no additional subroutines are required
'
' Calculator modes: standard - two input boxes, one output box and the view of history. Default mode for the application
'                   inline - one input box for both input and output. No history view is available. 
Public Class frmCalculator
    ' isStandard: boolean. Purpose: to indicate the switch between the modes of the calculator. True by default
    Dim isStandard As Boolean = True

    ' sizeStandard/Inline: Size. Purpose: values for sizes in different modes. Used to avoid hardcoded values
    Dim sizeStandard = New Size(288, 270)
    Dim sizeInline = New Size(288, 411)

    ' locationBtn{Add, Substract, Multiply, Divide}Standard: Point. Purpose: values for locations of buttons in the standard mode
    Dim locationBtnAddStandard = New Point(12, 169)
    Dim locationBtnSubstractStandard = New Point(75, 169)
    Dim locationBtnMultiplyStandard = New Point(138, 169)
    Dim locationBtnDivideStandard = New Point(201, 169)

    ' locationBtn{Add, Substract, Multiply, Divide}Inline: Point. Purpose: values for locations of buttons in the inline mode
    Dim locationBtnAddInline = New Point(201, 169)
    Dim locationBtnSubstractInline = New Point(201, 218)
    Dim locationBtnMultiplyInline = New Point(201, 267)
    Dim locationBtnDivideInline = New Point(201, 316)

    '
    ' Functions and subroutines for checking the inline mode input
    '
    Private Sub solveInlineExpression()
        '
        ' Purpose: this subroutine allows the user to evaluate the expression in the inline textbox
        ' Called by: all operation buttons
        ' Notice! Only called in the inline mode
        '

        ' answer: Double. Saves the answer
        Dim answer As Double = 0
        ' value1/2: Double. Save the operands used in the expression
        Dim value1, value2 As Double
        ' text1: String. Saves the first operand in the string format
        Dim text1 As String = ""
        ' text2: String. Saves the second operand in the string format
        Dim text2 As String = ""
        ' isFirstValue: Boolean. Used to determine if the symbol of the operation appeared in the expression already
        ' If no, the symbol processed is added to the first operand
        ' If yes, the symbol processed is added to the second operand
        Dim isFirstValue = True
        ' operation: Char. Saves the operation symbol for the further processing 
        Dim operation As Char

        ' Proceed the input in the inline textbox symbol by symbol
        For Each symbol As Char In txtInline.Text
            ' if the symbol is an operation (+, -, * or /), we change the isFirstValue boolean
            ' and save the operation in the variable
            If (symbol = "+") OrElse (symbol = "-") OrElse (symbol = "*") OrElse (symbol = "/") Then
                isFirstValue = False
                operation = symbol
            ElseIf isFirstValue = True Then
                ' if the symbol is not an operation, we add the symbol to either first or second operand,
                ' depending on isFirstValue boolean
                text1 &= symbol
            Else
                text2 &= symbol
            End If
        Next

        ' If text1 cannot be parsed into a value1, raise an error
        If Double.TryParse(text1, value1) = False Then
            MsgBox("Cannot evaluate the first operand", vbOKOnly, "Syntax error")
            txtInline.Clear()
            Exit Sub
        End If

        ' If text2 cannot be parsed into a value2, raise an error
        If Double.TryParse(text2, value2) = False Then
            MsgBox("Cannot evaluate the second operand", vbOKOnly, "Syntax error")
            txtInline.Clear()
        End If

        ' Compute the answer depending on which operation was specified in the inline input
        If operation = "+" Then
            answer = value1 + value2
        ElseIf operation = "-" Then
            answer = value1 - value2
        ElseIf operation = "*" Then
            answer = value1 * value2
        ElseIf operation = "/" Then
            ' Rudimentary check for division by 0
            If value2 = 0 Then
                MsgBox("Cannot divide by zero", vbOKOnly, "Syntax error")
                txtInline.Clear()
                Exit Sub
            Else
                answer = value1 / value2
            End If
        End If

        txtInline.Text = CStr(answer)
    End Sub

    Private Function hasOperationAlready() As Boolean
        '
        ' This function checks whether there are operations in the inline textbox
        ' Purpose: to evaluate the expression if one operation 

        ' Check if the symbol is already present in the expression
        For Each symbol As Char In txtInline.Text
            If symbol = "+" OrElse symbol = "-" OrElse symbol = "*" OrElse symbol = "/" Then
                Return True
            End If
        Next

        ' Return False otherwise
        Return False
    End Function

    '
    ' Subroutines for Exit and ClearAll buttons
    '
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        '
        '   This subroutine allows the user to end the program
        '
        Me.Close()
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        '
        ' Purpose: this subroutine allows the user to clear text from textboxes and listbox
        ' Notice: in the inline mode, cleans the input box
        '
        If (isStandard = True) Then
            txtInputOne.Clear()
            txtInputTwo.Clear()
            txtOutput.Clear()
            lbxHistory.Items.Clear()
        Else
            txtInline.Clear()
        End If
    End Sub

    '
    ' Subroutines for radiobuttons, which change the mode of the calculator
    '
    Private Sub rdoStandard_CheckedChanged(sender As Object, e As EventArgs) Handles rdoStandard.CheckedChanged
        '
        ' Purpose: this subroutine allows the user to change the calculator mode to standard
        '

        ' If already in the standard mode, exit the subroutine
        If (isStandard = True) Then
            Exit Sub
        End If

        ' Else, set the value to true
        isStandard = True

        ' Making all controls visible
        txtInputOne.Visible = True
        txtInputTwo.Visible = True
        txtOutput.Visible = True
        lbxHistory.Visible = True

        ' Making all labels visible
        lblInput.Visible = True
        lblOutput.Visible = True
        lblHistory.Visible = True

        ' Making the inline input box invisible
        txtInline.Visible = False

        ' Clear the contents of the inline input box
        txtInline.Clear()

        ' Hide all unnecessary buttons
        btnOne.Visible = False
        btnTwo.Visible = False
        btnThree.Visible = False
        btnFour.Visible = False
        btnFive.Visible = False
        btnSix.Visible = False
        btnSeven.Visible = False
        btnEight.Visible = False
        btnNine.Visible = False
        btnZero.Visible = False
        btnEqual.Visible = False
        btnDot.Visible = False

        ' Correcly position all controls
        btnAdd.Location = locationBtnAddStandard
        btnSubstract.Location = locationBtnSubstractStandard
        btnMultiply.Location = locationBtnMultiplyStandard
        btnDivide.Location = locationBtnDivideStandard

        ' Change the size of the form
        Me.Size = sizeStandard
    End Sub

    Private Sub rdoInline_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInline.CheckedChanged
        '
        ' Purpose: this subroutine allows the user to change the mode of the calculator to inline
        '

        ' If already in the inline mode, exit the subroutine
        If (isStandard = False) Then
            Exit Sub
        End If

        ' Else, set the value to false 
        isStandard = False

        ' Hide unnecessary labels
        lblInput.Visible = False
        lblOutput.Visible = False
        lblHistory.Visible = False

        ' Hide unnecessary textboxes
        txtInputOne.Visible = False
        txtInputTwo.Visible = False
        txtOutput.Visible = False
        lbxHistory.Visible = False

        ' Clear leftover data
        txtInputOne.Clear()
        txtInputTwo.Clear()
        txtOutput.Clear()
        lbxHistory.Items.Clear()

        ' Make input box visible
        txtInline.Visible = True

        ' Make buttons visible
        btnOne.Visible = True
        btnTwo.Visible = True
        btnThree.Visible = True
        btnFour.Visible = True
        btnFive.Visible = True
        btnSix.Visible = True
        btnSeven.Visible = True
        btnEight.Visible = True
        btnNine.Visible = True
        btnZero.Visible = True
        btnEqual.Visible = True
        btnDot.Visible = True

        ' Correcly position all controls
        btnAdd.Location = locationBtnAddInline
        btnSubstract.Location = locationBtnSubstractInline
        btnMultiply.Location = locationBtnMultiplyInline
        btnDivide.Location = locationBtnDivideInline

        ' Bind the btnEqual to "Enter" 
        Me.AcceptButton = btnEqual

        ' Change the size of the form
        Me.Size = sizeInline
    End Sub

    '
    ' Subroutines for operation buttons: "+", "-", "*", "/" and "="
    '
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        '
        ' Purpose: 
        ' If in standard mode, this subroutine allows the user to add two numbers in the textboxes and outputs the answer
        ' If in inline mode, this button adds a "+" to the textbox
        '

        ' If in inline mode and the last symbol is not an operation symbol, add +
        If isStandard = False Then
            If Not hasOperationAlready() Then
                txtInline.Text = txtInline.Text & "+"
            Else
                solveInlineExpression()
            End If
            Exit Sub
        End If

        ' Else, continue
        ' Declare three varaibles  that will hold the operands and an answer
        Dim value1 As Double
        Dim value2 As Double
        Dim answer As Double

        ' Check if we can parse first number as a double; if not, raise an error message
        If Double.TryParse(txtInputOne.Text, value1) = False Then
            MsgBox("Error parsing the integer in the first box", vbOKOnly, "Invalid input")
            Exit Sub
        End If

        ' Check if we can parse second number as a double; if not, raise an error message
        If Double.TryParse(txtInputTwo.Text, value2) = False Then
            MsgBox("Error parsing the integer in the second box", vbOKOnly, "Invalid input")
            Exit Sub
        End If

        ' Get the answer and display it
        answer = value1 + value2
        txtOutput.Text = CStr(answer)

        ' Add the operation to history
        lbxHistory.Items.Add("First operand: " & CStr(value1))
        lbxHistory.Items.Add("Second operand: " & CStr(value2))
        lbxHistory.Items.Add("Operation: add")
        lbxHistory.Items.Add("Result: " & CStr(answer))
        lbxHistory.Items.Add("---")
    End Sub

    Private Sub btnSubstract_Click(sender As Object, e As EventArgs) Handles btnSubstract.Click
        '
        ' Purpose: 
        ' If in standard mode, this subroutine allows the user to substract the second number from first and outputs the answer
        ' If in inline mode, this button adds a "-" to the textbox
        '

        ' If in inline mode and the last symbol is not -, add -
        If isStandard = False Then
            If Not hasOperationAlready() Then
                txtInline.Text = txtInline.Text & "-"
            Else
                solveInlineExpression()
            End If
            Exit Sub
        End If

        ' Else, continue
        ' Declare three varaibles  that will hold the operands and an answer
        Dim value1 As Double
        Dim value2 As Double
        Dim answer As Double

        ' Check if we can parse first number as a double; if not, raise an error message
        If Double.TryParse(txtInputOne.Text, value1) = False Then
            MsgBox("Error parsing the integer in the first box", vbOKOnly, "Invalid input")
            Exit Sub
        End If

        ' Check if we can parse second number as a double; if not, raise an error message
        If Double.TryParse(txtInputTwo.Text, value2) = False Then
            MsgBox("Error parsing the integer in the second box", vbOKOnly, "Invalid input")
            Exit Sub
        End If

        ' Get the answer and display it
        answer = value1 - value2
        txtOutput.Text = CStr(answer)

        ' Add the operation to history
        lbxHistory.Items.Add("First operand: " & CStr(value1))
        lbxHistory.Items.Add("Second operand: " & CStr(value2))
        lbxHistory.Items.Add("Operation: substract")
        lbxHistory.Items.Add("Result: " & CStr(answer))
        lbxHistory.Items.Add("---")
    End Sub

    Private Sub btnMultiply_Click(sender As Object, e As EventArgs) Handles btnMultiply.Click
        '
        ' Purpose: 
        ' If in standard mode, this subroutine allows the user to multiply two numbers in the textboxes and outputs the answer
        ' If in inline mode, this button adds a "*" to the textbox
        '

        ' If in inline mode and the last symbol is not *, add *
        If isStandard = False Then
            If Not hasOperationAlready() Then
                txtInline.Text = txtInline.Text & "*"
            Else
                solveInlineExpression()
            End If
            Exit Sub
        End If

        ' Else, continue
        ' Declare three varaibles  that will hold the operands and an answer
        Dim value1 As Double
        Dim value2 As Double
        Dim answer As Double

        ' Check if we can parse first number as a double; if not, raise an error message
        If Double.TryParse(txtInputOne.Text, value1) = False Then
            MsgBox("Error parsing the integer in the first box", vbOKOnly, "Invalid input")
            Exit Sub
        End If

        ' Check if we can parse second number as a double; if not, raise an error message
        If Double.TryParse(txtInputTwo.Text, value2) = False Then
            MsgBox("Error parsing the integer in the second box", vbOKOnly, "Invalid input")
            Exit Sub
        End If

        ' Get the answer and display it
        answer = value1 * value2
        txtOutput.Text = CStr(answer)

        ' Add the operation to history
        lbxHistory.Items.Add("First operand: " & CStr(value1))
        lbxHistory.Items.Add("Second operand: " & CStr(value2))
        lbxHistory.Items.Add("Operation: multiply")
        lbxHistory.Items.Add("Result: " & CStr(answer))
        lbxHistory.Items.Add("---")
    End Sub

    Private Sub btnDivide_Click(sender As Object, e As EventArgs) Handles btnDivide.Click
        '
        ' Purpose: 
        ' If in standard mode, this subroutine allows the user to divide the first number by second and outputs the answer
        ' If in inline mode, this button adds a "/" to the textbox
        '

        ' If in inline mode and the last symbol is not /, add /
        If isStandard = False Then
            If Not hasOperationAlready() Then
                txtInline.Text = txtInline.Text & "/"
            Else
                solveInlineExpression()
            End If
            Exit Sub
        End If

        ' Else, continue
        ' Declare three varaibles  that will hold the operands and an answer
        Dim value1 As Double
        Dim value2 As Double
        Dim answer As Double

        ' Check if we can parse first number as a double; if not, raise an error message
        If Double.TryParse(txtInputOne.Text, value1) = False Then
            MsgBox("Error parsing the integer in the first box", vbOKOnly, "Invalid input")
            Exit Sub
        End If

        ' Check if we can parse second number as a double; if not, raise an error message
        If Double.TryParse(txtInputTwo.Text, value2) = False Then
            MsgBox("Error parsing the integer in the second box", vbOKOnly, "Invalid input")
            Exit Sub
        End If

        ' Check if the second number is zero; if true, raise an error
        If value2 = 0 Then
            MsgBox("Cannot divide by zero!", vbOKOnly, "Invalid operation")
            Exit Sub
        End If

        ' Get the answer and display it
        answer = value1 / value2
        txtOutput.Text = CStr(answer)

        ' Add the operation to history
        lbxHistory.Items.Add("First operand: " & CStr(value1))
        lbxHistory.Items.Add("Second operand: " & CStr(value2))
        lbxHistory.Items.Add("Operation: divide")
        lbxHistory.Items.Add("Result: " & CStr(answer))
        lbxHistory.Items.Add("---")
    End Sub

    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        '
        ' Purpose: this subroutine allows the user to evaluate the expression in the inline mode
        ' Notice: this button is only present in the inline mode
        '

        ' If we don't have any operations in the textbox, we don't need to evaluate anything
        If Not hasOperationAlready() Then
            Exit Sub
        End If

        ' Else, solve the expression
        solveInlineExpression()
    End Sub

    '
    ' Subroutines for numeric buttons: "0" - "9"
    '
    Private Sub btnOne_Click(sender As Object, e As EventArgs) Handles btnOne.Click
        '
        ' Purpose: this subroutine allows the user to input number 1 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "1"
    End Sub

    Private Sub btnTwo_Click(sender As Object, e As EventArgs) Handles btnTwo.Click
        '
        ' Purpose: this subroutine allows the user to input number 2 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "2"
    End Sub

    Private Sub btnThree_Click(sender As Object, e As EventArgs) Handles btnThree.Click
        '
        ' Purpose: this subroutine allows the user to input number 3 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "3"
    End Sub

    Private Sub btnFour_Click(sender As Object, e As EventArgs) Handles btnFour.Click
        '
        ' Purpose: this subroutine allows the user to input number 4 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "4"
    End Sub

    Private Sub btnFive_Click(sender As Object, e As EventArgs) Handles btnFive.Click
        '
        ' Purpose: this subroutine allows the user to input number 5 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "5"
    End Sub

    Private Sub btnSix_Click(sender As Object, e As EventArgs) Handles btnSix.Click
        '
        ' Purpose: this subroutine allows the user to input number 6 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "6"
    End Sub

    Private Sub btnSeven_Click(sender As Object, e As EventArgs) Handles btnSeven.Click
        '
        ' Purpose: this subroutine allows the user to input number 7 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "7"
    End Sub

    Private Sub btnEight_Click(sender As Object, e As EventArgs) Handles btnEight.Click
        '
        ' Purpose: this subroutine allows the user to input number 8 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "8"
    End Sub

    Private Sub btnNine_Click(sender As Object, e As EventArgs) Handles btnNine.Click
        '
        ' Purpose: this subroutine allows the user to input number 9 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "9"
    End Sub

    Private Sub btnZero_Click(sender As Object, e As EventArgs) Handles btnZero.Click
        '
        ' Purpose: this subroutine allows the user to input number 0 to the textbox
        ' Notice: this button is only present in the inline mode
        '
        txtInline.Text = txtInline.Text & "0"
    End Sub
End Class
