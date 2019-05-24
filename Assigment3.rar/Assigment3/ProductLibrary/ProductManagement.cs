using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ProductLibrary
{
    public class ProductManagement
    {
        SqlConnection SqlCon =new SqlConnection(@"Data Source=TRIPHMSE62951\SQLEXPRESS;initial Catalog=saleDB;Integrated Security = True;");
        public bool AddNew(Product p)
        {
            try
            {
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@ProductId", p.ProductId);
                param.Add("@ProductName", p.ProductName);
                param.Add("@UnitPrice", p.UnitPrice);
                param.Add("@Quantity", p.Quantity);
                int result = SqlCon.Execute("AddOrUpdate", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
            return false;
        }


        public Boolean checkRole(String username, String password)
        {
            User user = new User();
            bool isAdmin = false;
            try
            {
               //User user = new User();
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@Username", username);
                param.Add("@Password", password);
                user = SqlCon.Query<User>("Login", param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                Console.WriteLine(user.IsAdmin);
                Console.WriteLine(user.Username);
                Console.WriteLine(user.Password);
                Console.WriteLine(user.Fullname);
                if(user.Username!=null)
                {
                    if(user.IsAdmin==true)
                    {
                        isAdmin = true;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
            return isAdmin;
        }


        public Boolean checkLogin(String username, String password)
        {
            try
            {
                List<User> list = new List<User>();
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@Username", username);
                param.Add("@Password", password);
                list = SqlCon.Query<User>("Login", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                Console.WriteLine(list[0].Username);
                if (list.Count != 0)
                {
                    return true;
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
            return false;
        }
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            try
            {
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@txtSearch", "");
                list = SqlCon.Query<Product>("ViewAllOrSearch", param, commandType: System.Data.CommandType.StoredProcedure).ToList<Product>();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
            return list;

        }
        public Boolean RemoveProduct(int id)
        {
            try
            {
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@ProductId", id);
                int result = SqlCon.Execute("DeleteById", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
            return false;
        }

        public List<Product> FindProduct(int id)
        {
            List<Product> list = new List<Product>();
            try
            {
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                list = SqlCon.Query<Product>("SearchById", param, commandType: System.Data.CommandType.StoredProcedure).ToList<Product>();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
            return list;

        }
    }
}
