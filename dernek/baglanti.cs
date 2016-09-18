using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class baglanti
{
    private string _database = String.Empty;
    private string _user = String.Empty;
    private string _password = String.Empty;
    private string _datasource = String.Empty;
    private string bag = String.Empty;

    public string database
    {
        get { return _database; }
        set { _database = value; }
    }
    public string user
    {
        get { return _user; }
        set { _user = value; }
    }
    public string password
    {
        get { return _password; }
        set { _password = value; }
    }
    public string datasource
    {
        get { return _datasource; }
        set { _datasource = value; }
    }

    public bool basla()
    {
        try
        {
            bag = "Data Source=" + datasource + ";Initial Catalog=" + database + "; User Id=" + user + "; password=" + password +";";
            cnn.ConnectionString = bag;
            cnn.Open();
        }
        catch (Exception)
        {
            MessageBox.Show("Bağlantı Hatası");
            return false;
        }
        return true;
    }
    
    //public DerinSisComp.cDrnSisComp drn = new DerinSisComp.cDrnSisComp();
    
    public SqlConnection cnn = new System.Data.SqlClient.SqlConnection();
    public DataSet dataSet = new DataSet();
    SqlDataAdapter adpTemp = new System.Data.SqlClient.SqlDataAdapter();
    SqlCommand cmdTemp = new System.Data.SqlClient.SqlCommand();


    public void ac()
    {
        try
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.ConnectionString = bag;
                cnn.Open();
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Bağlantı Hatası");
        }

    }

    public void kapat()
    {
        if (cnn.State == ConnectionState.Open)
        {
            cnn.Close();
        }
        cnn.Dispose();
    }
    public void programKapat() //formClosing eventinde calistir
    {
        cnn.Dispose();
        kapat();
    }


    public bool tblAc(string sorgu, ref DataTable dtTemp)
    {
        dtTemp.Columns.Clear();
        ac();
        cmdTemp.Connection = cnn;
        cmdTemp.CommandType = CommandType.Text;
        cmdTemp.CommandText = sorgu;
        adpTemp.SelectCommand = cmdTemp;
        adpTemp.Fill(dtTemp);
        if (dtTemp.Rows.Count == 0)
        {
            MessageBox.Show("Gösterilecek veri bulunamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        else
        {
            return false;
        }
        kapat();
    }

    public void sqlExecute(string sqlStr, bool kapat = true)
    {
        try
        {
            ac();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = sqlStr;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (kapat)
            {
                ac();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public decimal KDVhesap(decimal deger, byte yuzde, byte ondalik)
    {
        return Math.Round(deger / (100 + yuzde) * 100, ondalik);
    }

    public string ToOnlyCharacters(string s)
    {
        s = s.Trim();
        if (string.IsNullOrEmpty(s)) return "";
        Regex r = new Regex("[^a-zA-Z0-9]");
        s = r.Replace(s, "");
        return s;
    }

    public bool isNumeric(string s)
    {
        double price;
        bool isDouble = Double.TryParse(s, out price);
        if (!isDouble)
        {
            MessageBox.Show("Tutarı kontrol ediniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    public string ToMultiLineString(string str, int adet)
    {
        string yeni = "";
        for (int i = 0; i < str.Length; i += adet)
        {
            if (i > 0)
                yeni += "\n";
            if (i + adet < str.Length)
                yeni += str.Substring(i, adet);
            else
                yeni += str.Substring(i);
        }
        return yeni;
    }


    //var dt = new DataTable();
    //dt.Columns.Add("id", typeof(System.Byte));
    //dt.Columns.Add("ad");
    //dt.Rows.Add((byte)0, "Ürün");
    //dt.Rows.Add((byte)1, "Model");
    //dt.Rows.Add((byte)2, "Fiyat Listesi");
    //((DataGridViewComboBoxColumn)dgw.Columns["etkiTip"]).DisplayMember = "ad";
    //((DataGridViewComboBoxColumn)dgw.Columns["etkiTip"]).ValueMember = "id";
    //((DataGridViewComboBoxColumn)dgw.Columns["etkiTip"]).DataSource = dt;


    public DataGridViewCheckBoxColumn KolonCheckbox(string kolAd, string KolBas, int KolGen, bool kolSabit = false)
    {
        DataGridViewCheckBoxColumn cl = new DataGridViewCheckBoxColumn();
        cl.Name = kolAd;
        cl.HeaderText = KolBas;
        cl.Width = KolGen;
        cl.Frozen = kolSabit;
        return cl;
    }

    public string TelFormat(string tel)
    {
        {
            string sonuc = String.Format("{0:(###) ###-##-##}", tel);
            return sonuc;
        }
    }

    public string ParaFormat(string tutar)
    {
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("tr-TR");
        double valueBefore = double.Parse(tutar);
        string sonuc = String.Format(culture, "{0:N2}", valueBefore);
        return sonuc;
    }

    public bool EpostaKontrol(string eposta)
    {
        string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
        + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
        + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
        + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
        + @"[a-zA-Z]{2,}))$";
        Regex reStrict = new Regex(patternStrict);
        bool isStrictMatch = reStrict.IsMatch(eposta);
        return isStrictMatch;

    }

    public void ListBoxDoldur(CheckedListBox lb, string displayMember, string valueMember)
    {
        DataTable dt = new DataTable();
        new SqlDataAdapter(("SELECT * FROM sifTip WHERE hrktSIF=0 AND hrktTipID IN (0,1,3,7,9,10)"), cnn).Fill(dt);
        lb.DataSource = dt;
        lb.ValueMember = valueMember;
        lb.DisplayMember = displayMember;
    }

}





