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
    public partial class FormReportStorePlaceComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;
        public FormReportStorePlaceComponents(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveStorePlaceComponentsToExcelFile");

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

        private void FormReportStorePlaceComponents_Load(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetStorePlaceComponents");
                List<ReportStorePlaceComponentViewModel> storePlaceComponents = (List<ReportStorePlaceComponentViewModel>)method.Invoke(logic, null);
                if (storePlaceComponents != null)
                {
                    dataGridViewStorePlaceComponents.Rows.Clear();

                    foreach (var storePlace in storePlaceComponents)
                    {
                        dataGridViewStorePlaceComponents.Rows.Add(new object[] { storePlace.StorePlaceName, "", "" });

                        foreach (var component in storePlace.Components)
                        {
                            dataGridViewStorePlaceComponents.Rows.Add(new object[] { "", component.Item1, component.Item2 });
                        }

                        dataGridViewStorePlaceComponents.Rows.Add(new object[] { "Итого", "", storePlace.TotalCount });
                        dataGridViewStorePlaceComponents.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
