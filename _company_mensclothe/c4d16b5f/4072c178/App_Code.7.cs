#pragma checksum "G:\Company\MensClothe\App_Code\Clothe.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8414247C79E8A135573FC7A808E1B679DFAEEAAB"

#line 1 "G:\Company\MensClothe\App_Code\Clothe.cs"
using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Clothe
/// </summary>
public class Clothe
{
  //  public byte[] img { get; set; }
    public string   img { get; set; }
    public string size { get; set; } // Primary key
    public string quantity { get; set; } // Foreign key
    public string Description { get; set; }
    public string name { get; set; }
    public bool isAvailable {get; set;}
    public string Price { get; set; }
    public long ItemID { get; set; }

    public Clothe()
	{
		//
		// TODO: Add constructor logic here

	}


}


#line default
#line hidden
