'   Program for Assignment 1
'
' Written by: Alisher Turubayev - 2017
'
' Purpose: Demonstration of VB GUI for applications  
'
' Parameters: none
'
' Subroutine required: Each button has its own associated subroutine 
'                       No other functions/subroutines are required
'
Public Class Main

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        '
        ' This subroutine allows the user to exit the program
        ' Keybind: x
        '
        Me.Close()
    End Sub

    Private Sub btnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
        '
        ' This subroutine is called when the user presses the button with 'Default' label
        '
        ' Purpose: to change the color of the form to default (Grey) 
        ' Keybind: d
        '
        Me.BackColor = DefaultBackColor
    End Sub

    Private Sub btnRed_Click(sender As Object, e As EventArgs) Handles btnRed.Click
        '
        ' This subroutine is called when the user presses the button with 'Red' label
        '
        ' Purpose: to change the color of the form to red
        ' Keybind: r
        '
        Me.BackColor = Color.Red
    End Sub

    Private Sub btnBlue_Click(sender As Object, e As EventArgs) Handles btnBlue.Click
        '
        ' This subroutine is called when the user presses the button with 'Blue' label
        '
        ' Purpose: to change the color of the form to blue
        ' Keybind: b
        '
        Me.BackColor = Color.Blue
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        '
        ' This subroutine is called when the user presses the button with 'Change text' label
        '
        ' Purpose: to change the text of the label to whatever is written in the text box
        ' Notice the if statement: the subroutine will not change the text if the textbox is empty
        ' Keybind: c
        '
        If txtChange.Text.Length > 0 Then
            lblChange.Text = txtChange.Text ' if and only if the textbox is not empty we put the text in the label
        End If
        txtChange.ResetText()
    End Sub

End Class
