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
    public partial class FormStorePlaceRefill : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly StorePlaceLogic storePlaceLogic;

        public FormStorePlaceRefill(StorePlaceLogic storePlaceLogic, ComponentLogic componentLogic)
        {
            InitializeComponent();
            this.storePlaceLogic = storePlaceLogic;
            List<ComponentViewModel> componentsViews = componentLogic.Read(null);
            if (componentsViews != null)
            {
                comboBoxComponents.DisplayMember = "ComponentName";
                comboBoxComponents.ValueMember = "Id";
                comboBoxComponents.DataSource = componentsViews;
                comboBoxComponents.SelectedItem = null;
            }

            List<StorePlaceViewModel> storePlaceViews = storePlaceLogic.Read(null);
            if (storePlaceViews != null)
            {
                comboBoxStorePlaces.DisplayMember = "StorePlaceName";
                comboBoxStorePlaces.ValueMember = "Id";
                comboBoxStorePlaces.DataSource = storePlaceViews;
                comboBoxStorePlaces.SelectedItem = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxComponents.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxStorePlaces.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            storePlaceLogic.AddComponent(new StorePlaceComponentBindingModel
            {
                ComponentId = Convert.ToInt32(comboBoxComponents.SelectedValue),
                StorePlaceId = Convert.ToInt32(comboBoxStorePlaces.SelectedValue),
                Count = Convert.ToInt32(textBoxCount.Text)
            });

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
