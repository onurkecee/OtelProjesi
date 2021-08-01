using DevExpress.XtraEditors;
using OtelProjesi.Entity;
using OtelProjesi.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProjesi.Formlar.Ürün
{
    public partial class FrmUrunHareketTanimi : Form
    {
        public FrmUrunHareketTanimi()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();
        Repository<TBLURUNHAREKET> repo = new Repository<TBLURUNHAREKET>();
        TBLURUNHAREKET t = new TBLURUNHAREKET();
        public int id;

        private void FrmUrunHareketTanimi_Load(object sender, EventArgs e)
        {
            txtID.Text = id.ToString();

            lookUpEditUrun.Properties.DataSource = (from x in db.TBLURUN
                                                    select new
                                                    {
                                                        x.URUNID,
                                                        x.URUNAD
                                                    }).ToList();

            if (id != 0)
            {
                var urun = repo.Find(x => x.HAREKETID == id);
                lookUpEditUrun.EditValue = urun.URUN;
                txtMiktar.Text = urun.MIKTAR.ToString(); ;
                txtAciklama.Text = urun.ACIKLAMA;
                txtTarih.Text = urun.TARIH.ToString();
                cmbHareket.Text = urun.HAREKETTURU;
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
                if (txtMiktar.Text != "" && txtTarih.Text != "" && cmbHareket.Text != "" && lookUpEditUrun.Text != "")
                {
                    t.URUN = int.Parse(lookUpEditUrun.EditValue.ToString());
                    t.TARIH = DateTime.Parse(txtTarih.Text);
                    t.HAREKETTURU = cmbHareket.Text;
                    t.MIKTAR = decimal.Parse(txtMiktar.Text);
                    t.ACIKLAMA = txtAciklama.Text;
                    repo.TAdd(t);
                    XtraMessageBox.Show("Ürün Hareketi Başarılı Bir Şekilde Sisteme Kaydedildi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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
                    if (txtMiktar.Text != "" && txtTarih.Text != "" && cmbHareket.Text != "" && lookUpEditUrun.Text != "")
                    {
                        var guncelle = repo.Find(x => x.HAREKETID == id);
                        guncelle.URUN = int.Parse(lookUpEditUrun.EditValue.ToString());
                        guncelle.TARIH = DateTime.Parse(txtTarih.Text);
                        guncelle.HAREKETTURU = cmbHareket.Text;
                        guncelle.MIKTAR = decimal.Parse(txtMiktar.Text);
                        guncelle.ACIKLAMA = txtAciklama.Text;
                        repo.TUpdate(guncelle);
                        XtraMessageBox.Show("Ürün Hareketi Başarılı Bir Şekilde Değiştirildi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
