using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreUrunProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dburunler; user ID=postgres; password=479528");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kategoriler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into kategoriler (kategoriid,kategoriad) values (@p1,@p2)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(TxtKategorid.Text));
            komut1.Parameters.AddWithValue("@p2", TxtAd.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Ekleme işlemi başarılı gerçekleşti");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("update kategoriler set kategoriad=@p1 where kategoriid=@p2", baglanti);
            komut4.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut4.Parameters.AddWithValue("@p2", int.Parse(TxtKategorid.Text));
            komut4.ExecuteNonQuery();
          
            baglanti.Close();

            MessageBox.Show("ürün güncelleme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);



      
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut5 = new NpgsqlCommand(" Delete From kategoriler where kategoriid=@p1", baglanti);
            komut5.Parameters.AddWithValue("@p1", int.Parse(TxtKategorid.Text));
            komut5.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ürün silme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void urunler_gecis_Click(object sender, EventArgs e)
        {
            FrmUrun frm_urun = new FrmUrun();
            frm_urun.Show();
            this.Hide();
        }
    }
}
