namespace Vozni_Park.View
{
    partial class Login
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
            btnLogIn = new Button();
            tbUserName = new TextBox();
            tbPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // btnLogIn
            // 
            btnLogIn.Location = new Point(280, 256);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(130, 59);
            btnLogIn.TabIndex = 0;
            btnLogIn.Text = "Uloguj se";
            btnLogIn.UseVisualStyleBackColor = true;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // tbUserName
            // 
            tbUserName.Location = new Point(225, 102);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(254, 27);
            tbUserName.TabIndex = 1;
            tbUserName.Text = "Dejan";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(225, 169);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(254, 27);
            tbPassword.TabIndex = 2;
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.KeyPress += tbPassword_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 105);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 3;
            label1.Text = "Korisničko ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 172);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 4;
            label2.Text = "Šifra";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(291, 220);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(109, 20);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Promenite šifru";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 430);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPassword);
            Controls.Add(tbUserName);
            Controls.Add(btnLogIn);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogIn;
        private TextBox tbUserName;
        private TextBox tbPassword;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
    }
}