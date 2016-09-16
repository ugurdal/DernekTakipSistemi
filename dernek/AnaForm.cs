using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace dernek
{
    public partial class AnaForm : Form
    {
        baglanti _baglanti = new baglanti();
        List<int> ytkSil = new List<int>();

        public AnaForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _baglanti.database = Properties.Settings.Default.database;
            _baglanti.user = Properties.Settings.Default.user;
            _baglanti.password = Properties.Settings.Default.password;
            _baglanti.datasource = Properties.Settings.Default.dataSource;

            if (!_baglanti.basla())
                Environment.Exit(1);

            comboBoxMusteriTip.SelectedIndex = 0;
            ArayuzDoldur();
            comboBoxIl.SelectedValue = 34;
            Temizle();
            tsAdArama.Checked = true;

        }

        private void tsAdArama_Click(object sender, EventArgs e)
        {
            tsVNArama.Checked = false;
        }

        private void tsVNArama_Click(object sender, EventArgs e)
        {
            tsAdArama.Checked = false;
        }

        private void comboBoxMusteriTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMusteriTip.SelectedIndex == 1)
            {
                //labelKurulus.Visible = false;
                labelGenelKurul.Visible = false;
                dtpGenelKurul.Visible = false;
                //dtpKurulus.Visible = false;
            }
            else
            {
                //labelKurulus.Visible = true;
                labelGenelKurul.Visible = true;
                dtpGenelKurul.Visible = true;
                //dtpKurulus.Visible = true;
            }
        }

        private void Temizle()
        {
            labelID.Text = "0";
            textBoxKod.Text = "";
            textBoxAd.Text = "";
            comboBoxMusteriTip.SelectedIndex = 0;
            textBoxVN.Text = "";
            textBoxVD.Text = "";
            textBoxAdres.Text = "";
            textBoxNot.Text = "";
            mTextBoxTel1.Text = "";
            mTextBoxTel2.Text = "";
            mTextBoxGsm.Text = "";
            mTextBoxTelFaks.Text = "";
            textBoxEPosta.Text = "";
            comboBoxIl.SelectedValue = 34;
            textBoxIlce.Text = "";
            dtpGenelKurul.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpKurulus.Value = new DateTime(DateTime.Now.Year, 1, 1);
            textBoxTCNo.Text = "";
            textBoxKullanici.Text = "";
            textBoxSifre.Text = "";

            dgwYetkili.Rows.Clear();
            dgwYetkili.DataSource = null;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void ArayuzDoldur()
        {
            _baglanti.ac();
            DataTable dtIl = new DataTable();


            new SqlDataAdapter(("Select * from dbo.ilTanimlari Order By ilAdi"), _baglanti.cnn).Fill(dtIl);
            comboBoxIl.DisplayMember = "ilAdi";
            comboBoxIl.ValueMember = "ilPlaka";
            comboBoxIl.DataSource = dtIl;

            _baglanti.kapat();
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
                new SqlDataAdapter(string.Format(("Select * from dbo.musteri Where {0} like '" + tsTextMusteriAra.Text + "%' Order By mstAd "), ad == true ? "mstAd" : "mstVN"), _baglanti.cnn).Fill(dtMst);
            }

            dgwMusteri.DataSource = null;
            dgwMusteri.Rows.Clear();

            if (dtMst.Rows.Count == 0)
                return;

            dgwMusteri.Rows.Add(dtMst.Rows.Count);
            int i = new int();
            foreach (DataRow dr in dtMst.Rows)
            {
                dgwMusteri.Rows[i].Cells["mstId"].Value = dr["mstID"];
                dgwMusteri.Rows[i].Cells["mstKod"].Value = dr["mstKod"];
                dgwMusteri.Rows[i].Cells["mstAd"].Value = dr["mstAd"];
                i++;
            }

            dgwMusteri.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgwMusteri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _baglanti.kapat();
        }

        private void MusteriOku(string mstID)
        {
            _baglanti.ac();

            DataTable dt = new DataTable();
            DataTable dtYetkili = new DataTable();
            new SqlDataAdapter(string.Format(("Select * from dbo.musteri Where mstID = {0}"), mstID), _baglanti.cnn).Fill(dt);
            new SqlDataAdapter(string.Format(("Select * from dbo.musteriYetkili Where mstYetkiliID = {0}"), mstID), _baglanti.cnn).Fill(dtYetkili);

            labelID.Text = dt.Rows[0]["mstID"].ToString();
            textBoxKod.Text = dt.Rows[0]["mstKod"].ToString();
            textBoxAd.Text = dt.Rows[0]["mstAd"].ToString();
            comboBoxMusteriTip.SelectedIndex = Convert.ToByte(dt.Rows[0]["mstTip"]);
            textBoxVN.Text = dt.Rows[0]["mstVN"].ToString();
            textBoxVD.Text = dt.Rows[0]["mstVD"].ToString();
            textBoxAdres.Text = dt.Rows[0]["mstAdres"].ToString();
            textBoxNot.Text = dt.Rows[0]["mstNot"].ToString();
            mTextBoxTel1.Text = dt.Rows[0]["mstTel1"].ToString();
            mTextBoxTel2.Text = dt.Rows[0]["mstTel2"].ToString();
            mTextBoxGsm.Text = dt.Rows[0]["mstGsm"].ToString();
            mTextBoxTelFaks.Text = dt.Rows[0]["mstFaks"].ToString();
            textBoxEPosta.Text = dt.Rows[0]["mstEposta"].ToString();
            comboBoxIl.SelectedValue = dt.Rows[0]["mstIl"].ToString();
            textBoxIlce.Text = dt.Rows[0]["mstIlce"].ToString();
            dtpGenelKurul.Value = Convert.ToDateTime(dt.Rows[0]["mstGenelKurulTarih"].ToString());
            dtpKurulus.Value = Convert.ToDateTime(dt.Rows[0]["mstKurulusTarih"].ToString());
            textBoxTCNo.Text = dt.Rows[0]["mstTcNo"].ToString();
            textBoxKullanici.Text = dt.Rows[0]["mstKullaniciKodu"].ToString();
            textBoxSifre.Text = dt.Rows[0]["mstSifre"].ToString();

            if (dtYetkili.Rows.Count > 0)
            {
                dgwYetkili.Rows.Add(dtYetkili.Rows.Count);
                int i = new int();
                foreach (DataRow dr in dtYetkili.Rows)
                {
                    dgwYetkili.Rows[i].Cells["yetkiliAdi"].Value = dr["yetkiliAd"].ToString();
                    dgwYetkili.Rows[i].Cells["yetkiliGSM"].Value = dr["yetkiliGsm"].ToString();
                    dgwYetkili.Rows[i].Cells["yetkiliTel"].Value = dr["yetkiliTel"].ToString();
                    dgwYetkili.Rows[i].Cells["yetkiliDahili"].Value = dr["yetkiliDahili"].ToString();
                    dgwYetkili.Rows[i].Cells["yetkiliUnvan"].Value = dr["yetkiliUnvan"].ToString();
                    dgwYetkili.Rows[i].Cells["yetkiliEposta"].Value = dr["yetkiliEposta"].ToString();
                    dgwYetkili.Rows[i].Cells["yetkiliId"].Value = dr["yetkiliID"].ToString();

                    i++;
                }

            }
            _baglanti.kapat();
        }


        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Kaydet();
        }

        private void Kaydet()
        {
            if (!KaydetKontroller())
                return;
            try
            {
                _baglanti.ac();
                var mst = new SqlCommand("dbo.musteri_ekle", _baglanti.cnn);
                mst.CommandType = CommandType.StoredProcedure;
                SqlParameter id = mst.Parameters.Add("@id", SqlDbType.Int);
                id.Direction = ParameterDirection.ReturnValue;
                mst.Parameters.AddWithValue("@id", labelID.Text);
                mst.Parameters.AddWithValue("@kod", textBoxKod.Text);
                mst.Parameters.AddWithValue("@ad", textBoxAd.Text);
                mst.Parameters.AddWithValue("@tip", comboBoxMusteriTip.SelectedIndex);
                mst.Parameters.AddWithValue("@vd", textBoxVD.Text);
                mst.Parameters.AddWithValue("@vn", textBoxVN.Text);
                mst.Parameters.AddWithValue("@adres", textBoxAdres.Text);
                mst.Parameters.AddWithValue("@il", comboBoxIl.SelectedValue);
                mst.Parameters.AddWithValue("@ilce", textBoxIlce.Text);
                mst.Parameters.AddWithValue("@tel1", mTextBoxTel1.Text.Replace(" ", ""));
                mst.Parameters.AddWithValue("@tel2", mTextBoxTel2.Text.Replace(" ", ""));
                mst.Parameters.AddWithValue("@gsm", mTextBoxGsm.Text.Replace(" ", ""));
                mst.Parameters.AddWithValue("@faks", mTextBoxTelFaks.Text.Replace(" ", ""));
                mst.Parameters.AddWithValue("@eposta", textBoxEPosta.Text);
                mst.Parameters.AddWithValue("@not", textBoxNot.Text);
                mst.Parameters.AddWithValue("@gtarih", DateTime.Now);
                mst.Parameters.AddWithValue("@ktarih", DateTime.Now);
                mst.Parameters.AddWithValue("@kurulusTarih", dtpKurulus.Value.ToShortDateString());
                mst.Parameters.AddWithValue("@kurulTarih", dtpGenelKurul.Value.ToShortDateString());
                mst.Parameters.AddWithValue("@tc", textBoxTCNo.Text);
                mst.Parameters.AddWithValue("@kullanici", textBoxKullanici.Text);
                mst.Parameters.AddWithValue("@sifre", textBoxSifre.Text);

                mst.CommandTimeout = 3000;
                mst.ExecuteNonQuery();
                labelID.Text = id.Value.ToString();

                var ytk = new SqlCommand("dbo.musteri_yetkili_ekle", _baglanti.cnn);
                ytk.CommandType = CommandType.StoredProcedure;
                SqlParameter yId = mst.Parameters.Add("@id", SqlDbType.Int);
                yId.Direction = ParameterDirection.ReturnValue;
                ytk.Parameters.Add("@id", SqlDbType.Int);
                ytk.Parameters.Add("@mstID", SqlDbType.Int);
                ytk.Parameters.Add("@ad", SqlDbType.VarChar);
                ytk.Parameters.Add("@tel", SqlDbType.VarChar);
                ytk.Parameters.Add("@gsm", SqlDbType.VarChar);
                ytk.Parameters.Add("@dahili", SqlDbType.VarChar);
                ytk.Parameters.Add("@eposta", SqlDbType.VarChar);
                ytk.Parameters.Add("@unvan", SqlDbType.VarChar);

                foreach (DataGridViewRow rw in dgwYetkili.Rows)
                {
                    if (rw.Index != dgwYetkili.Rows.Count - 1)
                    {
                        ytk.Parameters["@id"].Value = rw.Cells["yetkiliID"].Value == null ? "0" : rw.Cells["yetkiliID"].Value;
                        ytk.Parameters["@mstID"].Value = labelID.Text;
                        ytk.Parameters["@ad"].Value = rw.Cells["yetkiliAdi"].Value;
                        ytk.Parameters["@tel"].Value = rw.Cells["yetkiliTel"].Value == null ? "" : rw.Cells["yetkiliTel"].Value;
                        ytk.Parameters["@gsm"].Value = rw.Cells["yetkiliGSM"].Value == null ? "" : rw.Cells["yetkiliGSM"].Value;
                        ytk.Parameters["@dahili"].Value = rw.Cells["yetkiliDahili"].Value == null ? "" : rw.Cells["yetkiliDahili"].Value;
                        ytk.Parameters["@eposta"].Value = rw.Cells["yetkiliEposta"].Value == null ? "" : rw.Cells["yetkiliEposta"].Value;
                        ytk.Parameters["@unvan"].Value = rw.Cells["yetkiliUnvan"].Value == null ? "" : rw.Cells["yetkiliUnvan"].Value;

                        ytk.CommandTimeout = 3000;
                        ytk.ExecuteNonQuery();
                    }
                }


                if (ytkSil.Count > 0)
                {
                    var sil = new SqlCommand("Delete dbo.musteriYetkili where yetkiliID=@id", _baglanti.cnn);
                    sil.Parameters.Add("@id", SqlDbType.Int);
                    sil.CommandType = CommandType.Text;

                    foreach (int i in ytkSil)
                    {
                        sil.Parameters["@id"].Value = i.ToString();
                        sil.CommandTimeout = 3000;
                        sil.ExecuteNonQuery();
                    }
                }


                var dt = new DataTable();
                new SqlDataAdapter(string.Format(("Select * from dbo.musteriYetkili Where mstYetkiliID = {0}"), labelID.Text), _baglanti.cnn).Fill(dt);
                dgwYetkili.Rows.Clear();
                dgwYetkili.DataSource = null;
                if (dt.Rows.Count > 0)
                {
                    dgwYetkili.Rows.Add(dt.Rows.Count);
                    int i = new int();
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgwYetkili.Rows[i].Cells["yetkiliAdi"].Value = dr["yetkiliAd"].ToString();
                        dgwYetkili.Rows[i].Cells["yetkiliGSM"].Value = dr["yetkiliGsm"].ToString();
                        dgwYetkili.Rows[i].Cells["yetkiliTel"].Value = dr["yetkiliTel"].ToString();
                        dgwYetkili.Rows[i].Cells["yetkiliDahili"].Value = dr["yetkiliDahili"].ToString();
                        dgwYetkili.Rows[i].Cells["yetkiliUnvan"].Value = dr["yetkiliUnvan"].ToString();
                        dgwYetkili.Rows[i].Cells["yetkiliEposta"].Value = dr["yetkiliEposta"].ToString();
                        dgwYetkili.Rows[i].Cells["yetkiliId"].Value = dr["yetkiliID"].ToString();
                        i++;
                    }
                }

                MessageBox.Show("Kaydedildi !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ytkSil.Clear();
            _baglanti.kapat();
        }

        private bool KaydetKontroller()
        {
            if (textBoxAd.Text == "")
            {
                MessageBox.Show("Müşteri adı giriniz !", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (mTextBoxTel1.Text == "" && mTextBoxTel2.Text == "" && mTextBoxGsm.Text == "" && mTextBoxTelFaks.Text == "")
            {
                MessageBox.Show("En az bir telefon numarası giriniz !", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (textBoxEPosta.Text != "" && !_baglanti.EpostaKontrol(textBoxEPosta.Text))
            {
                MessageBox.Show("Eposta adresini kontrol edin !", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (textBoxIlce.Text == "")
            {
                MessageBox.Show("İlçe giriniz !", "Uyarı", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                return false;

            }

            if (comboBoxMusteriTip.SelectedIndex == 1)
            {
                if (textBoxVD.Text == "" || textBoxVN.Text == "")
                {
                    MessageBox.Show("Vergi Dairesi ve Vergi Numarasını kontrol edin !", "Uyarı", MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
                    return false;
                }

                if (textBoxVN.Text.Length < 10)
                {
                    MessageBox.Show("Vergi numarası 10 haneden küçük olamaz !", "Uyarı", MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
                    return false;
                }

            }

            if (textBoxAdres.Text == "")
            {
                MessageBox.Show("Adres giriniz !", "Uyarı", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                return false;
            }

            if (textBoxTCNo.Text != "" && textBoxTCNo.Text.Length < 11)
            {
                MessageBox.Show("TC Kimlik Numarası 11 hane olmalı !", "Uyarı", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _baglanti.programKapat();
        }

        private void tsTextMusteriAra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MusteriAra(tsAdArama.Checked ? true : false, false);
            }
        }

        private void dgwMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (ytkSil.Count > 0)
                    ytkSil.Clear();
                Temizle();
                MusteriOku(dgwMusteri.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        private void tsTumMusteriler_Click(object sender, EventArgs e)
        {
            MusteriAra(false, true);
        }

        private void openToolStripButton1_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

        }

        private void copyAlltoClipboard()
        {
            dgwRapor.SelectAll();
            DataObject dataObj = dgwRapor.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void printToolStripButton1_Click(object sender, EventArgs e)
        {
            _baglanti.ac();
            DataTable dt = new DataTable();
            new SqlDataAdapter("Select * from dbo.musteri Order By mstAd", _baglanti.cnn).Fill(dt);

            dgwRapor.DataSource = null;
            dgwRapor.Rows.Clear();

            if (dt.Rows.Count > 0)
                dgwRapor.DataSource = dt;

            _baglanti.kapat();
        }

        private void dgwYetkili_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            ytkSil.Add(Convert.ToInt32(e.Row.Cells["yetkiliID"].Value));
        }

        private void textBoxEPosta_Leave(object sender, EventArgs e)
        {
            if (!_baglanti.EpostaKontrol(textBoxEPosta.Text))
            {
                MessageBox.Show("E-posta adresini kontrol ediniz !", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                textBoxEPosta.Focus();
                return;
            }
        }

        private void textBoxVN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxTCNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxVN_Leave(object sender, EventArgs e)
        {
            if (textBoxVN.Text.Length < 10 || textBoxVN.Text.Length > 11)
            {
                MessageBox.Show("Vergi numarası 10 hane, TCKN 11 hane olmalı ! ", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxVN.Focus();
                return;
            }
        }

        private void textBoxTCNo_Leave(object sender, EventArgs e)
        {
            if (textBoxTCNo.Text.Length != 11)
            {
                MessageBox.Show("TCKN 11 hane olmalı ! ", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxTCNo.Focus();
                return;
            }
        }

        private void dtpKurulus_Leave(object sender, EventArgs e)
        {
            if (dtpKurulus.Value > DateTime.Today)
            {
                MessageBox.Show("Kuruluş tarihi bugünden ileri olamaz", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dtpKurulus.Focus();
                return;
            }
        }


    }
}
