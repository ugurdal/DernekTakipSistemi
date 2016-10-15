using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dernek
{
    public partial class formKullanici : Form
    {
        baglanti _baglanti = new baglanti();

        public formKullanici()
        {
            InitializeComponent();
        }

        private void formKullanici_Load(object sender, EventArgs e)
        {
            _baglanti.oleDbConnection = conn.bag;

            if (!_baglanti.basla())
                Environment.Exit(1);

            Kullanıcılar();
            gbParola.Visible = false;
        }

        private void Kullanıcılar()
        {
            if (dgwKullanici.Rows.Count>0)
                dgwKullanici.Rows.Clear();

            DataTable dt = new DataTable();
            new OleDbDataAdapter("Select * From kullanici ORDER BY kullaniciAdSoyad", _baglanti.oleConn).Fill(dt);

            int i = new int();
            dgwKullanici.Rows.Add(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                dgwKullanici.Rows[i].Cells["id"].Value = dr["kullaniciID"];
                dgwKullanici.Rows[i].Cells["ad"].Value = dr["kullaniciAdSoyad"];
                dgwKullanici.Rows[i].Cells["kullanici"].Value = dr["kullaniciAdi"];
                dgwKullanici.Rows[i].Cells["parola"].Value = dr["kullaniciParola"];
                i++;
            }
            gbParola.Visible = false;
        }

        private void dgwKullanici_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgwKullanici.Rows[e.RowIndex].Cells["id"].Value != null)
            {
                labelID.Text = dgwKullanici.Rows[e.RowIndex].Cells["id"].Value.ToString();
                tbAdSoyad.Text = dgwKullanici.Rows[e.RowIndex].Cells["ad"].Value.ToString();
                tbKullanici.Text = dgwKullanici.Rows[e.RowIndex].Cells["kullanici"].Value.ToString();
                tbParola.Text = dgwKullanici.Rows[e.RowIndex].Cells["parola"].Value.ToString();
                labelParolaKontrol.Text = dgwKullanici.Rows[e.RowIndex].Cells["parola"].Value.ToString();
                gbParola.Visible = false;
                tbYeniParola.Text = "";
                tbYeniParolaTekrar.Text = "";    
            }
        }

        private void Temizle()
        {
            labelID.Text = "0";
            tbAdSoyad.Text = "";
            tbKullanici.Text = "";
            tbParola.Text = "";
            tbYeniParola.Text = "";
            tbYeniParolaTekrar.Text = "";
            labelParola.Text = "";
            gbParola.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void tsYeni_Click(object sender, EventArgs e)
        {
            Temizle();
            gbParola.Visible = true;
            labelParola.Visible = false;
            tbParola.Visible = false;
        }

        private void tsSil_Click(object sender, EventArgs e)
        {
            //hareket kontrolleri


            //sil
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbAdSoyad.Text))
            {
                MessageBox.Show("Kullanıcı ad ve soyadı girin ! ", "", MessageBoxButtons.OK,
                     MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbKullanici.Text))
            {
                MessageBox.Show("Kullanıcı adı ! ", "", MessageBoxButtons.OK,
                     MessageBoxIcon.Warning);
                return;
            }

            if (gbParola.Visible && labelID.Text != "0")
            {
                if (string.IsNullOrWhiteSpace(tbYeniParola.Text) || string.IsNullOrWhiteSpace(tbYeniParolaTekrar.Text))
                {
                    tbYeniParola.BackColor = Color.IndianRed;
                    tbYeniParolaTekrar.BackColor = Color.IndianRed;
                    MessageBox.Show("Yeni parolayı kontrol edin ! ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                tbYeniParola.BackColor = Color.White;
                tbYeniParolaTekrar.BackColor = Color.White;

                if (tbParola.Text != labelParolaKontrol.Text)
                {
                    tbParola.BackColor = Color.IndianRed;
                    MessageBox.Show("Mevcut parola doğru değil, lütfen doğru parolayı girin ! ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                tbParola.BackColor = Color.White;

                if (tbYeniParola.Text != tbYeniParolaTekrar.Text)
                {
                    tbYeniParola.BackColor = Color.IndianRed;
                    tbYeniParolaTekrar.BackColor = Color.IndianRed;
                    MessageBox.Show("Yeni parolalar eşleşmiyor, kontrol edin ! ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                tbYeniParola.BackColor = Color.White;
                tbYeniParolaTekrar.BackColor = Color.White;

                var cmd = new OleDbCommand();
                cmd.Connection = _baglanti.oleConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " UPDATE kullanici " +
                                        " SET kullaniciAdSoyad='" + tbAdSoyad.Text + "'" +
                                            ", kullaniciAdi='" + tbKullanici.Text + "'" +
                                            ", kullaniciParola='" + tbYeniParola.Text + "'" +
                                        " WHERE kullaniciID=" + labelID.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Parola güncellendi !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if ((gbParola.Visible == false && labelID.Text != "0"))
            {
                var cmd = new OleDbCommand();
                cmd.Connection = _baglanti.oleConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " UPDATE kullanici " +
                                  " SET kullaniciAdSoyad='" + tbAdSoyad.Text + "'" +
                                  ", kullaniciAdi='" + tbKullanici.Text + "'" +
                                  " WHERE kullaniciID=" + labelID.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Güncellendi !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (gbParola.Visible && labelID.Text == "0")
            {
                if (string.IsNullOrWhiteSpace(tbYeniParola.Text) || string.IsNullOrWhiteSpace(tbYeniParolaTekrar.Text))
                {
                    tbYeniParola.BackColor = Color.IndianRed;
                    tbYeniParolaTekrar.BackColor = Color.IndianRed;
                    MessageBox.Show("Parolayı kontrol edin ! ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                tbYeniParola.BackColor = Color.White;
                tbYeniParolaTekrar.BackColor = Color.White;

                if (tbYeniParola.Text != tbYeniParolaTekrar.Text)
                {
                    tbYeniParola.BackColor = Color.IndianRed;
                    tbYeniParolaTekrar.BackColor = Color.IndianRed;
                    MessageBox.Show("Parolalar eşleşmiyor, kontrol edin ! ", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                tbYeniParola.BackColor = Color.White;
                tbYeniParolaTekrar.BackColor = Color.White;

                var IDBul = new OleDbCommand("Select @@Identity", _baglanti.oleConn);
                IDBul.CommandType = CommandType.Text;
                IDBul.CommandTimeout = 3000;

                var cmd = new OleDbCommand();
                cmd.Connection = _baglanti.oleConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 3000;
                cmd.CommandText = " INSERT INTO kullanici (kullaniciAdSoyad, kullaniciAdi ,kullaniciParola )" +
                                        " SELECT '" + tbAdSoyad.Text + "'" +
                                            ", '" + tbKullanici.Text + "'" +
                                            ", '" + tbYeniParola.Text + "'" ;
                cmd.ExecuteNonQuery();
                labelID.Text = IDBul.ExecuteScalar().ToString();
                MessageBox.Show("Kullanıcı eklendi !", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Kullanıcılar();
            //kaydet kontroller
        }

        private void tsParolaDegistir_Click(object sender, EventArgs e)
        {
            if (labelID.Text == "0")
                return;
            tbParola.Text = "";
            tbYeniParola.Text = "";
            tbYeniParolaTekrar.Text = "";
            gbParola.Visible = true;
            tbParola.Focus();

        }

        private void tbParola_Validated(object sender, EventArgs e)
        {
            //if (tbParola.Text != labelParolaKontrol.Text)
            //{
            //    tbParola.BackColor = Color.IndianRed;
            //    MessageBox.Show("Mevcut parola doğru değil, lütfen doğru parolayı giriniz ! ", "", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    tbParola.Focus();
            //    return;
            //}
            //tbParola.BackColor = Color.White;
        }
    }
}
