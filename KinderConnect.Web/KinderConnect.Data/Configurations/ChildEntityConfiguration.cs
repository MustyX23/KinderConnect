using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace KinderConnect.Data.Configurations
{
    public class ChildEntityConfiguration : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder
                .Property(c => c.IsActive)
                .HasDefaultValue(true);

            builder.HasData(GenerateChildren());
        }

        private Child[] GenerateChildren()
        {
            ICollection<Child> children = new HashSet<Child>();

            Child child;

            child = new Child()
            {
                FirstName = "Chicken",
                LastName = "Little",
                DateOfBirth = DateTime.ParseExact("03/03/2021 18:30", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 3,
                Gender = "male",
                ImageUrl = "https://onebighappyphoto.com/wp-content/uploads/2-year-old-boy-and-family-photoshoot-2951-One-Big-Happy-Photo.jpg",
                ClassroomId = Guid.Parse("632bc679-3cc2-45b7-971b-6a92105321de"),
                ParentGuardianContact = "+1987654321",
                ParentGuardianId = Guid.Parse("BBFE1B04-2741-4440-9334-595CB40A9F64"),
            };

            children.Add(child);

            child = new Child()
            {
                FirstName = "Emma",
                LastName = "Malinkova",
                DateOfBirth = DateTime.ParseExact("10/03/2020 19:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 4,
                Gender = "female",
                ImageUrl = "https://previews.123rf.com/images/mashiki/mashiki1802/mashiki180200333/96303002-close-up-indoor-portrait-of-cute-happy-2-years-old-baby-girl-in-pink-sweater.jpg",
                ClassroomId = Guid.Parse("958b5667-9055-40a7-b7b2-81c19afe3329"),
                ParentGuardianContact = "+1234567890",
                ParentGuardianId = Guid.Parse("B785B0D0-3D8C-4C37-A304-E2C41DCAB31A")
            };

            children.Add(child);

            return children.ToArray();
        }
    }
}
