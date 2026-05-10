namespace Bojechki
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadCatalogs = new System.Windows.Forms.Button();
            this.btnLoadComponents = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.btnDeleteComponent = new System.Windows.Forms.Button();
            this.btnUpdateComponent = new System.Windows.Forms.Button();
            this.btnAddCatalog = new System.Windows.Forms.Button();
            this.btnDeleteCatalog = new System.Windows.Forms.Button();
            this.btnUpdateCatalog = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_tables = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(346, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(826, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnLoadCatalogs
            // 
            this.btnLoadCatalogs.Location = new System.Drawing.Point(12, 350);
            this.btnLoadCatalogs.Name = "btnLoadCatalogs";
            this.btnLoadCatalogs.Size = new System.Drawing.Size(75, 40);
            this.btnLoadCatalogs.TabIndex = 1;
            this.btnLoadCatalogs.Text = "Загрузить каталоги";
            this.btnLoadCatalogs.UseVisualStyleBackColor = true;
            this.btnLoadCatalogs.Click += new System.EventHandler(this.btnLoadCatalogs_Click);
            // 
            // btnLoadComponents
            // 
            this.btnLoadComponents.Location = new System.Drawing.Point(13, 396);
            this.btnLoadComponents.Name = "btnLoadComponents";
            this.btnLoadComponents.Size = new System.Drawing.Size(75, 41);
            this.btnLoadComponents.TabIndex = 2;
            this.btnLoadComponents.Text = "Загрузить товары";
            this.btnLoadComponents.UseVisualStyleBackColor = true;
            this.btnLoadComponents.Click += new System.EventHandler(this.btnLoadComponents_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(13, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 40);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(328, 20);
            this.txtSearch.TabIndex = 4;
            // 
            // btnAddComponent
            // 
            this.btnAddComponent.Location = new System.Drawing.Point(94, 396);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(75, 41);
            this.btnAddComponent.TabIndex = 5;
            this.btnAddComponent.Text = "Добавить товар";
            this.btnAddComponent.UseVisualStyleBackColor = true;
            this.btnAddComponent.Click += new System.EventHandler(this.btnAddComponent_Click);
            // 
            // btnDeleteComponent
            // 
            this.btnDeleteComponent.Location = new System.Drawing.Point(175, 397);
            this.btnDeleteComponent.Name = "btnDeleteComponent";
            this.btnDeleteComponent.Size = new System.Drawing.Size(75, 41);
            this.btnDeleteComponent.TabIndex = 6;
            this.btnDeleteComponent.Text = "Удалить товар";
            this.btnDeleteComponent.UseVisualStyleBackColor = true;
            this.btnDeleteComponent.Click += new System.EventHandler(this.btnDeleteComponent_Click);
            // 
            // btnUpdateComponent
            // 
            this.btnUpdateComponent.Location = new System.Drawing.Point(256, 396);
            this.btnUpdateComponent.Name = "btnUpdateComponent";
            this.btnUpdateComponent.Size = new System.Drawing.Size(75, 41);
            this.btnUpdateComponent.TabIndex = 7;
            this.btnUpdateComponent.Text = "Обновить товар";
            this.btnUpdateComponent.UseVisualStyleBackColor = true;
            this.btnUpdateComponent.Click += new System.EventHandler(this.btnUpdateComponent_Click);
            // 
            // btnAddCatalog
            // 
            this.btnAddCatalog.Location = new System.Drawing.Point(94, 350);
            this.btnAddCatalog.Name = "btnAddCatalog";
            this.btnAddCatalog.Size = new System.Drawing.Size(75, 40);
            this.btnAddCatalog.TabIndex = 8;
            this.btnAddCatalog.Text = "Добавить каталог";
            this.btnAddCatalog.UseVisualStyleBackColor = true;
            this.btnAddCatalog.Click += new System.EventHandler(this.btnAddCatalog_Click);
            // 
            // btnDeleteCatalog
            // 
            this.btnDeleteCatalog.Location = new System.Drawing.Point(175, 351);
            this.btnDeleteCatalog.Name = "btnDeleteCatalog";
            this.btnDeleteCatalog.Size = new System.Drawing.Size(75, 40);
            this.btnDeleteCatalog.TabIndex = 9;
            this.btnDeleteCatalog.Text = "Удалить каталог";
            this.btnDeleteCatalog.UseVisualStyleBackColor = true;
            this.btnDeleteCatalog.Click += new System.EventHandler(this.btnDeleteCatalog_Click);
            // 
            // btnUpdateCatalog
            // 
            this.btnUpdateCatalog.Location = new System.Drawing.Point(256, 350);
            this.btnUpdateCatalog.Name = "btnUpdateCatalog";
            this.btnUpdateCatalog.Size = new System.Drawing.Size(75, 40);
            this.btnUpdateCatalog.TabIndex = 10;
            this.btnUpdateCatalog.Text = "Обновить каталог";
            this.btnUpdateCatalog.UseVisualStyleBackColor = true;
            this.btnUpdateCatalog.Click += new System.EventHandler(this.btnUpdateCatalog_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(219, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Отсортировать по:";
            // 
            // cb_tables
            // 
            this.cb_tables.FormattingEnabled = true;
            this.cb_tables.Items.AddRange(new object[] {
            "Компоненты",
            "Каталоги"});
            this.cb_tables.Location = new System.Drawing.Point(94, 57);
            this.cb_tables.Name = "cb_tables";
            this.cb_tables.Size = new System.Drawing.Size(121, 21);
            this.cb_tables.TabIndex = 13;
            this.cb_tables.SelectedIndexChanged += new System.EventHandler(this.cb_tables_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Таблица";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "По возрастанию",
            "По убыванию"});
            this.checkedListBox1.Location = new System.Drawing.Point(220, 84);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 34);
            this.checkedListBox1.TabIndex = 15;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 450);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_tables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnUpdateCatalog);
            this.Controls.Add(this.btnDeleteCatalog);
            this.Controls.Add(this.btnAddCatalog);
            this.Controls.Add(this.btnUpdateComponent);
            this.Controls.Add(this.btnDeleteComponent);
            this.Controls.Add(this.btnAddComponent);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnLoadComponents);
            this.Controls.Add(this.btnLoadCatalogs);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLoadCatalogs;
        private System.Windows.Forms.Button btnLoadComponents;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddComponent;
        private System.Windows.Forms.Button btnDeleteComponent;
        private System.Windows.Forms.Button btnUpdateComponent;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddCatalog;
        private System.Windows.Forms.Button btnDeleteCatalog;
        private System.Windows.Forms.Button btnUpdateCatalog;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_tables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

