﻿#pragma checksum "I:\Company\MensClothe\HomePage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A77AD67CA6F5505D7974600625B4B10474195156"
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
    
    
    public class _Page_HomePage_cshtml : System.Web.WebPages.WebPage {
        
#line hidden
        
        public _Page_HomePage_cshtml() {
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

WriteAttribute("src", Tuple.Create(" src=\"", 33), Tuple.Create("\"", 71)
, Tuple.Create(Tuple.Create("", 39), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.validate.min.js")
, 39), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 95), Tuple.Create("\"", 145)
, Tuple.Create(Tuple.Create("", 101), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts/jquery.validate.unobtrusive.min.js")
, 101), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">

        function SelectedItemClick(id)
        {
            debugger;
            popupwin = window.open('Products/DetailProductResult' + ""?resultIndex="" + id + ""&isPopup=1"", 'Detail', 'height=' + 600 + ',width=' + 520 + ',scrollbars=yes,left=400,top=300');
            popupwin.focus();
        }


        $(document).ready(function () {



            $('#searchBox').autocomplete({
                autoFocus: true,
                minLength: 2,
                source: function (request, response) {
                    $.ajax({
                        type: ""POST"",
                        url: """);

            
            #line 25 "I:\Company\MensClothe\HomePage.cshtml"
                         Write(MensClothe.AspControlUtil.getAppPath());

            
            #line default
            #line hidden
WriteLiteral("Web_Service/WebService.asmx/SearchProduct\",\r\n                   data: \"{ \'searchS" +
"tring\': \'\" + request.term + \"\' }\",\r\n                   contentType: \"application" +
"/json; charset=utf-8\",\r\n                   dataType: \"json\",\r\n                  " +
" success: function (data) {\r\n                       response($.map(data.d, funct" +
"ion (item) {\r\n                           return {\r\n                             " +
"  label: item.Description,\r\n                               value: item.Descripti" +
"on,\r\n                               data: item\r\n                           }\r\n  " +
"                     }));\r\n                   },\r\n\r\n                   failure: " +
"function (errMsg) {\r\n                       alert(errMsg);\r\n                   }" +
"\r\n                });\r\n            },\r\n\r\n                //focus: function (even" +
"t, ui) {\r\n                //    $(\"#searchContent\").html(ui.item.data.HTML);\r\n  " +
"              //},\r\n\r\n\r\n\r\n\r\n                change: function (event, ui) {\r\n    " +
"                if (ui.item) {\r\n                        $(\"#searchContent\").html" +
"(ui.item.data.HTML);\r\n\r\n                    }\r\n                    //} else\r\n   " +
"                 //{\r\n                    //    $(\"#searchContent\").val(\"\");\r\n  " +
"                  //}\r\n                    //$(\"#searchContent\").val(\"\");\r\n     " +
"           },\r\n\r\n                select: function (event, ui) {\r\n\r\n             " +
"       //   if (TrnsLocation == \"#<%=AutotrnsPickupLocation.ClientID %>\")\r\n     " +
"               {\r\n                        alert(ui.item.data.HTML);\r\n           " +
"             $(\"#searchContent\").html(ui.item.data.HTML);\r\n                    }" +
"\r\n\r\n                }\r\n            });\r\n\r\n        });\r\n\r\n\r\n   function OnSuccees" +
"s() {\r\n   }\r\n   function OnError() {\r\n   }\r\n\r\n    </script>\r\n\r\n    ");

});

WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");

            
            #line 97 "I:\Company\MensClothe\HomePage.cshtml"
  
    Layout = "~/_SiteLayout.cshtml";
    Page.Title = "Home Page";

    
    
    // Initialize general page variables
    var email = "";
    var password = "";
    var confirmPassword = "";



    

    // If this is a POST request, validate and process data
    if (IsPost) {
        AntiForgery.Validate();
        email = Request.Form["email"];
        password = Request.Form["password"];
        confirmPassword = Request.Form["confirmPassword"];

        // Validate the user's captcha answer
        // if (!ReCaptcha.Validate("PRIVATE_KEY")) {
        //     ModelState.AddError("recaptcha", "Captcha response was not correct");
        // }

        // If all information is valid, create a new account
        if (Validation.IsValid()) {
            // Insert a new user into the database
            var db = Database.Open("mensClothe");

            // Check if user already exists
            var user = db.QuerySingle("SELECT Email FROM UserProfile WHERE LOWER(Email) = LOWER(@0)", email);
            if (user == null) {
                // Insert email into the profile table
                db.Execute("INSERT INTO UserProfile (Email) VALUES (@0)", email);

                // Create and associate a new entry in the membership database.
                // If successful, continue processing the request
                try {
                    bool requireEmailConfirmation = !WebMail.SmtpServer.IsEmpty();
                    var token = WebSecurity.CreateAccount(email, password, requireEmailConfirmation);
                    if (requireEmailConfirmation) {
                        var hostUrl = Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
                        var confirmationUrl = hostUrl + VirtualPathUtility.ToAbsolute("~/Account/Confirm?confirmationCode=" + HttpUtility.UrlEncode(token));

                        WebMail.Send(
                            to: email,
                            subject: "Please confirm your account",
                            body: "Your confirmation code is: " + token + ". Visit <a href=\"" + confirmationUrl + "\">" + confirmationUrl + "</a> to activate your account."
                        );
                    }

                    if (requireEmailConfirmation) {
                        // Thank the user for registering and let them know an email is on its way
                        Response.Redirect("~/Account/Thanks");
                    } else {
                        // Navigate back to the homepage and exit
                        WebSecurity.Login(email, password);

                        Response.Redirect("~/");
                    }
                } catch (System.Web.Security.MembershipCreateUserException e) {
                    ModelState.AddFormError(e.Message);
                }
            } else {
                // User already exists
                ModelState.AddFormError("Email address is already in use.");
            }
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n \r\n \r\n\r\n");

DefineSection("featured", () => {

WriteLiteral("\r\n<section");

WriteLiteral(" class=\"featured\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"content-wrapper\"");

WriteLiteral(">\r\n        <hgroup");

WriteLiteral(" class=\"title\"");

WriteLiteral(">\r\n            <h1>");

            
            #line 178 "I:\Company\MensClothe\HomePage.cshtml"
           Write(Page.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h1>\r\n            <h2>Men\'s Online Store</h2>\r\n        </hgroup>\r\n      \r\n     " +
"   <p>\r\n           <input");

WriteLiteral(" id=\"searchBox\"");

WriteLiteral(" type=\"text\"");

WriteLiteral("   />\r\n        </p>\r\n    </div>\r\n\r\n   \r\n\r\n\r\n\r\n</section>\r\n");

});

WriteLiteral("\r\n<h3>Products</h3>\r\n <div");

WriteLiteral("  id=\"searchContent\"");

WriteLiteral(" class=\"content-wrapper\"");

WriteLiteral(" >\r\n </div>\r\n\r\n<ol");

WriteLiteral(" class=\"round\"");

WriteLiteral(">\r\n   \r\n     <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6158), Tuple.Create("\"", 6190)
, Tuple.Create(Tuple.Create("", 6165), Tuple.Create<System.Object, System.Int32>(Href("~/Products/ProductResults")
, 6165), false)
);

WriteLiteral(">All Products</a>\r\n\r\n    <li");

WriteLiteral(" class=\"one\"");

WriteLiteral(">\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6244), Tuple.Create("\"", 6282)
, Tuple.Create(Tuple.Create("", 6251), Tuple.Create<System.Object, System.Int32>(Href("~/Products/ProductResults?cat=1")
, 6251), false)
);

WriteLiteral(">Clothes</a>\r\n    </li>\r\n\r\n    <li");

WriteLiteral(" class=\"two\"");

WriteLiteral(">\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6342), Tuple.Create("\"", 6380)
, Tuple.Create(Tuple.Create("", 6349), Tuple.Create<System.Object, System.Int32>(Href("~/Products/ProductResults?cat=2")
, 6349), false)
);

WriteLiteral(">Leather</a>\r\n    </li>\r\n\r\n    <li");

WriteLiteral(" class=\"three\"");

WriteLiteral(">\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6442), Tuple.Create("\"", 6480)
, Tuple.Create(Tuple.Create("", 6449), Tuple.Create<System.Object, System.Int32>(Href("~/Products/ProductResults?cat=3")
, 6449), false)
);

WriteLiteral(">Cosmetic</a>\r\n    </li>\r\n\r\n    <li");

WriteLiteral(" class=\"three\"");

WriteLiteral(">\r\n        \r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6553), Tuple.Create("\"", 6591)
, Tuple.Create(Tuple.Create("", 6560), Tuple.Create<System.Object, System.Int32>(Href("~/Products/ProductResults?cat=4")
, 6560), false)
);

WriteLiteral(">Accesories</a>\r\n    </li>\r\n\r\n     \r\n\r\n</ol>");

        }
    }
}
