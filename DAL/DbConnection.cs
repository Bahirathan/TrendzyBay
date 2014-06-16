using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WebMatrix.Data;


namespace DAL
{
    public class DbConnection
    {
        public string conStr = "ConnectionStr";
        public string providerName { get; set; }
        public Database db { get; set; }
        

        public DbConnection(string cnstr)
        {
            try
            {

                string ConnectionString = ConfigurationManager.ConnectionStrings[cnstr].ConnectionString;
                providerName = ConfigurationManager.ConnectionStrings[cnstr].ProviderName;
                db = Database.OpenConnectionString(ConnectionString, providerName);
            }
            catch (SqlException ex)
            {
                throw ;
            }
        }


        public DbConnection()
        {


        }



        public string ConnectionString
        {
            get { return conStr; }
            set { conStr = value; }
        }

        // Get provider name by passing connection string 
        string GetProviderByConnectionString(string Constr)
        {
            string returnValue = null;

            // Get the collection of connection strings.
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
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


        public int updateCustomerOrder(Customer cus, DateTime deliDate, decimal delivCharge, string  total, double exrate, string cur)
        {

            int orderID = -1;
            SqlConnection SQLconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand("updateCustomerOrder", SQLconn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter outPutVal = new SqlParameter("@OrderId", SqlDbType.Int);
                outPutVal.Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@customername", SqlDbType.VarChar).Value = cus.customername;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = cus.Address;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = cus.City;
                cmd.Parameters.Add("@region", SqlDbType.VarChar).Value = cus.State;
                cmd.Parameters.Add("@postalcode", SqlDbType.VarChar).Value = cus.Zipcode;
                cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = cus.Country;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = cus.phone;
                cmd.Parameters.Add("@fax", SqlDbType.VarChar).Value = string.Empty;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = cus.Email;
                cmd.Parameters.Add("@requireddate", SqlDbType.DateTime).Value = deliDate;
                cmd.Parameters.Add("@DeliverCharge", SqlDbType.Decimal).Value = delivCharge;
                cmd.Parameters.Add("@OrderTotal", SqlDbType.Decimal).Value =Convert.ToDecimal( total);
                cmd.Parameters.Add("@exRate", SqlDbType.Decimal).Value = exrate;
                cmd.Parameters.Add("@currency", SqlDbType.VarChar).Value = cur;
                
                cmd.Parameters.Add(outPutVal);
                SQLconn.Open();
                cmd.ExecuteNonQuery();
               // SQLconn.Close();
                
                if (outPutVal.Value != DBNull.Value) orderID = Convert.ToInt32(outPutVal.Value);
                return orderID;


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLconn.Close();
            }

          ///  return orderID;
        }

        public int updateOrderDetails(int ordID, int prdID, decimal price, int qty, decimal dicount, decimal excTotal)
        {
            int i = 0;
            SqlConnection SQLconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand("InsertOrderDetail", SQLconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrdId", SqlDbType.Int).Value = ordID;
                cmd.Parameters.Add("@productid", SqlDbType.Int).Value = prdID;
                cmd.Parameters.Add("@unitprice", SqlDbType.Decimal).Value = price;
                cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = qty;
                cmd.Parameters.Add("@discount", SqlDbType.Decimal).Value = dicount;
                cmd.Parameters.Add("@exchangeprice", SqlDbType.Decimal).Value = excTotal;
                SQLconn.Open();
                i = cmd.ExecuteNonQuery();
              //  SQLconn.Close();
                return i;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SQLconn.Close();
            }
            return i;
        }


        public static int DeleteOrder(string id)
        {
            
                int i = 0;
                SqlConnection SQLconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteOrder", SQLconn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OrdId", SqlDbType.Int).Value = id;

                    SQLconn.Open();
                    i = cmd.ExecuteNonQuery();
                    //  SQLconn.Close();
                    return i;


                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    SQLconn.Close();
                }
            }

      



    }
}
