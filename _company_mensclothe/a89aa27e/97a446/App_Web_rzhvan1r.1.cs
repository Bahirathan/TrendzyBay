﻿#pragma checksum "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A03FC232D4E817DF4614D4E581EA5DDE0C3DBAED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using System.Web.WebPages.Html;
    using WebMatrix.Data;
    using WebMatrix.WebData;
    using Microsoft.Web.WebPages.OAuth;
    using DotNetOpenAuth.AspNet;
    
    
    public class _Page_Admin_Orders_AddOrders_cshtml : System.Web.WebPages.WebPage {
        
#line hidden
        
        public _Page_Admin_Orders_AddOrders_cshtml() {
        }
        
        protected ASP.global_asax ApplicationInstance {
            get {
                return ((ASP.global_asax)(Context.ApplicationInstance));
            }
        }
        
        public override void Execute() {
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 84), Tuple.Create("\"", 122)
, Tuple.Create(Tuple.Create("", 90), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.validate.min.js")
, 90), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 146), Tuple.Create("\"", 196)
, Tuple.Create(Tuple.Create("", 152), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.validate.unobtrusive.min.js")
, 152), false)
);

WriteLiteral("></script>\r\n");

});

WriteLiteral("\r\n");

            
            #line 7 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
  
    Layout = "~/_SiteLayout.cshtml";
    Page.Title = "Clothess";

    // Initialize general page variables
    var ItemName = "";
    var Price = "";
    var ItemImage = "";
    byte[] imgStream = null; 
    var quantity = "";
    var size = "";
    var Description = "";
    var ms = new MemoryStream();
    Database Dbase = new DAL.DbConnection().db;
 
    
    
    // Setup validation
    Validation.RequireField("ItemName", "You must specify the  Clothes name.");
    Validation.RequireField("Price", "Price cannot be blank.");
    //Validation.RequireField("ItemImage", "Choose Item Image");
    Validation.RequireField("Size", "Size required ");
    
    
   
    if (IsPost) {
        AntiForgery.Validate();

      HttpPostedFileBase file = Request.Files["ItemImage"];
      if(file != null)
      {
       ms = new MemoryStream();
        file.InputStream.CopyTo(ms);
         // imgStream = ms.ToArray();
      } 
        
        
        ItemName = Request.Form["ItemName"];
        Price = Request.Form["Price"];
        ItemImage = Request.Form["ItemImage"];

        quantity = Request.Form["quantity"];
        size = Request.Form["size"];
        Description = Request.Form["Description"];

        System.Drawing.Bitmap image = new System.Drawing.Bitmap(ms);
        MemoryStream stream = new MemoryStream(16498);
        image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
        var img = file.FileName.ToString();  //stream.ToArray();
        
        
        if (Validation.IsValid()) {

           // var connectionString = "Data Source=.\\SQLExpress;Initial Catalog=mensStore;Integrated Security=True";
       //     var connectionString = "server=.\\SQLExpress;uid=sa;pwd=love123all;database=mensStore;";
       //   var OfficeconnectionString =  "Data Source=LGSM-PC\\MSSQL2012;Initial Catalog=mensStore;Integrated Security=False;User ID=sa;Password=love123all;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
         //   var HomeconnectionString="Data Source=(localdb)\\Projects;Initial Catalog=mensStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        //    var providerName = "System.Data.SqlClient";

        //    var db = Dbase.OpenConnectionString(OfficeconnectionString, providerName);
            
         // Insert a new user into the database
          //  var db = Database.Open("ConStr");

            //Dbase.Execute("INSERT INTO Products (productname,Price, ItemImage, QOH, Size,Description) VALUES (@0,@1,@2,@3,@4,@5 )", ItemName, Price, img, quantity, size, Description);
            Products prd = new Products();
          //  int result = Products.insert(ItemName, Price, img, quantity, size, Description);
          // if(result== 0)
           {
               string url = "~/ErrorPage?ErrorMessage=" + "Dabse Error Occured";
               Response.Redirect(url);
           }
            
                // Create and associate a new entry in the membership database.
                // If successful, continue processing the request
               
            
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<hgroup");

WriteLiteral(" class=\"title\"");

WriteLiteral(">\r\n    <h1>");

            
            #line 89 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
   Write(Page.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h1>\r\n    <h2>Add a new Products Item</h2>\r\n</hgroup>\r\n\r\n<form");

WriteLiteral(" method=\"post\"");

WriteLiteral("  enctype=\"multipart/form-data\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 94 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
Write(AntiForgery.GetHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 96 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
Write(Html.ValidationSummary("Adding Products was unsuccessful. Please correct the errors and try again.", excludeFieldErrors: true, htmlAttributes: null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <fieldset>\r\n        <legend>Registration Form</legend>\r\n        <ol>\r\n   " +
"         \r\n            <li");

WriteLiteral(" class=\"Clothes\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"Clothes\"");

WriteLiteral(" ");

            
            #line 103 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                      if (!ModelState.IsValidField("ItemName"))
                                     {
            
            #line default
            #line hidden
WriteLiteral("class=\"error-label\"");

            
            #line 104 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                                      }
            
            #line default
            #line hidden
WriteLiteral(">Products Name </label>\r\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ItemName\"");

WriteLiteral(" name=\"ItemName\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4182), Tuple.Create("\"", 4199)
            
            #line 105 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
, Tuple.Create(Tuple.Create("", 4190), Tuple.Create<System.Object, System.Int32>(ItemName
            
            #line default
            #line hidden
, 4190), false)
);

WriteLiteral(" ");

            
            #line 105 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                                              Write(Validation.For("ItemName"));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                ");

WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 107 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
           Write(Html.ValidationMessage("ItemName"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </li>\r\n            <li");

WriteLiteral(" class=\"Price\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"Price\"");

WriteLiteral(" ");

            
            #line 110 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                    if(!ModelState.IsValidField("Price")) {
            
            #line default
            #line hidden
WriteLiteral("class=\"error-label\"");

            
            #line 110 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                                                                           }
            
            #line default
            #line hidden
WriteLiteral(">Unit Price</label>\r\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Price\"");

WriteLiteral(" name=\"Price\"");

WriteLiteral(" ");

            
            #line 111 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                      Write(Validation.For("Price"));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                ");

WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 113 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
           Write(Html.ValidationMessage("Price"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </li>\r\n            <li");

WriteLiteral(" class=\"ItemImage\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"ItemImage\"");

WriteLiteral(" ");

            
            #line 116 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                        if(!ModelState.IsValidField("ItemImage")) {
            
            #line default
            #line hidden
WriteLiteral("class=\"error-label\"");

            
            #line 116 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                                                                                   }
            
            #line default
            #line hidden
WriteLiteral(">Image of the Products</label>\r\n                <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" id=\"ItemImage\"");

WriteLiteral(" name=\"ItemImage\"");

WriteLiteral("  />\r\n                ");

WriteLiteral("\r\n              </li>\r\n               <li");

WriteLiteral(" class=\"ItemImage\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"ItemImage\"");

WriteLiteral(" ");

            
            #line 121 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                        if(!ModelState.IsValidField("Quantity")) {
            
            #line default
            #line hidden
WriteLiteral("class=\"error-label\"");

            
            #line 121 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                                                                                  }
            
            #line default
            #line hidden
WriteLiteral(">Enter the quantity</label>\r\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"quantity\"");

WriteLiteral(" name=\"quantity\"");

WriteLiteral(" ");

            
            #line 122 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                            Write(Validation.For("quantity"));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                ");

WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 124 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
           Write(Html.ValidationMessage("Quantity"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </li>\r\n            <li");

WriteLiteral(" class=\"size\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"Size\"");

WriteLiteral(" ");

            
            #line 127 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                   if(!ModelState.IsValidField("Size")) {
            
            #line default
            #line hidden
WriteLiteral("class=\"error-label\"");

            
            #line 127 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                                                                         }
            
            #line default
            #line hidden
WriteLiteral(">Enter the Size </label>\r\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Size\"");

WriteLiteral(" name=\"Size\"");

WriteLiteral(" ");

            
            #line 128 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                    Write(Validation.For("Size"));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                ");

WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 130 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
           Write(Html.ValidationMessage("Size"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </li>\r\n\r\n            <li");

WriteLiteral(" class=\"description\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"ItemImage\"");

WriteLiteral(" ");

            
            #line 134 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                        if(!ModelState.IsValidField("Description")) {
            
            #line default
            #line hidden
WriteLiteral("class=\"error-label\"");

            
            #line 134 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                                                                                     }
            
            #line default
            #line hidden
WriteLiteral(">Enter the Description</label>\r\n                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Desc\"");

WriteLiteral(" name=\"Description\"");

WriteLiteral(" ");

            
            #line 135 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
                                                           Write(Validation.For("Description"));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                ");

WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 137 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
           Write(Html.ValidationMessage("Description"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </li>\r\n\r\n              <li>\r\n                   <label >Select the " +
"category  </label>\r\n                   <select");

WriteLiteral(" id=\"category\"");

WriteLiteral(" name=\"category\"");

WriteLiteral(">\r\n                        <option");

WriteLiteral(" value=\"1\"");

WriteLiteral(">Clothes</option>\r\n                        <option");

WriteLiteral(" value=\"2\"");

WriteLiteral(">Leather</option>\r\n                        <option");

WriteLiteral(" value=\"3\"");

WriteLiteral(">Accessories</option>\r\n                        <option");

WriteLiteral(" value=\"4\"");

WriteLiteral(">Cosmetics</option>\r\n                    </select>\r\n");

WriteLiteral("                    ");

            
            #line 148 "I:\Company\MensClothe\Admin\Orders\AddOrders.cshtml"
               Write(Html.ValidationMessage("category"));

            
            #line default
            #line hidden
WriteLiteral("\r\n             </li>\r\n\r\n\r\n            <li");

WriteLiteral(" class=\"recaptcha\"");

WriteLiteral(">\r\n                \r\n            </li>\r\n        </ol>\r\n        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Add Clothes\"");

WriteLiteral(" />\r\n    </fieldset>\r\n</form>");

        }
    }
}
