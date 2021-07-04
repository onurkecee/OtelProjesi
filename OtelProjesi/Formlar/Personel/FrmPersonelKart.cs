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

        private void FrmPersonelKart_Load(object sender, EventArgs e)
        {
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
            Repository<TBLPERSONEL> repo = new Repository<TBLPERSONEL>();
            TBLPERSONEL t = new TBLPERSONEL();
            t.ADSOYAD = txtAdSoyad.Text;
            t.TC = txtTc.Text;
            t.TELEFON = txtTelefon.Text;
            t.ISEGIRISTARIH = DateTime.Parse(dateEditGiris.Text);
            t.DEPARTMAN = int.Parse(lookUpEditDepartman.EditValue.ToString());
            t.GOREV = int.Parse(lookUpEditGorev.EditValue.ToString());
            t.ACIKLAMA = txtAciklama.Text;
            t.DURUM = 1;
            repo.TAdd(t);
            XtraMessageBox.Show("Personel Başarıyla Kaydedildi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
