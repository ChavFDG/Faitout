﻿// <auto-generated />
using System;
using Faitout.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Faitout.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Faitout.Data.Model.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CashRegisterVisible")
                        .HasColumnType("bit");

                    b.Property<bool>("ClientVisible")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EatInVatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TakeAwayVatId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EatInVatId");

                    b.HasIndex("ParentId");

                    b.HasIndex("TakeAwayVatId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Faitout.Data.Model.CompanyConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CartFixedFees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CartPercentageFees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("EnableDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("EnablePickUp")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMicro")
                        .HasColumnType("bit");

                    b.Property<decimal>("RestoTicketFixedFees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RestoTicketPercentageFees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("UseCard")
                        .HasColumnType("bit");

                    b.Property<bool>("UseRestoTicket")
                        .HasColumnType("bit");

                    b.Property<bool>("UseTax")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CompanyConfiguration");
                });

            modelBuilder.Entity("Faitout.Data.Model.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Faitout.Data.Model.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComplementaryInformations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAllergen")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOrganic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Faitout.Data.Model.IngredientRecipeQuantity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityUnity")
                        .HasColumnType("int");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("IngredientsRecipesQuantities");
                });

            modelBuilder.Entity("Faitout.Data.Model.IngredientTraceability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComplementaryInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductStockId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductStockId");

                    b.ToTable("IngredientsTraceabilities");
                });

            modelBuilder.Entity("Faitout.Data.Model.OpenedDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<bool>("EnableDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("EnablePickUp")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("OpenedDays");
                });

            modelBuilder.Entity("Faitout.Data.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderMode")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderModeDayAndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId1");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Faitout.Data.Model.OrderLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LineOrder")
                        .HasColumnType("int");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("Faitout.Data.Model.Payement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payements");
                });

            modelBuilder.Entity("Faitout.Data.Model.ProductStock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcatenatedPicturesNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentStock")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<bool>("EnableOnLine")
                        .HasColumnType("bit");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OnlinePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ProductStocks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ProductStock");
                });

            modelBuilder.Entity("Faitout.Data.Model.ProductTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("Faitout.Data.Model.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComplementaryInformations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Delevery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Faitout.Data.Model.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcatenatedPicturesNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OvenHumidity")
                        .HasColumnType("int");

                    b.Property<int>("OvenTemepature")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("OvenTime")
                        .HasColumnType("time");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Steps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UseOven")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Faitout.Data.Model.RecipeTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("TagId");

                    b.ToTable("RecipesTags");
                });

            modelBuilder.Entity("Faitout.Data.Model.StockMove", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductStockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductStockId");

                    b.HasIndex("ProviderId");

                    b.ToTable("StocksMoves");
                });

            modelBuilder.Entity("Faitout.Data.Model.SubIngredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComplementaryInformations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAllergen")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOrganic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("SubIngredients");
                });

            modelBuilder.Entity("Faitout.Data.Model.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Faitout.Data.Model.TimeRange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("From")
                        .HasColumnType("time");

                    b.Property<int>("OpenType")
                        .HasColumnType("int");

                    b.Property<Guid>("OpenedDayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("To")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("OpenedDayId");

                    b.ToTable("TimeRange");
                });

            modelBuilder.Entity("Faitout.Data.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disable")
                        .HasColumnType("bit");

                    b.Property<string>("DisableReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Token")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Faitout.Data.Model.VAT", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.ToTable("VATs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Faitout.Data.Model.Deposit", b =>
                {
                    b.HasBaseType("Faitout.Data.Model.ProductStock");

                    b.HasDiscriminator().HasValue("Deposit");
                });

            modelBuilder.Entity("Faitout.Data.Model.Product", b =>
                {
                    b.HasBaseType("Faitout.Data.Model.ProductStock");

                    b.Property<string>("BatchNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DLC")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepositId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasNetWeight")
                        .HasColumnType("bit");

                    b.Property<int>("InitialStock")
                        .HasColumnType("int");

                    b.Property<int>("NetWeight")
                        .HasColumnType("int");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ToSell")
                        .HasColumnType("bit");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DepositId");

                    b.HasIndex("RecipeId");

                    b.HasDiscriminator().HasValue("Product");
                });

            modelBuilder.Entity("Faitout.Data.Model.Category", b =>
                {
                    b.HasOne("Faitout.Data.Model.VAT", "EatInVat")
                        .WithMany("EatInCategories")
                        .HasForeignKey("EatInVatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Faitout.Data.Model.Category", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Faitout.Data.Model.VAT", "TakeAwayVat")
                        .WithMany("TakeAwayCategories")
                        .HasForeignKey("TakeAwayVatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.Discount", b =>
                {
                    b.HasOne("Faitout.Data.Model.Order", "Order")
                        .WithMany("Discounts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.IngredientRecipeQuantity", b =>
                {
                    b.HasOne("Faitout.Data.Model.Ingredient", "Ingredient")
                        .WithMany("IngredientRecipeQuantity")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faitout.Data.Model.Recipe", "Recipe")
                        .WithMany("IngredientRecipeQuantity")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.IngredientTraceability", b =>
                {
                    b.HasOne("Faitout.Data.Model.ProductStock", "ProductStock")
                        .WithMany("Traceability")
                        .HasForeignKey("ProductStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.Order", b =>
                {
                    b.HasOne("Faitout.Data.Model.Order", null)
                        .WithMany("Orders")
                        .HasForeignKey("OrderId1");

                    b.HasOne("Faitout.Data.Model.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Faitout.Data.Model.OrderLine", b =>
                {
                    b.HasOne("Faitout.Data.Model.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.Payement", b =>
                {
                    b.HasOne("Faitout.Data.Model.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.ProductTag", b =>
                {
                    b.HasOne("Faitout.Data.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faitout.Data.Model.Tag", "Tag")
                        .WithMany("ProductTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.RecipeTag", b =>
                {
                    b.HasOne("Faitout.Data.Model.Product", null)
                        .WithMany("RecipesTags")
                        .HasForeignKey("ProductId");

                    b.HasOne("Faitout.Data.Model.Recipe", "Recipe")
                        .WithMany("RecipesTags")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faitout.Data.Model.Tag", "Tag")
                        .WithMany("RecipesTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.StockMove", b =>
                {
                    b.HasOne("Faitout.Data.Model.ProductStock", "ProductStock")
                        .WithMany()
                        .HasForeignKey("ProductStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faitout.Data.Model.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.SubIngredient", b =>
                {
                    b.HasOne("Faitout.Data.Model.Ingredient", "Parent")
                        .WithMany("ChildsIngredients")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.TimeRange", b =>
                {
                    b.HasOne("Faitout.Data.Model.OpenedDay", "OpenedDay")
                        .WithMany("TimeRanges")
                        .HasForeignKey("OpenedDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Faitout.Data.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Faitout.Data.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faitout.Data.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Faitout.Data.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Faitout.Data.Model.Product", b =>
                {
                    b.HasOne("Faitout.Data.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Faitout.Data.Model.Deposit", "Deposit")
                        .WithMany("Products")
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Faitout.Data.Model.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
