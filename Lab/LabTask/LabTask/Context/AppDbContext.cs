using Microsoft.EntityFrameworkCore;

namespace LabTask.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SliderItem> SliderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SliderItem>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Offer)
                    .IsRequired()
                    .HasMaxLength(50); // Adjusted length according to your requirements

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(500);

                entity.Property(e => e.ImgPath)
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.LastModifiedDate)
                    .HasDefaultValueSql("GETDATE()");

                // DeletedDate is optional
                entity.Property(e => e.DeletedDate)
                    .IsRequired(false);
            });

        }
}
