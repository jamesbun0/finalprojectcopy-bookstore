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
    public class CartDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public CartDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CartDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CartDetails.ToListAsync());
        }

        // GET: CartDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartDetail = await _context.CartDetails
                .FirstOrDefaultAsync(m => m.CartDetailID == id);
            if (cartDetail == null)
            {
                return NotFound();
            }

            return View(cartDetail);
        }

        // GET: CartDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartDetailID,Title,Price,Quantity,ExtendedPrice")] CartDetail cartDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartDetail);
        }

        // GET: CartDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartDetail = await _context.CartDetails.FindAsync(id);
            if (cartDetail == null)
            {
                return NotFound();
            }
            return View(cartDetail);
        }

        // POST: CartDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartDetailID,Title,Price,Quantity,ExtendedPrice")] CartDetail cartDetail)
        {
            if (id != cartDetail.CartDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartDetailExists(cartDetail.CartDetailID))
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
            return View(cartDetail);
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CartDetail cartDetail)
        {
            //Find the related registration detail in the database
            CartDetail DbCartDetail = _context.CartDetails
                                        .Include(r => r.Book)
                                        .Include(r => r.Cart)
                                        .FirstOrDefault(r => r.CartDetailID ==
                                                            cartDetail.CartDetailID);

            //update the related fields
            DbCartDetail.Quantity = cartDetail.Quantity;
            DbCartDetail.Book.Price = DbCartDetail.Book.Price;
            DbCartDetail.ExtendedPrice = DbCartDetail.Book.Price * DbCartDetail.Quantity;

            //update the database
            if (ModelState.IsValid)
            {
                _context.CartDetails.Update(DbCartDetail);
                _context.SaveChanges();
                //changed to Detail
                return RedirectToAction("Details", "Carts", new { id = DbCartDetail.Cart.CartID });
            }


            //return to the cart details
            return View(cartDetail);

        }

        // GET: CartDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartDetail = await _context.CartDetails
                .FirstOrDefaultAsync(m => m.CartDetailID == id);
            if (cartDetail == null)
            {
                return NotFound();
            }

            return View(cartDetail);
        }

        // POST: CartDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var cartDetail = await _context.CartDetails.FindAsync(id);
            _context.CartDetails.Remove(cartDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/

            var cartDetail = await _context.CartDetails.FindAsync(id);
            _context.CartDetails.Remove(cartDetail);
            await _context.SaveChangesAsync();
            Cart ord = _context.Carts.FirstOrDefault(r => r.CartDetails.Any(rd => rd.CartDetailID == id));
            if (ord == null)
            {
                return View();
            }

            //was Details
            return RedirectToAction("Details", "Cart", new { id = ord.CartID });
        }

        private bool CartDetailExists(int id)
        {
            return _context.CartDetails.Any(e => e.CartDetailID == id);
        }
    }
}
