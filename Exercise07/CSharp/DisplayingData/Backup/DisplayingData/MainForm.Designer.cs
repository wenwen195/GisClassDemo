namespace DisplayingData
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblBreaks = new System.Windows.Forms.Label();
            this.cboBreaks = new System.Windows.Forms.ComboBox();
            this.cboNumericVals = new System.Windows.Forms.ComboBox();
            this.cboUniqueVals = new System.Windows.Forms.ComboBox();
            this.cboBlue = new System.Windows.Forms.ComboBox();
            this.cboGreen = new System.Windows.Forms.ComboBox();
            this.cboRed = new System.Windows.Forms.ComboBox();
            this.lblB = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.optBreaks = new System.Windows.Forms.RadioButton();
            this.optUnique = new System.Windows.Forms.RadioButton();
            this.optSimple = new System.Windows.Forms.RadioButton();
            this.cboLayer = new System.Windows.Forms.ComboBox();
            this.lblFLyr = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStretch = new System.Windows.Forms.Button();
            this.btnScale = new System.Windows.Forms.Button();
            this.btnChangeRGBRenderer = new System.Windows.Forms.Button();
            this.btnSaveLayer = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(546, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "File";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(174, 22);
            this.menuNewDoc.Text = "New Document";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(174, 22);
            this.menuOpenDoc.Text = "Open Document...";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(174, 22);
            this.menuSaveDoc.Text = "SaveDocument";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(174, 22);
            this.menuSaveAs.Text = "Save As...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(171, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(174, 22);
            this.menuExitApp.Text = "Exit";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(179, 52);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(301, 262);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 24);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(546, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(3, 52);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(173, 262);
            this.axTOCControl1.TabIndex = 4;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(245, 257);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 52);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 530);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(3, 560);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(543, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(49, 17);
            this.statusBarXY.Text = "Test 123";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRender);
            this.groupBox1.Controls.Add(this.lblBreaks);
            this.groupBox1.Controls.Add(this.cboBreaks);
            this.groupBox1.Controls.Add(this.cboNumericVals);
            this.groupBox1.Controls.Add(this.cboUniqueVals);
            this.groupBox1.Controls.Add(this.cboBlue);
            this.groupBox1.Controls.Add(this.cboGreen);
            this.groupBox1.Controls.Add(this.cboRed);
            this.groupBox1.Controls.Add(this.lblB);
            this.groupBox1.Controls.Add(this.lblG);
            this.groupBox1.Controls.Add(this.lblR);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.optBreaks);
            this.groupBox1.Controls.Add(this.optUnique);
            this.groupBox1.Controls.Add(this.optSimple);
            this.groupBox1.Controls.Add(this.cboLayer);
            this.groupBox1.Controls.Add(this.lblFLyr);
            this.groupBox1.Location = new System.Drawing.Point(6, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 213);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(227, 182);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(75, 23);
            this.btnRender.TabIndex = 16;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblBreaks
            // 
            this.lblBreaks.AutoSize = true;
            this.lblBreaks.Location = new System.Drawing.Point(179, 166);
            this.lblBreaks.Name = "lblBreaks";
            this.lblBreaks.Size = new System.Drawing.Size(108, 13);
            this.lblBreaks.TabIndex = 15;
            this.lblBreaks.Text = "equal-interval classes";
            // 
            // cboBreaks
            // 
            this.cboBreaks.FormattingEnabled = true;
            this.cboBreaks.Location = new System.Drawing.Point(109, 162);
            this.cboBreaks.Name = "cboBreaks";
            this.cboBreaks.Size = new System.Drawing.Size(55, 21);
            this.cboBreaks.TabIndex = 14;
            this.cboBreaks.Text = "5";
            // 
            // cboNumericVals
            // 
            this.cboNumericVals.FormattingEnabled = true;
            this.cboNumericVals.Location = new System.Drawing.Point(98, 126);
            this.cboNumericVals.Name = "cboNumericVals";
            this.cboNumericVals.Size = new System.Drawing.Size(204, 21);
            this.cboNumericVals.TabIndex = 13;
            // 
            // cboUniqueVals
            // 
            this.cboUniqueVals.FormattingEnabled = true;
            this.cboUniqueVals.Location = new System.Drawing.Point(98, 90);
            this.cboUniqueVals.Name = "cboUniqueVals";
            this.cboUniqueVals.Size = new System.Drawing.Size(204, 21);
            this.cboUniqueVals.TabIndex = 12;
            // 
            // cboBlue
            // 
            this.cboBlue.Enabled = false;
            this.cboBlue.FormattingEnabled = true;
            this.cboBlue.Location = new System.Drawing.Point(261, 56);
            this.cboBlue.Name = "cboBlue";
            this.cboBlue.Size = new System.Drawing.Size(41, 21);
            this.cboBlue.TabIndex = 11;
            // 
            // cboGreen
            // 
            this.cboGreen.Enabled = false;
            this.cboGreen.FormattingEnabled = true;
            this.cboGreen.Location = new System.Drawing.Point(193, 56);
            this.cboGreen.Name = "cboGreen";
            this.cboGreen.Size = new System.Drawing.Size(41, 21);
            this.cboGreen.TabIndex = 10;
            // 
            // cboRed
            // 
            this.cboRed.Enabled = false;
            this.cboRed.FormattingEnabled = true;
            this.cboRed.Location = new System.Drawing.Point(123, 56);
            this.cboRed.Name = "cboRed";
            this.cboRed.Size = new System.Drawing.Size(41, 21);
            this.cboRed.TabIndex = 9;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Enabled = false;
            this.lblB.Location = new System.Drawing.Point(238, 57);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(17, 13);
            this.lblB.TabIndex = 8;
            this.lblB.Text = "B:";
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Enabled = false;
            this.lblG.Location = new System.Drawing.Point(172, 57);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(18, 13);
            this.lblG.TabIndex = 7;
            this.lblG.Text = "G:";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Enabled = false;
            this.lblR.Location = new System.Drawing.Point(95, 57);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(18, 13);
            this.lblR.TabIndex = 6;
            this.lblR.Text = "R:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(10, 182);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // optBreaks
            // 
            this.optBreaks.AutoSize = true;
            this.optBreaks.Location = new System.Drawing.Point(7, 126);
            this.optBreaks.Name = "optBreaks";
            this.optBreaks.Size = new System.Drawing.Size(86, 17);
            this.optBreaks.TabIndex = 4;
            this.optBreaks.TabStop = true;
            this.optBreaks.Text = "Class Breaks";
            this.optBreaks.UseVisualStyleBackColor = true;
            this.optBreaks.CheckedChanged += new System.EventHandler(this.optBreaks_CheckedChanged);
            // 
            // optUnique
            // 
            this.optUnique.AutoSize = true;
            this.optUnique.Location = new System.Drawing.Point(10, 90);
            this.optUnique.Name = "optUnique";
            this.optUnique.Size = new System.Drawing.Size(89, 17);
            this.optUnique.TabIndex = 3;
            this.optUnique.TabStop = true;
            this.optUnique.Text = "Unique Value";
            this.optUnique.UseVisualStyleBackColor = true;
            this.optUnique.CheckedChanged += new System.EventHandler(this.optUnique_CheckedChanged);
            // 
            // optSimple
            // 
            this.optSimple.AutoSize = true;
            this.optSimple.Location = new System.Drawing.Point(10, 57);
            this.optSimple.Name = "optSimple";
            this.optSimple.Size = new System.Drawing.Size(56, 17);
            this.optSimple.TabIndex = 2;
            this.optSimple.TabStop = true;
            this.optSimple.Text = "Simple";
            this.optSimple.UseVisualStyleBackColor = true;
            this.optSimple.CheckedChanged += new System.EventHandler(this.optSimple_CheckedChanged);
            // 
            // cboLayer
            // 
            this.cboLayer.FormattingEnabled = true;
            this.cboLayer.Location = new System.Drawing.Point(98, 17);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.Size = new System.Drawing.Size(204, 21);
            this.cboLayer.TabIndex = 1;
            this.cboLayer.SelectedIndexChanged += new System.EventHandler(this.cboLayer_SelectedIndexChanged);
            // 
            // lblFLyr
            // 
            this.lblFLyr.AutoSize = true;
            this.lblFLyr.Location = new System.Drawing.Point(7, 20);
            this.lblFLyr.Name = "lblFLyr";
            this.lblFLyr.Size = new System.Drawing.Size(72, 13);
            this.lblFLyr.TabIndex = 0;
            this.lblFLyr.Text = "Feature Layer";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStretch);
            this.groupBox2.Controls.Add(this.btnScale);
            this.groupBox2.Controls.Add(this.btnChangeRGBRenderer);
            this.groupBox2.Controls.Add(this.btnSaveLayer);
            this.groupBox2.Location = new System.Drawing.Point(327, 337);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 213);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // btnStretch
            // 
            this.btnStretch.Location = new System.Drawing.Point(17, 143);
            this.btnStretch.Name = "btnStretch";
            this.btnStretch.Size = new System.Drawing.Size(115, 23);
            this.btnStretch.TabIndex = 4;
            this.btnStretch.Text = "Stretch Raster";
            this.btnStretch.UseVisualStyleBackColor = true;
            this.btnStretch.Click += new System.EventHandler(this.btnStretch_Click);
            // 
            // btnScale
            // 
            this.btnScale.Location = new System.Drawing.Point(17, 113);
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(115, 23);
            this.btnScale.TabIndex = 3;
            this.btnScale.Text = "Scale Dependent";
            this.btnScale.UseVisualStyleBackColor = true;
            this.btnScale.Click += new System.EventHandler(this.btnScale_Click);
            // 
            // btnChangeRGBRenderer
            // 
            this.btnChangeRGBRenderer.Location = new System.Drawing.Point(17, 83);
            this.btnChangeRGBRenderer.Name = "btnChangeRGBRenderer";
            this.btnChangeRGBRenderer.Size = new System.Drawing.Size(115, 23);
            this.btnChangeRGBRenderer.TabIndex = 2;
            this.btnChangeRGBRenderer.Text = "Change RGB Raster";
            this.btnChangeRGBRenderer.UseVisualStyleBackColor = true;
            // 
            // btnSaveLayer
            // 
            this.btnSaveLayer.Location = new System.Drawing.Point(17, 53);
            this.btnSaveLayer.Name = "btnSaveLayer";
            this.btnSaveLayer.Size = new System.Drawing.Size(115, 23);
            this.btnSaveLayer.TabIndex = 1;
            this.btnSaveLayer.Text = "Save Layer";
            this.btnSaveLayer.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 582);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ArcEngine Controls Application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboLayer;
        private System.Windows.Forms.Label lblFLyr;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton optBreaks;
        private System.Windows.Forms.RadioButton optUnique;
        private System.Windows.Forms.RadioButton optSimple;
        private System.Windows.Forms.ComboBox cboNumericVals;
        private System.Windows.Forms.ComboBox cboUniqueVals;
        private System.Windows.Forms.ComboBox cboBlue;
        private System.Windows.Forms.ComboBox cboGreen;
        private System.Windows.Forms.ComboBox cboRed;
        private System.Windows.Forms.ComboBox cboBreaks;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Label lblBreaks;
        private System.Windows.Forms.Button btnStretch;
        private System.Windows.Forms.Button btnScale;
        private System.Windows.Forms.Button btnChangeRGBRenderer;
        private System.Windows.Forms.Button btnSaveLayer;
    }
}

