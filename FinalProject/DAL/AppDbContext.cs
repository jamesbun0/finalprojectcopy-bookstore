using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinalProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartDetail> CartDetails { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<BookProcurement> BookProcurements { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Review> Reviews { get; set; }

    }
}
