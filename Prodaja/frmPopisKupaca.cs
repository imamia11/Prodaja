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
    public partial class frmPopisKupaca : Form
    {
        AccessData data;

        public frmPopisKupaca()
        {
            InitializeComponent();
            data = new AccessData();
        }

        private void frmPopisKupaca_Load(object sender, EventArgs e)
        {
            dataGridView3.DataSource = data.sviKupci();
            dataGridView3.Columns[0].Visible = false;
        }

        private void bShowAll_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = data.sviKupci();
            dataGridView3.Columns[0].Visible = false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.Refresh();
            dataGridView3.DataSource = data.popuniPoPretraziKupac(textBoxSearch.Text);
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                data.azuriraj();
                dataGridView3.Refresh();
                MessageBox.Show("Uspjeh");
                textBoxSearch.Text = "";
            }

            catch (Exception ex) 
            {
                MessageBox.Show("Greska prilikom azuriranja", "Greska");
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rez = MessageBox.Show("Jeste li sigurni da zelite izbrisati oznacenog kupca?", "Potvrda", MessageBoxButtons.OKCancel);

                if (rez.Equals(DialogResult.OK))
                {
                    dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
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
