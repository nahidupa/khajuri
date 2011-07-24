namespace MySqlBTToolKit
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
            this.btnDBManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDBManager
            // 
            this.btnDBManager.Location = new System.Drawing.Point(205, 12);
            this.btnDBManager.Name = "btnDBManager";
            this.btnDBManager.Size = new System.Drawing.Size(75, 23);
            this.btnDBManager.TabIndex = 0;
            this.btnDBManager.Text = "Test";
            this.btnDBManager.UseVisualStyleBackColor = true;
            this.btnDBManager.Click += new System.EventHandler(this.btnDBManager_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnDBManager);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDBManager;
    }
}

