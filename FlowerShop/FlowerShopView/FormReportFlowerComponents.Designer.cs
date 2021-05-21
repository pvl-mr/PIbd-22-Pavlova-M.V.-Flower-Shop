
namespace FlowerShopView
{
    partial class FormReportFlowerComponents
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
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.dataGridViewFlowerComponent = new System.Windows.Forms.DataGridView();
            this.ColumnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFlower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlowerComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.Location = new System.Drawing.Point(21, 22);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(167, 23);
            this.btnSaveToExcel.TabIndex = 0;
            this.btnSaveToExcel.Text = "Сохранить в Excel";
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            this.btnSaveToExcel.Click += new System.EventHandler(this.btnSaveToExcel_Click);
            // 
            // dataGridView
            // 
            this.dataGridViewFlowerComponent.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewFlowerComponent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlowerComponent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFlower,
            this.ColumnComponent,
            this.ColumnCount});
            this.dataGridViewFlowerComponent.Location = new System.Drawing.Point(21, 65);
            this.dataGridViewFlowerComponent.Name = "dataGridView";
            this.dataGridViewFlowerComponent.RowHeadersWidth = 53;
            this.dataGridViewFlowerComponent.RowTemplate.Height = 24;
            this.dataGridViewFlowerComponent.Size = new System.Drawing.Size(750, 373);
            this.dataGridViewFlowerComponent.TabIndex = 1;
            // 
            // ColumnFlower
            // 
            this.ColumnFlower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFlower.HeaderText = "Изделие";
            this.ColumnFlower.MinimumWidth = 7;
            this.ColumnFlower.Name = "ColumnFlower";
            // 
            // ColumnComponent
            // 
            this.ColumnComponent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComponent.HeaderText = "Компонент";
            this.ColumnComponent.MinimumWidth = 7;
            this.ColumnComponent.Name = "ColumnComponent";
           
            // 
            // ColumnCount
            // 
            this.ColumnCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.MinimumWidth = 7;
            this.ColumnCount.Name = "ColumnCount";
            // 
            // FormReportFlowerComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewFlowerComponent);
            this.Controls.Add(this.btnSaveToExcel);
            this.Name = "FormReportFlowerComponents";
            this.Text = "Компоненты по изделиям";
            this.Load += new System.EventHandler(this.FormReportFlowerComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlowerComponent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.DataGridView dataGridViewFlowerComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFlower;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
    }
}