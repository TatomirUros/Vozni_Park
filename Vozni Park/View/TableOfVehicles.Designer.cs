namespace Vozni_Park.View
{
    partial class TableOfVehicles
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
            label5 = new Label();
            cmbOwner = new ComboBox();
            btnFind = new Button();
            label4 = new Label();
            label3 = new Label();
            cmbSubcategory = new ComboBox();
            cmbCategory = new ComboBox();
            btnPrint = new Button();
            label2 = new Label();
            label1 = new Label();
            cmbMine = new ComboBox();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            cmbState = new ComboBox();
            cbMine = new CheckBox();
            cbCategory = new CheckBox();
            cbSubcategory = new CheckBox();
            cbOwner = new CheckBox();
            cbState = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(514, 74);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 39;
            label5.Text = "Vlasnik";
            // 
            // cmbOwner
            // 
            cmbOwner.FormattingEnabled = true;
            cmbOwner.Location = new Point(514, 91);
            cmbOwner.Margin = new Padding(3, 2, 3, 2);
            cmbOwner.Name = "cmbOwner";
            cmbOwner.Size = new Size(133, 23);
            cmbOwner.TabIndex = 38;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(52, 174);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(115, 38);
            btnFind.TabIndex = 37;
            btnFind.Text = "Pretraži";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(357, 74);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 33;
            label4.Text = "Potkategorija";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(204, 74);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 32;
            label3.Text = "Kategorija";
            // 
            // cmbSubcategory
            // 
            cmbSubcategory.FormattingEnabled = true;
            cmbSubcategory.Location = new Point(357, 91);
            cmbSubcategory.Margin = new Padding(3, 2, 3, 2);
            cmbSubcategory.Name = "cmbSubcategory";
            cmbSubcategory.Size = new Size(133, 23);
            cmbSubcategory.TabIndex = 31;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(204, 91);
            cmbCategory.Margin = new Padding(3, 2, 3, 2);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(133, 23);
            cmbCategory.TabIndex = 30;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(1358, 174);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(115, 38);
            btnPrint.TabIndex = 29;
            btnPrint.Text = "Štampaj tabelu";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(52, 28);
            label2.Name = "label2";
            label2.Size = new Size(407, 28);
            label2.TabIndex = 28;
            label2.Text = "Vozila podeljena po kategorijama i rudnicima";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 74);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 27;
            label1.Text = "Rudink";
            // 
            // cmbMine
            // 
            cmbMine.FormattingEnabled = true;
            cmbMine.Location = new Point(52, 91);
            cmbMine.Margin = new Padding(3, 2, 3, 2);
            cmbMine.Name = "cmbMine";
            cmbMine.Size = new Size(133, 23);
            cmbMine.TabIndex = 26;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(52, 236);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1421, 332);
            dataGridView1.TabIndex = 25;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(663, 74);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 41;
            label6.Text = "Stanje";
            // 
            // cmbState
            // 
            cmbState.FormattingEnabled = true;
            cmbState.Location = new Point(663, 91);
            cmbState.Margin = new Padding(3, 2, 3, 2);
            cmbState.Name = "cmbState";
            cmbState.Size = new Size(133, 23);
            cmbState.TabIndex = 40;
            // 
            // cbMine
            // 
            cbMine.AutoSize = true;
            cbMine.Location = new Point(170, 72);
            cbMine.Name = "cbMine";
            cbMine.Size = new Size(15, 14);
            cbMine.TabIndex = 42;
            cbMine.UseVisualStyleBackColor = true;
            // 
            // cbCategory
            // 
            cbCategory.AutoSize = true;
            cbCategory.Location = new Point(322, 72);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(15, 14);
            cbCategory.TabIndex = 43;
            cbCategory.UseVisualStyleBackColor = true;
            // 
            // cbSubcategory
            // 
            cbSubcategory.AutoSize = true;
            cbSubcategory.Location = new Point(475, 72);
            cbSubcategory.Name = "cbSubcategory";
            cbSubcategory.Size = new Size(15, 14);
            cbSubcategory.TabIndex = 44;
            cbSubcategory.UseVisualStyleBackColor = true;
            // 
            // cbOwner
            // 
            cbOwner.AutoSize = true;
            cbOwner.Location = new Point(632, 72);
            cbOwner.Name = "cbOwner";
            cbOwner.Size = new Size(15, 14);
            cbOwner.TabIndex = 45;
            cbOwner.UseVisualStyleBackColor = true;
            // 
            // cbState
            // 
            cbState.AutoSize = true;
            cbState.Location = new Point(781, 72);
            cbState.Name = "cbState";
            cbState.Size = new Size(15, 14);
            cbState.TabIndex = 46;
            cbState.UseVisualStyleBackColor = true;
            // 
            // TableOfVehicles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1519, 630);
            Controls.Add(cbState);
            Controls.Add(cbOwner);
            Controls.Add(cbSubcategory);
            Controls.Add(cbCategory);
            Controls.Add(cbMine);
            Controls.Add(label6);
            Controls.Add(cmbState);
            Controls.Add(label5);
            Controls.Add(cmbOwner);
            Controls.Add(btnFind);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbSubcategory);
            Controls.Add(cmbCategory);
            Controls.Add(btnPrint);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbMine);
            Controls.Add(dataGridView1);
            Name = "TableOfVehicles";
            Text = "Prikaz vozila";
            Load += TabelOfVehicles_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private ComboBox cmbOwner;
        private Button btnFind;
        private Label label4;
        private Label label3;
        private ComboBox cmbSubcategory;
        private ComboBox cmbCategory;
        private Button btnPrint;
        private Label label2;
        private Label label1;
        private ComboBox cmbMine;
        private DataGridView dataGridView1;
        private Label label6;
        private ComboBox cmbState;
        private CheckBox cbMine;
        private CheckBox cbCategory;
        private CheckBox cbSubcategory;
        private CheckBox cbOwner;
        private CheckBox cbState;
    }
}