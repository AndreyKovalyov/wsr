﻿namespace App
{
    partial class Fond
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
            this.SuspendLayout();
            // 
            // Fond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 391);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fond";
            this.Text = "Фонл";
            this.Load += new System.EventHandler(this.Fond_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Fond_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Fond_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Fond_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Fond_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}