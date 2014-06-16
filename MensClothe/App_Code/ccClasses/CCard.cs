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
        // TODO: Add constructor logic here
        //
    }
    [CreditCard]
    public string CreditCardNumber { get; set; }
    public string CreditCardExpiration { get; set; }
    public string SecurityCode { get; set; }
    public string CardType { get; set; }
}