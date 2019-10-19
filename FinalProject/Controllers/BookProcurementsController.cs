using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.DAL;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class BookProcurementsController : Controller
    {
        private readonly AppDbContext _context;

        public BookProcurementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BookProcurements
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookProcurements.ToListAsync());
        }

        // GET: BookProcurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookProcurement = await _context.BookProcurements
                .FirstOrDefaultAsync(m => m.BookProcurementID == id);
            if (bookProcurement == null)
            {
                return NotFound();
            }

            return View(bookProcurement);
        }

        // GET: BookProcurements/Create
        public IActionResult ManualReorder(int? id)
        {
            //check if bookid exists
            if (id == null)
            {
                return View("Error", new string[] { "Book does not exist" });
            }

            //Find the book
            Book book = _context.Books.Include(b => b.BookProcurements).FirstOrDefault(b => b.BookID == id);            

            //store user's name
            string userName = User.Identity.Name;
            //find the user in the database
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            List<BookProcurement> PrevOrders = book.BookProcurements.OrderByDescending(b => b.ProcurementDate).ToList();
            Int32 LastOrderQuantity = 5;
            Decimal LastOrderPrice = 1.00m;
            if (PrevOrders.Count() > 0)
            {
                BookProcurement LastOrder = PrevOrders[0];
                LastOrderQuantity = LastOrder.Quantity;
                LastOrderPrice = LastOrder.Price;
            }

            ViewBag.ProfitMargin = book.Price - book.Cost;

            

            BookProcurement bp = new BookProcurement() { Book = book, UserName = user.FirstName + " " + user.LastName , Quantity= LastOrderQuantity, Price = LastOrderPrice };
            _context.BookProcurements.Add(bp);
            _context.SaveChanges();


            //maybe create a viewbag getting the last price of that book's reorder - send it to view to show as default value
            // if(book.autoreorder == true){
            // redirecttoaction("ManualReorder", bp)


            return View(bp);
        }

        // POST: BookProcurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManualReorder([Bind("BookProcurementID,Quantity,Price")] BookProcurement bp)
        {
            BookProcurement DbBP = _context.BookProcurements.Include(b => b.Book).FirstOrDefault(b => b.BookProcurementID == bp.BookProcurementID);
            //if (book.AutoReorder == false)
            DbBP.Quantity = bp.Quantity;
            DbBP.Total = bp.Quantity * bp.Price;
            DbBP.ProcurementDate = System.DateTime.Today;
            DbBP.Book.Cost = bp.Price;
            DbBP.Book.LastOrdered = System.DateTime.Today;
            DbBP.Book.CopiesOnHand += bp.Quantity;

            //if (book.AutoReoder == true){
            //DbBP.Quantity = bp.Book.AutoReorderQuantity;
            //DbBP.Total = bp.Book.AutoReorderQuantity * bp.Book.AutoReorderPrice

            if (ModelState.IsValid)
            {
                _context.Update(DbBP);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: BookProcurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookProcurement = await _context.BookProcurements.FindAsync(id);
            if (bookProcurement == null)
            {
                return NotFound();
            }
            return View(bookProcurement);
        }

        // POST: BookProcurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookProcurementID,Subtotal,Total,Quantity,ProcurementDate,UserID")] BookProcurement bookProcurement)
        {
            if (id != bookProcurement.BookProcurementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookProcurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookProcurementExists(bookProcurement.BookProcurementID))
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
            return View(bookProcurement);
        }

        // GET: BookProcurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookProcurement = await _context.BookProcurements
                .FirstOrDefaultAsync(m => m.BookProcurementID == id);
            if (bookProcurement == null)
            {
                return NotFound();
            }

            return View(bookProcurement);
        }

        // POST: BookProcurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookProcurement = await _context.BookProcurements.FindAsync(id);
            _context.BookProcurements.Remove(bookProcurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookProcurementExists(int id)
        {
            return _context.BookProcurements.Any(e => e.BookProcurementID == id);
        }
    }
}
