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


public class Ordini_edi {

	#region [ Proprietà ]

	private string _Ean13;
	public string Ean13 {
		get { return _Ean13; }
		set { _Ean13 = value; } 
	}

	private string _Riferimento_ordine;
	public string Riferimento_ordine {
		get { return _Riferimento_ordine; }
		set { _Riferimento_ordine = value; } 
	}

	private string _Numero_ordine;
	public string Numero_ordine {
		get { return _Numero_ordine; }
		set { _Numero_ordine = value; } 
	}

	private string _Titolo_ordine;
	public string Titolo_ordine {
		get { return _Titolo_ordine; }
		set { _Titolo_ordine = value; } 
	}

	private string _Titolo_antique;
	public string Titolo_antique {
		get { return _Titolo_antique; }
		set { _Titolo_antique = value; } 
	}

	private string _Bloccato;
	public string Bloccato {
		get { return _Bloccato; }
		set { _Bloccato = value; } 
	}

	private string _Motivo_blocco;
	public string Motivo_blocco {
		get { return _Motivo_blocco; }
		set { _Motivo_blocco = value; } 
	}

	private string _Processato;
	public string Processato {
		get { return _Processato; }
		set { _Processato = value; } 
	}

	private string _Inviato;
	public string Inviato {
		get { return _Inviato; }
		set { _Inviato = value; } 
	}

	private string _Editore_ordine;
	public string Editore_ordine {
		get { return _Editore_ordine; }
		set { _Editore_ordine = value; } 
	}

	#endregion
}
