namespace Prodaja
{
    partial class frmIsporuka
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIsporuka));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxArtikal = new System.Windows.Forms.ComboBox();
            this.comboBoxKupac = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBoxCijena = new System.Windows.Forms.TextBox();
            this.bNoviArt = new System.Windows.Forms.Button();
            this.bNoviKup = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv Artikla";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(27, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ime Kupca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(27, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum Isporuke";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(27, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Prodajna cijena ";
            // 
            // comboBoxArtikal
            // 
            this.comboBoxArtikal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxArtikal.FormattingEnabled = true;
            this.comboBoxArtikal.Location = new System.Drawing.Point(174, 33);
            this.comboBoxArtikal.Name = "comboBoxArtikal";
            this.comboBoxArtikal.Size = new System.Drawing.Size(179, 24);
            this.comboBoxArtikal.TabIndex = 4;
            this.comboBoxArtikal.DropDown += new System.EventHandler(this.comboBoxArtikal_DropDown);
            this.comboBoxArtikal.TextChanged += new System.EventHandler(this.comboBoxArtikal_TextChanged);
            // 
            // comboBoxKupac
            // 
            this.comboBoxKupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxKupac.FormattingEnabled = true;
            this.comboBoxKupac.Location = new System.Drawing.Point(174, 82);
            this.comboBoxKupac.Name = "comboBoxKupac";
            this.comboBoxKupac.Size = new System.Drawing.Size(179, 24);
            this.comboBoxKupac.TabIndex = 5;
            this.comboBoxKupac.DropDown += new System.EventHandler(this.comboBoxKupac_DropDown);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker2.Location = new System.Drawing.Point(174, 133);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(179, 22);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // textBoxCijena
            // 
            this.textBoxCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCijena.Location = new System.Drawing.Point(174, 186);
            this.textBoxCijena.Name = "textBoxCijena";
            this.textBoxCijena.ReadOnly = true;
            this.textBoxCijena.Size = new System.Drawing.Size(100, 22);
            this.textBoxCijena.TabIndex = 7;
            // 
            // bNoviArt
            // 
            this.bNoviArt.Location = new System.Drawing.Point(377, 33);
            this.bNoviArt.Name = "bNoviArt";
            this.bNoviArt.Size = new System.Drawing.Size(85, 24);
            this.bNoviArt.TabIndex = 8;
            this.bNoviArt.Text = "Novi Artikal";
            this.bNoviArt.UseVisualStyleBackColor = true;
            this.bNoviArt.Click += new System.EventHandler(this.bNoviArt_Click);
            // 
            // bNoviKup
            // 
            this.bNoviKup.Location = new System.Drawing.Point(377, 82);
            this.bNoviKup.Name = "bNoviKup";
            this.bNoviKup.Size = new System.Drawing.Size(85, 25);
            this.bNoviKup.TabIndex = 9;
            this.bNoviKup.Text = "Novi Kupac";
            this.bNoviKup.UseVisualStyleBackColor = true;
            this.bNoviKup.Click += new System.EventHandler(this.bNoviKup_Click);
            // 
            // bClear
            // 
            this.bClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClear.Location = new System.Drawing.Point(174, 259);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(86, 38);
            this.bClear.TabIndex = 10;
            this.bClear.Text = "Očisti";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bClose
            // 
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bClose.Location = new System.Drawing.Point(30, 259);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(86, 38);
            this.bClose.TabIndex = 11;
            this.bClose.Text = "Zatvori";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Location = new System.Drawing.Point(362, 247);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 60);
            this.bSave.TabIndex = 12;
            this.bSave.Text = "Spremi";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Kn";
            // 
            // frmIsporuka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 331);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bNoviKup);
            this.Controls.Add(this.bNoviArt);
            this.Controls.Add(this.textBoxCijena);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.comboBoxKupac);
            this.Controls.Add(this.comboBoxArtikal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIsporuka";
            this.Text = "Kreiraj Isporuku";
            this.Load += new System.EventHandler(this.frmIsporuka_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxArtikal;
        private System.Windows.Forms.ComboBox comboBoxKupac;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBoxCijena;
        private System.Windows.Forms.Button bNoviArt;
        private System.Windows.Forms.Button bNoviKup;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label label5;
    }
}