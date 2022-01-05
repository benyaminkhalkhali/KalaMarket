using KalaMarket.DataLayer.Entities;
using KalaMarket.DataLayer.Entities.Address;
using KalaMarket.DataLayer.Entities.Discount;
using KalaMarket.DataLayer.Entities.ProductEntities;
using KalaMarket.DataLayer.Entities.ProductEntities.FAQ;
using KalaMarket.DataLayer.Entities.Role;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Context
{
    public class KalaMarketContext:DbContext
    {
        public KalaMarketContext(DbContextOptions <KalaMarketContext> options) : base(options)
        {

        }
        public DbSet<MainSlider> mainSliders { get; set; }
        public DbSet<User> users { get; set; }
        

        #region FAQ
        public DbSet<Answer> answers { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Question> questions { get; set; }
        #endregion

        #region Product
        public DbSet<Brand> brands { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductColor> productColors { get; set; }
        public DbSet<ProductGallery> productGalleries { get; set; }
        public DbSet<ProductGuarantee> productGuarantees { get; set; }
        public DbSet<PropertyName> propertyNames { get; set; }
        public DbSet<PropertyName_Category> propertyName_Categories { get; set; }
        public DbSet<PropertyValue> propertyValues { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<ProductPrice> productPrices { get; set; }
        public DbSet<Favourite> favourites { get; set; }

        #endregion

        #region Address
        public DbSet<UserAddress> userAddresses { get; set; }
        #endregion

        #region Cart
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartDetail> cartDetails { get; set; }
        #endregion

        #region Discount
        public DbSet<Discount> discounts { get; set; }
        public DbSet<UserDiscount> userDiscounts { get; set; }
        #endregion

        #region Role

        public DbSet<Role> roles { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<RolePermission> rolePermissions { get; set; }
        public DbSet<UserRole> userRoles { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder); 
        }
    }
}
