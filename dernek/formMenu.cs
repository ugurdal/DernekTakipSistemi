using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dernek
{
    public partial class formMenu : Form
    {
        string _sunucu = String.Empty;
        string _veritabani = String.Empty;
        string _kullanici = String.Empty;
        
        public formMenu()
        {
            InitializeComponent();
        }

        private void formMenu_Load(object sender, EventArgs e)
        {
            labelDatabase.Text = _veritabani;
            labelKullanici.Text = _kullanici;
            labelSunucu.Text = _sunucu;
            notlar.Text = Properties.Settings.Default.not;
        }

        public void basla(string sunucu, string veritabani, string kullanici)
        {
            _sunucu = sunucu;
            _kullanici = kullanici;
            _veritabani = veritabani;
        }

        private void formMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing && (_frmMst != null))
            //{
            //    e.Cancel = true;
            //    return;
            //}
            
            Properties.Settings.Default.not = notlar.Text;
            Properties.Settings.Default.Save();
        }

        private void pbMusteri_Click(object sender, EventArgs e)
        {
           var frmMst = new formMusteri();
           frmMst.ShowDialog();
        }

        private void pbMusteri_MouseEnter(object sender, EventArgs e)
        {
            pbMusteri.Cursor = Cursors.Hand;
            gbMusteri.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        }

        private void pbMusteri_MouseLeave(object sender, EventArgs e)
        {
            pbMusteri.Cursor = Cursors.Default;
            gbMusteri.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        }

        private void pbCari_MouseEnter(object sender, EventArgs e)
        {
            gbCari.Cursor = Cursors.Hand;
            gbCari.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        }

        private void pbCari_MouseLeave(object sender, EventArgs e)
        {
            gbCari.Cursor = Cursors.Default;
            gbCari.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        }

        private void pbCari_Click(object sender, EventArgs e)
        {
            var frmCari = new formCari();
            frmCari.ShowDialog();
        }


    }
}
