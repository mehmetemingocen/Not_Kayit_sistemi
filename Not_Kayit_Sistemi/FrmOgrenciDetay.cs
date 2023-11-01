﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-GM33BP4\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");
        public string durum;  // DENEME

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select  * From TBLDERS where OGRNUMARA=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                LblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                LblSinav1.Text = dr[4].ToString();
                LblSinav2.Text = dr[5].ToString();
                LblSinav3.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                //  LblDurum.Text = dr[8].ToString();

                if (dr[8].ToString() == "True")
                {
                    LblDurum.Text = "Geçti";
                }
                else
                {
                    LblDurum.Text = "Kaldı";
                }

            }



            baglanti.Close();
        }

        private void LblDurum_Click(object sender, EventArgs e)
        {
           
        }
    }
}
