using System;
using System.Windows.Forms;
using Bojechki.Services;

namespace Bojechki
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        public string email = "";
        public string password = "";
        Form1 form1 = new Form1();

        private void register_btn_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите почту и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string request = $"LOGIN|{email}|{password}";
            string response = ServerConnection.SendRequestToServer(request);

            if (response == "SUCCESS")
            {
                form1.Show();
                this.Hide();
            }
            else if (response.StartsWith("FAIL|"))
            {
                string errorMsg = response.Substring(5);
                MessageBox.Show(errorMsg, "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Неизвестный ответ сервера: {response}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            email = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }
    }
}
