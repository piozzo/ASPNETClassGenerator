using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;


public class Ordini_ediProvider {

	public static void insertOrdini_edi(Ordini_edi item) 
	{
		using (MySqlConnection cnMySql = new MySqlConnection(connectionString))
		{
			cnMySql.Open();

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("INSERT INTO antique.ordini_edi(`id_ordine`, `data_ordine`, `codfornitore`, `chi_ordina`, `codlib_ordine`, `ean13`, `riferimento_ordine`, `quantita_ordinata`, `quantita_cancellata`, `quantita_confermata`, `numero_ordine`, `data_invio`, `titolo_ordine`, `titolo_antique`, `prezzo_ordine`, `data_cancellazione_automatica`, `data_scadenza`, `bloccato`, `motivo_blocco`, `sbloccato_da`, `data_sblocco`, `processato`, `inviato`, `codice_ordine`, `editore_ordine`, `sconto_ordine`, `prezzo_finale_libroco`)");
			sb.Append("VALUES ");
			sb.Append("(?id_ordine, ?data_ordine, ?codfornitore, ?chi_ordina, ?codlib_ordine, ?ean13, ?riferimento_ordine, ?quantita_ordinata, ?quantita_cancellata, ?quantita_confermata, ?numero_ordine, ?data_invio, ?titolo_ordine, ?titolo_antique, ?prezzo_ordine, ?data_cancellazione_automatica, ?data_scadenza, ?bloccato, ?motivo_blocco, ?sbloccato_da, ?data_sblocco, ?processato, ?inviato, ?codice_ordine, ?editore_ordine, ?sconto_ordine, ?prezzo_finale_libroco)");

			using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), cnMySql)) 
			{
				try 
				{
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex) 
				{
					EventLogger.LogError("Errore durante l'inserimento dell'oggetto Ordini_edi nel database.", ex);
				}
			}

			cnMySql.Close();
		}
	}
}
