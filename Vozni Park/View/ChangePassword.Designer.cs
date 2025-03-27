namespace Vozni_Park.View
{
    partial class ChangePassword
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
            btnChange = new Button();
            tbUsername = new TextBox();
            tbOldPassword = new TextBox();
            tbNewPassword = new TextBox();
            tbCheckNewPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnChange
            // 
            btnChange.Location = new Point(164, 239);
            btnChange.Margin = new Padding(3, 2, 3, 2);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(130, 44);
            btnChange.TabIndex = 0;
            btnChange.Text = "Promeni šifru";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(184, 76);
            tbUsername.Margin = new Padding(3, 2, 3, 2);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(176, 23);
            tbUsername.TabIndex = 1;
            // 
            // tbOldPassword
            // 
            tbOldPassword.Location = new Point(184, 111);
            tbOldPassword.Margin = new Padding(3, 2, 3, 2);
            tbOldPassword.Name = "tbOldPassword";
            tbOldPassword.Size = new Size(176, 23);
            tbOldPassword.TabIndex = 2;
            tbOldPassword.UseSystemPasswordChar = true;
            // 
            // tbNewPassword
            // 
            tbNewPassword.Location = new Point(184, 145);
            tbNewPassword.Margin = new Padding(3, 2, 3, 2);
            tbNewPassword.Name = "tbNewPassword";
            tbNewPassword.Size = new Size(176, 23);
            tbNewPassword.TabIndex = 3;
            tbNewPassword.UseSystemPasswordChar = true;
            // 
            // tbCheckNewPassword
            // 
            tbCheckNewPassword.Location = new Point(184, 178);
            tbCheckNewPassword.Margin = new Padding(3, 2, 3, 2);
            tbCheckNewPassword.Name = "tbCheckNewPassword";
            tbCheckNewPassword.Size = new Size(176, 23);
            tbCheckNewPassword.TabIndex = 4;
            tbCheckNewPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 79);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 5;
            label1.Text = "Korisničko ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 113);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 6;
            label2.Text = "Stara šifra";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 147);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 7;
            label3.Text = "Nova šifra";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 181);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 8;
            label4.Text = "Ponovljena šifra";
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 366);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbCheckNewPassword);
            Controls.Add(tbNewPassword);
            Controls.Add(tbOldPassword);
            Controls.Add(tbUsername);
            Controls.Add(btnChange);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChangePassword";
            Text = "Promeni sifru";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChange;
        private TextBox tbUsername;
        private TextBox tbOldPassword;
        private TextBox tbNewPassword;
        private TextBox tbCheckNewPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}