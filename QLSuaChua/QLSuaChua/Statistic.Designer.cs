namespace QLSuaChua
{
    partial class Statistic
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnthang = new System.Windows.Forms.Button();
            this.btnquaylai = new System.Windows.Forms.Button();
            this.btnnam = new System.Windows.Forms.Button();
            this.btnngay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(455, 271);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnthang);
            this.panel2.Controls.Add(this.btnquaylai);
            this.panel2.Controls.Add(this.btnnam);
            this.panel2.Controls.Add(this.btnngay);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 56);
            this.panel2.TabIndex = 5;
            // 
            // btnthang
            // 
            this.btnthang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnthang.Location = new System.Drawing.Point(142, 11);
            this.btnthang.Name = "btnthang";
            this.btnthang.Size = new System.Drawing.Size(75, 35);
            this.btnthang.TabIndex = 4;
            this.btnthang.Text = "Tháng";
            this.btnthang.UseVisualStyleBackColor = true;
            this.btnthang.Click += new System.EventHandler(this.btnthang_Click);
            // 
            // btnquaylai
            // 
            this.btnquaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnquaylai.Location = new System.Drawing.Point(334, 11);
            this.btnquaylai.Name = "btnquaylai";
            this.btnquaylai.Size = new System.Drawing.Size(75, 35);
            this.btnquaylai.TabIndex = 3;
            this.btnquaylai.Text = "Quay lại";
            this.btnquaylai.UseVisualStyleBackColor = true;
            this.btnquaylai.Click += new System.EventHandler(this.btnquaylai_Click);
            // 
            // btnnam
            // 
            this.btnnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnnam.Location = new System.Drawing.Point(238, 11);
            this.btnnam.Name = "btnnam";
            this.btnnam.Size = new System.Drawing.Size(75, 35);
            this.btnnam.TabIndex = 2;
            this.btnnam.Text = "Năm";
            this.btnnam.UseVisualStyleBackColor = true;
            this.btnnam.Click += new System.EventHandler(this.btnnam_Click);
            // 
            // btnngay
            // 
            this.btnngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnngay.Location = new System.Drawing.Point(47, 11);
            this.btnngay.Name = "btnngay";
            this.btnngay.Size = new System.Drawing.Size(75, 35);
            this.btnngay.TabIndex = 0;
            this.btnngay.Text = "Ngày";
            this.btnngay.UseVisualStyleBackColor = true;
            this.btnngay.Click += new System.EventHandler(this.btnngay_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 271);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.panel3.Location = new System.Drawing.Point(12, 351);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 40);
            this.panel3.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id hóa đơn:";
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 403);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "Statistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistic";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnthang;
        private System.Windows.Forms.Button btnquaylai;
        private System.Windows.Forms.Button btnnam;
        private System.Windows.Forms.Button btnngay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}