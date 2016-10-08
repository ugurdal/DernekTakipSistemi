using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dernek
{
    public partial class formGiris : Form
    {
        baglanti _baglanti = new baglanti();
        OleDbConnection cnn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                                    @"Data Source=" + Application.StartupPath + "\\dernek.mdb; " +
                                                    @"Jet OLEDB:Database Password=grdl;Persist Security Info=true");

        private string oledbCon = @"Provider=Microsoft.Jet.OLEDB.4.0; " +
                                  @"Data Source=" + Application.StartupPath + "\\dernek.mdb; " +
                                  @"Jet OLEDB:Database Password=grdl;Persist Security Info=true";

        public formGiris()
        {
            InitializeComponent();
        }

        private void formGiris_Load(object sender, EventArgs e)
        {
            _baglanti.database = Properties.Settings.Default.database;
            _baglanti.user = Properties.Settings.Default.user;
            _baglanti.password = Properties.Settings.Default.password;
            _baglanti.datasource = Properties.Settings.Default.dataSource;
            _baglanti.oleDbConnection = conn.bag;

            if (!_baglanti.basla())
                Environment.Exit(1);
            textBoxKullanici.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris();
        }

        private void formGiris_KeyDown(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
            {
                Giris();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                _baglanti.programKapat();
            }

        }

        private void Giris()
        {
            if (string.IsNullOrWhiteSpace(textBoxKullanici.Text) || string.IsNullOrWhiteSpace(textBoxSifre.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre eksiksiz girilmeli", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dt = new DataTable();
            //new SqlDataAdapter(string.Format("Select * From dbo.kullanici Where kullaniciAdi='{0}' And Parola='{1}'", textBoxKullanici.Text, textBoxSifre.Text), _baglanti.cnn).Fill(dt);
            new OleDbDataAdapter(string.Format("Select * From kullanici Where kullaniciAdi='{0}' And kullaniciParola='{1}'", textBoxKullanici.Text, textBoxSifre.Text), _baglanti.oleConn).Fill(dt);
            
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Kullanıcı adı veya parola hatalı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string _kullanici = dt.Rows[0]["kullaniciAdSoyad"].ToString();

            Properties.Settings.Default.oleDbConn = oledbCon;
            Properties.Settings.Default.Save();

            
            var frm = new formMenu();
            frm.basla(_baglanti.datasource, _baglanti.database, _kullanici);
            frm.ShowDialog();
            this.Close();
        }


    }
}
