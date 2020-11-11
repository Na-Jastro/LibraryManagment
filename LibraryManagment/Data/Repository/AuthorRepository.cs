using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context):base(context)
        {

        }
        public IEnumerable<Author> GetAllWithAuthors()
        {
            return _context.Authors.Include(p => p.Books);
        }

        public Author GetWithBooks(int id)
        {
            return _context.Authors.Where(p => p.AuthorId == id)
                .Include(p => p.Books)
                .FirstOrDefault();
        }
    }
}
