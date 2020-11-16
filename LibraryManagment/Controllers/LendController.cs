using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagment.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }
        [Route("Lend")]
        public IActionResult List()
        {
            var availableBooks = _bookRepository.FindWithAuthor(p => p.BorrowerId == 0);

            if (availableBooks.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableBooks);
            }
        }
        public IActionResult LendBook(int bookId)
        {
            var lendVm = new LendViewModel()
            {
                Book = _bookRepository.GetById(bookId),
                Customers = _customerRepository.GetAll()
            };
            return View(lendVm);
        }

        [HttpPost]
        public IActionResult LendBook(LendViewModel lendViewModel)
        {
            var book = _bookRepository.GetById(lendViewModel.Book.BookId);
            var customer = _customerRepository.GetById(lendViewModel.Book.BorrowerId);
            book.Borrower = customer;
            _bookRepository.Update(book);
            return RedirectToAction("List");
        }
    }
}
