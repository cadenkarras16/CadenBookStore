using System;
using System.Linq;

namespace CadenBookStore.Models
{
    public interface IBookCartRepository
    {
        IQueryable<BookCart> bookcarts { get; }

        void SaveBook(BookCart bookcart);
    }
}
