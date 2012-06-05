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


public class Pagamenti_gruppo {

	#region [ Proprietà ]

	private int _Id_pagamenti;
	public int Id_pagamenti {
		get { return _Id_pagamenti; }
		set { _Id_pagamenti = value; } 
	}

	private string _Transaction_id;
	public string Transaction_id {
		get { return _Transaction_id; }
		set { _Transaction_id = value; } 
	}

	private string _Tipo_pagamento;
	public string Tipo_pagamento {
		get { return _Tipo_pagamento; }
		set { _Tipo_pagamento = value; } 
	}

	private string _Nome_esecutore;
	public string Nome_esecutore {
		get { return _Nome_esecutore; }
		set { _Nome_esecutore = value; } 
	}

	private string _Email_esecutore;
	public string Email_esecutore {
		get { return _Email_esecutore; }
		set { _Email_esecutore = value; } 
	}

	private DateTime _Data_pagamento;
	public DateTime Data_pagamento {
		get { return _Data_pagamento; }
		set { _Data_pagamento = value; } 
	}

	private double _Importo_pagamento;
	public double Importo_pagamento {
		get { return _Importo_pagamento; }
		set { _Importo_pagamento = value; } 
	}

	#endregion

	#region [ Metodi Pubblici ]

	public static void inserisci

	#endregion
}
