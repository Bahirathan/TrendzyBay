﻿#pragma checksum "G:\Company\MensClothe\Account\ForgotPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C7549A94AD8355787B3A4DC42CF1FCAC40BDF1E8"
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
    
    
    public class _Page_Account_ForgotPassword_cshtml : System.Web.WebPages.WebPage {
        
#line hidden
        
        public _Page_Account_ForgotPassword_cshtml() {
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

            
            #line 7 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
  
    Layout = "~/_SiteLayout.cshtml";
    Page.Title = "Forget Your Password";

    bool passwordSent = false;
    var resetToken = "";
    var email = Request.Form["email"] ?? Request.QueryString["email"];

    // Setup validation
    Validation.RequireField("email", "The email address field is required.");

    if (IsPost) {
        AntiForgery.Validate();
        // validate email
        bool isValid = true;
        if (Validation.IsValid()) {
            if (WebSecurity.GetUserId(email) > -1 && WebSecurity.IsConfirmed(email)) {
                resetToken = WebSecurity.GeneratePasswordResetToken(email); // Optionally specify an expiration date for the token
            } else {
                passwordSent = true; // We don't want to disclose that the user does not exist.
                isValid = false;
            }
        }
        if (isValid) {
            var hostUrl = Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
            var resetUrl = hostUrl + VirtualPathUtility.ToAbsolute("~/Account/PasswordReset?resetToken=" + HttpUtility.UrlEncode(resetToken));
            WebMail.Send(
                to: email,
                subject: "Please reset your password", 
                body: "Use this password reset token to reset your password. The token is: " + resetToken + @". Visit <a href=""" + HttpUtility.HtmlAttributeEncode(resetUrl) + @""">" + resetUrl + "</a> to reset your password."
            );
            passwordSent = true;
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<hgroup");

WriteLiteral(" class=\"title\"");

WriteLiteral(">\r\n    <h1>");

            
            #line 44 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
   Write(Page.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h1>\r\n    <h2>Use the form below to reset your password.</h2>\r\n</hgroup>\r\n\r\n");

            
            #line 48 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
 if (!WebMail.SmtpServer.IsEmpty()) {

            
            #line default
            #line hidden
WriteLiteral("    <p>\r\n        We will send password reset instructions to the email address as" +
"sociated with your account.\r\n    </p>\r\n");

            
            #line 52 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"

    if (passwordSent) {

            
            #line default
            #line hidden
WriteLiteral("        <p");

WriteLiteral(" class=\"message-success\"");

WriteLiteral(">\r\n            Instructions to reset your password have been sent to the specifie" +
"d email address.\r\n        </p>\r\n");

            
            #line 57 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
    }


            
            #line default
            #line hidden
WriteLiteral("    <form");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 60 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
   Write(AntiForgery.GetHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 61 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
   Write(Html.ValidationSummary(excludeFieldErrors: true));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        <fieldset>\r\n            <legend>Password Reset Instructions Form</leg" +
"end>\r\n            <ol>\r\n                <li");

WriteLiteral(" class=\"email\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"email\"");

WriteLiteral(" ");

            
            #line 67 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
                                        if (!ModelState.IsValidField("email")) {
            
            #line default
            #line hidden
WriteLiteral("class=\"error-label\"");

            
            #line 67 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
                                                                                                                }
            
            #line default
            #line hidden
WriteLiteral(">Email address</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"email\"");

WriteLiteral(" name=\"email\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2688), Tuple.Create("\"", 2702)
            
            #line 68 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
, Tuple.Create(Tuple.Create("", 2696), Tuple.Create<System.Object, System.Int32>(email
            
            #line default
            #line hidden
, 2696), false)
);

WriteAttribute("disabled", Tuple.Create(" disabled=\"", 2703), Tuple.Create("\"", 2727)
            
            #line 68 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
        , Tuple.Create(Tuple.Create("", 2714), Tuple.Create<System.Object, System.Int32>(passwordSent
            
            #line default
            #line hidden
, 2714), false)
);

WriteLiteral(" ");

            
            #line 68 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
                                                                                                  Write(Validation.For("email"));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n");

WriteLiteral("                    ");

            
            #line 69 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
               Write(Html.ValidationMessage("email"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </li>\r\n            </ol>\r\n            <p");

WriteLiteral(" class=\"form-actions\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Send instructions\"");

WriteAttribute("disabled", Tuple.Create(" disabled=\"", 2954), Tuple.Create("\"", 2978)
            
            #line 73 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
, Tuple.Create(Tuple.Create("", 2965), Tuple.Create<System.Object, System.Int32>(passwordSent
            
            #line default
            #line hidden
, 2965), false)
);

WriteLiteral(" />\r\n            </p>\r\n        </fieldset>\r\n    </form>\r\n");

            
            #line 77 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
} else {

            
            #line default
            #line hidden
WriteLiteral("   <p");

WriteLiteral(" class=\"message-info\"");

WriteLiteral(">\r\n       Password recovery is disabled for this website because the SMTP server " +
"is \r\n       not configured correctly. Please contact the owner of this site to r" +
"eset \r\n       your password.\r\n   </p>\r\n");

            
            #line 83 "G:\Company\MensClothe\Account\ForgotPassword.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
