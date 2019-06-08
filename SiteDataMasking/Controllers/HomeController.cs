using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using SiteDataMasking.Models;

namespace SiteDataMasking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(
            [FromServices]IConfiguration config)
        {
            List<Cliente> clientes;

            using (SqlConnection conexao =
                new SqlConnection(
                    config.GetConnectionString("ExemploDataMask")))
            {
                clientes = conexao.Query<Cliente>(
                    "SELECT * " +
                    "FROM dbo.Clientes").AsList();
            }

            return View(clientes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}