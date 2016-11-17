namespace Spane_Laboratory
{
    partial class SaleOrderReport
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
            this.SaleOrderCrptViewr = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnSaleSearch = new System.Windows.Forms.Button();
            this.tbSaleSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaleOrderCrptViewr
            // 
            this.SaleOrderCrptViewr.ActiveViewIndex = -1;
            this.SaleOrderCrptViewr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaleOrderCrptViewr.Cursor = System.Windows.Forms.Cursors.Default;
            this.SaleOrderCrptViewr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaleOrderCrptViewr.Location = new System.Drawing.Point(0, 0);
            this.SaleOrderCrptViewr.Name = "SaleOrderCrptViewr";
            this.SaleOrderCrptViewr.Size = new System.Drawing.Size(881, 444);
            this.SaleOrderCrptViewr.TabIndex = 0;
            // 
            // btnSaleSearch
            // 
            this.btnSaleSearch.Location = new System.Drawing.Point(614, 2);
            this.btnSaleSearch.Name = "btnSaleSearch";
            this.btnSaleSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSaleSearch.TabIndex = 1;
            this.btnSaleSearch.Text = "Search ";
            this.btnSaleSearch.UseVisualStyleBackColor = true;
            this.btnSaleSearch.Click += new System.EventHandler(this.btnSaleSearch_Click);
            // 
            // tbSaleSearch
            // 
            this.tbSaleSearch.Location = new System.Drawing.Point(488, 2);
            this.tbSaleSearch.Name = "tbSaleSearch";
            this.tbSaleSearch.Size = new System.Drawing.Size(120, 20);
            this.tbSaleSearch.TabIndex = 2;
            // 
            // SaleOrderReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 444);
            this.Controls.Add(this.tbSaleSearch);
            this.Controls.Add(this.btnSaleSearch);
            this.Controls.Add(this.SaleOrderCrptViewr);
            this.Name = "SaleOrderReport";
            this.Text = "SaleOrderReport";
            this.Load += new System.EventHandler(this.SaleOrderReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer SaleOrderCrptViewr;
        private System.Windows.Forms.Button btnSaleSearch;
        private System.Windows.Forms.TextBox tbSaleSearch;
    }
}