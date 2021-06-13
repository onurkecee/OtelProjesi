using OtelProjesi.Entity;
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

namespace OtelProjesi.Formlar.Tanımlamalar
{
    public partial class FrmTelefon : Form
    {
        public FrmTelefon()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        private void FrmTelefon_Load(object sender, EventArgs e)
        {
            db.TBLTELEFON.Load();
            bindingSource1.DataSource = db.TBLTELEFON.Local;

            repositoryItemLookUpEditDurum.DataSource = (from x in db.TBLDURUM
                                                        select new
                                                        {
                                                            x.DURUMID,
                                                            x.DURUMAD
                                                        }).ToList();
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

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }
    }
}
