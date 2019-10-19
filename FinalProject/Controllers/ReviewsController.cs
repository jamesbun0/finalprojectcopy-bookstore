using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null )
            {
                return View(_context.Reviews.Include(r => r.Book).Where(r => r.Book.BookID == id));
            }
            return View(await _context.Reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        [Authorize(Roles = "Customer")]
        public IActionResult Create(int? id)
        {
            Review review = new Review();

            //add check code if statement - customer must have compelted order that consists of the book
            string userName = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            var cart = _context.Carts
                           .Include(r => r.CartDetails)
                           .ThenInclude(r => r.Book)
                           .FirstOrDefault(r => r.CartID == id);
            if (cart == null)
            {
                return View("Error", new String[] { "You cannot review books unless you purchase them" });
            }


            return View(review);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public IActionResult Create([Bind("Rating,ReviewsWritten")] Review review, int? id)
        {

            Book book = _context.Books.Find(id);
            review.Book = book;
            string userName = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            review.Author = user;

            if (ModelState.IsValid)
            {
                _context.Add(review);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(review);

        }

        // GET: Reviews/Approve
        [Authorize(Roles = "Employee, Manager")]
        public IActionResult Approve(int? id)
        {
            Review review = new Review();
            return View(review);
        }

        ////POST: Reviews/Approve
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee, Manager")]
        public IActionResult Approve(Review review, int? id)
        {

            string userName = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            review.Approver = user;
            user.NumOfReviewsApp += 1;
            _context.Update(user);
            _context.SaveChanges();


            if (ModelState.IsValid)
            {
                review.ReviewsApproved = true;
                _context.Update(review);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(review);




            //_context.SaveChanges();
            //_context.Update(review);

            //return View(var);

        }

        // GET: Reviews/Reject
        [Authorize(Roles = "Employee, Manager")]
        public IActionResult Reject()
        {
            return View();

        }

        //POST: Reviews/Reject
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee, Manager")]
        public ActionResult Reject([Bind("ReviewsApproved")] Review review)
        {

            //boolean ReviewsApproved should be false
            //if (ModelState.IsValid)
            //{
            //    _context.Add(review);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(review);

            string userName = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            review.Approver = user;
            user.NumOfReviewsRej += 1;
            _context.Update(user);
            _context.SaveChanges();


            if (ModelState.IsValid)
            {
                review.ReviewsApproved = false;
                _context.Add(review);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(review);

        }

        // GET: Reviews/Edit/5
        [Authorize(Roles = "Employee, Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee, Manager")]
        //have an if statement for if this book was not purchased by this customer, then return error
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,Rating,ReviewsWritten,ReviewsApproved")] Review review)
        {
            if (id != review.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review.ReviewsWritten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        //// GET: Reviews/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var review = await _context.Reviews
        //        .FirstOrDefaultAsync(m => m.ReviewID == id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(review);
        //}

        //// POST: Reviews/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //var review = await _context.Reviews.FindAsync(id);
        //_context.Reviews.Remove(review);
        //await _context.SaveChangesAsync();
        //return RedirectToAction(nameof(Index));

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewID == id);
        }
    }



}


//hi