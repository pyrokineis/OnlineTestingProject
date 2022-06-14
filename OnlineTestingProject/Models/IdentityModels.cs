using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.EntityFramework;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
    
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            //: base("SQLServer", throwIfV1Schema: false)
                        : base("DefaultConnection", throwIfV1Schema: false)
        { }
        //public ApplicationDbContext()
        //    : base("MySQL_DB", throwIfV1Schema: false)
        //{ }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UsersInGroup> UsersInGroups { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<QuestionsInTest> QuestionsInTests { get; set; }
        public DbSet<TestAssignedGroup> TestAssignedGroups { get; set; }
        public DbSet<TestAssignedUser> TestAssignedUsers { get; set; }
        public DbSet<AnswersOption> AnswersOptions { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        

        //protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<IdentityUser>().ToTable("aspnetusers");
        //    modelBuilder.Entity<IdentityRole>().ToTable("aspnetroles");
        //    modelBuilder.Entity<IdentityUserRole>().ToTable("aspnetuserroles");
        //    modelBuilder.Entity<IdentityUserLogin>().ToTable("aspnetuserlogins");
        //    modelBuilder.Entity<IdentityUserClaim>().ToTable("aspnetuserclaims");  
        //}
        }
}