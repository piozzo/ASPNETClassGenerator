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


public class PagamentiProvider {

	public static void insertPagamenti(Pagamenti item) 
	{
		using (MySqlConnection cnMySql = new MySqlConnection(connectionString))
		{
			cnMySql.Open();

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("INSERT INTO antique.pagamenti(`id_pagamenti`, `data_ultimo_pagamento`, `totale_pagamento`, `numero_fattura`, `anno_fattura`, `tipo_fattura`, `numregpn`, `annocom`)");
			sb.Append("VALUES ");
			sb.Append("(?id_pagamenti, ?data_ultimo_pagamento, ?totale_pagamento, ?numero_fattura, ?anno_fattura, ?tipo_fattura, ?numregpn, ?annocom)");

			using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), cnMySql)) 
			{
				try 
				{
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex) 
				{
					EventLogger.LogError("Errore durante l'inserimento dell'oggetto Pagamenti nel database.", ex);
				}
			}

			cnMySql.Close();
		}
	}

	public static void updatePagamenti(Pagamenti item) 
	{
		using (MySqlConnection cnMySql = new MySqlConnection(connectionString))
		{
			cnMySql.Open();

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("UPDATE antique.pagamenti ");
			sb.Append("SET ");
			sb.Append("`id_pagamenti` = ?id_pagamenti, ");
			sb.Append("`data_ultimo_pagamento` = ?data_ultimo_pagamento, ");
			sb.Append("`totale_pagamento` = ?totale_pagamento, ");
			sb.Append("`numero_fattura` = ?numero_fattura, ");
			sb.Append("`anno_fattura` = ?anno_fattura, ");
			sb.Append("`tipo_fattura` = ?tipo_fattura, ");
			sb.Append("`numregpn` = ?numregpn, ");
			sb.Append("`annocom` = ?annocom, ");
			sb.Append("WHERE id=?id;");


			using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), cnMySql)) 
			{
				//lista parametri comando
				try 
				{
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex) 
				{
					EventLogger.LogError("Errore durante l'aggiornamento dell'oggetto Pagamenti nel database.", ex);
				}
			}

			cnMySql.Close();
		}
	}

protected Pagamenti getPagamentiFromReader(IDataReader reader)
{
	Pagamenti item = new Pagamenti();

	item.Id_pagamenti = ConvertDBObjectToInt(reader["id_pagamenti"]);
	item.Data_ultimo_pagamento = ConvertDBObjectToDateTime(reader["data_ultimo_pagamento"]);
	item.Totale_pagamento = (reader["totale_pagamento"]);
	item.Numero_fattura = ConvertDBObjectToInt(reader["numero_fattura"]);
	item.Anno_fattura = ConvertDBObjectToInt(reader["anno_fattura"]);
	item.Tipo_fattura = ConvertDBObjectToInt(reader["tipo_fattura"]);
	item.Numregpn = ConvertDBObjectToInt(reader["numregpn"]);
	item.Annocom = ConvertDBObjectToString(reader["annocom"]);

	return item;
}

//Parametri per le query

cmd.Parameters.AddWithValue("?id_pagamenti", item.Id_pagamenti);
cmd.Parameters.AddWithValue("?data_ultimo_pagamento", item.Data_ultimo_pagamento);
cmd.Parameters.AddWithValue("?totale_pagamento", item.Totale_pagamento);
cmd.Parameters.AddWithValue("?numero_fattura", item.Numero_fattura);
cmd.Parameters.AddWithValue("?anno_fattura", item.Anno_fattura);
cmd.Parameters.AddWithValue("?tipo_fattura", item.Tipo_fattura);
cmd.Parameters.AddWithValue("?numregpn", item.Numregpn);
cmd.Parameters.AddWithValue("?annocom", item.Annocom);
