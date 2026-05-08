using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestione_Magazzino
{
    public partial class Form1 : Form
    {
        private readonly MerceRepository _merceRepo;
        private readonly AcquirenteRepository _acquirenteRepo;
        private readonly ComuneRepository _comuneRepo;
        private readonly MagazzinoRepository _magazzinoRepo;
        private readonly FatturaRepository _fatturaRepo;

        // Lista temporanea per le righe della fattura che l'utente sta creando nella GUI
        private List<DettaglioFattura> _carrelloCorrente = new List<DettaglioFattura>();

        public Form1()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=db_gestione_magazzino;Uid=root;Pwd=0208Pall#!;";

            // Istanziamo tutti i componenti della logica dati
            _merceRepo = new MerceRepository(connectionString);
            _acquirenteRepo = new AcquirenteRepository(connectionString);
            _comuneRepo = new ComuneRepository(connectionString);
            _magazzinoRepo = new MagazzinoRepository(connectionString);
            _fatturaRepo = new FatturaRepository(connectionString);

            this.Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await InizializzaTuttiICampiAsync();
        }

        private async Task InizializzaTuttiICampiAsync()
        {
            try
            {
                // Carichiamo le ComboBox e i dati all'avvio per le nuove schede
                var comuni = await _comuneRepo.OttieniTuttiIComuniAsync();
                cmbComuniAcquirente.DataSource = comuni;
                cmbComuniAcquirente.DisplayMember = "Citta";

                var merci = await _merceRepo.OttieniTutteLeMerciAsync();
                cmbMerciMagazzino.DataSource = merci;
                cmbMerciMagazzino.DisplayMember = "Descrizione";

                cmbMerciFattura.DataSource = new List<Merce>(merci);
                cmbMerciFattura.DisplayMember = "Descrizione";

                var acquirenti = await _acquirenteRepo.OttieniTuttiGliAcquirentiAsync();
                cmbAcquirentiFattura.DataSource = acquirenti;
                cmbAcquirentiFattura.DisplayMember = "RagioneSociale";

                cmbFiltroAcquirente.DataSource = new List<Acquirente>(acquirenti);
                cmbFiltroAcquirente.DisplayMember = "RagioneSociale";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore di inizializzazione moduli: " + ex.Message);
            }
        }

        // =========================================================
        // SCHEDA 2: INSERIMENTO ACQUIRENTE & COMUNE
        // =========================================================
        private async void btnSalvaAcquirente_Click(object sender, EventArgs e)
        {
            try
            {
                var comuneScelto = (Comune)cmbComuniAcquirente.SelectedItem;

                Acquirente nuovoAcquirente = new Acquirente
                {
                    P_Iva = txtPartitaIva.Text,
                    RagioneSociale = txtRagioneSociale.Text,
                    Indirizzo = txtIndirizzoAcquirente.Text,
                    ComuneResidenza = comuneScelto
                };

                await _acquirenteRepo.AggiungiAcquirenteAsync(nuovoAcquirente);
                MessageBox.Show("Nuovo Acquirente Registrato!");
                await InizializzaTuttiICampiAsync(); // Rinfresca i menu a tendina
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore salvataggio acquirente: " + ex.Message);
            }
        }

        // =========================================================
        // SCHEDA 3: DISPOSIZIONE MERCI NEI MAGAZZINI
        // =========================================================
        private async void btnStoccaMerce_Click(object sender, EventArgs e)
        {
            try
            {
                var merceSelezionata = (Merce)cmbMerciMagazzino.SelectedItem;
                // Assicurati che l'utente scriva un numero nella TextBox dello scaffale (es: 1, 2, 3)
                int idScaffale = Convert.ToInt32(txtNomeMagazzino.Text);
                int quantita = Convert.ToInt32(txtQuantitaMagazzino.Text);

                await _magazzinoRepo.DisponiMerceAsync(idScaffale, merceSelezionata.IdMerce, quantita);
                MessageBox.Show("Stoccaggio completato!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: inserire un ID numerico per lo scaffale. " + ex.Message);
            }
        }

        // =========================================================
        // SCHEDA 4: EMISSIONE FATTURA & CONTROLLO DISPONIBILITÀ
        // =========================================================
        private async void btnAggiungiRigaCarrello_Click(object sender, EventArgs e)
        {
            var merceSelezionata = (Merce)cmbMerciFattura.SelectedItem;
            int quantitaRichiesta = Convert.ToInt32(txtQuantitaFattura.Text);

            // CONTROLLO DI BUSINESS: Verifichiamo la giacenza effettiva nei magazzini
            int disponibilitaReale = await _magazzinoRepo.OttieniDisponibilitaMerceAsync(merceSelezionata.IdMerce);

            if (quantitaRichiesta > disponibilitaReale)
            {
                MessageBox.Show($"Azione Annullata! Quantità richiesta ({quantitaRichiesta}) superiore alla disponibilità in magazzino ({disponibilitaReale}).",
                                "Giacenza Insufficiente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Se disponibile, aggiungiamo la riga al carrello provvisorio
            _carrelloCorrente.Add(new DettaglioFattura
            {
                MerceAcquistata = merceSelezionata,
                Quantita = quantitaRichiesta,
                PrezzoApplicato = merceSelezionata.PrezzoUnitario
            });

            // Aggiorna la griglia temporanea della fattura corrente
            dgvRigheFatturaProvvisoria.DataSource = null;
            dgvRigheFatturaProvvisoria.DataSource = _carrelloCorrente;
        }

        private async void btnEmettiFatturaFinale_Click(object sender, EventArgs e)
        {
            if (_carrelloCorrente.Count == 0) return;

            try
            {
                Fattura nuovaFattura = new Fattura
                {
                    NumeroFattura = txtNumeroFattura.Text,
                    DataEmissione = dtpDataFattura.Value,
                    Intestatario = (Acquirente)cmbAcquirentiFattura.SelectedItem
                };

                await _fatturaRepo.EmettiFatturaAsync(nuovaFattura, _carrelloCorrente);
                MessageBox.Show("Fattura emessa e registrata! Le giacenze di magazzino sono state scaricate.");

                _carrelloCorrente.Clear();
                dgvRigheFatturaProvvisoria.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore fatale durante l'emissione della fattura: " + ex.Message);
            }
        }

        // =========================================================
        // SCHEDA 5: VISUALIZZAZIONE FATTURE PER ACQUIRENTE
        // =========================================================
        private async void cmbFiltroAcquirente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroAcquirente.SelectedItem == null) return;

            var acquirenteSelezionato = (Acquirente)cmbFiltroAcquirente.SelectedItem;

            // Chiamiamo il metodo del repository per filtrare le fatture
            var fattureTrovate = await _fatturaRepo.OttieniFatturePerAcquirenteAsync(acquirenteSelezionato.P_Iva);

            dgvFattureAcquirente.DataSource = null;
            dgvFattureAcquirente.DataSource = fattureTrovate;
        }

        // --- GESTIONE BOTTONE: AGGIUNGI MERCE ---
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Merce nuovaMerce = new Merce
                {
                    Descrizione = txtDescrizione.Text,
                    PrezzoUnitario = Convert.ToDecimal(txtPrezzo.Text)
                };

                await _merceRepo.AggiungiMerceAsync(nuovaMerce);
                MessageBox.Show("Merce aggiunta con successo!");

                await AggiornaGrigliaMerciAsync();
                PulisciCampiMerci();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante l'inserimento: " + ex.Message);
            }
        }

        // --- GESTIONE BOTTONE: AGGIORNA MERCE ---
        private async void button2_Click(object sender, EventArgs e)
        {
            if (dgvMerci.CurrentRow == null) return;

            try
            {
                Merce merceSelezionata = (Merce)dgvMerci.CurrentRow.DataBoundItem;
                merceSelezionata.Descrizione = txtDescrizione.Text;
                merceSelezionata.PrezzoUnitario = Convert.ToDecimal(txtPrezzo.Text);

                await _merceRepo.AggiornaMerceAsync(merceSelezionata);
                MessageBox.Show("Merce aggiornata!");

                await AggiornaGrigliaMerciAsync();
                PulisciCampiMerci();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante l'aggiornamento: " + ex.Message);
            }
        }

        // --- GESTIONE BOTTONE: ELIMINA MERCE ---
        private async void button3_Click(object sender, EventArgs e)
        {
            if (dgvMerci.CurrentRow == null) return;

            var conferma = MessageBox.Show("Eliminare la merce selezionata?", "Conferma", MessageBoxButtons.YesNo);
            if (conferma == DialogResult.Yes)
            {
                try
                {
                    Merce merceSelezionata = (Merce)dgvMerci.CurrentRow.DataBoundItem;
                    await _merceRepo.EliminaMerceAsync(merceSelezionata.IdMerce);

                    await AggiornaGrigliaMerciAsync();
                    PulisciCampiMerci();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore: la merce potrebbe essere legata a fatture o magazzini.\n" + ex.Message);
                }
            }
        }

        // --- METODI HELPER ---
        private async Task AggiornaGrigliaMerciAsync()
        {
            dgvMerci.DataSource = null;
            dgvMerci.DataSource = await _merceRepo.OttieniTutteLeMerciAsync();
        }

        private void PulisciCampiMerci()
        {
            txtIdMerce.Clear();
            txtDescrizione.Clear();
            txtPrezzo.Clear();
        }
        private async Task AggiornaGrigliaComuniAsync()
        {
            dgvComuni.DataSource = null;
            dgvComuni.DataSource = await _comuneRepo.OttieniTuttiIComuniAsync();
        }

        private void dgvMerci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Merce m = (Merce)dgvMerci.Rows[e.RowIndex].DataBoundItem;
                txtIdMerce.Text = m.IdMerce.ToString();
                txtDescrizione.Text = m.Descrizione;
                txtPrezzo.Text = m.PrezzoUnitario.ToString();
            }
        }

        private async void btnSalvaComune_ClickAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCap.Text) || string.IsNullOrWhiteSpace(txtCitta.Text))
            {
                MessageBox.Show("Inserire CAP e Città!");
                return;
            }

            try
            {
                Comune nuovoComune = new Comune
                {
                    CAP = txtCap.Text,
                    Citta = txtCitta.Text,
                    Provincia = txtProvincia.Text
                };

                // Assicurati che ComuneRepository abbia il metodo AggiungiComuneAsync
                await _comuneRepo.AggiungiComuneAsync(nuovoComune);
                MessageBox.Show("Comune inserito correttamente!");

                // AGGIORNAMENTO CRUCIALE:
                // Ricarichiamo i dati per aggiornare sia la griglia dei comuni 
                // sia la ComboBox nella scheda Acquirenti
                await InizializzaTuttiICampiAsync();
                await AggiornaGrigliaComuniAsync();

                txtCap.Clear();
                txtCitta.Clear();
                txtProvincia.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante il salvataggio del comune: " + ex.Message);
            }
        }
    }
}