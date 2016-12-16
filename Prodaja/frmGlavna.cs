using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prodaja
{
    public partial class frmGlavna : Form
    {
        public frmGlavna()
        {
            InitializeComponent();
        }

        private void bKupac_Click(object sender, EventArgs e)
        {
            frmKupac kupac = new frmKupac();
            kupac.Show();
        }

        private void bArtikal_Click(object sender, EventArgs e)
        {
            frmArtikal artikal = new frmArtikal();
            artikal.Show();
        }

        private void bIsporuka_Click(object sender, EventArgs e)
        {
            frmIsporuka isporuka = new frmIsporuka();
            isporuka.Show();
        }

        private void bIsporuceno_Click(object sender, EventArgs e)
        {
            frmIsporuceno isp = new frmIsporuceno();
            isp.Show();
        }

        private void bPopisArtikala_Click(object sender, EventArgs e)
        {
            frmPopisArtikala popisA = new frmPopisArtikala();
            popisA.Show();
        }

        private void bPopisKupaca_Click(object sender, EventArgs e)
        {
            frmPopisKupaca popisK = new frmPopisKupaca();
            popisK.Show();
        }

        private void bStatistika_Click(object sender, EventArgs e)
        {
            frmStatistika stats = new frmStatistika();
            stats.Show();
        }
    
    }
}
