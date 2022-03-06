
namespace Book_Kepping
{
    partial class DatabaseSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_DatabaseName = new System.Windows.Forms.TextBox();
            this.TB_TableName = new System.Windows.Forms.TextBox();
            this.B_Verify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cash Method Table Name";
            // 
            // TB_DatabaseName
            // 
            this.TB_DatabaseName.Location = new System.Drawing.Point(153, 12);
            this.TB_DatabaseName.Name = "TB_DatabaseName";
            this.TB_DatabaseName.Size = new System.Drawing.Size(430, 23);
            this.TB_DatabaseName.TabIndex = 2;
            // 
            // TB_TableName
            // 
            this.TB_TableName.Location = new System.Drawing.Point(153, 47);
            this.TB_TableName.Name = "TB_TableName";
            this.TB_TableName.Size = new System.Drawing.Size(430, 23);
            this.TB_TableName.TabIndex = 3;
            // 
            // B_Verify
            // 
            this.B_Verify.Location = new System.Drawing.Point(153, 76);
            this.B_Verify.Name = "B_Verify";
            this.B_Verify.Size = new System.Drawing.Size(135, 39);
            this.B_Verify.TabIndex = 4;
            this.B_Verify.Text = "Verify Data";
            this.B_Verify.UseVisualStyleBackColor = true;
            this.B_Verify.Click += new System.EventHandler(this.B_Verify_Click);
            // 
            // DatabaseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 120);
            this.Controls.Add(this.B_Verify);
            this.Controls.Add(this.TB_TableName);
            this.Controls.Add(this.TB_DatabaseName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseSettings";
            this.Text = "DatabaseSettings";
            this.Load += new System.EventHandler(this.DatabaseSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_DatabaseName;
        private System.Windows.Forms.TextBox TB_TableName;
        private System.Windows.Forms.Button B_Verify;
    }
}