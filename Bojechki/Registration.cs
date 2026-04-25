using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите почту и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 4)
            {
                MessageBox.Show("Пароль должен быть не менее 4 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string request = $"REGISTER|{full_name}|{address}|{phone}|{email}|{password}";
            string response = SendRequestToServer(request);

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
                MessageBox.Show($"Неизвестный ответ сервера: {response}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string SendRequestToServer(string message)
        {
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 13000))
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] requestData = Encoding.UTF8.GetBytes(message);
                    stream.Write(requestData, 0, requestData.Length);
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка сети: {ex.Message}";
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
            phone = comboBox1.Text + textBox5.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
