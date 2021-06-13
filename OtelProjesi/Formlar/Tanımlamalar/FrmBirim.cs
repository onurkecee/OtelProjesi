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
    public partial class FrmBirim : Form
    {
        public FrmBirim()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();

        private void FrmBirim_Load(object sender, EventArgs e)
        {
            db.TBLBIRIM.Load();
            bindingSource1.DataSource = db.TBLBIRIM.Local;

            repositoryItemLookUpEditDurum.DataSource = (from x in db.TBLDURUM
                                                        select new
                                                        {
                                                            x.DURUMID,
                                                            x.DURUMAD
                                                        }).ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
