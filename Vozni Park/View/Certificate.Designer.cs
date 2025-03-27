namespace Vozni_Park.View
{
    partial class Certificate
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
            ofdImage = new OpenFileDialog();
            btnNew = new Button();
            pictureBox1 = new PictureBox();
            btnDelete = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            btnPrint = new Button();
            btnShowImage = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ofdImage
            // 
            ofdImage.FileName = "openFileDialog1";
            // 
            // btnNew
            // 
            btnNew.Location = new Point(10, 23);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(120, 49);
            btnNew.TabIndex = 0;
            btnNew.Text = "Dodaj sliku saobraćajne";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(210, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(945, 810);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(10, 76);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 49);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Obriši sliku saobraćajne";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(84, 270);
            btnPrevious.Margin = new Padding(3, 2, 3, 2);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(120, 49);
            btnPrevious.TabIndex = 4;
            btnPrevious.Text = "Prethodna";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(84, 323);
            btnNext.Margin = new Padding(3, 2, 3, 2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(120, 49);
            btnNext.TabIndex = 5;
            btnNext.Text = "Sledeća";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(10, 129);
            btnPrint.Margin = new Padding(3, 2, 3, 2);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(120, 49);
            btnPrint.TabIndex = 6;
            btnPrint.Text = "Štampaj";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnShowImage
            // 
            btnShowImage.Location = new Point(10, 182);
            btnShowImage.Margin = new Padding(3, 2, 3, 2);
            btnShowImage.Name = "btnShowImage";
            btnShowImage.Size = new Size(120, 49);
            btnShowImage.TabIndex = 7;
            btnShowImage.Text = "Prikaži originalnu sliku";
            btnShowImage.UseVisualStyleBackColor = true;
            btnShowImage.Click += btnShowImage_Click;
            // 
            // Certificate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1410, 813);
            Controls.Add(btnShowImage);
            Controls.Add(btnPrint);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(btnDelete);
            Controls.Add(pictureBox1);
            Controls.Add(btnNew);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Certificate";
            Text = "Saobraćajna";
            FormClosing += Certificate_FormClosing;
            Load += Certificate_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog ofdImage;
        private Button btnNew;
        private PictureBox pictureBox1;
        private Button btnDelete;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnPrint;
        private Button btnShowImage;
    }
}