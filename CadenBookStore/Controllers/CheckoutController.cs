using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadenBookStore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadenBookStore.Controllers
{
    public class CheckoutController : Controller
    {
        private IBookCartRepository repo { get; set; }
        private Basket basket { get; set; }

        public CheckoutController(IBookCartRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }


        [HttpGet]
        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View(new BookCart());
        }


        [HttpPost]
        public IActionResult Checkout(BookCart bookcart)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your basket is empty!");

            }

            if (ModelState.IsValid)
            {
                bookcart.Lines = basket.Items.ToArray();
                repo.SaveBook(bookcart);
                basket.ClearBasket();

                return RedirectToPage("/CheckoutComplete"); ;
            }
            else
            {
                return View();
            }
        }
    }
}
