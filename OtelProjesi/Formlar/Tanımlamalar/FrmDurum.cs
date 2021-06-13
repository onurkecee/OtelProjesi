using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelProjesi.Entity;

namespace OtelProjesi.Formlar.Tanımlamalar
{
    public partial class FrmDurum : Form
    {
        public FrmDurum()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        private void FrmDurum_Load(object sender, EventArgs e)
        {
            //var durumlar = (from x in db.TBLDURUM
            //                select new
            //                {
            //                    x.DURUMID,
            //                    x.DURUMAD
            //                });
            //gridControl1.DataSource = durumlar.ToList();

            db.TBLDURUM.Load();
            bindingSource1.DataSource = db.TBLDURUM.Local;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Değerleri Kontrol Edip Tekrar Deneyin", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void durumuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
