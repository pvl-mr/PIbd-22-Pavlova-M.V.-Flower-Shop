
namespace FlowerShopView
{
    partial class FormImplementer
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
            this.labelFIO = new System.Windows.Forms.Label();
            this.labelWorkingTime = new System.Windows.Forms.Label();
            this.labelPauseTime = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.textBoxWorkingTime = new System.Windows.Forms.TextBox();
            this.textBoxPauseTime = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(60, 57);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(133, 16);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО исполнителя: ";
            // 
            // labelWorkingTime
            // 
            this.labelWorkingTime.AutoSize = true;
            this.labelWorkingTime.Location = new System.Drawing.Point(60, 104);
            this.labelWorkingTime.Name = "labelWorkingTime";
            this.labelWorkingTime.Size = new System.Drawing.Size(113, 16);
            this.labelWorkingTime.TabIndex = 1;
            this.labelWorkingTime.Text = "Время на заказ:";
            // 
            // labelPauseTime
            // 
            this.labelPauseTime.AutoSize = true;
            this.labelPauseTime.Location = new System.Drawing.Point(60, 150);
            this.labelPauseTime.Name = "labelPauseTime";
            this.labelPauseTime.Size = new System.Drawing.Size(134, 16);
            this.labelPauseTime.TabIndex = 2;
            this.labelPauseTime.Text = "Время на перерыв: ";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(218, 57);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(414, 22);
            this.textBoxFIO.TabIndex = 3;
            // 
            // textBoxWorkingTime
            // 
            this.textBoxWorkingTime.Location = new System.Drawing.Point(218, 104);
            this.textBoxWorkingTime.Name = "textBoxWorkingTime";
            this.textBoxWorkingTime.Size = new System.Drawing.Size(414, 22);
            this.textBoxWorkingTime.TabIndex = 4;
            // 
            // textBoxPauseTime
            // 
            this.textBoxPauseTime.Location = new System.Drawing.Point(218, 147);
            this.textBoxPauseTime.Name = "textBoxPauseTime";
            this.textBoxPauseTime.Size = new System.Drawing.Size(414, 22);
            this.textBoxPauseTime.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(380, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 47);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(520, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 47);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 303);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxPauseTime);
            this.Controls.Add(this.textBoxWorkingTime);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelPauseTime);
            this.Controls.Add(this.labelWorkingTime);
            this.Controls.Add(this.labelFIO);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label labelWorkingTime;
        private System.Windows.Forms.Label labelPauseTime;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.TextBox textBoxWorkingTime;
        private System.Windows.Forms.TextBox textBoxPauseTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}