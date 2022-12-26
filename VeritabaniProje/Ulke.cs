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

namespace VeritabaniProje
{

    public partial class Ulke : Form
    {
        public Ulke()
        {
            InitializeComponent();
        }

        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=DbHastane; user Id=postgres; password=1234");

        private void Ulke_Load(object sender, EventArgs e)
        {

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("insert into \"Hastane\".\"Ulke\" (\"ulkead\") values (@p1);", connect);
            cmd.Parameters.AddWithValue("@p1", txt_ulkeAd.Text);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("ükle başarıyla eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("Delete From \"Hastane\".\"Ulke\" where \"ulkeid\" = @p1", connect);
            cmd1.Parameters.AddWithValue("@p1", int.Parse(txt_id.Text));
            cmd1.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ulke başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand cmd2 = new NpgsqlCommand("update \"Hastane\".\"Ulke\" set \"ulkead\" = @p2 where \"ulkeid\" = @p1", connect);
            cmd2.Parameters.AddWithValue("@p1", int.Parse(txt_id.Text));
            cmd2.Parameters.AddWithValue("@p2", txt_ulkeAd.Text);
            cmd2.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Ulke başarıyla güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from \"Hastane\".\"Ulke\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connect);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from \"Hastane\".\"Ulke\" where ulkead like '%" + txt_ara.Text + "%'", connect);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            connect.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txt_id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_ulkeAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }
    }
}
