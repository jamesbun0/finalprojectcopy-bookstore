using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public enum TitleFilter { None, Ascending, Descending }
    public enum AuthorFilter { None, Ascending, Descending }
    public enum PopularityFilter {None, Ascending, Descending}
    public enum DateFilter { None, Newest, Oldest }
    public enum RatingFilter {None, Ascending, Descending }
    public enum StockFilter { False, True }

    [AllowAnonymous]
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(String SearchString)
        {
            //ViewBag.BookCount = _context.Books.Count();
            if (SearchString != null && SearchString != "")
            {
                List<Book> SelectedBooks = new List<Book>();
                var query = from r in _context.Books
                            select r;
                query = query.Where(r => r.Title.Contains(SearchString) || r.Author.Contains(SearchString));
                
                //dont think you need to display genre in results
                //SelectedBooks = query.Include(r => r.Genre).ToList();
                SelectedBooks = query.Include(r => r.Reviews).ToList();

                ViewBag.SelectedBooks = SelectedBooks.Count();
                ViewBag.TotalBooks = _context.Books.Count();
                return View(SelectedBooks.OrderByDescending(r => r.BookID));
            }
            ViewBag.SelectedBooks = _context.Books.Count();
            ViewBag.TotalBooks = _context.Books.Count();
            return View(_context.Books.Include(r => r.Genre).OrderByDescending(r => r.BookID));
            //return View(_context.Books.Include(r => r.Reviews).ToList());
        }

        public IActionResult DetailedSearch()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }


        public IActionResult DisplaySearchResults(String TitleString, String AuthorString, int UniqueNumber, int SelectedGenre, 
            TitleFilter SelectedTitleFilter, AuthorFilter SelectedAuthorFilter, PopularityFilter SelectedPopularityFilter, 
            DateFilter SelectedDateFilter, RatingFilter SelectedRatingFilter, StockFilter SelectedStockFilter)
        {
            List<Book> SelectedBooks = new List<Book>();
            var query = from r in _context.Books.Include(b => b.Genre)
                select r;

            if (TitleString != null && TitleString != "")
            {
                query = query.Where(r => r.Title.Contains(TitleString));
            }

            if (AuthorString != null && AuthorString != "")
            {
                query = query.Where(r => r.Author.Contains(AuthorString));
            }

            if (UniqueNumber != 0)
            {
                query = query.Where(r => r.UniqueID == UniqueNumber);
            }

            if (SelectedGenre != 0 )
            {
                Genre GenreToDisplay = _context.Genres.Find(SelectedGenre);
                query = query.Where(r => r.Genre == GenreToDisplay);
            }

            if (SelectedStockFilter == StockFilter.True)
            {
                query = query.Where(b => b.CopiesOnHand > 0);
            }
            
            //if no sort
            SelectedBooks = query.Include(b => b.Reviews).ToList();

            if (SelectedTitleFilter == TitleFilter.Ascending)
            {
                SelectedBooks = query.OrderBy(r => r.Title).ToList();
            }
            else if(SelectedTitleFilter == TitleFilter.Descending)
            {
                SelectedBooks = query.OrderByDescending(r => r.Title).ToList();
            }

            if (SelectedAuthorFilter == AuthorFilter.Ascending)
            {
                SelectedBooks = query.OrderBy(r => r.Author).ToList();
            }
            else if(SelectedAuthorFilter == AuthorFilter.Descending)
            {
                SelectedBooks = query.OrderByDescending(r => r.Author).ToList();
            }

            //POPULARTY FILTER CODE
            if (SelectedPopularityFilter == PopularityFilter.Ascending)
            {
                query = query.OrderByDescending(r => r.CopiesSold);
            }
            //don't need filter if not chosen - no else
          

            if (SelectedDateFilter == DateFilter.Oldest)
            {
                SelectedBooks = query.OrderBy(r => r.PublishedDate).ToList();
            }
            else if (SelectedDateFilter == DateFilter.Newest)
            {
                SelectedBooks = query.OrderByDescending(r => r.PublishedDate).ToList();
            }

            if (SelectedRatingFilter == RatingFilter.Descending)
            {
                //Int32 AvgRating = 0;
                //Int32 
                //List<Book> books = _context.Books.Include(b => b.Reviews).Where(b => b.Reviews != null).ToList();               
                //foreach(Book b in books)
                //{
                //    AvgRating +=
                //}
                //foreach(Book book in query)
                SelectedBooks = query.OrderByDescending(r => r.AvgRating).ToList();
            }

            //execute the query and store it into the SelectedRepositories list
            //SelectedBooks = query.Include(r => r.Reviews).ToList();
            ViewBag.SelectedBooks = SelectedBooks.Count();
            ViewBag.TotalBooks = _context.Books.Count();
            //pass the filtered results to display in view
            return View("Index", SelectedBooks);

        }

        //public IActionResult DisplayBooksToReorder()
        //{
        //    List<Book> SelectedBooks = new List<Book>();
        //    var query = from r in _context.Books
        //                select r;

        //    query = query.Where(r => r.CopiesOnHand < r.Reorder);
        //    query = query.OrderBy()
        //}

        public SelectList GetAllGenres()
        {
            List<Genre> Genres = _context.Genres.ToList();

            Genre SelectNone = new Genre() { GenreID = 0, GenreName = "All Genres" };
            Genres.Add(SelectNone);

            SelectList AllGenres = new SelectList(Genres.OrderBy(l => l.GenreID), "GenreID", "GenreName");

            return AllGenres;
        }
    }
}