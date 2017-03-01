Imports System.ComponentModel

Public Class frmMaster
    'setting values and creating lists
    Dim lastClicked As Button
    Dim decrement As Integer = 1
    Dim btnGraph As New List(Of Buttons)
    Dim flowGraph As New List(Of FlowLayoutPanel)
    Dim colorCode As New List(Of Color)
    Dim win As Boolean = False
    Dim easyMode As Boolean = True

    'closes program
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    'creates event for each button
    Private Sub btn_Click(sender As Button, e As EventArgs)
        lastClicked = sender
        ctxColors.Show(sender, New Point(0, sender.Height))
    End Sub

    'displays context menu with colors after clicking one of the buttons
    Private Sub toolItem_Click(sender As ToolStripMenuItem, e As EventArgs) Handles RedToolStripMenuItem.Click, OrangeToolStripMenuItem.Click, YellowToolStripMenuItem.Click, GreenToolStripMenuItem.Click, BlueToolStripMenuItem.Click, IndigoToolStripMenuItem.Click
        If easyMode Then
            For Each btn As Button In getRow(decrement)
                If btn.BackColor = sender.BackColor Then
                    btn.BackColor = Color.Transparent
                End If
            Next
        End If

        lastClicked.BackColor = sender.BackColor
    End Sub

    'generates all the buttons and their properties
    Private Sub frmMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dialog As DialogResult = MessageBox.Show("Enable Ms. B's Easy Mode", "Enable Easy Mode?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.Yes Then
            easyMode = True
        ElseIf dialog = DialogResult.No Then
            easyMode = False
        End If

        For i = 0 To 8
            Dim row As New List(Of Button)

            For j = 0 To 4
                If Not (j = 4) Then
                    Dim btn As New Button
                    btn.Enabled = False
                    btn.Width = 55
                    btn.Height = 55
                    row.Add(btn)
                Else
                    Dim flow As New FlowLayoutPanel
                    flow.Width = 55
                    flow.Height = 55
                    flow.AutoScroll = True
                    flow.BorderStyle = BorderStyle.Fixed3D
                    flowPanel.SetFlowBreak(flow, True)

                    For x = 1 To 4
                        Dim chk As New CheckBox
                        'chk.Enabled = False
                        chk.AutoCheck = False
                        chk.AutoSize = True
                        chk.Margin = New Padding(8, 8, 0, 0)

                        If x = 2 Then
                            flow.SetFlowBreak(chk, True)
                        End If

                        flow.Controls.Add(chk)
                    Next

                    flowGraph.Add(flow)
                End If
            Next

            btnGraph.Add(New Buttons(row))
        Next

        flowGraph.Reverse()
        btnGraph.Reverse()

        For i = 0 To btnGraph.Count - 1
            Dim row As Buttons = btnGraph(i)

            For Each btn As Button In row.row
                AddHandler btn.Click, AddressOf btn_Click
                flowPanel.Controls.Add(btn)
            Next

            flowPanel.Controls.Add(flowGraph(i))
        Next

        activateRow(0, True)
        generateCode()
    End Sub

    'triggers the checking of the game board
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If decrement <= 9 And isValid() Then
            scoreRow(getRow(decrement))

            If decrement > 0 Then
                activateRow(decrement - 1, False)
            End If

            If decrement = 9 And Not (win) Then
                MsgBox("You lost")
                MsgBox("This is the Color Key for the game you just lost: " & String.Join(", ", colorCode))
                resetGame()
            ElseIf win Then
                resetGame()
            ElseIf decrement < 9 Then
                activateRow(decrement, True)
            End If

            decrement += 1
        Else
            MessageBox.Show("You must color all boxes before continuing")
        End If
    End Sub

    'resets game
    Private Sub resetGame()
        Dim nForm As New frmMaster()
        AddHandler nForm.FormClosed, AddressOf Me.Close
        Hide()
        nForm.Show()
    End Sub

    'creates the random code 
    Private Sub generateCode()
        colorCode.Clear()
        Dim colors As New List(Of Color)
        Dim rand As New Random()

        colors.Add(Color.Red)
        colors.Add(Color.Orange)
        colors.Add(Color.Yellow)
        colors.Add(Color.Green)
        colors.Add(Color.Blue)
        colors.Add(Color.Indigo)

        If easyMode Then
            For i As Integer = 1 To 4
                Dim randint = rand.Next(0, colors.Count)
                colorCode.Add(colors(randint))
                colors.Remove(colors(randint))
            Next
        Else
            For i As Integer = 1 To 4
                Dim randint = rand.Next(0, 5)
                colorCode.Add(colors(randint))
            Next
        End If

        'MsgBox(String.Join(", ", colorCode))
    End Sub

    'enables a row
    Private Sub activateRow(ByVal up As Integer, ByVal enable As Boolean)
        Dim btn As List(Of Button) = getRow(up + 1)

        For i = 0 To 3
            btn(i).Enabled = enable
        Next
    End Sub

    'checks the game board
    Private Sub scoreRow(ByVal row As List(Of Button))
        Dim score As New List(Of Char)
        Dim colorSeen As New List(Of Color)
        Dim colors As New List(Of Color)

        score.Add("E")
        score.Add("E")
        score.Add("E")
        score.Add("E")

        For Each btn As Button In row
            colors.Add(btn.BackColor)
        Next

        For i = 0 To 3
            Dim btn As Button = row(i)
            Dim clr As Color = colors(i)
            Dim codeColorCount As Integer = Enumerable.Count(colorCode, Function(code) code = clr)
            Dim localColorCount As Integer = Enumerable.Count(colors, Function(code) code = clr)
            Dim seenCount As Integer = Enumerable.Count(colorSeen, Function(code) code = clr)
            Dim equal As Boolean = codeColorCount = localColorCount

            Dim curColorsAB As Integer = 0

            For j = 0 To 3
                If colors(j) = colorCode(j) And colors(j) = clr And score(j) = "E" Then
                    score(j) = "A"
                    curColorsAB += 1
                End If
            Next

            For j = 0 To 3
                If score(j) = "E" And curColorsAB < codeColorCount And colors(j) = clr Then
                    score(j) = "B"
                    curColorsAB += 1
                ElseIf score(j) = "E" And colors(j) = clr Then
                    score(j) = "C"
                End If
            Next
        Next

        score.Sort()

        showScore(score, flowGraph(flowGraph.Count - decrement))

        If String.Join("", score) = "AAAA" Then
            MsgBox("You win!")
            win = True
        End If
    End Sub

    'displays score
    Private Sub showScore(ByVal score As List(Of Char), ByVal chkRow As FlowLayoutPanel)
        Dim chkBoxes = chkRow.Controls.OfType(Of CheckBox)

        For i = 0 To chkBoxes.Count - 1
            Dim chk As CheckBox = chkBoxes(i)
            If score(i) = "A" Then
                chk.CheckState = CheckState.Indeterminate
            ElseIf score(i) = "B" Then
                chk.CheckState = CheckState.Checked
            Else
                chk.CheckState = CheckState.Unchecked
            End If
        Next
    End Sub

    'gets row 
    Private Function getRow(ByVal up As Integer) As List(Of Button)
        If btnGraph.Count - up >= 0 Then
            Return btnGraph(btnGraph.Count - up).row
        End If
    End Function

    'checks if all buttons in a row are colored
    Private Function isValid() As Boolean
        If Not (decrement = 0) Then
            For Each btn As Button In getRow(decrement)
                If btn.BackColor.Equals(Color.Transparent) Then
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Private Sub frmMaster_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Me.Visible Then
            Dim doExit As DialogResult = MessageBox.Show("Are you sure you wish to exit the application?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If doExit = doExit.No Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        MsgBox("You lost")
        MsgBox("This is the Color Key for the game you just lost: " & String.Join(", ", colorCode))
        resetGame()
    End Sub
End Class


