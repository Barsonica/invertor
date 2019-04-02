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
            this.lineButton = new System.Windows.Forms.CheckBox();
            this.sidePanel1 = new System.Windows.Forms.Panel();
            this.objectListView = new System.Windows.Forms.ListBox();
            this.drawingAreaStatusStrip = new System.Windows.Forms.StatusStrip();
            this.firstLastPointLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.firstLastPointLabelValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.secondLastPointLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.secondLastPointLabelValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.topPanel.SuspendLayout();
            this.topRibbonTab.SuspendLayout();
            this.fileTabPage.SuspendLayout();
            this.drawTapPage.SuspendLayout();
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
            // 
            // fileSaveButton
            // 
            this.fileSaveButton.Location = new System.Drawing.Point(170, 6);
            this.fileSaveButton.Name = "fileSaveButton";
            this.fileSaveButton.Size = new System.Drawing.Size(75, 23);
            this.fileSaveButton.TabIndex = 2;
            this.fileSaveButton.Text = "Save";
            this.fileSaveButton.UseVisualStyleBackColor = true;
            // 
            // fileOpenButton
            // 
            this.fileOpenButton.Location = new System.Drawing.Point(89, 6);
            this.fileOpenButton.Name = "fileOpenButton";
            this.fileOpenButton.Size = new System.Drawing.Size(75, 23);
            this.fileOpenButton.TabIndex = 1;
            this.fileOpenButton.Text = "Open";
            this.fileOpenButton.UseVisualStyleBackColor = true;
            // 
            // fileNewButton
            // 
            this.fileNewButton.Location = new System.Drawing.Point(8, 6);
            this.fileNewButton.Name = "fileNewButton";
            this.fileNewButton.Size = new System.Drawing.Size(75, 23);
            this.fileNewButton.TabIndex = 0;
            this.fileNewButton.Text = "New";
            this.fileNewButton.UseVisualStyleBackColor = true;
            // 
            // drawTapPage
            // 
            this.drawTapPage.Controls.Add(this.lineButton);
            this.drawTapPage.Location = new System.Drawing.Point(4, 22);
            this.drawTapPage.Name = "drawTapPage";
            this.drawTapPage.Padding = new System.Windows.Forms.Padding(3);
            this.drawTapPage.Size = new System.Drawing.Size(1260, 104);
            this.drawTapPage.TabIndex = 1;
            this.drawTapPage.Text = "Draw";
            this.drawTapPage.UseVisualStyleBackColor = true;
            // 
            // lineButton
            // 
            this.lineButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.lineButton.AutoSize = true;
            this.lineButton.Location = new System.Drawing.Point(8, 6);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(37, 23);
            this.lineButton.TabIndex = 1;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.CheckedChanged += new System.EventHandler(this.lineButton_CheckedChanged);
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
            this.objectListView.FormattingEnabled = true;
            this.objectListView.Location = new System.Drawing.Point(0, 0);
            this.objectListView.Name = "objectListView";
            this.objectListView.Size = new System.Drawing.Size(200, 504);
            this.objectListView.TabIndex = 0;
            // 
            // drawingAreaStatusStrip
            // 
            this.drawingAreaStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstLastPointLabel,
            this.firstLastPointLabelValue,
            this.secondLastPointLabel,
            this.secondLastPointLabelValue});
            this.drawingAreaStatusStrip.Location = new System.Drawing.Point(200, 612);
            this.drawingAreaStatusStrip.Name = "drawingAreaStatusStrip";
            this.drawingAreaStatusStrip.Size = new System.Drawing.Size(1068, 22);
            this.drawingAreaStatusStrip.TabIndex = 2;
            // 
            // firstLastPointLabel
            // 
            this.firstLastPointLabel.Name = "firstLastPointLabel";
            this.firstLastPointLabel.Size = new System.Drawing.Size(63, 17);
            this.firstLastPointLabel.Text = "First Point:";
            // 
            // firstLastPointLabelValue
            // 
            this.firstLastPointLabelValue.Name = "firstLastPointLabelValue";
            this.firstLastPointLabelValue.Size = new System.Drawing.Size(13, 17);
            this.firstLastPointLabelValue.Text = "v";
            // 
            // secondLastPointLabel
            // 
            this.secondLastPointLabel.Name = "secondLastPointLabel";
            this.secondLastPointLabel.Size = new System.Drawing.Size(80, 17);
            this.secondLastPointLabel.Text = "Second Point:";
            // 
            // secondLastPointLabelValue
            // 
            this.secondLastPointLabelValue.Name = "secondLastPointLabelValue";
            this.secondLastPointLabelValue.Size = new System.Drawing.Size(11, 17);
            this.secondLastPointLabelValue.Text = "t";
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
            this.drawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingArea_Paint);
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
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.topPanel.ResumeLayout(false);
            this.topRibbonTab.ResumeLayout(false);
            this.fileTabPage.ResumeLayout(false);
            this.drawTapPage.ResumeLayout(false);
            this.drawTapPage.PerformLayout();
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
        private System.Windows.Forms.ToolStripStatusLabel firstLastPointLabel;
        private System.Windows.Forms.ToolStripStatusLabel firstLastPointLabelValue;
        private System.Windows.Forms.ToolStripStatusLabel secondLastPointLabel;
        private System.Windows.Forms.ToolStripStatusLabel secondLastPointLabelValue;
        private System.Windows.Forms.PictureBox drawingArea;
    }
}

