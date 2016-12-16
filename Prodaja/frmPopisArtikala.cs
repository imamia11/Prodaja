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
    public partial class frmPopisArtikala : Form
    {
        AccessData data;

        public frmPopisArtikala()
        {
            InitializeComponent();
            data = new AccessData();
        }

        private void frmPopisArtikala_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = data.sviArtikli();
            dataGridView2.Columns[0].Visible = false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.Refresh();

            dataGridView2.DataSource = data.popuniPoPretraziArtikal(textBoxSearch.Text);
            dataGridView2.Columns[0].Visible = false;
        }

        private void bShowAll_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = data.sviArtikli();
            dataGridView2.Columns[0].Visible = false;
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            try
            { 
                data.azuriraj();
                dataGridView2.Refresh();
                MessageBox.Show("Uspjesno azurirano", "Uspjeh!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxSearch.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Greska!");
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rez = MessageBox.Show("Jeste li sigurni da zelite izbrisati oznaceni artikl?", "Potvrda", MessageBoxButtons.OKCancel);

                if (rez.Equals(DialogResult.OK))
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                    data.azuriraj();
                }
                else
                {
                    return;
                }
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
