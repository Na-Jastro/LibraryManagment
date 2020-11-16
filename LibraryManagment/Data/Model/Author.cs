using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required, MinLength(3, ErrorMessage = "Name Required"), MaxLength(30)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
