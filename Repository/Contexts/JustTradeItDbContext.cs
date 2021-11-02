using JustTradeIt.Software.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JustTradeIt.Software.API.Repositories.Contexts
{
    public class JustTradeItDbContext : DbContext
    {
        public JustTradeItDbContext(DbContextOptions<JustTradeItDbContext> options): base (options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>()
                .HasOne(m => m.SenderFk)
                .WithMany(u => u.SentTrades)
                .HasForeignKey(f => f.SenderId);
            modelBuilder.Entity<Trade>()
                .HasOne(m => m.ReceiverFk)
                .WithMany(u => u.ReceivedTrades)
                .HasForeignKey(f => f.ReceiverId);
            modelBuilder.Entity<TradeItem>()
                .HasKey(t => new {t.TradeId, t.UserId, t.ItemId});
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JwtToken> JwtTokens { get; set; }
        public DbSet<TradeItem> TradeItems { get; set; }
        public DbSet<ItemCondition> ItemConditions { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
    }
}