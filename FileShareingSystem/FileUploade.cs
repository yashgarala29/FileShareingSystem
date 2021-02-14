using FileShareingSystem.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FileShareingSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FileUploade" in both code and config file together.
    public class FileUploade : IFileUploade
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FileShareingSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void DoWork()
        {
        }

        public List<listOfAllFile> GetFile(string fileid)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                //cmd.CommandText = "SELECT * FROM FileDetail  WHERE  ComonID=";
                cmd.CommandText = "SELECT* FROM FileDetail WHERE  ComonID=@comonID";

                SqlParameter filename = new SqlParameter("@comonID", fileid);
                cmd.Parameters.Add(filename);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                
                List<listOfAllFile> listOfAllFile = new List<listOfAllFile>();
                //int Id = sqlDataReader.GetInt32(0);
                while (sqlDataReader.Read())
                {
                    var temp = new listOfAllFile
                    {
                        Id = sqlDataReader.GetInt32(0),
                        UplodeDate = sqlDataReader.GetDateTime(1),
                        FileName = sqlDataReader.GetString(2),
                        ComonId = sqlDataReader.GetString(4),
                        UserId = sqlDataReader.GetInt32(3),
                    };
                    listOfAllFile.Add(temp);
                }
                sqlConnection.Close();
                return listOfAllFile;
            }
            catch(Exception e)
            {

            }
            return null;    
        }

        public int Login(string username, string password)
        {

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "SELECT * FROM UserDetail WHERE username=@username AND password=@password ";
                SqlParameter username_1 = new SqlParameter("@username", username);
                //SqlParameter email = new SqlParameter("@email", r_user.email);
                SqlParameter password_1 = new SqlParameter("@password", password);
                cmd.Parameters.Add(username_1);
                //cmd.Parameters.Add(email);
                cmd.Parameters.Add(password_1);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();
                string temp = sqlDataReader.GetString(1);
                sqlConnection.Close();
                
                if (temp ==null)
                {
                    return 0;
                }
                else
                {
                    return 1;

                }
            }
            catch (Exception e)
            {
                
            }
            return 0;
        }

        public void Register(userDetail r_user)
        {
            try
            { SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "INSERT INTO UserDetail (username,email,password)VALUES(@username,@email,@password) ";
            SqlParameter username = new SqlParameter("@username", r_user.Username);
            SqlParameter email = new SqlParameter("@email", r_user.email);
            SqlParameter password = new SqlParameter("@password", r_user.password);
            cmd.Parameters.Add(username);
            cmd.Parameters.Add(email);
            cmd.Parameters.Add(password);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            } catch(Exception e)
            {

            }
            }

        public void SaveFile(requestFile r_file)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "INSERT INTO FileDetail (UplodeDate,FileName,UserId,ComonID)VALUES(@UplodeDate,@FileName,@UserId,@ComonID) ";
            SqlParameter UplodeDate = new SqlParameter("@UplodeDate", DateTime.Now);
            SqlParameter FileName = new SqlParameter("@FileName", r_file.FileName);
            SqlParameter UserId = new SqlParameter("@UserId", r_file.UserId);
                SqlParameter comomid = new SqlParameter("@ComonID", r_file.ComonId);
                cmd.Parameters.Add(UplodeDate);
            cmd.Parameters.Add(FileName);
            cmd.Parameters.Add(UserId);
                cmd.Parameters.Add(comomid);

                sqlConnection.Open();
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            }
            catch(Exception e)
            {
                
            }
            }
    }
}
