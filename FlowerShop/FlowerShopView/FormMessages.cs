using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.BusinessLogic;
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
    public partial class FormMessages : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MailLogic logic;
        private bool hasNext = false;

        private readonly int mailsOnPage = 4;

        private int currentPage = 0;

        public FormMessages(MailLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            if (mailsOnPage < 1) { mailsOnPage = 5; }
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = logic.Read(new MessageInfoBindingModel { ToSkip = currentPage * mailsOnPage, ToTake = mailsOnPage + 1 });
            hasNext = !(list.Count() <= mailsOnPage);
            if (hasNext)
            {
                buttonNext.Text = "Next " + (currentPage + 2);
                buttonNext.Enabled = true;
            }
            else
            {
                buttonNext.Text = "Next";
                buttonNext.Enabled = false;
            }
            if (list != null)
            {
                dataGridViewMessages.DataSource = list.Take(mailsOnPage).ToList();
                dataGridViewMessages.Columns[0].Visible = false;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (hasNext)
            {
                currentPage++;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonPrev.Enabled = true;
                buttonPrev.Text = "Prev " + (currentPage);
                LoadData();
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if ((currentPage - 1) >= 0)
            {
                currentPage--;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonNext.Enabled = true;
                buttonNext.Text = "Next " + (currentPage + 2);
                if (currentPage == 0)
                {
                    buttonPrev.Enabled = false;
                    buttonPrev.Text = "Prev";
                }
                else
                {
                    buttonPrev.Text = "Prev " + (currentPage);
                }
                LoadData();
            }
        }
    }
}
