<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaster))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.flowPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.RedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YellowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxColors = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IndigoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ctxColors.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.btnExit, "btnExit")
        Me.btnExit.Name = "btnExit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'flowPanel
        '
        Me.flowPanel.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.flowPanel, "flowPanel")
        Me.flowPanel.Name = "flowPanel"
        '
        'btnCheck
        '
        Me.btnCheck.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.btnCheck, "btnCheck")
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.UseVisualStyleBackColor = False
        '
        'RedToolStripMenuItem
        '
        Me.RedToolStripMenuItem.BackColor = System.Drawing.Color.Red
        Me.RedToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.RedToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.RedToolStripMenuItem.Name = "RedToolStripMenuItem"
        resources.ApplyResources(Me.RedToolStripMenuItem, "RedToolStripMenuItem")
        '
        'OrangeToolStripMenuItem
        '
        Me.OrangeToolStripMenuItem.BackColor = System.Drawing.Color.Orange
        Me.OrangeToolStripMenuItem.ForeColor = System.Drawing.Color.Orange
        Me.OrangeToolStripMenuItem.Name = "OrangeToolStripMenuItem"
        resources.ApplyResources(Me.OrangeToolStripMenuItem, "OrangeToolStripMenuItem")
        '
        'YellowToolStripMenuItem
        '
        Me.YellowToolStripMenuItem.BackColor = System.Drawing.Color.Yellow
        Me.YellowToolStripMenuItem.Name = "YellowToolStripMenuItem"
        resources.ApplyResources(Me.YellowToolStripMenuItem, "YellowToolStripMenuItem")
        '
        'GreenToolStripMenuItem
        '
        Me.GreenToolStripMenuItem.BackColor = System.Drawing.Color.Green
        Me.GreenToolStripMenuItem.Name = "GreenToolStripMenuItem"
        resources.ApplyResources(Me.GreenToolStripMenuItem, "GreenToolStripMenuItem")
        '
        'BlueToolStripMenuItem
        '
        Me.BlueToolStripMenuItem.BackColor = System.Drawing.Color.Blue
        Me.BlueToolStripMenuItem.Name = "BlueToolStripMenuItem"
        resources.ApplyResources(Me.BlueToolStripMenuItem, "BlueToolStripMenuItem")
        '
        'ctxColors
        '
        Me.ctxColors.BackColor = System.Drawing.SystemColors.Control
        Me.ctxColors.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RedToolStripMenuItem, Me.OrangeToolStripMenuItem, Me.YellowToolStripMenuItem, Me.GreenToolStripMenuItem, Me.BlueToolStripMenuItem, Me.IndigoToolStripMenuItem})
        Me.ctxColors.Name = "ctxColors"
        resources.ApplyResources(Me.ctxColors, "ctxColors")
        Me.ctxColors.TabStop = True
        '
        'IndigoToolStripMenuItem
        '
        Me.IndigoToolStripMenuItem.BackColor = System.Drawing.Color.Indigo
        Me.IndigoToolStripMenuItem.Name = "IndigoToolStripMenuItem"
        resources.ApplyResources(Me.IndigoToolStripMenuItem, "IndigoToolStripMenuItem")
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.btnReset, "btnReset")
        Me.btnReset.Name = "btnReset"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoCheck = False
        resources.ApplyResources(Me.CheckBox3, "CheckBox3")
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoCheck = False
        resources.ApplyResources(Me.CheckBox2, "CheckBox2")
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoCheck = False
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmMaster
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.flowPanel)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMaster"
        Me.ShowIcon = False
        Me.ctxColors.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents flowPanel As FlowLayoutPanel
    Friend WithEvents btnCheck As Button
    Friend WithEvents ctxColors As ContextMenuStrip
    Friend WithEvents BlueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GreenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents YellowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrangeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IndigoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnReset As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
