using OtelProjesi.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelProjesi.Repositories;
using DevExpress.XtraEditors;

namespace OtelProjesi.Formlar.Ürün
{
    public partial class FrmUrunKart : Form
    {
        public FrmUrunKart()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();
        Repository<TBLURUN> repo = new Repository<TBLURUN>();
        public int id;

        private void FrmUrunKart_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString();
            try
            {
                lookUpEditUrunGrup.Properties.DataSource = (from x in db.TBLURUNGRUP
                                                            select new
                                                            {
                                                                x.URUNGRUPID,
                                                                x.URUNGRUPAD
                                                            }).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ürün Grup Listeleme Hatası", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                lookUpEditDurum.Properties.DataSource = (from x in db.TBLDURUM
                                                         select new
                                                         {
                                                             x.DURUMID,
                                                             x.DURUMAD
                                                         }).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Durum Listeleme Hatası", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                lookUpEditBirim.Properties.DataSource = (from x in db.TBLBIRIM
                                                         select new
                                                         {
                                                             x.BIRIMID,
                                                             x.BIRIMAD
                                                         }).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Birim Listeleme Hatası", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Veri Gönderme
            if (id != 0)
            {
                var urun = repo.Find(x => x.URUNID == id);
                txtUrunAD.Text = urun.URUNAD;
                lookUpEditUrunGrup.EditValue = urun.URUNGRUP;
                lookUpEditBirim.EditValue = urun.URUNBIRIM;
                txtFiyat.Text = urun.URUNFIYAT.ToString();
                txtToplam.Text = urun.TOPLAM.ToString();
                txtKDV.Text = urun.KDV.ToString();
                lookUpEditDurum.EditValue = urun.DURUM;
            }

        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrunAD.Text != "" && txtToplam.Text != "" && txtFiyat.Text != "" && txtKDV.Text != "" && lookUpEditBirim.Text != "" && lookUpEditDurum.Text != "" && lookUpEditUrunGrup.Text != "")
                {
                    TBLURUN urun = new TBLURUN();
                    urun.URUNAD = txtUrunAD.Text;
                    urun.URUNGRUP = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
                    urun.URUNBIRIM = int.Parse(lookUpEditDurum.EditValue.ToString());
                    urun.URUNFIYAT = decimal.Parse(txtFiyat.Text);
                    urun.TOPLAM = decimal.Parse(txtToplam.Text);
                    urun.KDV = byte.Parse(txtKDV.Text);
                    repo.TAdd(urun);
                    XtraMessageBox.Show("Ürün Başarılı Bir Şekilde Sisteme Kaydedildi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                DialogResult result = XtraMessageBox.Show("Ürün Bilgilerini Gerçekten Değiştirmek İstiyor Musun ?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (txtUrunAD.Text != "" && txtToplam.Text != "" && txtFiyat.Text != "" && txtKDV.Text != "" && lookUpEditBirim.Text != "" && lookUpEditDurum.Text != "" && lookUpEditUrunGrup.Text != "")
                    {
                        var guncelle = repo.Find(x => x.URUNID == id);
                        guncelle.URUNAD = txtUrunAD.Text;
                        guncelle.URUNGRUP = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
                        guncelle.URUNBIRIM = int.Parse(lookUpEditDurum.EditValue.ToString());
                        guncelle.URUNFIYAT = decimal.Parse(txtFiyat.Text);
                        guncelle.TOPLAM = decimal.Parse(txtToplam.Text);
                        guncelle.KDV = byte.Parse(txtKDV.Text);
                        repo.TUpdate(guncelle);
                        XtraMessageBox.Show("Ürün Başarılı Bir Şekilde Değiştirildi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
    }
}
