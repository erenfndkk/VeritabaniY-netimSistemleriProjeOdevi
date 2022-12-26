using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeritabaniProje
{
    public partial class Maas : Form
    {
        public Maas()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localhost; port=5432; Database=DbHastane; user Id=postgres; password=1234");

        private void Maas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("select maasid, kiminmaas, kacpara, " +
            "\"Hastane\".\"vergi\"(kacpara), " +
            "\r\n\"Hastane\".\"vergiliMaas\"(kacpara), \"Hastane\".\"donerSermaye\"(kacpara),\r" +
            "\n\"Hastane\".\"netMaas\"(kacpara) from \"Hastane\".\"Maas\";", connect);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }
    }
}
