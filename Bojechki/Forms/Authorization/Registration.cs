using Bojechki.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Bojechki
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        public string email = "";
        public string password = "";
        public string full_name = "";
        public string address = "";
        public string phone = "";

        Form1 form1 = new Form1();
        private void Registration_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("+7 Россия");
            comboBox1.Items.Add("+375 Беларусь");
            comboBox1.Items.Add("+998 Узбекистан");
            comboBox1.Items.Add("+91 Индия");
            comboBox1.Items.Add("+92 Пакистан");
            comboBox1.Items.Add("+992 Таджикистан");
            comboBox1.Items.Add("+850 КНДР");
            comboBox1.Items.Add("+1 США");
            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            email = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (new[] { full_name, email, password, phone, address }.Any(string.IsNullOrWhiteSpace))
                {
                    MessageBox.Show("Введите все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password.Length < 4)
                {
                    MessageBox.Show("Пароль должен быть не менее 4 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string request = $"REGISTER|{full_name}|{address}|{phone}|{email}|{password}";
                string response = ServerConnection.SendRequestToServer(request);

                if (response == "SUCCESS")
                {
                    MessageBox.Show("Регистрация успешна! Теперь вы можете войти.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Authorization authorization = new Authorization();
                    authorization.ShowDialog();
                }
                else if (response.StartsWith("FAIL|"))
                {
                    string errorMsg = response.Substring(5);
                    MessageBox.Show(errorMsg, "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Неизвестный ответ сервера: {response}", "ОшиБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            full_name = textBox3.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            address = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();
            string code = selected.Split(' ')[0];
            phone = code + textBox5.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
