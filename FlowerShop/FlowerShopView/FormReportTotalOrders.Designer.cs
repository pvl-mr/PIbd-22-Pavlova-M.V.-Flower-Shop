
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
            this.reportTotalOrders = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(698, 482);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(163, 47);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "Сформировать";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateReportOrders_Click);
            // 
            // btnSaveToPdf
            // 
            this.btnSaveToPdf.Location = new System.Drawing.Point(884, 482);
            this.btnSaveToPdf.Name = "btnSaveToPdf";
            this.btnSaveToPdf.Size = new System.Drawing.Size(148, 47);
            this.btnSaveToPdf.TabIndex = 1;
            this.btnSaveToPdf.Text = "Сохранить в pdf";
            this.btnSaveToPdf.UseVisualStyleBackColor = true;
            this.btnSaveToPdf.Click += new System.EventHandler(this.btnSaveToPdf_Click);
            // 
            // reportTotalOrders
            // 
            this.reportTotalOrders.LocalReport.ReportEmbeddedResource = "FlowerShopView.ReportTotalOrders.rdlc";
            this.reportTotalOrders.Location = new System.Drawing.Point(23, 33);
            this.reportTotalOrders.Name = "reportTotalOrders";
            this.reportTotalOrders.ServerReport.BearerToken = null;
            this.reportTotalOrders.Size = new System.Drawing.Size(1009, 426);
            this.reportTotalOrders.TabIndex = 2;
            // 
            // FormReportTotalOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 554);
            this.Controls.Add(this.reportTotalOrders);
            this.Controls.Add(this.btnSaveToPdf);
            this.Controls.Add(this.btnCreateOrder);
            this.Name = "FormReportTotalOrders";
            this.Text = "Заказы за весь период";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnSaveToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportTotalOrders;
    }
}