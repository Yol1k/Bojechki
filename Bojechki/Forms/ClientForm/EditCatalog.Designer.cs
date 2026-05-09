namespace Bojechki.Forms.ClientForm
{
    partial class EditCatalog
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
            this.price_catalog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.desc_catalog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_add_catalog = new System.Windows.Forms.Button();
            this.type_catalog = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.name_catalog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // price_catalog
            // 
            this.price_catalog.Location = new System.Drawing.Point(208, 416);
            this.price_catalog.Name = "price_catalog";
            this.price_catalog.Size = new System.Drawing.Size(284, 20);
            this.price_catalog.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Введите цену каталога";
            // 
            // desc_catalog
            // 
            this.desc_catalog.Location = new System.Drawing.Point(208, 228);
            this.desc_catalog.Multiline = true;
            this.desc_catalog.Name = "desc_catalog";
            this.desc_catalog.Size = new System.Drawing.Size(517, 130);
            this.desc_catalog.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Введите описание каталога";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Введите тип каталога";
            // 
            // btn_add_catalog
            // 
            this.btn_add_catalog.Location = new System.Drawing.Point(208, 482);
            this.btn_add_catalog.Name = "btn_add_catalog";
            this.btn_add_catalog.Size = new System.Drawing.Size(284, 23);
            this.btn_add_catalog.TabIndex = 12;
            this.btn_add_catalog.Text = "Обновить";
            this.btn_add_catalog.UseVisualStyleBackColor = true;
            this.btn_add_catalog.Click += new System.EventHandler(this.btn_add_catalog_Click);
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
            this.type_catalog.Location = new System.Drawing.Point(208, 158);
            this.type_catalog.Name = "type_catalog";
            this.type_catalog.Size = new System.Drawing.Size(284, 21);
            this.type_catalog.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Введите название каталога";
            // 
            // name_catalog
            // 
            this.name_catalog.Location = new System.Drawing.Point(208, 90);
            this.name_catalog.Name = "name_catalog";
            this.name_catalog.Size = new System.Drawing.Size(284, 20);
            this.name_catalog.TabIndex = 9;
            // 
            // EditCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.price_catalog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.desc_catalog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_add_catalog);
            this.Controls.Add(this.type_catalog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name_catalog);
            this.Name = "EditCatalog";
            this.Text = "EditCatalog";
            this.Load += new System.EventHandler(this.EditCatalog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox price_catalog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox desc_catalog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_add_catalog;
        private System.Windows.Forms.ComboBox type_catalog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name_catalog;
    }
}