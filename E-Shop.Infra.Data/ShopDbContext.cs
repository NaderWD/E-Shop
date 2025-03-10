﻿using E_Shop.Domain.Models.ColorModels;
using E_Shop.Domain.Models.CommentModels;
using E_Shop.Domain.Models.ContactUsModels;
using E_Shop.Domain.Models.DiscountsModels;
using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.SpecificationModels;
using E_Shop.Domain.Models.TicketModels;
using E_Shop.Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;


namespace E_Shop.Infra.Data
{
    public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ContactUsMessage> ContactUsMessages { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }

        public DbSet<ColorModel> Color { get; set; }
        public DbSet<ProductColorMapping> ProductColorMapping { get; set; }

        public DbSet<Specification> Specifications { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<CategorySpecification> CategorySpecifications { get; set; }

        public DbSet<ProductGallery> ProductGallery { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Like> Likes { get; set; }         
        public DbSet<Evaluation> Evaluations { get; set; }

        public DbSet<Discount> Discounts { get; set; }   
        
        public DbSet<DiscountProductMapping> DiscountProductMapping { get; set; }   


    }
}
