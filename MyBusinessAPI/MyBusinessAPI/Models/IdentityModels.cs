using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace MyBusinessAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Attendence> Attendences { get; set; }
        public DbSet<CommunicationMessage> CommunicationMessages { get; set; }
        public DbSet<EventNotification> EventNotifications { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<SchoolEvent> SchoolEvents { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }
        public DbSet<StudentParentRelation> StudentParentRelations { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectExam> SubjectExams { get; set; }
        public DbSet<SubjectPeriod> SubjectPeriods { get; set; }
        public DbSet<SubjectTeacherStandardRelation> SubjectTeacherStandardRelations { get; set; }
        
    }

    //public class OwinAuthDbContext : IdentityDbContext
    //{
    //    public OwinAuthDbContext()
    //        : base("OwinAuthDbContext")
    //    {
    //    }
    //} 
}