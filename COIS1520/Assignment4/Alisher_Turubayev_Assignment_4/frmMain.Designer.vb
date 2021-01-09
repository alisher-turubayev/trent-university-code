<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnRead = New System.Windows.Forms.Button()
        Me.lstFromFile = New System.Windows.Forms.ListBox()
        Me.lstSorted = New System.Windows.Forms.ListBox()
        Me.btnSortAscending = New System.Windows.Forms.Button()
        Me.btnDescending = New System.Windows.Forms.Button()
        Me.lblSort = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(265, 435)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(165, 23)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRead
        '
        Me.btnRead.Location = New System.Drawing.Point(12, 435)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(165, 23)
        Me.btnRead.TabIndex = 1
        Me.btnRead.Text = "Read from default location"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'lstFromFile
        '
        Me.lstFromFile.FormattingEnabled = True
        Me.lstFromFile.Location = New System.Drawing.Point(12, 13)
        Me.lstFromFile.Name = "lstFromFile"
        Me.lstFromFile.Size = New System.Drawing.Size(165, 407)
        Me.lstFromFile.TabIndex = 2
        '
        'lstSorted
        '
        Me.lstSorted.FormattingEnabled = True
        Me.lstSorted.Location = New System.Drawing.Point(265, 13)
        Me.lstSorted.Name = "lstSorted"
        Me.lstSorted.Size = New System.Drawing.Size(165, 407)
        Me.lstSorted.TabIndex = 3
        '
        'btnSortAscending
        '
        Me.btnSortAscending.Location = New System.Drawing.Point(183, 29)
        Me.btnSortAscending.Name = "btnSortAscending"
        Me.btnSortAscending.Size = New System.Drawing.Size(76, 23)
        Me.btnSortAscending.TabIndex = 4
        Me.btnSortAscending.Text = "Ascending"
        Me.btnSortAscending.UseVisualStyleBackColor = True
        '
        'btnDescending
        '
        Me.btnDescending.Location = New System.Drawing.Point(183, 58)
        Me.btnDescending.Name = "btnDescending"
        Me.btnDescending.Size = New System.Drawing.Size(76, 23)
        Me.btnDescending.TabIndex = 5
        Me.btnDescending.Text = "Descending"
        Me.btnDescending.UseVisualStyleBackColor = True
        '
        'lblSort
        '
        Me.lblSort.Location = New System.Drawing.Point(184, 13)
        Me.lblSort.Name = "lblSort"
        Me.lblSort.Size = New System.Drawing.Size(75, 13)
        Me.lblSort.TabIndex = 6
        Me.lblSort.Text = "Sort:"
        Me.lblSort.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 470)
        Me.Controls.Add(Me.lblSort)
        Me.Controls.Add(Me.btnDescending)
        Me.Controls.Add(Me.btnSortAscending)
        Me.Controls.Add(Me.lstSorted)
        Me.Controls.Add(Me.lstFromFile)
        Me.Controls.Add(Me.btnRead)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmMain"
        Me.Text = "Name Sorter"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnRead As Button
    Friend WithEvents lstFromFile As ListBox
    Friend WithEvents lstSorted As ListBox
    Friend WithEvents btnSortAscending As Button
    Friend WithEvents btnDescending As Button
    Friend WithEvents lblSort As Label
End Class
