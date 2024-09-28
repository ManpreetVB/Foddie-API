using System.Data.SqlClient;
using System.Data;

namespace FoddieDB.Models
{
    public class DAL
    {
        public Response Login(Login users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_Login", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", users.Password);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                user.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                response.StatusCode = 200;
                response.StatusMessage = "User is valid";
                response.user = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Invalid user";
                response.user = null;
            }
            return response;

        }
        public Response Registration(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_Registration", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@UserName", users.UserName);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Address", users.Address);
            cmd.Parameters.AddWithValue("@PostCode", users.PostCode);
            cmd.Parameters.AddWithValue("@PhoneNumber", users.PhoneNumber);
           
            cmd.Parameters.AddWithValue("@Type", users.Type);
            
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.Type = users.Type;
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.Type = null;
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }


        public Response UserProfile(string email, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_UserProfile", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);

            da.SelectCommand.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                user.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                user.Address = Convert.ToString(dt.Rows[0]["Address"]);
                user.PostCode = Convert.ToInt32(dt.Rows[0]["PostCode"]);
                user.PhoneNumber = Convert.ToInt32(dt.Rows[0]["PhoneNumber"]);
                user.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                user.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);

                response.StatusCode = 200;
                response.StatusMessage =  Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                response.user = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage =  Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                response.user = null;
            }
            return response;

        }

        public Response UpdateUserProfile(Users users, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateUserProfile", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", users.UserId);
            cmd.Parameters.AddWithValue("@UserName", users.UserName);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Address", users.Address);
            cmd.Parameters.AddWithValue("@PostCode", users.PostCode);
            cmd.Parameters.AddWithValue("@PhoneNumber", users.PhoneNumber);
 
            cmd.Parameters.AddWithValue("@Type", users.Type);
            cmd.Parameters.AddWithValue("@IsActive", users.IsActive);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            Response response = new Response();
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }


        public Response UserList(SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_UserList", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            Response response = new Response();
            List<Users> listUsers = new List<Users>();

            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users user = new Users();
                    user.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
                    user.UserName = Convert.ToString(dt.Rows[i]["UserName"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    user.PostCode = Convert.ToInt32(dt.Rows[i]["PostCode"]);
                    user.PhoneNumber = Convert.ToInt32(dt.Rows[i]["PhoneNumber"]);
                    user.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    user.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    user.Type = Convert.ToString(dt.Rows[i]["Type"]);

                    listUsers.Add(user);
                }
            }
                if (listUsers.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                    response.listUsers = listUsers;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                    response.listUsers = null;
                }

                return response;
        }


        public Response AddUpdateProduct(Products products, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddUpdateProduct", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Products> listProducts = new List<Products>();
            cmd.Parameters.AddWithValue("@ProductId", products.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", products.ProductName);
            cmd.Parameters.AddWithValue("@Description", products.Description);
            cmd.Parameters.AddWithValue("@Price", products.Price);
            cmd.Parameters.AddWithValue("@Quantity", products.Quantity);
            cmd.Parameters.AddWithValue("@ImageUrl", products.ImageUrl);
            cmd.Parameters.AddWithValue("@CategoryId", products.CategoryId);
           cmd.Parameters.AddWithValue("@IsActive", products.IsActive);
            cmd.Parameters.AddWithValue("@ActionType", products.ActionType);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            if (products.ActionType != "Get" && products.ActionType != "GetByID")
            {
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {

                    response.StatusCode = 200;
                    if (products.ActionType == "Add")
                        response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

                    if (products.ActionType == "Update")
                        response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

                    if (products.ActionType == "Delete")
                        response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

                }
                else
                {
                    response.StatusCode = 100;
                    if (products.ActionType == "Add")
                        response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
              
                    if (products.ActionType == "Update")
                        response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

                    if (products.ActionType == "Delete")
                        response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

                }
            }
            else
            {
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Products product = new Products();
                        product.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                        product.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                        product.Description = Convert.ToString(dt.Rows[i]["Description"]);
                        product.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                        product.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                        product.ImageUrl = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                        product.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                         product.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                        listProducts.Add(product);
                    }
                    if (listProducts.Count > 0)
                    {
                        response.StatusCode = 200;
                        response.listProducts = listProducts;
                    }
                    else
                    {
                        response.StatusCode = 100;
                        response.listProducts = null;
                    }
                }
            }
            return response;

        }



        public Response PaymentProcess(Payment payment, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_Payment", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PaymentId", payment.PaymentId);
            cmd.Parameters.AddWithValue("@CardName", payment.CardName);
            cmd.Parameters.AddWithValue("@CvvNumber", payment.CvvNumber);
            cmd.Parameters.AddWithValue("@PaymentMode", payment.PaymentMode);
            cmd.Parameters.AddWithValue("@ExpiryDate", payment.ExpiryDate);
            cmd.Parameters.AddWithValue("@CardNumber", payment.CardNumber);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.Type = null;
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }



        public Response AddToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddToCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@CartId", cart.CartId);
           
            cmd.Parameters.AddWithValue("@Price", cart.Price);
            cmd.Parameters.AddWithValue("@Email", cart.Email);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
            cmd.Parameters.AddWithValue("@ProductId", cart.ProductId);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;

        }



        public Response RemoveToCart(int cartId,string email, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_RemoveToCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@CartId", cartId);

            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }



        public Response CartList( string email, SqlConnection connection)
        {
            Response response = new Response();
            List<Cart> listCart = new List<Cart>();
            SqlDataAdapter da = new SqlDataAdapter("sp_CartList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email",email);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cart carts= new Cart();
                    carts.CartId= Convert.ToInt32(dt.Rows[i]["CartId"]);
                    carts.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    carts.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    carts.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                   
                    listCart.Add(carts);

                }
                if (listCart.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Cart details fetched";
                    response.listCart = listCart;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Cart details are not available";
                    response.listCart = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Cart details are not available";
                response.listCart = null;
            }
            return response;
        }


        public Response PlaceOrder(OrderRequest orderRequest, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceOrder ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", orderRequest.Email);
           
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order has been placed successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order could not be placed";
            }
            return response;

        }



        public Response OrderList(int userId, string email, string type,int orderId, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_OrderList", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@UserId", userId);
            da.SelectCommand.Parameters.AddWithValue("@Type",type);
            da.SelectCommand.Parameters.AddWithValue("@Email", email);




            da.SelectCommand.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Orders> listOrder = new List<Orders>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Orders orders = new Orders();
                    orders.OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"]);
                    orders.OrderNumber = Convert.ToString(dt.Rows[i]["OrderNumber"]);
                    orders.OrderTotal = dt.Rows[i]["OrderTotal"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["OrderTotal"]) : 0;

                    orders.Status = Convert.ToString(dt.Rows[i]["Status"]);
                    orders.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);

                    if (type == "UserItem")
                    {
                        orders.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                        orders.Description = Convert.ToString(dt.Rows[i]["Description"]);
                        orders.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                        orders.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                        orders.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                        orders.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                        orders.ImageUrl = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                    }
                    listOrder.Add(orders);
                }
                if (listOrder.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                    response.listOrders = listOrder;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value); ;
                    response.listOrders = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                response.listOrders = null;
            }
            return response;

        }


        public Response UpdateOrderStatus(Orders order, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_UpdateOrderStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
            cmd.Parameters.AddWithValue("@Status", order.Status);

            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }


        public Response DeleteUser(int userId, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteUser", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            Response response = new Response();
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }



        public Response AddCategory(Categories category, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_AddCategory", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", category.Name);
            cmd.Parameters.AddWithValue("@ImageUrl", category.ImageUrl);
            cmd.Parameters.AddWithValue("@IsActive", category.IsActive);

            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

            Response response = new Response();
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }



        public Response ProductList(SqlConnection connection)
        {
            List<Products> listproducts = new List<Products>();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products;", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Products product = new Products();
                    product.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                    product.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    product.Description = Convert.ToString(dt.Rows[i]["Description"]);
                    product.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    product.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    product.ImageUrl = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                    product.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                    listproducts.Add(product);
                }
                if (listproducts.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.listProducts = listproducts;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = " No Data Found";
                    response.listProducts = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " No Data Found";
                response.listProducts = null;
            }
            return response;
        }

        


    }
}
