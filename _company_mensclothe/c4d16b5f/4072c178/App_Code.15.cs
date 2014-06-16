#pragma checksum "G:\Company\MensClothe\App_Code\Order\OrderClass.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6C6730F8EA67E285EF856EC53A30F7B80D5435A7"

#line 1 "G:\Company\MensClothe\App_Code\Order\OrderClass.cs"
using PayPalIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Westwind.Tools;
using Westwind.WebStore;

/// <summary>
/// Summary description for OrderClass
/// </summary>
/// 

public class OrderClass
{
    public string lblErrorMessage { get; set; }
    public OrderClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

   
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
   

    /// <summary>
    /// Required internal variable that lets us know if
    /// we are returning from PayPal. This flag can be used
    /// to bypass other processing that might be happening
    /// for Credit Cards or whatever.
    /// 
    /// This gets set by HandlePayPalReturn. Not used in this
    /// demo. Refer to article to see how it's used in a more
    /// complex environment.
    /// </summary>
    private bool PayPalReturnRequest = false;

    /// <summary>
    /// Our ever so complicated ORDER DATA. Hey this is supposed to be 
    /// a quick demo and skeleton, so I kept it as simple as possible.
    /// The article shows a more complex environment!
    /// </summary>
    protected decimal OrderAmount = 0.00M;

   

    /// <summary>
    /// Saves the invoice if all goes well!
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
  


    /// <summary>
    /// Redirects the current request to the PayPal site by passing a querystring.
    /// PayPal then should return to this page with ?PayPal=Cancel or ?PayPal=Success
    /// This routine stores all the form vars so they can be restored later
    /// </summary>
    public void HandlePayPalRedirection()
    {

        // *** Set a flag so we know we redirected
        HttpContext.Current.Session["PayPal_Redirected"] = "True";

        // *** Save any values you might need when you return here
        HttpContext.Current.Session["PayPal_OrderAmount"] = this.OrderAmount;  // already saved above

        //			Session["PayPal_HeardFrom"] = this.txtHeardFrom.Text;
        //			Session["PayPal_ToolUsed"] = this.txtToolUsed.Text;

        PayPalHelper PayPal = new PayPalHelper();
        PayPal.PayPalBaseUrl = App.Configuration.PayPalUrl;
        PayPal.AccountEmail = App.Configuration.AccountEmail;
        PayPal.Amount = this.OrderAmount;


        //PayPal.LogoUrl = "https://www.west-wind.com/images/wwtoollogo_text.gif";

        PayPal.ItemName = "West Wind Web Store Invoice #" + new Guid().GetHashCode().ToString("x");

        // *** Have paypal return back to this URL
        PayPal.SuccessUrl = HttpContext.Current.Request.Url + "?PayPal=Success";
        PayPal.CancelUrl = HttpContext.Current.Request.Url + "?PayPal=Cancel";

        HttpContext.Current.Response.Redirect(PayPal.GetSubmitUrl());

        return;
    }

    /// <summary>
    /// Handles the return processing from a PayPal Request.
    /// Looks at the PayPal Querystring variable
    /// </summary>


    public bool ProcessCreditCard(Customer customer, CCard cCard, string OrderAmount)
    {
        bool Result = false;

        ccProcessing CC = null;
        ccProcessors CCType = App.Configuration.CCProcessor;

        try
        {
            // *** Figure out which type to use
            if (CCType == ccProcessors.AccessPoint)
            {
                CC = new ccAccessPoint();
            }
            else if (CCType == ccProcessors.AuthorizeNet)
            {
                CC = new ccAuthorizeNet();
                CC.MerchantPassword = App.Configuration.CCMerchantPassword;
            }
            else if (CCType == ccProcessors.PayFlowPro)
            {
                CC = new ccPayFlowPro();
                CC.MerchantPassword = App.Configuration.CCMerchantPassword;
            }
            else if (CCType == ccProcessors.LinkPoint)
            {
                CC = new ccLinkPoint();
                CC.MerchantPassword = App.Configuration.CCMerchantId;
                CC.CertificatePath = App.Configuration.CCCertificatePath;   // "d:\app\MyCert.pem"
            }


            //CC.UseTestTransaction = true;

            // *** Tell whether we do SALE or Pre-Auth
            CC.ProcessType = App.Configuration.CCProcessType;

            // *** Disable this for testing to get provider response
            CC.UseMod10Check = true;

            CC.Timeout = App.Configuration.CCConnectionTimeout;  // In Seconds
            CC.HttpLink = App.Configuration.CCHostUrl;			 // The host Url format will vary with provider
            CC.MerchantId = App.Configuration.CCMerchantId;

            CC.LogFile = App.Configuration.CCLogFile;
            CC.ReferringUrl = App.Configuration.CCReferingOrderUrl;

            // *** Name can be provided as a single string or as firstname and lastname
            CC.Name = customer.FirstName;
            //CC.Firstname = Cust.Firstname.TrimEnd();
            //CC.Lastname = Cust.Lastname.TrimEnd();
            // CC.Company = Cust.Company.TrimEnd();

            CC.Address = customer.Address;
            CC.State = customer.State;
            CC.City = customer.City;
            CC.Zip = customer.Zipcode;
            CC.Country = customer.Country;	// 2 Character Country ID
            CC.Phone = customer.phone;
            CC.Email = customer.Email;

            CC.OrderAmount = decimal.Parse(OrderAmount);

            //CC.TaxAmount = Inv.Tax;					// Optional

            CC.CreditCardNumber = cCard.CreditCardNumber;
            CC.CreditCardExpiration = cCard .CreditCardExpiration;
            CC.SecurityCode = cCard.SecurityCode;

            // *** Make this Unique
            //CC.OrderId = Inv.Invno.TrimEnd() + "_" + DateTime.Now.ToString();
            CC.Comment = "Test Order # " + new Guid().GetHashCode().ToString("x");

            Result = CC.ValidateCard();

            if (!Result)
            {
                this.lblErrorMessage = CC.ValidatedMessage +
                    "<hr>" +
                    CC.ErrorMessage;
            }
            else
            {
                // *** Should be APPROVED
                this.lblErrorMessage = CC.ValidatedMessage;
            }


            // *** Always write out the raw response
            if (wwUtils.Empty(CC.RawProcessorResult))
            {
                this.lblErrorMessage += "<hr>" + "Raw Results:<br>" +
                                             CC.RawProcessorResult;
            }
        }
        catch (Exception ex)
        {

            this.lblErrorMessage = "FAILED<hr>" +
                                        "Processing Error: " + ex.Message;

            return false;
        }

        return Result;
    }


    //public void HandlePayPalReturn()
    //{
    //    bool PayPalReturnRequest;
    //    string Result = HttpContext.Current.Request.QueryString["PayPal"];
    //    string Redir = (string)HttpContext.Current.Session["PayPal_Redirected"];

    //    // *** Only do this if we are redirected!
    //    if (Redir == "True")
    //    {
    //        HttpContext.Current.Session.Remove("PayPal_Redirected");

    //        // *** Set flag so we know not to go TO PayPal again
    //        PayPalReturnRequest = true;

    //        // *** Retrieve saved Page content
    //        if (!IsPost)
    //        {
    //            Request.Form["txtOrderAmount"] = ((decimal)HttpContext.Current.Session["PayPal_OrderAmount"]).ToString();
    //            Request.Form["txtCCType"] = "PP";

    //            //				this.txtNotes.Text = (string) Session["PayPal_Notes"];
    //            //				this.txtHeardFrom.Text = (string) Session["PayPal_HeardFrom"];
    //            //				this.txtToolUsed.Text = (string) Session["PayPal_ToolUsed"];
    //        }
    //        if (Result == "Cancel")
    //        {
    //            Response.Write("<script>alert('PayPal Payment Processing Failed');</script>");
    //        }
    //        else
    //        {
    //            // *** We returned successfully - simulate button click to save the order
    //            string script = "btnSubmit_Click();";
    //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", script, true);

    //        }
    //    }


    //}


    //void ShowError(string ErrorMessage)
    //{
    //    this.lblErrorMessage.Text = ErrorMessage + "<p>";
    //}

    protected void TextBox8_TextChanged(object sender, System.EventArgs e)
    {

    }


}


#line default
#line hidden
