namespace Vozni_Park.View
{
    partial class Owner
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
            btnUpdate = new Button();
            cmbName = new ComboBox();
            tbName = new TextBox();
            btnDelete = new Button();
            btnInsert = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(300, 247);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 60);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Izmeni izabranog vlasnika";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // cmbName
            // 
            cmbName.FormattingEnabled = true;
            cmbName.Location = new Point(299, 115);
            cmbName.Name = "cmbName";
            cmbName.Size = new Size(151, 28);
            cmbName.TabIndex = 8;
            // 
            // tbName
            // 
            tbName.Location = new Point(299, 167);
            tbName.Name = "tbName";
            tbName.Size = new Size(151, 27);
            tbName.TabIndex = 7;
            tbName.TextChanged += tbName_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(469, 247);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(134, 60);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Obriši izabranog vlasnika ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(159, 247);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(123, 60);
            btnInsert.TabIndex = 5;
            btnInsert.Text = "Unesi novog vlasnika";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 118);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 10;
            label1.Text = "Svi vlasnici";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 170);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 11;
            label2.Text = "Naziv vlasnika";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(299, 38);
            label3.Name = "label3";
            label3.Size = new Size(99, 35);
            label3.TabIndex = 12;
            label3.Text = "Vlasnici";
            // 
            // Owner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 396);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(cmbName);
            Controls.Add(tbName);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Owner";
            Text = "Vlasnici";
            Load += Owner_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private ComboBox cmbName;
        private TextBox tbName;
        private Button btnDelete;
        private Button btnInsert;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}