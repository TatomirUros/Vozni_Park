namespace Vozni_Park.View
{
    partial class Subcategory
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
            label4 = new Label();
            cmbCategory = new ComboBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(273, 53);
            label3.Name = "label3";
            label3.Size = new Size(129, 28);
            label3.TabIndex = 25;
            label3.Text = "Potkategorije";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(190, 198);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 24;
            label2.Text = "Naziv potkategorije";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(201, 119);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 23;
            label1.Text = "Sve potkategorije";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(290, 251);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 45);
            btnUpdate.TabIndex = 22;
            btnUpdate.Text = "Izmeni izabranu potkategoriju";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cmbName
            // 
            cmbName.FormattingEnabled = true;
            cmbName.Location = new Point(313, 116);
            cmbName.Margin = new Padding(3, 2, 3, 2);
            cmbName.Name = "cmbName";
            cmbName.Size = new Size(133, 23);
            cmbName.TabIndex = 21;
            cmbName.SelectedIndexChanged += cmbName_SelectedIndexChanged_1;
            // 
            // tbName
            // 
            tbName.Location = new Point(313, 195);
            tbName.Margin = new Padding(3, 2, 3, 2);
            tbName.Name = "tbName";
            tbName.Size = new Size(133, 23);
            tbName.TabIndex = 20;
            tbName.TextChanged += tbName_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(428, 251);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(108, 45);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Obriši izabranu potkategoriju";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(166, 251);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(99, 45);
            btnInsert.TabIndex = 18;
            btnInsert.Text = "Unesi novu potkategoriju";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(166, 158);
            label4.Name = "label4";
            label4.Size = new Size(133, 15);
            label4.TabIndex = 27;
            label4.Text = "Kategorija potkategorije";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(313, 155);
            cmbCategory.Margin = new Padding(3, 2, 3, 2);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(133, 23);
            cmbCategory.TabIndex = 26;
            // 
            // Subcategory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 371);
            Controls.Add(label4);
            Controls.Add(cmbCategory);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(cmbName);
            Controls.Add(tbName);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Name = "Subcategory";
            Text = "Potkategorije";
            Load += Subcategory_Load;
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
        private Label label4;
        private ComboBox cmbCategory;
    }
}