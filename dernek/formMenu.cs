﻿using System;
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
            _sunucu = "Microsoft Access";
            _kullanici = kullanici;
            _veritabani = "Dernek";
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/ugurdal0");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/ugurrdal");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/ugurdal");
        }

        private void pbKullanici_Click(object sender, EventArgs e)
        {
            var frm = new formKullanici();
            frm.ShowDialog();
        }

        private void pbKullanici_MouseEnter(object sender, EventArgs e)
        {
            gbKullanici.Cursor = Cursors.Hand;
            gbKullanici.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        }

        private void pbKullanici_MouseLeave(object sender, EventArgs e)
        {
            gbKullanici.Cursor = Cursors.Default;
            gbKullanici.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        }


    }
}
