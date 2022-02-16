using System;
using System.Linq;

namespace CadenBookStore.Models
{
    public class EFBookProjectRepository : IBookProjectRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookProjectRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
