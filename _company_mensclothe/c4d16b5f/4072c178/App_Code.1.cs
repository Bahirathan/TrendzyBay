#pragma checksum "G:\Company\MensClothe\App_Code\ccClasses\CCard.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37B9E9AEA8D253F8F02AFD8170D5030215DDEDDD"

#line 1 "G:\Company\MensClothe\App_Code\ccClasses\CCard.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CCard
using System.ComponentModel.DataAnnotations;
public class CCard
{

    [CreditCard]
    public string CreditCardNumber { get; set; }
    public string CreditCardExpiration { get; set; }
    public string SecurityCode { get; set; }
    public string CardType { get; set; }
	public CCard()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

#line default
#line hidden
