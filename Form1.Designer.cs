
namespace Book_Kepping
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BT_cash_method = new System.Windows.Forms.Button();
            this.B_DatabaseInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BT_cash_method
            // 
            this.BT_cash_method.Location = new System.Drawing.Point(12, 12);
            this.BT_cash_method.Name = "BT_cash_method";
            this.BT_cash_method.Size = new System.Drawing.Size(356, 60);
            this.BT_cash_method.TabIndex = 2;
            this.BT_cash_method.Text = "Insert Data Entries";
            this.BT_cash_method.UseVisualStyleBackColor = true;
            this.BT_cash_method.Click += new System.EventHandler(this.BT_cash_method_Click);
            // 
            // B_DatabaseInfo
            // 
            this.B_DatabaseInfo.Location = new System.Drawing.Point(12, 78);
            this.B_DatabaseInfo.Name = "B_DatabaseInfo";
            this.B_DatabaseInfo.Size = new System.Drawing.Size(356, 34);
            this.B_DatabaseInfo.TabIndex = 3;
            this.B_DatabaseInfo.Text = "Cash Method Database Information Settings";
            this.B_DatabaseInfo.UseVisualStyleBackColor = true;
            this.B_DatabaseInfo.Click += new System.EventHandler(this.B_DatabaseInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 123);
            this.Controls.Add(this.B_DatabaseInfo);
            this.Controls.Add(this.BT_cash_method);
            this.Name = "Form1";
            this.Text = "Book Keeping Method";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BT_cash_method;
        private System.Windows.Forms.Button B_DatabaseInfo;
    }
}

