namespace Vozni_Park.View
{
    partial class TagReplenishment
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
            tbSerialNumber = new TextBox();
            tbAmount = new TextBox();
            dtpDate = new DateTimePicker();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tbReg
            // 
            tbReg.Location = new Point(160, 100);
            tbReg.Name = "tbReg";
            tbReg.Size = new Size(150, 27);
            tbReg.TabIndex = 0;
            // 
            // tbSerialNumber
            // 
            tbSerialNumber.Location = new Point(160, 150);
            tbSerialNumber.Name = "tbSerialNumber";
            tbSerialNumber.Size = new Size(150, 27);
            tbSerialNumber.TabIndex = 1;
            // 
            // tbAmount
            // 
            tbAmount.Location = new Point(160, 201);
            tbAmount.Name = "tbAmount";
            tbAmount.Size = new Size(150, 27);
            tbAmount.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(160, 251);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(150, 27);
            dtpDate.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(160, 312);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 50);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Dopuni";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(386, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(634, 276);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 6;
            label1.Text = "Registracija TAG-a";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 153);
            label2.Name = "label2";
            label2.Size = new Size(131, 20);
            label2.TabIndex = 7;
            label2.Text = "Serijski broj TAG-a";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 204);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 8;
            label3.Text = "Uplata";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 256);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 9;
            label4.Text = "Datum uplate";
            // 
            // TagReplenishment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 756);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(dtpDate);
            Controls.Add(tbAmount);
            Controls.Add(tbSerialNumber);
            Controls.Add(tbReg);
            Name = "TagReplenishment";
            Text = "Uplata TAG-a";
            Load += TagReplenishment_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbReg;
        private TextBox tbSerialNumber;
        private TextBox tbAmount;
        private DateTimePicker dtpDate;
        private Button btnAdd;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}