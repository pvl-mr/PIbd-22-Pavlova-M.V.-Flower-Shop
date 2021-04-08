
namespace FlowerShopView
{
    partial class FormReportTotalOrders
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
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnSaveToPdf = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(425, 26);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(163, 47);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "Сформировать";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            // 
            // btnSaveToPdf
            // 
            this.btnSaveToPdf.Location = new System.Drawing.Point(625, 26);
            this.btnSaveToPdf.Name = "btnSaveToPdf";
            this.btnSaveToPdf.Size = new System.Drawing.Size(148, 47);
            this.btnSaveToPdf.TabIndex = 1;
            this.btnSaveToPdf.Text = "button1";
            this.btnSaveToPdf.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FlowerShopView.ReportTotalOrders.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(42, 113);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(710, 308);
            this.reportViewer1.TabIndex = 2;
            // 
            // FormReportTotalOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnSaveToPdf);
            this.Controls.Add(this.btnCreateOrder);
            this.Name = "FormReportTotalOrders";
            this.Text = "FormReportTotalOrders";
            this.Load += new System.EventHandler(this.FormReportTotalOrders_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnSaveToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}