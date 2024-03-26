using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KinderConnect.Data.Models;

namespace KinderConnect.Data.Configurations
{
    public class ClassroomEntityConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder
                .Property(c => c.IsActive)
                .HasDefaultValue(true);

            builder.HasData(GenerateClassrooms());
        }

        private Classroom[] GenerateClassrooms()
        {
            ICollection<Classroom> classrooms = new HashSet<Classroom>();

            Classroom classroom;

            classroom = new Classroom()
            {
                Id = Guid.Parse("632bc679-3cc2-45b7-971b-6a92105321de"),
                Name = "Little Explorers"
            };

            classrooms.Add(classroom);

            classroom = new Classroom()
            {
                Id = Guid.Parse("958b5667-9055-40a7-b7b2-81c19afe3329"),
                Name = "Doodle Den"
            };

            classrooms.Add(classroom);

            return classrooms.ToArray();
        }
    }
}
