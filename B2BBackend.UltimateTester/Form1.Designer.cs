﻿namespace B2BBackend.UltimateTester
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
            this.btn_checklog = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_checklog
            // 
            this.btn_checklog.Location = new System.Drawing.Point(24, 12);
            this.btn_checklog.Name = "btn_checklog";
            this.btn_checklog.Size = new System.Drawing.Size(160, 32);
            this.btn_checklog.TabIndex = 0;
            this.btn_checklog.Text = "Check Log";
            this.btn_checklog.UseVisualStyleBackColor = true;
            this.btn_checklog.Click += new System.EventHandler(this.btn_checklog_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Check Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 339);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_checklog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_checklog;
        private System.Windows.Forms.Button button1;
    }
}

