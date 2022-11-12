using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CommonLib;
using System.Net;

namespace DALLib
{
    public class DABookInventory
    {


        BookInventory Book;
        string connectionString = "Data Source=GDC-LAPTOP-308;Initial Catalog=Libary;Integrated Security=True";

        //  string connectionString = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;


        public DABookInventory()
        {
            
        }


        public List<BookInventory> GetAllBookInventory()
        {
            List<BookInventory> list = new List<BookInventory>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllBooksInventory", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 30;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            BookInventory Book;

                            while (reader.Read())
                            {
                                Book = new BookInventory
                                {
                                    ID = (int)reader["Id"],
                                    BookId = (int)reader["BookId"],
                                    UserId = (int)reader["UserId"],
                                    CheckedIn = (bool)(reader)["CheckedOut"],
                                  //  checkintime = (DateTime)(reader)["CheckedInTime"],
                                  //  checkOut = (DateTime)(reader)["CheckedOutTime"],


                                };
                                list.Add(Book);

                            }
                        }

                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
                return new List<BookInventory>();
            }

        }
        public BookInventory GetUserCheckedOutBooks(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("GetUsersCheckedOutBooks", con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = Id;

                        cmd.CommandTimeout = 30;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Book = new BookInventory
                                {
                                    ID = (int)reader["Id"],
                                    BookId = (int)reader["BookId"],
                                    UserId = (int)reader["UserId"],
                                    CheckedIn = (bool)(reader)["CheckedOut"],
                                    checkintime = (DateTime)(reader)["CheckedInTime"],
                                    checkOut = (DateTime)(reader)["CheckedOutTime"],

                                };

                            }
                        }

                    }
                }

                return Book;
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
                return new BookInventory();
            }

        }
    
        public List<BookInventory> Test(int Bookid,int userid)
        {
            List<BookInventory> list = new List<BookInventory>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetUserBookInventory", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@BookId", SqlDbType.Int)).Value = Bookid;
                        cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int)).Value = userid;

                        cmd.CommandTimeout = 30;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            BookInventory Book;

                            while (reader.Read())
                            {
                                Book = new BookInventory
                                {
                                    ID = (int)reader["Id"],
                                    BookId = (int)reader["BookId"],
                                    UserId = (int)reader["UserId"],
                                    CheckedIn = (bool)(reader)["CheckedOut"],
                                   // checkintime = (DateTime)(reader)["CheckedInTime"],
                                   // checkOut = (DateTime)(reader)["CheckedOutTime"],


                                };
                                list.Add(Book);

                            }
                        }

                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
                return new List<BookInventory>();
            }

        }
        public void AddToBookInventory(int BookID, int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddToBookInventory", con))
                    {
                        con.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@BookId", SqlDbType.Int)).Value = BookID;
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int)).Value = UserID;
                        command.Parameters.Add(new SqlParameter("@CheckedOut", SqlDbType.Bit)).Value = 1;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
            }

        }

        public void AddToBookInventory(BookInventory dABookInventory)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddToBookInventory", con))
                    {
                        con.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@BookId", SqlDbType.Int)).Value = dABookInventory.BookId;
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int)).Value = dABookInventory.UserId;
                        command.Parameters.Add(new SqlParameter("@CheckedOut", SqlDbType.Bit)).Value = 1;
                       // command.Parameters.Add(new SqlParameter("@CheckedOutTime", SqlDbType.DateTime)).Value = DateTime.Now;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
            }

        }
        public void removeBookInventory(int userId,int bookId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("removeBookInventory", con))
                    {
                        con.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int)).Value = userId;
                        command.Parameters.Add(new SqlParameter("@BookId", SqlDbType.Int)).Value = bookId;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
            }

        }
        public BookInventory GetBookInventory(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("GetBookInventory", con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int)).Value = userId;


                        cmd.CommandTimeout = 30;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Book = new BookInventory
                                {
                                    ID = (int)reader["Id"],
                                    BookId = (int)reader["BookId"],
                                    UserId = (int)reader["UserId"],
                                    CheckedIn = (bool)(reader)["CheckedOut"],
                                    // Role = reader["RoleID"] is DBNull ? 1 : (int)reader["RoleID"],


                                };

                            }
                        }

                    }
                }

                return Book;
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
                return new BookInventory();
            }

        }
        public void Checkin(int BookId, int UserId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("CheckInBook", con))
                    {
                        con.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@BookId", SqlDbType.Int)).Value = BookId;
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int)).Value = UserId;
                     //   command.Parameters.Add(new SqlParameter("@CheckedInTime", SqlDbType.DateTime)).Value = DateTime.Now;


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
            }

        }
        public void Checkin(BookInventory dABookInventory)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("CheckInBook", con))
                    {
                        con.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@BookId", SqlDbType.Int)).Value = dABookInventory.BookId;
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int)).Value = dABookInventory.UserId;
                     //   command.Parameters.Add(new SqlParameter("@CheckedInTime", SqlDbType.DateTime)).Value = DateTime.Now;


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
            }

        }

        public void insertErrorLog(Exception ex)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("AddErrorLogging", con))
                {
                    con.Open();

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@StackTrace", SqlDbType.VarChar)).Value = ex.StackTrace;
                    command.Parameters.Add(new SqlParameter("@Message", SqlDbType.VarChar)).Value = ex.Message;
                    command.Parameters.Add(new SqlParameter("@Source", SqlDbType.VarChar)).Value = ex.Source;
                    command.Parameters.Add(new SqlParameter("@Url", SqlDbType.VarChar)).Value = "";
                    command.Parameters.Add(new SqlParameter("@LogDate", SqlDbType.DateTime)).Value = System.DateTime.Now;
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
