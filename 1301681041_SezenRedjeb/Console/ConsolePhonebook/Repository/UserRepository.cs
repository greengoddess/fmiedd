using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Kaffee
{
   public class UserRepository
    {
       OleDbConnection connection;
       OleDbCommand command;

       public void ConnectTo()
       {
           connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DataBase.accdb;Persist Security Info=False;");
           command = connection.CreateCommand();
       }

       public UserRepository()
       {
           ConnectTo();
       }

       public void Insert(User user)
       {
           try
           {
               command.CommandText = "INSERT INTO [User] ([Username],[Password],[FirstName],[LastName]) VALUES('" + user.Username + "','" + user.Password + "','" + user.FirstName + "','" + user.LastName + "')";
               command.CommandType = CommandType.Text;

               connection.Open();

               command.ExecuteNonQuery();
           }
           finally
           {
               connection.Close();
           }
       }

       public void Update(User oldUser, User newUser)
       {
           try
           {
               command.CommandText = "UPDATE [User] SET[Username]='" + newUser.Username + "',[Password]='" + newUser.Password + "',[FirstName]='" + newUser.FirstName + "',[LastName]='" + newUser.LastName + "'WHERE [ID]=" + oldUser.ID;
               command.CommandType = CommandType.Text;

               connection.Open();

               command.ExecuteNonQuery();
           }
           finally
           {
               connection.Close();
           }
       }

       public void Delete(User user)
       {
           try
           {
               command.CommandText = "DELETE FROM [User] WHERE [ID]=" + user.ID;
               command.CommandType = CommandType.Text;

               connection.Open();

               command.ExecuteNonQuery();

           }
           finally
           {
               connection.Close();
           }
       }
       public User GetByID(int ID)
       {
           try
           {
               command.CommandText = "SELECT * FROM [User]";
               command.CommandType = CommandType.Text;

               connection.Open();

               OleDbDataReader reader = command.ExecuteReader();

               while (reader.Read())
               {
                   User user = new User();
                   user.ID = int.Parse(reader["ID"].ToString());
                   user.Username = reader["Username"].ToString();
                   user.Password = reader["Password"].ToString();
                   user.FirstName = reader["FirstName"].ToString();
                   user.LastName = reader["LastName"].ToString();

                   if (user.ID == ID)
                   {
                       return user;
                   }

               }
               return null;
           }

           finally
           {
               connection.Close();
           }
       }
       public List<User> GetAll()
       {
           List<User> list = new List<User>();
           try
           {
               command.CommandText = "SELECT * FROM [User]";
               command.CommandType = CommandType.Text;

               connection.Open();

               OleDbDataReader reader = command.ExecuteReader();

               while (reader.Read())
               {
                   User user = new User();
                   user.ID = int.Parse(reader["ID"].ToString());
                   user.Username = reader["Username"].ToString();
                   user.Password = reader["Password"].ToString();
                   user.FirstName = reader["FirstName"].ToString();
                   user.LastName = reader["LastName"].ToString();

                   list.Add(user);

               }
               return list;
           }

           finally
           {
               connection.Close();
           }
           
       }
       public User GetByUsernameAndPassword(string username, string password)
       {
           try
           {
               command.CommandText = "SELECT * FROM [User]";
               command.CommandType = CommandType.Text;

               connection.Open();

               OleDbDataReader reader = command.ExecuteReader();

               while (reader.Read())
               {
                   User user = new User();
                   user.ID = int.Parse(reader["ID"].ToString());
                   user.Username = reader["Username"].ToString();
                   user.Password = reader["Password"].ToString();
                   user.FirstName = reader["FirstName"].ToString();
                   user.LastName = reader["LastName"].ToString();

                   if (user.Username == username && user.Password == password)
                   {
                       return user;
                   }

               }
               return null;
           }

           finally
           {
               connection.Close();
           }
       }
    }
}
