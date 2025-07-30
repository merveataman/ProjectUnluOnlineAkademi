using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Entities;

namespace UnluOnlineAkademi.Persistence.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<EducationalContent> EducationalContents { get; set; }
        public DbSet<StudentTestimonial> StudentTestimonials { get; set; }
        public DbSet<Achievements> Achievements { get; set; }
        public DbSet<WhyUs> WhyUs { get; set; }
        public DbSet<MailList> MailLists { get; set; }
        public DbSet<Policies> Policies { get; set; }
        public DbSet<CourseLessons> CourseLessons { get; set; }
        public DbSet<CourseCategoryLessons> CourseCategoryLessons { get; set; }
        public DbSet<ContactOptions> ContactOptions { get; set; }
        public DbSet<ContactInfos> ContactInfos { get; set; }
        public DbSet<ContactOptionInfos> ContactOptionInfos { get; set; }
        public DbSet<SSS> SSS { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        //public DbSet<HomeSection> HomeSections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<CourseCategory>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<EducationalContent>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<StudentTestimonial>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Achievements>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<WhyUs>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<MailList>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Policies>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<CourseLessons>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ContactOptions>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ContactInfos>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<SSS>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<AboutUs>().HasQueryFilter(x => !x.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.ID = Guid.NewGuid();
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
