namespace Invertor
{
    partial class MainWindow
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.topRibbonTab = new System.Windows.Forms.TabControl();
            this.fileTabPage = new System.Windows.Forms.TabPage();
            this.fileSaveAsButton = new System.Windows.Forms.Button();
            this.fileSaveButton = new System.Windows.Forms.Button();
            this.fileOpenButton = new System.Windows.Forms.Button();
            this.fileNewButton = new System.Windows.Forms.Button();
            this.drawTapPage = new System.Windows.Forms.TabPage();
            this.circleButton = new System.Windows.Forms.CheckBox();
            this.rectangleButton = new System.Windows.Forms.CheckBox();
            this.lineButton = new System.Windows.Forms.CheckBox();
            this.lineThicknessValue = new System.Windows.Forms.NumericUpDown();
            this.lineThicknessLabel = new System.Windows.Forms.Label();
            this.lineColorPicture = new System.Windows.Forms.PictureBox();
            this.lineColorButton = new System.Windows.Forms.Button();
            this.viewTabPage = new System.Windows.Forms.TabPage();
            this.selectBackColorButton = new System.Windows.Forms.Button();
            this.selectBackColor = new System.Windows.Forms.PictureBox();
            this.originMovementStepLabel = new System.Windows.Forms.Label();
            this.scaleStepLabel = new System.Windows.Forms.Label();
            this.originMovementStepValue = new System.Windows.Forms.NumericUpDown();
            this.scaleStepValue = new System.Windows.Forms.NumericUpDown();
            this.invertedDirectionCheckbox = new System.Windows.Forms.CheckBox();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.fpsValue = new System.Windows.Forms.NumericUpDown();
            this.sidePanel1 = new System.Windows.Forms.Panel();
            this.objectListView = new System.Windows.Forms.ListBox();
            this.drawingAreaStatusStrip = new System.Windows.Forms.StatusStrip();
            this.secondLastPointLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.secondLastPointLabelValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.scaleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.scaleLabelValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.paraelButton = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.topRibbonTab.SuspendLayout();
            this.fileTabPage.SuspendLayout();
            this.drawTapPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineColorPicture)).BeginInit();
            this.viewTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originMovementStepValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleStepValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsValue)).BeginInit();
            this.sidePanel1.SuspendLayout();
            this.drawingAreaStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.topRibbonTab);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1268, 130);
            this.topPanel.TabIndex = 0;
            // 
            // topRibbonTab
            // 
            this.topRibbonTab.Controls.Add(this.fileTabPage);
            this.topRibbonTab.Controls.Add(this.drawTapPage);
            this.topRibbonTab.Controls.Add(this.viewTabPage);
            this.topRibbonTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topRibbonTab.Location = new System.Drawing.Point(0, 0);
            this.topRibbonTab.Name = "topRibbonTab";
            this.topRibbonTab.SelectedIndex = 0;
            this.topRibbonTab.Size = new System.Drawing.Size(1268, 130);
            this.topRibbonTab.TabIndex = 2;
            // 
            // fileTabPage
            // 
            this.fileTabPage.Controls.Add(this.fileSaveAsButton);
            this.fileTabPage.Controls.Add(this.fileSaveButton);
            this.fileTabPage.Controls.Add(this.fileOpenButton);
            this.fileTabPage.Controls.Add(this.fileNewButton);
            this.fileTabPage.Location = new System.Drawing.Point(4, 22);
            this.fileTabPage.Name = "fileTabPage";
            this.fileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fileTabPage.Size = new System.Drawing.Size(1260, 104);
            this.fileTabPage.TabIndex = 0;
            this.fileTabPage.Text = "File";
            this.fileTabPage.UseVisualStyleBackColor = true;
            // 
            // fileSaveAsButton
            // 
            this.fileSaveAsButton.Location = new System.Drawing.Point(251, 6);
            this.fileSaveAsButton.Name = "fileSaveAsButton";
            this.fileSaveAsButton.Size = new System.Drawing.Size(75, 23);
            this.fileSaveAsButton.TabIndex = 3;
            this.fileSaveAsButton.Text = "Save as";
            this.fileSaveAsButton.UseVisualStyleBackColor = true;
            this.fileSaveAsButton.Click += new System.EventHandler(this.fileSaveAsButton_Click);
            // 
            // fileSaveButton
            // 
            this.fileSaveButton.Location = new System.Drawing.Point(170, 6);
            this.fileSaveButton.Name = "fileSaveButton";
            this.fileSaveButton.Size = new System.Drawing.Size(75, 23);
            this.fileSaveButton.TabIndex = 2;
            this.fileSaveButton.Text = "Save";
            this.fileSaveButton.UseVisualStyleBackColor = true;
            this.fileSaveButton.Click += new System.EventHandler(this.fileSaveButton_Click);
            // 
            // fileOpenButton
            // 
            this.fileOpenButton.Location = new System.Drawing.Point(89, 6);
            this.fileOpenButton.Name = "fileOpenButton";
            this.fileOpenButton.Size = new System.Drawing.Size(75, 23);
            this.fileOpenButton.TabIndex = 1;
            this.fileOpenButton.Text = "Open";
            this.fileOpenButton.UseVisualStyleBackColor = true;
            this.fileOpenButton.Click += new System.EventHandler(this.fileOpenButton_Click);
            // 
            // fileNewButton
            // 
            this.fileNewButton.Location = new System.Drawing.Point(8, 6);
            this.fileNewButton.Name = "fileNewButton";
            this.fileNewButton.Size = new System.Drawing.Size(75, 23);
            this.fileNewButton.TabIndex = 0;
            this.fileNewButton.Text = "New";
            this.fileNewButton.UseVisualStyleBackColor = true;
            this.fileNewButton.Click += new System.EventHandler(this.fileNewButton_Click);
            // 
            // drawTapPage
            // 
            this.drawTapPage.Controls.Add(this.circleButton);
            this.drawTapPage.Controls.Add(this.rectangleButton);
            this.drawTapPage.Controls.Add(this.lineButton);
            this.drawTapPage.Controls.Add(this.lineThicknessValue);
            this.drawTapPage.Controls.Add(this.lineThicknessLabel);
            this.drawTapPage.Controls.Add(this.lineColorPicture);
            this.drawTapPage.Controls.Add(this.lineColorButton);
            this.drawTapPage.Controls.Add(this.paraelButton);
            this.drawTapPage.Location = new System.Drawing.Point(4, 22);
            this.drawTapPage.Name = "drawTapPage";
            this.drawTapPage.Padding = new System.Windows.Forms.Padding(3);
            this.drawTapPage.Size = new System.Drawing.Size(1260, 104);
            this.drawTapPage.TabIndex = 1;
            this.drawTapPage.Text = "Draw";
            this.drawTapPage.UseVisualStyleBackColor = true;
            // 
            // circleButton
            // 
            this.circleButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.circleButton.AutoSize = true;
            this.circleButton.Location = new System.Drawing.Point(80, 35);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(43, 23);
            this.circleButton.TabIndex = 1;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.CheckedChanged += new System.EventHandler(this.toolChecked);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.rectangleButton.AutoSize = true;
            this.rectangleButton.Location = new System.Drawing.Point(8, 35);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(66, 23);
            this.rectangleButton.TabIndex = 1;
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.CheckedChanged += new System.EventHandler(this.toolChecked);
            // 
            // lineButton
            // 
            this.lineButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.lineButton.AutoSize = true;
            this.lineButton.Location = new System.Drawing.Point(128, 35);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(37, 23);
            this.lineButton.TabIndex = 1;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.CheckedChanged += new System.EventHandler(this.toolChecked);
            // 
            // lineThicknessValue
            // 
            this.lineThicknessValue.Location = new System.Drawing.Point(245, 9);
            this.lineThicknessValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineThicknessValue.Name = "lineThicknessValue";
            this.lineThicknessValue.Size = new System.Drawing.Size(35, 20);
            this.lineThicknessValue.TabIndex = 5;
            this.lineThicknessValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lineThicknessLabel
            // 
            this.lineThicknessLabel.AutoSize = true;
            this.lineThicknessLabel.Location = new System.Drawing.Point(183, 11);
            this.lineThicknessLabel.Name = "lineThicknessLabel";
            this.lineThicknessLabel.Size = new System.Drawing.Size(56, 13);
            this.lineThicknessLabel.TabIndex = 4;
            this.lineThicknessLabel.Text = "Thickness";
            // 
            // lineColorPicture
            // 
            this.lineColorPicture.BackColor = System.Drawing.Color.White;
            this.lineColorPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineColorPicture.Location = new System.Drawing.Point(196, 35);
            this.lineColorPicture.Name = "lineColorPicture";
            this.lineColorPicture.Size = new System.Drawing.Size(78, 23);
            this.lineColorPicture.TabIndex = 3;
            this.lineColorPicture.TabStop = false;
            // 
            // lineColorButton
            // 
            this.lineColorButton.Location = new System.Drawing.Point(196, 64);
            this.lineColorButton.Name = "lineColorButton";
            this.lineColorButton.Size = new System.Drawing.Size(78, 23);
            this.lineColorButton.TabIndex = 2;
            this.lineColorButton.Text = "Color";
            this.lineColorButton.UseVisualStyleBackColor = true;
            this.lineColorButton.Click += new System.EventHandler(this.lineColorButton_Click);
            // 
            // viewTabPage
            // 
            this.viewTabPage.Controls.Add(this.selectBackColorButton);
            this.viewTabPage.Controls.Add(this.selectBackColor);
            this.viewTabPage.Controls.Add(this.originMovementStepLabel);
            this.viewTabPage.Controls.Add(this.scaleStepLabel);
            this.viewTabPage.Controls.Add(this.originMovementStepValue);
            this.viewTabPage.Controls.Add(this.scaleStepValue);
            this.viewTabPage.Controls.Add(this.invertedDirectionCheckbox);
            this.viewTabPage.Controls.Add(this.fpsLabel);
            this.viewTabPage.Controls.Add(this.fpsValue);
            this.viewTabPage.Location = new System.Drawing.Point(4, 22);
            this.viewTabPage.Name = "viewTabPage";
            this.viewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.viewTabPage.Size = new System.Drawing.Size(1260, 104);
            this.viewTabPage.TabIndex = 2;
            this.viewTabPage.Text = "View";
            this.viewTabPage.UseVisualStyleBackColor = true;
            // 
            // selectBackColorButton
            // 
            this.selectBackColorButton.Location = new System.Drawing.Point(202, 3);
            this.selectBackColorButton.Name = "selectBackColorButton";
            this.selectBackColorButton.Size = new System.Drawing.Size(108, 23);
            this.selectBackColorButton.TabIndex = 5;
            this.selectBackColorButton.Text = "Select Background";
            this.selectBackColorButton.UseVisualStyleBackColor = true;
            this.selectBackColorButton.Click += new System.EventHandler(this.selectBackColorButton_Click);
            // 
            // selectBackColor
            // 
            this.selectBackColor.BackColor = System.Drawing.SystemColors.Highlight;
            this.selectBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectBackColor.Location = new System.Drawing.Point(202, 32);
            this.selectBackColor.Name = "selectBackColor";
            this.selectBackColor.Size = new System.Drawing.Size(108, 46);
            this.selectBackColor.TabIndex = 4;
            this.selectBackColor.TabStop = false;
            // 
            // originMovementStepLabel
            // 
            this.originMovementStepLabel.AutoSize = true;
            this.originMovementStepLabel.Location = new System.Drawing.Point(8, 8);
            this.originMovementStepLabel.Name = "originMovementStepLabel";
            this.originMovementStepLabel.Size = new System.Drawing.Size(109, 13);
            this.originMovementStepLabel.TabIndex = 3;
            this.originMovementStepLabel.Text = "Origin movement step";
            // 
            // scaleStepLabel
            // 
            this.scaleStepLabel.AutoSize = true;
            this.scaleStepLabel.Location = new System.Drawing.Point(60, 34);
            this.scaleStepLabel.Name = "scaleStepLabel";
            this.scaleStepLabel.Size = new System.Drawing.Size(57, 13);
            this.scaleStepLabel.TabIndex = 2;
            this.scaleStepLabel.Text = "Scale step";
            // 
            // originMovementStepValue
            // 
            this.originMovementStepValue.Location = new System.Drawing.Point(123, 6);
            this.originMovementStepValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.originMovementStepValue.Name = "originMovementStepValue";
            this.originMovementStepValue.Size = new System.Drawing.Size(73, 20);
            this.originMovementStepValue.TabIndex = 1;
            this.originMovementStepValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // scaleStepValue
            // 
            this.scaleStepValue.Location = new System.Drawing.Point(123, 32);
            this.scaleStepValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleStepValue.Name = "scaleStepValue";
            this.scaleStepValue.Size = new System.Drawing.Size(73, 20);
            this.scaleStepValue.TabIndex = 0;
            this.scaleStepValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // invertedDirectionCheckbox
            // 
            this.invertedDirectionCheckbox.AutoSize = true;
            this.invertedDirectionCheckbox.Location = new System.Drawing.Point(63, 81);
            this.invertedDirectionCheckbox.Name = "invertedDirectionCheckbox";
            this.invertedDirectionCheckbox.Size = new System.Drawing.Size(128, 17);
            this.invertedDirectionCheckbox.TabIndex = 1;
            this.invertedDirectionCheckbox.Text = "Inverted key direction";
            this.invertedDirectionCheckbox.UseVisualStyleBackColor = true;
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(58, 65);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(59, 13);
            this.fpsLabel.TabIndex = 3;
            this.fpsLabel.Text = "Render fps";
            // 
            // fpsValue
            // 
            this.fpsValue.Location = new System.Drawing.Point(123, 58);
            this.fpsValue.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.fpsValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fpsValue.Name = "fpsValue";
            this.fpsValue.Size = new System.Drawing.Size(73, 20);
            this.fpsValue.TabIndex = 1;
            this.fpsValue.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // sidePanel1
            // 
            this.sidePanel1.BackColor = System.Drawing.Color.White;
            this.sidePanel1.Controls.Add(this.objectListView);
            this.sidePanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel1.Location = new System.Drawing.Point(0, 130);
            this.sidePanel1.Name = "sidePanel1";
            this.sidePanel1.Size = new System.Drawing.Size(200, 504);
            this.sidePanel1.TabIndex = 1;
            // 
            // objectListView
            // 
            this.objectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.objectListView.FormattingEnabled = true;
            this.objectListView.Location = new System.Drawing.Point(0, 0);
            this.objectListView.Name = "objectListView";
            this.objectListView.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.objectListView.Size = new System.Drawing.Size(200, 504);
            this.objectListView.TabIndex = 0;
            this.objectListView.DoubleClick += new System.EventHandler(this.objectListView_DoubleClick);
            // 
            // drawingAreaStatusStrip
            // 
            this.drawingAreaStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secondLastPointLabel,
            this.secondLastPointLabelValue,
            this.scaleLabel,
            this.scaleLabelValue});
            this.drawingAreaStatusStrip.Location = new System.Drawing.Point(200, 612);
            this.drawingAreaStatusStrip.Name = "drawingAreaStatusStrip";
            this.drawingAreaStatusStrip.Size = new System.Drawing.Size(1068, 22);
            this.drawingAreaStatusStrip.TabIndex = 2;
            // 
            // secondLastPointLabel
            // 
            this.secondLastPointLabel.Name = "secondLastPointLabel";
            this.secondLastPointLabel.Size = new System.Drawing.Size(85, 17);
            this.secondLastPointLabel.Text = "Selected Point:";
            // 
            // secondLastPointLabelValue
            // 
            this.secondLastPointLabelValue.Name = "secondLastPointLabelValue";
            this.secondLastPointLabelValue.Size = new System.Drawing.Size(11, 17);
            this.secondLastPointLabelValue.Text = "t";
            // 
            // scaleLabel
            // 
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(37, 17);
            this.scaleLabel.Text = "Scale:";
            // 
            // scaleLabelValue
            // 
            this.scaleLabelValue.Name = "scaleLabelValue";
            this.scaleLabelValue.Size = new System.Drawing.Size(25, 17);
            this.scaleLabelValue.Text = "100";
            // 
            // drawingArea
            // 
            this.drawingArea.BackColor = System.Drawing.SystemColors.Highlight;
            this.drawingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingArea.Location = new System.Drawing.Point(200, 130);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(1068, 482);
            this.drawingArea.TabIndex = 3;
            this.drawingArea.TabStop = false;
            this.drawingArea.Click += new System.EventHandler(this.drawingArea_Click);
            this.drawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseDown);
            this.drawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseMove);
            this.drawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseUp);
            this.drawingArea.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseWheel);
            // 
            // paraelButton
            // 
            this.paraelButton.Location = new System.Drawing.Point(300, 20);
            this.paraelButton.Name = "paraelButton";
            this.paraelButton.Size = new System.Drawing.Size(75, 23);
            this.paraelButton.TabIndex = 3;
            this.paraelButton.Text = "Parael";
            this.paraelButton.UseVisualStyleBackColor = true;
            this.paraelButton.Click += new System.EventHandler(this.paraelButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Untitled";
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.White;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1268, 634);
            this.Controls.Add(this.drawingArea);
            this.Controls.Add(this.drawingAreaStatusStrip);
            this.Controls.Add(this.sidePanel1);
            this.Controls.Add(this.topPanel);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invertor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.topPanel.ResumeLayout(false);
            this.topRibbonTab.ResumeLayout(false);
            this.fileTabPage.ResumeLayout(false);
            this.drawTapPage.ResumeLayout(false);
            this.drawTapPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineColorPicture)).EndInit();
            this.viewTabPage.ResumeLayout(false);
            this.viewTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectBackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originMovementStepValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleStepValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsValue)).EndInit();
            this.sidePanel1.ResumeLayout(false);
            this.drawingAreaStatusStrip.ResumeLayout(false);
            this.drawingAreaStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.CheckBox lineButton;
        private System.Windows.Forms.CheckBox rectangleButton;
        private System.Windows.Forms.CheckBox circleButton;
        private System.Windows.Forms.TabControl topRibbonTab;
        private System.Windows.Forms.TabPage fileTabPage;
        private System.Windows.Forms.Button fileSaveAsButton;
        private System.Windows.Forms.Button fileSaveButton;
        private System.Windows.Forms.Button fileOpenButton;
        private System.Windows.Forms.Button fileNewButton;
        private System.Windows.Forms.TabPage drawTapPage;
        private System.Windows.Forms.Panel sidePanel1;
        private System.Windows.Forms.ListBox objectListView;
        private System.Windows.Forms.StatusStrip drawingAreaStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel secondLastPointLabel;
        private System.Windows.Forms.ToolStripStatusLabel secondLastPointLabelValue;
        public System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.ToolStripStatusLabel scaleLabel;
        private System.Windows.Forms.ToolStripStatusLabel scaleLabelValue;
        private System.Windows.Forms.TabPage viewTabPage;
        private System.Windows.Forms.Label originMovementStepLabel;
        private System.Windows.Forms.Label scaleStepLabel;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.NumericUpDown originMovementStepValue;
        private System.Windows.Forms.NumericUpDown scaleStepValue;
        private System.Windows.Forms.NumericUpDown fpsValue;
        private System.Windows.Forms.CheckBox invertedDirectionCheckbox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        public System.Windows.Forms.PictureBox lineColorPicture;
        private System.Windows.Forms.Button lineColorButton;
        public System.Windows.Forms.ColorDialog colorDialog;
        public System.Windows.Forms.NumericUpDown lineThicknessValue;
        private System.Windows.Forms.Label lineThicknessLabel;
        private System.Windows.Forms.Button selectBackColorButton;
        private System.Windows.Forms.PictureBox selectBackColor;
        private System.Windows.Forms.Button paraelButton;
    }
}

