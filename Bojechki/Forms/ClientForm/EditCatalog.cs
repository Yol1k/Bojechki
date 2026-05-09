using Bojechki.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bojechki.Forms.ClientForm
{
    public partial class EditCatalog : Form
    {
        private Catalog catalog;
        public EditCatalog(Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
        }

        private void EditCatalog_Load(object sender, EventArgs e)
        {
            name_catalog.Text = catalog.Name;
            type_catalog.SelectedItem = catalog.Type;
            desc_catalog.Text = catalog.Description;
            price_catalog.Text = catalog.Price.ToString();
        }

        private void btn_add_catalog_Click(object sender, EventArgs e)
        {
            string request = $"UPDATE_CATALOG|{catalog.Id}|{name_catalog.Text}|{type_catalog.SelectedItem}|{desc_catalog.Text}|{price_catalog.Text}";
            string response = ServerConnection.SendRequestToServer(request);

            if (response == "SUCCESS")
            {
                MessageBox.Show("Каталог обновлён");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка: " + response);
            }
        }
    }
}
