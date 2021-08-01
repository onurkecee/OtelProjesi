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

        private void FrmUrunKart_Load(object sender, EventArgs e)
        {
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
            
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrunAD.Text!=""&&txtToplam.Text!=""&&txtFiyat.Text!=""&&txtKDV.Text!=""&&lookUpEditBirim.Text!=""&&lookUpEditDurum.Text!=""&&lookUpEditUrunGrup.Text!="")
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
    }
}
