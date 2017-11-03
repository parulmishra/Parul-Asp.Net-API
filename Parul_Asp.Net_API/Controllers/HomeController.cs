using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parul_Asp.Net_API.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Parul_Asp.Net_API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult GetRepos()
        {
            var repos = Repo.GetRepos();
            for (int i = 0; i < repos.Count; i++)
            {
                for (int j = 0; j < repos.Count; j++)
                {
                    if (repos[i].stargazers_count < repos[j].stargazers_count)
                    {
                        var temp = repos[i];
                        repos[i] = repos[j];
                        repos[j] = temp;
                    }
                }
            }
            return View(repos);
        }
    }
}
