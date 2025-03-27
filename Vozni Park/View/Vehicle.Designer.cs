namespace Vozni_Park.View
{
    partial class Vehicle
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vehicle));
            tbBrand = new TextBox();
            tbModel = new TextBox();
            tbKm = new TextBox();
            tbReg = new TextBox();
            cmbOwner = new ComboBox();
            cmbMine = new ComboBox();
            btnUpdateBrand = new Button();
            btnUpdateModel = new Button();
            btnUpdateKm = new Button();
            btnUpdateOwner = new Button();
            btnUpdateMine = new Button();
            btnUpdateReg = new Button();
            btnUpdateDate = new Button();
            dtpDate = new DateTimePicker();
            btnNew = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnShowCertifivate = new Button();
            btnRequest = new Button();
            btnServiceVehicle = new Button();
            tbFind = new TextBox();
            lbNumberOfRequests = new Label();
            pictureBox1 = new PictureBox();
            btnBefore = new Button();
            btnNext = new Button();
            btnDeleteImage = new Button();
            btnAddImage = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            menuStrip1 = new MenuStrip();
            tAGToolStripMenuItem = new ToolStripMenuItem();
            osnovneInformacijeToolStripMenuItem = new ToolStripMenuItem();
            rudniciToolStripMenuItem = new ToolStripMenuItem();
            vlasniciToolStripMenuItem = new ToolStripMenuItem();
            serviseriToolStripMenuItem = new ToolStripMenuItem();
            tipServisaToolStripMenuItem1 = new ToolStripMenuItem();
            kategorijeToolStripMenuItem = new ToolStripMenuItem();
            potkategorijeToolStripMenuItem = new ToolStripMenuItem();
            tabelarniPrikazVozilaToolStripMenuItem = new ToolStripMenuItem();
            validnostRegistracijaToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            rbRegWas = new RadioButton();
            rbRegNo = new RadioButton();
            rbRegYes = new RadioButton();
            btnClear = new Button();
            bindingSource1 = new BindingSource(components);
            btnShowImage = new Button();
            label9 = new Label();
            label10 = new Label();
            cmbSubcategory = new ComboBox();
            cmbCategory = new ComboBox();
            btnUpdateSubcategory = new Button();
            btnUpdateCategory = new Button();
            btnUpdateState = new Button();
            label11 = new Label();
            cmbVehicleState = new ComboBox();
            btnShowAllRegistrationPlates = new Button();
            label12 = new Label();
            btnUpdateTireDimension = new Button();
            tbTireDimension = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // tbBrand
            // 
            tbBrand.Location = new Point(121, 119);
            tbBrand.Margin = new Padding(3, 2, 3, 2);
            tbBrand.Name = "tbBrand";
            tbBrand.Size = new Size(133, 23);
            tbBrand.TabIndex = 1;
            // 
            // tbModel
            // 
            tbModel.Location = new Point(121, 153);
            tbModel.Margin = new Padding(3, 2, 3, 2);
            tbModel.Name = "tbModel";
            tbModel.Size = new Size(133, 23);
            tbModel.TabIndex = 2;
            // 
            // tbKm
            // 
            tbKm.Location = new Point(121, 184);
            tbKm.Margin = new Padding(3, 2, 3, 2);
            tbKm.Name = "tbKm";
            tbKm.Size = new Size(133, 23);
            tbKm.TabIndex = 3;
            // 
            // tbReg
            // 
            tbReg.Location = new Point(121, 367);
            tbReg.Margin = new Padding(3, 2, 3, 2);
            tbReg.Name = "tbReg";
            tbReg.Size = new Size(133, 23);
            tbReg.TabIndex = 4;
            // 
            // cmbOwner
            // 
            cmbOwner.FormattingEnabled = true;
            cmbOwner.Location = new Point(121, 218);
            cmbOwner.Margin = new Padding(3, 2, 3, 2);
            cmbOwner.Name = "cmbOwner";
            cmbOwner.Size = new Size(133, 23);
            cmbOwner.TabIndex = 6;
            // 
            // cmbMine
            // 
            cmbMine.FormattingEnabled = true;
            cmbMine.Location = new Point(121, 254);
            cmbMine.Margin = new Padding(3, 2, 3, 2);
            cmbMine.Name = "cmbMine";
            cmbMine.Size = new Size(133, 23);
            cmbMine.TabIndex = 7;
            // 
            // btnUpdateBrand
            // 
            btnUpdateBrand.Image = (Image)resources.GetObject("btnUpdateBrand.Image");
            btnUpdateBrand.Location = new Point(278, 119);
            btnUpdateBrand.Margin = new Padding(3, 2, 3, 2);
            btnUpdateBrand.Name = "btnUpdateBrand";
            btnUpdateBrand.Size = new Size(26, 21);
            btnUpdateBrand.TabIndex = 8;
            btnUpdateBrand.UseVisualStyleBackColor = true;
            btnUpdateBrand.Click += btnUpdateBrand_Click;
            // 
            // btnUpdateModel
            // 
            btnUpdateModel.Image = (Image)resources.GetObject("btnUpdateModel.Image");
            btnUpdateModel.Location = new Point(278, 151);
            btnUpdateModel.Margin = new Padding(3, 2, 3, 2);
            btnUpdateModel.Name = "btnUpdateModel";
            btnUpdateModel.Size = new Size(26, 21);
            btnUpdateModel.TabIndex = 9;
            btnUpdateModel.UseVisualStyleBackColor = true;
            btnUpdateModel.Click += btnUpdateModel_Click;
            // 
            // btnUpdateKm
            // 
            btnUpdateKm.Image = (Image)resources.GetObject("btnUpdateKm.Image");
            btnUpdateKm.Location = new Point(278, 183);
            btnUpdateKm.Margin = new Padding(3, 2, 3, 2);
            btnUpdateKm.Name = "btnUpdateKm";
            btnUpdateKm.Size = new Size(26, 21);
            btnUpdateKm.TabIndex = 10;
            btnUpdateKm.UseVisualStyleBackColor = true;
            btnUpdateKm.Click += btnUpdateKm_Click;
            // 
            // btnUpdateOwner
            // 
            btnUpdateOwner.Image = (Image)resources.GetObject("btnUpdateOwner.Image");
            btnUpdateOwner.Location = new Point(278, 218);
            btnUpdateOwner.Margin = new Padding(3, 2, 3, 2);
            btnUpdateOwner.Name = "btnUpdateOwner";
            btnUpdateOwner.Size = new Size(26, 21);
            btnUpdateOwner.TabIndex = 11;
            btnUpdateOwner.UseVisualStyleBackColor = true;
            btnUpdateOwner.Click += btnUpdateOwner_Click;
            // 
            // btnUpdateMine
            // 
            btnUpdateMine.Image = (Image)resources.GetObject("btnUpdateMine.Image");
            btnUpdateMine.Location = new Point(278, 254);
            btnUpdateMine.Margin = new Padding(3, 2, 3, 2);
            btnUpdateMine.Name = "btnUpdateMine";
            btnUpdateMine.Size = new Size(26, 21);
            btnUpdateMine.TabIndex = 12;
            btnUpdateMine.UseVisualStyleBackColor = true;
            btnUpdateMine.Click += btnUpdateMine_Click;
            // 
            // btnUpdateReg
            // 
            btnUpdateReg.Image = (Image)resources.GetObject("btnUpdateReg.Image");
            btnUpdateReg.Location = new Point(278, 366);
            btnUpdateReg.Margin = new Padding(3, 2, 3, 2);
            btnUpdateReg.Name = "btnUpdateReg";
            btnUpdateReg.Size = new Size(26, 21);
            btnUpdateReg.TabIndex = 13;
            btnUpdateReg.UseVisualStyleBackColor = true;
            btnUpdateReg.Click += btnUpdateReg_Click;
            // 
            // btnUpdateDate
            // 
            btnUpdateDate.Image = (Image)resources.GetObject("btnUpdateDate.Image");
            btnUpdateDate.Location = new Point(278, 408);
            btnUpdateDate.Margin = new Padding(3, 2, 3, 2);
            btnUpdateDate.Name = "btnUpdateDate";
            btnUpdateDate.Size = new Size(26, 21);
            btnUpdateDate.TabIndex = 14;
            btnUpdateDate.UseVisualStyleBackColor = true;
            btnUpdateDate.Click += btnUpdateDate_Click;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(121, 407);
            dtpDate.Margin = new Padding(3, 2, 3, 2);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(133, 23);
            dtpDate.TabIndex = 15;
            dtpDate.Value = new DateTime(2023, 10, 24, 21, 26, 7, 0);
            // 
            // btnNew
            // 
            btnNew.Location = new Point(34, 586);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(95, 40);
            btnNew.TabIndex = 16;
            btnNew.Text = "Dodaj novi auto";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(145, 586);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(95, 40);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Izmeni izabrani auto";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(259, 586);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(95, 40);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Obriši izabrani auto";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnShowCertifivate
            // 
            btnShowCertifivate.Location = new Point(34, 517);
            btnShowCertifivate.Margin = new Padding(3, 2, 3, 2);
            btnShowCertifivate.Name = "btnShowCertifivate";
            btnShowCertifivate.Size = new Size(132, 50);
            btnShowCertifivate.TabIndex = 20;
            btnShowCertifivate.Text = "Prikazi saobraćajnu izabranog auta";
            btnShowCertifivate.UseVisualStyleBackColor = true;
            btnShowCertifivate.Click += btnShowCertifivate_Click;
            // 
            // btnRequest
            // 
            btnRequest.Location = new Point(34, 672);
            btnRequest.Margin = new Padding(3, 2, 3, 2);
            btnRequest.Name = "btnRequest";
            btnRequest.Size = new Size(104, 56);
            btnRequest.TabIndex = 21;
            btnRequest.Text = "Otvori zahteve vozila";
            btnRequest.UseVisualStyleBackColor = true;
            btnRequest.Click += btnRequest_Click;
            // 
            // btnServiceVehicle
            // 
            btnServiceVehicle.Location = new Point(175, 672);
            btnServiceVehicle.Margin = new Padding(3, 2, 3, 2);
            btnServiceVehicle.Name = "btnServiceVehicle";
            btnServiceVehicle.Size = new Size(104, 56);
            btnServiceVehicle.TabIndex = 22;
            btnServiceVehicle.Text = "Otvori servise vozila";
            btnServiceVehicle.UseVisualStyleBackColor = true;
            btnServiceVehicle.Click += btnServiceVehicle_Click;
            // 
            // tbFind
            // 
            tbFind.Location = new Point(121, 54);
            tbFind.Margin = new Padding(3, 2, 3, 2);
            tbFind.Name = "tbFind";
            tbFind.Size = new Size(133, 23);
            tbFind.TabIndex = 23;
            tbFind.TextChanged += tbFind_TextChangedAsync;
            // 
            // lbNumberOfRequests
            // 
            lbNumberOfRequests.AutoSize = true;
            lbNumberOfRequests.BackColor = SystemColors.ButtonFace;
            lbNumberOfRequests.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lbNumberOfRequests.Location = new Point(34, 637);
            lbNumberOfRequests.Name = "lbNumberOfRequests";
            lbNumberOfRequests.Size = new Size(59, 25);
            lbNumberOfRequests.TabIndex = 24;
            lbNumberOfRequests.Text = "label1";
            lbNumberOfRequests.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(500, 53);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(630, 531);
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // btnBefore
            // 
            btnBefore.Location = new Point(510, 604);
            btnBefore.Margin = new Padding(3, 2, 3, 2);
            btnBefore.Name = "btnBefore";
            btnBefore.Size = new Size(79, 52);
            btnBefore.TabIndex = 26;
            btnBefore.Text = "Prethodna";
            btnBefore.UseVisualStyleBackColor = true;
            btnBefore.Click += btnBefore_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1042, 604);
            btnNext.Margin = new Padding(3, 2, 3, 2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(79, 52);
            btnNext.TabIndex = 27;
            btnNext.Text = "Sledeća";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnDeleteImage
            // 
            btnDeleteImage.Location = new Point(704, 604);
            btnDeleteImage.Margin = new Padding(3, 2, 3, 2);
            btnDeleteImage.Name = "btnDeleteImage";
            btnDeleteImage.Size = new Size(101, 52);
            btnDeleteImage.TabIndex = 28;
            btnDeleteImage.Text = "Izbriš izabranu sliku";
            btnDeleteImage.UseVisualStyleBackColor = true;
            btnDeleteImage.Click += btnDeleteImage_Click;
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new Point(810, 604);
            btnAddImage.Margin = new Padding(3, 2, 3, 2);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(106, 52);
            btnAddImage.TabIndex = 29;
            btnAddImage.Text = "Dodaj novu sliku";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 45);
            label1.Name = "label1";
            label1.Size = new Size(68, 30);
            label1.TabIndex = 30;
            label1.Text = "Pretraga po\r\n registraciji";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 122);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 31;
            label2.Text = "Marka";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 155);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 32;
            label3.Text = "Model";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 186);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 33;
            label4.Text = "Kilometraža";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(59, 220);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 34;
            label5.Text = "Vlasnik";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(60, 257);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 35;
            label6.Text = "Rudnik";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 368);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 36;
            label7.Text = "Registracija";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 397);
            label8.Name = "label8";
            label8.Size = new Size(76, 30);
            label8.TabIndex = 37;
            label8.Text = "Datum isteka\r\nregistracije";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tAGToolStripMenuItem, osnovneInformacijeToolStripMenuItem, tabelarniPrikazVozilaToolStripMenuItem, validnostRegistracijaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1222, 24);
            menuStrip1.TabIndex = 38;
            menuStrip1.Text = "menuStrip1";
            // 
            // tAGToolStripMenuItem
            // 
            tAGToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            tAGToolStripMenuItem.Name = "tAGToolStripMenuItem";
            tAGToolStripMenuItem.Size = new Size(40, 20);
            tAGToolStripMenuItem.Text = "TAG";
            tAGToolStripMenuItem.Click += tAGToolStripMenuItem_Click;
            // 
            // osnovneInformacijeToolStripMenuItem
            // 
            osnovneInformacijeToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            osnovneInformacijeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rudniciToolStripMenuItem, vlasniciToolStripMenuItem, serviseriToolStripMenuItem, tipServisaToolStripMenuItem1, kategorijeToolStripMenuItem, potkategorijeToolStripMenuItem });
            osnovneInformacijeToolStripMenuItem.Name = "osnovneInformacijeToolStripMenuItem";
            osnovneInformacijeToolStripMenuItem.Size = new Size(102, 20);
            osnovneInformacijeToolStripMenuItem.Text = "Osnovni podaci";
            // 
            // rudniciToolStripMenuItem
            // 
            rudniciToolStripMenuItem.Name = "rudniciToolStripMenuItem";
            rudniciToolStripMenuItem.Size = new Size(144, 22);
            rudniciToolStripMenuItem.Text = "Rudnici";
            rudniciToolStripMenuItem.Click += rudniciToolStripMenuItem_Click;
            // 
            // vlasniciToolStripMenuItem
            // 
            vlasniciToolStripMenuItem.Name = "vlasniciToolStripMenuItem";
            vlasniciToolStripMenuItem.Size = new Size(144, 22);
            vlasniciToolStripMenuItem.Text = "Vlasnici";
            vlasniciToolStripMenuItem.Click += vlasniciToolStripMenuItem_Click;
            // 
            // serviseriToolStripMenuItem
            // 
            serviseriToolStripMenuItem.Name = "serviseriToolStripMenuItem";
            serviseriToolStripMenuItem.Size = new Size(144, 22);
            serviseriToolStripMenuItem.Text = "Serviseri";
            serviseriToolStripMenuItem.Click += serviseriToolStripMenuItem_Click;
            // 
            // tipServisaToolStripMenuItem1
            // 
            tipServisaToolStripMenuItem1.Name = "tipServisaToolStripMenuItem1";
            tipServisaToolStripMenuItem1.Size = new Size(144, 22);
            tipServisaToolStripMenuItem1.Text = "Tip servisa";
            tipServisaToolStripMenuItem1.Click += tipServisaToolStripMenuItem1_Click;
            // 
            // kategorijeToolStripMenuItem
            // 
            kategorijeToolStripMenuItem.Name = "kategorijeToolStripMenuItem";
            kategorijeToolStripMenuItem.Size = new Size(144, 22);
            kategorijeToolStripMenuItem.Text = "Kategorije";
            kategorijeToolStripMenuItem.Click += kategorijeToolStripMenuItem_Click;
            // 
            // potkategorijeToolStripMenuItem
            // 
            potkategorijeToolStripMenuItem.Name = "potkategorijeToolStripMenuItem";
            potkategorijeToolStripMenuItem.Size = new Size(144, 22);
            potkategorijeToolStripMenuItem.Text = "Potkategorije";
            potkategorijeToolStripMenuItem.Click += potkategorijeToolStripMenuItem_Click;
            // 
            // tabelarniPrikazVozilaToolStripMenuItem
            // 
            tabelarniPrikazVozilaToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            tabelarniPrikazVozilaToolStripMenuItem.Name = "tabelarniPrikazVozilaToolStripMenuItem";
            tabelarniPrikazVozilaToolStripMenuItem.Size = new Size(133, 20);
            tabelarniPrikazVozilaToolStripMenuItem.Text = "Tabelarni prikaz vozila";
            tabelarniPrikazVozilaToolStripMenuItem.Click += tabelarniPrikazVozilaToolStripMenuItem_Click;
            // 
            // validnostRegistracijaToolStripMenuItem
            // 
            validnostRegistracijaToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            validnostRegistracijaToolStripMenuItem.Name = "validnostRegistracijaToolStripMenuItem";
            validnostRegistracijaToolStripMenuItem.Size = new Size(127, 20);
            validnostRegistracijaToolStripMenuItem.Text = "Validnost registracija";
            validnostRegistracijaToolStripMenuItem.Click += validnostRegistracijaToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbRegWas);
            groupBox1.Controls.Add(rbRegNo);
            groupBox1.Controls.Add(rbRegYes);
            groupBox1.Location = new Point(315, 480);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(179, 87);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Da li je vozilo registrovano";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // rbRegWas
            // 
            rbRegWas.AutoSize = true;
            rbRegWas.Location = new Point(6, 41);
            rbRegWas.Margin = new Padding(3, 2, 3, 2);
            rbRegWas.Name = "rbRegWas";
            rbRegWas.Size = new Size(57, 19);
            rbRegWas.TabIndex = 2;
            rbRegWas.TabStop = true;
            rbRegWas.Text = "Bilo je";
            rbRegWas.UseVisualStyleBackColor = true;
            // 
            // rbRegNo
            // 
            rbRegNo.AutoSize = true;
            rbRegNo.Location = new Point(6, 64);
            rbRegNo.Margin = new Padding(3, 2, 3, 2);
            rbRegNo.Name = "rbRegNo";
            rbRegNo.Size = new Size(40, 19);
            rbRegNo.TabIndex = 1;
            rbRegNo.TabStop = true;
            rbRegNo.Text = "Ne";
            rbRegNo.UseVisualStyleBackColor = true;
            // 
            // rbRegYes
            // 
            rbRegYes.AutoSize = true;
            rbRegYes.Location = new Point(6, 19);
            rbRegYes.Margin = new Padding(3, 2, 3, 2);
            rbRegYes.Name = "rbRegYes";
            rbRegYes.Size = new Size(39, 19);
            rbRegYes.TabIndex = 0;
            rbRegYes.TabStop = true;
            rbRegYes.Text = "Da";
            rbRegYes.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(378, 586);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(95, 40);
            btnClear.TabIndex = 40;
            btnClear.Text = "Očisti polja";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnShowImage
            // 
            btnShowImage.Location = new Point(278, 54);
            btnShowImage.Margin = new Padding(3, 2, 3, 2);
            btnShowImage.Name = "btnShowImage";
            btnShowImage.Size = new Size(106, 40);
            btnShowImage.TabIndex = 42;
            btnShowImage.Text = "Prikaži originalnu sliku";
            btnShowImage.UseVisualStyleBackColor = true;
            btnShowImage.Click += btnShowImage_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 332);
            label9.Name = "label9";
            label9.Size = new Size(77, 15);
            label9.TabIndex = 46;
            label9.Text = "Potkategorija";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(44, 295);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 45;
            label10.Text = "Kategorija";
            // 
            // cmbSubcategory
            // 
            cmbSubcategory.FormattingEnabled = true;
            cmbSubcategory.Location = new Point(121, 329);
            cmbSubcategory.Margin = new Padding(3, 2, 3, 2);
            cmbSubcategory.Name = "cmbSubcategory";
            cmbSubcategory.Size = new Size(133, 23);
            cmbSubcategory.TabIndex = 44;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(121, 293);
            cmbCategory.Margin = new Padding(3, 2, 3, 2);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(133, 23);
            cmbCategory.TabIndex = 43;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnUpdateSubcategory
            // 
            btnUpdateSubcategory.Image = (Image)resources.GetObject("btnUpdateSubcategory.Image");
            btnUpdateSubcategory.Location = new Point(278, 331);
            btnUpdateSubcategory.Margin = new Padding(3, 2, 3, 2);
            btnUpdateSubcategory.Name = "btnUpdateSubcategory";
            btnUpdateSubcategory.Size = new Size(26, 21);
            btnUpdateSubcategory.TabIndex = 48;
            btnUpdateSubcategory.UseVisualStyleBackColor = true;
            btnUpdateSubcategory.Click += btnUpdateSubcategory_Click;
            // 
            // btnUpdateCategory
            // 
            btnUpdateCategory.Image = (Image)resources.GetObject("btnUpdateCategory.Image");
            btnUpdateCategory.Location = new Point(278, 295);
            btnUpdateCategory.Margin = new Padding(3, 2, 3, 2);
            btnUpdateCategory.Name = "btnUpdateCategory";
            btnUpdateCategory.Size = new Size(26, 21);
            btnUpdateCategory.TabIndex = 47;
            btnUpdateCategory.UseVisualStyleBackColor = true;
            btnUpdateCategory.Click += btnUpdateCategory_Click;
            // 
            // btnUpdateState
            // 
            btnUpdateState.Image = (Image)resources.GetObject("btnUpdateState.Image");
            btnUpdateState.Location = new Point(278, 442);
            btnUpdateState.Margin = new Padding(3, 2, 3, 2);
            btnUpdateState.Name = "btnUpdateState";
            btnUpdateState.Size = new Size(26, 21);
            btnUpdateState.TabIndex = 51;
            btnUpdateState.UseVisualStyleBackColor = true;
            btnUpdateState.Click += btnUpdateState_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(27, 443);
            label11.Name = "label11";
            label11.Size = new Size(72, 15);
            label11.TabIndex = 50;
            label11.Text = "Stanje vozila";
            // 
            // cmbVehicleState
            // 
            cmbVehicleState.FormattingEnabled = true;
            cmbVehicleState.Location = new Point(121, 440);
            cmbVehicleState.Margin = new Padding(3, 2, 3, 2);
            cmbVehicleState.Name = "cmbVehicleState";
            cmbVehicleState.Size = new Size(133, 23);
            cmbVehicleState.TabIndex = 49;
            // 
            // btnShowAllRegistrationPlates
            // 
            btnShowAllRegistrationPlates.Location = new Point(172, 517);
            btnShowAllRegistrationPlates.Margin = new Padding(3, 2, 3, 2);
            btnShowAllRegistrationPlates.Name = "btnShowAllRegistrationPlates";
            btnShowAllRegistrationPlates.Size = new Size(132, 50);
            btnShowAllRegistrationPlates.TabIndex = 52;
            btnShowAllRegistrationPlates.Text = "Prikaži sve tablice vozila";
            btnShowAllRegistrationPlates.UseVisualStyleBackColor = true;
            btnShowAllRegistrationPlates.Click += btnShowAllRegistrationPlates_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 486);
            label12.Name = "label12";
            label12.Size = new Size(93, 15);
            label12.TabIndex = 55;
            label12.Text = "Dimenzije guma";
            // 
            // btnUpdateTireDimension
            // 
            btnUpdateTireDimension.Image = (Image)resources.GetObject("btnUpdateTireDimension.Image");
            btnUpdateTireDimension.Location = new Point(278, 480);
            btnUpdateTireDimension.Margin = new Padding(3, 2, 3, 2);
            btnUpdateTireDimension.Name = "btnUpdateTireDimension";
            btnUpdateTireDimension.Size = new Size(26, 21);
            btnUpdateTireDimension.TabIndex = 54;
            btnUpdateTireDimension.UseVisualStyleBackColor = true;
            btnUpdateTireDimension.Click += btnUpdateTireDimension_Click;
            // 
            // tbTireDimension
            // 
            tbTireDimension.Location = new Point(121, 481);
            tbTireDimension.Margin = new Padding(3, 2, 3, 2);
            tbTireDimension.Name = "tbTireDimension";
            tbTireDimension.Size = new Size(133, 23);
            tbTireDimension.TabIndex = 53;
            // 
            // Vehicle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1222, 736);
            Controls.Add(label12);
            Controls.Add(btnUpdateTireDimension);
            Controls.Add(tbTireDimension);
            Controls.Add(btnShowAllRegistrationPlates);
            Controls.Add(btnUpdateState);
            Controls.Add(label11);
            Controls.Add(cmbVehicleState);
            Controls.Add(btnUpdateSubcategory);
            Controls.Add(btnUpdateCategory);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(cmbSubcategory);
            Controls.Add(cmbCategory);
            Controls.Add(btnShowImage);
            Controls.Add(btnClear);
            Controls.Add(groupBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddImage);
            Controls.Add(btnDeleteImage);
            Controls.Add(btnNext);
            Controls.Add(btnBefore);
            Controls.Add(pictureBox1);
            Controls.Add(lbNumberOfRequests);
            Controls.Add(tbFind);
            Controls.Add(btnServiceVehicle);
            Controls.Add(btnRequest);
            Controls.Add(btnShowCertifivate);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnNew);
            Controls.Add(dtpDate);
            Controls.Add(btnUpdateDate);
            Controls.Add(btnUpdateReg);
            Controls.Add(btnUpdateMine);
            Controls.Add(btnUpdateOwner);
            Controls.Add(btnUpdateKm);
            Controls.Add(btnUpdateModel);
            Controls.Add(btnUpdateBrand);
            Controls.Add(cmbMine);
            Controls.Add(cmbOwner);
            Controls.Add(tbReg);
            Controls.Add(tbKm);
            Controls.Add(tbModel);
            Controls.Add(tbBrand);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Vehicle";
            Text = "Vozila";
            FormClosing += Vehicle_FormClosing;
            Load += Vehicle_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbBrand;
        private TextBox tbModel;
        private TextBox tbKm;
        private TextBox tbReg;
        private ComboBox cmbOwner;
        private ComboBox cmbMine;
        private Button btnUpdateBrand;
        private Button btnUpdateModel;
        private Button btnUpdateKm;
        private Button btnUpdateOwner;
        private Button btnUpdateMine;
        private Button btnUpdateReg;
        private Button btnUpdateDate;
        private DateTimePicker dtpDate;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnShowCertifivate;
        private Button btnRequest;
        private Button btnServiceVehicle;
        private TextBox tbFind;
        private Label lbNumberOfRequests;
        private PictureBox pictureBox1;
        private Button btnBefore;
        private Button btnNext;
        private Button btnDeleteImage;
        private Button btnAddImage;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tAGToolStripMenuItem;
        private ToolStripMenuItem osnovneInformacijeToolStripMenuItem;
        private ToolStripMenuItem rudniciToolStripMenuItem;
        private ToolStripMenuItem vlasniciToolStripMenuItem;
        private ToolStripMenuItem serviseriToolStripMenuItem;
        private ToolStripMenuItem tipServisaToolStripMenuItem1;
        private GroupBox groupBox1;
        private RadioButton rbRegNo;
        private RadioButton rbRegYes;
        private RadioButton rbRegWas;
        private Button btnClear;
        private BindingSource bindingSource1;
        private ToolStripMenuItem tabelarniPrikazVozilaToolStripMenuItem;
        private ToolStripMenuItem validnostRegistracijaToolStripMenuItem;
        private Button btnShowImage;
        private Label label9;
        private Label label10;
        private ComboBox cmbSubcategory;
        private ComboBox cmbCategory;
        private Button btnUpdateSubcategory;
        private Button btnUpdateCategory;
        private ToolStripMenuItem kategorijeToolStripMenuItem;
        private ToolStripMenuItem potkategorijeToolStripMenuItem;
        private Button btnUpdateState;
        private Label label11;
        private ComboBox cmbVehicleState;
        private Button btnShowAllRegistrationPlates;
        private Label label12;
        private Button btnUpdateTireDimension;
        private TextBox tbTireDimension;
    }
}