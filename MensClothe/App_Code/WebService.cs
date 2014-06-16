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
using System.Web.WebPages;
using System.Net;
using Zayko.Finance;
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
    public MensClothe.Cart SelectedItemClick(string _id)
    {
        //   if(IsPost)
      //  DbConnection Dbase = new DbConnection("ConnectionStr");
        var ProductRecord = Products.getSellingDetail(int.Parse(_id));
        if (ProductRecord != null)
        {
            var Price = Convert.ToString(ProductRecord.price);
            var Description = Convert.ToString(ProductRecord.price);
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

        return profile.SCart;

    }


    [WebMethod]
    public List<OderDetails> GetOrderDetails(string _id)
    {
        //   if(IsPost)
        //  DbConnection Dbase = new DbConnection("ConnectionStr");
        return Orders.OderedItems(int.Parse(_id)).ToList();

    }
    



    [WebMethod]
    public void DeleteOrder(string _id)
    {
        //   if(IsPost)
      //  DbConnection Dbase = new DbConnection("ConnectionStr");
     //    DAL.Orders.DeleteOrder(_id);
        DAL.DbConnection.DeleteOrder(_id); 
       
        
    }



    [WebMethod]
    public void DeleteCustomer(string _id)
    {
        //   if(IsPost)
        //  DbConnection Dbase = new DbConnection("ConnectionStr");
        //    DAL.Orders.DeleteOrder(_id);
       Customer.DeleteCustomer(  int.Parse(_id));


    }



    
        [WebMethod]
    public MensClothe.Cart getShoppingCartdetails()
    {
      return  profile.SCart;
    }


    [WebMethod]
    public DAL.Category SearchCategory(string categoryID)
    {
        var CatRecord = DAL.Category.getCategoryDetail(int.Parse(categoryID));
        if (CatRecord != null)
        {

            var result = new DAL.Category
                {
                    categoryid = CatRecord["categoryid"],
                    description = CatRecord["description"],
                    categoryname = CatRecord["categoryname"],

                };
            return result;
        }
        return null;
    }

   
   [WebMethod(EnableSession=true)]
    public void sendEmail(string url, string Rawurl)
    {
            
        WebClient client = new WebClient();
        String htmlCode = client.DownloadString(url);
        Search.SmtpUtil mail = new Search.SmtpUtil();
        mail.send(HttpContext.Current.Session["CustomerEmail"].ToString(), " FashionStore-Order Confirmation  ", htmlCode, url, Rawurl);
  
   } 

   [WebMethod(EnableSession=true)]
   public void setCurrencyDetails(string curnVal, string curnSymbol, string Country)
    {
        CurrencyConverter myCurrencyConverter = new CurrencyConverter();
        IList<CurrencyData> currencyList = new 
List<CurrencyData>();

      
        try
        {
            if (curnVal == "LKR")
            {
             Application["exRate"] = 1.00;
             Application["curSym"] = "Rs";
             Application["ISOcur"] = "LKR";
            }
            else
            {
                currencyList.Add(new CurrencyData("LKR", curnVal));
                myCurrencyConverter.GetCurrencyData(ref currencyList);
                Application["exRate"] = currencyList[0].Rate;
                Application["curSym"] = curnSymbol;
                Application["ISOcur"] = curnVal;
                Application["cou_cur"] = Country + "(" + curnSymbol + ")";
               
            }
        }
        catch   

        {
            // Catch an exception
        }

      //  return exRate;
   } 
    
    



    [WebMethod]
    public MensClothe.Cart  DeleteCartItemClick(int itemid)
    {
        for (int i = profile.SCart.Items.Count - 1; i >= 0; i--)
        {
            if (profile.SCart.Items[i].ProductID == itemid)
            {
                profile.SCart.DeleteItem(i);
            }
        }

        return profile.SCart;
    }

    [WebMethod]
    public void DeleteAllCartItemClick()
    {
        for (int i = profile.SCart.Items.Count - 1; i >= 0; i--)
        {
            profile.SCart.DeleteItem(i);
        }
    }





    [WebMethod]
    public DAL.Customer getCustomerDetails(string cusID)
    {
        var CusRecord = DAL.Customer.getCustomerDetail(int.Parse(cusID));
        return CusRecord;
    }

    [WebMethod]
    public DAL.Suppliers getSupplierDetails(string SuppID)
    {
        var SuppRecord = DAL.Suppliers.getSuppliersDetail(int.Parse(SuppID));
        return SuppRecord;
    }



      [WebMethod]
    public Products getProductDetails(string prdID)
    {
        var PrdRecord = Products.getProductDetail(int.Parse(prdID));

        return PrdRecord;
    }

      [WebMethod]
      public Products getSellingDetail(string prdID)
      {
          var PrdRecord = Products.getProductDetail(int.Parse(prdID));

          return PrdRecord;
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
                price = p.price,
                imgURL = p.img,
                HTML = HtrmlString(p.name, AspControlUtil.formatPrice(double.Parse(p.price)), p.img, p.ItemID.ToString()).ToString()
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
        string image = AspControlUtil.getFullImagePath(Convert.ToString(imgurl));
        //   if (result != null)
        {
            sb.Append("<table width=\"260px\" cellpadding=\"3\" cellspacing=\"0\" bordercolor=\"#0000FF\" class=\"tmplreftbl\">\n");
            sb.Append("             <tr>\n");
            sb.Append("             <td class=\"tmplrefth\" ><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label>Product Name </label></span></td>\n");
            sb.Append("             <td class=\"tmplrefth\" ><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label> Price </label></span></td>\n");
            sb.Append("             <td class=\"tmplrefth\" ><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label> Picture </label></span></td>\n");
            sb.Append("             </tr>\n");
            //          foreach (var item in result)
            {

                sb.Append("         <tr>\n");
                sb.Append("         <td class=\"tmplrefth\" ><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label> " + name + "</label></span></td>\n");
                sb.Append("         <td class=\"tmplrefth\" ><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><label>" + price + " </label></span></td>\n");
                sb.Append("         <td class=\"tmplrefth\" ><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><img src=\' " + image + "' alt=\"Template Preview\" onclick='SelectedItemClick(" + id + ");' style=\"width:100px;height:150px;\" /></span></td>\n");
                sb.Append("         <td class=\"tmplrefth\" ><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><input id=\' " + id + "' onclick='Add2CartClick(this);' type=\"submit\" name=\'" + id + "'  value=\"Add to Cart\" /></span></td>\n");
                sb.Append("         <td class=\"tmplrefth\" ><span style=\"font-family:Tahoma, Verdana, Trebuchet MS, Arial\"><input id=\' " + string.Concat("i-", id) + "' onclick='ViewDetailClick(this);' type=\"submit\" name=\'" + string.Concat("i-", id) + "'  value=\"View Detals\"  /></span></td>\n");
                sb.Append("         </tr>\n");
            }
            sb.Append("           </table>\n");
        }
        return sb;
    }











}
