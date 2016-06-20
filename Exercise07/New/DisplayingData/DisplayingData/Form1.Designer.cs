
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.lblLayer = new System.Windows.Forms.Label();
            this.cboLayer = new System.Windows.Forms.ComboBox();
            this.cboRed = new System.Windows.Forms.ComboBox();
            this.lblR = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.cboGreen = new System.Windows.Forms.ComboBox();
            this.lblB = new System.Windows.Forms.Label();
            this.cboBlue = new System.Windows.Forms.ComboBox();
            this.optSimple = new System.Windows.Forms.RadioButton();
            this.btnSaveLayer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxProp2 = new System.Windows.Forms.ComboBox();
            this.cbxProp1 = new System.Windows.Forms.ComboBox();
            this.optChart = new System.Windows.Forms.RadioButton();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblBreaks = new System.Windows.Forms.Label();
            this.cboBreaks = new System.Windows.Forms.ComboBox();
            this.cboNumericVals = new System.Windows.Forms.ComboBox();
            this.optBreaks = new System.Windows.Forms.RadioButton();
            this.cboUniqueVals = new System.Windows.Forms.ComboBox();
            this.optUnique = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStretch = new System.Windows.Forms.Button();
            this.btnScale = new System.Windows.Forms.Button();
            this.btnChangeRGBRenderer = new System.Windows.Forms.Button();
            this.statusBarXY = new System.Windows.Forms.TextBox();
            this.lblActiveMap = new System.Windows.Forms.Label();
            this.cboActiveMap = new System.Windows.Forms.ComboBox();
            this.rtxbRasterInfo = new System.Windows.Forms.RichTextBox();
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.toolStripSeparator1,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(39, 21);
            this.menuFile.Text = "File";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(171, 22);
            this.menuNewDoc.Text = "New Docment";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(171, 22);
            this.menuOpenDoc.Text = "Open Document";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(171, 22);
            this.menuSaveDoc.Text = "Save Document";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(171, 22);
            this.menuSaveAs.Text = "Save As ";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(171, 22);
            this.menuExitApp.Text = "Exit";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(298, 219);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // lblLayer
            // 
            this.lblLayer.AutoSize = true;
            this.lblLayer.Location = new System.Drawing.Point(6, 17);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(83, 12);
            this.lblLayer.TabIndex = 5;
            this.lblLayer.Text = "Feature Layer";
            // 
            // cboLayer
            // 
            this.cboLayer.FormattingEnabled = true;
            this.cboLayer.Location = new System.Drawing.Point(118, 17);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.Size = new System.Drawing.Size(212, 20);
            this.cboLayer.TabIndex = 6;
            this.cboLayer.SelectedIndexChanged += new System.EventHandler(this.cboLayer_SelectedIndexChanged);
            // 
            // cboRed
            // 
            this.cboRed.FormattingEnabled = true;
            this.cboRed.Location = new System.Drawing.Point(145, 46);
            this.cboRed.Name = "cboRed";
            this.cboRed.Size = new System.Drawing.Size(39, 20);
            this.cboRed.TabIndex = 7;
            this.cboRed.SelectedIndexChanged += new System.EventHandler(this.cboRed_SelectedIndexChanged);
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(122, 46);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(17, 12);
            this.lblR.TabIndex = 8;
            this.lblR.Text = "R:";
            this.lblR.Click += new System.EventHandler(this.lblR_Click);
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(190, 45);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(17, 12);
            this.lblG.TabIndex = 9;
            this.lblG.Text = "G:";
            this.lblG.Click += new System.EventHandler(this.lblGreen_Click);
            // 
            // cboGreen
            // 
            this.cboGreen.FormattingEnabled = true;
            this.cboGreen.Location = new System.Drawing.Point(211, 45);
            this.cboGreen.Name = "cboGreen";
            this.cboGreen.Size = new System.Drawing.Size(46, 20);
            this.cboGreen.TabIndex = 10;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(263, 46);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(17, 12);
            this.lblB.TabIndex = 11;
            this.lblB.Text = "B:";
            this.lblB.Click += new System.EventHandler(this.lblBlue_Click);
            // 
            // cboBlue
            // 
            this.cboBlue.FormattingEnabled = true;
            this.cboBlue.Location = new System.Drawing.Point(286, 46);
            this.cboBlue.Name = "cboBlue";
            this.cboBlue.Size = new System.Drawing.Size(44, 20);
            this.cboBlue.TabIndex = 12;
            this.cboBlue.SelectedIndexChanged += new System.EventHandler(this.cboBlue_SelectedIndexChanged);
            // 
            // optSimple
            // 
            this.optSimple.AutoSize = true;
            this.optSimple.Location = new System.Drawing.Point(6, 49);
            this.optSimple.Name = "optSimple";
            this.optSimple.Size = new System.Drawing.Size(59, 16);
            this.optSimple.TabIndex = 13;
            this.optSimple.TabStop = true;
            this.optSimple.Text = "Simple";
            this.optSimple.UseVisualStyleBackColor = true;
            this.optSimple.CheckedChanged += new System.EventHandler(this.optSimple_CheckedChanged);
            // 
            // btnSaveLayer
            // 
            this.btnSaveLayer.Location = new System.Drawing.Point(19, 20);
            this.btnSaveLayer.Name = "btnSaveLayer";
            this.btnSaveLayer.Size = new System.Drawing.Size(129, 23);
            this.btnSaveLayer.TabIndex = 14;
            this.btnSaveLayer.Text = "Save Layer";
            this.btnSaveLayer.UseVisualStyleBackColor = true;
            this.btnSaveLayer.Click += new System.EventHandler(this.btnSaveLayer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxProp2);
            this.groupBox1.Controls.Add(this.cbxProp1);
            this.groupBox1.Controls.Add(this.optChart);
            this.groupBox1.Controls.Add(this.btnRender);
            this.groupBox1.Controls.Add(this.lblBreaks);
            this.groupBox1.Controls.Add(this.cboBreaks);
            this.groupBox1.Controls.Add(this.cboNumericVals);
            this.groupBox1.Controls.Add(this.optBreaks);
            this.groupBox1.Controls.Add(this.cboUniqueVals);
            this.groupBox1.Controls.Add(this.optUnique);
            this.groupBox1.Controls.Add(this.lblLayer);
            this.groupBox1.Controls.Add(this.cboRed);
            this.groupBox1.Controls.Add(this.optSimple);
            this.groupBox1.Controls.Add(this.cboLayer);
            this.groupBox1.Controls.Add(this.lblR);
            this.groupBox1.Controls.Add(this.lblG);
            this.groupBox1.Controls.Add(this.lblB);
            this.groupBox1.Controls.Add(this.cboBlue);
            this.groupBox1.Controls.Add(this.cboGreen);
            this.groupBox1.Location = new System.Drawing.Point(0, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 188);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // cbxProp2
            // 
            this.cbxProp2.FormattingEnabled = true;
            this.cbxProp2.Location = new System.Drawing.Point(226, 155);
            this.cbxProp2.Name = "cbxProp2";
            this.cbxProp2.Size = new System.Drawing.Size(100, 20);
            this.cbxProp2.TabIndex = 24;
            // 
            // cbxProp1
            // 
            this.cbxProp1.FormattingEnabled = true;
            this.cbxProp1.Location = new System.Drawing.Point(86, 154);
            this.cbxProp1.Name = "cbxProp1";
            this.cbxProp1.Size = new System.Drawing.Size(98, 20);
            this.cbxProp1.TabIndex = 23;
            // 
            // optChart
            // 
            this.optChart.AutoSize = true;
            this.optChart.Location = new System.Drawing.Point(5, 155);
            this.optChart.Name = "optChart";
            this.optChart.Size = new System.Drawing.Size(53, 16);
            this.optChart.TabIndex = 22;
            this.optChart.TabStop = true;
            this.optChart.Text = "Chart";
            this.optChart.UseVisualStyleBackColor = true;
            this.optChart.CheckedChanged += new System.EventHandler(this.optChart_CheckedChanged);
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(251, 124);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(75, 23);
            this.btnRender.TabIndex = 21;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblBreaks
            // 
            this.lblBreaks.AutoSize = true;
            this.lblBreaks.Location = new System.Drawing.Point(5, 127);
            this.lblBreaks.Name = "lblBreaks";
            this.lblBreaks.Size = new System.Drawing.Size(137, 12);
            this.lblBreaks.TabIndex = 19;
            this.lblBreaks.Text = "Equal-Interval Classes";
            // 
            // cboBreaks
            // 
            this.cboBreaks.FormattingEnabled = true;
            this.cboBreaks.Location = new System.Drawing.Point(148, 124);
            this.cboBreaks.Name = "cboBreaks";
            this.cboBreaks.Size = new System.Drawing.Size(76, 20);
            this.cboBreaks.TabIndex = 18;
            // 
            // cboNumericVals
            // 
            this.cboNumericVals.FormattingEnabled = true;
            this.cboNumericVals.Location = new System.Drawing.Point(118, 94);
            this.cboNumericVals.Name = "cboNumericVals";
            this.cboNumericVals.Size = new System.Drawing.Size(208, 20);
            this.cboNumericVals.TabIndex = 17;
            // 
            // optBreaks
            // 
            this.optBreaks.AutoSize = true;
            this.optBreaks.Location = new System.Drawing.Point(5, 94);
            this.optBreaks.Name = "optBreaks";
            this.optBreaks.Size = new System.Drawing.Size(89, 16);
            this.optBreaks.TabIndex = 16;
            this.optBreaks.TabStop = true;
            this.optBreaks.Text = "Class Break";
            this.optBreaks.UseVisualStyleBackColor = true;
            this.optBreaks.CheckedChanged += new System.EventHandler(this.optBreaks_CheckedChanged);
            // 
            // cboUniqueVals
            // 
            this.cboUniqueVals.FormattingEnabled = true;
            this.cboUniqueVals.Location = new System.Drawing.Point(118, 72);
            this.cboUniqueVals.Name = "cboUniqueVals";
            this.cboUniqueVals.Size = new System.Drawing.Size(212, 20);
            this.cboUniqueVals.TabIndex = 15;
            // 
            // optUnique
            // 
            this.optUnique.AutoSize = true;
            this.optUnique.Location = new System.Drawing.Point(5, 73);
            this.optUnique.Name = "optUnique";
            this.optUnique.Size = new System.Drawing.Size(101, 16);
            this.optUnique.TabIndex = 14;
            this.optUnique.TabStop = true;
            this.optUnique.Text = "Unique Values";
            this.optUnique.UseVisualStyleBackColor = true;
            this.optUnique.CheckedChanged += new System.EventHandler(this.obtUniqueVals_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(641, 538);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStretch);
            this.groupBox2.Controls.Add(this.btnScale);
            this.groupBox2.Controls.Add(this.btnChangeRGBRenderer);
            this.groupBox2.Controls.Add(this.btnSaveLayer);
            this.groupBox2.Location = new System.Drawing.Point(402, 374);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 188);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // btnStretch
            // 
            this.btnStretch.Location = new System.Drawing.Point(19, 116);
            this.btnStretch.Name = "btnStretch";
            this.btnStretch.Size = new System.Drawing.Size(129, 23);
            this.btnStretch.TabIndex = 17;
            this.btnStretch.Text = "Stresh Raster";
            this.btnStretch.UseVisualStyleBackColor = true;
            this.btnStretch.Click += new System.EventHandler(this.btnStretch_Click);
            // 
            // btnScale
            // 
            this.btnScale.Location = new System.Drawing.Point(19, 83);
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(129, 23);
            this.btnScale.TabIndex = 16;
            this.btnScale.Text = "Scale Dependent ";
            this.btnScale.UseVisualStyleBackColor = true;
            this.btnScale.Click += new System.EventHandler(this.btnScale_Click);
            // 
            // btnChangeRGBRenderer
            // 
            this.btnChangeRGBRenderer.Location = new System.Drawing.Point(19, 51);
            this.btnChangeRGBRenderer.Name = "btnChangeRGBRenderer";
            this.btnChangeRGBRenderer.Size = new System.Drawing.Size(129, 26);
            this.btnChangeRGBRenderer.TabIndex = 15;
            this.btnChangeRGBRenderer.Text = "Change RGB Raster";
            this.btnChangeRGBRenderer.UseVisualStyleBackColor = true;
            this.btnChangeRGBRenderer.Click += new System.EventHandler(this.btnChangeRGBRenderer_Click);
            // 
            // statusBarXY
            // 
            this.statusBarXY.Location = new System.Drawing.Point(641, 28);
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(232, 21);
            this.statusBarXY.TabIndex = 18;
            // 
            // lblActiveMap
            // 
            this.lblActiveMap.AutoSize = true;
            this.lblActiveMap.Location = new System.Drawing.Point(574, 5);
            this.lblActiveMap.Name = "lblActiveMap";
            this.lblActiveMap.Size = new System.Drawing.Size(65, 12);
            this.lblActiveMap.TabIndex = 19;
            this.lblActiveMap.Text = "Active Map";
            // 
            // cboActiveMap
            // 
            this.cboActiveMap.FormattingEnabled = true;
            this.cboActiveMap.Location = new System.Drawing.Point(673, 5);
            this.cboActiveMap.Name = "cboActiveMap";
            this.cboActiveMap.Size = new System.Drawing.Size(200, 20);
            this.cboActiveMap.TabIndex = 20;
            this.cboActiveMap.SelectedIndexChanged += new System.EventHandler(this.cboActiveMap_SelectedIndexChanged);
            // 
            // rtxbRasterInfo
            // 
            this.rtxbRasterInfo.Location = new System.Drawing.Point(641, 391);
            this.rtxbRasterInfo.Name = "rtxbRasterInfo";
            this.rtxbRasterInfo.Size = new System.Drawing.Size(220, 141);
            this.rtxbRasterInfo.TabIndex = 21;
            this.rtxbRasterInfo.Text = "";
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Location = new System.Drawing.Point(5, 247);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(157, 110);
            this.axSymbologyControl1.TabIndex = 17;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 27);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(458, 28);
            this.axToolbarControl1.TabIndex = 4;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(0, 54);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(207, 187);
            this.axTOCControl1.TabIndex = 3;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(211, 54);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(671, 314);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 583);
            this.Controls.Add(this.rtxbRasterInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cboActiveMap);
            this.Controls.Add(this.lblActiveMap);
            this.Controls.Add(this.statusBarXY);
            this.Controls.Add(this.axSymbologyControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ArcEngine Controls Application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.Label lblLayer;
        private System.Windows.Forms.ComboBox cboLayer;
        private System.Windows.Forms.ComboBox cboRed;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.ComboBox cboGreen;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.ComboBox cboBlue;
        private System.Windows.Forms.RadioButton optSimple;
        private System.Windows.Forms.Button btnSaveLayer;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optUnique;
        private System.Windows.Forms.RadioButton optBreaks;
        private System.Windows.Forms.ComboBox cboUniqueVals;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblBreaks;
        private System.Windows.Forms.ComboBox cboBreaks;
        private System.Windows.Forms.ComboBox cboNumericVals;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStretch;
        private System.Windows.Forms.Button btnScale;
        private System.Windows.Forms.Button btnChangeRGBRenderer;
        private System.Windows.Forms.Button btnRender;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        private System.Windows.Forms.TextBox statusBarXY;
        private System.Windows.Forms.Label lblActiveMap;
        private System.Windows.Forms.ComboBox cboActiveMap;
        private System.Windows.Forms.RichTextBox rtxbRasterInfo;
        private System.Windows.Forms.ComboBox cbxProp2;
        private System.Windows.Forms.ComboBox cbxProp1;
        private System.Windows.Forms.RadioButton optChart;
    }
}

