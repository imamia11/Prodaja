using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Prodaja.DAL
{
    class AccessData:IDisposable
    {
        private OleDbConnection conn;
        public OleDbDataAdapter ad;  
        public DataTable dataTable;  
        
        
        public AccessData()
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Prodaja.accdb");
        }

        public void Dispose()
        {
            conn.Dispose();
            ad.Dispose();
        }

        //----------frmArtikal
        public bool checkArtikal(string naziv)
        {
            bool check;
            int val;
            OleDbCommand commd = new OleDbCommand("SELECT COUNT(*) FROM Artikal WHERE Naziv_artikla=@naziv", conn);
            commd.Parameters.Add(@naziv, OleDbType.VarChar).Value = naziv;
            conn.Open();

            val = (int)commd.ExecuteScalar();

            if (val <= 0)
            {
                check = false;
            }

            else 
            {
                check = true;
            }

            conn.Close();

            return check;
        }

        public int insertArtikal(string naziv, DateTime datum, decimal nabCijena, decimal trosak, decimal prodCijena, decimal profit)
        {
            int num_rows = 0;

            bool tr = checkArtikal(naziv);

            if (!tr)
            {
                ad = new OleDbDataAdapter();
                ad.InsertCommand = new OleDbCommand("Insert into Artikal(Naziv_artikla,Datum_dobave,Nabavna_cijena,Zavisan_trosak,Prodajna_cijena,Profit) values(@naziv,@datum,@nabCijena,@trosak,@prodCijena,@profit)", conn);
                ad.InsertCommand.Parameters.Add("@naziv", OleDbType.VarChar).Value = naziv;
                ad.InsertCommand.Parameters.Add("@datum", OleDbType.Date).Value = datum;
                ad.InsertCommand.Parameters.Add("@nabCijena", OleDbType.Decimal).Value = nabCijena;
                ad.InsertCommand.Parameters.Add("@trosak", OleDbType.Decimal).Value = trosak;
                ad.InsertCommand.Parameters.Add("@prodCijena", OleDbType.Decimal).Value = prodCijena;
                ad.InsertCommand.Parameters.Add("@profit", OleDbType.Decimal).Value = prodCijena - (nabCijena + trosak);

                conn.Open();
                num_rows = ad.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                num_rows = 3;
            }

            return num_rows;
        }

        //-------frmKupac-------
        public bool checkKupac(string ime)
        {
            bool check;
            int val;
            OleDbCommand commd = new OleDbCommand("SELECT COUNT(*) FROM Kupac WHERE Ime_kupca=@ime", conn);
            commd.Parameters.Add(@ime, OleDbType.VarChar).Value = ime;
            conn.Open();

            val = (int)commd.ExecuteScalar();

            if (val <= 0)
            {
                check = false;
            }

            else
            {
                check = true;
            }

            conn.Close();

            return check;
        }

        public int insertKupac(string ime, string adresa, string tel)
        {
            int num_rows = 0;
            bool tr = checkKupac(ime);
        
            if (!tr)
            {
                ad = new OleDbDataAdapter();
                ad.InsertCommand = new OleDbCommand("Insert into Kupac(Ime_kupca,Adresa,Broj_tel) values(@ime,@adresa,@tel)", conn);
                ad.InsertCommand.Parameters.Add("@ime", OleDbType.VarChar).Value = ime;
                ad.InsertCommand.Parameters.Add("@adresa", OleDbType.VarChar).Value = adresa;
                ad.InsertCommand.Parameters.Add("@tel", OleDbType.VarChar).Value = tel;

                conn.Open();
                num_rows = ad.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Kupac vec postoji u bazi", "Greska!");
            }
            return num_rows;
        }
        //-------frmIsporuka-------
        public List<string> getNazivArtikala()
        {
            List<String> lista = new List<string>();

            OleDbCommand commd = new OleDbCommand("Select Naziv_artikla from Artikal", conn);
            DataTable dt = new DataTable();
            ad = new OleDbDataAdapter(commd);
            ad.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(dr["Naziv_artikla"].ToString());
            }

            return lista;
        }

        public List<string> getImenaKupaca()
        {
            List<String> lista = new List<string>();

            OleDbCommand commd = new OleDbCommand("Select Ime_kupca from Kupac", conn);
            DataTable dt = new DataTable();
            ad = new OleDbDataAdapter(commd);
            ad.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(dr["Ime_kupca"].ToString());
            }

            return lista;
        
        }

        public int kreirajIsporuku(string artikal, string kupac, double cijena, DateTime datum)
        {
            int num_rows = 0;
            
            ad = new OleDbDataAdapter();
            ad.InsertCommand = new OleDbCommand("Insert into Isporuka(Artikal_ID, Kupac_ID, Cijena, Datum_isporuke) values(@artikal, @kupac, @cijena, @datum)", conn);
            ad.InsertCommand.Parameters.Add("@artikal", OleDbType.Integer).Value = getAid(artikal);
            ad.InsertCommand.Parameters.Add("@kupac", OleDbType.Integer).Value = getKid(kupac);
            ad.InsertCommand.Parameters.Add("@cijena", OleDbType.Double).Value = cijena;
            ad.InsertCommand.Parameters.Add("@datum", OleDbType.Date).Value = datum;

            conn.Open();
            
            num_rows = ad.InsertCommand.ExecuteNonQuery();

            conn.Close();

            return num_rows;
        }

        public int getAid(string art)
        {
            int id = 0;
            OleDbCommand commd = new OleDbCommand("Select Artikal_ID from Artikal where Naziv_artikla='" + art + "'", conn);
            conn.Open();
            id = (int)commd.ExecuteScalar();
            conn.Close();
            return id;
        }

        public int getKid(string kup)
        {
            int id = 0;
            OleDbCommand commd = new OleDbCommand("Select Kupac_ID from Kupac where Ime_kupca='" + kup + "'", conn);
            conn.Open();
            id = (int)commd.ExecuteScalar();
            conn.Close();
            return id;
        }

        public int showCijena(string naziv_art)
        {
            int cijena;

            OleDbCommand commd = new OleDbCommand("Select Prodajna_cijena from Artikal where Naziv_artikla='" + naziv_art + "'", conn);
            conn.Open();

            try
            {
                cijena = (int)commd.ExecuteScalar();
                conn.Close();
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString(), "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cijena = 0;
            }

            return cijena;
        }
   

    //---------Isporuceno------------
       

     
        
        public DataTable popuniPoPretrazi(string naziv)
        {
            string qry = "SELECT a.Naziv_artikla, k.Ime_kupca, k.Adresa, k.Broj_tel, i.Datum_isporuke, i.Cijena, a.Profit FROM Kupac k, Isporuka i, Artikal a WHERE a.Artikal_ID=i.Artikal_ID AND k.Kupac_ID=i.Kupac_ID AND a.Naziv_artikla like '" + naziv + "%'";
            OleDbCommand commd = new OleDbCommand(qry, conn);
            DataTable dt = new DataTable();
            ad = new OleDbDataAdapter(commd);
            ad.Fill(dt);
            return dt;
        }

        public BindingSource sveIsporuke()
        {
            conn.Open();
            ad = new OleDbDataAdapter("SELECT a.Naziv_artikla, k.Ime_kupca, k.Adresa, k.Broj_tel, i.Datum_isporuke, i.Cijena, a.Profit FROM Kupac k, Artikal a, Isporuka i WHERE a.Artikal_ID=i.Artikal_ID AND k.Kupac_ID=i.Kupac_ID ORDER BY i.Datum_isporuke DESC", conn);
            OleDbCommandBuilder com = new OleDbCommandBuilder(ad);
            dataTable = new DataTable();
            ad.Fill(dataTable);
            BindingSource bss = new BindingSource();
            bss.DataSource = dataTable;
            conn.Close();

            return bss;
        }

       

        public decimal totalProfit()
        {
            decimal total;

            OleDbCommand commd = new OleDbCommand("Select sum(Cijena) from Isporuka", conn);
            conn.Open();

            try
            {
                total = (decimal)commd.ExecuteScalar();
                conn.Close();
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString(), "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                total = 0;
            }

            return total;
        }

        //----------frmPopisArtikala-------

        public DataTable popuniPoPretraziArtikal(string nazivArt)
        {
            string qry = "Select * from Artikal where Naziv_Artikla like '" + nazivArt + "%'";
            OleDbCommand commd = new OleDbCommand(qry, conn);
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter(commd);
            ad.Fill(dt);
            return dt;
        }

        public BindingSource sviArtikli()
        {
            conn.Open();

            ad = new OleDbDataAdapter("Select * from Artikal", conn);
            OleDbCommandBuilder commd = new OleDbCommandBuilder(ad);

            dataTable = new DataTable();
            ad.Fill(dataTable);
            BindingSource bs = new BindingSource();
            bs.DataSource = dataTable;
            conn.Close();
            return bs;

        }

        public void azuriraj()
        {
            if (ad != null)
            {
                ad.Update(dataTable);
            }
            else
            {
                MessageBox.Show("Greska", "Greska!");
            }
        }

        //-------frmPopisKupaca------


        public DataTable popuniPoPretraziKupac(string imeKup)
        {
            string qry = "Select * from Kupac where Ime_kupca like '" + imeKup + "%'";
            OleDbCommand commd = new OleDbCommand(qry, conn);
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter(commd);
            ad.Fill(dt);
            return dt;
        }

        public BindingSource sviKupci()
        {
            conn.Open();

            ad = new OleDbDataAdapter("Select * from Kupac", conn);
            OleDbCommandBuilder commd = new OleDbCommandBuilder(ad);

            dataTable = new DataTable();
            ad.Fill(dataTable);
            BindingSource bs = new BindingSource();
            bs.DataSource = dataTable;
            conn.Close();
            return bs;

        }

        //-------frmStatistika------

        public DataTable popuniGrafikon()
        {
            string qry = "SELECT a.Naziv_artikla, SUM(a.Profit) FROM Artikal a, Isporuka i, Kupac k WHERE a.Artikal_ID=i.Artikal_ID AND k.Kupac_ID=i.Kupac_ID GROUP BY a.Naziv_artikla";
            OleDbCommand commd = new OleDbCommand(qry, conn);
            DataTable dt = new DataTable();
            ad = new OleDbDataAdapter(commd);
            ad.Fill(dt);

            return dt;
        }

        public DataTable popuniGrafikonPoDatumu(DateTime from, DateTime to)
        {
            string qry = "SELECT a.Naziv_artikla, SUM(a.profit) FROM Artikal a, Isporuka i, Kupac k WHERE a.Artikal_ID=i.Artikal_ID AND k.Kupac_ID=i.Kupac_ID AND i.Datum_isporuke BETWEEN @from AND @to GROUP BY a.Naziv_artikla";
            OleDbCommand commd = new OleDbCommand(qry, conn);
            commd.Parameters.Add("@from", OleDbType.Date).Value = from;
            commd.Parameters.Add("@to", OleDbType.Date).Value = to;

            DataTable dt = new DataTable();
            ad = new OleDbDataAdapter(commd);
            ad.Fill(dt);

            return dt;
        }

      

    }
}
