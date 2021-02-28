
namespace FlowerShopView
{
    partial class FormStorePlaceRefill
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
            this.labelStorePlace = new System.Windows.Forms.Label();
            this.labelComponent = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBoxStorePlaces = new System.Windows.Forms.ComboBox();
            this.comboBoxComponents = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStorePlace
            // 
            this.labelStorePlace.AutoSize = true;
            this.labelStorePlace.Location = new System.Drawing.Point(57, 43);
            this.labelStorePlace.Name = "labelStorePlace";
            this.labelStorePlace.Size = new System.Drawing.Size(54, 16);
            this.labelStorePlace.TabIndex = 0;
            this.labelStorePlace.Text = "Склад: ";
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(57, 111);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(86, 16);
            this.labelComponent.TabIndex = 1;
            this.labelComponent.Text = "Компонент: ";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(57, 186);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(92, 16);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Количество: ";
            // 
            // comboBoxStorePlaces
            // 
            this.comboBoxStorePlaces.FormattingEnabled = true;
            this.comboBoxStorePlaces.Location = new System.Drawing.Point(175, 43);
            this.comboBoxStorePlaces.Name = "comboBoxStorePlaces";
            this.comboBoxStorePlaces.Size = new System.Drawing.Size(279, 24);
            this.comboBoxStorePlaces.TabIndex = 3;
            // 
            // comboBoxComponents
            // 
            this.comboBoxComponents.FormattingEnabled = true;
            this.comboBoxComponents.Location = new System.Drawing.Point(175, 111);
            this.comboBoxComponents.Name = "comboBoxComponents";
            this.comboBoxComponents.Size = new System.Drawing.Size(279, 24);
            this.comboBoxComponents.TabIndex = 4;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(175, 186);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(279, 22);
            this.textBoxCount.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(82, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 70);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(267, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 70);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormStorePlaceRefill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 356);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxComponents);
            this.Controls.Add(this.comboBoxStorePlaces);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelComponent);
            this.Controls.Add(this.labelStorePlace);
            this.Name = "FormStorePlaceRefill";
            this.Text = "Пополнение склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStorePlace;
        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ComboBox comboBoxStorePlaces;
        private System.Windows.Forms.ComboBox comboBoxComponents;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}