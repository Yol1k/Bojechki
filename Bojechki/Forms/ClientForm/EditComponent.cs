using Bojechki.Services;
using System;
using System.Windows.Forms;
using Component = Bojechki.Models.Component;

namespace Bojechki.Forms.ClientForm
{
    public partial class EditComponent: Form
    {
        private Component _component;
        public EditComponent(Component component)
        {
            InitializeComponent();
            _component = component;
        }

        private void EditComponent_Load(object sender, EventArgs e)
        {
            textBox1.Text = _component.Name;
            textBox2.Text = _component.Purchase_Price.ToString();
            textBox3.Text = _component.Retail_Price.ToString();
            textBox4.Text = _component.Stock_Quantity.ToString();
            comboBox1.SelectedItem = _component.Type;
        }

        private void btn_edit_component_Click(object sender, EventArgs e)
        {
            string request = $"UPDATE_COMPONENT|{_component.Id}|{textBox1.Text}|{comboBox1.SelectedItem}|{textBox2.Text}|{textBox3.Text}|{textBox4.Text}";
            string response = ServerConnection.SendRequestToServer(request);

            if (response == "SUCCESS")
            {
                MessageBox.Show("Компонент обновлён");
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
