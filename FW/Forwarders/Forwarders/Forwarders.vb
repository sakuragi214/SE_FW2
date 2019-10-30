Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports ADODB
Imports System.IO
Imports System.Data.SqlClient

Public Class MDIForwarders
    Private f As Form
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
    Public Sub ClearTextBoxes(Optional ByVal ctlcol As Control.ControlCollection = Nothing)
        If ctlcol Is Nothing Then ctlcol = f.Controls
        For Each ctl As Control In ctlcol
            If TypeOf (ctl) Is TextBox Then
                DirectCast(ctl, TextBox).Clear()
            Else
                If Not ctl.Controls Is Nothing OrElse ctl.Controls.Count <> 0 Then
                    ClearTextBoxes(ctl.Controls)
                End If
            End If
        Next
    End Sub
    Private Sub clear(Optional ByVal textclearcol As Control.ControlCollection = Nothing)
        If textclearcol Is Nothing Then textclearcol = f.Controls
        For Each textclear As Control In textclearcol
            If TypeOf textclear Is CheckBox Then
                DirectCast(textclear, CheckBox).Checked = False
            Else
                If Not textclear.Controls Is Nothing OrElse textclear.Controls.Count <> 0 Then
                    clear(textclear.Controls)
                End If
            End If
        Next
    End Sub
    Private Sub radclear(Optional ByVal textclearrad As Control.ControlCollection = Nothing)
        If textclearrad Is Nothing Then textclearrad = f.Controls
        For Each textclearrd As Control In textclearrad
            If TypeOf textclearrd Is RadioButton Then
                DirectCast(textclearrd, RadioButton).Checked = False
            Else
                If Not textclearrd.Controls Is Nothing OrElse textclearrd.Controls.Count <> 0 Then
                    radclear(textclearrd.Controls)
                End If
            End If
        Next
    End Sub
    Private Sub cbclear(Optional ByVal textclearcbcol As Control.ControlCollection = Nothing)
        If textclearcbcol Is Nothing Then textclearcbcol = f.Controls
        For Each textclearcb As Control In textclearcbcol
            If TypeOf textclearcb Is ComboBox Then
                DirectCast(textclearcb, ComboBox).Text = ""
            Else
                If Not textclearcb.Controls Is Nothing OrElse textclearcb.Controls.Count <> 0 Then
                    cbclear(textclearcb.Controls)
                End If
            End If
        Next
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ClearTextBoxes()
        clear()
        cbclear()
        radclear()

        ' Create a new instance of the child form.
        '  Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ' ChildForm.MdiParent = Me

        'm_ChildFormNumber += 1
        'ChildForm.Text = "Window " & m_ChildFormNumber

        'ChildForm.Show()

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

    Private Sub MDIForwarders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel3.Text = ("USER: " + FW.gs_User)
        f = New Blank
        f.TopLevel = False
        Me.Panel1.Controls.Add(f)
        f.Dock = DockStyle.Fill
        f.Show()
        BindTreeViewAdmin()



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

                'Case "Main"
                '   f.Dispose()
                '  f = New MainFW
                ' f.TopLevel = False
                ' Me.Panel1.Controls.Add(f)
                ' f.Dock = DockStyle.Fill
               ' f.Show()



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

            Case "User Settings"
                f.Dispose()
                f = New UserPermissions
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Billing"
                f.Dispose()
                f = New Billing
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()


        End Select


    End Sub
    Sub BindTreeViewAdmin()
        Dim connetionString = "Data Source=LAPTOP-SQ6GSPQV; Initial Catalog=FW;Integrated Security=True;"
        Dim conn As System.Data.SqlClient.SqlConnection = New SqlClient.SqlConnection(connetionString)
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        Dim pke(0) As DataColumn
        Dim i As Integer
        Dim j As Integer
        Try

            cmd.CommandText = "Select * From Users Inner Join UserScreen On Users.UserID=UserScreen.UserID Inner Join Screen on UserScreen.ScreenID=Screen.ScreenID Where UserScreen.UserID='" + gs_User + "'"
            da.SelectCommand = cmd
            da.SelectCommand.Connection = conn
            da.Fill(dt)
            pke(0) = dt.Columns("ScreenID")
            dt.PrimaryKey = pke
            conn.Close()


            TreeView1.Nodes.Add("Forwarders")
            TreeView1.Nodes.Add("Brokerage")
            TreeView1.Nodes.Add("Billing")
            TreeView1.Nodes.Add("Admin")
            For j = 0 To dt.Rows.Count - 1
                If (dt.Rows(j).Item("Status") = "Enable") Then
                    If (dt.Rows(j).Item("FormParent") = "Forwarders") Then
                        TreeView1.Nodes(i).Nodes.Add(dt.Rows(j).Item("NodeName"))
                        Me.TreeView1.Nodes(0).ExpandAll()
                    ElseIf (dt.Rows(j).Item("FormParent") = "Brokerage") Then
                        TreeView1.Nodes(i + 1).Nodes.Add(dt.Rows(j).Item("NodeName"))
                        Me.TreeView1.Nodes(1).ExpandAll()
                    ElseIf (dt.Rows(j).Item("FormParent") = "Billing") Then
                        TreeView1.Nodes(i + 2).Nodes.Add(dt.Rows(j).Item("NodeName"))
                        Me.TreeView1.Nodes(2).ExpandAll()
                    ElseIf (dt.Rows(j).Item("FormParent") = "Admin") Then
                        TreeView1.Nodes(i + 3).Nodes.Add(dt.Rows(j).Item("NodeName"))
                        Me.TreeView1.Nodes(3).ExpandAll()
                    End If
                End If

            Next




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub BindTreeViewForwarder()
        Dim connetionString = "Data Source=LAPTOP-SQ6GSPQV; Initial Catalog=FW;Integrated Security=True;"
        Dim conn As System.Data.SqlClient.SqlConnection = New SqlClient.SqlConnection(connetionString)
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        Dim pke(0) As DataColumn
        Dim i As Integer
        Dim j As Integer
        Try

            cmd.CommandText = "Select * from SCREEN "
            da.SelectCommand = cmd
            da.SelectCommand.Connection = conn
            da.Fill(dt)
            pke(0) = dt.Columns("ScreenID")
            dt.PrimaryKey = pke
            conn.Close()


            TreeView1.Nodes.Add("Forwarders")
            For j = 0 To dt.Rows.Count - 1

                TreeView1.Nodes(i).Nodes.Add(dt.Rows(j).Item("NodeName"))
            Next
            Me.TreeView1.Nodes(0).ExpandAll()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub BindTreeViewBrokerage()
        Dim connetionString = "Data Source=LAPTOP-SQ6GSPQV; Initial Catalog=FW;Integrated Security=True;"
        Dim conn As System.Data.SqlClient.SqlConnection = New SqlClient.SqlConnection(connetionString)
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        Dim pke(0) As DataColumn
        Dim i As Integer
        Dim j As Integer
        Try

            cmd.CommandText = "Select * from SCREEN where Status='Active' AND FormParent='Brokerage'"
            da.SelectCommand = cmd
            da.SelectCommand.Connection = conn
            da.Fill(dt)
            pke(0) = dt.Columns("ScreenID")
            dt.PrimaryKey = pke
            conn.Close()


            TreeView1.Nodes.Add("Brokerage")
            For j = 0 To dt.Rows.Count - 1
                TreeView1.Nodes(i).Nodes.Add(dt.Rows(j).Item("NodeName"))
            Next




            Me.TreeView1.Nodes(0).ExpandAll()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MDIForwarders_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.Control AndAlso e.KeyCode = Keys.N) Then
            Debug.Print("Call Save action here")
        End If
    End Sub
End Class
