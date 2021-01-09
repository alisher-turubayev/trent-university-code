' This is a automated cashier system for assignment 3
'
' Written by: Alisher Turubayev - February 2018
'
' Purpose: demonstration of VB skills
'
' Parameters: none
'
' Subroutine required: none. Each button and a form have their own subroutines.
'                       No additional subroutines are required
Public Class frmCashier
    ' TAX_HST: const double. Used to calculate the tax applied
    Const TAX_HST = 0.13
    ' costOfItems: double. Used to store the cost of all items jn cart
    Dim costOfItems As Double = 0
    ' numberOfItems: Int32. Used to store the number of items in cart
    Dim numberOfItems As Int32 = 0
    ' isClosed: Boolean. Used to determine if the transaction is closed or not
    Dim isClosed As Boolean = False

    Private Sub frmCashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        ' Purpose: this subroutine loads the form and puts the header for the receipt
        '

        ' formatStr: string. Used to correctly format the output
        Dim formatStr As String = "{0, 21}"

        ' Add header
        lstFinalReceipt.Items.Add(String.Format(formatStr, "Welcome to the"))

        ' formatStr changes are necessary for correct output
        formatStr = "{0, 28}"
        lstFinalReceipt.Items.Add(String.Format(formatStr, "Zhuldyz Convenience Store!"))

        formatStr = "{0, 25}"
        lstFinalReceipt.Items.Add(String.Format(formatStr, "Transaction started:"))

        ' Add a timestamp of the transaction start
        formatStr = "{0, -15}{1, 13}"
        lstFinalReceipt.Items.Add(String.Format(formatStr, DateString, TimeString))
        lstFinalReceipt.Items.Add("")

        ' Add column headers
        lstFinalReceipt.Items.Add(String.Format(formatStr, "Item name:", "Price:"))
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        '
        ' Purpose: this subroutine allows the user to exit the program
        '
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        '
        ' Purpose: this subroutine allows the user to add the item to the receipt
        '

        ' price: double. Holds the value of the price textbox
        Dim price As Double

        ' If the textbox contents cannot be converted to the double, raise an error
        If Not Double.TryParse(txtPrice.Text, price) Then
            MsgBox("Price cannot be retrieved", vbOKOnly, "Invalid input")
            Exit Sub
        End If

        ' Make the formatStr for formatting the output properly
        Dim formatStr As String = "{0, -15}{1, 13}"
        ' Output the name and the price of the item in the formatted way
        lstFinalReceipt.Items.Add(String.Format(formatStr, txtName.Text, FormatCurrency(txtPrice.Text)))

        ' Add the price to the cost of all items and increase the number of items by one
        costOfItems += price
        numberOfItems += 1
    End Sub

    Private Sub btnCloseTransaction_Click(sender As Object, e As EventArgs) Handles btnCloseTransaction.Click
        '
        ' Purpose: to calculate the final cost and taxes applied + close the transaction
        '

        ' Check if there are no items in the cart. If no items in the cart are present, raise an error
        If numberOfItems = 0 Then
            MsgBox("No items in the cart are present! Cannot close the transaction!", vbOKOnly, "Error!")
            Exit Sub
        End If

        ' Check if the transaction was closed. If yes, then raise an error message
        If isClosed = True Then
            MsgBox("Transaction is closed already. Restart the program to input new data", vbOKOnly, "Error!")
            Exit Sub
        End If
        ' Else, set isClosed to True and continue
        isClosed = True

        ' taxesApplied: double. Holds the amount of taxes applied to the sale
        Dim taxesApplied As Double = costOfItems * TAX_HST

        ' totalCost: double. Holds the total sales amount
        Dim totalCost As Double = costOfItems + taxesApplied

        ' formatStr: string. Used for proper formatting
        Dim formatStr As String = "{0, -15}{1, 13}"

        ' Add the divider for readability
        lstFinalReceipt.Items.Add(String.Format(formatStr, "--------------", "------------"))
        lstFinalReceipt.Items.Add("")

        ' Output the cost of all items, taxes applied and total cost
        lstFinalReceipt.Items.Add(String.Format(formatStr, "Cost of items:", FormatCurrency(costOfItems)))
        lstFinalReceipt.Items.Add(String.Format(formatStr, "Taxes applied:", FormatCurrency(taxesApplied)))
        lstFinalReceipt.Items.Add(String.Format(formatStr, "Total cost:", FormatCurrency(totalCost)))

        ' Add a couple of free lines for readability
        lstFinalReceipt.Items.Add("")
        lstFinalReceipt.Items.Add("")

        ' Change the format string for right format
        formatStr = "{0, 24}"
        lstFinalReceipt.Items.Add(String.Format(formatStr, "Transaction closed:"))

        ' Change the format string for right format
        formatStr = "{0, -15}{1, 13}"
        ' Put the timestamp of transaction closure
        lstFinalReceipt.Items.Add(String.Format(formatStr, DateString, TimeString))
        lstFinalReceipt.Items.Add("")

        ' Goodbye message!
        lstFinalReceipt.Items.Add("Thank you for your purchase!")
        lstFinalReceipt.Items.Add("You bought " & numberOfItems & " items today")
        lstFinalReceipt.Items.Add("See you again at")
        lstFinalReceipt.Items.Add("Zhuldyz Convenience Store!")
    End Sub
End Class
