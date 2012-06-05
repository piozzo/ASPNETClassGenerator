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


public class Pagamenti_gruppoProvider {

	public static void insertPagamenti_gruppo(Pagamenti_gruppo item) 
	{
		using (MySqlConnection cnMySql = new MySqlConnection(connectionString))
		{
			cnMySql.Open();

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("INSERT INTO antique.pagamenti_gruppo(`id_pagamenti`, `transaction_id`, `tipo_pagamento`, `nome_esecutore`, `email_esecutore`, `data_pagamento`, `importo_pagamento`)");
			sb.Append("VALUES ");
			sb.Append("(?id_pagamenti, ?transaction_id, ?tipo_pagamento, ?nome_esecutore, ?email_esecutore, ?data_pagamento, ?importo_pagamento)");

			using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), cnMySql)) 
			{
				try 
				{
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex) 
				{
					EventLogger.LogError("Errore durante l'inserimento dell'oggetto Pagamenti_gruppo nel database.", ex);
				}
			}

			cnMySql.Close();
		}
	}

	public static void updatePagamenti_gruppo(Pagamenti_gruppo item) 
	{
		using (MySqlConnection cnMySql = new MySqlConnection(connectionString))
		{
			cnMySql.Open();

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("UPDATE antique.pagamenti_gruppo ");
			sb.Append("SET ");
			sb.Append("`id_pagamenti` = ?id_pagamenti, ");
			sb.Append("`transaction_id` = ?transaction_id, ");
			sb.Append("`tipo_pagamento` = ?tipo_pagamento, ");
			sb.Append("`nome_esecutore` = ?nome_esecutore, ");
			sb.Append("`email_esecutore` = ?email_esecutore, ");
			sb.Append("`data_pagamento` = ?data_pagamento, ");
			sb.Append("`importo_pagamento` = ?importo_pagamento, ");
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
					EventLogger.LogError("Errore durante l'aggiornamento dell'oggetto Pagamenti_gruppo nel database.", ex);
				}
			}

			cnMySql.Close();
		}
	}

protected Pagamenti_gruppo getPagamenti_gruppoFromReader(IDataReader reader)
{
	Pagamenti_gruppo item = new Pagamenti_gruppo();

	item.Id_pagamenti = ConvertDBObjectToInt(reader["id_pagamenti"]);
	item.Transaction_id = ConvertDBObjectToString(reader["transaction_id"]);
	item.Tipo_pagamento = ConvertDBObjectToString(reader["tipo_pagamento"]);
	item.Nome_esecutore = ConvertDBObjectToString(reader["nome_esecutore"]);
	item.Email_esecutore = ConvertDBObjectToString(reader["email_esecutore"]);
	item.Data_pagamento = ConvertDBObjectToDateTime(reader["data_pagamento"]);
	item.Importo_pagamento = (reader["importo_pagamento"]);

	return item;
}

//Parametri per le query

cmd.Parameters.AddWithValue("?id_pagamenti", item.Id_pagamenti);
cmd.Parameters.AddWithValue("?transaction_id", item.Transaction_id);
cmd.Parameters.AddWithValue("?tipo_pagamento", item.Tipo_pagamento);
cmd.Parameters.AddWithValue("?nome_esecutore", item.Nome_esecutore);
cmd.Parameters.AddWithValue("?email_esecutore", item.Email_esecutore);
cmd.Parameters.AddWithValue("?data_pagamento", item.Data_pagamento);
cmd.Parameters.AddWithValue("?importo_pagamento", item.Importo_pagamento);
