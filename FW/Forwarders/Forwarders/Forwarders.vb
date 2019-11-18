Imports System.Windows.Forms

Public Class MDIForwarders

    Dim WithEvents aTimer As New System.Windows.Forms.Timer

    Private Sub aTimer_Tick(ByVal sender As Object,
                            ByVal e As System.EventArgs) Handles aTimer.Tick
        ToolStripStatusLabel2.Text = DateTime.Now.ToString("MMMM dd, yyyy h:mm:ss tt")
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object,
                            ByVal e As System.EventArgs) Handles Me.Shown
        aTimer.Interval = 250
        aTimer.Start()
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles menuShipment.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        If menuShipment.Text = "&Shipment" Then gs_Module = "SH"
        fGENERATEMenu()
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()




    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer
    Function fGENERATEMenu()
        Dim Forwarding As TreeNode
        Dim Brokerage As TreeNode
        Dim UserSettings As TreeNode





        'Dim rsSCR As New ADODB.Recordset
        'Dim logstr = ("SELECT Description From Screens WHERE Module='" & gs_Module & "'")

        'With rsSCR
        '    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
        '    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
        '    .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        '    .Open(logstr, gs_Conn)


        '    If Not .EOF Then
        '        '    Forwarding = New TreeNode("Shipment")
        '        '    TreeView1.Nodes.Add(Forwarding)
        '        '    For i = 1 To rsSCR.RecordCount
        '        '        TreeView1.Nodes(0).Nodes(0).Nodes.Add(New _
        '        'TreeNode("Sub Project" & Str(i)))
        '        '        'Forwarding.Nodes.Add(rsSCR.Fields(i - 1).Value)
        '        '    Next
        '        Forwarding = New TreeNode("Shipment")
        '        TreeView1.Nodes.Add(Forwarding)
        '        'TreeView1.Nodes(0).Nodes.Add(New TreeNode("Project 1"))
        '        'Creating child nodes under the first child

        '        For i As Integer = 1 To rsSCR.RecordCount
        '            TreeView1.Nodes(0).Nodes.Add(New _
        '               TreeNode(rsSCR.Fields(i - 1).Value))
        '            rsSCR.MoveNext()
        '        Next i



        '    End If
        'End With


        Dim da As New System.Data.OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim rsSCR As New ADODB.Recordset
        Dim logstr = ("SELECT Description From Screens WHERE Module='" & gs_Module & "'")

        With rsSCR
            .CursorLocation = ADODB.CursorLocationEnum.adUseClient
            .CursorType = ADODB.CursorTypeEnum.adOpenStatic
            .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
            .Open(logstr, gs_Conn)


            Dim x = rsSCR.RecordCount

            If Not .EOF Then
                da.Fill(ds, rsSCR, "Screens")

                Forwarding = New TreeNode("Shipment")
                TreeView1.Nodes.Add(Forwarding)


                For i As Integer = 1 To x
                    TreeView1.Nodes(0).Nodes.Add(New _
                       TreeNode(ds.Tables("Screens").Rows(i - 1).Item(0)))

                Next i


            End If
            End With


    End Function
    Private Sub MDIForwarders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel3.Text = ("USER: " + FW.gs_User)



        f = New MainFW
            f.TopLevel = False
            Me.Panel1.Controls.Add(f)
            f.Dock = DockStyle.Fill
        f.Show()

        'If (FW.gs_User = "admin") Then
        '    Forwarding = New TreeNode("Forwarder")
        '    TreeView1.Nodes.Add(Forwarding)
        '    Forwarding.Nodes.Add("Details")
        '    Forwarding.Nodes.Add("Custom Info")
        '    Forwarding.Nodes.Add("History")
        '    Forwarding.Nodes.Add("Certificate Of Payment")
        '    Forwarding.Nodes.Add("Schedule Of Delivery")
        '    Brokerage = New TreeNode("Brokerage")
        '    TreeView1.Nodes.Add(Brokerage)
        '    Brokerage.Nodes.Add("Advances")
        '    Brokerage.Nodes.Add("Liquidation")
        '    UserSettings = New TreeNode("User Settings")
        '    TreeView1.Nodes.Add(UserSettings)
        '    Me.TreeView1.Nodes(0).ExpandAll()
        '    Me.TreeView1.Nodes(1).ExpandAll()
        'ElseIf (FW.gs_User = "forwarder") Then
        '    Forwarding = New TreeNode("Forwarder")
        '    TreeView1.Nodes.Add(Forwarding)
        '    Forwarding.Nodes.Add("Details")
        '    Forwarding.Nodes.Add("Custom Info")
        '    Forwarding.Nodes.Add("History")
        '    Forwarding.Nodes.Add("Certificate Of Payment")
        '    Forwarding.Nodes.Add("Schedule Of Delivery")
        '    Me.TreeView1.Nodes(0).ExpandAll()
        'ElseIf (FW.gs_User = "broker") Then
        '    Brokerage = New TreeNode("Brokerage")
        '    TreeView1.Nodes.Add(Brokerage)
        '    Brokerage.Nodes.Add("Advances")
        '    Brokerage.Nodes.Add("Liquidation")
        '    Me.TreeView1.Nodes(0).ExpandAll()
        'End If






    End Sub

    Private Sub StatusStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip.ItemClicked

    End Sub

    Private Sub Form_Close(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        frmLogin.Show()

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
    Private f As Form
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        Dim node As TreeNode
        node = TreeView1.SelectedNode
        Select Case node.Text
            Case "Advances"
                f.Dispose()
                f = New Advances
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Liquidation"
                f.Dispose()
                f = New Liquidation
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Main"
                f.Dispose()
                f = New MainFW
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Forwarder"
                f.Dispose()
                f = New Details
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Details"
                f.Dispose()
                f = New Details
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Custom Info"
                f.Dispose()
                f = New CustomInfo
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "History"
                f.Dispose()
                f = New History
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Certificate Of Payment"
                f.Dispose()
                f = New CertificateOfPayment
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Schedule Of Delivery"
                f.Dispose()
                f = New ScheduleOfDelivery
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Brokerage"
                f.Dispose()
                f = New Advances
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

        End Select


    End Sub


End Class
