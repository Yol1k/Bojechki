using Bojechki.Services;
using System;
using System.Windows.Forms;

namespace Bojechki.Forms.ClientForm
{
    public partial class AddComponent : Form
    {
        public string name = "";
        public string type = "";
        public string retail_price = "";
        public string stock_quantity = "";
        public string purchase_price = "";
        public event Action ComponentAdded;
        public AddComponent()
        {
            InitializeComponent();
        }

        private void AddComponent_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = tb_name.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = cb_type.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            retail_price = tb_retail_price.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            stock_quantity = tb_stock_quantity.Text;
        }

        private void btn_add_component_Click(object sender, EventArgs e)
        {
            string request = $"ADD_COMPONENT|{name}|{type}|{purchase_price}|{retail_price}|{stock_quantity}";
            string response = ServerConnection.SendRequestToServer(request);
            if (response == "SUCCESS")
            {
                ComponentAdded?.Invoke();
                MessageBox.Show("Новый товар успешно добавлен");
            }
            else
            {
                MessageBox.Show(text: "Ошибка:" + response);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            purchase_price = tb_purchase_price.Text;
        }
    }
}
