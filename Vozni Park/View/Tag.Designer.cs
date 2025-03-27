namespace Vozni_Park.View
{
    partial class Tag
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
            btnFind = new Button();
            tbFind = new TextBox();
            tbReg = new TextBox();
            tbSerialNumber = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnFind
            // 
            btnFind.Location = new Point(384, 43);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(132, 50);
            btnFind.TabIndex = 0;
            btnFind.Text = "Dopuni pronađeni TAG";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // tbFind
            // 
            tbFind.Location = new Point(160, 55);
            tbFind.Name = "tbFind";
            tbFind.Size = new Size(174, 27);
            tbFind.TabIndex = 1;
            tbFind.TextChanged += tbFind_TextChanged;
            // 
            // tbReg
            // 
            tbReg.Location = new Point(160, 163);
            tbReg.Name = "tbReg";
            tbReg.Size = new Size(174, 27);
            tbReg.TabIndex = 2;
            // 
            // tbSerialNumber
            // 
            tbSerialNumber.Location = new Point(160, 212);
            tbSerialNumber.Name = "tbSerialNumber";
            tbSerialNumber.Size = new Size(174, 27);
            tbSerialNumber.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(160, 281);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(174, 63);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Dodaj novi TAG";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(160, 360);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(86, 63);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Izmeni TAG";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(261, 360);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(77, 63);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Obriši TAG";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(384, 120);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(957, 515);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 43);
            label1.Name = "label1";
            label1.Size = new Size(100, 40);
            label1.TabIndex = 9;
            label1.Text = "Pretraži TAG\r\npo registraciji";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 170);
            label2.Name = "label2";
            label2.Size = new Size(131, 20);
            label2.TabIndex = 10;
            label2.Text = "Registracija TAG-a";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 215);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 11;
            label3.Text = "Serijski broj TAG-a";
            // 
            // Tag
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1457, 784);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(tbSerialNumber);
            Controls.Add(tbReg);
            Controls.Add(tbFind);
            Controls.Add(btnFind);
            Name = "Tag";
            Text = "Tag";
            Load += Tag_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFind;
        private TextBox tbFind;
        private TextBox tbReg;
        private TextBox tbSerialNumber;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}