using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.Data;

namespace DAL
{
    public class Orders
    {
        public int orderid { get; set; }
        public int cusid { get; set; }
        public DateTime orderdate { get; set; } // Primary key
        public DateTime requireddate { get; set; } // Primary key
        public decimal deliveryCharge { get; set; } // Foreign key
        public decimal exchangeRate { get; set; } // Primary key
        public string exchangeCurrency { get; set; } // Foreign key
        public decimal Total { get; set; } // Primary key


        static Database dbase;

        public Orders()
        {
            Dbase = new DbConnection("ConnectionStr").db;
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
        public int insert(int cusid, DateTime orderdate, DateTime requiredate, double deliverycharge)
        {
            try
            {
                int result = Dbase.Execute("INSERT INTO Orders(cusid, orderdate, requireddate, DeliverCharge) VALUES(@0,@1,@2,@3 )", cusid, orderdate, requiredate, deliverycharge);
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



        public static int UpdateOrder(int cusid, DateTime orderdate, DateTime requiredate, double deliverycharge, int id)
        {
            Database Db = null;
            try
            {

                int result = Db.Execute("UPDATE  Orders SET  cusid=@0 ,orderdate=@1,  requireddate=@2 ,    DeliverCharge=@3,  WHERE orderid = @4", cusid, orderdate, requiredate, deliverycharge, id);
                return result;
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                Db.Close();
            }

        }

        public static List<OderDetails> OderedItems(int id)
        {
        string query = string.Format(@"SELECT
        P.productname AS pName,
        od.productid AS prdid,
        od.unitprice AS val,
        od.discount AS disc,
        od.unitprice AS val,
        od.exchangeprice AS exPri,  
        od.qty AS qty
        FROM orderDetails AS od
        JOIN Products AS p
        ON od.productid = p.productid 
        where OD.orderid={0} ", id);

            try
            {
                List<OderDetails> items = new List<OderDetails>();
                var orderDetails = Dbase.Query(query).ToList();
                foreach (var item in orderDetails)
                {
                    items.Add(new OderDetails
                    {

                        ProductID = item["prdid"],
                        PrdName = item["pName"],
                        price = item["val"],
                        ExchangePrice = item["exPri"],
                        quantity = item["qty"],
                        discount = item["disc"],

                    });
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
        public static IEnumerable<dynamic> getOrderDetails(int id)
        {
            string query = string.Format(@"SELECT
        C.Email AS email,
        P.productname AS productName,
        P.ImageUrl AS image,
        SUM(OD.qty) AS qty,
        CAST(SUM(OD.qty * OD.unitprice * (1 - OD.discount))
        AS NUMERIC(12, 2)) AS val
        FROM Products AS P
        JOIN OrderDetails AS OD
        ON OD.productid = p.productid 
        JOIN Orders AS O
        ON OD.orderid = O.orderid
        JOIN Customers AS C
        ON C.custid = O.custid and OD.orderid={0}
        GROUP BY  P.productname, P.ImageUrl, C.Email ", id);

            try
            {
                var ProductRecord = Dbase.Query(query).ToList();
                return ProductRecord;
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


        public static List<Orders> getOrderCollections()
        {

            try
            {
                List<Orders> items = new List<Orders>();
                var OrderRecord = Dbase.Query("SELECT * FROM  Orders ");
                foreach (var item in OrderRecord)
                {
                    items.Add(new Orders
                    {
                        cusid = item["custid"],
                        orderdate = item["orderdate"],
                        requireddate = item["requireddate"],
                        deliveryCharge = item["DeliverCharge"],
                        orderid = item["orderid"],
                        exchangeCurrency = item["exchangeCurrency"],
                        exchangeRate = item["exchangeRate"],
                        Total = item["Total"]
                         
                    });
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

    }

    public class OderDetails : Orders
    {
        public int ProductID { get; set; }
        public string PrdName { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal discount { get; set; }
        public decimal ExchangePrice { get; set; }
    }

}