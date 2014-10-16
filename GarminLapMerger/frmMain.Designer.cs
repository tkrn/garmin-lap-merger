namespace GarminLapMerger
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.lstSelectedFiles = new System.Windows.Forms.ListBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lnkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(12, 14);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(117, 23);
            this.btnBrowseFolder.TabIndex = 0;
            this.btnBrowseFolder.Text = "Browse Folder";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // lstSelectedFiles
            // 
            this.lstSelectedFiles.FormattingEnabled = true;
            this.lstSelectedFiles.Location = new System.Drawing.Point(12, 43);
            this.lstSelectedFiles.MultiColumn = true;
            this.lstSelectedFiles.Name = "lstSelectedFiles";
            this.lstSelectedFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSelectedFiles.Size = new System.Drawing.Size(445, 95);
            this.lstSelectedFiles.TabIndex = 1;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(135, 16);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(322, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.Text = "BrowseFolderPath";
            // 
            // btnMerge
            // 
            this.btnMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMerge.Location = new System.Drawing.Point(333, 144);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(126, 23);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "Merge as New File";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "tcx";
            this.saveFileDialog.FileName = "Combined.tcx";
            this.saveFileDialog.Filter = "Garmin TCX File|*.tcx";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select the folder which contains the Garmin TCX GPS files.";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // lnkLabel
            // 
            this.lnkLabel.AutoSize = true;
            this.lnkLabel.Location = new System.Drawing.Point(12, 149);
            this.lnkLabel.Name = "lnkLabel";
            this.lnkLabel.Size = new System.Drawing.Size(115, 13);
            this.lnkLabel.TabIndex = 2;
            this.lnkLabel.TabStop = true;
            this.lnkLabel.Text = "www.nerdthinking.com";
            this.lnkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLabel_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 177);
            this.Controls.Add(this.lnkLabel);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.lstSelectedFiles);
            this.Controls.Add(this.btnBrowseFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garmin Lap Merger - Version 1.0";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.ListBox lstSelectedFiles;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.LinkLabel lnkLabel;
    }
}

