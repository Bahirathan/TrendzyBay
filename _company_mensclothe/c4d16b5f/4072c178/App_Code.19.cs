#pragma checksum "G:\Company\MensClothe\App_Code\Customer.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F1B451072C56F7FD9C05B060918257DAF3A53D1C"

#line 1 "G:\Company\MensClothe\App_Code\Customer.cs"
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Customer
/// </summary>
[Serializable]
public class Customer
{
    public Customer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Zipcode { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string phone { get; set; }
    public string Email { get; set; }

}

#line default
#line hidden
