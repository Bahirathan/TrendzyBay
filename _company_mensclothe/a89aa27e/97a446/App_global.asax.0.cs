﻿#pragma checksum "I:\Company\MensClothe\global.asax" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C1736F44B910D9E04142D87739B9A3F6C0593D20"
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
    
    #line 391 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Configuration;
    
    #line default
    #line hidden
    
    #line 394 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Text.RegularExpressions;
    
    #line default
    #line hidden
    
    #line 395 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web;
    
    #line default
    #line hidden
    
    #line 399 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.Security;
    
    #line default
    #line hidden
    
    #line 403 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.UI.WebControls.WebParts;
    
    #line default
    #line hidden
    
    #line 388 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 397 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.DynamicData;
    
    #line default
    #line hidden
    
    #line 389 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Collections.Specialized;
    
    #line default
    #line hidden
    
    #line 405 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Xml.Linq;
    
    #line default
    #line hidden
    
    #line 387 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 392 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 401 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.UI;
    
    #line default
    #line hidden
    
    #line 400 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.Profile;
    
    #line default
    #line hidden
    
    #line 393 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 404 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.UI.HtmlControls;
    
    #line default
    #line hidden
    
    #line 396 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.Caching;
    
    #line default
    #line hidden
    
    #line 386 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System;
    
    #line default
    #line hidden
    
    #line 402 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.UI.WebControls;
    
    #line default
    #line hidden
    
    #line 398 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.SessionState;
    
    #line default
    #line hidden
    
    #line 390 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    
    [System.Runtime.CompilerServices.CompilerGlobalScopeAttribute()]
    public class global_asax : global::System.Web.HttpApplication {
        
        private static bool @__initialized;
        
        
        #line 3 "I:\Company\MensClothe\global.asax"
                       

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {

        ProfileCommon profile = HttpContext.Current.Profile as ProfileCommon;
        //  profile.SCart = new MensClothe.Cart();

        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs e)
    {
        ProfileCommon anonymousProfile = Profile.GetProfile(e.AnonymousID);
        if (anonymousProfile.SCart != null)
        {
            if (Profile.SCart == null)
                Profile.SCart = new MensClothe.Cart();

            Profile.SCart.Items.AddRange(anonymousProfile.SCart.Items);

            anonymousProfile.SCart = null;
        }

        ProfileManager.DeleteProfile(e.AnonymousID);
        AnonymousIdentificationModule.ClearAnonymousIdentifier();
    }
  
       

        #line default
        #line hidden
        
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global_asax() {
            if ((global::ASP.global_asax.@__initialized == false)) {
                global::ASP.global_asax.@__initialized = true;
            }
        }
        
        protected ProfileCommon Profile {
            get {
                return ((ProfileCommon)(this.Context.Profile));
            }
        }
    }
}
