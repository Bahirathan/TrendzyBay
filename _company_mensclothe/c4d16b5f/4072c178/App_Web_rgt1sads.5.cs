﻿#pragma checksum "G:\Company\MensClothe\_AppStart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5F095E128C62BEA657AF6AECC8BDCEBBE625D122"
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
    
    
    public class _Page__AppStart_cshtml : System.Web.WebPages.ApplicationStartPage {
        
#line hidden
        
        public _Page__AppStart_cshtml() {
        }
        
        protected ASP.global_asax ApplicationInstance {
            get {
                return ((ASP.global_asax)(Context.ApplicationInstance));
            }
        }
        
        public override void Execute() {
            
            #line 1 "G:\Company\MensClothe\_AppStart.cshtml"
  
    WebSecurity.InitializeDatabaseConnection("StarterSite", "UserProfile", "UserId", "Email", autoCreateTables: true);

    // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, Twitter,
    // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=226949

    //OAuthWebSecurity.RegisterMicrosoftClient(
    //    clientId: "",
    //    clientSecret: "");

    //OAuthWebSecurity.RegisterTwitterClient(
    //    consumerKey: "",
    //    consumerSecret: "");

    //OAuthWebSecurity.RegisterFacebookClient(
    //    appId: "",
    //    appSecret: "");

    //OAuthWebSecurity.RegisterGoogleClient();

    //WebMail.SmtpServer = "mailserver.example.com";
    //WebMail.EnableSsl = true;
    //WebMail.UserName = "username@example.com";
    //WebMail.Password = "your-password";
    //WebMail.From = "your-name-here@example.com";

    // To learn how to optimize scripts and stylesheets in your site go to http://go.microsoft.com/fwlink/?LinkID=248973

            
            #line default
            #line hidden
        }
    }
}
