using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodaja.DAL;

namespace Prodaja
{
    public partial class frmStatistika : Form
    {
        AccessData data;      
        public frmStatistika()
        {
            InitializeComponent();
            data = new AccessData();
        }

        private void frmStatistika_Load(object sender, EventArgs e)
        {
            DataTable dt = data.popuniGrafikon();
            chart1.DataSource = dt;
            chart1.Series[0].XValueMember = dt.Columns[0].ToString();
            chart1.Series[0].YValueMembers = dt.Columns[1].ToString();
            chart1.DataBind();
        }

        private void bfilter_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date != dateTimePicker2.Value.Date)
            {
                DataTable dt = data.popuniGrafikonPoDatumu(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                chart1.DataSource = dt;
                chart1.Series[0].XValueMember = dt.Columns[0].ToString();
                chart1.Series[0].YValueMembers = dt.Columns[1].ToString();
                chart1.DataBind();
            }
            else
            {
                MessageBox.Show("Izaberite dva razlicita datuma", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       
    }
}
