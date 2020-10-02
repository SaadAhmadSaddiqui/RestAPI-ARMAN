using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI_ARMAN.Models;

namespace RestAPI_ARMAN.Processors
{
    public class RoomProcessor
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-4Q6B9N0;Initial Catalog=ARMAN-DB;User ID=sa;Password=dictyt");
        public List<Room> rooms = new List<Room>();

        public JsonResult GetRooms()
        {
            try
            {
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SzabistRooms", con);
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow r in dt.Rows)
                    {
                        rooms.Add(new Room
                        {
                            RoomID = Convert.ToInt32(r["RoomID"]),
                            RoomName = r["RoomName"].ToString(),
                            RoomX = Convert.ToSingle(r["RoomX"]),
                            RoomY = Convert.ToSingle(r["RoomY"]),
                            RoomZ = Convert.ToSingle(r["RoomZ"])
                        });
                    }
                }
                return new JsonResult(rooms);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public JsonResult GetRoomByID(int ID)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SzabistRooms WHERE RoomID = "+ID+"", con);
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow r in dt.Rows)
                    {
                        rooms.Add(new Room
                        {
                            RoomID = Convert.ToInt32(r["RoomID"]),
                            RoomName = r["RoomName"].ToString(),
                            RoomX = Convert.ToSingle(r["RoomX"]),
                            RoomY = Convert.ToSingle(r["RoomY"]),
                            RoomZ = Convert.ToSingle(r["RoomZ"]),
                        });
                    }
                }
                return new JsonResult(rooms);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public JsonResult AddRoom(string RoomName, float RoomX, float RoomY, float RoomZ)
        {
            try
            {
                using (con)
                {
                    //" + RoomName + ", " + RoomX + ", " + RoomY + ", " + RoomZ + "
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO SzabistRooms (RoomName, RoomX, RoomY, RoomZ) VALUES(@RoomName, @RoomX, @RoomY, @RoomZ)", con);
                    cmd.Parameters.AddWithValue("@RoomName", RoomName);
                    cmd.Parameters.AddWithValue("@RoomX", RoomX);
                    cmd.Parameters.AddWithValue("@RoomY", RoomY);
                    cmd.Parameters.AddWithValue("@RoomZ", RoomZ);

                    cmd.ExecuteNonQuery();

                    SqlCommand nCmd = new SqlCommand("SELECT * FROM SzabistRooms", con);
                    nCmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(nCmd);
                    da.Fill(dt);

                    foreach (DataRow r in dt.Rows)
                    {
                        rooms.Add(new Room
                        {
                            RoomID = Convert.ToInt32(r["RoomID"]),
                            RoomName = r["RoomName"].ToString(),
                            RoomX = Convert.ToSingle(r["RoomX"]),
                            RoomY = Convert.ToSingle(r["RoomY"]),
                            RoomZ = Convert.ToSingle(r["RoomZ"]),
                        });
                    }
                }
                return new JsonResult(rooms);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public JsonResult UpdateRoomName(int RoomID, string RoomName)
        {
            try
            {
                using (con)
                {
                    //" + RoomName + ", " + RoomX + ", " + RoomY + ", " + RoomZ + "
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE SzabistRooms SET RoomName = @RoomName WHERE RoomID = '"+RoomID+"'", con);
                    cmd.Parameters.AddWithValue("@RoomName", RoomName);

                    cmd.ExecuteNonQuery();

                    SqlCommand nCmd = new SqlCommand("SELECT * FROM SzabistRooms", con);
                    nCmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(nCmd);
                    da.Fill(dt);

                    foreach (DataRow r in dt.Rows)
                    {
                        rooms.Add(new Room
                        {
                            RoomID = Convert.ToInt32(r["RoomID"]),
                            RoomName = r["RoomName"].ToString(),
                            RoomX = Convert.ToSingle(r["RoomX"]),
                            RoomY = Convert.ToSingle(r["RoomY"]),
                            RoomZ = Convert.ToSingle(r["RoomZ"]),
                        });
                    }
                }
                return new JsonResult(rooms);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public JsonResult UpdateRoom(int RoomID, string RoomName, float RoomX, float RoomY, float RoomZ)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE SzabistRooms SET RoomName = @RoomName, RoomX = @RoomX, RoomY = @RoomY, RoomZ = @RoomZ WHERE RoomID = '" + RoomID + "'", con);
                    cmd.Parameters.AddWithValue("@RoomName", RoomName);
                    cmd.Parameters.AddWithValue("@RoomX", RoomX);
                    cmd.Parameters.AddWithValue("@RoomY", RoomY);
                    cmd.Parameters.AddWithValue("@RoomZ", RoomZ);

                    cmd.ExecuteNonQuery();

                    SqlCommand nCmd = new SqlCommand("SELECT * FROM SzabistRooms", con);
                    nCmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(nCmd);
                    da.Fill(dt);

                    foreach (DataRow r in dt.Rows)
                    {
                        rooms.Add(new Room
                        {
                            RoomID = Convert.ToInt32(r["RoomID"]),
                            RoomName = r["RoomName"].ToString(),
                            RoomX = Convert.ToSingle(r["RoomX"]),
                            RoomY = Convert.ToSingle(r["RoomY"]),
                            RoomZ = Convert.ToSingle(r["RoomZ"]),
                        });
                    }
                }
                return new JsonResult(rooms);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public JsonResult DeleteRoom(int ID)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM SzabistRooms WHERE RoomID = "+ID+"", con);
                    cmd.ExecuteNonQuery();

                    SqlCommand nCmd = new SqlCommand("SELECT * FROM SzabistRooms", con);
                    nCmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(nCmd);
                    da.Fill(dt);

                    foreach (DataRow r in dt.Rows)
                    {
                        rooms.Add(new Room
                        {
                            RoomID = Convert.ToInt32(r["RoomID"]),
                            RoomName = r["RoomName"].ToString(),
                            RoomX = Convert.ToSingle(r["RoomX"]),
                            RoomY = Convert.ToSingle(r["RoomY"]),
                            RoomZ = Convert.ToSingle(r["RoomZ"]),
                        });
                    }
                }
                return new JsonResult(rooms);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}