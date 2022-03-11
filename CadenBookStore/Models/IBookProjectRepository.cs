using System;
using System.Linq;

namespace CadenBookStore.Models
{
    public interface IBookProjectRepository
    {
        IQueryable<Book> Books { get; }

        public void SaveBook(Book b);

        public void CreateBook(Book b);

        public void DeleteBook(Book b);
    }
}
