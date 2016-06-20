<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        'Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
        'Failure to do this may result in random crashes on exit due to the operating system unloading 
        'the libraries in the incorrect order. 
        ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown()

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.axTOCControl1 = New ESRI.ArcGIS.Controls.AxTOCControl
        Me.btnSelectCities = New System.Windows.Forms.Button
        Me.btnLandLocked = New System.Windows.Forms.Button
        Me.btnSpatialFilter = New System.Windows.Forms.Button
        Me.axLicenseControl1 = New ESRI.ArcGIS.Controls.AxLicenseControl
        Me.axMapControl1 = New ESRI.ArcGIS.Controls.AxMapControl
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip
        Me.statusBarXY = New System.Windows.Forms.ToolStripStatusLabel
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.menuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.menuNewDoc = New System.Windows.Forms.ToolStripMenuItem
        Me.menuOpenDoc = New System.Windows.Forms.ToolStripMenuItem
        Me.menuSaveDoc = New System.Windows.Forms.ToolStripMenuItem
        Me.menuSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.menuSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.menuExitApp = New System.Windows.Forms.ToolStripMenuItem
        Me.axToolbarControl1 = New ESRI.ArcGIS.Controls.AxToolbarControl
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.axTOCControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.axLicenseControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.axMapControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        CType(Me.axToolbarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 52)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.axTOCControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSelectCities)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnLandLocked)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSpatialFilter)
        Me.SplitContainer1.Panel2.Controls.Add(Me.axLicenseControl1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.axMapControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(744, 354)
        Me.SplitContainer1.SplitterDistance = 169
        Me.SplitContainer1.TabIndex = 0
        '
        'axTOCControl1
        '
        Me.axTOCControl1.Location = New System.Drawing.Point(3, 3)
        Me.axTOCControl1.Name = "axTOCControl1"
        Me.axTOCControl1.OcxState = CType(resources.GetObject("axTOCControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axTOCControl1.Size = New System.Drawing.Size(192, 349)
        Me.axTOCControl1.TabIndex = 5
        '
        'btnSelectCities
        '
        Me.btnSelectCities.Location = New System.Drawing.Point(483, 91)
        Me.btnSelectCities.Name = "btnSelectCities"
        Me.btnSelectCities.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectCities.TabIndex = 9
        Me.btnSelectCities.Text = "Select Cities"
        Me.btnSelectCities.UseVisualStyleBackColor = True
        '
        'btnLandLocked
        '
        Me.btnLandLocked.Location = New System.Drawing.Point(483, 6)
        Me.btnLandLocked.Name = "btnLandLocked"
        Me.btnLandLocked.Size = New System.Drawing.Size(75, 23)
        Me.btnLandLocked.TabIndex = 8
        Me.btnLandLocked.Text = "Landlocked"
        Me.btnLandLocked.UseVisualStyleBackColor = True
        '
        'btnSpatialFilter
        '
        Me.btnSpatialFilter.Location = New System.Drawing.Point(483, 47)
        Me.btnSpatialFilter.Name = "btnSpatialFilter"
        Me.btnSpatialFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnSpatialFilter.TabIndex = 7
        Me.btnSpatialFilter.Text = "Spatial Filter"
        Me.btnSpatialFilter.UseVisualStyleBackColor = True
        '
        'axLicenseControl1
        '
        Me.axLicenseControl1.Enabled = True
        Me.axLicenseControl1.Location = New System.Drawing.Point(123, 150)
        Me.axLicenseControl1.Name = "axLicenseControl1"
        Me.axLicenseControl1.OcxState = CType(resources.GetObject("axLicenseControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axLicenseControl1.Size = New System.Drawing.Size(32, 32)
        Me.axLicenseControl1.TabIndex = 6
        '
        'axMapControl1
        '
        Me.axMapControl1.Location = New System.Drawing.Point(3, 3)
        Me.axMapControl1.Name = "axMapControl1"
        Me.axMapControl1.OcxState = CType(resources.GetObject("axMapControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axMapControl1.Size = New System.Drawing.Size(456, 349)
        Me.axMapControl1.TabIndex = 3
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusBarXY})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 406)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(744, 22)
        Me.statusStrip1.Stretch = False
        Me.statusStrip1.TabIndex = 8
        Me.statusStrip1.Text = "statusBar1"
        '
        'statusBarXY
        '
        Me.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.statusBarXY.Name = "statusBarXY"
        Me.statusBarXY.Size = New System.Drawing.Size(49, 17)
        Me.statusBarXY.Text = "Test 123"
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuFile})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(744, 24)
        Me.menuStrip1.TabIndex = 9
        Me.menuStrip1.Text = "menuStrip1"
        '
        'menuFile
        '
        Me.menuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuNewDoc, Me.menuOpenDoc, Me.menuSaveDoc, Me.menuSaveAs, Me.menuSeparator, Me.menuExitApp})
        Me.menuFile.Name = "menuFile"
        Me.menuFile.Size = New System.Drawing.Size(35, 20)
        Me.menuFile.Text = "File"
        '
        'menuNewDoc
        '
        Me.menuNewDoc.Image = CType(resources.GetObject("menuNewDoc.Image"), System.Drawing.Image)
        Me.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White
        Me.menuNewDoc.Name = "menuNewDoc"
        Me.menuNewDoc.Size = New System.Drawing.Size(174, 22)
        Me.menuNewDoc.Text = "New Document"
        '
        'menuOpenDoc
        '
        Me.menuOpenDoc.Image = CType(resources.GetObject("menuOpenDoc.Image"), System.Drawing.Image)
        Me.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White
        Me.menuOpenDoc.Name = "menuOpenDoc"
        Me.menuOpenDoc.Size = New System.Drawing.Size(174, 22)
        Me.menuOpenDoc.Text = "Open Document..."
        '
        'menuSaveDoc
        '
        Me.menuSaveDoc.Image = CType(resources.GetObject("menuSaveDoc.Image"), System.Drawing.Image)
        Me.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White
        Me.menuSaveDoc.Name = "menuSaveDoc"
        Me.menuSaveDoc.Size = New System.Drawing.Size(174, 22)
        Me.menuSaveDoc.Text = "SaveDocument"
        '
        'menuSaveAs
        '
        Me.menuSaveAs.Name = "menuSaveAs"
        Me.menuSaveAs.Size = New System.Drawing.Size(174, 22)
        Me.menuSaveAs.Text = "Save As..."
        '
        'menuSeparator
        '
        Me.menuSeparator.Name = "menuSeparator"
        Me.menuSeparator.Size = New System.Drawing.Size(171, 6)
        '
        'menuExitApp
        '
        Me.menuExitApp.Name = "menuExitApp"
        Me.menuExitApp.Size = New System.Drawing.Size(174, 22)
        Me.menuExitApp.Text = "Exit"
        '
        'axToolbarControl1
        '
        Me.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.axToolbarControl1.Location = New System.Drawing.Point(0, 24)
        Me.axToolbarControl1.Name = "axToolbarControl1"
        Me.axToolbarControl1.OcxState = CType(resources.GetObject("axToolbarControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axToolbarControl1.Size = New System.Drawing.Size(744, 28)
        Me.axToolbarControl1.TabIndex = 10
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 428)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.axToolbarControl1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "MainForm"
        Me.Text = "ArcEngine Controls Application"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.axTOCControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.axLicenseControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.axMapControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.axToolbarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents statusBarXY As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents menuFile As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuNewDoc As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuOpenDoc As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuSaveDoc As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuSaveAs As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuSeparator As System.Windows.Forms.ToolStripSeparator
    Private WithEvents menuExitApp As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents axToolbarControl1 As ESRI.ArcGIS.Controls.AxToolbarControl
    Private WithEvents axTOCControl1 As ESRI.ArcGIS.Controls.AxTOCControl
    Private WithEvents axMapControl1 As ESRI.ArcGIS.Controls.AxMapControl
    Private WithEvents axLicenseControl1 As ESRI.ArcGIS.Controls.AxLicenseControl
    Friend WithEvents btnLandLocked As System.Windows.Forms.Button
    Friend WithEvents btnSpatialFilter As System.Windows.Forms.Button
    Friend WithEvents btnSelectCities As System.Windows.Forms.Button
End Class
