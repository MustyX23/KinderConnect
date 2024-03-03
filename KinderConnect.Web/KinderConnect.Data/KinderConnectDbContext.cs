using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KinderConnect.Data
{
    public class KinderConnectDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public KinderConnectDbContext(DbContextOptions<KinderConnectDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Child> Children { get; set; } = null!;
        public DbSet<Classroom> Classrooms { get; set; } = null!;
        public DbSet<Qualification> Qualifications { get; set; } = null!;
        public DbSet<TeacherQualification> TeachersQualifications { get; set; } = null!;
        public DbSet<ClassroomTeacher> ClassroomsTeachers { get; set; } = null!;
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(KinderConnectDbContext))
                ?? Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}
