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
using System.Globalization;

namespace OtelProjesi.Formlar.Misafir
{
    public partial class FrmMisafirListesi : Form
    {
        public FrmMisafirListesi()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        private void FrmMisafirListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLMISAFIR
                                       select new
                                       {
                                           x.MISAFIRID,
                                           x.ADSOYAD,
                                           x.TC,
                                           x.TELEFON,
                                           x.MAIL,
                                           x.iller.sehir,
                                           x.ilceler.ilce
                                       }).ToList();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmMisafirKart frm = new FrmMisafirKart();
            frm.id = int.Parse(gridView1.GetFocusedRowCellValue("MISAFIRID").ToString());
            frm.Show();
        }
    }
}
