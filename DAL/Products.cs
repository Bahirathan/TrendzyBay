using DAL;
using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;
using System.Globalization;

/// <summary>
/// Summary description for Orders
/// </summary>
public class Products
{
    //  public byte[] img { get; set; }
    
    public string img { get; set; }
    
    public string categoryID { get; set; } // Primary key
    public string supplierID { get; set; } // Primary
    public string quantity { get; set; } // Foreign key
    public string Description { get; set; }
    public string name { get; set; }
    public bool isAvailable { get; set; }
    public string price { get; set; }
    public int profitmargin { get; set; }
    public long ItemID { get; set; }
    static Database dbase;

    public Products()
    {
      //  Dbase = new DbConnection("ConnectionStr").db;
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
    public static int insert(string ProductName, string price, string imageUrl, string quantity, string SuppId, string categoryid, string disCont,int profit , string Size, string Color)
    {
        try
        {
            //VALUES(1, N'Product HHYDP', 1, 1, 18.00, 0)
            //  this.ConnectionString = "ConnectionStr";
            int result = Dbase.Execute("INSERT INTO Products(productname, unitprice,ImageUrl,quantity, supplierid, categoryid,  discontinued,profitmargin , Size , Color ) VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9)",
            ProductName, price, imageUrl, quantity, SuppId, categoryid, disCont, profit , Size , Color );
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



    public static int UpdateProduct(string ProductName, string Price, string imageUrl, string quantity, string catID, string suppId, string discont, int id, int profitmargin)
    {

        try
        {

            int result = Dbase.Execute("UPDATE  Products SET productname=@0 ,  unitprice=@1 ,ImageUrl=@2,  quantity=@3 ,categoryid=@4,    supplierid=@5, discontinued=@6, profitmargin=@8   WHERE productid = @7", ProductName, Price, imageUrl, quantity, catID, suppId, discont, id, profitmargin);
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

    public static Products getSellingDetail(int id)
    {

        string query = string.Format(@"SELECT C.description,P.productid, P.productname, P.categoryid, P.discontinued,   P.unitprice,P.quantity,P.profitmargin,P.ImageUrl,P.supplierid FROM Categories AS C INNER JOIN Products AS P ON C.categoryid = P.categoryid and P.productid={0}", id);
        //  Database db;
        try
        {
            var ProductRecord = Dbase.QuerySingle(query);  //"SELECT * FROM  Products ");
            var sellingPrice = ((double)((ProductRecord["profitmargin"] * (ProductRecord["unitprice"]) / 100) + ProductRecord["unitprice"])).ToString("0.00", CultureInfo.InvariantCulture);


            Products product = new Products { categoryID = Convert.ToString(ProductRecord["categoryid"]), supplierID = Convert.ToString(ProductRecord["supplierid"]), name = ProductRecord["productname"], price = sellingPrice, Description = ProductRecord["description"], img = (Convert.ToString(ProductRecord["ImageUrl"])), profitmargin = ProductRecord["profitmargin"], quantity = Convert.ToString(ProductRecord["quantity"]), isAvailable = ProductRecord["discontinued"] };
            return product;
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



    public static Products getProductDetail(int id)
    {

        string query = string.Format(@"SELECT C.description,P.productid, P.productname, P.categoryid, P.discontinued,   P.unitprice,P.quantity,P.profitmargin,P.ImageUrl,P.supplierid FROM Categories AS C INNER JOIN Products AS P ON C.categoryid = P.categoryid and P.productid={0}", id);
        //  Database db;
       try
       {  
      var ProductRecord = Dbase.QuerySingle(query);  //"SELECT * FROM  Products ");
      Products product = new Products { categoryID = Convert.ToString(ProductRecord["categoryid"]), supplierID = Convert.ToString(ProductRecord["supplierid"]), name = ProductRecord["productname"], price =  Convert.ToString( ProductRecord["unitprice"]), Description = ProductRecord["description"], img = (Convert.ToString(ProductRecord["ImageUrl"])), profitmargin = ProductRecord["profitmargin"], quantity = Convert.ToString(ProductRecord["quantity"]), isAvailable = ProductRecord["discontinued"] };
        return product;
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


    public static List<Products> getProductRecodCollections()
    {

        try
        {

            string query = string.Format(@"SELECT C.description,P.productid, P.productname,  P.profitmargin,  P.unitprice, P.quantity,P.ImageUrl,P.supplierid FROM Categories AS C INNER JOIN Products AS P ON C.categoryid = P.categoryid  where P.discontinued='0' ");


            ///this.ConnectionString = "ConnectionStr";
            List<Products> items = new List<Products>();
            var ProductRecord = Dbase.Query(query);  //"SELECT * FROM  Products ");
            foreach (var item in ProductRecord)
            {
              //  double profi =(double) item["profitmargin"]/100;

                var sellingPrice = ((double)( (item["profitmargin"] * (item["unitprice"]) / 100) +item["unitprice"]))  .ToString("0.00", CultureInfo.InvariantCulture);

               
                //items.Add(new Products { name = item.name, Price = Convert.ToString(item.Price), size = Convert.ToString(item.size), Description = item.Description, img = (Convert.ToString(item.img)), quantity = Convert.ToString(item.quantity), ItemID = item.ItemID });
                items.Add(new Products { name = item["productname"], price = sellingPrice, Description = item["description"], img = (Convert.ToString(item["ImageUrl"])), quantity = Convert.ToString(item["quantity"]), ItemID = item["productid"] });
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


    public static List<Products> getProductModifyCollections()
    {

        try
        {

            string query = string.Format(@"SELECT C.description,P.productid, P.productname,  P.profitmargin,  P.unitprice, P.quantity,P.ImageUrl,P.supplierid FROM Categories AS C INNER JOIN Products AS P ON C.categoryid = P.categoryid   ");


            ///this.ConnectionString = "ConnectionStr";
            List<Products> items = new List<Products>();
            var ProductRecord = Dbase.Query(query);  //"SELECT * FROM  Products ");
            foreach (var item in ProductRecord)
            {
                //  double profi =(double) item["profitmargin"]/100;

                var sellingPrice = ((double)((item["profitmargin"] * (item["unitprice"]) / 100) + item["unitprice"])).ToString("0.00", CultureInfo.InvariantCulture);


                //items.Add(new Products { name = item.name, Price = Convert.ToString(item.Price), size = Convert.ToString(item.size), Description = item.Description, img = (Convert.ToString(item.img)), quantity = Convert.ToString(item.quantity), ItemID = item.ItemID });
                items.Add(new Products { name = item["productname"], price = sellingPrice, Description = item["description"], img = (Convert.ToString(item["ImageUrl"])), quantity = Convert.ToString(item["quantity"]), ItemID = item["productid"] });
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



    public static List<Products> getCategoryWiseProducts(int catID)
    {

        try
        {

            string query = string.Format(@"SELECT C.description,P.productid, P.productname,    P.unitprice,P.quantity,P.ImageUrl,P.supplierid FROM Categories AS C INNER JOIN Products AS P ON C.categoryid = P.categoryid and C.categoryid ={0}  and P.discontinued='0' ", catID);

          


            ///this.ConnectionString = "ConnectionStr";
            List<Products> items = new List<Products>();
            var ProductRecord = Dbase.Query(query);  //"SELECT * FROM  Products ");
            foreach (var item in ProductRecord)
            {
                //items.Add(new Products { name = item.name, Price = Convert.ToString(item.Price), size = Convert.ToString(item.size), Description = item.Description, img = (Convert.ToString(item.img)), quantity = Convert.ToString(item.quantity), ItemID = item.ItemID });
                items.Add(new Products { name = item["productname"], price = Convert.ToString(item["unitprice"]), Description = item["description"], img = (Convert.ToString(item["ImageUrl"])), quantity = Convert.ToString(item["quantity"]), ItemID = item["productid"] });
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


    public static int DeleteProduct(string id)
    {
        try
        {
            int i = Dbase.Execute("DELETE FROM  Products WHERE productid = @0 ", id);
            return i;

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






}
