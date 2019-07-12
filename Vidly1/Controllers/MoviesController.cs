using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie();
            movie.MoveName = "The Post";

            var customers = new List<Customer>()
            {
                new Customer() {CustomerName="Customer 1" },
                new Customer() {CustomerName="Customer 2" }
            };
            var viewmodel = new RandomMovieViewModel()
            {
                Movie=movie,
                Customers=customers
            };
            
            return View(viewmodel);
           
        } 
    }
}