namespace Vozni_Park.View
{
    partial class CheckRegistrationValidDate
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
            label1 = new Label();
            cmbMines = new ComboBox();
            dataGridView1 = new DataGridView();
            btnFind = new Button();
            label2 = new Label();
            btnPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 107);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 5;
            label1.Text = "Rudnici";
            // 
            // cmbMines
            // 
            cmbMines.FormattingEnabled = true;
            cmbMines.Location = new Point(78, 105);
            cmbMines.Margin = new Padding(3, 2, 3, 2);
            cmbMines.Name = "cmbMines";
            cmbMines.Size = new Size(133, 23);
            cmbMines.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(61, 198);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1260, 332);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(78, 141);
            btnFind.Margin = new Padding(3, 2, 3, 2);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(132, 32);
            btnFind.TabIndex = 6;
            btnFind.Text = "Proveri u rudinku";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(22, 16);
            label2.Name = "label2";
            label2.Size = new Size(277, 28);
            label2.TabIndex = 7;
            label2.Text = "Vozila kojima ističe registracija";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(1189, 141);
            btnPrint.Margin = new Padding(3, 2, 3, 2);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(132, 32);
            btnPrint.TabIndex = 8;
            btnPrint.Text = "Štampaj tabelu";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // CheckRegistrationValidDate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 574);
            Controls.Add(btnPrint);
            Controls.Add(label2);
            Controls.Add(btnFind);
            Controls.Add(label1);
            Controls.Add(cmbMines);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CheckRegistrationValidDate";
            Text = "Vozila kojima ističe registracija";
            Load += CheckRegistrationValidDate_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbMines;
        private DataGridView dataGridView1;
        private Button btnFind;
        private Label label2;
        private Button btnPrint;
    }
}