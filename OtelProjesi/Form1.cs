using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDurumTanim_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmDurum frm = new Formlar.Tanımlamalar.FrmDurum();
            frm.Show();
        }

        private void btnBirimTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmBirim frm = new Formlar.Tanımlamalar.FrmBirim();
            frm.Show();
        }

        private void btnDepartmanTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDepartman frm = new FrmDepartman();
            frm.Show();
        }

        private void btnGorevTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmGorev frm = new Formlar.Tanımlamalar.FrmGorev();
            frm.Show();
        }

        private void btnKasaTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKasa frm = new Formlar.Tanımlamalar.FrmKasa();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnKurTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKur frm = new Formlar.Tanımlamalar.FrmKur();
            frm.Show();
        }

        private void btnOdaTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmOda frm = new Formlar.Tanımlamalar.FrmOda();
            frm.Show();
        }

        private void btnTelefonTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmTelefon frm = new Formlar.Tanımlamalar.FrmTelefon();
            frm.Show();
        }

        private void btnUlkeTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUlke frm = new Formlar.Tanımlamalar.FrmUlke();
            frm.Show();
        }

        private void btnUrunGrupTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUrunGrup frm = new Formlar.Tanımlamalar.FrmUrunGrup();
            frm.Show();
        }

        private void btnPersonelKart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Personel.FrmPersonelKart frm = new Formlar.Personel.FrmPersonelKart();
            frm.Show();
        }

        private void btnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Personel.FrmPersonelListesi frm = new Formlar.Personel.FrmPersonelListesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnMisafirKart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Misafir.FrmMisafirKart frm = new Formlar.Misafir.FrmMisafirKart();
            frm.Show();
        }

        private void btnMisafirListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Misafir.FrmMisafirListesi frm = new Formlar.Misafir.FrmMisafirListesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Ürün.FrmUrunListesi frm = new Formlar.Ürün.FrmUrunListesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnUrunKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Ürün.FrmUrunKart frm = new Formlar.Ürün.FrmUrunKart();
            frm.Show();
        }

        private void btnUrunGirisHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Ürün.FrmUrunGirisHareket frm = new Formlar.Ürün.FrmUrunGirisHareket();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnUrunCikisHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Ürün.FrmUrunCikisHareket frm = new Formlar.Ürün.FrmUrunCikisHareket();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnYeniUrunHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Ürün.FrmUrunHareketTanimi frm = new Formlar.Ürün.FrmUrunHareketTanimi();
            frm.Show();
        }

        private void btnRezervasyonKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmRezervasyonKarti frm = new Formlar.Rezervasyon.FrmRezervasyonKarti();
            frm.Show();
        }

        private void btnRezervasyonListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmTumRezervasyonlar frm = new Formlar.Rezervasyon.FrmTumRezervasyonlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnAktifRezervasyonlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmAktifRezervasyonlar frm = new Formlar.Rezervasyon.FrmAktifRezervasyonlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnIptalRezervasyon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmIptalRezervasyon frm = new Formlar.Rezervasyon.FrmIptalRezervasyon();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnGecmisRezervasyon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmGecmisRezervasyonlar frm = new Formlar.Rezervasyon.FrmGecmisRezervasyonlar();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
