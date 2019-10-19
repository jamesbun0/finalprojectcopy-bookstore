using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public enum Filter {None, MostRecent, ProfitMarginA, ProfitMarginD, PriceA, PriceD, MostPopular, AmountofRevA,
                            AmountofRevB, EmployeeIDA, EmployeeIDD, AppReviewsA, AppReviewsD, RejReviewsA, RejReviewsD}
    //public enum MostRecentFilter { Ascending, Descending }
    //public enum ProfitMarginFilter { Ascending, Descending }
    //public enum PriceFilter { Ascending, Descending }
    //public enum MostPopularFilter { Ascending, Descending }
    //public enum AmountOfRevenueFilter { Ascending, Descending }
    //public enum EmployeeIDFilter { Ascending, Descending }
    //public enum ApprovedReviewsFilter { Ascending, Descending }
    //public enum RejectedReviewsFilter { Ascending, Descending }
    public enum TypeOfReport {None, AllBooksSold, AllOrders, AllCustomers, Totals, CurrentInventory, AppRejReviews}

    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //ViewBag.AllReports = GetAllReports();
            return View();
        }

        //public IActionResult ReportFilter(MostRecentFilter SelectedMostRecentFilter, ProfitMarginFilter SelectedProfitMarginFilter, PriceFilter SelectedPriceFilter,
        //MostPopularFilter SelectedMostPopularFilter, AmountOfRevenueFilter SelectedAmountOfRevenueFilter, EmployeeIDFilter SelectedEmployeeIDFilter , 
        //ApprovedReviewsFilter SelectedApprovedReviewsFilter, TypeOfReport SelectedTypeOfReport)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReportFilter(Filter SelectedFilter, TypeOfReport SelectedTypeOfReport)
        {
            // if they choose blank
            //return redirect to action to the corresponding method
            if(SelectedTypeOfReport == TypeOfReport.AllBooksSold)
            {
                return RedirectToAction("AllBooksSold", new { sf = SelectedFilter });
            }

            if (SelectedTypeOfReport == TypeOfReport.AllOrders)
            {
                return RedirectToAction("AllOrders", new { sf = SelectedFilter });
            }

            if (SelectedTypeOfReport == TypeOfReport.AllCustomers)
            {
                return RedirectToAction("AllCustomers", new { sf = SelectedFilter });
            }

            if (SelectedTypeOfReport == TypeOfReport.Totals)
            {
                return RedirectToAction("Totals", new { sf = SelectedFilter });
            }

            if (SelectedTypeOfReport == TypeOfReport.CurrentInventory)
            {
                return RedirectToAction("CurrentInventory", new { sf = SelectedFilter });
            }

            if (SelectedTypeOfReport == TypeOfReport.AppRejReviews)
            {
                return RedirectToAction("AppRejReviews", new { sf = SelectedFilter });
            }

            else {
                return View("Index");
            }
        }

        public IActionResult AllBooksSold(Filter sf)
        {
            List<CartDetail> SelectedCartDetails = new List<CartDetail>();
            SelectedCartDetails = _context.CartDetails.Include(c => c.Book).Include(c => c.Cart).ThenInclude(c => c.Customer).ToList();          
            //calculate avg weighted cost
            foreach (CartDetail cd in SelectedCartDetails)
            {
                Decimal WeightedAvgCost = (cd.Book.Cost * cd.Quantity) / cd.Quantity;
                cd.Book.AvgWeightedCost = WeightedAvgCost;
                cd.Book.ProfitMargin = (cd.Price * cd.Quantity) - cd.Book.AvgWeightedCost;
            }

            var query = from r in _context.CartDetails.Include(c => c.Book).Include(c => c.Cart).ThenInclude(c => c.Customer)
                        select r;

            if (sf == Filter.MostRecent)
            {
                SelectedCartDetails = query.OrderByDescending(b => b.Cart.CartID).ToList();
            }

            else if(sf == Filter.ProfitMarginA) 
            {
                SelectedCartDetails = query.OrderBy(b => b.Book.ProfitMargin).ToList();
            }


            else if(sf == Filter.ProfitMarginD)
            {
                SelectedCartDetails = query.OrderByDescending(b => b.Book.ProfitMargin).ToList();
            }

            else if (sf == Filter.PriceA)
            {
                SelectedCartDetails = query.OrderBy(b => b.Book.Price).ToList();
            }

            else if (sf == Filter.PriceD)
            {
                SelectedCartDetails = query.OrderByDescending(b => b.Book.Price).ToList();
            }

            else if(sf == Filter.MostPopular)
            {
                SelectedCartDetails = query.OrderBy(c => c.Book.CopiesSold).ToList();
            }

            else 
            {
                return View("Error", new String[] { "You can't sort the chosen filter." });
            }

            //SelectedCartDetails = query.Include(b => b.Cart).Include(b => b.Book).ToList();
            //SelectedCartDetails = query.ToList();

            ViewBag.SelectedCartDetails = SelectedCartDetails.Count();
            return View(SelectedCartDetails);    
        }

        public IActionResult AllOrders(Filter sf)
        {
            List<Cart> SelectedCarts = new List<Cart>();
            SelectedCarts = _context.Carts.Include(c => c.CartDetails).ThenInclude(c => c.Book).Include(c => c.Customer).ToList();           
            //calculate avg weighted cost
            foreach (Cart c in SelectedCarts)
            {
                Decimal CartWeightedAvgCost = 0;
                foreach (CartDetail cd in c.CartDetails)
                {
                    //CHANGE THIS!!!!!!!
                    //Decimal WeightedAvgCost = (cd.Book.Cost * cd.Quantity) / cd.Cart.TotalQuantity;
                    Decimal WeightedAvgCost = (cd.Book.Cost * cd.Quantity) / 1;
                    CartWeightedAvgCost += WeightedAvgCost;
                    //cd.Book.ProfitMargin = (cd.Price * cd.Quantity) - cd.Book.AvgWeightedCost;
                }
                c.AvgWeightedCost = CartWeightedAvgCost;
                c.ProfitMargin = c.CartTotal - c.AvgWeightedCost;
            }


            var query = from r in _context.Carts.Include(c => c.CartDetails).ThenInclude(c => c.Book).Include(c => c.Customer)
                        select r;

            if (sf == Filter.MostRecent)
            {
                SelectedCarts = query.OrderByDescending(b => b.CartID).ToList();
            }

            else if (sf == Filter.ProfitMarginA)
            {
                SelectedCarts = query.OrderBy(b => b.ProfitMargin).ToList();
            }

            else if (sf == Filter.ProfitMarginD)
            {
                SelectedCarts = query.OrderByDescending(b => b.ProfitMargin).ToList();
            }

            else if(sf == Filter.PriceA)
            {
                SelectedCarts = query.OrderBy(b => b.CartTotal).ToList();
            }

            else if(sf == Filter.PriceD)
            {
                SelectedCarts = query.OrderByDescending(b => b.CartTotal).ToList();
            }

            //SelectedCartDetails = query.Include(b => b.Cart).Include(b => b.Book).ToList();
            ViewBag.SelectedCarts = SelectedCarts.Count();
            return View(SelectedCarts);
        }

        public IActionResult AllCustomers(Filter sf)
        {
            List<AppUser> Customers = new List<AppUser>();
            Customers = _context.Users.Include(c => c.Carts).ThenInclude(c => c.CartDetails).ThenInclude(c => c.Book).ToList();
            //calculate avg weighted cost
            //foreach (CartDetail cd in SelectedCartDetails)
            //{
            //    Decimal WeightedAvgCost = (cd.Book.Cost * cd.Quantity) / cd.Quantity;
            //    cd.Book.AvgWeightedCost = WeightedAvgCost;
            //    cd.Book.ProfitMargin = (cd.Price * cd.Quantity) - cd.Book.AvgWeightedCost;
            //}
            foreach (AppUser cust in Customers)
            {
                //wrong
                Decimal UserWeightedAvgCost = 0m;
                foreach (Cart c in cust.Carts)
                {                   
                    foreach (CartDetail cd in c.CartDetails)
                    {
                        //CHANGE THIS!!!!!!!
                        //Decimal WeightedAvgCost = (cd.Book.Cost * cd.Quantity) / cd.Cart.TotalQuantity;
                        Decimal WeightedAvgCost = (cd.Book.Cost * cd.Quantity) / 1;
                        UserWeightedAvgCost += WeightedAvgCost;
                        //cd.Book.ProfitMargin = (cd.Price * cd.Quantity) - cd.Book.AvgWeightedCost;
                    }
                }
                cust.AvgWeightedCost = UserWeightedAvgCost;
                cust.ProfitMargin = cust.AmountOfRevenue - cust.AvgWeightedCost;
            }

            var query = from r in _context.Users.Include(c => c.Carts).ThenInclude(c => c.CartDetails).ThenInclude(c => c.Book)
                        select r;

            if (sf == Filter.ProfitMarginA)
            {
                Customers = query.OrderBy(b => b.ProfitMargin).ToList();
            }

            else if (sf == Filter.ProfitMarginD)
            {
                Customers = query.OrderByDescending(b => b.ProfitMargin).ToList();
            }

            else if (sf == Filter.AmountofRevA)
            {
                Customers = query.OrderBy(b => b.AmountOfRevenue).ToList();
            }

            else if (sf == Filter.AmountofRevB)
            {
                Customers = query.OrderByDescending(b => b.AmountOfRevenue).ToList();
            }

            //SelectedCartDetails = query.Include(b => b.Cart).Include(b => b.Book).ToList();
            ViewBag.SelectedCustomers = Customers.Count();
            return View(Customers);
        }

        public IActionResult Totals(Filter sf)
        {
            List<AppUser> Customers = new List<AppUser>();
            Customers = _context.Users.Include(c => c.Carts).ThenInclude(c => c.CartDetails).ThenInclude(c => c.Book).ToList();
           
            Decimal TotalCost = 0;
            Decimal TotalRevenue = 0;
            
            foreach(AppUser user in Customers)
            {
                TotalRevenue += user.AmountOfRevenue;
                TotalCost += user.AvgWeightedCost * user.TotalBooksPurchased;
            }

            Decimal TotalProfit = TotalRevenue - TotalCost;
            List<Decimal> totals = new List<Decimal> { TotalProfit, TotalRevenue, TotalCost };
            ViewBag.Totals = totals;
            return View();
        }

        public IActionResult CurrentInventory()
        {
            List<Book> SelectedBooks = new List<Book>();
            SelectedBooks = _context.Books.Include(c => c.CartDetails).ThenInclude(c => c.Cart).ThenInclude(c => c.Customer).ToList();

            List<Cart> AllCarts = new List<Cart>();

            //wrong - need to calculate the average book cost for each title
            Decimal TotalCostOfBooks = 0m;
            Int32 NumOfBooks = 0;
            foreach(Book b in SelectedBooks)
            {
                TotalCostOfBooks += b.Cost;
                NumOfBooks += 1;
            }

            Decimal AvgCostOfBooks = TotalCostOfBooks / NumOfBooks;
            decimal.Round(AvgCostOfBooks, 2, MidpointRounding.AwayFromZero);

            ViewBag.AvgCostOfBooks = AvgCostOfBooks; 
            ViewBag.SelectedBooks = SelectedBooks.Count();
        
            return View(SelectedBooks);
        }

        public IActionResult AppRejReviews(Filter sf)
        {
            List<AppUser> Employees = new List<AppUser>();
            Employees = _context.Users.Where(u => u.CreditCardNumber != null).ToList();

            var query = from r in _context.Users.Where(u => u.CreditCardNumber != null)
                        select r;

            if (sf == Filter.EmployeeIDA)
            {
                Employees = query.OrderBy(b => b.UserID).ToList();
            }

            else if (sf == Filter.AppReviewsA)
            {
                Employees = query.OrderBy(b => b.NumOfReviewsApp).ToList();
            }

            else if (sf == Filter.AppReviewsD)
            {
                Employees = query.OrderByDescending(b => b.NumOfReviewsApp).ToList();
            }

            else if (sf == Filter.RejReviewsA)
            {
                Employees = query.OrderBy(b => b.NumOfReviewsRej).ToList();
            }

            else if (sf == Filter.RejReviewsD)
            {
                Employees = query.OrderByDescending(b => b.NumOfReviewsRej).ToList();
            }
            ViewBag.SelectedUsers = Employees.Count();
            return View(Employees);
        }



        //private SelectList GetAllReports()
        //{
        //    List<String> allreports = new List<String>();
        //    allreports.Add("AllBooksSold");
        //    allreports.Add("AllOrders");
        //    allreports.Add("AllCustomers");
        //    allreports.Add("Totals");
        //    allreports.Add("CurrentInventory");
        //    allreports.Add("ApprovedReviews");

        //    SelectList reports = new SelectList(allreports);
        //}
    }
}