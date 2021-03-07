
namespace FlowerShopView
{
    partial class FormStorePlace
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
            this.labelStorePlaceName = new System.Windows.Forms.Label();
            this.textBoxStorePlaceName = new System.Windows.Forms.TextBox();
            this.labelAdministratorName = new System.Windows.Forms.Label();
            this.textBoxAdministratorName = new System.Windows.Forms.TextBox();
            this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
            this.ColumnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStorePlaceName
            // 
            this.labelStorePlaceName.AutoSize = true;
            this.labelStorePlaceName.Location = new System.Drawing.Point(30, 51);
            this.labelStorePlaceName.Name = "labelStorePlaceName";
            this.labelStorePlaceName.Size = new System.Drawing.Size(129, 16);
            this.labelStorePlaceName.TabIndex = 0;
            this.labelStorePlaceName.Text = "Название склада: ";
            // 
            // textBoxStorePlaceName
            // 
            this.textBoxStorePlaceName.Location = new System.Drawing.Point(197, 51);
            this.textBoxStorePlaceName.Name = "textBoxStorePlaceName";
            this.textBoxStorePlaceName.Size = new System.Drawing.Size(434, 22);
            this.textBoxStorePlaceName.TabIndex = 1;
            // 
            // labelAdministratorName
            // 
            this.labelAdministratorName.AutoSize = true;
            this.labelAdministratorName.Location = new System.Drawing.Point(30, 104);
            this.labelAdministratorName.Name = "labelAdministratorName";
            this.labelAdministratorName.Size = new System.Drawing.Size(117, 16);
            this.labelAdministratorName.TabIndex = 2;
            this.labelAdministratorName.Text = "Ответственный: ";
            // 
            // textBoxAdministratorName
            // 
            this.textBoxAdministratorName.Location = new System.Drawing.Point(197, 104);
            this.textBoxAdministratorName.Name = "textBoxAdministratorName";
            this.textBoxAdministratorName.Size = new System.Drawing.Size(434, 22);
            this.textBoxAdministratorName.TabIndex = 3;
            // 
            // dataGridViewComponents
            // 
            this.dataGridViewComponents.AllowUserToAddRows = false;
            this.dataGridViewComponents.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnComponent,
            this.ColumnCount});
            this.dataGridViewComponents.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewComponents.Location = new System.Drawing.Point(33, 146);
            this.dataGridViewComponents.Name = "dataGridViewComponents";
            this.dataGridViewComponents.RowHeadersWidth = 51;
            this.dataGridViewComponents.RowTemplate.Height = 24;
            this.dataGridViewComponents.Size = new System.Drawing.Size(598, 237);
            this.dataGridViewComponents.TabIndex = 4;
            // 
            // ColumnComponent
            // 
            this.ColumnComponent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComponent.HeaderText = "Компонент";
            this.ColumnComponent.MinimumWidth = 6;
            this.ColumnComponent.Name = "ColumnComponent";
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.MinimumWidth = 6;
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.Width = 125;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(33, 411);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(276, 51);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(346, 411);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(285, 51);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormStorePlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 489);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridViewComponents);
            this.Controls.Add(this.textBoxAdministratorName);
            this.Controls.Add(this.labelAdministratorName);
            this.Controls.Add(this.textBoxStorePlaceName);
            this.Controls.Add(this.labelStorePlaceName);
            this.Name = "FormStorePlace";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormStorePlace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStorePlaceName;
        private System.Windows.Forms.TextBox textBoxStorePlaceName;
        private System.Windows.Forms.Label labelAdministratorName;
        private System.Windows.Forms.TextBox textBoxAdministratorName;
        private System.Windows.Forms.DataGridView dataGridViewComponents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}