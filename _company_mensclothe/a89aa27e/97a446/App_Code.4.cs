#pragma checksum "I:\Company\MensClothe\App_Code\WebService.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C42E982C885863D011E71EB2230244A94FE2C325"

#line 1 "I:\Company\MensClothe\App_Code\WebService.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using DAL;
using MensClothe;
using Search;
using WebMatrix.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    ProfileCommon profile = HttpContext.Current.Profile as ProfileCommon;
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void SelectedItemClick(string _id)
    {
        //   if(IsPost)
      //  DbConnection Dbase = new DbConnection("ConnectionStr");
        var ProductRecord = Products.getProductDetail(int.Parse(_id));
        if (ProductRecord != null)
        {
            var Price = Convert.ToString(ProductRecord.unitprice);
            var Description = Convert.ToString(ProductRecord.unitprice);
            var quantity = Convert.ToString(ProductRecord.quantity);
            var catID = Convert.ToString(ProductRecord.categoryID);
            var img = Convert.ToString(ProductRecord.img);
            var ClotheName = Convert.ToString(ProductRecord.name);
            if (profile.SCart == null)
            {
                profile.SCart = new MensClothe.Cart();
            }
            profile.SCart.Insert(int.Parse(_id), double.Parse(Price), 1, ClotheName, img);
        }
    }



    [WebMethod]
    public List<SearchResult> SearchProduct(string searchString)
    {
        //   if(IsPost)
     //   DbConnection Dbase = new DbConnection("ConnectionStr");
        var ProductRecord = Products.getProductRecodCollections();   //Dbase.getProductRecodCollections();
        var result = ProductRecord.Where(p => p.Description.ToLower().Contains(
                     searchString.ToLower()) ||
                     p.name.ToLower().Contains(searchString.ToLower()))
            .Select(p => new SearchResult
            {
                Category = "Product",
                Description = p.name,
                Id = p.ItemID,
                price = p.unitprice,
                imgURL = p.img,
                HTML = HtrmlString(p.name, p.unitprice, p.img, p.ItemID.ToString()).ToString()
            }).ToList();
        return result;
    }

    [WebMethod]
    protected void ProcessPayment(Customer cus, CCard ccard, string Amount, bool PayPalReturnRequest)
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
            if (!order.ProcessCreditCard(cus, ccard, Amount))
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


    protected StringBuilder HtrmlString(string name, string price, string imgurl, string id)
    {
        var sb = new StringBuilder("");
        var sb2 = new StringBuilder("");
        string image = MensClothe.AspControlUtil.getFullImagePath(Convert.ToString(imgurl));
        //   if (result != null)
        {
            sb.Append("<table width=\"260px\" cellpadding=\"3\" cellspacing=\"0\" bordercolor=\"#0000FF\" class=\"tmplreftbl\">\n");
            sb.Append("             <tr>\n");
            sb.Append("             <td class=\"tmplrefth\" width=\"50%\" align=\"left\"><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label>Product Name </label></td>\n");
            sb.Append("                <td class=\"tmplrefth\" width=\"50%\" align=\"left\"><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label> Price </label></td>\n");
            sb.Append("                <td class=\"tmplrefth\" width=\"50%\" align=\"left\"><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label> Picture </label></td>\n");
            sb.Append("             </tr>\n");
            //          foreach (var item in result)
            {

                sb.Append("             <tr>\n");
                sb.Append("             <td class=\"tmplrefth\" width=\"50%\" align=\"left\"><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label> " + name + "</label></td>\n");
                sb.Append("                <td class=\"tmplrefth\" width=\"50%\" align=\"left\"><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label>" + price + " </label></td>\n");
                sb.Append("                <td class=\"tmplrefth\" width=\"50%\" align=\"left\"><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><img src=\' " + image + "' alt=\"Template Preview\" onclick='SelectedItemClick(" + id + ");' style=\"width:300px;height:100px;\"></td>\n");
                sb.Append("             </tr>\n");
            }
            sb.Append("           </table>\n");
        }
        return sb;
    }










}


#line default
#line hidden
