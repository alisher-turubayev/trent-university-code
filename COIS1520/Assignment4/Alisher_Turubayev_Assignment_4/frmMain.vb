' This is a name sorter for Assignment 4
'
' Written by: Alisher Turubayev - March 2018
'
' Purpose: demonstration of VB skills
'
' Parameters: none
'
' Subroutine required: none. Each button has their own subroutine. 
'                       Additionally, there are functions/subroutines for Bubble Sort (Sort, Compare, Swap).
'                       No additional subroutines are required
Public Class frmMain
    ' END_OF_FILE: integer const. Stores the end of file indentifier
    Const END_OF_FILE As Integer = -1

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        '
        ' This subroutine allows the user to exit the application
        '
        Me.Close()
    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        '
        ' This subroutine reads the names in names.txt in the default location and prints them out in the left listbox
        '

        ' Clear the listbox
        lstFromFile.Items.Clear()

        ' applicationPath: string. Stores the path where .exe is run
        Dim applicationPath As String = Application.StartupPath()
        ' fileName: string. Stores the name and the path to the file 
        Dim fileName As String = applicationPath + "\names.txt"

        Dim score() As Integer = {85, 92, 75, 68}

        doubleAll(score)

        Debug.WriteLine(fileName)

        If Not System.IO.File.Exists(fileName) Then
            '
            ' If the file is not found, raise critical error and end the program execution
            '
            MsgBox("File not found. Please, reinstall the program.", vbCritical, "Critical error!")
            Exit Sub
        End If

        ' Open the file reader
        Dim reader As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(fileName)

        ' Read while available
        While Not reader.Peek().Equals(END_OF_FILE)
            ' Add the line to the listbox
            Dim inputLine As String = reader.ReadLine()
            lstFromFile.Items.Add(inputLine)
        End While

        ' Close the reading stream
        reader.Close()
    End Sub

    Private Sub btnSortAscending_Click(sender As Object, e As EventArgs) Handles btnSortAscending.Click
        '
        ' This subroutine allows the user to sort the entries in ascending order and output them to the right listbox
        '

        ' Clear the listbox
        lstSorted.Items.Clear()

        ' numberEntries: Integer. Stores the number of names
        Dim numberEntries As Integer = lstFromFile.Items.Count
        ' names(): String. Stores the entries from the listbox
        Dim names(numberEntries - 1) As String
        ' index: Integer. Stores the current accessed item
        Dim index As Integer = 0

        ' Copy the data from listbox to the array
        For Each name As String In lstFromFile.Items
            names(index) = name
            index += 1
        Next

        ' Bubble Sort the array
        StringBubbleSort(names)

        For Each name As String In names
            lstSorted.Items.Add(name)
        Next
    End Sub

    Private Sub doubleAll(ByVal myArray() As Integer)
        For index As Integer = 0 To myArray.Count() - 1
            myArray(index) *= 2
        Next
    End Sub

    Private Sub btnDescending_Click(sender As Object, e As EventArgs) Handles btnDescending.Click
        '
        ' This subroutine allows the user to sort the entries in descending order and output them to the right listbox
        '

        ' Clear the listbox
        lstSorted.Items.Clear()

        ' numberEntries: Integer. Stores the number of names
        Dim numberEntries As Integer = lstFromFile.Items.Count
        ' names(): String. Stores the entries from the listbox
        Dim names(numberEntries - 1) As String
        ' index: Integer. Stores the current accessed item
        Dim index As Integer = 0

        ' Copy the data from listbox to the array
        For Each name As String In lstFromFile.Items
            names(index) = name
            index += 1
        Next

        ' Bubble Sort the array in descending order (see documentation)
        StringBubbleSort(names, False)

        For Each name As String In names
            lstSorted.Items.Add(name)
        Next
    End Sub

    '
    ' StringBubbleSort: subroutine
    ' Parameters: names(): String. Mandatory: stores the array which needs to be sorted
    '             and isAscending: Boolean. Optional: allows for either ascending or descending sorting method. 
    '                 True as default for ascending order, False - for descending.
    ' Returns: nothing
    ' Purpose: subroutine sorts the given array of strings
    '
    Private Sub StringBubbleSort(names() As String, Optional isAscending As Boolean = True)
        ' Initialize the first loop
        For iteration = 0 To names.Length
            ' Initialize the second loop
            For index = 0 To names.Length - 2
                ' If the StringCompare function returns True, swap the values
                If StringCompare(names(index), names(index + 1)) = isAscending Then
                    StringSwap(names(index), names(index + 1))
                End If
            Next
        Next
    End Sub

    '
    ' StringCompare: Boolean
    ' Parameters: item1/2: String. The items to be compared
    ' Returns: boolean specifying if the item1 is alphabetically bigger than item2
    ' Purpose: function compares two strings without altering the values
    '
    Private Function StringCompare(item1 As String, item2 As String) As Boolean
        item1 = item1.ToUpper()
        item2 = item2.ToUpper()
        Return item1 > item2
    End Function

    '
    ' StringSwap: subroutine
    ' Parameters: item1/2: ByRef String. The items to be swapped
    ' Returns: nothing
    ' Purpose: function swaps the values of two strings
    '
    Private Sub StringSwap(ByRef item1 As String, ByRef item2 As String)
        Dim temporary As String = item1
        item1 = item2
        item2 = temporary
    End Sub
End Class
