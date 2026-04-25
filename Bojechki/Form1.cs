using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Bojechki
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private Process serverProcess;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //string serverExePath = "Bojechki_server.exe";

                //serverProcess = Process.Start(serverExePath);
                //System.Threading.Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось запустить сервер: " + ex.Message);
            }
        }

        private void LoadData(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadClients_Click(object sender, EventArgs e)
        {
            string jsonResponse = SendRequestToServer("GET_CLIENTS");

            if (jsonResponse != "UNKNOWN_COMMAND" && !jsonResponse.StartsWith("Ошибка"))
            {
                var clientsList = JsonConvert.DeserializeObject<List<Client>>(jsonResponse);

                dataGridView1.DataSource = clientsList;
            }
            else
            {
                MessageBox.Show(jsonResponse);
            }
        }

        private void btnLoadComponents_Click(object sender, EventArgs e)
        {
            string jsonResponse = SendRequestToServer("GET_COMPONENTS");

            if (jsonResponse != "UNKNOWN_COMMAND" && !jsonResponse.StartsWith("Ошибка"))
            {
                var componentsList = JsonConvert.DeserializeObject<List<Component>>(jsonResponse);

                dataGridView1.DataSource = componentsList;
            }
            else
            {
                MessageBox.Show(jsonResponse);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "божечки.mdf");
            string connectionString = $@"Data Source=(LocalDB)\v13.0;AttachDbFilename=""{dbFilePath}"";Initial Catalog=BojechkiDB;Integrated Security=True;";
            string searchText = txtSearch.Text.Trim();
            string query = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (string.IsNullOrEmpty(searchText))
                    {
                        query = "SELECT * FROM Components";
                    }
                    query = "SELECT name AS 'Название', type AS 'Тип', retail_price AS 'Цена (руб)' FROM Components WHERE name LIKE @search";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@search", "%" + searchText + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dataGridView1.DataSource = table;

                            if (table.Rows.Count == 0)
                            {
                                MessageBox.Show("Ничего не найдено.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска: " + ex.Message);
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

                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;

                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                        }

                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка сети: {ex.Message}";
            }
        }

    }
}