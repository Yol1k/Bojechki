namespace Bojechki.Forms.ClientForm
{
    partial class AddCatalog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.name_catalog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.type_catalog = new System.Windows.Forms.ComboBox();
            this.btn_add_catalog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.desc_catalog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.price_catalog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // name_catalog
            // 
            this.name_catalog.Location = new System.Drawing.Point(224, 80);
            this.name_catalog.Name = "name_catalog";
            this.name_catalog.Size = new System.Drawing.Size(284, 20);
            this.name_catalog.TabIndex = 0;
            this.name_catalog.TextChanged += new System.EventHandler(this.name_catalog_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите название каталога";
            // 
            // type_catalog
            // 
            this.type_catalog.FormattingEnabled = true;
            this.type_catalog.Items.AddRange(new object[] {
            "Сборка под заказ",
            "Готовый ПК",
            "Защита",
            "Апгрейд",
            "Профилактика"});
            this.type_catalog.Location = new System.Drawing.Point(224, 148);
            this.type_catalog.Name = "type_catalog";
            this.type_catalog.Size = new System.Drawing.Size(284, 21);
            this.type_catalog.TabIndex = 2;
            this.type_catalog.SelectedIndexChanged += new System.EventHandler(this.type_catalog_SelectedIndexChanged);
            // 
            // btn_add_catalog
            // 
            this.btn_add_catalog.Location = new System.Drawing.Point(224, 472);
            this.btn_add_catalog.Name = "btn_add_catalog";
            this.btn_add_catalog.Size = new System.Drawing.Size(284, 23);
            this.btn_add_catalog.TabIndex = 3;
            this.btn_add_catalog.Text = "Добавить";
            this.btn_add_catalog.UseVisualStyleBackColor = true;
            this.btn_add_catalog.Click += new System.EventHandler(this.btn_add_catalog_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Введите тип каталога";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Введите описание каталога";
            // 
            // desc_catalog
            // 
            this.desc_catalog.Location = new System.Drawing.Point(224, 218);
            this.desc_catalog.Multiline = true;
            this.desc_catalog.Name = "desc_catalog";
            this.desc_catalog.Size = new System.Drawing.Size(517, 130);
            this.desc_catalog.TabIndex = 6;
            this.desc_catalog.TextChanged += new System.EventHandler(this.desc_catalog_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Введите цену каталога";
            // 
            // price_catalog
            // 
            this.price_catalog.Location = new System.Drawing.Point(224, 406);
            this.price_catalog.Name = "price_catalog";
            this.price_catalog.Size = new System.Drawing.Size(284, 20);
            this.price_catalog.TabIndex = 8;
            this.price_catalog.TextChanged += new System.EventHandler(this.price_catalog_TextChanged);
            // 
            // AddCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.price_catalog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.desc_catalog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_add_catalog);
            this.Controls.Add(this.type_catalog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name_catalog);
            this.Name = "AddCatalog";
            this.Text = "AddCatalog";
            this.Load += new System.EventHandler(this.AddCatalog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name_catalog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox type_catalog;
        private System.Windows.Forms.Button btn_add_catalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox desc_catalog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox price_catalog;
    }
}