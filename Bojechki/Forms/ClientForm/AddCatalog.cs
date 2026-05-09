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

namespace Bojechki.Forms.ClientForm
{
    public partial class AddCatalog : Form
    {
        public string name = "";
        public string type = "";
        public string description = "";
        public string price = "";
        public event Action CatalogAdded;
        public AddCatalog()
        {
            InitializeComponent();
        }

        private void AddCatalog_Load(object sender, EventArgs e)
        {

        }

        private void name_catalog_TextChanged(object sender, EventArgs e)
        {
            name = (string)name_catalog.Text;
        }

        private void type_catalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = (string)type_catalog.Text;
        }

        private void desc_catalog_TextChanged(object sender, EventArgs e)
        {
            description = (string)desc_catalog.Text;
        }

        private void price_catalog_TextChanged(object sender, EventArgs e)
        {
            price = (string)price_catalog.Text;
        }

        private void btn_add_catalog_Click(object sender, EventArgs e)
        {
            string request = $"ADD_CATALOG|{name}|{type}|{description}|{price}";
            string response = ServerConnection.SendRequestToServer(request);
            if (response == "SUCCESS")
            {
                CatalogAdded?.Invoke();
                MessageBox.Show("Новый каталог успешно добавлен");
            }
            else
            {
                MessageBox.Show(text: "Ошибка:" + response);
            }
        }
    }
}
