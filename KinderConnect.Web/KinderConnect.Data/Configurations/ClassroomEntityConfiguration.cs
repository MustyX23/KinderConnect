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
                Name = "Little Explorers",
                Information = "Nature walks." +
                "Sensory play with natural materials." +
                "Learning about different animals and habitats." +
                "Creative storytelling sessions",
                MinimumAge = 0,
                MaximumAge = 3,
                TotalSeats = 25,
                TutionFee = 100,
                ImageUrl = "https://pbs.twimg.com/profile_images/557241923597914112/wuYMY-Sj_400x400.png"
            };

            classrooms.Add(classroom);

            classroom = new Classroom()
            {
                Id = Guid.Parse("958b5667-9055-40a7-b7b2-81c19afe3329"),
                Name = "Doodle Den",
                Information = "Art studio with easels and drawing tables." +
                "Variety of art supplies and materials." +
                "Display area for showcasing student artwork." +
                "Cozy reading corner for inspiration",
                MinimumAge = 3,
                MaximumAge = 6,
                TotalSeats = 25,
                TutionFee = 150,
                ImageUrl = "https://www.abnewswire.com/uploads/1692132999.jpeg"
            };

            classrooms.Add(classroom);

            return classrooms.ToArray();
        }
    }
}
