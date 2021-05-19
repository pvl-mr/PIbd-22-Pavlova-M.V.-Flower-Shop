using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.BusinessLogic;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FlowerShopView
{
    public partial class FormReportFlowerComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;

        public FormReportFlowerComponents(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormReportFlowerComponents_Load(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetFlowerComponent");

                List<ReportFlowerComponentViewModel> dict = (List<ReportFlowerComponentViewModel>)method.Invoke(logic, null);
                if (dict != null)
                {
                    dataGridViewFlowerComponent.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridViewFlowerComponent.Rows.Add(new object[] { elem.FlowerName, "", "" });
                        foreach (var listElem in elem.Components)
                        {
                            dataGridViewFlowerComponent.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridViewFlowerComponent.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridViewFlowerComponent.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveFlowerComponentToExcelFile");

                        method.Invoke(logic, new object[]
                        {
                            new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        }
                        });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
