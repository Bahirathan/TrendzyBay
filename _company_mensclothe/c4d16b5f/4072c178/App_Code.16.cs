#pragma checksum "G:\Company\MensClothe\App_Code\WebService.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "679592F4830E8161A71A6286D28515A01181F717"

#line 1 "G:\Company\MensClothe\App_Code\WebService.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebMatrix.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {
    ProfileCommon profile = HttpContext.Current.Profile as ProfileCommon;
    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public  void SelectedItemClick(string _id)
    {
        //   if(IsPost)


        Database Dbase = new DbConnection("ConnectionStr").db;
        var ClotheRecord = Dbase.QuerySingle("SELECT ItemName, Description, Price, QOH, Size, ItemImage FROM  Clothe Where ItemID=@0 ", _id);
        if (ClotheRecord != null)
        {
            var Price = Convert.ToString(ClotheRecord["Price"]);
            var Description = Convert.ToString(ClotheRecord["Description"]);
            var quantity = Convert.ToString(ClotheRecord["QOH"]);
            var size = Convert.ToString(ClotheRecord["Size"]);
            var img = Convert.ToString(ClotheRecord["ItemImage"]);
            var ClotheName = Convert.ToString(ClotheRecord["ItemName"]);
          
            if (profile.SCart == null)
            {
                profile.SCart = new MensClothe.Cart();
            }


            profile.SCart.Insert(int.Parse(_id), double.Parse(Price), 1, ClotheName, img);

        }


    }

    [WebMethod]
    protected void ProcessPayment(Customer cus,CCard ccard  , string Amount, bool PayPalReturnRequest)
    {
        OrderClass order = new OrderClass();
        decimal OrderAmount;

        // *** Our simplistic 'order validation'
            OrderAmount = decimal.Parse(Amount);
        
        // *** Dumb ass data simulation - this should only be set once the order is Validated!
        this.Session["OrderAmount"] = OrderAmount;

        // *** Handle PayPal Processing seperately from ProcessCard() since it requires
        // *** passing off to another page on the PayPal Site.
        // *** This request will return to this page Cancel or Success querystring
        if (ccard.CardType == "PP" && PayPalReturnRequest)
            order.HandlePayPalRedirection(); // this will end this request!
        else
        {
            // *** CC Processing
            if (!order.ProcessCreditCard(cus, ccard,Amount))
                return;    // failure - display error

            // *** Write the order amount (and enything else you might need into session)
            // *** Normally you'd probably write a PK for the final invoice so you 
            // *** can reload it on the Confirmation.aspx page
            Session["PayPal_OrderAmount"] = OrderAmount;


        }


        // *** TODO:  Save your order etc.



        // *** Show the confirmation page - don't transfer so they can refresh without error
        HttpContext.Current.Response.Redirect("Confirmation.aspx");
    }



}


#line default
#line hidden
