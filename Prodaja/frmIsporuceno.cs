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
    public partial class frmIsporuceno : Form
    {
        AccessData data;
        public frmIsporuceno()
        {
            InitializeComponent();
            data = new AccessData();
        }

        private void frmIsporuceno_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data.sveIsporuke();
            textBoxTotalProfit.Text = data.totalProfit().ToString();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data.popuniPoPretrazi(textBoxSearch.Text);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data.popuniPoPretrazi(textBoxSearch.Text);
        }





    }
}
