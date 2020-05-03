using System;
using System.Collections.Generic;
using System.Text;
using Faitout.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Faitout.Data
{
    //https://docs.microsoft.com/fr-fr/ef/core/managing-schemas/migrations/?tabs=vs
    //Add-Migration InitialCreate
    //Update-Database
    //Drop-Database
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<CompanyConfiguration> CompanyConfiguration { get; set; }
        public DbSet<OpenedDay> OpenedDays { get; set; }
        public DbSet<VAT> Taxes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientTraceability> IngredientsTraceabilities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<ProductStock> ProductStocks{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<ProductIngredientRawMaterial> ProductsIngredientsRawMaterials { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeTag> RecipesTags { get; set; }
        public DbSet<SubRawMaterialIngredient> SubRawMaterialsIngredients { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Payement> Payements { get; set; }
        public DbSet<StockMove> StocksMove { get; set; }
        public DbSet<Discount> Discounts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductIngredientRawMaterial>()
               .HasOne(b => b.Product)
               .WithMany(a => a.ProductsIngredientsRawMaterials)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductIngredientRawMaterial>()
                .HasOne(b => b.RawMaterial)
                .WithMany(a => a.ProductsIngredientsRawMaterials)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProductIngredientRawMaterial>()
                .HasOne(b => b.Ingredient)
                .WithMany(a => a.ProductsIngredientsRawMaterials)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>()
                .HasOne(b => b.EatInVat)
                .WithMany(a=>a.EatInCategories)
                .OnDelete(DeleteBehavior.Restrict); 
            builder.Entity<Category>()
                .HasOne(b => b.TakeAwayVat)
                .WithMany(a => a.TakeAwayCategories)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasOne(b => b.Deposit)
                .WithMany(a => a.Products)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public static void PopulateDataBase(ApplicationDbContext context)
        {
            //CompanyConfiguration
            CompanyConfiguration companyConfiguration = new CompanyConfiguration();
            context.CompanyConfiguration.Add(companyConfiguration);
            //OpenedDays
            context.Add(new OpenedDay(DayOfWeek.Monday));
            context.Add(new OpenedDay(DayOfWeek.Tuesday));
            context.Add(new OpenedDay(DayOfWeek.Wednesday));
            context.Add(new OpenedDay(DayOfWeek.Thursday));
            context.Add(new OpenedDay(DayOfWeek.Friday));
            context.Add(new OpenedDay(DayOfWeek.Saturday, false));
            context.Add(new OpenedDay(DayOfWeek.Sunday, false));
            context.SaveChanges();
            //Range
            foreach (var openedDay in context.OpenedDays)
            {
                context.Add(new TimeRange() { OpenedDay = openedDay, OpenType = OpenType.Open });
                context.Add(new TimeRange() { OpenedDay = openedDay, OpenType = OpenType.Delivery });
                context.Add(new TimeRange() { OpenedDay = openedDay, OpenType = OpenType.PickUp });
            }
            //Save
            context.SaveChanges();
        }
    }
}
