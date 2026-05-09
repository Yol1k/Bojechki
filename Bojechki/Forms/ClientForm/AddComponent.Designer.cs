namespace Bojechki.Forms.ClientForm
{
    partial class AddComponent
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
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_retail_price = new System.Windows.Forms.TextBox();
            this.tb_stock_quantity = new System.Windows.Forms.TextBox();
            this.btn_add_component = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.tb_purchase_price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(243, 121);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(278, 20);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tb_retail_price
            // 
            this.tb_retail_price.Location = new System.Drawing.Point(246, 244);
            this.tb_retail_price.Name = "tb_retail_price";
            this.tb_retail_price.Size = new System.Drawing.Size(278, 20);
            this.tb_retail_price.TabIndex = 3;
            this.tb_retail_price.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tb_stock_quantity
            // 
            this.tb_stock_quantity.Location = new System.Drawing.Point(246, 283);
            this.tb_stock_quantity.Name = "tb_stock_quantity";
            this.tb_stock_quantity.Size = new System.Drawing.Size(278, 20);
            this.tb_stock_quantity.TabIndex = 4;
            this.tb_stock_quantity.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // btn_add_component
            // 
            this.btn_add_component.Location = new System.Drawing.Point(246, 362);
            this.btn_add_component.Name = "btn_add_component";
            this.btn_add_component.Size = new System.Drawing.Size(275, 23);
            this.btn_add_component.TabIndex = 7;
            this.btn_add_component.Text = "Добавить";
            this.btn_add_component.UseVisualStyleBackColor = true;
            this.btn_add_component.Click += new System.EventHandler(this.btn_add_component_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите название компонента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Выберите тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Введите розничная цену";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Введите количество на складе";
            // 
            // cb_type
            // 
            this.cb_type.Font = new System.Drawing.Font("Cascadia Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Items.AddRange(new object[] {
            "Процессор",
            "Материнская плата",
            "Оперативная память",
            "Видеокарта",
            "Накопитель",
            "Блок питания",
            "Корпус",
            "Система охлаждения ",
            "Монитор",
            "Клавиатура",
            "Мышь",
            "Наушники",
            "Колонки",
            "Микрофон",
            "Веб-камера"});
            this.cb_type.Location = new System.Drawing.Point(243, 183);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(281, 23);
            this.cb_type.TabIndex = 19;
            this.cb_type.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tb_purchase_price
            // 
            this.tb_purchase_price.Location = new System.Drawing.Point(246, 327);
            this.tb_purchase_price.Name = "tb_purchase_price";
            this.tb_purchase_price.Size = new System.Drawing.Size(278, 20);
            this.tb_purchase_price.TabIndex = 20;
            this.tb_purchase_price.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Введите покупную цену";
            // 
            // AddComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_purchase_price);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_add_component);
            this.Controls.Add(this.tb_stock_quantity);
            this.Controls.Add(this.tb_retail_price);
            this.Controls.Add(this.tb_name);
            this.Name = "AddComponent";
            this.Text = "AddComponent";
            this.Load += new System.EventHandler(this.AddComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_retail_price;
        private System.Windows.Forms.TextBox tb_stock_quantity;
        private System.Windows.Forms.Button btn_add_component;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.TextBox tb_purchase_price;
        private System.Windows.Forms.Label label5;
    }
}