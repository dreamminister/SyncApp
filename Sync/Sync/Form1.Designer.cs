namespace Sync
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
            this.FirstDirLB = new System.Windows.Forms.ListBox();
            this.SecondDirLB = new System.Windows.Forms.ListBox();
            this.firstDirNameLbl = new System.Windows.Forms.Label();
            this.SecondDirNameLbl = new System.Windows.Forms.Label();
            this.firstDirSelectBtn = new System.Windows.Forms.Button();
            this.secondDirSelectBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.SyncBtn = new System.Windows.Forms.Button();
            this.statusMessageStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusMessageStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FirstDirLB
            // 
            this.FirstDirLB.FormattingEnabled = true;
            this.FirstDirLB.Location = new System.Drawing.Point(23, 38);
            this.FirstDirLB.Name = "FirstDirLB";
            this.FirstDirLB.Size = new System.Drawing.Size(350, 199);
            this.FirstDirLB.TabIndex = 0;
            this.FirstDirLB.SelectedIndexChanged += new System.EventHandler(this.FileList_SelectedIndexChanged);
            // 
            // SecondDirLB
            // 
            this.SecondDirLB.FormattingEnabled = true;
            this.SecondDirLB.Location = new System.Drawing.Point(420, 38);
            this.SecondDirLB.Name = "SecondDirLB";
            this.SecondDirLB.Size = new System.Drawing.Size(350, 199);
            this.SecondDirLB.TabIndex = 1;
            this.SecondDirLB.SelectedIndexChanged += new System.EventHandler(this.FileList_SelectedIndexChanged);
            // 
            // firstDirNameLbl
            // 
            this.firstDirNameLbl.AutoSize = true;
            this.firstDirNameLbl.Location = new System.Drawing.Point(26, 22);
            this.firstDirNameLbl.Name = "firstDirNameLbl";
            this.firstDirNameLbl.Size = new System.Drawing.Size(0, 13);
            this.firstDirNameLbl.TabIndex = 2;
            // 
            // SecondDirNameLbl
            // 
            this.SecondDirNameLbl.AutoSize = true;
            this.SecondDirNameLbl.Location = new System.Drawing.Point(423, 22);
            this.SecondDirNameLbl.Name = "SecondDirNameLbl";
            this.SecondDirNameLbl.Size = new System.Drawing.Size(0, 13);
            this.SecondDirNameLbl.TabIndex = 3;
            // 
            // firstDirSelectBtn
            // 
            this.firstDirSelectBtn.Location = new System.Drawing.Point(23, 244);
            this.firstDirSelectBtn.Name = "firstDirSelectBtn";
            this.firstDirSelectBtn.Size = new System.Drawing.Size(91, 23);
            this.firstDirSelectBtn.TabIndex = 4;
            this.firstDirSelectBtn.Text = "Select Dir #1";
            this.firstDirSelectBtn.UseVisualStyleBackColor = true;
            this.firstDirSelectBtn.Click += new System.EventHandler(this.DirSelectBtn_Click);
            // 
            // secondDirSelectBtn
            // 
            this.secondDirSelectBtn.Location = new System.Drawing.Point(420, 244);
            this.secondDirSelectBtn.Name = "secondDirSelectBtn";
            this.secondDirSelectBtn.Size = new System.Drawing.Size(91, 23);
            this.secondDirSelectBtn.TabIndex = 5;
            this.secondDirSelectBtn.Text = "Select Dir #2";
            this.secondDirSelectBtn.UseVisualStyleBackColor = true;
            this.secondDirSelectBtn.Click += new System.EventHandler(this.DirSelectBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ResetBtn);
            this.groupBox1.Controls.Add(this.AddBtn);
            this.groupBox1.Controls.Add(this.DelBtn);
            this.groupBox1.Controls.Add(this.SyncBtn);
            this.groupBox1.Location = new System.Drawing.Point(177, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 66);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // ResetBtn
            // 
            this.ResetBtn.Enabled = false;
            this.ResetBtn.Location = new System.Drawing.Point(320, 28);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(75, 23);
            this.ResetBtn.TabIndex = 3;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Enabled = false;
            this.AddBtn.Location = new System.Drawing.Point(220, 28);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "Add file";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Enabled = false;
            this.DelBtn.Location = new System.Drawing.Point(117, 28);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(75, 23);
            this.DelBtn.TabIndex = 1;
            this.DelBtn.Text = "Delete file";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // SyncBtn
            // 
            this.SyncBtn.Enabled = false;
            this.SyncBtn.Location = new System.Drawing.Point(15, 28);
            this.SyncBtn.Name = "SyncBtn";
            this.SyncBtn.Size = new System.Drawing.Size(75, 23);
            this.SyncBtn.TabIndex = 0;
            this.SyncBtn.Text = "Sync";
            this.SyncBtn.UseVisualStyleBackColor = true;
            this.SyncBtn.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // statusMessageStrip
            // 
            this.statusMessageStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusMessage});
            this.statusMessageStrip.Location = new System.Drawing.Point(0, 386);
            this.statusMessageStrip.Name = "statusMessageStrip";
            this.statusMessageStrip.Size = new System.Drawing.Size(793, 22);
            this.statusMessageStrip.SizingGrip = false;
            this.statusMessageStrip.TabIndex = 7;
            // 
            // toolStripStatusMessage
            // 
            this.toolStripStatusMessage.Name = "toolStripStatusMessage";
            this.toolStripStatusMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 408);
            this.Controls.Add(this.statusMessageStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.secondDirSelectBtn);
            this.Controls.Add(this.firstDirSelectBtn);
            this.Controls.Add(this.SecondDirNameLbl);
            this.Controls.Add(this.firstDirNameLbl);
            this.Controls.Add(this.SecondDirLB);
            this.Controls.Add(this.FirstDirLB);
            this.Name = "Form1";
            this.Text = "Sync";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusMessageStrip.ResumeLayout(false);
            this.statusMessageStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FirstDirLB;
        private System.Windows.Forms.ListBox SecondDirLB;
        private System.Windows.Forms.Label firstDirNameLbl;
        private System.Windows.Forms.Label SecondDirNameLbl;
        private System.Windows.Forms.Button firstDirSelectBtn;
        private System.Windows.Forms.Button secondDirSelectBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button SyncBtn;
        private System.Windows.Forms.StatusStrip statusMessageStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusMessage;
    }
}

