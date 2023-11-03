using System.Data.SqlClient;

namespace SqlWebApp.Model
{
    public class ProductService
    {
        private static string db_source = "appservertestsrivani.database.windows.net";
        private static string db_user = "welcomeuser";
        private static string db_password = "welcome@1234";
        private static string db_database = "appdb";

        private SqlConnection  GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();            
            _builder.DataSource = db_source;    
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> products = new List<Product>();

            string statement = "SELECT ProductID, ProductName, Quantity from Products";

            conn.Open();

            SqlCommand sqlCommand= new SqlCommand(statement, conn);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    ProductID = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Quanity = reader.GetInt32(2)
                });
            }
            return products;
        }
    }
}
