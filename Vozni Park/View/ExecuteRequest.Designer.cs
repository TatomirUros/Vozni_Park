namespace Vozni_Park.View
{
    partial class ExecuteRequest
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
            btnExecute = new Button();
            tbReg = new TextBox();
            tbKm = new TextBox();
            tbDescription = new TextBox();
            cmbServiceType = new ComboBox();
            cmbRepairer = new ComboBox();
            dtpDate = new DateTimePicker();
            tbPrice = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            btnDelete = new Button();
            btnNext = new Button();
            btnBefore = new Button();
            btnAddImage = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(212, 541);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(215, 75);
            btnExecute.TabIndex = 0;
            btnExecute.Text = "Ispuni zahtev";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // tbReg
            // 
            tbReg.Location = new Point(213, 57);
            tbReg.Name = "tbReg";
            tbReg.Size = new Size(214, 27);
            tbReg.TabIndex = 1;
            // 
            // tbKm
            // 
            tbKm.Location = new Point(213, 107);
            tbKm.Name = "tbKm";
            tbKm.Size = new Size(214, 27);
            tbKm.TabIndex = 2;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(213, 327);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(341, 105);
            tbDescription.TabIndex = 4;
            // 
            // cmbServiceType
            // 
            cmbServiceType.FormattingEnabled = true;
            cmbServiceType.Location = new Point(213, 212);
            cmbServiceType.Name = "cmbServiceType";
            cmbServiceType.Size = new Size(214, 28);
            cmbServiceType.TabIndex = 5;
            // 
            // cmbRepairer
            // 
            cmbRepairer.FormattingEnabled = true;
            cmbRepairer.Location = new Point(213, 270);
            cmbRepairer.Name = "cmbRepairer";
            cmbRepairer.Size = new Size(214, 28);
            cmbRepairer.TabIndex = 6;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(212, 157);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(215, 27);
            dtpDate.TabIndex = 7;
            // 
            // tbPrice
            // 
            tbPrice.Location = new Point(212, 458);
            tbPrice.Name = "tbPrice";
            tbPrice.Size = new Size(214, 27);
            tbPrice.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 64);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 9;
            label1.Text = "Registracija";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 110);
            label2.Name = "label2";
            label2.Size = new Size(159, 20);
            label2.TabIndex = 10;
            label2.Text = "Kilometraža pri servisu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 162);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 11;
            label3.Text = "Datum servisa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(108, 215);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 12;
            label4.Text = "Tip servisa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(126, 273);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 13;
            label5.Text = "Serviser";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(89, 330);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 14;
            label6.Text = "Detaljan opis";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(144, 461);
            label7.Name = "label7";
            label7.Size = new Size(42, 20);
            label7.TabIndex = 15;
            label7.Text = "Cena";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(628, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(595, 595);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(924, 622);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(124, 75);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Obriši sliku računa/fakture";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1119, 622);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(101, 75);
            btnNext.TabIndex = 18;
            btnNext.Text = "Sledeća";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnBefore
            // 
            btnBefore.Location = new Point(628, 622);
            btnBefore.Name = "btnBefore";
            btnBefore.Size = new Size(101, 75);
            btnBefore.TabIndex = 19;
            btnBefore.Text = "Prethodna";
            btnBefore.UseVisualStyleBackColor = true;
            btnBefore.Click += btnBefore_Click;
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new Point(794, 622);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(124, 75);
            btnAddImage.TabIndex = 20;
            btnAddImage.Text = "Dodaj slike računa/fakture";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // ExecuteRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1336, 785);
            Controls.Add(btnAddImage);
            Controls.Add(btnBefore);
            Controls.Add(btnNext);
            Controls.Add(btnDelete);
            Controls.Add(pictureBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPrice);
            Controls.Add(dtpDate);
            Controls.Add(cmbRepairer);
            Controls.Add(cmbServiceType);
            Controls.Add(tbDescription);
            Controls.Add(tbKm);
            Controls.Add(tbReg);
            Controls.Add(btnExecute);
            Name = "ExecuteRequest";
            Text = "Zahtevi za servisom";
            Load += ExecuteRequest_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExecute;
        private TextBox tbReg;
        private TextBox tbKm;
        private TextBox tbDescription;
        private ComboBox cmbServiceType;
        private ComboBox cmbRepairer;
        private DateTimePicker dtpDate;
        private TextBox tbPrice;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private PictureBox pictureBox1;
        private Button btnDelete;
        private Button btnNext;
        private Button btnBefore;
        private Button btnAddImage;
    }
}