using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dernek
{
    public partial class formCari : Form
    {
        baglanti _baglanti = new baglanti();
        private int musteriID;
        public formCari()
        {
            InitializeComponent();
        }

        private void tsAdAra_Click(object sender, EventArgs e)
        {
            tsVNAra.Checked = false;
        }

        private void tsVNAra_Click(object sender, EventArgs e)
        {
            tsAdAra.Checked = false;
        }

        private void formCari_Load(object sender, EventArgs e)
        {
            _baglanti.database = Properties.Settings.Default.database;
            _baglanti.user = Properties.Settings.Default.user;
            _baglanti.password = Properties.Settings.Default.password;
            _baglanti.datasource = Properties.Settings.Default.dataSource;

            if (!_baglanti.basla())
                Environment.Exit(1);

            tsAdAra.Checked = true;
            comboboxBA.SelectedIndex = 0;
            splitContainer3.SplitterDistance = 620;
            islemTarihi.MaxDate = DateTime.Today;
            ArayuzDoldur();
            Temizle();
            gbCari.Enabled = false;
        }

        private void tsTumMusteriler_Click(object sender, EventArgs e)
        {
            MusteriAra(true, true);
        }

        private void MusteriAra(bool ad, bool tum)
        {
            _baglanti.ac();
            DataTable dtMst = new DataTable();

            if (tum)
            {
                new SqlDataAdapter(string.Format(("Select * from dbo.musteri Order By mstAd ")), _baglanti.cnn).Fill(dtMst);
            }
            else
            {
                new SqlDataAdapter(string.Format(("Select * from dbo.musteri Where {0} like '" + tsCariAra.Text + "%' Order By mstAd "), ad == true ? "mstAd" : "mstVN"), _baglanti.cnn).Fill(dtMst);
            }

            dgwMusteriCari.DataSource = null;
            dgwMusteriCari.Rows.Clear();

            if (dtMst.Rows.Count == 0)
                return;

            dgwMusteriCari.Rows.Add(dtMst.Rows.Count);
            int i = new int();
            foreach (DataRow dr in dtMst.Rows)
            {
                dgwMusteriCari.Rows[i].Cells["mstId"].Value = dr["mstID"];
                dgwMusteriCari.Rows[i].Cells["mstKod"].Value = dr["mstKod"];
                dgwMusteriCari.Rows[i].Cells["mstAd"].Value = dr["mstAd"];
                i++;
            }

            dgwMusteriCari.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgwMusteriCari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _baglanti.kapat();
        }

        private void tsCariAra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MusteriAra(tsAdAra.Checked ? true : false, false);
            }
            if (dgwMusteriCari.Rows.Count == 0)
                labelKod.Text = "0";
        }

        private void newToolStripButton1_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            labelID.Text = "0";
            textBoxEvrakNo.Text = "";
            textBoxNot.Text = "";
            textBoxTutar.Text = "";
            comboboxBA.SelectedIndex = 0;
            comboBoxIslemTip.SelectedIndex = 0;
            islemTarihi.SetDate(DateTime.Today);
        }

        private void textBoxTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxTutar_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTutar.Text))
            {
                textBoxTutar.Text = _baglanti.ParaFormat(textBoxTutar.Text);
            }
        }

        private void dgwMusteriCari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                gbCari.Enabled = true;
                musteriID = int.Parse(dgwMusteriCari.Rows[e.RowIndex].Cells[1].Value.ToString());
                labelKod.Text = musteriID.ToString();
                CariHareketDoldur(musteriID);
            }

        }

        private void CariHareketDoldur(int mstID)
        {
            
        }
        private void ArayuzDoldur()
        {
            _baglanti.ac();
            DataTable dtIslemTip = new DataTable();
            new SqlDataAdapter(("Select * from dbo.cariIslemTip Order By islemSira"), _baglanti.cnn).Fill(dtIslemTip);
            comboBoxIslemTip.DisplayMember = "islemAd";
            comboBoxIslemTip.ValueMember = "islemId";
            comboBoxIslemTip.DataSource = dtIslemTip;

            _baglanti.kapat();
        }

        private void tsKaydet_Click(object sender, EventArgs e)
        {
            KaydetKontroller();
        }

        private void KaydetKontroller()
        {
            if (labelKod.Text == "0")
            {
                MessageBox.Show("Müşteri seçiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            Kaydet();
        }

        private void Kaydet()
        {
            
        }

    }
}
