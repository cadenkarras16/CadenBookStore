using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CadenBookStore.Models
{
    public class EFBookCartRepository : IBookCartRepository
    {
        private BookstoreContext context;

        public EFBookCartRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<BookCart> bookcarts => context.bookcarts.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveBook(BookCart bookcart)
        {
            context.AttachRange(bookcart.Lines.Select(x => x.Book));

            if (bookcart.CartId == 0)
            {
                context.bookcarts.Add(bookcart);
            }

            context.SaveChanges();
        }
    }
}
