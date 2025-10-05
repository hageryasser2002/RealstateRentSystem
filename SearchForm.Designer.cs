using System.Drawing;

namespace RealStateRentSystem
{
    partial class SearchForm
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
        //private void InitializeComponent()
        //{
        //    this.textBoxSearch = new System.Windows.Forms.TextBox();
        //    this.SuspendLayout();
        //    // 
        //    // textBoxSearch
        //    // 
        //    this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 8F);
        //    this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
        //    this.textBoxSearch.Name = "textBoxSearch";
        //    this.textBoxSearch.Size = new System.Drawing.Size(200, 25);
        //    this.textBoxSearch.TabIndex = 0;
        //    this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
        //    // 
        //    // SearchForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(200, 25);
        //    this.Controls.Add(this.textBoxSearch);
        //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //    this.Name = "SearchForm";
        //    this.ShowInTaskbar = false;
        //    this.TopMost = true;
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}
        #endregion
        private void InitializeComponent()
        {
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(175, 25);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // SearchForm
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(175, 25);
            this.Controls.Add(this.textBoxSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.CheckBox checkBoxSearch;
    }
}