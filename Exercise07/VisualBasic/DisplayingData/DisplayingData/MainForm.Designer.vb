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
        Me.axTOCControl1 = New ESRI.ArcGIS.Controls.AxTOCControl
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnRender = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblBreaks = New System.Windows.Forms.Label
        Me.cboBreaks = New System.Windows.Forms.ComboBox
        Me.cboNumericVals = New System.Windows.Forms.ComboBox
        Me.cboUniqueVals = New System.Windows.Forms.ComboBox
        Me.cboBlue = New System.Windows.Forms.ComboBox
        Me.lblB = New System.Windows.Forms.Label
        Me.cboGreen = New System.Windows.Forms.ComboBox
        Me.lblG = New System.Windows.Forms.Label
        Me.cboRed = New System.Windows.Forms.ComboBox
        Me.lblR = New System.Windows.Forms.Label
        Me.optBreaks = New System.Windows.Forms.RadioButton
        Me.optUnique = New System.Windows.Forms.RadioButton
        Me.optSimple = New System.Windows.Forms.RadioButton
        Me.cboLayer = New System.Windows.Forms.ComboBox
        Me.lblFLyr = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnStretch = New System.Windows.Forms.Button
        Me.btnScale = New System.Windows.Forms.Button
        Me.btnChangeRGBRenderer = New System.Windows.Forms.Button
        Me.btnSaveLayer = New System.Windows.Forms.Button
        CType(Me.axTOCControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.axLicenseControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.axMapControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        CType(Me.axToolbarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'axTOCControl1
        '
        Me.axTOCControl1.Location = New System.Drawing.Point(2, 58)
        Me.axTOCControl1.Name = "axTOCControl1"
        Me.axTOCControl1.OcxState = CType(resources.GetObject("axTOCControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axTOCControl1.Size = New System.Drawing.Size(173, 262)
        Me.axTOCControl1.TabIndex = 5
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
        Me.axMapControl1.Location = New System.Drawing.Point(179, 58)
        Me.axMapControl1.Name = "axMapControl1"
        Me.axMapControl1.OcxState = CType(resources.GetObject("axMapControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axMapControl1.Size = New System.Drawing.Size(301, 262)
        Me.axMapControl1.TabIndex = 3
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusBarXY})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 550)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(544, 22)
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
        Me.menuStrip1.Size = New System.Drawing.Size(544, 24)
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
        Me.axToolbarControl1.Location = New System.Drawing.Point(0, 24)
        Me.axToolbarControl1.Name = "axToolbarControl1"
        Me.axToolbarControl1.OcxState = CType(resources.GetObject("axToolbarControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axToolbarControl1.Size = New System.Drawing.Size(859, 28)
        Me.axToolbarControl1.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRender)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.lblBreaks)
        Me.GroupBox1.Controls.Add(Me.cboBreaks)
        Me.GroupBox1.Controls.Add(Me.cboNumericVals)
        Me.GroupBox1.Controls.Add(Me.cboUniqueVals)
        Me.GroupBox1.Controls.Add(Me.cboBlue)
        Me.GroupBox1.Controls.Add(Me.lblB)
        Me.GroupBox1.Controls.Add(Me.cboGreen)
        Me.GroupBox1.Controls.Add(Me.lblG)
        Me.GroupBox1.Controls.Add(Me.cboRed)
        Me.GroupBox1.Controls.Add(Me.lblR)
        Me.GroupBox1.Controls.Add(Me.optBreaks)
        Me.GroupBox1.Controls.Add(Me.optUnique)
        Me.GroupBox1.Controls.Add(Me.optSimple)
        Me.GroupBox1.Controls.Add(Me.cboLayer)
        Me.GroupBox1.Controls.Add(Me.lblFLyr)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 337)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 213)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'btnRender
        '
        Me.btnRender.Enabled = False
        Me.btnRender.Location = New System.Drawing.Point(233, 184)
        Me.btnRender.Name = "btnRender"
        Me.btnRender.Size = New System.Drawing.Size(75, 23)
        Me.btnRender.TabIndex = 16
        Me.btnRender.Text = "Render"
        Me.btnRender.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(7, 190)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblBreaks
        '
        Me.lblBreaks.AutoSize = True
        Me.lblBreaks.Enabled = False
        Me.lblBreaks.Location = New System.Drawing.Point(173, 164)
        Me.lblBreaks.Name = "lblBreaks"
        Me.lblBreaks.Size = New System.Drawing.Size(108, 13)
        Me.lblBreaks.TabIndex = 14
        Me.lblBreaks.Text = "equal-interval classes"
        '
        'cboBreaks
        '
        Me.cboBreaks.Enabled = False
        Me.cboBreaks.FormattingEnabled = True
        Me.cboBreaks.Location = New System.Drawing.Point(106, 161)
        Me.cboBreaks.Name = "cboBreaks"
        Me.cboBreaks.Size = New System.Drawing.Size(56, 21)
        Me.cboBreaks.TabIndex = 13
        Me.cboBreaks.Text = "5"
        '
        'cboNumericVals
        '
        Me.cboNumericVals.Enabled = False
        Me.cboNumericVals.FormattingEnabled = True
        Me.cboNumericVals.Location = New System.Drawing.Point(106, 124)
        Me.cboNumericVals.Name = "cboNumericVals"
        Me.cboNumericVals.Size = New System.Drawing.Size(203, 21)
        Me.cboNumericVals.TabIndex = 12
        '
        'cboUniqueVals
        '
        Me.cboUniqueVals.Enabled = False
        Me.cboUniqueVals.FormattingEnabled = True
        Me.cboUniqueVals.Location = New System.Drawing.Point(106, 90)
        Me.cboUniqueVals.Name = "cboUniqueVals"
        Me.cboUniqueVals.Size = New System.Drawing.Size(203, 21)
        Me.cboUniqueVals.TabIndex = 11
        '
        'cboBlue
        '
        Me.cboBlue.Enabled = False
        Me.cboBlue.FormattingEnabled = True
        Me.cboBlue.Location = New System.Drawing.Point(271, 56)
        Me.cboBlue.Name = "cboBlue"
        Me.cboBlue.Size = New System.Drawing.Size(38, 21)
        Me.cboBlue.TabIndex = 10
        '
        'lblB
        '
        Me.lblB.AutoSize = True
        Me.lblB.Enabled = False
        Me.lblB.Location = New System.Drawing.Point(248, 56)
        Me.lblB.Name = "lblB"
        Me.lblB.Size = New System.Drawing.Size(17, 13)
        Me.lblB.TabIndex = 9
        Me.lblB.Text = "B:"
        '
        'cboGreen
        '
        Me.cboGreen.Enabled = False
        Me.cboGreen.FormattingEnabled = True
        Me.cboGreen.Location = New System.Drawing.Point(196, 56)
        Me.cboGreen.Name = "cboGreen"
        Me.cboGreen.Size = New System.Drawing.Size(38, 21)
        Me.cboGreen.TabIndex = 8
        '
        'lblG
        '
        Me.lblG.AutoSize = True
        Me.lblG.Enabled = False
        Me.lblG.Location = New System.Drawing.Point(173, 56)
        Me.lblG.Name = "lblG"
        Me.lblG.Size = New System.Drawing.Size(18, 13)
        Me.lblG.TabIndex = 7
        Me.lblG.Text = "G:"
        '
        'cboRed
        '
        Me.cboRed.Enabled = False
        Me.cboRed.FormattingEnabled = True
        Me.cboRed.Location = New System.Drawing.Point(124, 56)
        Me.cboRed.Name = "cboRed"
        Me.cboRed.Size = New System.Drawing.Size(38, 21)
        Me.cboRed.TabIndex = 6
        '
        'lblR
        '
        Me.lblR.AutoSize = True
        Me.lblR.Enabled = False
        Me.lblR.Location = New System.Drawing.Point(103, 56)
        Me.lblR.Name = "lblR"
        Me.lblR.Size = New System.Drawing.Size(18, 13)
        Me.lblR.TabIndex = 5
        Me.lblR.Text = "R:"
        '
        'optBreaks
        '
        Me.optBreaks.AutoSize = True
        Me.optBreaks.Enabled = False
        Me.optBreaks.Location = New System.Drawing.Point(7, 124)
        Me.optBreaks.Name = "optBreaks"
        Me.optBreaks.Size = New System.Drawing.Size(86, 17)
        Me.optBreaks.TabIndex = 4
        Me.optBreaks.TabStop = True
        Me.optBreaks.Text = "Class Breaks"
        Me.optBreaks.UseVisualStyleBackColor = True
        '
        'optUnique
        '
        Me.optUnique.AutoSize = True
        Me.optUnique.Enabled = False
        Me.optUnique.Location = New System.Drawing.Point(7, 90)
        Me.optUnique.Name = "optUnique"
        Me.optUnique.Size = New System.Drawing.Size(89, 17)
        Me.optUnique.TabIndex = 3
        Me.optUnique.TabStop = True
        Me.optUnique.Text = "Unique Value"
        Me.optUnique.UseVisualStyleBackColor = True
        '
        'optSimple
        '
        Me.optSimple.AutoSize = True
        Me.optSimple.Enabled = False
        Me.optSimple.Location = New System.Drawing.Point(7, 56)
        Me.optSimple.Name = "optSimple"
        Me.optSimple.Size = New System.Drawing.Size(56, 17)
        Me.optSimple.TabIndex = 2
        Me.optSimple.TabStop = True
        Me.optSimple.Text = "Simple"
        Me.optSimple.UseVisualStyleBackColor = True
        '
        'cboLayer
        '
        Me.cboLayer.FormattingEnabled = True
        Me.cboLayer.Location = New System.Drawing.Point(103, 15)
        Me.cboLayer.Name = "cboLayer"
        Me.cboLayer.Size = New System.Drawing.Size(206, 21)
        Me.cboLayer.TabIndex = 1
        '
        'lblFLyr
        '
        Me.lblFLyr.AutoSize = True
        Me.lblFLyr.Location = New System.Drawing.Point(7, 15)
        Me.lblFLyr.Name = "lblFLyr"
        Me.lblFLyr.Size = New System.Drawing.Size(72, 13)
        Me.lblFLyr.TabIndex = 0
        Me.lblFLyr.Text = "Feature Layer"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnStretch)
        Me.GroupBox2.Controls.Add(Me.btnScale)
        Me.GroupBox2.Controls.Add(Me.btnChangeRGBRenderer)
        Me.GroupBox2.Controls.Add(Me.btnSaveLayer)
        Me.GroupBox2.Location = New System.Drawing.Point(327, 337)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(153, 213)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'btnStretch
        '
        Me.btnStretch.Location = New System.Drawing.Point(15, 141)
        Me.btnStretch.Name = "btnStretch"
        Me.btnStretch.Size = New System.Drawing.Size(121, 23)
        Me.btnStretch.TabIndex = 4
        Me.btnStretch.Text = "Stretch Raster"
        Me.btnStretch.UseVisualStyleBackColor = True
        '
        'btnScale
        '
        Me.btnScale.Location = New System.Drawing.Point(15, 112)
        Me.btnScale.Name = "btnScale"
        Me.btnScale.Size = New System.Drawing.Size(121, 23)
        Me.btnScale.TabIndex = 3
        Me.btnScale.Text = "Scale Dependent"
        Me.btnScale.UseVisualStyleBackColor = True
        '
        'btnChangeRGBRenderer
        '
        Me.btnChangeRGBRenderer.Location = New System.Drawing.Point(15, 83)
        Me.btnChangeRGBRenderer.Name = "btnChangeRGBRenderer"
        Me.btnChangeRGBRenderer.Size = New System.Drawing.Size(121, 23)
        Me.btnChangeRGBRenderer.TabIndex = 2
        Me.btnChangeRGBRenderer.Text = "Change RGB Raster"
        Me.btnChangeRGBRenderer.UseVisualStyleBackColor = True
        '
        'btnSaveLayer
        '
        Me.btnSaveLayer.Location = New System.Drawing.Point(15, 54)
        Me.btnSaveLayer.Name = "btnSaveLayer"
        Me.btnSaveLayer.Size = New System.Drawing.Size(121, 23)
        Me.btnSaveLayer.TabIndex = 1
        Me.btnSaveLayer.Text = "Save Layer"
        Me.btnSaveLayer.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 572)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.axLicenseControl1)
        Me.Controls.Add(Me.axMapControl1)
        Me.Controls.Add(Me.axTOCControl1)
        Me.Controls.Add(Me.axToolbarControl1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "MainForm"
        Me.Text = "ArcEngine Controls Application"
        CType(Me.axTOCControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.axLicenseControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.axMapControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.axToolbarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optBreaks As System.Windows.Forms.RadioButton
    Friend WithEvents optUnique As System.Windows.Forms.RadioButton
    Friend WithEvents optSimple As System.Windows.Forms.RadioButton
    Friend WithEvents cboLayer As System.Windows.Forms.ComboBox
    Friend WithEvents lblFLyr As System.Windows.Forms.Label
    Friend WithEvents cboRed As System.Windows.Forms.ComboBox
    Friend WithEvents lblR As System.Windows.Forms.Label
    Friend WithEvents cboBlue As System.Windows.Forms.ComboBox
    Friend WithEvents lblB As System.Windows.Forms.Label
    Friend WithEvents cboGreen As System.Windows.Forms.ComboBox
    Friend WithEvents lblG As System.Windows.Forms.Label
    Friend WithEvents btnRender As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblBreaks As System.Windows.Forms.Label
    Friend WithEvents cboBreaks As System.Windows.Forms.ComboBox
    Friend WithEvents cboNumericVals As System.Windows.Forms.ComboBox
    Friend WithEvents cboUniqueVals As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStretch As System.Windows.Forms.Button
    Friend WithEvents btnScale As System.Windows.Forms.Button
    Friend WithEvents btnChangeRGBRenderer As System.Windows.Forms.Button
    Friend WithEvents btnSaveLayer As System.Windows.Forms.Button
End Class
