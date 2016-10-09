namespace dernek
{
    partial class formKullanici
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
            this.dgwKullanici = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kullanici = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsYeni = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSil = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsParolaDegistir = new System.Windows.Forms.ToolStripButton();
            this.tbAdSoyad = new System.Windows.Forms.TextBox();
            this.tbKullanici = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelParola = new System.Windows.Forms.Label();
            this.tbParola = new System.Windows.Forms.TextBox();
            this.labelParolaYeni = new System.Windows.Forms.Label();
            this.tbYeniParola = new System.Windows.Forms.TextBox();
            this.tbYeniParolaTekrar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbParola = new System.Windows.Forms.GroupBox();
            this.labelParolaKontrol = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwKullanici)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbParola.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwKullanici
            // 
            this.dgwKullanici.AllowUserToAddRows = false;
            this.dgwKullanici.AllowUserToDeleteRows = false;
            this.dgwKullanici.AllowUserToOrderColumns = true;
            this.dgwKullanici.AllowUserToResizeColumns = false;
            this.dgwKullanici.AllowUserToResizeRows = false;
            this.dgwKullanici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwKullanici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ad,
            this.kullanici,
            this.parola});
            this.dgwKullanici.Location = new System.Drawing.Point(12, 28);
            this.dgwKullanici.Name = "dgwKullanici";
            this.dgwKullanici.ReadOnly = true;
            this.dgwKullanici.Size = new System.Drawing.Size(209, 285);
            this.dgwKullanici.TabIndex = 0;
            this.dgwKullanici.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwKullanici_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // ad
            // 
            this.ad.HeaderText = "Kullanıcı Adı";
            this.ad.Name = "ad";
            this.ad.ReadOnly = true;
            this.ad.Width = 150;
            // 
            // kullanici
            // 
            this.kullanici.HeaderText = "kullanici";
            this.kullanici.Name = "kullanici";
            this.kullanici.ReadOnly = true;
            this.kullanici.Visible = false;
            // 
            // parola
            // 
            this.parola.HeaderText = "parola";
            this.parola.Name = "parola";
            this.parola.ReadOnly = true;
            this.parola.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsYeni,
            this.toolStripSeparator2,
            this.tsSil,
            this.toolStripSeparator1,
            this.tsParolaDegistir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(572, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsYeni
            // 
            this.tsYeni.Image = global::dernek.Properties.Resources.AddTableHS;
            this.tsYeni.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsYeni.Name = "tsYeni";
            this.tsYeni.Size = new System.Drawing.Size(121, 22);
            this.tsYeni.Text = "Yeni Kullanıcı Ekle";
            this.tsYeni.Click += new System.EventHandler(this.tsYeni_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsSil
            // 
            this.tsSil.Image = global::dernek.Properties.Resources.DeleteHS;
            this.tsSil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSil.Name = "tsSil";
            this.tsSil.Size = new System.Drawing.Size(39, 22);
            this.tsSil.Text = "Sil";
            this.tsSil.Click += new System.EventHandler(this.tsSil_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsParolaDegistir
            // 
            this.tsParolaDegistir.Image = global::dernek.Properties.Resources.key;
            this.tsParolaDegistir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsParolaDegistir.Name = "tsParolaDegistir";
            this.tsParolaDegistir.Size = new System.Drawing.Size(103, 22);
            this.tsParolaDegistir.Text = "Parola Değiştir";
            this.tsParolaDegistir.Click += new System.EventHandler(this.tsParolaDegistir_Click);
            // 
            // tbAdSoyad
            // 
            this.tbAdSoyad.Location = new System.Drawing.Point(11, 36);
            this.tbAdSoyad.Name = "tbAdSoyad";
            this.tbAdSoyad.Size = new System.Drawing.Size(274, 22);
            this.tbAdSoyad.TabIndex = 2;
            // 
            // tbKullanici
            // 
            this.tbKullanici.Location = new System.Drawing.Point(11, 88);
            this.tbKullanici.Name = "tbKullanici";
            this.tbKullanici.Size = new System.Drawing.Size(152, 22);
            this.tbKullanici.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ad - Soyad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kullanıcı Adı";
            // 
            // labelParola
            // 
            this.labelParola.AutoSize = true;
            this.labelParola.Location = new System.Drawing.Point(5, 10);
            this.labelParola.Name = "labelParola";
            this.labelParola.Size = new System.Drawing.Size(83, 14);
            this.labelParola.TabIndex = 9;
            this.labelParola.Text = "Mevcut Parola";
            // 
            // tbParola
            // 
            this.tbParola.Location = new System.Drawing.Point(8, 31);
            this.tbParola.Name = "tbParola";
            this.tbParola.PasswordChar = '*';
            this.tbParola.Size = new System.Drawing.Size(152, 22);
            this.tbParola.TabIndex = 8;
            this.tbParola.Validated += new System.EventHandler(this.tbParola_Validated);
            // 
            // labelParolaYeni
            // 
            this.labelParolaYeni.AutoSize = true;
            this.labelParolaYeni.Location = new System.Drawing.Point(5, 61);
            this.labelParolaYeni.Name = "labelParolaYeni";
            this.labelParolaYeni.Size = new System.Drawing.Size(67, 14);
            this.labelParolaYeni.TabIndex = 11;
            this.labelParolaYeni.Text = "Yeni Parola";
            // 
            // tbYeniParola
            // 
            this.tbYeniParola.Location = new System.Drawing.Point(8, 82);
            this.tbYeniParola.Name = "tbYeniParola";
            this.tbYeniParola.PasswordChar = '*';
            this.tbYeniParola.Size = new System.Drawing.Size(152, 22);
            this.tbYeniParola.TabIndex = 10;
            // 
            // tbYeniParolaTekrar
            // 
            this.tbYeniParolaTekrar.Location = new System.Drawing.Point(166, 82);
            this.tbYeniParolaTekrar.Name = "tbYeniParolaTekrar";
            this.tbYeniParolaTekrar.PasswordChar = '*';
            this.tbYeniParolaTekrar.Size = new System.Drawing.Size(150, 22);
            this.tbYeniParolaTekrar.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 35);
            this.button1.TabIndex = 13;
            this.button1.Text = "Vazgeç";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(404, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 35);
            this.button2.TabIndex = 14;
            this.button2.Text = "Kaydet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelID.Location = new System.Drawing.Point(291, 40);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(15, 14);
            this.labelID.TabIndex = 15;
            this.labelID.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbKullanici);
            this.groupBox1.Controls.Add(this.labelID);
            this.groupBox1.Controls.Add(this.tbAdSoyad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(236, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 121);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // gbParola
            // 
            this.gbParola.Controls.Add(this.labelParolaKontrol);
            this.gbParola.Controls.Add(this.tbYeniParolaTekrar);
            this.gbParola.Controls.Add(this.tbParola);
            this.gbParola.Controls.Add(this.labelParola);
            this.gbParola.Controls.Add(this.tbYeniParola);
            this.gbParola.Controls.Add(this.labelParolaYeni);
            this.gbParola.Location = new System.Drawing.Point(236, 151);
            this.gbParola.Name = "gbParola";
            this.gbParola.Size = new System.Drawing.Size(320, 115);
            this.gbParola.TabIndex = 17;
            this.gbParola.TabStop = false;
            // 
            // labelParolaKontrol
            // 
            this.labelParolaKontrol.AutoSize = true;
            this.labelParolaKontrol.Location = new System.Drawing.Point(163, 34);
            this.labelParolaKontrol.Name = "labelParolaKontrol";
            this.labelParolaKontrol.Size = new System.Drawing.Size(39, 14);
            this.labelParolaKontrol.TabIndex = 13;
            this.labelParolaKontrol.Text = "Parola";
            this.labelParolaKontrol.Visible = false;
            // 
            // formKullanici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 325);
            this.Controls.Add(this.gbParola);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgwKullanici);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formKullanici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Tanımları";
            this.Load += new System.EventHandler(this.formKullanici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwKullanici)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbParola.ResumeLayout(false);
            this.gbParola.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwKullanici;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox tbAdSoyad;
        private System.Windows.Forms.TextBox tbKullanici;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelParola;
        private System.Windows.Forms.TextBox tbParola;
        private System.Windows.Forms.Label labelParolaYeni;
        private System.Windows.Forms.TextBox tbYeniParola;
        private System.Windows.Forms.TextBox tbYeniParolaTekrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullanici;
        private System.Windows.Forms.DataGridViewTextBoxColumn parola;
        private System.Windows.Forms.ToolStripButton tsYeni;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsSil;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsParolaDegistir;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbParola;
        private System.Windows.Forms.Label labelParolaKontrol;
    }
}