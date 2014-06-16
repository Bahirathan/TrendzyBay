using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.Data;

namespace DAL
{
    public class Category
    {
        public int categoryid;
        public string categoryname;
        public string description;
        private static Database dbase;

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
        public static int insertCategory(string CatName, string description, int CategoryID)
        {
            try
            {
                int result = Dbase.Execute("INSERT INTO Categories(categoryname,description, categoryid) VALUES(@0,@1,@2 )", CatName, description, CategoryID);
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



        public static int UpdateCategory(string CatName, string description, int newCatID, int id)
        {
            try
            {
                int result = Dbase.Execute("UPDATE  Categories SET    categoryname=@0 ,description=@1 , categoryid=@2 WHERE categoryid = @3", CatName, description, newCatID, id);
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


        public static dynamic getCategoryDetail(int id)
        {
            try
            {
                var Record = Dbase.QuerySingle("SELECT * FROM  Categories Where categoryid=@0 ", id);
                return Record;
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


        public static List<Category> getCategoryRecodCollections()
        {
            try
            {
                List<Category> items = new List<Category>();
                var CategoryRecord = Dbase.Query("SELECT * FROM  Categories ");
                foreach (var item in CategoryRecord)
                {
                    items.Add(new Category { categoryid = item["categoryid"], categoryname = item["categoryname"], description = item["description"] });
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

        public static int DeleteCategory(string id)
        {
            int i = Dbase.Execute("DELETE FROM  Categories WHERE categoryid = @0 ", id);
            return i;
        }
    }
}
