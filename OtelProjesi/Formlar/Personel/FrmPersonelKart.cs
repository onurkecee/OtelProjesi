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
    }
}
