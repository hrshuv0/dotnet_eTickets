using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(m => m.Cinema);
            
            return View(allMovies);
        }
        
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(m => m.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) ||
                                                          n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            
            return View("Index", allMovies);
        }
        
        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }
        
        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _service.GetNewMovieDropdownValues();

            ViewBag.Cinemas   = new SelectList(movieDropdownData.Cinemas,   "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors    = new SelectList(movieDropdownData.Actors,    "Id", "FullName");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownValues();

                ViewBag.Cinemas   = new SelectList(movieDropdownData.Cinemas,   "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.Actors    = new SelectList(movieDropdownData.Actors,    "Id", "FullName");

                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        
        
        //Get: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            if (movieDetails is null)
            {
                return NotFound();
            }

            var response = new NewMovieVM()
            {
                Id            = movieDetails.Id,
                Name          = movieDetails.Name,
                Description   = movieDetails.Description,
                Price         = movieDetails.Price,
                ImageUrl      = movieDetails.ImageUrl,
                MovieCategory = movieDetails.MovieCategory,
                StartDate     = movieDetails.StartDate,
                EndDate       = movieDetails.EndDate,
                CinemaId      = movieDetails.CinemaId,
                ProducerId    = movieDetails.ProducerId,
                ActorIds      = movieDetails.ActorsMovies.Select(n => n.ActorId).ToList(),
            };
            
            var movieDropdownData = await _service.GetNewMovieDropdownValues();

            ViewBag.Cinemas   = new SelectList(movieDropdownData.Cinemas,   "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors    = new SelectList(movieDropdownData.Actors,    "Id", "FullName");
            
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }
            
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownValues();

                ViewBag.Cinemas   = new SelectList(movieDropdownData.Cinemas,   "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.Actors    = new SelectList(movieDropdownData.Actors,    "Id", "FullName");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


    }
}