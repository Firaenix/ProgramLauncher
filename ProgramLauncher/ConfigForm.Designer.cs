namespace ProgramLauncher
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.initAppBrowseBtn = new System.Windows.Forms.Button();
            this.initAppLabel = new System.Windows.Forms.Label();
            this.initAppTextBox = new System.Windows.Forms.TextBox();
            this.initAppDialog = new System.Windows.Forms.OpenFileDialog();
            this.addNewSectionBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.initParamsTbx = new System.Windows.Forms.TextBox();
            this.initParamsLabel = new System.Windows.Forms.Label();
            this.expandPanelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // initAppBrowseBtn
            // 
            this.initAppBrowseBtn.AutoSize = true;
            this.initAppBrowseBtn.Location = new System.Drawing.Point(506, 44);
            this.initAppBrowseBtn.Name = "initAppBrowseBtn";
            this.initAppBrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.initAppBrowseBtn.TabIndex = 0;
            this.initAppBrowseBtn.Text = "Browse";
            this.initAppBrowseBtn.UseVisualStyleBackColor = true;
            this.initAppBrowseBtn.Click += new System.EventHandler(this.initAppBrowseBtn_Click);
            // 
            // initAppLabel
            // 
            this.initAppLabel.AutoSize = true;
            this.initAppLabel.Location = new System.Drawing.Point(22, 25);
            this.initAppLabel.Name = "initAppLabel";
            this.initAppLabel.Size = new System.Drawing.Size(100, 13);
            this.initAppLabel.TabIndex = 1;
            this.initAppLabel.Text = "Original Application:";
            // 
            // initAppTextBox
            // 
            this.initAppTextBox.BackColor = System.Drawing.Color.White;
            this.initAppTextBox.Location = new System.Drawing.Point(22, 46);
            this.initAppTextBox.Name = "initAppTextBox";
            this.initAppTextBox.ReadOnly = true;
            this.initAppTextBox.Size = new System.Drawing.Size(276, 20);
            this.initAppTextBox.TabIndex = 2;
            // 
            // initAppDialog
            // 
            this.initAppDialog.Filter = "Exe files (*.exe)|*.exe|All files (*.*)|*.*";
            // 
            // addNewSectionBtn
            // 
            this.addNewSectionBtn.Location = new System.Drawing.Point(579, 5);
            this.addNewSectionBtn.Name = "addNewSectionBtn";
            this.addNewSectionBtn.Size = new System.Drawing.Size(25, 25);
            this.addNewSectionBtn.TabIndex = 3;
            this.addNewSectionBtn.Text = "+";
            this.addNewSectionBtn.UseVisualStyleBackColor = true;
            this.addNewSectionBtn.Click += new System.EventHandler(this.addNewSectionBtn_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(612, 139);
            this.flowLayoutPanel.TabIndex = 4;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // splitContainer
            // 
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(-2, -1);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.initParamsTbx);
            this.splitContainer.Panel1.Controls.Add(this.initParamsLabel);
            this.splitContainer.Panel1.Controls.Add(this.expandPanelBtn);
            this.splitContainer.Panel1.Controls.Add(this.initAppTextBox);
            this.splitContainer.Panel1.Controls.Add(this.initAppBrowseBtn);
            this.splitContainer.Panel1.Controls.Add(this.addNewSectionBtn);
            this.splitContainer.Panel1.Controls.Add(this.initAppLabel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.flowLayoutPanel);
            this.splitContainer.Panel2Collapsed = true;
            this.splitContainer.Size = new System.Drawing.Size(615, 285);
            this.splitContainer.SplitterDistance = 98;
            this.splitContainer.TabIndex = 6;
            // 
            // initParamsTbx
            // 
            this.initParamsTbx.Location = new System.Drawing.Point(309, 46);
            this.initParamsTbx.Name = "initParamsTbx";
            this.initParamsTbx.Size = new System.Drawing.Size(185, 20);
            this.initParamsTbx.TabIndex = 6;
            // 
            // initParamsLabel
            // 
            this.initParamsLabel.AutoSize = true;
            this.initParamsLabel.Location = new System.Drawing.Point(307, 25);
            this.initParamsLabel.Name = "initParamsLabel";
            this.initParamsLabel.Size = new System.Drawing.Size(63, 13);
            this.initParamsLabel.TabIndex = 5;
            this.initParamsLabel.Text = "Parameters:";
            // 
            // expandPanelBtn
            // 
            this.expandPanelBtn.Location = new System.Drawing.Point(273, 69);
            this.expandPanelBtn.Name = "expandPanelBtn";
            this.expandPanelBtn.Size = new System.Drawing.Size(75, 23);
            this.expandPanelBtn.TabIndex = 4;
            this.expandPanelBtn.Text = "Show All";
            this.expandPanelBtn.UseVisualStyleBackColor = true;
            this.expandPanelBtn.Click += new System.EventHandler(this.expandPanelBtn_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(613, 94);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(629, 133);
            this.Name = "ConfigForm";
            this.Text = "Program Launcher Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing_Click);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button initAppBrowseBtn;
        private System.Windows.Forms.Label initAppLabel;
        private System.Windows.Forms.TextBox initAppTextBox;
        private System.Windows.Forms.OpenFileDialog initAppDialog;
        private System.Windows.Forms.Button addNewSectionBtn;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button expandPanelBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.TextBox initParamsTbx;
        private System.Windows.Forms.Label initParamsLabel;
    }
}

