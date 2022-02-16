using System;
using System.Linq;

namespace CadenBookStore.Models
{
    public interface IBookProjectRepository
    {
        IQueryable<Book> Books { get; }
    }
}
