using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    { private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie();
            movie.MovieName = "The Post";

            var customers = new List<Customer>()
            {
                new Customer() {CustomerName="Customer 1" },
                new Customer() {CustomerName="Customer 2" }
            };
            var viewmodel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewmodel);

        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            
            return View(movies);
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewmodel = new MovieFormViewModel()
            {   // Movie =new Movie(),
                Genres = genres

            };
            ViewBag.movie = "New";
            return View("MovieForm",viewmodel);
        }
        public ActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.MovieId == id);
            if (Movie == null)
                return HttpNotFound();
            return View(Movie);
        }
        public ActionResult Edit(int id)
        {
            var genres = _context.Genres.ToList();
            var movie = _context.Movies.Include(m =>m.Genre).Single(m => m.MovieId == id);
            var viewmodel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = genres
            };
            ViewBag.movie = "Edit";
            return View("MOvieForm",viewmodel);
        }
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel()
                {
                    Movie=movie,
                    Genres=_context.Genres.ToList()
                };
                return View("MovieForm", viewmodel);
            }
            if (movie.MovieId == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
                
            else
            {
                var movieInDb = _context.Movies.Include(m => m.Genre).Single(m => m.MovieId == movie.MovieId);
                movieInDb.MovieName = movie.MovieName;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Now;
            }
            _context.SaveChanges();
            return RedirectToAction("index","Movies");
        }
    }
}