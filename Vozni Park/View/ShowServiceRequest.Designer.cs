namespace Vozni_Park.View
{
    partial class ShowServiceRequest
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
            pictureBox1 = new PictureBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnBefore = new Button();
            btnNext = new Button();
            tbNumberOfRequest = new TextBox();
            tbDescription = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(454, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 850);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(166, 281);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(91, 82);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Dodaj sliku";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(262, 281);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(91, 82);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Obriši sliku";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnBefore
            // 
            btnBefore.Location = new Point(166, 369);
            btnBefore.Name = "btnBefore";
            btnBefore.Size = new Size(91, 51);
            btnBefore.TabIndex = 3;
            btnBefore.Text = "Prethodna";
            btnBefore.UseVisualStyleBackColor = true;
            btnBefore.Click += btnBefore_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(262, 369);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(91, 51);
            btnNext.TabIndex = 4;
            btnNext.Text = "Sledeća";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // tbNumberOfRequest
            // 
            tbNumberOfRequest.Location = new Point(166, 75);
            tbNumberOfRequest.Name = "tbNumberOfRequest";
            tbNumberOfRequest.Size = new Size(187, 27);
            tbNumberOfRequest.TabIndex = 5;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(166, 127);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(187, 123);
            tbDescription.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 78);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 7;
            label1.Text = "Broj/naziv zahteva";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 130);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 8;
            label2.Text = "Opis zahteva";
            // 
            // ShowServiceRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 889);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbDescription);
            Controls.Add(tbNumberOfRequest);
            Controls.Add(btnNext);
            Controls.Add(btnBefore);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(pictureBox1);
            Name = "ShowServiceRequest";
            Text = "Zahtev za servisom";
            Load += ShowServiceRequest_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnBefore;
        private Button btnNext;
        private TextBox tbNumberOfRequest;
        private TextBox tbDescription;
        private Label label1;
        private Label label2;
    }
}