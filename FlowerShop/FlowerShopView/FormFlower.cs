using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.BusinessLogic;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FlowerShopView
{
    public partial class FormFlower : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly FlowerLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> flowerComponents;

        public FormFlower(FlowerLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void FormFlower_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {  
                    FlowerViewModel view = logic.Read(new FlowerBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.FlowerName;
                        textBoxPrice.Text = view.Price.ToString();
                        flowerComponents = view.FlowerComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                flowerComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (flowerComponents != null)
                {
                    dataGridViewCompFlower.Rows.Clear();
                    foreach (var pc in flowerComponents)
                    {
                        dataGridViewCompFlower.Rows.Add(new object[] { pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFlowerComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (flowerComponents.ContainsKey(form.Id))
                {
                    flowerComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    flowerComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompFlower.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormFlowerComponent>();
                int id = Convert.ToInt32(dataGridViewCompFlower.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = flowerComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    flowerComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompFlower.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        flowerComponents.Remove(Convert.ToInt32(dataGridViewCompFlower.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (flowerComponents == null || flowerComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new FlowerBindingModel
                {
                    Id = id,
                   
                    FlowerName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    FlowerComponents = flowerComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
