using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using moviesNow.Connection;
using System.Data.Odbc;
using moviesNow.Models;
using System.Data;

namespace moviesNow.Controllers
{
    public class HomeController : Controller
    {
        private OdbcConnection _Dbconnection;
        public HomeController()
        {
            dbConnect _conn = new dbConnect();
            _Dbconnection = _conn.GetConnection();

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();

        }
        //public ActionResult Movies()
        //{
        //    OdbcCommand _command;
        //    var _conn = _Dbconnection;
        //    _command = new OdbcCommand("spw_list", _conn);
        //    _command.CommandType = CommandType.StoredProcedure;
        //    var reader = _command.ExecuteReader();


        //    List<Movies> values = new List<Movies> { };
        //    while (reader.Read())
        //    {
        //        var response = new Movies();
        //        response.Id = (int)reader["Id"];
        //        response.Name = reader["Name"].ToString();
        //        response.Director = reader["Director"].ToString();
        //        response.DateRelease = reader["DateRelease"].ToString();
        //        values.Add(response);
        //    }
        //    return View(values);
        //}
        public ActionResult Movies()
        {
            OdbcCommand _command;
            using (var _conn = _Dbconnection)
            {
                _command = new OdbcCommand("spw_list", _conn);
                _command.CommandType = CommandType.StoredProcedure;
                var reader = _command.ExecuteReader();
                List<Movies> values = new List<Movies> { };
                while (reader.Read())
                {
                    var response = new Movies();
                    response.Id = (int)reader["Id"];
                    response.Name = reader["Name"].ToString();
                    response.Director = reader["Director"].ToString();
                    response.DateRelease = reader["DateRelease"].ToString();
                    values.Add(response);
                }
                return View(values);
            }
        }
    }
}