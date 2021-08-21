using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelProjesi.Entity;
using OtelProjesi.Repositories;
using System.Data.Sql;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace OtelProjesi.Formlar.Rezervasyon
{
    public partial class FrmRezervasyonKarti : Form
    {
        public FrmRezervasyonKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();
        Repository<TBLREZERVASYON> repo = new Repository<TBLREZERVASYON>();
        TBLREZERVASYON t = new TBLREZERVASYON();
        public int id;

        private void FrmRezervasyonKarti_Load(object sender, EventArgs e)
        {
            lookUpEditMusteri.Properties.DataSource = (from x in db.TBLMISAFIR
                                                       select new
                                                       {
                                                           x.MISAFIRID,
                                                           x.ADSOYAD
                                                       }).ToList();

            lookUpEditOda.Properties.DataSource = (from x in db.TBLODA
                                                   select new
                                                   {
                                                       x.ODAID,
                                                       x.ODANUMARASI,
                                                       x.TBLDURUM.DURUMAD
                                                   }).Where(y => y.DURUMAD == "Aktif").ToList();

            lookUpEditDurum.Properties.DataSource = (from x in db.TBLDURUM
                                                     select new
                                                     {
                                                         x.DURUMID,
                                                         x.DURUMAD
                                                     }).ToList();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditDurum.Text != "" && lookUpEditMusteri.Text != "" && lookUpEditOda.Text != "" && txtKisiSayisi.Value.ToString() != "" && dateGirisTarih.Text != "" && dateCikisTarih.Text != "" && txtAdSoyad.Text != "" && txtTelefon.Text != "")
                {
                    t.MISAFIR = int.Parse(lookUpEditMusteri.EditValue.ToString());
                    t.GIRISTARIH = DateTime.Parse(dateGirisTarih.Text);
                    t.CIKISTARIH = DateTime.Parse(dateCikisTarih.Text);
                    t.KISISAYISI = txtKisiSayisi.Value.ToString();
                    t.ODA = int.Parse(lookUpEditOda.EditValue.ToString());
                    t.REZERVASYONADSOYAD = txtAdSoyad.Text;
                    t.TELEFON = txtTelefon.Text;
                    t.ACIKLAMA = txtAciklama.Text;
                    t.DURUM = int.Parse(lookUpEditDurum.EditValue.ToString());
                    repo.TAdd(t);
                    XtraMessageBox.Show("Oda Başarılı Bir Şekilde Sisteme Kaydedildi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    XtraMessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (SqlException ex)
            {

                XtraMessageBox.Show(ex.Message);
            }

        }
    }
}
