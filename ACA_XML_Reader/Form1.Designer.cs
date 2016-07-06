namespace ACA_XML_Reader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Check_File = new System.Windows.Forms.Button();
            this.listBox_errorIDs = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_ErrorFile = new System.Windows.Forms.TextBox();
            this.textBox_SubmissionFile = new System.Windows.Forms.TextBox();
            this.recordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Check_File
            // 
            this.button_Check_File.Location = new System.Drawing.Point(376, 439);
            this.button_Check_File.Name = "button_Check_File";
            this.button_Check_File.Size = new System.Drawing.Size(75, 23);
            this.button_Check_File.TabIndex = 0;
            this.button_Check_File.Text = "Check File";
            this.button_Check_File.UseVisualStyleBackColor = true;
            this.button_Check_File.Click += new System.EventHandler(this.button_Check_File_Click);
            // 
            // listBox_errorIDs
            // 
            this.listBox_errorIDs.FormattingEnabled = true;
            this.listBox_errorIDs.Location = new System.Drawing.Point(12, 12);
            this.listBox_errorIDs.Name = "listBox_errorIDs";
            this.listBox_errorIDs.Size = new System.Drawing.Size(120, 95);
            this.listBox_errorIDs.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recordID,
            this.firstName,
            this.lastName,
            this.SSN});
            this.dataGridView1.Location = new System.Drawing.Point(12, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(771, 320);
            this.dataGridView1.TabIndex = 4;
            // 
            // textBox_ErrorFile
            // 
            this.textBox_ErrorFile.Location = new System.Drawing.Point(430, 21);
            this.textBox_ErrorFile.Name = "textBox_ErrorFile";
            this.textBox_ErrorFile.Size = new System.Drawing.Size(266, 20);
            this.textBox_ErrorFile.TabIndex = 5;
            // 
            // textBox_SubmissionFile
            // 
            this.textBox_SubmissionFile.Location = new System.Drawing.Point(430, 47);
            this.textBox_SubmissionFile.Name = "textBox_SubmissionFile";
            this.textBox_SubmissionFile.Size = new System.Drawing.Size(266, 20);
            this.textBox_SubmissionFile.TabIndex = 6;
            // 
            // recordID
            // 
            this.recordID.HeaderText = "Record ID";
            this.recordID.Name = "recordID";
            // 
            // firstName
            // 
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            // 
            // lastName
            // 
            this.lastName.HeaderText = "Last Name";
            this.lastName.Name = "lastName";
            // 
            // SSN
            // 
            this.SSN.HeaderText = "SSN";
            this.SSN.Name = "SSN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 474);
            this.Controls.Add(this.textBox_SubmissionFile);
            this.Controls.Add(this.textBox_ErrorFile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBox_errorIDs);
            this.Controls.Add(this.button_Check_File);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ACA Error Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Check_File;
        private System.Windows.Forms.ListBox listBox_errorIDs;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_ErrorFile;
        private System.Windows.Forms.TextBox textBox_SubmissionFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSN;
    }
}

