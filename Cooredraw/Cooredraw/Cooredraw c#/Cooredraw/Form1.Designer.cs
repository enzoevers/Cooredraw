namespace Cooredraw
{
    partial class Form1
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
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.tbTabControl = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.gbPBSize = new System.Windows.Forms.GroupBox();
            this.lblOpenExisting = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbHeightResolution = new System.Windows.Forms.TextBox();
            this.tbWidthResolution = new System.Windows.Forms.TextBox();
            this.btnCreateCanvas = new System.Windows.Forms.Button();
            this.lblResolutionHeight = new System.Windows.Forms.Label();
            this.lblResolutionWidth = new System.Windows.Forms.Label();
            this.gbPortConnection = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbBoudrates = new System.Windows.Forms.ComboBox();
            this.lblBoudrate = new System.Windows.Forms.Label();
            this.btnPortRefresh = new System.Windows.Forms.Button();
            this.cbAvailablePorts = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.tabCanvas = new System.Windows.Forms.TabPage();
            this.pnlPictureBoxShading = new System.Windows.Forms.Panel();
            this.gbTools = new System.Windows.Forms.GroupBox();
            this.lblRGBValues = new System.Windows.Forms.Label();
            this.tbFontThickness = new System.Windows.Forms.TextBox();
            this.lblFontThickess = new System.Windows.Forms.Label();
            this.lblPencilType = new System.Windows.Forms.Label();
            this.cbPencilTypes = new System.Windows.Forms.ComboBox();
            this.lblFontColor = new System.Windows.Forms.Label();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFontColor = new System.Windows.Forms.Panel();
            this.lbCanvasBackGround = new System.Windows.Forms.ListBox();
            this.btnClearCanvas = new System.Windows.Forms.Button();
            this.btnEraser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.tbTabControl.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.gbPBSize.SuspendLayout();
            this.gbPortConnection.SuspendLayout();
            this.tabCanvas.SuspendLayout();
            this.gbTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.White;
            this.pbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCanvas.Location = new System.Drawing.Point(209, 3);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(1245, 753);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseDown);
            // 
            // tbTabControl
            // 
            this.tbTabControl.Controls.Add(this.tabSettings);
            this.tbTabControl.Controls.Add(this.tabCanvas);
            this.tbTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTabControl.Location = new System.Drawing.Point(0, 0);
            this.tbTabControl.Name = "tbTabControl";
            this.tbTabControl.SelectedIndex = 0;
            this.tbTabControl.Size = new System.Drawing.Size(1516, 795);
            this.tbTabControl.TabIndex = 2;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.gbPBSize);
            this.tabSettings.Controls.Add(this.gbPortConnection);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1508, 769);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // gbPBSize
            // 
            this.gbPBSize.Controls.Add(this.lblOpenExisting);
            this.gbPBSize.Controls.Add(this.btnOpen);
            this.gbPBSize.Controls.Add(this.tbHeightResolution);
            this.gbPBSize.Controls.Add(this.tbWidthResolution);
            this.gbPBSize.Controls.Add(this.btnCreateCanvas);
            this.gbPBSize.Controls.Add(this.lblResolutionHeight);
            this.gbPBSize.Controls.Add(this.lblResolutionWidth);
            this.gbPBSize.Location = new System.Drawing.Point(215, 7);
            this.gbPBSize.Name = "gbPBSize";
            this.gbPBSize.Size = new System.Drawing.Size(167, 195);
            this.gbPBSize.TabIndex = 3;
            this.gbPBSize.TabStop = false;
            this.gbPBSize.Text = "Resolution";
            // 
            // lblOpenExisting
            // 
            this.lblOpenExisting.AutoSize = true;
            this.lblOpenExisting.Location = new System.Drawing.Point(6, 150);
            this.lblOpenExisting.Name = "lblOpenExisting";
            this.lblOpenExisting.Size = new System.Drawing.Size(83, 13);
            this.lblOpenExisting.TabIndex = 10;
            this.lblOpenExisting.Text = "Or open existing";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(9, 166);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(145, 23);
            this.btnOpen.TabIndex = 9;
            this.btnOpen.Text = "Open existing";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbHeightResolution
            // 
            this.tbHeightResolution.Location = new System.Drawing.Point(50, 60);
            this.tbHeightResolution.Name = "tbHeightResolution";
            this.tbHeightResolution.Size = new System.Drawing.Size(104, 20);
            this.tbHeightResolution.TabIndex = 8;
            // 
            // tbWidthResolution
            // 
            this.tbWidthResolution.Location = new System.Drawing.Point(50, 31);
            this.tbWidthResolution.Name = "tbWidthResolution";
            this.tbWidthResolution.Size = new System.Drawing.Size(104, 20);
            this.tbWidthResolution.TabIndex = 7;
            // 
            // btnCreateCanvas
            // 
            this.btnCreateCanvas.Location = new System.Drawing.Point(9, 99);
            this.btnCreateCanvas.Name = "btnCreateCanvas";
            this.btnCreateCanvas.Size = new System.Drawing.Size(145, 23);
            this.btnCreateCanvas.TabIndex = 6;
            this.btnCreateCanvas.Text = "Create  new";
            this.btnCreateCanvas.UseVisualStyleBackColor = true;
            this.btnCreateCanvas.Click += new System.EventHandler(this.btnCreateCanvas_Click);
            // 
            // lblResolutionHeight
            // 
            this.lblResolutionHeight.AutoSize = true;
            this.lblResolutionHeight.Location = new System.Drawing.Point(6, 63);
            this.lblResolutionHeight.Name = "lblResolutionHeight";
            this.lblResolutionHeight.Size = new System.Drawing.Size(41, 13);
            this.lblResolutionHeight.TabIndex = 5;
            this.lblResolutionHeight.Text = "Height:";
            // 
            // lblResolutionWidth
            // 
            this.lblResolutionWidth.AutoSize = true;
            this.lblResolutionWidth.Location = new System.Drawing.Point(6, 34);
            this.lblResolutionWidth.Name = "lblResolutionWidth";
            this.lblResolutionWidth.Size = new System.Drawing.Size(38, 13);
            this.lblResolutionWidth.TabIndex = 4;
            this.lblResolutionWidth.Text = "Width:";
            this.lblResolutionWidth.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // gbPortConnection
            // 
            this.gbPortConnection.Controls.Add(this.btnDisconnect);
            this.gbPortConnection.Controls.Add(this.btnConnect);
            this.gbPortConnection.Controls.Add(this.cbBoudrates);
            this.gbPortConnection.Controls.Add(this.lblBoudrate);
            this.gbPortConnection.Controls.Add(this.btnPortRefresh);
            this.gbPortConnection.Controls.Add(this.cbAvailablePorts);
            this.gbPortConnection.Controls.Add(this.lblPort);
            this.gbPortConnection.Location = new System.Drawing.Point(8, 6);
            this.gbPortConnection.Name = "gbPortConnection";
            this.gbPortConnection.Size = new System.Drawing.Size(200, 196);
            this.gbPortConnection.TabIndex = 2;
            this.gbPortConnection.TabStop = false;
            this.gbPortConnection.Text = "Connection";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(7, 167);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(177, 23);
            this.btnDisconnect.TabIndex = 8;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(7, 138);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(177, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbBoudrates
            // 
            this.cbBoudrates.FormattingEnabled = true;
            this.cbBoudrates.Location = new System.Drawing.Point(63, 102);
            this.cbBoudrates.Name = "cbBoudrates";
            this.cbBoudrates.Size = new System.Drawing.Size(121, 21);
            this.cbBoudrates.TabIndex = 6;
            this.cbBoudrates.SelectedIndexChanged += new System.EventHandler(this.cbBoudrates_SelectedIndexChanged);
            // 
            // lblBoudrate
            // 
            this.lblBoudrate.AutoSize = true;
            this.lblBoudrate.Location = new System.Drawing.Point(6, 105);
            this.lblBoudrate.Name = "lblBoudrate";
            this.lblBoudrate.Size = new System.Drawing.Size(53, 13);
            this.lblBoudrate.TabIndex = 5;
            this.lblBoudrate.Text = "Boudrate:";
            // 
            // btnPortRefresh
            // 
            this.btnPortRefresh.Location = new System.Drawing.Point(109, 54);
            this.btnPortRefresh.Name = "btnPortRefresh";
            this.btnPortRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnPortRefresh.TabIndex = 4;
            this.btnPortRefresh.Text = "Refresh";
            this.btnPortRefresh.UseVisualStyleBackColor = true;
            this.btnPortRefresh.Click += new System.EventHandler(this.btnPortRefresh_Click);
            // 
            // cbAvailablePorts
            // 
            this.cbAvailablePorts.FormattingEnabled = true;
            this.cbAvailablePorts.Location = new System.Drawing.Point(63, 27);
            this.cbAvailablePorts.Name = "cbAvailablePorts";
            this.cbAvailablePorts.Size = new System.Drawing.Size(121, 21);
            this.cbAvailablePorts.TabIndex = 3;
            this.cbAvailablePorts.SelectedIndexChanged += new System.EventHandler(this.cbAvailablePorts_SelectedIndexChanged);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 30);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port:";
            // 
            // tabCanvas
            // 
            this.tabCanvas.BackColor = System.Drawing.Color.Silver;
            this.tabCanvas.Controls.Add(this.pnlPictureBoxShading);
            this.tabCanvas.Controls.Add(this.gbTools);
            this.tabCanvas.Controls.Add(this.pbCanvas);
            this.tabCanvas.Location = new System.Drawing.Point(4, 22);
            this.tabCanvas.Name = "tabCanvas";
            this.tabCanvas.Padding = new System.Windows.Forms.Padding(3);
            this.tabCanvas.Size = new System.Drawing.Size(1508, 769);
            this.tabCanvas.TabIndex = 0;
            this.tabCanvas.Text = "Canvas";
            // 
            // pnlPictureBoxShading
            // 
            this.pnlPictureBoxShading.BackColor = System.Drawing.Color.DimGray;
            this.pnlPictureBoxShading.Location = new System.Drawing.Point(220, 14);
            this.pnlPictureBoxShading.Name = "pnlPictureBoxShading";
            this.pnlPictureBoxShading.Size = new System.Drawing.Size(1245, 753);
            this.pnlPictureBoxShading.TabIndex = 3;
            // 
            // gbTools
            // 
            this.gbTools.BackColor = System.Drawing.Color.Gray;
            this.gbTools.Controls.Add(this.btnEraser);
            this.gbTools.Controls.Add(this.lblRGBValues);
            this.gbTools.Controls.Add(this.tbFontThickness);
            this.gbTools.Controls.Add(this.lblFontThickess);
            this.gbTools.Controls.Add(this.lblPencilType);
            this.gbTools.Controls.Add(this.cbPencilTypes);
            this.gbTools.Controls.Add(this.lblFontColor);
            this.gbTools.Controls.Add(this.btnSaveAs);
            this.gbTools.Controls.Add(this.btnSave);
            this.gbTools.Controls.Add(this.pnlFontColor);
            this.gbTools.Controls.Add(this.lbCanvasBackGround);
            this.gbTools.Controls.Add(this.btnClearCanvas);
            this.gbTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbTools.Location = new System.Drawing.Point(3, 3);
            this.gbTools.Name = "gbTools";
            this.gbTools.Size = new System.Drawing.Size(200, 763);
            this.gbTools.TabIndex = 2;
            this.gbTools.TabStop = false;
            this.gbTools.Text = "Tools";
            // 
            // lblRGBValues
            // 
            this.lblRGBValues.AutoSize = true;
            this.lblRGBValues.Location = new System.Drawing.Point(7, 467);
            this.lblRGBValues.Name = "lblRGBValues";
            this.lblRGBValues.Size = new System.Drawing.Size(10, 13);
            this.lblRGBValues.TabIndex = 11;
            this.lblRGBValues.Text = "-";
            // 
            // tbFontThickness
            // 
            this.tbFontThickness.Location = new System.Drawing.Point(3, 608);
            this.tbFontThickness.Name = "tbFontThickness";
            this.tbFontThickness.Size = new System.Drawing.Size(191, 20);
            this.tbFontThickness.TabIndex = 10;
            this.tbFontThickness.TextChanged += new System.EventHandler(this.tbFontThickness_TextChanged);
            // 
            // lblFontThickess
            // 
            this.lblFontThickess.AutoSize = true;
            this.lblFontThickess.Location = new System.Drawing.Point(3, 592);
            this.lblFontThickess.Name = "lblFontThickess";
            this.lblFontThickess.Size = new System.Drawing.Size(76, 13);
            this.lblFontThickess.TabIndex = 9;
            this.lblFontThickess.Text = "Font thickness";
            // 
            // lblPencilType
            // 
            this.lblPencilType.AutoSize = true;
            this.lblPencilType.Location = new System.Drawing.Point(0, 541);
            this.lblPencilType.Name = "lblPencilType";
            this.lblPencilType.Size = new System.Drawing.Size(39, 13);
            this.lblPencilType.TabIndex = 8;
            this.lblPencilType.Text = "Pencil:";
            // 
            // cbPencilTypes
            // 
            this.cbPencilTypes.FormattingEnabled = true;
            this.cbPencilTypes.Location = new System.Drawing.Point(3, 557);
            this.cbPencilTypes.Name = "cbPencilTypes";
            this.cbPencilTypes.Size = new System.Drawing.Size(191, 21);
            this.cbPencilTypes.TabIndex = 7;
            this.cbPencilTypes.SelectedIndexChanged += new System.EventHandler(this.cbPencilTypes_SelectedIndexChanged);
            // 
            // lblFontColor
            // 
            this.lblFontColor.AutoSize = true;
            this.lblFontColor.Location = new System.Drawing.Point(0, 344);
            this.lblFontColor.Name = "lblFontColor";
            this.lblFontColor.Size = new System.Drawing.Size(59, 13);
            this.lblFontColor.TabIndex = 6;
            this.lblFontColor.Text = "Font collor:";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(3, 48);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 5;
            this.btnSaveAs.Text = "Save as";
            this.btnSaveAs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlFontColor
            // 
            this.pnlFontColor.Location = new System.Drawing.Point(3, 360);
            this.pnlFontColor.Name = "pnlFontColor";
            this.pnlFontColor.Size = new System.Drawing.Size(191, 100);
            this.pnlFontColor.TabIndex = 2;
            // 
            // lbCanvasBackGround
            // 
            this.lbCanvasBackGround.FormattingEnabled = true;
            this.lbCanvasBackGround.Location = new System.Drawing.Point(3, 142);
            this.lbCanvasBackGround.Name = "lbCanvasBackGround";
            this.lbCanvasBackGround.Size = new System.Drawing.Size(191, 199);
            this.lbCanvasBackGround.TabIndex = 1;
            this.lbCanvasBackGround.SelectedIndexChanged += new System.EventHandler(this.lbCanvasBackGround_SelectedIndexChanged);
            // 
            // btnClearCanvas
            // 
            this.btnClearCanvas.Location = new System.Drawing.Point(3, 77);
            this.btnClearCanvas.Name = "btnClearCanvas";
            this.btnClearCanvas.Size = new System.Drawing.Size(191, 23);
            this.btnClearCanvas.TabIndex = 0;
            this.btnClearCanvas.Text = "Clear canvas";
            this.btnClearCanvas.UseVisualStyleBackColor = true;
            this.btnClearCanvas.Click += new System.EventHandler(this.btnClearCanvas_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.Location = new System.Drawing.Point(3, 106);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(191, 23);
            this.btnEraser.TabIndex = 12;
            this.btnEraser.Text = "Eraser";
            this.btnEraser.UseVisualStyleBackColor = true;
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1516, 795);
            this.Controls.Add(this.tbTabControl);
            this.Name = "Form1";
            this.Text = "Cooredraw";
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.tbTabControl.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.gbPBSize.ResumeLayout(false);
            this.gbPBSize.PerformLayout();
            this.gbPortConnection.ResumeLayout(false);
            this.gbPortConnection.PerformLayout();
            this.tabCanvas.ResumeLayout(false);
            this.gbTools.ResumeLayout(false);
            this.gbTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.TabControl tbTabControl;
        private System.Windows.Forms.TabPage tabCanvas;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox gbPortConnection;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cbAvailablePorts;
        private System.Windows.Forms.Button btnPortRefresh;
        private System.Windows.Forms.ComboBox cbBoudrates;
        private System.Windows.Forms.Label lblBoudrate;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox gbTools;
        private System.Windows.Forms.ListBox lbCanvasBackGround;
        private System.Windows.Forms.Button btnClearCanvas;
        private System.Windows.Forms.Panel pnlFontColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label lblResolutionWidth;
        private System.Windows.Forms.GroupBox gbPBSize;
        private System.Windows.Forms.TextBox tbHeightResolution;
        private System.Windows.Forms.TextBox tbWidthResolution;
        private System.Windows.Forms.Button btnCreateCanvas;
        private System.Windows.Forms.Label lblResolutionHeight;
        private System.Windows.Forms.Label lblOpenExisting;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblFontColor;
        private System.Windows.Forms.Label lblPencilType;
        private System.Windows.Forms.ComboBox cbPencilTypes;
        private System.Windows.Forms.TextBox tbFontThickness;
        private System.Windows.Forms.Label lblFontThickess;
        private System.Windows.Forms.Label lblRGBValues;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Panel pnlPictureBoxShading;
        private System.Windows.Forms.Button btnEraser;
    }
}

