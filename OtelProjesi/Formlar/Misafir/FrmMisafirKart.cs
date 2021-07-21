using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelProjesi.Entity;
using OtelProjesi.Repositories;

namespace OtelProjesi.Formlar.Misafir
{
    public partial class FrmMisafirKart : Form
    {
        public FrmMisafirKart()
        {
            InitializeComponent();
        }

        Repository<TBLMISAFIR> repo = new Repository<TBLMISAFIR>();
        DbOtelEntities db = new DbOtelEntities();
        public int id;
        string resim1, resim2;

        private void FrmMisafirKart_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString();

            //Güncellenecek misafir bilgileri
            if (id != 0)
            {
                var misafir = repo.Find(x => x.MISAFIRID == id);
                txtAciklama.Text = misafir.ACIKLAMA;
                txtAdres.Text = misafir.ADRES;
                txtAdSoyad.Text = misafir.ADSOYAD;
                txtMail.Text = misafir.MAIL;
                txtTc.Text = misafir.TC;
                txtTelefon.Text = misafir.TELEFON;
                //pictureOn.Image = Image.FromFile(misafir.KIMLIKFOTO1);
                // pictureArka.Image = Image.FromFile(misafir.KIMLIKFOTO2);
                resim1 = misafir.KIMLIKFOTO1;
                resim2 = misafir.KIMLIKFOTO2;
                lookUpEditSehir.EditValue = misafir.SEHIR;
                lookUpEditIlce.EditValue = misafir.ILCE;
                lookUpEditUlke.EditValue = misafir.ULKE;
            }


            //ülke listesi
            lookUpEditUlke.Properties.DataSource = (from x in db.TBLULKE
                                                    select new
                                                    {
                                                        x.ULKEID,
                                                        x.ULKEAD
                                                    }).ToList();

            lookUpEditSehir.Properties.DataSource = (from x in db.iller
                                                     select new
                                                     {
                                                         x.id,
                                                         x.sehir
                                                     }).ToList();
        }

        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen = int.Parse(lookUpEditSehir.EditValue.ToString());
            lookUpEditIlce.Properties.DataSource = (from x in db.ilceler
                                                    select new
                                                    {
                                                        x.id,
                                                        x.ilce,
                                                        x.sehir
                                                    }).Where(y => y.sehir == secilen).ToList();
        }



        private void pictureOn_EditValueChanged(object sender, EventArgs e)
        {
            resim1 = pictureOn.GetLoadedImageLocation().ToString();
        }

        private void pictureArka_EditValueChanged(object sender, EventArgs e)
        {
            resim2 = pictureArka.GetLoadedImageLocation().ToString();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = XtraMessageBox.Show("Misafir Bilgilerini Gerçekten Değiştirmek İstiyor Musun ?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (txtAdSoyad.Text != "" && txtTc.Text != "" && lookUpEditUlke.Text != "" && txtTelefon.Text != "")
                    {
                        var guncelle = repo.Find(x => x.MISAFIRID == id);
                        guncelle.ACIKLAMA = txtAciklama.Text;
                        guncelle.ADRES = txtAdres.Text;
                        guncelle.ADSOYAD = txtAdSoyad.Text;
                        guncelle.MAIL = txtMail.Text;
                        guncelle.TC = txtTc.Text;
                        guncelle.TELEFON = txtTelefon.Text;
                        guncelle.KIMLIKFOTO1 = resim1;
                        guncelle.KIMLIKFOTO2 = resim2;
                        guncelle.SEHIR = int.Parse(lookUpEditSehir.EditValue.ToString());
                        guncelle.ILCE = int.Parse(lookUpEditIlce.EditValue.ToString());
                        guncelle.ULKE = int.Parse(lookUpEditUlke.EditValue.ToString());
                        guncelle.DURUM = 1;
                        repo.TUpdate(guncelle);
                        XtraMessageBox.Show("Personel Bilgileri Başarıyla Güncellendi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        XtraMessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAdSoyad.Text != "" && txtTc.Text != "" && lookUpEditUlke.Text != "" && txtTelefon.Text != "")
                {
                    TBLMISAFIR t = new TBLMISAFIR();
                    t.ADSOYAD = txtAdSoyad.Text;
                    t.TC = txtTc.Text;
                    t.TELEFON = txtTelefon.Text;
                    t.MAIL = txtMail.Text;
                    t.ADRES = txtAdres.Text;
                    t.DURUM = 1;
                    t.SEHIR = int.Parse(lookUpEditSehir.EditValue.ToString());
                    t.ILCE = int.Parse(lookUpEditIlce.EditValue.ToString());
                    t.ULKE = int.Parse(lookUpEditUlke.EditValue.ToString());
                    t.KIMLIKFOTO1 = resim1;
                    t.KIMLIKFOTO2 = resim2;
                    repo.TAdd(t);
                    XtraMessageBox.Show("Misafir Başarılı Bir Şekilde Sisteme Kaydedildi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    XtraMessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
