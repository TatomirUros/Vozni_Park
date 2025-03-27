namespace Vozni_Park.View
{
    partial class ServiceRequest
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
            tbReg = new TextBox();
            tbBrand = new TextBox();
            tbModel = new TextBox();
            tbNumber = new TextBox();
            cmbTypService = new ComboBox();
            dataGridView1 = new DataGridView();
            btnAdd = new Button();
            tbDescription = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tbReg
            // 
            tbReg.Location = new Point(140, 60);
            tbReg.Name = "tbReg";
            tbReg.Size = new Size(168, 27);
            tbReg.TabIndex = 0;
            // 
            // tbBrand
            // 
            tbBrand.Location = new Point(140, 115);
            tbBrand.Name = "tbBrand";
            tbBrand.Size = new Size(168, 27);
            tbBrand.TabIndex = 1;
            // 
            // tbModel
            // 
            tbModel.Location = new Point(140, 169);
            tbModel.Name = "tbModel";
            tbModel.Size = new Size(168, 27);
            tbModel.TabIndex = 2;
            // 
            // tbNumber
            // 
            tbNumber.Location = new Point(140, 271);
            tbNumber.Name = "tbNumber";
            tbNumber.Size = new Size(168, 27);
            tbNumber.TabIndex = 3;
            // 
            // cmbTypService
            // 
            cmbTypService.FormattingEnabled = true;
            cmbTypService.Location = new Point(140, 216);
            cmbTypService.Name = "cmbTypService";
            cmbTypService.Size = new Size(168, 28);
            cmbTypService.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(490, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(803, 319);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(140, 447);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 70);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Dodaj zahtev";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(140, 329);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(235, 87);
            tbDescription.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 60);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 8;
            label1.Text = "Registracija";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 118);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 9;
            label2.Text = "Marka";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 172);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 10;
            label3.Text = "Model";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 219);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 11;
            label4.Text = "Tip servisa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 274);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 12;
            label5.Text = "Broj zahteva";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 332);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 13;
            label6.Text = "Opis zahteva";
            // 
            // ServiceRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1347, 623);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbDescription);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Controls.Add(cmbTypService);
            Controls.Add(tbNumber);
            Controls.Add(tbModel);
            Controls.Add(tbBrand);
            Controls.Add(tbReg);
            Name = "ServiceRequest";
            Text = "Zahtevi za servis vozila";
            Load += ServiceRequest_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbReg;
        private TextBox tbBrand;
        private TextBox tbModel;
        private TextBox tbNumber;
        private ComboBox cmbTypService;
        private DataGridView dataGridView1;
        private Button btnAdd;
        private TextBox tbDescription;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}