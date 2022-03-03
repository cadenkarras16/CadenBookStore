using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadenBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CadenBookStore.Models.Infrastructure;


namespace CadenBookStore.Pages
{
    public class AddToCartModel : PageModel
    {
        private IBookProjectRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }


        public AddToCartModel (IBookProjectRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }




        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);


            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
