using Bojechki.Forms.ClientForm;
using Bojechki.Models;
using Bojechki.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Component = Bojechki.Models.Component;

namespace Bojechki
{
    public partial class Form1 : Form
    {
        private Process serverProcess;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_tables.SelectedIndex = 0;
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

        private void btnLoadCatalogs_Click(object sender, EventArgs e)
        {
            LoadCatalogs();
        }

        private void btnLoadComponents_Click(object sender, EventArgs e)
        {
            LoadComponents();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cb_tables.Text.ToLower() == "каталоги")
            {
                string request = $"SEARCH_CATALOGS|{txtSearch.Text}|{comboBox1.Text}|{checkedListBox1.SelectedIndex.ToString()}";
                string json = ServerConnection.SendRequestToServer(request);
                var catalogs = JsonConvert.DeserializeObject<List<Catalog>>(json);
                dataGridView1.DataSource = catalogs;
            }
            else
            {
                string request = $"SEARCH_COMPONENTS|{txtSearch.Text}|{comboBox1.Text}|{checkedListBox1.SelectedIndex.ToString()}";
                string json = ServerConnection.SendRequestToServer(request);
                var components = JsonConvert.DeserializeObject<List<Component>>(json);
                dataGridView1.DataSource = components;
            }
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            AddComponent addComponent = new AddComponent();
            addComponent.ComponentAdded += () => LoadComponents();
            addComponent.Show();
        }

        private void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string response = ServerConnection.SendRequestToServer($"DELETE_COMPONENT|{id}");
                if (response == "SUCCESS") LoadComponents();
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
                    LoadComponents();
                }
            }
        }

        private void btnAddCatalog_Click(object sender, EventArgs e)
        {
            AddCatalog addCatalog = new AddCatalog();
            addCatalog.CatalogAdded +=() => LoadCatalogs();
            addCatalog.Show();
        }

        private void btnDeleteCatalog_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string response = ServerConnection.SendRequestToServer($"DELETE_CATALOG|{id}");
                if (response == "SUCCESS") LoadCatalogs();
                else MessageBox.Show(response);
            }
        }

        private void btnUpdateCatalog_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выбери товар для редактирования");
                return;
            }

            Catalog catalog = (Catalog)dataGridView1.SelectedRows[0].DataBoundItem;
            if (catalog == null) return;

            using (var editForm = new EditCatalog(catalog))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCatalogs();
                }
            }
        }

        private void LoadComponents()
        {
            string json = ServerConnection.SendRequestToServer("GET_COMPONENTS");
            var components = JsonConvert.DeserializeObject<List<Component>>(json);
            dataGridView1.DataSource = components;
            cb_tables.SelectedIndex = 0;
            UpdateColumns();
        }

        private void LoadCatalogs()
        {
            string json = ServerConnection.SendRequestToServer("GET_CATALOGS");
            var catalogs = JsonConvert.DeserializeObject<List<Catalog>>(json);
            dataGridView1.DataSource = catalogs;
            cb_tables.SelectedIndex = 1;
            UpdateColumns();
        }

        private void UpdateColumns()
        {
            comboBox1.Items.Clear();
            if (dataGridView1.DataSource != null)
            {
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    comboBox1.Items.Add(column.HeaderText);
                }
                comboBox1.SelectedIndex = 0;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 1)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, false);
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
            }
        }

        private void cb_tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = null;

            if (cb_tables.SelectedIndex == 0)
            {
                comboBox1.Items.Add("Id");
                comboBox1.Items.Add("Name");
                comboBox1.Items.Add("Type");
                comboBox1.Items.Add("Purchase_Price");
                comboBox1.Items.Add("Retail_Price");
                comboBox1.Items.Add("Stock_Quantity");
                comboBox1.Text = "Id";
            }
            else
            {
                comboBox1.Text = "Id";
                comboBox1.Items.Add("Id");
                comboBox1.Items.Add("Name");
                comboBox1.Items.Add("Type");
                comboBox1.Items.Add("Description");
                comboBox1.Items.Add("Price");
            }
        }
    }
}