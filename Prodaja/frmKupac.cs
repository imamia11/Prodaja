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
    public partial class frmKupac : Form
    {
        AccessData data;
        int val;
        public frmKupac()
        {
            InitializeComponent();
            data = new AccessData();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (textBoxIme.Text != "")
            {
                val = data.insertKupac(textBoxIme.Text, textBoxAdresa.Text, textBoxTel.Text);
            }
            else
            {
                MessageBox.Show("Upisite barem ime kupca", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (val == 1)
            {
                MessageBox.Show("Uspjesno spremljen kupac", "Spremljeno!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxIme.Text = "";
                textBoxAdresa.Text = "";
                textBoxTel.Text = "";
                //this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("Podaci nisu spremljeni u bazu", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxIme.Text = "";
                textBoxAdresa.Text = "";
                textBoxTel.Text = "";
            }
        }

        private void textBoxTel_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBoxTel.Text.Length.ToString();

            if (textBoxTel.Text.Length > 15)
            {
                MessageBox.Show("Broj premasuje duljinu od 15 znamenaka!");
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBoxIme.Text = "";
            textBoxAdresa.Text = "";
            textBoxTel.Text = "";
        }


        
    }
}
