namespace Vozni_Park.View
{
    partial class ServiceVehicle
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
            tbModel = new TextBox();
            tbBrand = new TextBox();
            tbReg = new TextBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tbModel
            // 
            tbModel.Location = new Point(132, 145);
            tbModel.Name = "tbModel";
            tbModel.Size = new Size(168, 27);
            tbModel.TabIndex = 5;
            // 
            // tbBrand
            // 
            tbBrand.Location = new Point(132, 91);
            tbBrand.Name = "tbBrand";
            tbBrand.Size = new Size(168, 27);
            tbBrand.TabIndex = 4;
            // 
            // tbReg
            // 
            tbReg.Location = new Point(132, 36);
            tbReg.Name = "tbReg";
            tbReg.Size = new Size(168, 27);
            tbReg.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(51, 201);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1313, 445);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 39);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 7;
            label1.Text = "Registracija";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 94);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 8;
            label2.Text = "Marka";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 148);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 9;
            label3.Text = "Model";
            // 
            // ServiceVehicle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 687);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(tbModel);
            Controls.Add(tbBrand);
            Controls.Add(tbReg);
            Name = "ServiceVehicle";
            Text = "Servisi urađeni na vozilu";
            Load += ServiceVehicle_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbModel;
        private TextBox tbBrand;
        private TextBox tbReg;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}