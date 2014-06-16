using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.Data;

namespace DAL
{
   public class Customer
    {
        //  public byte[] img { get; set; }
        public string CustomerID { get; set; }
        public string customername { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
    static Database dbase;

    public Customer()
	{
        Dbase = new DbConnection("ConnectionStr").db;	
     		// TODO: Add constructor logic here

	}

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
    public static int insert( Customer cusDetails)//string cusName,string address, string city, string region, string postalcode, string country,string phone, string fax , string Email)
    {
        try
        {
            //VALUES(1, N'Product HHYDP', 1, 1, 18.00, 0)
            //  this.ConnectionString = "ConnectionStr";
            int result = Dbase.Execute("INSERT INTO Customers(customername, address, city, region, postalcode, country, phone, fax, Email) VALUES(@0,@1,@2,@3,@4,@5, @6,@7,@8 )", cusDetails.customername, cusDetails.Address, cusDetails.City,
                cusDetails.State, cusDetails.Zipcode, cusDetails.Country, cusDetails.phone, string.Empty, cusDetails.Email);
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



    public static int UpdateCustomer(Customer cus)//string cusName, string address, string city, string region, string postalcode, string country, string phone, string fax, string Email, string cusid)
    {
        try
        {
            
        int result = Dbase.Execute("UPDATE  Customer SET  customername=@0 ,address=@1, "
        +" city=@2 ,    region=@3, postalcode=@4 , country=@5,phone=@6,  fax=@7 , Email=@8  WHERE custid = @9"
        , cus.customername, cus.Address,cus.City, cus.State, cus.Zipcode,cus.Country,cus.phone, string.Empty,cus.Email ,cus.CustomerID);
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


    public static Customer getCustomerDetail(int id)
    {
      //  Database db;
        try
        {
            dynamic CustomerRecord = Dbase.QuerySingle("SELECT * FROM  Customers Where custid=@0 ", id);
            Customer cusDetail = new  Customer{ customername = CustomerRecord["customername"],   Address = CustomerRecord["address"]
            ,City = CustomerRecord["city"],   Country = CustomerRecord["country"], Email = CustomerRecord["Email"], phone = CustomerRecord["phone"],  Zipcode=CustomerRecord["postalcode"], 
            State=CustomerRecord["region"], CustomerID=Convert.ToString( CustomerRecord["custid"]) };
            return cusDetail;
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


    public static  List<Customer> getAllCustomers()
    {

       try
        {
            ///this.ConnectionString = "ConnectionStr";
            List<Customer> items = new List<Customer>();
            var ProductRecord = Dbase.Query("SELECT * FROM  Customers ");
            foreach (var item in ProductRecord)
            {
                //items.Add(new Products { name = item.name, Price = Convert.ToString(item.Price), size = Convert.ToString(item.size), Description = item.Description, img = (Convert.ToString(item.img)), quantity = Convert.ToString(item.quantity), ItemID = item.ItemID });
                items.Add(new Customer {  customername = item["customername"],   Address = item["address"]
                ,   City = item["city"],   Country = item["country"], Email = item["Email"],
                 phone = item["phone"],  Zipcode=item["postalcode"],  State=item["region"], CustomerID=Convert.ToString( item["custid"]) });
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

    public static int DeleteCustomer(int id )
    {
        //int i = Dbase.Execute("DELETE FROM  Customers WHERE custid = @0 ", id);
        //return i;

        int result = Dbase.Execute("delete  Customers    WHERE custid = @0", id);
        return result;



    }



    }
}
