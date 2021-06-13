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

namespace OtelProjesi
{
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            db.TBLDEPARTMAN.Load();
            bindingSource1.DataSource = db.TBLDEPARTMAN.Local;

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

                MessageBox.Show("Lütfen Değerleri Kontrol Edip Tekrar Deneyin", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
        }
    }
}
