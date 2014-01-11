<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.IPAddress_Label = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Port_Label = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GPU_Label = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StopStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QuitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Settings_GroupBox = New System.Windows.Forms.GroupBox
        Me.Enable_Memory_Check = New System.Windows.Forms.CheckBox
        Me.Enable_Engine_Check = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.ResultsPage = New System.Windows.Forms.TabPage
        Me.Results_ListView = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.GPUPage = New System.Windows.Forms.TabPage
        Me.GPU_ListView = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.GPUTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Engine_Min_Label = New System.Windows.Forms.TextBox
        Me.Engine_Max_Label = New System.Windows.Forms.TextBox
        Me.Engine_Step_Label = New System.Windows.Forms.TextBox
        Me.Memory_Min_Label = New System.Windows.Forms.TextBox
        Me.Memory_Max_Label = New System.Windows.Forms.TextBox
        Me.Memory_Step_Label = New System.Windows.Forms.TextBox
        Me.Wait_Label = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.Settings_GroupBox.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.ResultsPage.SuspendLayout()
        Me.GPUPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'IPAddress_Label
        '
        Me.IPAddress_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IPAddress_Label.Location = New System.Drawing.Point(84, 30)
        Me.IPAddress_Label.Name = "IPAddress_Label"
        Me.IPAddress_Label.Size = New System.Drawing.Size(68, 20)
        Me.IPAddress_Label.TabIndex = 0
        Me.IPAddress_Label.Text = "127.0.0.1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP Address:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(169, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Port:"
        '
        'Port_Label
        '
        Me.Port_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Port_Label.Location = New System.Drawing.Point(204, 30)
        Me.Port_Label.Name = "Port_Label"
        Me.Port_Label.Size = New System.Drawing.Size(48, 20)
        Me.Port_Label.TabIndex = 1
        Me.Port_Label.Text = "4028"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "GPU:"
        '
        'GPU_Label
        '
        Me.GPU_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GPU_Label.Location = New System.Drawing.Point(56, 63)
        Me.GPU_Label.Name = "GPU_Label"
        Me.GPU_Label.Size = New System.Drawing.Size(37, 20)
        Me.GPU_Label.TabIndex = 2
        Me.GPU_Label.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Engine Clock (MHz):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(163, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Min:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(254, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Max:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(350, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Step:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(468, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem, Me.StopStripMenuItem1, Me.ViewLogToolStripMenuItem, Me.QuitToolStripMenuItem2})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.StartToolStripMenuItem.Text = "&Start"
        '
        'StopStripMenuItem1
        '
        Me.StopStripMenuItem1.Name = "StopStripMenuItem1"
        Me.StopStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.StopStripMenuItem1.Size = New System.Drawing.Size(128, 22)
        Me.StopStripMenuItem1.Text = "Sto&p"
        '
        'ViewLogToolStripMenuItem
        '
        Me.ViewLogToolStripMenuItem.Name = "ViewLogToolStripMenuItem"
        Me.ViewLogToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ViewLogToolStripMenuItem.Text = "View Log"
        '
        'QuitToolStripMenuItem2
        '
        Me.QuitToolStripMenuItem2.Name = "QuitToolStripMenuItem2"
        Me.QuitToolStripMenuItem2.Size = New System.Drawing.Size(128, 22)
        Me.QuitToolStripMenuItem2.Text = "Quit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(114, 22)
        Me.AboutToolStripMenuItem1.Text = "&About"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(350, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Step:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(254, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Max:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(163, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Min:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(39, 117)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Memory Clock (MHz):"
        '
        'Settings_GroupBox
        '
        Me.Settings_GroupBox.Controls.Add(Me.Wait_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Memory_Step_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Memory_Max_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Memory_Min_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Engine_Step_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Engine_Max_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Engine_Min_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Enable_Memory_Check)
        Me.Settings_GroupBox.Controls.Add(Me.Enable_Engine_Check)
        Me.Settings_GroupBox.Controls.Add(Me.Label12)
        Me.Settings_GroupBox.Controls.Add(Me.IPAddress_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Label1)
        Me.Settings_GroupBox.Controls.Add(Me.Label8)
        Me.Settings_GroupBox.Controls.Add(Me.Label2)
        Me.Settings_GroupBox.Controls.Add(Me.Port_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Label9)
        Me.Settings_GroupBox.Controls.Add(Me.Label3)
        Me.Settings_GroupBox.Controls.Add(Me.GPU_Label)
        Me.Settings_GroupBox.Controls.Add(Me.Label10)
        Me.Settings_GroupBox.Controls.Add(Me.Label4)
        Me.Settings_GroupBox.Controls.Add(Me.Label11)
        Me.Settings_GroupBox.Controls.Add(Me.Label5)
        Me.Settings_GroupBox.Controls.Add(Me.Label7)
        Me.Settings_GroupBox.Controls.Add(Me.Label6)
        Me.Settings_GroupBox.Location = New System.Drawing.Point(12, 38)
        Me.Settings_GroupBox.Name = "Settings_GroupBox"
        Me.Settings_GroupBox.Size = New System.Drawing.Size(445, 173)
        Me.Settings_GroupBox.TabIndex = 22
        Me.Settings_GroupBox.TabStop = False
        Me.Settings_GroupBox.Text = "Settings"
        '
        'Enable_Memory_Check
        '
        Me.Enable_Memory_Check.AutoSize = True
        Me.Enable_Memory_Check.Checked = True
        Me.Enable_Memory_Check.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Enable_Memory_Check.Location = New System.Drawing.Point(20, 116)
        Me.Enable_Memory_Check.Name = "Enable_Memory_Check"
        Me.Enable_Memory_Check.Size = New System.Drawing.Size(15, 14)
        Me.Enable_Memory_Check.TabIndex = 25
        Me.Enable_Memory_Check.UseVisualStyleBackColor = True
        '
        'Enable_Engine_Check
        '
        Me.Enable_Engine_Check.AutoSize = True
        Me.Enable_Engine_Check.Checked = True
        Me.Enable_Engine_Check.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Enable_Engine_Check.Location = New System.Drawing.Point(20, 95)
        Me.Enable_Engine_Check.Name = "Enable_Engine_Check"
        Me.Enable_Engine_Check.Size = New System.Drawing.Size(15, 14)
        Me.Enable_Engine_Check.TabIndex = 24
        Me.Enable_Engine_Check.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(350, 139)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Wait:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 478)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(468, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 25
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.ResultsPage)
        Me.TabControl1.Controls.Add(Me.GPUPage)
        Me.TabControl1.Location = New System.Drawing.Point(12, 217)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(445, 252)
        Me.TabControl1.TabIndex = 26
        '
        'ResultsPage
        '
        Me.ResultsPage.Controls.Add(Me.Results_ListView)
        Me.ResultsPage.Location = New System.Drawing.Point(4, 22)
        Me.ResultsPage.Name = "ResultsPage"
        Me.ResultsPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ResultsPage.Size = New System.Drawing.Size(437, 226)
        Me.ResultsPage.TabIndex = 1
        Me.ResultsPage.Text = "Results"
        Me.ResultsPage.UseVisualStyleBackColor = True
        '
        'Results_ListView
        '
        Me.Results_ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6})
        Me.Results_ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.Results_ListView.Location = New System.Drawing.Point(6, 6)
        Me.Results_ListView.Name = "Results_ListView"
        Me.Results_ListView.Size = New System.Drawing.Size(428, 210)
        Me.Results_ListView.TabIndex = 0
        Me.Results_ListView.UseCompatibleStateImageBehavior = False
        Me.Results_ListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Engine (MHz)"
        Me.ColumnHeader1.Width = 83
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Memory (MHz)"
        Me.ColumnHeader2.Width = 84
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Hash Rate (Mh/s)"
        Me.ColumnHeader3.Width = 105
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "HW Errors"
        Me.ColumnHeader6.Width = 152
        '
        'GPUPage
        '
        Me.GPUPage.Controls.Add(Me.GPU_ListView)
        Me.GPUPage.Location = New System.Drawing.Point(4, 22)
        Me.GPUPage.Name = "GPUPage"
        Me.GPUPage.Padding = New System.Windows.Forms.Padding(3)
        Me.GPUPage.Size = New System.Drawing.Size(437, 226)
        Me.GPUPage.TabIndex = 0
        Me.GPUPage.Text = "GPU"
        Me.GPUPage.UseVisualStyleBackColor = True
        '
        'GPU_ListView
        '
        Me.GPU_ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5})
        Me.GPU_ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.GPU_ListView.Location = New System.Drawing.Point(6, 6)
        Me.GPU_ListView.Name = "GPU_ListView"
        Me.GPU_ListView.Size = New System.Drawing.Size(428, 210)
        Me.GPU_ListView.TabIndex = 1
        Me.GPU_ListView.UseCompatibleStateImageBehavior = False
        Me.GPU_ListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Parameter"
        Me.ColumnHeader4.Width = 190
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Value"
        Me.ColumnHeader5.Width = 236
        '
        'GPUTimer
        '
        Me.GPUTimer.Enabled = True
        Me.GPUTimer.Interval = 1000
        '
        'Engine_Min_Label
        '
        Me.Engine_Min_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Engine_Min_Label.Location = New System.Drawing.Point(194, 93)
        Me.Engine_Min_Label.Name = "Engine_Min_Label"
        Me.Engine_Min_Label.Size = New System.Drawing.Size(54, 20)
        Me.Engine_Min_Label.TabIndex = 4
        Me.Engine_Min_Label.Text = "900"
        '
        'Engine_Max_Label
        '
        Me.Engine_Max_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Engine_Max_Label.Location = New System.Drawing.Point(290, 93)
        Me.Engine_Max_Label.Name = "Engine_Max_Label"
        Me.Engine_Max_Label.Size = New System.Drawing.Size(54, 20)
        Me.Engine_Max_Label.TabIndex = 5
        Me.Engine_Max_Label.Text = "1000"
        '
        'Engine_Step_Label
        '
        Me.Engine_Step_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Engine_Step_Label.Location = New System.Drawing.Point(388, 93)
        Me.Engine_Step_Label.Name = "Engine_Step_Label"
        Me.Engine_Step_Label.Size = New System.Drawing.Size(41, 20)
        Me.Engine_Step_Label.TabIndex = 6
        Me.Engine_Step_Label.Text = "5"
        '
        'Memory_Min_Label
        '
        Me.Memory_Min_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Memory_Min_Label.Location = New System.Drawing.Point(194, 115)
        Me.Memory_Min_Label.Name = "Memory_Min_Label"
        Me.Memory_Min_Label.Size = New System.Drawing.Size(54, 20)
        Me.Memory_Min_Label.TabIndex = 7
        Me.Memory_Min_Label.Text = "1200"
        '
        'Memory_Max_Label
        '
        Me.Memory_Max_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Memory_Max_Label.Location = New System.Drawing.Point(290, 115)
        Me.Memory_Max_Label.Name = "Memory_Max_Label"
        Me.Memory_Max_Label.Size = New System.Drawing.Size(54, 20)
        Me.Memory_Max_Label.TabIndex = 8
        Me.Memory_Max_Label.Text = "1250"
        '
        'Memory_Step_Label
        '
        Me.Memory_Step_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Memory_Step_Label.Location = New System.Drawing.Point(388, 115)
        Me.Memory_Step_Label.Name = "Memory_Step_Label"
        Me.Memory_Step_Label.Size = New System.Drawing.Size(41, 20)
        Me.Memory_Step_Label.TabIndex = 9
        Me.Memory_Step_Label.Text = "5"
        '
        'Wait_Label
        '
        Me.Wait_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Wait_Label.Location = New System.Drawing.Point(388, 137)
        Me.Wait_Label.Name = "Wait_Label"
        Me.Wait_Label.Size = New System.Drawing.Size(41, 20)
        Me.Wait_Label.TabIndex = 10
        Me.Wait_Label.Text = "30"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 500)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Settings_GroupBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CGBenchmark"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Settings_GroupBox.ResumeLayout(False)
        Me.Settings_GroupBox.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResultsPage.ResumeLayout(False)
        Me.GPUPage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IPAddress_Label As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Port_Label As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GPU_Label As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents AboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Settings_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents StopStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ViewLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Enable_Memory_Check As System.Windows.Forms.CheckBox
    Friend WithEvents Enable_Engine_Check As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents GPUPage As System.Windows.Forms.TabPage
    Friend WithEvents ResultsPage As System.Windows.Forms.TabPage
    Friend WithEvents GPUTimer As System.Windows.Forms.Timer
    Friend WithEvents Results_ListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GPU_ListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Engine_Max_Label As System.Windows.Forms.TextBox
    Friend WithEvents Engine_Min_Label As System.Windows.Forms.TextBox
    Friend WithEvents Wait_Label As System.Windows.Forms.TextBox
    Friend WithEvents Memory_Step_Label As System.Windows.Forms.TextBox
    Friend WithEvents Memory_Max_Label As System.Windows.Forms.TextBox
    Friend WithEvents Memory_Min_Label As System.Windows.Forms.TextBox
    Friend WithEvents Engine_Step_Label As System.Windows.Forms.TextBox

End Class
