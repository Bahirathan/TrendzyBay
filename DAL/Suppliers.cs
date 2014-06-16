using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.Data;

namespace DAL
{
 public    class Suppliers
    {
   public int supplierid { get; set; }
   public string companyname { get; set; }
   public string contactname { get; set; }
   public string address { get; set; } // Primary key
   public string city { get; set; } // Foreign key
   public string region { get; set; }
   public string postalcode { get; set; }
   public string Email { get; set; }
   public string country { get; set; }
   public string phone { get; set; }
   public string fax { get; set; }
   static Database dbase;

    //public Suppliers()
    //{
    //    Dbase = new DbConnection("ConnectionStr").db;	
    //        // TODO: Add constructor logic here

    //}

    static Database Dbase
    {
        get
        {

            return new DbConnection("ConnectionStr").db;	
        }

        set
        {
            dbase = value;
        }
    }
    public static int insert(Suppliers supp)//string companyname, string contactname, string address, string city, string region, string postalcode, string country, string phone, string fax, string Email)
    {
        try
        {
            //VALUES(1, N'Product HHYDP', 1, 1, 18.00, 0)
            //  this.ConnectionString = "ConnectionStr";
            int result = Dbase.Execute("INSERT INTO Suppliers(companyname,contactname, address, city, region, postalcode, country, phone, fax, Email) VALUES(@0,@1,@2,@3,@4,@5, @6,@7,@8,@9 )", supp.companyname, supp.contactname, supp.address, supp.city, supp.region, supp.postalcode, supp.country, supp.phone, supp.fax, supp.Email);
            return result;
        }

        catch
        {
            throw new Exception();

        }
        finally
        {

            Dbase.Close();
        }

    }



    public static int UpdateSuppliers( Suppliers supp)
    {
         try
        {

        int result = Dbase.Execute("UPDATE  Suppliers SET  companyname=@0 ,address=@1, "
        + " city=@2 ,    region=@3, postalcode=@4 , country=@5,phone=@6,  fax=@7 , Email=@8,contactname=@10  WHERE supplierid = @9"
        , supp.companyname, supp.address, supp.city, supp.region, supp.postalcode, supp.country, supp.phone, string.Empty, supp.Email, supp.supplierid, supp.contactname);
            return result;
        }
        catch
        {
            throw new Exception();
        }
        finally
        {
            Dbase.Close();
        }

    }


    public static Suppliers getSuppliersDetail(int id)
    {
      //  Database db;
        try
        {
            var SuppRecord = Dbase.QuerySingle("SELECT * FROM  Suppliers Where supplierid=@0 ", id);
            Suppliers SuppDetail = new Suppliers
            {
                companyname = SuppRecord["companyname"],
                contactname = SuppRecord["contactname"],
                address = SuppRecord["address"]  ,
                city = SuppRecord["city"],
                country = SuppRecord["country"],
                Email = SuppRecord["Email"],
                phone = SuppRecord["phone"],
                postalcode = SuppRecord["postalcode"],
                region = SuppRecord["region"],
                supplierid = SuppRecord["supplierid"]
            };
            return SuppDetail;
            
   
        }
        catch
        {
            throw new Exception();
        }
        finally
        {
            Dbase.Close();
        }
    }


    public static List<Suppliers> getAllSuppliers()
    {

       try
        {
            List<Suppliers> items = new List<Suppliers>();
            var ProductRecord = Dbase.Query("SELECT * FROM  Suppliers ");
            foreach (var item in ProductRecord)
            {
               
                items.Add(new Suppliers {   contactname = item["contactname"],  address = item["address"]
                ,  city = item["city"],  country = item["country"], Email = item["Email"],
                                            fax = Convert.ToString(item["fax"]), supplierid= item["supplierid"],
                                            companyname = item["companyname"],
                 phone = item["phone"], postalcode=item["postalcode"], region=item["region"], });
            }

            return items;

        }
        catch
        {
            throw new Exception();
        }
        finally
        {
            Dbase.Close();
        }
    }

    public static int DeleteSuppliers(string id)
    {
        int i = Dbase.Execute("DELETE FROM  Suppliers WHERE supplierid = @0 ", id);
        return i;
    }
    }
}
