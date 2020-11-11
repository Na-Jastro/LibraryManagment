using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
        }
        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(p => p.Author)
                .Where(predicate);
        }
        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            return _context.Books.Include(p => p.Author)
                .Include(p => p.Borrower)
                .Where(predicate);
        }
        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _context.Books.Include(p => p.Author);
        }
    }
}
