
namespace FlowerShopView
{
    partial class FormReportStorePlaceComponents
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
            this.dataGridViewStorePlaceComponents = new System.Windows.Forms.DataGridView();
            this.ColumnStorePlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorePlaceComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.Location = new System.Drawing.Point(578, 401);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(167, 23);
            this.btnSaveToExcel.TabIndex = 0;
            this.btnSaveToExcel.Text = "Сохранить в Excel";
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            this.btnSaveToExcel.Click += new System.EventHandler(this.btnSaveToExcel_Click);
            // 
            // dataGridViewStorePlaceComponents
            // 
            this.dataGridViewStorePlaceComponents.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewStorePlaceComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStorePlaceComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStorePlace,
            this.ColumnComponent,
            this.ColumnCount});
            this.dataGridViewStorePlaceComponents.Location = new System.Drawing.Point(12, 44);
            this.dataGridViewStorePlaceComponents.Name = "dataGridViewStorePlaceComponents";
            this.dataGridViewStorePlaceComponents.RowHeadersWidth = 53;
            this.dataGridViewStorePlaceComponents.RowTemplate.Height = 24;
            this.dataGridViewStorePlaceComponents.Size = new System.Drawing.Size(733, 325);
            this.dataGridViewStorePlaceComponents.TabIndex = 1;
            // 
            // ColumnStorePlace
            // 
            this.ColumnStorePlace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnStorePlace.HeaderText = "Склад";
            this.ColumnStorePlace.MinimumWidth = 7;
            this.ColumnStorePlace.Name = "ColumnStorePlace";
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
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.MinimumWidth = 7;
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.Width = 130;
            // 
            // FormReportStorePlaceComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewStorePlaceComponents);
            this.Controls.Add(this.btnSaveToExcel);
            this.Name = "FormReportStorePlaceComponents";
            this.Text = "Компоненты на складах";
            this.Load += new System.EventHandler(this.FormReportStorePlaceComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorePlaceComponents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.DataGridView dataGridViewStorePlaceComponents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStorePlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
    }
}