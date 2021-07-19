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

namespace OtelProjesi.Formlar.Personel
{
    public partial class FrmPersonelKart : Form
    {
        public FrmPersonelKart()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        public int id;

        Repository<TBLPERSONEL> repo = new Repository<TBLPERSONEL>();

        private void FrmPersonelKart_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString();

            if (id != 0)
            {
                var personel = repo.Find(x => x.PERSONELID == id);
                txtAdSoyad.Text = personel.ADSOYAD;
                txtAciklama.Text = personel.ACIKLAMA;
                txtAdres.Text = personel.ADRES;
                txtMail.Text = personel.MAIL;
                txtSifre.Text = personel.SIFRE;
                txtTc.Text = personel.TC;
                txtTelefon.Text = personel.TELEFON;
                lblKimlikOn.Text = personel.KIMLIKON;
                dateEditGiris.Text = personel.ISEGIRISTARIH.ToString();
                dateCikis.Text = personel.ISCIKISTARIH.ToString();
                // pictureOn.Image = Image.FromFile(personel.KIMLIKON);
                // pictureArka.Image = Image.FromFile(personel.KIMLIKARKA);
                lookUpEditDepartman.EditValue = personel.DEPARTMAN;
                lookUpEditGorev.EditValue = personel.GOREV;
            }


            lookUpEditDepartman.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                         select new
                                                         {
                                                             x.DEPARTMANID,
                                                             x.DEPARTMANAD
                                                         }).ToList();

            lookUpEditGorev.Properties.DataSource = (from x in db.TBLGOREV
                                                     select new
                                                     {
                                                         x.GOREVID,
                                                         x.GOREVAD
                                                     }).ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAdSoyad.Text != "" && txtTc.Text != "" && lookUpEditDepartman.Text != "" && lookUpEditGorev.Text != "" && dateEditGiris.Text != "")
                {
                    TBLPERSONEL t = new TBLPERSONEL();
                    t.ADSOYAD = txtAdSoyad.Text;
                    t.TC = txtTc.Text;
                    t.TELEFON = txtTelefon.Text;
                    t.MAIL = txtMail.Text;
                    t.ADRES = txtAdres.Text;
                    t.ISEGIRISTARIH = DateTime.Parse(dateEditGiris.Text);
                    t.DEPARTMAN = int.Parse(lookUpEditDepartman.EditValue.ToString());
                    t.GOREV = int.Parse(lookUpEditGorev.EditValue.ToString());
                    t.ACIKLAMA = txtAciklama.Text;
                    t.KIMLIKON = pictureOn.GetLoadedImageLocation();
                    t.KIMLIKARKA = pictureArka.GetLoadedImageLocation();
                    //t.YETKI=
                    //t.SIFRE=txtSifre.Text;
                    t.DURUM = 1;
                    repo.TAdd(t);
                    XtraMessageBox.Show("Personel Başarıyla Kaydedildi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    XtraMessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = XtraMessageBox.Show("Personel Bilgilerini Gerçekten Değiştirmek İstiyor Musun ?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (txtAdSoyad.Text != "" && txtTc.Text != "" && lookUpEditDepartman.Text != "" && lookUpEditGorev.Text != "" && dateEditGiris.Text != "")
                    {
                        var guncelle = repo.Find(x => x.PERSONELID == id);
                        guncelle.ADSOYAD = txtAdSoyad.Text;
                        guncelle.TC = txtTc.Text;
                        guncelle.TELEFON = txtTelefon.Text;
                        guncelle.MAIL = txtMail.Text;
                        guncelle.ADRES = txtAdres.Text;
                        guncelle.ISEGIRISTARIH = DateTime.Parse(dateEditGiris.Text);
                        guncelle.DEPARTMAN = int.Parse(lookUpEditDepartman.EditValue.ToString());
                        guncelle.GOREV = int.Parse(lookUpEditGorev.EditValue.ToString());
                        guncelle.ACIKLAMA = txtAciklama.Text;
                        guncelle.KIMLIKON = lblKimlikOn.Text;
                        guncelle.KIMLIKARKA = lblKimlikArka.Text;
                        repo.TUpdate(guncelle);
                        XtraMessageBox.Show("Personel Bilgileri Başarıyla Güncellendi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        XtraMessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }

        }

        private void pictureOn_EditValueChanged(object sender, EventArgs e)
        {
            lblKimlikOn.Text = pictureOn.GetLoadedImageLocation().ToString();
        }

        private void pictureArka_EditValueChanged(object sender, EventArgs e)
        {
            lblKimlikArka.Text = pictureArka.GetLoadedImageLocation().ToString();
        }
    }
}
