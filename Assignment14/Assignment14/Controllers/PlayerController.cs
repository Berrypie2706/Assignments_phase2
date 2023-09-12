using Assignment14.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Assignment14.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        string conString = ConfigurationManager.ConnectionStrings["PlyrConStr"].ConnectionString;
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        public ActionResult Index()
        {
            List<Player> player = new List<Player>();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("Select * from Players");
                cmd.Connection = con;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    player.Add(new Player
                    {
                        PlayerId = (int)(reader["PlayerId"]),
                        FirstName = (string)(reader["FirstName"]),
                        LastName = (string)(reader["LastName"]),
                        JerseyNumber = (int)(reader["JerseyNumber"]),
                        Position = (string)(reader["Position"]),
                        Team = (string)(reader["Team"])
                    }
                    );
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            return View(player);
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            Player player = new Player();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Players where PlayerId = @pid");
                cmd.Parameters.AddWithValue("@pid", id);
                cmd.Connection = con;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    player.PlayerId = (int)(reader["PlayerId"]);
                    player.FirstName = (string)(reader["FirstName"]);
                    player.LastName = (string)(reader["LastName"]);
                    player.JerseyNumber = (int)(reader["JerseyNumber"]);
                    player.Position = (string)(reader["Position"]);
                    player.Team = (string)(reader["Team"]);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            return View(player);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View(new Player());
        }

        // POST: Player/Create
        [HttpPost]
        public ActionResult Create(Player player)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("insert into Players values(@pid, @fn, @ln, @jn, @pn, @team)");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@pid", player.PlayerId);
                cmd.Parameters.AddWithValue("@fn", player.FirstName);
                cmd.Parameters.AddWithValue("@ln", player.LastName);
                cmd.Parameters.AddWithValue("@jn", player.JerseyNumber);
                cmd.Parameters.AddWithValue("@pn", player.Position);
                cmd.Parameters.AddWithValue("@team", player.Team);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int id)
        {
            Player player = new Player();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("Select * from Players");
                cmd.Connection = con;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    player.PlayerId = (int)(reader["PlayerId"]);
                    player.FirstName = (string)(reader["FirstName"]);
                    player.LastName = (string)(reader["LastName"]);
                    player.JerseyNumber = (int)(reader["JerseyNumber"]);
                    player.Position = (string)(reader["Position"]);
                    player.Team = (string)(reader["Team"]);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            return View(player);
        }

        // POST: Player/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Player player)
        {

            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("update Players set PlayerId = @id, FirstName = @fn, LastName = @ln, JerseyNumber = @jn, Position = @pn, Team = @team where PlayerId = @id");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", player.PlayerId);
                cmd.Parameters.AddWithValue("@fn", player.FirstName);
                cmd.Parameters.AddWithValue("@ln", player.LastName);
                cmd.Parameters.AddWithValue("@jn", player.JerseyNumber);
                cmd.Parameters.AddWithValue("@pn", player.Position);
                cmd.Parameters.AddWithValue("@team", player.Team);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }

        }

        // GET: Player/Delete/5
        public ActionResult Delete(int id)
        {
            Player player = new Player();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Players where PlayerId = @pid");
                cmd.Parameters.AddWithValue("@pid", id);
                cmd.Connection = con;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    player = new Player
                    {
                        PlayerId = (int)(reader["PlayerId"]),
                        FirstName = (string)(reader["FirstName"]),
                        LastName = (string)(reader["LastName"]),
                        JerseyNumber = (int)(reader["JerseyNumber"]),
                        Position = (string)(reader["Position"]),
                        Team = (string)(reader["Team"])
                    };
                }


            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Player player)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("delete from Players where PlayerId = @pid");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@pid", player.PlayerId);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Assignment14.Models;

//namespace Assignment_14.Controllers
//{
//    public class PlayerController : Controller
//    {
//        string conString = ConfigurationManager.ConnectionStrings["PlyrConStr"].ConnectionString;
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static SqlDataReader srdr;

//        // GET: Players
//        public ActionResult Index()
//        {
//            List<Player> players = new List<Player>();
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("select * from Players");
//                cmd.Connection = con;
//                con.Open();
//                srdr = cmd.ExecuteReader();
//                while (srdr.Read())
//                {
//                    players.Add(
//                        new Player
//                        {
//                            PlayerId = (int)(srdr["PlayerId"]),
//                            FirstName = (string)(srdr["FirstName"]),
//                            LastName = (string)(srdr["LastName"]),
//                            JerseyNumber = (int)(srdr["JerseyNumber"]),
//                            Position = (string)(srdr["Position"]),
//                            Team = (string)(srdr["Team"])
//                        });
//                }
//            }
//            catch (Exception ex)
//            {
//                TempData["error"] = ex.Message;
//                return View("Error");
//            }
//            finally { con.Close(); }
//            return View(players);
//        }


//        // GET: Players/Details/5
//        public ActionResult Details(int id)
//        {
//            Player player = new Player();
//            con = new SqlConnection(conString);
//            try
//            {
//                cmd = new SqlCommand("select * from Players where PlayerId = @id");
//                cmd.Parameters.AddWithValue("@id", id);
//                cmd.Connection = con;
//                con.Open();
//                srdr = cmd.ExecuteReader();
//                while (srdr.Read())
//                {
//                    player.PlayerId = (int)(srdr["PlayerId"]);
//                    player.FirstName = (string)(srdr["FirstName"]);
//                    player.LastName = (string)(srdr["LastName"]);
//                    player.JerseyNumber = (int)(srdr["JerseyNumber"]);
//                    player.Position = (string)(srdr["Position"]);
//                    player.Team = (string)(srdr["Team"]);
//                }
//            }
//            catch (Exception ex)
//            {
//                TempData["error"] = ex.Message;
//                return View("Error");
//            }
//            finally
//            {
//                if (con != null && con.State != ConnectionState.Closed)
//                {
//                    con.Close();
//                }
//            }
//            return View(player);
//        }

//        // GET: Players/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Players/Create
//        [HttpPost]
//        public ActionResult Create(Player player)
//        {
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("insert into Players values (@id,@firstname,@lastname,@jerseynumber,@position,@team)");
//                cmd.Connection = con;
//                cmd.Parameters.AddWithValue("@id", player.PlayerId);
//                cmd.Parameters.AddWithValue("@firstname", player.FirstName);
//                cmd.Parameters.AddWithValue("@lastname", player.LastName);
//                cmd.Parameters.AddWithValue("@jerseynumber", player.JerseyNumber);
//                cmd.Parameters.AddWithValue("@position", player.Position);
//                cmd.Parameters.AddWithValue("@team", player.Team);
//                con.Open();
//                cmd.ExecuteNonQuery();
//                return RedirectToAction("Index");
//            }
//            catch (Exception ex)
//            {
//                TempData["error"] = ex.Message;
//                return View("Error");
//            }
//            finally
//            {
//                con.Close();
//            }
//        }

//        // GET: Players/Edit/5
//        public ActionResult Edit(int id)
//        {
//            Player player = new Player();
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("select * from Players");
//                cmd.Connection = con;
//                con.Open();
//                srdr = cmd.ExecuteReader();
//                while (srdr.Read())
//                {
//                    player.PlayerId = (int)(srdr["PlayerId"]);
//                    player.FirstName = srdr["FirstName"].ToString();
//                    player.LastName = srdr["LastName"].ToString();
//                    player.JerseyNumber = (int)(srdr["JerseyNumber"]);
//                    player.Position = srdr["position"].ToString();
//                    player.Team = srdr["Team"].ToString();
//                }
//            }
//            catch (Exception ex)
//            {
//                TempData["error"] = ex.Message;
//                return View("Error");
//            }
//            return View(player);
//        }


//        // POST: Players/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, Player player)
//        {
//            try
//            {
//                // TODO: Add update logic here
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("update Players set FirstName =@pFn, LastName = @pLn, JerseyNumber = @pJN, Position = @pP,Team =@pT where PlayerId =@upid");
//                cmd.Connection = con;
//                cmd.Parameters.AddWithValue("@upid", player.PlayerId);
//                cmd.Parameters.AddWithValue("pFn", player.FirstName);
//                cmd.Parameters.AddWithValue("pLn", player.LastName);
//                cmd.Parameters.AddWithValue("pJN", player.JerseyNumber);
//                cmd.Parameters.AddWithValue("pP", player.Position);
//                cmd.Parameters.AddWithValue("pT", player.Team);
//                con.Open();
//                cmd.ExecuteNonQuery();
//                return RedirectToAction("Index");
//            }
//            catch (Exception ex)
//            {
//                TempData["error"] = ex.Message;
//                return View("Error");
//            }
//            finally
//            {
//                con.Close();
//            }
//        }

//        // GET: Players/Delete/5
//        public ActionResult Delete(int id)
//        {
//            Player player = new Player();
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("select * from Players");
//                cmd.Parameters.AddWithValue("@id", id);
//                cmd.Connection = con;
//                con.Open();
//                srdr = cmd.ExecuteReader();
//                while (srdr.Read())
//                {
//                    player = new Player
//                    {
//                        PlayerId = (int)(srdr["PlayerId"]),
//                        FirstName = (string)(srdr["FirstName"]),
//                        LastName = (string)(srdr["LastName"]),
//                        JerseyNumber = (int)(srdr["JerseyNumber"]),
//                        Position = (string)(srdr["Position"]),
//                        Team = (string)(srdr["Team"]),
//                    };
//                }
//            }
//            catch (Exception ex)
//            {
//                TempData["error"] = ex.Message;
//                return View("Error");
//            }
//            finally { con.Close(); }
//            return View(player);
//        }
//        // POST: Players/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, Player player)
//        {
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("delete from Players where PlayerId=@pid");
//                cmd.Connection = con;
//                cmd.Parameters.AddWithValue("@pid", id);
//                con.Open();
//                cmd.ExecuteNonQuery();
//                return RedirectToAction("Index");

//            }
//            catch (Exception ex)
//            {
//                TempData["error"] = ex.Message;
//                return View("Error");
//            }
//            finally
//            {
//                con.Close();
//            }
//        }
//    }
//}
