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
    public partial class FormStorePlace : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }
        private readonly StorePlaceLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> storePlaceComponents;

        public FormStorePlace(StorePlaceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormStorePlace_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StorePlaceViewModel view = logic.Read(new StorePlaceBindingModel { Id = id.Value })?[0];

                    if (view != null)
                    {
                        textBoxStorePlaceName.Text = view.StorePlaceName;
                        textBoxAdministratorName.Text = view.AdministratorName;
                        storePlaceComponents = view.StorePlaceComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                storePlaceComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxStorePlaceName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAdministratorName.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.CreateOrUpdate(new StorePlaceBindingModel
                {
                    Id = id,
                    StorePlaceName = textBoxStorePlaceName.Text,
                    AdministratorName = textBoxAdministratorName.Text,
                    StorePlaceComponents = storePlaceComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                if (storePlaceComponents != null)
                {
                   dataGridViewComponents.Rows.Clear();
                    foreach (KeyValuePair<int, (string, int)> storePlaceComponent in storePlaceComponents)
                    {
                        dataGridViewComponents.Rows.Add(new object[] { storePlaceComponent.Value.Item1,
                        storePlaceComponent.Value.Item2 });
                    }
                }
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
