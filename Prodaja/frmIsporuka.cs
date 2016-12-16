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
    public partial class frmIsporuka : Form
    {
        AccessData data;       

        public frmIsporuka()
        {
            InitializeComponent();
            data = new AccessData();
        }

        private void frmIsporuka_Load(object sender, EventArgs e)
        {
            comboBoxArtikal.DataSource = data.getNazivArtikala();
            comboBoxKupac.DataSource = data.getImenaKupaca();
            
        }

        private void comboBoxArtikal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxCijena.Text = data.showCijena(comboBoxArtikal.SelectedItem.ToString()).ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.ToString());
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                int val = 0;
                

                if (textBoxCijena.Text != "")
                {
                    val = data.kreirajIsporuku(comboBoxArtikal.SelectedItem.ToString(), comboBoxKupac.SelectedItem.ToString(), Double.Parse(textBoxCijena.Text), dateTimePicker2.Value.Date);
                    if (val == 1)
                    {
                        MessageBox.Show("Uspjesno isporuceno", "Isporuceno!", MessageBoxButtons.OK);
                        textBoxCijena.Text = "";
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom spremanja u bazu", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Greska!", "Greska!", MessageBoxButtons.OK);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            comboBoxArtikal.Text = "";
            comboBoxKupac.Text = "";
            textBoxCijena.Text = "";
        }

        private void bNoviArt_Click(object sender, EventArgs e)
        {
            frmArtikal artikal = new frmArtikal();
            artikal.ShowDialog();
        }

        private void bNoviKup_Click(object sender, EventArgs e)
        {
            frmKupac kupac = new frmKupac();
            kupac.ShowDialog();
        }


        private void comboBoxArtikal_DropDown(object sender, EventArgs e)
        {
            this.comboBoxArtikal.Refresh();
            this.comboBoxArtikal.DataSource = data.getNazivArtikala();
            this.textBoxCijena.Text = data.showCijena(comboBoxArtikal.SelectedItem.ToString()).ToString();
        }

        private void comboBoxKupac_DropDown(object sender, EventArgs e)
        {
            this.comboBoxKupac.Refresh();
            this.comboBoxKupac.DataSource = data.getImenaKupaca();
        }
       
    }
}
