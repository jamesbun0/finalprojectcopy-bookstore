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
    [Authorize]
    public class CartsController : Controller
    {
        private AppDbContext _context;

        public CartsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Carts
        public IActionResult Index()
        {

            List<Cart> Carts = new List<Cart>();
            if (User.IsInRole("Customer"))
            {
                Carts = _context.Carts.Include(c => c.CartDetails).Where(c => c.Customer.UserName == User.Identity.Name && c.Status == true).ToList();
            }



            return View(Carts);
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.Include(o => o.CartDetails)
                .ThenInclude(o => o.Book)
                .FirstOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        //// GET: Carts/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Carts/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CartID,OrderDate,OrderTotal,Shipping,Status")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cart);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cart);
        //}

        //GET: AddToCart
        //[Authorize(Roles = "Customer")]
        //public IActionResult AddToCart(int? id)
        public IActionResult AddToCart()
        {
            //check if bookid exists
            //if (id == null)
            //{
            //    return View("Error", new string[] { "Book does not exist" });
            //}


            //Find the book
            //Book book = _context.Books.Find(id);

            //store user's name
            //string userName = User.Identity.Name;
            //find the user in the database
            //AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            //find an uncompleted cart associated with the user
            //Cart cart = _context.Carts.Include(u => u.Customer).FirstOrDefault(u => u.Customer.UserID == user.UserID && u.Status == false);

            // if an uncompleted cart does not exist -> create a new cart for the user
            //if (cart == null)
            //{
            //create a new cart bc couldn't find an cart associated with that user
            //cart = new Cart() { Customer = user };               
            //_context.Carts.Add(cart);

            //_context.SaveChanges();

            //}


            //CartDetail od = new CartDetail() { Cart = cart , Book = book };
            //CartDetail od = new CartDetail();


            //_context.CartDetails.Add(od);
            //_context.SaveChanges();

            //od = _context.CartDetails.Include(o => o.Cart).FirstOrDefault(o => o.Cart.CartID == cart.CartID);


            //_context.SaveChanges();


            //return View("AddToCart", od);
            return View();
        }


        // POST: Cart/AddToCart/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult AddToCart([Bind("Quantity")]CartDetail od, int? id)
        public IActionResult AddToCart([Bind("CartDetailID, Quantity")] CartDetail cd, int? id)
        {
            //store user's name
            string userName = User.Identity.Name;
            //find the user in the database
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            //find an uncompleted cart associated with the user
            Cart cart = _context.Carts.Include(u => u.Customer).FirstOrDefault(u => u.Customer.UserID == user.UserID && u.Status == false);

            // if an uncompleted cart does not exist -> create a new cart for the user
            if (cart == null)
            {
                //create a new cart bc couldn't find an cart associated with that user
                cart = new Cart() { Customer = user, CartDate = System.DateTime.Today };
                _context.Carts.Add(cart);

                _context.SaveChanges();

            }

            //Find the book
            Book book = _context.Books.Find(id);

            //check if book is in stock
            if (book.CopiesOnHand < 1)
            {
                return View("Error", new String[] { "This book is out of stock" });
            }            

            //check if book is still active - still for sale
            //if (book.Active == false)
            //{
                //return View("Error", new String[] { "This book is no longer for sale" });
            //}

            //check if book already exists in cart
            foreach(CartDetail cdb in cart.CartDetails)
            {
                if(cdb.Book.BookID == id)
                {
                    return View("Error", new String[] { "This book already is in your cart." });
                }
            }

            CartDetail orderdetail = new CartDetail() { Cart = cart, Book = book };
            //od.Cart = cart;
            //od.Book = book;

            ////updating prop for cartdetails
            orderdetail.Quantity = cd.Quantity;
            orderdetail.Title = book.Title;
            orderdetail.Price = book.Price;
            orderdetail.ExtendedPrice = cd.Quantity * book.Price;
            orderdetail.CustomerName = user.FirstName + " " + user.LastName;           
            orderdetail.TotalCost = book.Cost * cd.Quantity;

            //update prop for carts
            orderdetail.Cart.CustomerName = user.FirstName + " " + user.LastName;
            //orderdetail.Cart.TotalQuantity += cd.Quantity;





            if (ModelState.IsValid)
            {
                _context.CartDetails.Add(orderdetail);
                _context.SaveChanges();
                _context.Update(orderdetail);
                return RedirectToAction("Details", new { id = orderdetail.Cart.CartID });
            }

            //ViewBag.AllProducts = GetAllBooks();
            return View(orderdetail);
        }


        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);*/

            if (id == null)
            {
                return NotFound();
            }

            var cart = _context.Carts
                                       .Include(r => r.CartDetails)
                                       .ThenInclude(r => r.Book)
                                       .FirstOrDefault(r => r.CartID == id);

            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cart cart)
        {
            if (id != cart.CartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(cart.CartID))
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
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .FirstOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Carts.Any(e => e.CartID == id);
        }

        private SelectList GetAllBooks()
        {
            List<Book> Books = _context.Books.ToList();
            SelectList allBooks = new SelectList(Books, "BookID", "Title");
            return allBooks;
        }

        //GET: CHECKOUT
        //public IActionResult Checkout(int? id)
        public IActionResult Checkout()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //store user's name
            string userName = User.Identity.Name;
            //find the user in the database
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            //find an uncompleted cart associated with the user
            Cart cart = _context.Carts.Include(u => u.Customer).Include(u => u.CartDetails).ThenInclude(c => c.Book).FirstOrDefault(u => u.Customer.UserID == user.UserID && u.Status == false);

            if (cart == null)
            {
                return View("Error", new String[] { "There are no items in your shopping cart" });
            }

            //create viewbag variable for creditcards of user
            ViewBag.CreditCards = GetAllCreditCards();

            return View(cart);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: CHECKOUT
        public IActionResult Checkout(int SelectedCreditCard, String CouponTypeString)
        {
            //store user's name
            string userName = User.Identity.Name;
            //find the user in the database
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            //find an uncompleted cart associated with the user
            Cart cart = _context.Carts.Include(u => u.Customer).Include(u => u.CartDetails).ThenInclude(u => u.Book).FirstOrDefault(u => u.Customer.UserID == user.UserID && u.Status == false);           

            if (cart == null)
            {
                return View("Error", new string[] { "Shopping Cart is empty." });
            }

            if (SelectedCreditCard == 0)
            {
                return View("Error", new String[] { "Please input your payment method." });
            }



            List<CartDetail> cartdetails = new List<CartDetail>();
            cartdetails = cart.CartDetails;
            foreach (CartDetail cd in cartdetails)
            {
                cd.Book.CopiesOnHand = cd.Book.CopiesOnHand - cd.Quantity;
                cd.Book.CopiesSold += 1;
                //cd.Book.TotalRevenue += cd.Quantity * cd.Price;

                //update prop for carts
                cd.Cart.TotalQuantity += cd.Quantity;

                //
                //update prop for users
                user.AmountOfRevenue += cd.Cart.CartTotal;
                user.TotalBooksPurchased += cd.Quantity;
            }



            //fix credit card update stuff
            cart.CreditCard = _context.CreditCards.FirstOrDefault(c => c.CreditCardID == SelectedCreditCard);

            if (CouponTypeString != null)
            {
                cart.Coupon.CouponType = CouponTypeString;
            }
            cart.CartDate = System.DateTime.Today;

            _context.SaveChanges();
            _context.Update(cart);


            //code for sending email to customers after placing an order
            //string toEmailAddress = user.Email;
            //string emailSubject = ("Thank You For Your Order!");
            //string emailBody = ("Here are the details from your order!: " + 
            //string emailBody = ("We also recommend you check out these books: " + GenerateBookRecommendations);

            //EmailMessaging.SendEmail(toEmailAddress, emailSubject, emailBody);


            //return View("Index");
            return RedirectToAction("PlaceOrder");
            //RedirectToAction("PlaceOrder")
            //place cart should only change the cart from pending to complete
        }

        public IActionResult ConfirmOrder()
        {
            return View();
        }

        public IActionResult ApplyCoupon (String CreditCardString, String CouponTypeString)
        {
            return RedirectToAction("Checkout", CreditCardString, CouponTypeString);
        }

        public IActionResult PlaceOrder()
        {
            //store user's name
            string userName = User.Identity.Name;
            //find the user in the database
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            //find an uncompleted cart associated with the user
            Cart cart = _context.Carts.Include(u => u.Customer).FirstOrDefault(u => u.Customer.UserID == user.UserID && u.Status == false);

            cart.Status = true;
           


            _context.SaveChanges();
            _context.Update(cart);

            return RedirectToAction("GetRecommendations", new {id = cart.CartID });
        }

        //public IActionResult OrderConfirmation(int? id)
        //{
        //    ViewBag.Recommendations = books;
        //    return View();
        //}

        public ActionResult GetRecommendations(int? id)
        {
            //Int32 num = id;
            //find the order based on the cartID
            //CartDetail cart = _context.CartDetails.Find(id);

            //create an empty list of orderdetails
            List<CartDetail> details = _context.CartDetails.Include(c => c.Cart).Include(c => c.Book).ThenInclude(c => c.Genre).Where(c => c.Cart.CartID == id).ToList();

            List<CartDetail> emptycartdetails = new List<CartDetail>();
            List<Book> orderedBooks = new List<Book>();
            //populate the list with the details of the order that we found
            foreach (CartDetail cartdetail in details)
            {
                emptycartdetails.Add(cartdetail);
                orderedBooks.Add(cartdetail.Book);
            }



            //pull the first book in cart details
            //Book book1 = orderedBooks.First();
            Book book1 = orderedBooks[0];

            //create other lists to hold other things
            //the list we actually return will be RecommendedBooks
            List<Book> RecommendedBooks = new List<Book>();
            List<Book> List1 = new List<Book>();
            List<Book> List2 = new List<Book>();

            //var query = from b in _context.Books select b;
            //var query2 = from b in _context.Books select b;

            //query to find book that has same author and genre as the first book in orderedbooks list
            //query = query.Where(b => b.Author == book1.Author && b.Genre.GenreName == book1.Genre.GenreName);

            //add to list1
            //List1 = query.ToList();
            List1 = _context.Books.Include( b => b.Genre).Where(b => b.Author == book1.Author && b.Genre.GenreName == book1.Genre.GenreName).ToList();

            //list2 is same genre and highest rating to lowest rating

            //List2 = _context.Books.Include(b => b.Genre).Where(b => b.Genre.GenreName == book1.Genre.GenreName).OrderByDescending(b => b.AvgRating).ToList();
            List2 = _context.Books.Include(b => b.Genre).Where(b => b.Genre.GenreName == book1.Genre.GenreName).ToList();
            //add to list
            //List2 = query2.ToList();

            if (List1.Count == 0)
            {
                int countBooks = 0;
                while (countBooks < 3)
                {
                    foreach (Book book in List2)
                    {
                        RecommendedBooks.Add(book);
                        countBooks += 1;
                    }
                }

            }
            else
            {
                int countBooks = List1.Count();
                if (countBooks >= 3)
                {
                    RecommendedBooks.Add(List1[0]);
                    RecommendedBooks.Add(List1[1]);
                    RecommendedBooks.Add(List1[2]);
                }
                else if(countBooks == 1)
                 {

                    RecommendedBooks.Add(List1[0]);
                    RecommendedBooks.Add(List2[0]);
                    RecommendedBooks.Add(List2[1]);
                    
                 }

                else if (countBooks == 2)
                    {
                        RecommendedBooks.Add(List1[0]);
                        RecommendedBooks.Add(List1[1]);
                        RecommendedBooks.Add(List2[0]);
                    }

                }

            List<string> dab = new List<string> { RecommendedBooks[0].Title, RecommendedBooks[1].Title, RecommendedBooks[2].Title };
            ViewBag.Recommendations = dab;
            return View("OrderConfirmation");


        }



        private SelectList GetAllCreditCards()
        {
            //store user's name
            string userName = User.Identity.Name;
            //find the user in the database
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            var creditcards = _context.CreditCards.Include(c => c.Customer).Where(c => c.Customer.UserID == user.UserID).ToList();
            SelectList allCreditcards = new SelectList(creditcards, "CreditCardID", "CreditCardNumber");
            return allCreditcards;
        }
    }
}

//hi