﻿#pragma checksum "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3F3B19F57CF1C44F221D7971A472DAF84642910E"
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
    
    
    public class _Page_Admin_Products_RemoveItem_cshtml : System.Web.WebPages.WebPage {
        
#line hidden
        
        public _Page_Admin_Products_RemoveItem_cshtml() {
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

            
            #line 7 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
  
    Layout = "~/_SiteLayout.cshtml";
    Page.Title = "Clothes";
    dynamic ProductRecord =null ;
    var Price = "";
    var quantity = "";
    var Description = "";
    var clotheId = 0;
    Database db;
    var items = new List<SelectListItem>();
    var i = 0;
    
    Validation.RequireField("ItemName", "You must specify the  Products name.");
    Validation.RequireField("Price", "Price cannot be blank.");
    Validation.RequireField("ItemImage", "Choose Item Image");
    Validation.RequireField("Size", "Sizerequired ");

     if (IsPost)
     {
         var detailForm = Request.Form["detailform"];
         var delDetail = Request.Form["deleteDetail"];
         var delConfirm = Request.Form["deleteConfirm"];

  
         if (!string.IsNullOrEmpty(Request.Form["DDLid"]))
         {
           Session.Add("clotheId", Request.Form["DDLid"]) ;
         }
      
    if (delDetail != null && Session["clotheId"]!= null)
    {
            clotheId = int.Parse(Session["clotheId"].ToString());
            db = Database.Open("mensClothe");
            ProductRecord = db.QuerySingle("SELECT Description, Price, QOH FROM  Products Where ItemID=@0 ", clotheId);
            if(ProductRecord != null)
            {
                Price = Convert.ToString( ProductRecord["Price"]);
                quantity = Convert.ToString(ProductRecord["Description "]);
                Description =Convert.ToString( ProductRecord["QOH"]) ;
            } 
    }
    else if (delConfirm != null && Session["clotheId"]!=null)
    {
         clotheId = int.Parse(Session["clotheId"].ToString());
         db = Database.Open("mensClothe");
         i = db.Execute("DELETE FROM  Products WHERE ItemID = @0 ", clotheId);
   
    
    }
    
    
     }
    
    

        

            
        
            
            // Insert a new item into the database
             db = Database.Open("mensClothe");

            // Check if user already exists
            var user = db.Query("SELECT * FROM  Products ");
            
            if(user != null)
            {

               items.Add(new SelectListItem { Text = "Select....", Value = "" });
               foreach(var item in user)
               {

                   items.Add(new SelectListItem { Text = item["ItemName"], Value = Convert.ToString( item["ItemID"]) });
                   
               }
            
            }
            
               
            
        
    

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<hgroup");

WriteLiteral(" class=\"title\"");

WriteLiteral(">\r\n    <h1>");

            
            #line 93 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
   Write(Page.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h1>\r\n    <h2>Delete Products Item</h2>\r\n</hgroup>\r\n\r\n<form");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 98 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
Write(AntiForgery.GetHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 100 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
Write(Html.ValidationSummary("Adding Products was unsuccessful. Please correct the errors and try again.", excludeFieldErrors: true, htmlAttributes: null));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <fieldset>\r\n        <legend>Registration Form</legend>\r\n        <ol>\r\n\r\n " +
"           <li");

WriteLiteral(" class=\"Clothes\"");

WriteLiteral(">\r\n                <label  >\r\n                    Select Products Item to be Dele" +
"ted:\r\n                </label>\r\n");

WriteLiteral("                ");

            
            #line 110 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
           Write(Html.DropDownList("DDLid",    items));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n\r\n\r\n            </li>\r\n             \r\n        </ol>\r\n   \r\n    <div");

WriteLiteral(" id=\"detailform\"");

WriteLiteral("   ");

            
            #line 119 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
                            if(ProductRecord == null)
                           {
            
            #line default
            #line hidden
WriteLiteral("style=\"display:none;\"");

            
            #line 120 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
                                                              }
            
            #line default
            #line hidden
WriteLiteral("\">\r\n\r\n        <ol>            \r\n\r\n            <li class=\"Price\">\r\n               " +
" <label>\r\n                    Price</label>\r\n                <input type=\"text\" " +
"id=\"Price\" name=\"Price\" value=\"");

            
            #line 127 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
                                                             Write(Price);

            
            #line default
            #line hidden
WriteLiteral("\" ) />\r\n                ");

WriteLiteral("\r\n              \r\n            </li>\r\n            <li class=\"ItemImage\">\r\n        " +
"        <label for=\"ItemImage\">\r\n                    Quantity</label>\r\n         " +
"       <input type=\"text\" id=\"quantity\" name=\"quantity\"  value=\"");

            
            #line 134 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
                                                                    Write(quantity);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n            </li>\r\n           \r\n            <li class=\"description\">\r\n     " +
"           <label>\r\n                    Description</label>\r\n                <in" +
"put type=\"text\" id=\"Desc\" name=\"Description\"  value=\"");

            
            #line 140 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
                                                                   Write(Description);

            
            #line default
            #line hidden
WriteLiteral(@""" />
            </li>
            <li class=""recaptcha""></li>
        </ol>
        <input type=""submit"" id=""deleteConfirm"" name=""deleteConfirm"" value=""Confirm"" />
       </div>
  </fieldset>
    <p>
    <input type=""submit"" id=""deleteDetail""  name=""deleteDetail"" value=""Delete Products Item""  ");

            
            #line 148 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
                                                                                               if (ProductRecord != null)
                            {
            
            #line default
            #line hidden
WriteLiteral("style=\"display:none;\"");

            
            #line 149 "I:\Company\MensClothe\Admin\Products\RemoveItem.cshtml"
                                                               }
            
            #line default
            #line hidden
WriteLiteral("\" />\r\n   </p>\r\n    <ul>\r\n        <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 4747), Tuple.Create("\"", 4756)
, Tuple.Create(Tuple.Create("", 4754), Tuple.Create<System.Object, System.Int32>(Href("~/")
, 4754), false)
);

WriteLiteral(">Home</a></li>\r\n        <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 4787), Tuple.Create("\"", 4807)
, Tuple.Create(Tuple.Create("", 4794), Tuple.Create<System.Object, System.Int32>(Href("~/Admin/Admin")
, 4794), false)
);

WriteLiteral(">Admin</a></li>\r\n        \r\n    </ul>\r\n</form>");

        }
    }
}
