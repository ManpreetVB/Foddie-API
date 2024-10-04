using System.Data.SqlClient;

namespace FoddieDB.Models
{
    public class BAL
    {
        public Response Login(Login users, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.Login(users, connection);
        }

        public Response Registration(Users users, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.Registration(users, connection);
        }

        public Response UserProfile(string email, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.UserProfile(email, connection);
        }

        public Response UpdateUserProfile(Users users, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.UpdateUserProfile(users, connection);
        }

        public Response UserList(SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.UserList(connection);
        }


        public Response AddUpdateProduct(Products products, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.AddUpdateProduct(products, connection);
        }


        public Response PaymentProcess(Payment payment, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.PaymentProcess(payment, connection);
        }

        public Response AddToCart(Cart cart, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.AddToCart(cart, connection);
        }


        public Response RemoveToCart(int cartId,string email, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.RemoveToCart(cartId,email, connection);
        }

        public Response CartList(string email, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.CartList(email, connection);
        }


        public Response PlaceOrder(OrderRequest orderRequest, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.PlaceOrder(orderRequest, connection);
        }


        public Response OrderList(string email,string type,  SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.OrderList( email, type,  connection);
        }


        public Response UpdateOrderStatus(Orders order, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.UpdateOrderStatus(order, connection);
        }


        public Response DeleteUser(int userId, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.DeleteUser(userId, connection);
        }

        public Response AddCategory(Categories category, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.AddCategory(category, connection);
        }


        public Response ProductList(SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.ProductList(connection);
        }

        
    }
}
