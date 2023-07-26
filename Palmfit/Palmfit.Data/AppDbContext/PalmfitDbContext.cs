using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Data.AppDbContext
{
    public class PalmfitDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Health> Healths { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletHistory> WalletHistories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<FoodClass> FoodClasses { get; set; }
        public DbSet<Food> Foods { get; set; }
        public PalmfitDbContext(DbContextOptions<PalmfitDbContext> options) : base(options) 
        {

        }
    }
}
