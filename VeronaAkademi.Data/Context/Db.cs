using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Data.Entities;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Context
{
    public class Db : DbContext
    {
        public Db()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=*******;TrustServerCertificate=True;Database=*********;User Id=*********;Password=***********;");
        }

         public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<PersonelType> PersonelTip { get; set; }
        public virtual DbSet<Department> Departman { get; set; }
        public virtual DbSet<PersonelRestrictionRelation> PersonelKisitlamaRelation { get; set; }
        public virtual DbSet<Restriction> Kisitlama { get; set; }
        public virtual DbSet<RestrictionControllerAction> KisitlamaControllerAction { get; set; }
        public virtual DbSet<RestrictionUi> ArayuzKisitlama { get; set; }
        public virtual DbSet<RestrictionPersonelUi> PersonelArayuzKisitlama { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryGroup> CategoryGroup { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Customer> Customer{ get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<Profession> Profession { get; set; }
        public virtual DbSet<ProfessionCourseRelation> ProfessionCourseRelation { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SkillCourseRelation> SkillCourseRelation { get; set; }
        public virtual DbSet<SkillGroup> SkillGroup { get; set; }
        public virtual DbSet<Trailer> Trailer { get; set; }
        public virtual DbSet<LecturerCourseRelation> LecturerCourseRelation { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<CustomerCourseRelation> CustomerCourseRelation { get; set; }
        public virtual DbSet<CustomerLessonRelation> CustomerLessonRelation { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }

        public virtual DbSet<Advisor> Advisor { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PracticeLesson> PracticeLesson { get; set; }
        public virtual DbSet<AdvisorCourseRelation> AdvisorCourseRelation { get; set; }
        public virtual DbSet<PackageAdvisorRelation> PackageAdvisorRelation { get; set; }
        public virtual DbSet<PackageCourseRelation> PackageCourseRelation { get; set; }
        public virtual DbSet<PackagePracticeLessonRelation> PackagePracticeLessonRelation { get; set; }
        public virtual DbSet<PracticeLessonCourseRelation> PracticeLessonCourseRelation { get; set; }
        public virtual DbSet<CustomerAdvisorRelation> CustomerAdvisorRelation { get; set; }
        public virtual DbSet<CustomerPracticeLessonRelation> CustomerPracticeLessonRelation { get; set; }
        public virtual DbSet<CustomerPackageRelation> CustomerPackageRelation { get; set; }
        public virtual DbSet<PracticeLessonGallery> PracticeLessonGallery { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Message> Message { get; set; }

        public virtual DbSet<TestEntity> TestEntity { get; set; }
        public virtual DbSet<Test> Test { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.CategoryId);
                entity.Property(x => x.Name);
                entity.HasOne(x => x.Parent)
                    .WithMany(x => x.SubCategory)
                    .HasForeignKey(x => x.ParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

}
