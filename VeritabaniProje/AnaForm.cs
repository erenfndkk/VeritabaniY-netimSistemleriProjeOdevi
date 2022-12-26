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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Doktor doktor = new Doktor();
            doktor.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Duyuru duyuru = new Duyuru();
            duyuru.Show();
        }

        private void btn_mahalle_Click(object sender, EventArgs e)
        {
            Mahalle mahalle = new Mahalle();
            mahalle.Show();
        }

      

        private void btn_sehir_Click(object sender, EventArgs e)
        {
            Sehir sehir = new Sehir();
            sehir.Show();
        }

        private void btn_bolge_Click(object sender, EventArgs e)
        {
            Bolge bolge = new Bolge();
            bolge.Show();
        }

        private void btn_ulke_Click(object sender, EventArgs e)
        {
            Ulke ulke = new Ulke();
            ulke.Show();
        }

        private void btn_sekreter_Click(object sender, EventArgs e)
        {
            Sekreter sekreter = new Sekreter();
            sekreter.Show();
        }

        private void btn_hemsire_Click(object sender, EventArgs e)
        {
            Hemsire hemsire = new Hemsire();
            hemsire.Show();
        }

        private void btn_hastabakici_Click(object sender, EventArgs e)
        {
            HastaBakici hastaBakici = new HastaBakici();
            hastaBakici.Show();
        }

        private void btn_hizmetlicalisan_Click(object sender, EventArgs e)
        {
            HizmetliCalisan hizmetliCalisan = new HizmetliCalisan();
            hizmetliCalisan.Show();
        }

        private void btn_maas_Click(object sender, EventArgs e)
        {
            Maas maas = new Maas();
            maas.Show();
        }

        private void btn_poliklinik_Click(object sender, EventArgs e)
        {
            Poliklinik poliklinik = new Poliklinik();
            poliklinik.Show();
        }

        private void btn_recete_Click(object sender, EventArgs e)
        {
            Recete recete = new Recete();
            recete.Show();
        }

        private void btn_hemsireHasta_Click(object sender, EventArgs e)
        {
            HemsireHasta hemsireHasta = new HemsireHasta();
            hemsireHasta.Show();
        }

        private void btn_hastaBakiciHasta_Click(object sender, EventArgs e)
        {
            HastaBakiciHasta hastaBakiciHasta = new HastaBakiciHasta();
            hastaBakiciHasta.Show();
        }

        private void btn_ilce_Click(object sender, EventArgs e)
        {
            Ilce ilce = new Ilce();
            ilce.Show();
        }
    }
}
