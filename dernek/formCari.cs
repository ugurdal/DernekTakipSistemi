using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
            //splitContainer3.SplitterDistance = 700;
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
           if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)44)
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
                tbBakiye.Text = "0";
                tbBorc.Text = "0";
                tbAlacak.Text = "0";
                Temizle();
                gbCari.Enabled = true;
                musteriID = int.Parse(dgwMusteriCari.Rows[e.RowIndex].Cells[1].Value.ToString());
                labelKod.Text = musteriID.ToString();
                CariHareketDoldur(musteriID);
            }

        }

        private void CariHareketDoldur(int mstID)
        {
            dgwCari.DataSource = null;
            if (dgwCari.Rows.Count > 0)
                dgwCari.Rows.Clear();

            _baglanti.ac();
            DataTable dtCari = new DataTable();
            new SqlDataAdapter(string.Format(("Select * from dbo.cariIslemler_vw Where [MüşteriID]={0}"), mstID), _baglanti.cnn).Fill(dtCari);

            if (dtCari.Rows.Count == 0)
                return;

            dgwCari.DataSource = dtCari;
            DataGridFormatla(dgwCari);
            dgwCari.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dgwCari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _baglanti.kapat();
            BakiyeOku(mstID);
        }

        private void DataGridFormatla(DataGridView dgw)
        {
            foreach (DataGridViewRow dr in dgw.Rows)
            {
                if (dr.Cells["cariBA"].Value.ToString() == "0")
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
            foreach (DataGridViewColumn cl in dgw.Columns)
            {
                if (cl.Name == "İşlem Tutarı" || cl.Name == "Bakiye")
                {
                    cl.DefaultCellStyle.Format = "N2";
                    cl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    cl.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                }
                
            }

        }


        private void BakiyeOku(int mstID)
        {
            _baglanti.ac();
            DataTable dtCari = new DataTable();
            new SqlDataAdapter(string.Format(("Select * from dbo.cariBakiye_vw Where cariMusteri={0}"), mstID), _baglanti.cnn).Fill(dtCari);

            if (dtCari.Rows.Count == 0)
                return;

            tbBakiye.Text = _baglanti.ParaFormat(dtCari.Rows[0]["bakiye"].ToString());
            tbAlacak.Text = _baglanti.ParaFormat(dtCari.Rows[0]["alacak"].ToString());
            tbBorc.Text = _baglanti.ParaFormat(dtCari.Rows[0]["borc"].ToString());
            _baglanti.kapat();
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

            if(! _baglanti.isNumeric(textBoxTutar.Text))
                return;

            Kaydet();
        }

        private void Kaydet()
        {
            _baglanti.ac();
            
            try
            {
                var kaydet = new SqlCommand("dbo.cariKaydet", _baglanti.cnn);
                kaydet.CommandType = CommandType.StoredProcedure;
                SqlParameter id = kaydet.Parameters.Add("@cID", SqlDbType.Int);
                id.Direction = ParameterDirection.ReturnValue;
                kaydet.Parameters.AddWithValue("@cID", labelID.Text);
                kaydet.Parameters.AddWithValue("@no", textBoxEvrakNo.Text);
                kaydet.Parameters.AddWithValue("@tip", comboBoxIslemTip.SelectedValue);
                kaydet.Parameters.AddWithValue("@musteri", labelKod.Text);
                kaydet.Parameters.AddWithValue("@cba", comboboxBA.SelectedIndex);
                double tutar = double.Parse(textBoxTutar.Text.Replace("-",""));
                kaydet.Parameters.AddWithValue("@tutar", comboboxBA.SelectedIndex == 0 ? tutar : -1*tutar);
                kaydet.Parameters.AddWithValue("@tarih", islemTarihi.SelectionStart.ToShortDateString());
                kaydet.Parameters.AddWithValue("@not", textBoxNot.Text);
                kaydet.Parameters.AddWithValue("@kisi", 1);

                kaydet.CommandTimeout = 3000;
                kaydet.ExecuteNonQuery();
                labelID.Text = id.Value.ToString();
                MessageBox.Show("Kaydedildi !", "Cari", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BakiyeOku(int.Parse(labelKod.Text));
                CariHareketDoldur(int.Parse(labelKod.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
          
            _baglanti.kapat();
        }

        private void dgwCari_Sorted(object sender, EventArgs e)
        {
            if (dgwCari.Rows.Count > 0)
                DataGridFormatla(dgwCari);
        }

        private void dgwCari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                double tutar = double.Parse(dgwCari.Rows[e.RowIndex].Cells["İşlem Tutarı"].Value.ToString());
                labelID.Text = dgwCari.Rows[e.RowIndex].Cells["İşlem ID"].Value.ToString();
                textBoxEvrakNo.Text = dgwCari.Rows[e.RowIndex].Cells["Evrak No"].Value.ToString();
                textBoxNot.Text = dgwCari.Rows[e.RowIndex].Cells["Notlar"].Value.ToString();
                if (tutar < 0)
                {
                    tutar = -1 * tutar;
                }
                textBoxTutar.Text = _baglanti.ParaFormat(tutar.ToString());
                comboboxBA.SelectedIndex = int.Parse(dgwCari.Rows[e.RowIndex].Cells["cariBA"].Value.ToString());
                comboBoxIslemTip.SelectedValue = dgwCari.Rows[e.RowIndex].Cells["TipId"].Value.ToString();
                islemTarihi.SetDate(Convert.ToDateTime(dgwCari.Rows[e.RowIndex].Cells["İşlem Tarihi"].Value));
            }
        }

        private void comboBoxIslemTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (labelID.Text == "0")
            {
                if (comboBoxIslemTip.SelectedIndex > 3)
                {
                    comboboxBA.SelectedIndex = 1;
                }
                else
                {
                    comboboxBA.SelectedIndex = 0;
                }    
            }
        }

        private void formCari_FormClosing(object sender, FormClosingEventArgs e)
        {
            _baglanti.programKapat();
        }
        
    }
}
