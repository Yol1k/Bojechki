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
using Bojechki.Services;
using Bojechki.Models;
using Component = Bojechki.Models.Component;
using Bojechki.Forms.ClientForm;

namespace Bojechki
{
    public partial class Form1 : Form
    {
        private string connectionString = $@"Data Source=(localdb)\v13.0;Initial Catalog=bog;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
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

        private void btnLoadClients_Click(object sender, EventArgs e)
        {
            string jsonResponse = ServerConnection.SendRequestToServer("GET_CLIENTS");

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
            string jsonResponse = ServerConnection.SendRequestToServer("GET_COMPONENTS");

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

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            AddComponent addComponent = new AddComponent();
            addComponent.ComponentAdded += () => RefreshComponentsGrid();
            addComponent.Show();
        }

        private void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string response = ServerConnection.SendRequestToServer($"DELETE_COMPONENT|{id}");
                if (response == "SUCCESS") RefreshComponentsGrid();
                else MessageBox.Show(response);
            }
        }

        private void btnUpdateComponent_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выбери товар для редактирования"); 
                return;
            }

            Component component = (Component)dataGridView1.SelectedRows[0].DataBoundItem;
            if (component == null) return;

            using (var editForm = new EditComponent(component))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshComponentsGrid();
                }
            }
        }

        private void RefreshComponentsGrid()
        {
            string json = ServerConnection.SendRequestToServer("GET_COMPONENTS");
            var components = JsonConvert.DeserializeObject<List<Component>>(json);
            dataGridView1.DataSource = components;
        }
    }
}