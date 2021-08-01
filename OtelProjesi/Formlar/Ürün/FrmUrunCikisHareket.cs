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

namespace OtelProjesi.Formlar.Ürün
{
    public partial class FrmUrunCikisHareket : Form
    {
        public FrmUrunCikisHareket()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunCikisHareket_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLURUNHAREKET
                                       select new
                                       {
                                           x.HAREKETID,
                                           x.TBLURUN.URUNAD,
                                           x.MIKTAR,
                                           x.TARIH,
                                           x.HAREKETTURU
                                       }).Where(y => y.HAREKETTURU == "Çıkış").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmUrunHareketTanimi frm = new FrmUrunHareketTanimi();
            frm.id = int.Parse(gridView1.GetFocusedRowCellValue("HAREKETID").ToString());
            frm.Show();
        }
    }
}
