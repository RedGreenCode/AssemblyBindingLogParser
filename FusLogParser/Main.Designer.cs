namespace FusLogParser
{
    partial class Main
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
            this.lstFileNames = new System.Windows.Forms.ListBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnOpenOriginal = new System.Windows.Forms.Button();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnGenerateBindingRedirect = new System.Windows.Forms.Button();
            this.btnGenerateCopyCommand = new System.Windows.Forms.Button();
            this.txtAssemblyLocation = new System.Windows.Forms.TextBox();
            this.lblLogLocation = new System.Windows.Forms.Label();
            this.lblAssemblyLocation = new System.Windows.Forms.Label();
            this.btnCopyTargetAssemblyName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstFileNames
            // 
            this.lstFileNames.FormattingEnabled = true;
            this.lstFileNames.Location = new System.Drawing.Point(12, 95);
            this.lstFileNames.Name = "lstFileNames";
            this.lstFileNames.Size = new System.Drawing.Size(1189, 147);
            this.lstFileNames.TabIndex = 0;
            this.lstFileNames.SelectedIndexChanged += new System.EventHandler(this.lstFileNames_SelectedIndexChanged);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(113, 13);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(1088, 20);
            this.txtPath.TabIndex = 1;
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(13, 259);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(1188, 515);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.Text = "";
            // 
            // btnOpenOriginal
            // 
            this.btnOpenOriginal.Location = new System.Drawing.Point(1218, 192);
            this.btnOpenOriginal.Name = "btnOpenOriginal";
            this.btnOpenOriginal.Size = new System.Drawing.Size(122, 35);
            this.btnOpenOriginal.TabIndex = 3;
            this.btnOpenOriginal.Text = "Open Original";
            this.btnOpenOriginal.UseVisualStyleBackColor = true;
            this.btnOpenOriginal.Click += new System.EventHandler(this.btnOpenOriginal_Click);
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Location = new System.Drawing.Point(1218, 233);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(122, 35);
            this.btnOpenConfig.TabIndex = 4;
            this.btnOpenConfig.Text = "Open Config";
            this.btnOpenConfig.UseVisualStyleBackColor = true;
            this.btnOpenConfig.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1218, 274);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(122, 35);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(1218, 315);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(122, 34);
            this.btnDeleteAll.TabIndex = 6;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnGenerateBindingRedirect
            // 
            this.btnGenerateBindingRedirect.Location = new System.Drawing.Point(1218, 403);
            this.btnGenerateBindingRedirect.Name = "btnGenerateBindingRedirect";
            this.btnGenerateBindingRedirect.Size = new System.Drawing.Size(122, 42);
            this.btnGenerateBindingRedirect.TabIndex = 7;
            this.btnGenerateBindingRedirect.Text = "Generate Binding Redirect to Clipboard";
            this.btnGenerateBindingRedirect.UseVisualStyleBackColor = true;
            this.btnGenerateBindingRedirect.Click += new System.EventHandler(this.btnGenerateBindingRedirect_Click);
            // 
            // btnGenerateCopyCommand
            // 
            this.btnGenerateCopyCommand.Location = new System.Drawing.Point(1218, 451);
            this.btnGenerateCopyCommand.Name = "btnGenerateCopyCommand";
            this.btnGenerateCopyCommand.Size = new System.Drawing.Size(122, 39);
            this.btnGenerateCopyCommand.TabIndex = 8;
            this.btnGenerateCopyCommand.Text = "Generate Copy Command to Clipboard";
            this.btnGenerateCopyCommand.UseVisualStyleBackColor = true;
            this.btnGenerateCopyCommand.Click += new System.EventHandler(this.btnGenerateCopyCommand_Click);
            // 
            // txtAssemblyLocation
            // 
            this.txtAssemblyLocation.Location = new System.Drawing.Point(113, 51);
            this.txtAssemblyLocation.Name = "txtAssemblyLocation";
            this.txtAssemblyLocation.Size = new System.Drawing.Size(1088, 20);
            this.txtAssemblyLocation.TabIndex = 9;
            // 
            // lblLogLocation
            // 
            this.lblLogLocation.AutoSize = true;
            this.lblLogLocation.Location = new System.Drawing.Point(12, 19);
            this.lblLogLocation.Name = "lblLogLocation";
            this.lblLogLocation.Size = new System.Drawing.Size(84, 13);
            this.lblLogLocation.TabIndex = 10;
            this.lblLogLocation.Text = "Log file location:";
            // 
            // lblAssemblyLocation
            // 
            this.lblAssemblyLocation.AutoSize = true;
            this.lblAssemblyLocation.Location = new System.Drawing.Point(13, 51);
            this.lblAssemblyLocation.Name = "lblAssemblyLocation";
            this.lblAssemblyLocation.Size = new System.Drawing.Size(94, 13);
            this.lblAssemblyLocation.TabIndex = 11;
            this.lblAssemblyLocation.Text = "Assembly location:";
            // 
            // btnCopyTargetAssemblyName
            // 
            this.btnCopyTargetAssemblyName.Location = new System.Drawing.Point(1218, 497);
            this.btnCopyTargetAssemblyName.Name = "btnCopyTargetAssemblyName";
            this.btnCopyTargetAssemblyName.Size = new System.Drawing.Size(122, 37);
            this.btnCopyTargetAssemblyName.TabIndex = 12;
            this.btnCopyTargetAssemblyName.Text = "Copy Target Assembly Name to Clipboard";
            this.btnCopyTargetAssemblyName.UseVisualStyleBackColor = true;
            this.btnCopyTargetAssemblyName.Click += new System.EventHandler(this.btnCopyTargetAssemblyName_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 786);
            this.Controls.Add(this.btnCopyTargetAssemblyName);
            this.Controls.Add(this.lblAssemblyLocation);
            this.Controls.Add(this.lblLogLocation);
            this.Controls.Add(this.txtAssemblyLocation);
            this.Controls.Add(this.btnGenerateCopyCommand);
            this.Controls.Add(this.btnGenerateBindingRedirect);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnOpenConfig);
            this.Controls.Add(this.btnOpenOriginal);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lstFileNames);
            this.Name = "Main";
            this.Text = "Assembly Log Parser";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFileNames;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button btnOpenOriginal;
        private System.Windows.Forms.Button btnOpenConfig;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnGenerateBindingRedirect;
        private System.Windows.Forms.Button btnGenerateCopyCommand;
        private System.Windows.Forms.TextBox txtAssemblyLocation;
        private System.Windows.Forms.Label lblLogLocation;
        private System.Windows.Forms.Label lblAssemblyLocation;
        private System.Windows.Forms.Button btnCopyTargetAssemblyName;
    }
}

