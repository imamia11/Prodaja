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
    public partial class frmArtikal : Form
    {
        AccessData data;

        public frmArtikal()
        {
            InitializeComponent();
            data = new AccessData();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (textBoxNaziv.Text != "" && textBoxNabava.Text != "" && textBoxTrosak.Text != "" && textBoxCijena.Text != "")
            {
                int val = data.insertArtikal(textBoxNaziv.Text, dateTimePicker1.Value.Date, Decimal.Parse(textBoxNabava.Text), Decimal.Parse(textBoxTrosak.Text), Decimal.Parse(textBoxCijena.Text), Decimal.Parse(textBoxProfit.Text));

                if (val == 1)
                {
                    MessageBox.Show("Uspjesno spremljeno", "Spremljeno!", MessageBoxButtons.OK);
                    textBoxNaziv.Text = "";
                    textBoxNabava.Text = "";
                    textBoxTrosak.Text = "";
                    textBoxCijena.Text = "";
                    textBoxProfit.Text = "";

                    this.Close();
                }

                else if (val == 3)
                {
                    MessageBox.Show("Naziv artikla vec postoji u bazi", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxNaziv.Text = "";
                }

                else
                {
                    MessageBox.Show("Nastala je greska prilikom unosa novog artikla", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxNaziv.Text = "";
                    textBoxNabava.Text = "";
                    textBoxTrosak.Text = "";
                    textBoxCijena.Text = "";
                    textBoxProfit.Text = "";
                }
            }

            else
            {
                MessageBox.Show("Niste ispunili sva polja...", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNaziv.Text = "";
                textBoxNabava.Text = "";
                textBoxTrosak.Text = "";
                textBoxCijena.Text = "";
                textBoxProfit.Text = "";
            }

        }

        private void textBoxCijena_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxCijena.Text != "")
                {
                    decimal total = (Decimal.Parse(textBoxNabava.Text) + Decimal.Parse(textBoxTrosak.Text));
                    textBoxProfit.Text = (Decimal.Parse(textBoxCijena.Text) - total).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBoxNaziv.Text = "";
            textBoxNabava.Text = "";
            textBoxTrosak.Text = "";
            textBoxCijena.Text = "";
            textBoxProfit.Text = "";
        }


    }    
}
