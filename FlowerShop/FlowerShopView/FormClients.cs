﻿using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.BusinessLogic;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace FlowerShopView
{
    public partial class FormClients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ClientLogic logic;
        public FormClients(ClientLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClient>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormClient>();
                form.Id = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                    Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new ClientBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewClients.DataSource = list;
                    dataGridViewClients.Columns[0].Visible = false;
                    dataGridViewClients.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

    }
}
