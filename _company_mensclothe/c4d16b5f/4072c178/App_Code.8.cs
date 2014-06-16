#pragma checksum "G:\Company\MensClothe\App_Code\DbConnection.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "546E8B2B03902B641A8CEEC14535D184C4C28921"

#line 1 "G:\Company\MensClothe\App_Code\DbConnection.cs"
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for DbConnection
/// </summary>
public class DbConnection
{
    public string ConnectionString   {  get; set; }
    public string providerName { get; set; }
    public Database db { get; set; }
	public DbConnection(string cnstr )
	{
        try
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[cnstr].ConnectionString;
            providerName = ConfigurationManager.ConnectionStrings[cnstr].ProviderName;
            db = Database.OpenConnectionString(ConnectionString, providerName);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
	}


    // Get provider name by passing connection string 
    string GetProviderByConnectionString(string Constr)
    {
        string   returnValue = null;

        // Get the collection of connection strings.
        ConnectionStringSettingsCollection settings =  ConfigurationManager.ConnectionStrings;
        if (settings != null)
        {
            foreach (ConnectionStringSettings cs in settings)
            {
                if (cs.Name == Constr)
                    returnValue = cs.ProviderName;
                    break;
            }
        }
        return returnValue;
    }

     







}

#line default
#line hidden
