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

namespace OtelProjesi.Formlar.Rezervasyon
{
    public partial class FrmGecmisRezervasyonlar : Form
    {
        public FrmGecmisRezervasyonlar()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmGecmisRezervasyonlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLREZERVASYON
                                       select new
                                       {
                                           x.REZERVASYONID,
                                           x.TBLMISAFIR.ADSOYAD,
                                           x.GIRISTARIH,
                                           x.CIKISTARIH,
                                           x.KISISAYISI,
                                           x.TBLODA.ODANUMARASI,
                                           x.TELEFON,
                                           x.TBLDURUM.DURUMAD
                                       }).Where(y => y.DURUMAD == "Çıkış Yapıldı").ToList();
        }
    }
}
