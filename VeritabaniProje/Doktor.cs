using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VeritabaniProje
{
    public partial class Doktor : Form
    {
        public Doktor()
        {
            InitializeComponent();
        }

        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=DbHastane; user Id=postgres; password=1234");

        private void Doktor_Load(object sender, EventArgs e)
        {

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT INTO \"Hastane\".\"Kisi\"(\"ad\",\"soyad\"," +
                "\"ulke\",\"bolge\",\"sehir\",\"ilce\",\"mahalle\",\"Cinsiyet\",\"telefon\",\"TcNo\")" +
                "\r\nVALUES (@pAd,@pSoyad,@pUlke,@pBolge,@pSehir,@pIlce,@pMahalle,@pCinsiyet,@pTelefon,@pTcNo)", connect);

            cmd1.Parameters.AddWithValue("@pAd", txt_ad.Text );
            cmd1.Parameters.AddWithValue("@pSoyad", txt_soyad.Text );
            cmd1.Parameters.AddWithValue("@pUlke", int.Parse(msk_ulke.Text));
            cmd1.Parameters.AddWithValue("@pBolge", int.Parse(msk_bolge.Text));
            cmd1.Parameters.AddWithValue("@pSehir", int.Parse(msk_sehir.Text));
            cmd1.Parameters.AddWithValue("@pIlce", int.Parse(msk_ilce.Text));
            cmd1.Parameters.AddWithValue("@pMahalle", int.Parse(msk_mahalle.Text));
            cmd1.Parameters.AddWithValue("@pCinsiyet", txt_cinsiyet.Text);
            cmd1.Parameters.AddWithValue("@pTelefon", txt_telefon.Text);
            cmd1.Parameters.AddWithValue("@pTcNo", txt_tc.Text);

            cmd1.ExecuteNonQuery();
            

            NpgsqlCommand cmd2 = new NpgsqlCommand("insert into \"Hastane\".\"Doktor\" " +
                "(\"Maas\", \"calistigiPoliklinik\", \"DoktorId\", \"isegirdigiyil\")" +
                " values(@p1,@p2,currval('\"Hastane\".\"Insan_kisiid_seq\"'),@p3)", connect);
            cmd2.Parameters.AddWithValue("@p1", int.Parse(msk_maas.Text));
            cmd2.Parameters.AddWithValue("@p2", int.Parse(msk_poliklinik.Text));
            cmd2.Parameters.AddWithValue("@p3", txt_isegiridigiyil.Text);
            cmd2.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("doktor başarıyla eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("Delete From \"Hastane\".\"Doktor\" where \"DoktorId\" = @p1", connect);
            cmd1.Parameters.AddWithValue("@p1", int.Parse(txt_doktorid.Text));
            cmd1.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Doktor başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand cmd2 = new NpgsqlCommand("update \"Hastane\".\"Kisi\" set \"ad\" = @pAd, " +
                "\"soyad\" = @pSoyad, \"ulke\" = @pUlke, \"bolge\" = @pBolge, \"sehir\" = @pSehir, \"ilce\" = @pIlce, \"mahalle\" = @pMahalle, \"Cinsiyet\" = @pCinsiyet, " +
                "\"telefon\" = @pTelefon, \"TcNo\" = @pTcno" +
                " where \"kisiid\" = @p2", connect);
            cmd2.Parameters.AddWithValue("@pAd", txt_ad.Text);
            cmd2.Parameters.AddWithValue("@pSoyad", txt_soyad.Text);
            cmd2.Parameters.AddWithValue("@pUlke", int.Parse(msk_ulke.Text));
            cmd2.Parameters.AddWithValue("@pBolge", int.Parse(msk_bolge.Text));
            cmd2.Parameters.AddWithValue("@pSehir", int.Parse(msk_sehir.Text));
            cmd2.Parameters.AddWithValue("@pIlce", int.Parse(msk_ilce.Text));
            cmd2.Parameters.AddWithValue("@pMahalle", int.Parse(msk_mahalle.Text));
            cmd2.Parameters.AddWithValue("@pCinsiyet", txt_cinsiyet.Text);
            cmd2.Parameters.AddWithValue("@pTelefon", txt_telefon.Text);
            cmd2.Parameters.AddWithValue("@pTcno", txt_tc.Text);
            cmd2.Parameters.AddWithValue("@p2", int.Parse(txt_doktorid.Text));

            cmd2.ExecuteNonQuery();

            NpgsqlCommand cmd3 = new NpgsqlCommand(" update \"Hastane\".\"Doktor\" set \"Maas\" = @pMaas," +
                " \"calistigiPoliklinik\" = @pCalistigipoliklinik," +
                " \"isegirdigiyil\" = @pIsegiridigiyil where \"DoktorId\" = @p1", connect);

            cmd3.Parameters.AddWithValue("@pMaas", int.Parse(msk_maas.Text));
            cmd3.Parameters.AddWithValue("@pCalistigipoliklinik", int.Parse(msk_poliklinik.Text));
            cmd3.Parameters.AddWithValue("@pIsegiridigiyil", txt_isegiridigiyil.Text);
            cmd3.Parameters.AddWithValue("@p1", int.Parse(txt_doktorid.Text));

            cmd3.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Doktor başarıyla güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from \"Hastane\".\"Kisi\"\r\n" +
                "inner join \"Hastane\".\"Doktor\"" +
                "\r\non \"Hastane\".\"Kisi\".\"kisiid\" = \"Hastane\".\"Doktor\".\"DoktorId\"";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connect);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txt_doktorid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            //msk_ulke.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msk_ulke.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msk_bolge.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            msk_sehir.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            msk_ilce.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            msk_mahalle.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txt_cinsiyet.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            txt_telefon.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            txt_tc.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            msk_maas.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            msk_poliklinik.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            txt_isegiridigiyil.Text = dataGridView1.Rows[secilen].Cells[14].Value.ToString();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            connect.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("select * from \"Hastane\".\"Kisi\"\r\ninner join \"Hastane\".\"Doktor\"\r\non" +
                " \"Hastane\".\"Kisi\".\"kisiid\" = \"Hastane\".\"Doktor\".\"DoktorId\" where ad like '%" + txt_ara.Text + "%';", connect);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }

        
    }
}
