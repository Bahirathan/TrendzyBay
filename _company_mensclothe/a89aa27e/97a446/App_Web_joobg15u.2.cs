﻿#pragma checksum "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D06A9735F2E7E908B5C908C793E0A116A98D043D"
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
    
    
    public class _Page_Admin_Customer_ViewCustomers_cshtml : System.Web.WebPages.WebPage {
        
#line hidden
        
        public _Page_Admin_Customer_ViewCustomers_cshtml() {
        }
        
        protected ASP.global_asax ApplicationInstance {
            get {
                return ((ASP.global_asax)(Context.ApplicationInstance));
            }
        }
        
        public override void Execute() {
WriteLiteral("\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 86), Tuple.Create("\"", 124)
, Tuple.Create(Tuple.Create("", 92), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.validate.min.js")
, 92), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 148), Tuple.Create("\"", 198)
, Tuple.Create(Tuple.Create("", 154), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.validate.unobtrusive.min.js")
, 154), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n\r\n        $(document).ready(function () {\r\n\r\n        });\r\n\r\n    </script>\r\n\r\n");

});

WriteLiteral("\r\n\r\n\r\n\r\n");

            
            #line 19 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
  
    Layout = "~/_SiteLayout.cshtml";
    Page.Title = "Clothes";
    List<DAL.Customer> CustomerRecords = new List<DAL.Customer>();
    var items = new List<DAL.Customer>();
    CustomerRecords = DAL.Customer.getAllCustomers();
       

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n\r\n<form");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n\r\n");

WriteLiteral("    ");

            
            #line 32 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
Write(AntiForgery.GetHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");

WriteLiteral("\r\n    <div");

WriteLiteral(" id=\"detailform\"");

WriteLiteral("   ");

            
            #line 34 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
                            if (CustomerRecords == null)
                           {
            
            #line default
            #line hidden
WriteLiteral("style=\"display:none;\"");

            
            #line 35 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
                                                              }
            
            #line default
            #line hidden
WriteLiteral("\">\r\n\r\n\r\n\r\n        <table>\r\n\r\n");

            
            #line 41 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
            
            
            #line default
            #line hidden
            
            #line 41 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
             foreach (var item in CustomerRecords)
            { 

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>\r\n                        <label>\r\n" +
"                            Name:\r\n                        </label>\r\n           " +
"              <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"txtName\"");

WriteLiteral(" name=\"txtName\"");

WriteAttribute("value", Tuple.Create("  value=\"", 1150), Tuple.Create("\"", 1177)
            
            #line 48 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
, Tuple.Create(Tuple.Create("", 1159), Tuple.Create<System.Object, System.Int32>(item.customername
            
            #line default
            #line hidden
, 1159), false)
);

WriteLiteral(" />\r\n                        <label");

WriteLiteral(" for=\"txtAddress\"");

WriteLiteral(">\r\n                            Address:\r\n                        </label>\r\n      " +
"                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"txtAddress\"");

WriteLiteral(" name=\"txtAddress\"");

WriteAttribute("value", Tuple.Create("  value=\"", 1383), Tuple.Create("\"", 1405)
            
            #line 52 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
       , Tuple.Create(Tuple.Create("", 1392), Tuple.Create<System.Object, System.Int32>(item.Address
            
            #line default
            #line hidden
, 1392), false)
);

WriteLiteral("   />\r\n                       \r\n                         <label");

WriteLiteral(" for=\"txtCity\"");

WriteLiteral(">\r\n                            City:\r\n                        </label>\r\n         " +
"                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"txtCity\"");

WriteLiteral(" name=\"txtCity\"");

WriteAttribute("value", Tuple.Create("   value=\"", 1626), Tuple.Create("\"", 1646)
            
            #line 57 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
 , Tuple.Create(Tuple.Create("", 1636), Tuple.Create<System.Object, System.Int32>(item.City
            
            #line default
            #line hidden
, 1636), false)
);

WriteLiteral(" />\r\n                       \r\n                        <label");

WriteLiteral(" for=\"txtState\"");

WriteLiteral(">\r\n                            State/Province:\r\n                        </label>\r" +
"\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"txtState\"");

WriteLiteral(" name=\"txtState\"");

WriteAttribute("value", Tuple.Create("  value=\"", 1876), Tuple.Create("\"", 1896)
            
            #line 62 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
 , Tuple.Create(Tuple.Create("", 1885), Tuple.Create<System.Object, System.Int32>(item.State
            
            #line default
            #line hidden
, 1885), false)
);

WriteLiteral(" />\r\n                        &nbsp;&nbsp; \r\n                       \r\n            " +
"             <label");

WriteLiteral(" for=\"ZipCode\"");

WriteLiteral(">\r\n                            Zip/Postal Code:\r\n                        </label>" +
"\r\n                         <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"txtZip\"");

WriteLiteral(" name=\"txtZip\"");

WriteAttribute("value", Tuple.Create("  value=\"", 2163), Tuple.Create("\"", 2185)
            
            #line 68 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
, Tuple.Create(Tuple.Create("", 2172), Tuple.Create<System.Object, System.Int32>(item.Zipcode
            
            #line default
            #line hidden
, 2172), false)
);

WriteLiteral(" />\r\n                       \r\n                        <label>Country:</label>\r\n  " +
"                       <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Country\"");

WriteLiteral(" name=\"txtZip\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2335), Tuple.Create("\"", 2356)
            
            #line 71 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
, Tuple.Create(Tuple.Create("", 2343), Tuple.Create<System.Object, System.Int32>(item.Country
            
            #line default
            #line hidden
, 2343), false)
);

WriteLiteral(" />\r\n                       \r\n                        <label");

WriteLiteral(" for=\"txtEmail\"");

WriteLiteral(">\r\n                            Email:\r\n                        </label>\r\n        " +
"                <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"txtEmail\"");

WriteLiteral(" name=\"txtEmail\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2577), Tuple.Create("\"", 2596)
            
            #line 76 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
, Tuple.Create(Tuple.Create("", 2585), Tuple.Create<System.Object, System.Int32>(item.Email
            
            #line default
            #line hidden
, 2585), false)
);

WriteLiteral(" />\r\n                        <label");

WriteLiteral(" for=\"txtPhone\"");

WriteLiteral(">\r\n                            Phone:\r\n                        </label>\r\n        " +
"                  <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"txtPhone\"");

WriteLiteral(" name=\"txtPhone\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2794), Tuple.Create("\"", 2813)
            
            #line 80 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
  , Tuple.Create(Tuple.Create("", 2802), Tuple.Create<System.Object, System.Int32>(item.phone
            
            #line default
            #line hidden
, 2802), false)
);

WriteLiteral(" />\r\n\r\n                    </td>\r\n                    <td>\r\n \r\n                  " +
"  </td>\r\n                </tr>\r\n");

            
            #line 87 "I:\Company\MensClothe\Admin\Customer\ViewCustomers.cshtml"
          
           
        
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n    </div>\r\n    <ul>\r\n        <li><a href=\"~/\">Home</a></li>\r\n " +
"       <li><a href=\"~/Admin/Admin\">Admin</a></li>\r\n    </ul>\r\n</form>\r\n");

        }
    }
}
