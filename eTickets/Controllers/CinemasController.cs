using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allCimenas = await _context.Cinemas.ToListAsync();
            
            return View(allCimenas);
        }
    }
}