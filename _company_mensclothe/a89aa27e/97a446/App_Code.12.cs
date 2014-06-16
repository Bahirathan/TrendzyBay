#pragma checksum "I:\Company\MensClothe\App_Code\ccClasses\CCard.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5AC8F9CA3F181FED9727A9DC55617C0B67208555"

#line 1 "I:\Company\MensClothe\App_Code\ccClasses\CCard.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CCard
using System.ComponentModel.DataAnnotations;
public class CCard
{
    public CCard()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [CreditCard]
    public string CreditCardNumber { get; set; }
    public string CreditCardExpiration { get; set; }
    public string SecurityCode { get; set; }
    public string CardType { get; set; }
	
}

#line default
#line hidden
