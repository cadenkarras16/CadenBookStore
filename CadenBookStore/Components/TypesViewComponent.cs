using System;
using System.Linq;
using CadenBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadenBookStore.Components
{
    public class TypesViewComponent: ViewComponent
    {
        private IBookProjectRepository repo { get; set; }

        public TypesViewComponent (IBookProjectRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];


            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);


            return View(types);
        }
    }
}
