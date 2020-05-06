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
        public DbSet<Category> Categories { get; set; }
        public DbSet<CompanyConfiguration> CompanyConfiguration { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientRecipeQuantity> IngredientsRecipesQuantities { get; set; }
        public DbSet<IngredientTraceability> IngredientsTraceabilities { get; set; }
        public DbSet<OpenedDay> OpenedDays { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Payement> Payements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeTag> RecipesTags { get; set; }
        public DbSet<StockMove> StocksMoves { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VAT> VATs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasOne(b => b.EatInVat)
                .WithMany(a=>a.EatInCategories)
                .OnDelete(DeleteBehavior.Restrict); 
            builder.Entity<Category>()
                .HasOne(b => b.TakeAwayVat)
                .WithMany(a => a.TakeAwayCategories)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RecipeTag>()
            .HasOne(rt => rt.Recipe)
            .WithMany(r => r.RecipesTags)
            .HasForeignKey(rt => rt.RecipeId);

            builder.Entity<RecipeTag>()
            .HasOne(rt => rt.Tag)
            .WithMany(t => t.RecipesTags)
            .HasForeignKey(rt => rt.TagId);

            builder.Entity<IngredientRecipeQuantity>()
            .HasOne(irq => irq.Ingredient)
            .WithMany(i => i.IngredientRecipeQuantity)
            .HasForeignKey(irq => irq.IngredientId);

            builder.Entity<IngredientRecipeQuantity>()
            .HasOne(r => r.Recipe)
            .WithMany(i => i.IngredientRecipeQuantity)
            .HasForeignKey(r => r.RecipeId);

            builder.Entity<Category>()
                        .HasOne(x => x.Parent)
                        .WithMany(x => x.Childs)
                        .HasForeignKey(x => x.ParentId)
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
            //Tax
            context.Add(new VAT() { Tax = 0 });
            context.Add(new VAT() { Tax = 0.055m });
            context.Add(new VAT() { Tax = 0.1m });
            context.Add(new VAT() { Tax = 0.2m});
            //Tags
            context.Add(new Tag() { Name = "Chaud" , Description ="Ce plat peut être consommé chaud", Color= "#ff3333" });
            context.Add(new Tag() { Name = "Froid", Description = "Ce plat peut être consommé froid", Color = "#3385ff" });
            context.Add(new Tag() { Name = "Carné", Description = "Contient de la viande", Color = "#ff0000" });
            context.Add(new Tag() { Name = "Végé", Description = "Ce plat est végétarien", Color = "#5cd65c" });
            context.Add(new Tag() { Name = "Vegan", Description = "Ce plat est végan", Color = "#adebad" });
            context.Add(new Tag() { Name = "0 lactose", Description = "Ce plat est sans lactose", Color = "#99c2ff" });
            context.Add(new Tag() { Name = "0 gluten", Description = "Ce plat est sans gluten", Color = "#ffd699" });
            context.Add(new Tag() { Name = "bio", Description = "Est issue de l'agriculture biologique", Color = "#33cc33" });
            context.Add(new Tag() { Name = "local", Description = "Est un produit local", Color = "#ff3333" });
            context.Add(new Tag() { Name = "Français", Description = "Produit Français par Toutatis !", Color = "#0066ff" });
            context.Add(new Tag() { Name = "Ardèche", Description = "Ardechio Merveillous Païs", Color = "#c2d6d6" });
            //Save
            context.SaveChanges();
        }
    }
}
