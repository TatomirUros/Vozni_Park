namespace Vozni_Park.View
{
    partial class ServiceType
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
            btnUpdate.Location = new Point(272, 257);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(121, 72);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Izmeni izabrani tip servisa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cmbName
            // 
            cmbName.FormattingEnabled = true;
            cmbName.Location = new Point(276, 146);
            cmbName.Name = "cmbName";
            cmbName.Size = new Size(151, 28);
            cmbName.TabIndex = 8;
            // 
            // tbName
            // 
            tbName.Location = new Point(276, 198);
            tbName.Name = "tbName";
            tbName.Size = new Size(151, 27);
            tbName.TabIndex = 7;
            tbName.TextChanged += tbName_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(411, 256);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(121, 72);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Obriši izabrani tip servisa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(135, 257);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(121, 73);
            btnInsert.TabIndex = 5;
            btnInsert.Text = "Unesi novi tip servisa";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 149);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 10;
            label1.Text = "Svi tipovi servisa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 201);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 11;
            label2.Text = "Naziv tipa servisa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(272, 50);
            label3.Name = "label3";
            label3.Size = new Size(131, 35);
            label3.TabIndex = 13;
            label3.Text = "Tip servisa";
            // 
            // ServiceType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 432);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(cmbName);
            Controls.Add(tbName);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ServiceType";
            Text = "Tip servisa";
            Load += ServiceType_Load;
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