﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Profile;



public class ProfileCommon : System.Web.Profile.ProfileBase {
    
    public virtual MensClothe.Cart SCart {
        get {
            return ((MensClothe.Cart)(this.GetPropertyValue("SCart")));
        }
        set {
            this.SetPropertyValue("SCart", value);
        }
    }
    
    public virtual ProfileCommon GetProfile(string username) {
        return ((ProfileCommon)(ProfileBase.Create(username)));
    }
}
