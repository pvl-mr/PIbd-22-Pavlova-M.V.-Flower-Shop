using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShopView
{
    public partial class FormReportTotalOrders : Form
    {
        public FormReportTotalOrders()
        {
            InitializeComponent();
        }

        private void FormReportTotalOrders_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
