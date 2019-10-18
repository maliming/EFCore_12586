using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Data
{

    public class TestEntity
    {
        public int AppId { get; set; }

        public string Name { get; set; }

        public List<TestEntityChildren> Children { get; set; }

    }

    public class TestEntityChildren
    {
        public int AppId { get; set; }

        public string Name { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<TestEntityChildren> TestEntityChildren { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TestEntity>(entity =>
            {
                entity.HasKey(x => new {x.AppId, x.Name});
                entity.Property(x => x.Name).HasMaxLength(10).IsRequired();

                entity.HasMany(x => x.Children).WithOne().HasForeignKey(x => new { x.AppId, x.Name }).IsRequired();
            });

            builder.Entity<TestEntityChildren>(entity =>
            {
                entity.HasKey(x => new { x.AppId, x.Name });
                entity.Property(x => x.Name).HasMaxLength(10).IsRequired();
            });
        }
    }
}
