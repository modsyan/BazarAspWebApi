using Bazar.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bazar.Core.Configurations;

public static class EntityConfigurationRegistrar
{
    public static void ApplyConfiguration(ModelBuilder modelBuilder)
    {
        // new AddressEntityTypeConfiguration().Configure(modelBuilder.Entity<Address>());
        
        // new CartEntityTypeConfiguration().Configure(modelBuilder.Entity<Cart>());
        new CartItemConfiguration().Configure(modelBuilder.Entity<CartItem>());
        
        // new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
        
        // new FaqEntityTypeConfiguration().Configure(modelBuilder.Entity<Faq>());
        
        new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderItemConfiguration().Configure(modelBuilder.Entity<OrderItem>());
        
        // new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());
        // new ProductImageEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductImage>());
        
        new ReviewConfiguration().Configure(modelBuilder.Entity<Review>());
        new ReviewReplyConfiguration().Configure(modelBuilder.Entity<ReviewReply>());
        
        new CommentConfiguration().Configure(modelBuilder.Entity<Comment>());
        new CommentReplyConfiguration().Configure(modelBuilder.Entity<CommentReply>());
        
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        
        new BlockConfiguration().Configure(modelBuilder.Entity<Block>());
        new PostConfiguration().Configure(modelBuilder.Entity<Post>());
        new VendorConfiguration().Configure(modelBuilder.Entity<Vendor>());
        new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
    }
}