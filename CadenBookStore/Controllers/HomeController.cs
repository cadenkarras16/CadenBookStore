using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadenBookStore.Models;
using CadenBookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadenBookStore.Controllers
{
    public class HomeController : Controller
    {
        private IBookProjectRepository repo;

        public HomeController(IBookProjectRepository temp)
        {
            repo = temp;
        }


        // GET: /<controller>/
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {

            int pageSize = 5;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == bookCategory || bookCategory == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = (bookCategory == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
