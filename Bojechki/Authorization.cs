using Newtonsoft.Json;
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
            string response = SendRequestToServer(request);

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
    }
}
