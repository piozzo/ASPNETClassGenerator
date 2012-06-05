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


public class Pagamenti {

	#region [ Proprietà ]

	private int _Id_pagamenti;
	public int Id_pagamenti {
		get { return _Id_pagamenti; }
		set { _Id_pagamenti = value; } 
	}

	private DateTime _Data_ultimo_pagamento;
	public DateTime Data_ultimo_pagamento {
		get { return _Data_ultimo_pagamento; }
		set { _Data_ultimo_pagamento = value; } 
	}

	private double _Totale_pagamento;
	public double Totale_pagamento {
		get { return _Totale_pagamento; }
		set { _Totale_pagamento = value; } 
	}

	private int _Numero_fattura;
	public int Numero_fattura {
		get { return _Numero_fattura; }
		set { _Numero_fattura = value; } 
	}

	private int _Anno_fattura;
	public int Anno_fattura {
		get { return _Anno_fattura; }
		set { _Anno_fattura = value; } 
	}

	private int _Tipo_fattura;
	public int Tipo_fattura {
		get { return _Tipo_fattura; }
		set { _Tipo_fattura = value; } 
	}

	private int _Numregpn;
	public int Numregpn {
		get { return _Numregpn; }
		set { _Numregpn = value; } 
	}

	private string _Annocom;
	public string Annocom {
		get { return _Annocom; }
		set { _Annocom = value; } 
	}

	#endregion

	#region [ Metodi Pubblici ]

	public static void inserisci

	#endregion
}
