namespace Vozni_Park.View
{
    partial class Mine
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
            btnInsert = new Button();
            btnDelete = new Button();
            tbName = new TextBox();
            cmbName = new ComboBox();
            btnUpdate = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(140, 184);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(99, 44);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Unesi novi rudnik";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(402, 184);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(108, 44);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Obriši izabrani rudnik";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // tbName
            // 
            tbName.Location = new Point(262, 124);
            tbName.Margin = new Padding(3, 2, 3, 2);
            tbName.Name = "tbName";
            tbName.Size = new Size(133, 23);
            tbName.TabIndex = 2;
            tbName.TextChanged += tbName_TextChanged;
            // 
            // cmbName
            // 
            cmbName.FormattingEnabled = true;
            cmbName.Location = new Point(262, 85);
            cmbName.Margin = new Padding(3, 2, 3, 2);
            cmbName.Name = "cmbName";
            cmbName.Size = new Size(133, 23);
            cmbName.TabIndex = 3;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(264, 184);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 44);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Izmeni izabrani rudnik";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(189, 87);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 5;
            label1.Text = "Svi rudnici";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(170, 126);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 6;
            label2.Text = "Naziv rudnika";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(262, 22);
            label3.Name = "label3";
            label3.Size = new Size(77, 28);
            label3.TabIndex = 9;
            label3.Text = "Rudnici";
            // 
            // Mine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 288);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(cmbName);
            Controls.Add(tbName);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Mine";
            Text = "Rudnik";
            Load += Mine_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInsert;
        private Button btnDelete;
        private TextBox tbName;
        private ComboBox cmbName;
        private Button btnUpdate;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}