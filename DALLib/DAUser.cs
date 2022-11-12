﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CommonLib;
using System.IO;

namespace DALLib
{
    public class DAUser
    {
       
        User User;
        public DAUser()
        {
           
        }
       
        //  string connectionString = ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        string connectionString = "Data Source=GDC-LAPTOP-308;Initial Catalog=Libary;Integrated Security=True";

        public List<User> GetAllUser()
        {
            List<User> list = new List<User>();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetUsers", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 30;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            User user;

                            while (reader.Read())
                            {
                                user = new User
                                {
                                    ID = reader["Id"] is DBNull ? 0 : (int)reader["Id"],
                                    UserName = (string)reader["Username"],
                                    password = (string)reader["Password"],
                                    Role = reader["RoleID"] is DBNull ? 1 : (int)reader["RoleID"],


                                };
                                list.Add(user);

                            }
                        }

                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
                return new List<User>();
            }

        }
        public User GetUser(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("GetUser", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = Id;

                        cmd.CommandTimeout = 30;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                User = new User
                                {
                                    ID = (int)reader["Id"],
                                    UserName = (string)reader["Username"],
                                    password = (string)reader["Password"],
                                    Role = reader["RoleID"] is DBNull ? 1 : (int)reader["RoleID"],


                                };

                            }
                        }

                    }
                }

                return User;
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
                return new User();
            }

        }
        public void updateUser(User User, int UserToBeUpdated)
        {
            SqlConnection lConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UpdateUserByUserID", lConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                lConnection.Open();
                cmd.Parameters.AddWithValue("@Id", UserToBeUpdated);
                cmd.Parameters.AddWithValue("@Username", User.UserName);
                cmd.Parameters.AddWithValue("@Password", User.password);
                cmd.Parameters.AddWithValue("@RoleId", User.Role);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
            }
        }
        public User GetUserByUsername(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("GetUserByUserName", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar)).Value = username;

                        cmd.CommandTimeout = 30;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                User = new User
                                {
                                    ID = (int)reader["Id"],
                                    UserName = (string)reader["Username"],
                                    password = (string)reader["Password"],
                                    Role = reader["RoleID"] is DBNull ? 1 : (int)reader["RoleID"],


                                };

                            }
                        }

                    }
                }

                return User;
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
                return new User();
            }

        }
        public void AddUser(int Role, string Username, string Password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddUser", con))
                    {
                        con.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@RoleId", SqlDbType.Int)).Value = Role;
                        command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar)).Value = Username;
                        command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = Password;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
            }

        }
        public void RemoveUser(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("RemoveUser", con))
                    {
                        con.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = Id;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
            }

        }
        public void UpdateUsername(int id, string newUsername)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateUserName", con))
                    {
                        con.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                        command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar)).Value = newUsername;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                insertErrorLog(ex);
            }

        }
        public void UpadatePassword(int id, string newPassword)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdatePasswrd", con))
                    {
                        con.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                        command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = newPassword;
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
