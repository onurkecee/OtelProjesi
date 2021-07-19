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

namespace OtelProjesi.Formlar.Personel
{
    public partial class FrmPersonelListesi : Form
    {
        public FrmPersonelListesi()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        private void FrmPersonelListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLPERSONEL
                                       select new
                                       {
                                           x.PERSONELID,
                                           x.ADSOYAD,
                                           x.TC,
                                           x.TELEFON,
                                           x.MAIL,
                                           x.TBLDEPARTMAN.DEPARTMANAD,
                                           x.TBLGOREV.GOREVAD,
                                           x.TBLDURUM.DURUMAD
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmPersonelKart frm = new FrmPersonelKart();
            frm.id = int.Parse(gridView1.GetFocusedRowCellValue("PERSONELID").ToString());
            frm.Show();
        }
    }
}
