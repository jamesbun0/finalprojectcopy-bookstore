using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Seeding;
using FinalProject.DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class SeedController : Controller
    {
        private AppDbContext _db;

        public SeedController(AppDbContext context)
        {
            _db = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeedBooks()
        {
            try
            {
                Seeding.SeedBooks.SeedAllBooks(_db);
            }
            catch (NotSupportedException ex)
            {
                return View("Error", new String[] { "The data has already been added", ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return View("Error", new String[] { "There was an error adding data to the database", ex.Message });
            }

            return View("Confirm");
        }

        public IActionResult SeedGenres()
        {
            try
            {
                Seeding.SeedGenres.SeedAllGenres(_db);
            }
            catch (NotSupportedException ex)
            {
                return View("Error", new String[] { "The data has already been added", ex.Message});
            }
            catch (InvalidOperationException ex)
            {
                return View("Error", new String[] { "There was an error adding data to the database", ex.Message });
            }

            return View("Confirm");
        }

        //public IActionResult SeedCustomers()
        //{
        //    try
        //    {
        //       Seeding.SeedCustomers.SeedAllCustomers(_db);
        //    }
        //    catch (NotSupportedException ex)
        //    {
        //        return View("Error", new String[] { "The data has already been added", ex.Message });
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        return View("Error", new String[] { "There was an error adding data to the database", ex.Message });
        //    }

        //    return View("Confirm");
        //}

        //public IActionResult SeedEmployees()
        //{
        //    try
        //    {
        //        Seeding.SeedEmployees.SeedAllEmployees(_db);
        //    }
        //    catch (NotSupportedException ex)
        //    {
        //        return View("Error", new String[] { "The data has already been added", ex.Message });
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        return View("Error", new String[] { "There was an error adding data to the database", ex.Message });
        //    }

        //    return View("Confirm");
        //}

        //public IActionResult SeedManagers()
        //{
        //    try
        //    {
        //        Seeding.SeedManagers.SeedAllManagers(_db);
        //    }
        //    catch (NotSupportedException ex)
        //    {
        //        return View("Error", new String[] { "The data has already been added", ex.Message });
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        return View("Error", new String[] { "There was an error adding data to the database", ex.Message });
        //    }

        //    return View("Confirm");
        //}
    }
}
