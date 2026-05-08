namespace Gestione_Magazzino
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabMerci = new TabPage();
            dgvMerci = new DataGridView();
            txtIdMerce = new TextBox();
            txtDescrizione = new TextBox();
            txtPrezzo = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tabAcquirenti = new TabPage();
            txtPartitaIva = new TextBox();
            txtRagioneSociale = new TextBox();
            txtIndirizzoAcquirente = new TextBox();
            cmbComuniAcquirente = new ComboBox();
            btnSalvaAcquirente = new Button();
            tabMagazzino = new TabPage();
            cmbMerciMagazzino = new ComboBox();
            txtNomeMagazzino = new TextBox();
            txtQuantitaMagazzino = new TextBox();
            btnStoccaMerce = new Button();
            tabFatture = new TabPage();
            txtNumeroFattura = new TextBox();
            dtpDataFattura = new DateTimePicker();
            cmbAcquirentiFattura = new ComboBox();
            cmbMerciFattura = new ComboBox();
            txtQuantitaFattura = new TextBox();
            btnAggiungiRigaCarrello = new Button();
            dgvRigheFatturaProvvisoria = new DataGridView();
            btnEmettiFatturaFinale = new Button();
            tabStorico = new TabPage();
            cmbFiltroAcquirente = new ComboBox();
            dgvFattureAcquirente = new DataGridView();
            tabComuni = new TabPage();
            dgvComuni = new DataGridView();
            txtCap = new TextBox();
            txtCitta = new TextBox();
            txtProvincia = new TextBox();
            btnSalvaComune = new Button();
            tabControl1.SuspendLayout();
            tabMerci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMerci).BeginInit();
            tabAcquirenti.SuspendLayout();
            tabMagazzino.SuspendLayout();
            tabFatture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRigheFatturaProvvisoria).BeginInit();
            tabStorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFattureAcquirente).BeginInit();
            tabComuni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComuni).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabMerci);
            tabControl1.Controls.Add(tabAcquirenti);
            tabControl1.Controls.Add(tabMagazzino);
            tabControl1.Controls.Add(tabFatture);
            tabControl1.Controls.Add(tabStorico);
            tabControl1.Controls.Add(tabComuni);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 600);
            tabControl1.TabIndex = 0;
            // 
            // tabMerci
            // 
            tabMerci.Controls.Add(dgvMerci);
            tabMerci.Controls.Add(txtIdMerce);
            tabMerci.Controls.Add(txtDescrizione);
            tabMerci.Controls.Add(txtPrezzo);
            tabMerci.Controls.Add(button1);
            tabMerci.Controls.Add(button2);
            tabMerci.Controls.Add(button3);
            tabMerci.Location = new Point(4, 29);
            tabMerci.Name = "tabMerci";
            tabMerci.Size = new Size(992, 567);
            tabMerci.TabIndex = 0;
            tabMerci.Text = "Gestione Merci";
            // 
            // dgvMerci
            // 
            dgvMerci.ColumnHeadersHeight = 29;
            dgvMerci.Location = new Point(20, 20);
            dgvMerci.Name = "dgvMerci";
            dgvMerci.RowHeadersWidth = 51;
            dgvMerci.Size = new Size(600, 400);
            dgvMerci.TabIndex = 0;
            dgvMerci.CellContentClick += dgvMerci_CellContentClick;
            // 
            // txtIdMerce
            // 
            txtIdMerce.Location = new Point(650, 50);
            txtIdMerce.Name = "txtIdMerce";
            txtIdMerce.Size = new Size(100, 27);
            txtIdMerce.TabIndex = 1;
            // 
            // txtDescrizione
            // 
            txtDescrizione.Location = new Point(650, 100);
            txtDescrizione.Name = "txtDescrizione";
            txtDescrizione.Size = new Size(100, 27);
            txtDescrizione.TabIndex = 2;
            // 
            // txtPrezzo
            // 
            txtPrezzo.Location = new Point(650, 150);
            txtPrezzo.Name = "txtPrezzo";
            txtPrezzo.Size = new Size(100, 27);
            txtPrezzo.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(650, 200);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Aggiungi";
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(650, 240);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Aggiorna";
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(650, 280);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Elimina";
            button3.Click += button3_Click;
            // 
            // tabAcquirenti
            // 
            tabAcquirenti.Controls.Add(txtPartitaIva);
            tabAcquirenti.Controls.Add(txtRagioneSociale);
            tabAcquirenti.Controls.Add(txtIndirizzoAcquirente);
            tabAcquirenti.Controls.Add(cmbComuniAcquirente);
            tabAcquirenti.Controls.Add(btnSalvaAcquirente);
            tabAcquirenti.Location = new Point(4, 29);
            tabAcquirenti.Name = "tabAcquirenti";
            tabAcquirenti.Size = new Size(992, 567);
            tabAcquirenti.TabIndex = 1;
            tabAcquirenti.Text = "Acquirenti";
            // 
            // txtPartitaIva
            // 
            txtPartitaIva.Location = new Point(20, 30);
            txtPartitaIva.Name = "txtPartitaIva";
            txtPartitaIva.PlaceholderText = "Partita IVA";
            txtPartitaIva.Size = new Size(100, 27);
            txtPartitaIva.TabIndex = 0;
            // 
            // txtRagioneSociale
            // 
            txtRagioneSociale.Location = new Point(20, 70);
            txtRagioneSociale.Name = "txtRagioneSociale";
            txtRagioneSociale.PlaceholderText = "Ragione Sociale";
            txtRagioneSociale.Size = new Size(100, 27);
            txtRagioneSociale.TabIndex = 1;
            // 
            // txtIndirizzoAcquirente
            // 
            txtIndirizzoAcquirente.Location = new Point(20, 110);
            txtIndirizzoAcquirente.Name = "txtIndirizzoAcquirente";
            txtIndirizzoAcquirente.PlaceholderText = "Indirizzo";
            txtIndirizzoAcquirente.Size = new Size(100, 27);
            txtIndirizzoAcquirente.TabIndex = 2;
            // 
            // cmbComuniAcquirente
            // 
            cmbComuniAcquirente.Location = new Point(20, 150);
            cmbComuniAcquirente.Name = "cmbComuniAcquirente";
            cmbComuniAcquirente.Size = new Size(121, 28);
            cmbComuniAcquirente.TabIndex = 3;
            // 
            // btnSalvaAcquirente
            // 
            btnSalvaAcquirente.Location = new Point(20, 200);
            btnSalvaAcquirente.Name = "btnSalvaAcquirente";
            btnSalvaAcquirente.Size = new Size(75, 23);
            btnSalvaAcquirente.TabIndex = 4;
            btnSalvaAcquirente.Text = "Salva Acquirente";
            btnSalvaAcquirente.Click += btnSalvaAcquirente_Click;
            // 
            // tabMagazzino
            // 
            tabMagazzino.Controls.Add(cmbMerciMagazzino);
            tabMagazzino.Controls.Add(txtNomeMagazzino);
            tabMagazzino.Controls.Add(txtQuantitaMagazzino);
            tabMagazzino.Controls.Add(btnStoccaMerce);
            tabMagazzino.Location = new Point(4, 29);
            tabMagazzino.Name = "tabMagazzino";
            tabMagazzino.Size = new Size(992, 567);
            tabMagazzino.TabIndex = 2;
            tabMagazzino.Text = "Magazzino";
            // 
            // cmbMerciMagazzino
            // 
            cmbMerciMagazzino.Location = new Point(20, 30);
            cmbMerciMagazzino.Name = "cmbMerciMagazzino";
            cmbMerciMagazzino.Size = new Size(121, 28);
            cmbMerciMagazzino.TabIndex = 0;
            // 
            // txtNomeMagazzino
            // 
            txtNomeMagazzino.Location = new Point(20, 70);
            txtNomeMagazzino.Name = "txtNomeMagazzino";
            txtNomeMagazzino.PlaceholderText = "Nome Magazzino / Scaffale";
            txtNomeMagazzino.Size = new Size(100, 27);
            txtNomeMagazzino.TabIndex = 1;
            // 
            // txtQuantitaMagazzino
            // 
            txtQuantitaMagazzino.Location = new Point(20, 110);
            txtQuantitaMagazzino.Name = "txtQuantitaMagazzino";
            txtQuantitaMagazzino.PlaceholderText = "Quantità";
            txtQuantitaMagazzino.Size = new Size(100, 27);
            txtQuantitaMagazzino.TabIndex = 2;
            // 
            // btnStoccaMerce
            // 
            btnStoccaMerce.Location = new Point(20, 160);
            btnStoccaMerce.Name = "btnStoccaMerce";
            btnStoccaMerce.Size = new Size(75, 23);
            btnStoccaMerce.TabIndex = 3;
            btnStoccaMerce.Text = "Disponi Merce";
            btnStoccaMerce.Click += btnStoccaMerce_Click;
            // 
            // tabFatture
            // 
            tabFatture.Controls.Add(txtNumeroFattura);
            tabFatture.Controls.Add(dtpDataFattura);
            tabFatture.Controls.Add(cmbAcquirentiFattura);
            tabFatture.Controls.Add(cmbMerciFattura);
            tabFatture.Controls.Add(txtQuantitaFattura);
            tabFatture.Controls.Add(btnAggiungiRigaCarrello);
            tabFatture.Controls.Add(dgvRigheFatturaProvvisoria);
            tabFatture.Controls.Add(btnEmettiFatturaFinale);
            tabFatture.Location = new Point(4, 29);
            tabFatture.Name = "tabFatture";
            tabFatture.Size = new Size(992, 567);
            tabFatture.TabIndex = 3;
            tabFatture.Text = "Emetti Fattura";
            // 
            // txtNumeroFattura
            // 
            txtNumeroFattura.Location = new Point(20, 20);
            txtNumeroFattura.Name = "txtNumeroFattura";
            txtNumeroFattura.Size = new Size(100, 27);
            txtNumeroFattura.TabIndex = 0;
            // 
            // dtpDataFattura
            // 
            dtpDataFattura.Location = new Point(20, 60);
            dtpDataFattura.Name = "dtpDataFattura";
            dtpDataFattura.Size = new Size(200, 27);
            dtpDataFattura.TabIndex = 1;
            // 
            // cmbAcquirentiFattura
            // 
            cmbAcquirentiFattura.Location = new Point(20, 100);
            cmbAcquirentiFattura.Name = "cmbAcquirentiFattura";
            cmbAcquirentiFattura.Size = new Size(121, 28);
            cmbAcquirentiFattura.TabIndex = 2;
            // 
            // cmbMerciFattura
            // 
            cmbMerciFattura.Location = new Point(300, 20);
            cmbMerciFattura.Name = "cmbMerciFattura";
            cmbMerciFattura.Size = new Size(121, 28);
            cmbMerciFattura.TabIndex = 3;
            // 
            // txtQuantitaFattura
            // 
            txtQuantitaFattura.Location = new Point(300, 60);
            txtQuantitaFattura.Name = "txtQuantitaFattura";
            txtQuantitaFattura.Size = new Size(100, 27);
            txtQuantitaFattura.TabIndex = 4;
            // 
            // btnAggiungiRigaCarrello
            // 
            btnAggiungiRigaCarrello.Location = new Point(300, 100);
            btnAggiungiRigaCarrello.Name = "btnAggiungiRigaCarrello";
            btnAggiungiRigaCarrello.Size = new Size(75, 23);
            btnAggiungiRigaCarrello.TabIndex = 5;
            btnAggiungiRigaCarrello.Text = "Aggiungi al Carrello";
            btnAggiungiRigaCarrello.Click += btnAggiungiRigaCarrello_Click;
            // 
            // dgvRigheFatturaProvvisoria
            // 
            dgvRigheFatturaProvvisoria.ColumnHeadersHeight = 29;
            dgvRigheFatturaProvvisoria.Location = new Point(300, 140);
            dgvRigheFatturaProvvisoria.Name = "dgvRigheFatturaProvvisoria";
            dgvRigheFatturaProvvisoria.RowHeadersWidth = 51;
            dgvRigheFatturaProvvisoria.Size = new Size(500, 200);
            dgvRigheFatturaProvvisoria.TabIndex = 6;
            // 
            // btnEmettiFatturaFinale
            // 
            btnEmettiFatturaFinale.Location = new Point(300, 360);
            btnEmettiFatturaFinale.Name = "btnEmettiFatturaFinale";
            btnEmettiFatturaFinale.Size = new Size(75, 23);
            btnEmettiFatturaFinale.TabIndex = 7;
            btnEmettiFatturaFinale.Text = "Conferma ed Emetti";
            btnEmettiFatturaFinale.Click += btnEmettiFatturaFinale_Click;
            // 
            // tabStorico
            // 
            tabStorico.Controls.Add(cmbFiltroAcquirente);
            tabStorico.Controls.Add(dgvFattureAcquirente);
            tabStorico.Location = new Point(4, 29);
            tabStorico.Name = "tabStorico";
            tabStorico.Size = new Size(992, 567);
            tabStorico.TabIndex = 4;
            tabStorico.Text = "Storico Fatture";
            // 
            // cmbFiltroAcquirente
            // 
            cmbFiltroAcquirente.Location = new Point(20, 20);
            cmbFiltroAcquirente.Name = "cmbFiltroAcquirente";
            cmbFiltroAcquirente.Size = new Size(121, 28);
            cmbFiltroAcquirente.TabIndex = 0;
            cmbFiltroAcquirente.SelectedIndexChanged += cmbFiltroAcquirente_SelectedIndexChanged;
            // 
            // dgvFattureAcquirente
            // 
            dgvFattureAcquirente.ColumnHeadersHeight = 29;
            dgvFattureAcquirente.Location = new Point(20, 70);
            dgvFattureAcquirente.Name = "dgvFattureAcquirente";
            dgvFattureAcquirente.RowHeadersWidth = 51;
            dgvFattureAcquirente.Size = new Size(800, 400);
            dgvFattureAcquirente.TabIndex = 1;
            // 
            // tabComuni
            // 
            tabComuni.Controls.Add(dgvComuni);
            tabComuni.Controls.Add(txtCap);
            tabComuni.Controls.Add(txtCitta);
            tabComuni.Controls.Add(txtProvincia);
            tabComuni.Controls.Add(btnSalvaComune);
            tabComuni.Location = new Point(4, 29);
            tabComuni.Name = "tabComuni";
            tabComuni.Size = new Size(992, 567);
            tabComuni.TabIndex = 5;
            tabComuni.Text = "Anagrafica Comuni";
            // 
            // dgvComuni
            // 
            dgvComuni.ColumnHeadersHeight = 29;
            dgvComuni.Location = new Point(20, 20);
            dgvComuni.Name = "dgvComuni";
            dgvComuni.RowHeadersWidth = 51;
            dgvComuni.Size = new Size(500, 350);
            dgvComuni.TabIndex = 0;
            // 
            // txtCap
            // 
            txtCap.Location = new Point(550, 50);
            txtCap.Name = "txtCap";
            txtCap.PlaceholderText = "CAP";
            txtCap.Size = new Size(100, 27);
            txtCap.TabIndex = 1;
            // 
            // txtCitta
            // 
            txtCitta.Location = new Point(550, 90);
            txtCitta.Name = "txtCitta";
            txtCitta.PlaceholderText = "Città";
            txtCitta.Size = new Size(100, 27);
            txtCitta.TabIndex = 2;
            // 
            // txtProvincia
            // 
            txtProvincia.Location = new Point(550, 130);
            txtProvincia.Name = "txtProvincia";
            txtProvincia.PlaceholderText = "Provincia (Sigla)";
            txtProvincia.Size = new Size(100, 27);
            txtProvincia.TabIndex = 3;
            // 
            // btnSalvaComune
            // 
            btnSalvaComune.Location = new Point(550, 180);
            btnSalvaComune.Name = "btnSalvaComune";
            btnSalvaComune.Size = new Size(75, 23);
            btnSalvaComune.TabIndex = 4;
            btnSalvaComune.Text = "Aggiungi Comune";
            btnSalvaComune.Click += btnSalvaComune_ClickAsync;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Gestione Magazzino 2.0";
            tabControl1.ResumeLayout(false);
            tabMerci.ResumeLayout(false);
            tabMerci.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMerci).EndInit();
            tabAcquirenti.ResumeLayout(false);
            tabAcquirenti.PerformLayout();
            tabMagazzino.ResumeLayout(false);
            tabMagazzino.PerformLayout();
            tabFatture.ResumeLayout(false);
            tabFatture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRigheFatturaProvvisoria).EndInit();
            tabStorico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFattureAcquirente).EndInit();
            tabComuni.ResumeLayout(false);
            tabComuni.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComuni).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabMerci;
        private TabPage tabAcquirenti;
        private TabPage tabMagazzino;
        private TabPage tabFatture;
        private TabPage tabStorico;
        private TabPage tabComuni;
        private DataGridView dgvComuni;
        private TextBox txtCap;
        private TextBox txtCitta;
        private TextBox txtProvincia;
        private Button btnSalvaComune;

        // Merci
        private DataGridView dgvMerci;
        private TextBox txtIdMerce;
        private TextBox txtDescrizione;
        private TextBox txtPrezzo;
        private Button button1;
        private Button button2;
        private Button button3;

        // Acquirenti
        private TextBox txtPartitaIva;
        private TextBox txtRagioneSociale;
        private TextBox txtIndirizzoAcquirente;
        private ComboBox cmbComuniAcquirente;
        private Button btnSalvaAcquirente;

        // Magazzino
        private ComboBox cmbMerciMagazzino;
        private TextBox txtNomeMagazzino;
        private TextBox txtQuantitaMagazzino;
        private Button btnStoccaMerce;

        // Fatture
        private TextBox txtNumeroFattura;
        private DateTimePicker dtpDataFattura;
        private ComboBox cmbAcquirentiFattura;
        private ComboBox cmbMerciFattura;
        private TextBox txtQuantitaFattura;
        private Button btnAggiungiRigaCarrello;
        private DataGridView dgvRigheFatturaProvvisoria;
        private Button btnEmettiFatturaFinale;

        // Storico
        private ComboBox cmbFiltroAcquirente;
        private DataGridView dgvFattureAcquirente;
    }
}