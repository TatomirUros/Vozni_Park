namespace Vozni_Park.View
{
    partial class Category
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnUpdate = new Button();
            cmbName = new ComboBox();
            tbName = new TextBox();
            btnDelete = new Button();
            btnInsert = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(277, 52);
            label3.Name = "label3";
            label3.Size = new Size(102, 28);
            label3.TabIndex = 17;
            label3.Text = "Kategorije";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 157);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 16;
            label2.Text = "Naziv kategorije";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(184, 118);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 15;
            label1.Text = "Sve kategorije";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(279, 214);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 45);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Izmeni izabranu kategoriju";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cmbName
            // 
            cmbName.FormattingEnabled = true;
            cmbName.Location = new Point(277, 115);
            cmbName.Margin = new Padding(3, 2, 3, 2);
            cmbName.Name = "cmbName";
            cmbName.Size = new Size(133, 23);
            cmbName.TabIndex = 13;
            // 
            // tbName
            // 
            tbName.Location = new Point(277, 154);
            tbName.Margin = new Padding(3, 2, 3, 2);
            tbName.Name = "tbName";
            tbName.Size = new Size(133, 23);
            tbName.TabIndex = 12;
            tbName.TextChanged += tbName_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(417, 214);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(108, 45);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Obriši izabranu kategoriju";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(155, 214);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(99, 45);
            btnInsert.TabIndex = 10;
            btnInsert.Text = "Unesi novu kategoriju";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // Category
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 316);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(cmbName);
            Controls.Add(tbName);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Name = "Category";
            Text = "Kategorije";
            Load += Category_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnUpdate;
        private ComboBox cmbName;
        private TextBox tbName;
        private Button btnDelete;
        private Button btnInsert;
    }
}