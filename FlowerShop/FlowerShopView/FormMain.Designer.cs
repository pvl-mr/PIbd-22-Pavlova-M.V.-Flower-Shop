namespace FlowerShopView
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStripObjects = new System.Windows.Forms.MenuStrip();
            this.cправочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКомпонентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоИзделиямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripObjects = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnTakeOrderInWork = new System.Windows.Forms.Button();
            this.btnOrderReady = new System.Windows.Forms.Button();
            this.btnPayOrder = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.menuStripObjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripObjects
            // 
            this.menuStripObjects.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripObjects.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripObjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cправочникиToolStripMenuItem,
            this.отчётыToolStripMenuItem});
            this.menuStripObjects.Location = new System.Drawing.Point(0, 0);
            this.menuStripObjects.Name = "menuStripObjects";
            this.menuStripObjects.Size = new System.Drawing.Size(1424, 29);
            this.menuStripObjects.TabIndex = 0;
            this.menuStripObjects.Text = "menuStripObjects";
            // 
            // cправочникиToolStripMenuItem
            // 
            this.cправочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem});
            this.cправочникиToolStripMenuItem.Name = "cправочникиToolStripMenuItem";
            this.cправочникиToolStripMenuItem.Size = new System.Drawing.Size(121, 25);
            this.cправочникиToolStripMenuItem.Text = "Cправочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click_1);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click_1);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКомпонентовToolStripMenuItem,
            this.компонентыПоИзделиямToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(78, 25);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // списокКомпонентовToolStripMenuItem
            // 
            this.списокКомпонентовToolStripMenuItem.Name = "списокКомпонентовToolStripMenuItem";
            this.списокКомпонентовToolStripMenuItem.Size = new System.Drawing.Size(283, 30);
            this.списокКомпонентовToolStripMenuItem.Text = "Список изделий";
            this.списокКомпонентовToolStripMenuItem.Click += new System.EventHandler(this.списокКомпонентовToolStripMenuItem_Click);
            // 
            // компонентыПоИзделиямToolStripMenuItem
            // 
            this.компонентыПоИзделиямToolStripMenuItem.Name = "компонентыПоИзделиямToolStripMenuItem";
            this.компонентыПоИзделиямToolStripMenuItem.Size = new System.Drawing.Size(283, 30);
            this.компонентыПоИзделиямToolStripMenuItem.Text = "Компоненты по изделиям";
            this.компонентыПоИзделиямToolStripMenuItem.Click += new System.EventHandler(this.компонентыПоИзделиямToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(283, 30);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // contextMenuStripObjects
            // 
            this.contextMenuStripObjects.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripObjects.Name = "contextMenuStripObjects";
            this.contextMenuStripObjects.Size = new System.Drawing.Size(61, 4);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(1117, 59);
            this.btnCreateOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(225, 46);
            this.btnCreateOrder.TabIndex = 2;
            this.btnCreateOrder.Text = "Создать заказ";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnTakeOrderInWork
            // 
            this.btnTakeOrderInWork.Location = new System.Drawing.Point(1117, 137);
            this.btnTakeOrderInWork.Margin = new System.Windows.Forms.Padding(4);
            this.btnTakeOrderInWork.Name = "btnTakeOrderInWork";
            this.btnTakeOrderInWork.Size = new System.Drawing.Size(224, 50);
            this.btnTakeOrderInWork.TabIndex = 3;
            this.btnTakeOrderInWork.Text = "Отдать на выполнение";
            this.btnTakeOrderInWork.UseVisualStyleBackColor = true;
            this.btnTakeOrderInWork.Click += new System.EventHandler(this.btnTakeOrderInWork_Click);
            // 
            // btnOrderReady
            // 
            this.btnOrderReady.Location = new System.Drawing.Point(1117, 223);
            this.btnOrderReady.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrderReady.Name = "btnOrderReady";
            this.btnOrderReady.Size = new System.Drawing.Size(223, 53);
            this.btnOrderReady.TabIndex = 4;
            this.btnOrderReady.Text = "Заказ готов";
            this.btnOrderReady.UseVisualStyleBackColor = true;
            this.btnOrderReady.Click += new System.EventHandler(this.btnOrderReady_Click);
            // 
            // btnPayOrder
            // 
            this.btnPayOrder.Location = new System.Drawing.Point(1117, 306);
            this.btnPayOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnPayOrder.Name = "btnPayOrder";
            this.btnPayOrder.Size = new System.Drawing.Size(221, 50);
            this.btnPayOrder.TabIndex = 5;
            this.btnPayOrder.Text = "Заказ оплачен";
            this.btnPayOrder.UseVisualStyleBackColor = true;
            this.btnPayOrder.Click += new System.EventHandler(this.btnPayOrder_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1117, 393);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(220, 48);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Обновить список";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(16, 59);
            this.dataGridViewOrders.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.Size = new System.Drawing.Size(1071, 393);
            this.dataGridViewOrders.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 481);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnPayOrder);
            this.Controls.Add(this.btnOrderReady);
            this.Controls.Add(this.btnTakeOrderInWork);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.menuStripObjects);
            this.MainMenuStrip = this.menuStripObjects;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Цветочная лавка";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripObjects.ResumeLayout(false);
            this.menuStripObjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripObjects;
        private System.Windows.Forms.ToolStripMenuItem cправочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripObjects;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnTakeOrderInWork;
        private System.Windows.Forms.Button btnOrderReady;
        private System.Windows.Forms.Button btnPayOrder;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКомпонентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоИзделиямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
    }
}