using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryManagment.Models;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.ViewModel;

namespace LibraryManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(IBookRepository bookRepository,
                              IAuthorRepository authorRepository,
                              ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            var homeVm = new HomeViewModel()
            {
                AuthorCount = _authorRepository.Count(p => true),
                BookCount = _bookRepository.Count(p => true),
                CustomerCount = _customerRepository.Count(p => true),
                LendBookCount = _bookRepository.Count(p => p.Borrower != null)
            };
            return View(homeVm);
        }
    }
}
