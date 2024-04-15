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
                ClassroomId = Guid.Parse("632BC679-3CC2-45B7-971B-6A92105321DE"),
                ParentGuardianContact = "+1987654321",
                ParentGuardianId = Guid.Parse("BBFE1B04-2741-4440-9334-595CB40A9F64"),
            };
            children.Add(new Child()
            {
                FirstName = "Luna",
                LastName = "Little",
                DateOfBirth = DateTime.ParseExact("05/05/2020 10:15", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 4,
                Gender = "female",
                ImageUrl = "https://img.freepik.com/premium-photo/smiling-baby-girl-3-4-year-old-wearing-knitted-red-sweater-posing-nature-background-close-up-looking-camera-childhood-autumn-season_260913-2064.jpg",
                ClassroomId = Guid.Parse("632BC679-3CC2-45B7-971B-6A92105321DE"),
                ParentGuardianContact = "+1987654321",
                ParentGuardianId = Guid.Parse("BBFE1B04-2741-4440-9334-595CB40A9F64"),
            });

            children.Add(child);

            children.Add(new Child()
            {
                FirstName = "Leo",
                LastName = "Doodle",
                DateOfBirth = DateTime.ParseExact("10/03/2020 19:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 4,
                Gender = "male",
                ImageUrl = "https://www.shutterstock.com/image-photo/happy-five-year-old-european-600nw-278349572.jpg",
                ClassroomId = Guid.Parse("958B5667-9055-40A7-B7B2-81C19AFE3329"),
                ParentGuardianContact = "+1234567890",
                ParentGuardianId = Guid.Parse("B785B0D0-3D8C-4C37-A304-E2C41DCAB31A")
            });

            children.Add(new Child()
            {
                FirstName = "Mila",
                LastName = "Doodle",
                DateOfBirth = DateTime.ParseExact("15/06/2019 14:45", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 5,
                Gender = "female",
                ImageUrl = "https://people.com/thmb/PUJBCZ6e6-0hakU8up3vt6TJkZE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(749x0:751x2)/Imi-Schneider4-f5ffc7e6f4d948fb9e40d9c788acc71c.jpg",
                ClassroomId = Guid.Parse("958B5667-9055-40A7-B7B2-81C19AFE3329"),
                ParentGuardianContact = "+1234567890",
                ParentGuardianId = Guid.Parse("B785B0D0-3D8C-4C37-A304-E2C41DCAB31A")
            });

            child = new Child()
            {
                FirstName = "Emma",
                LastName = "Malinkova",
                DateOfBirth = DateTime.ParseExact("10/03/2020 19:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 4,
                Gender = "female",
                ImageUrl = "https://previews.123rf.com/images/mashiki/mashiki1802/mashiki180200333/96303002-close-up-indoor-portrait-of-cute-happy-2-years-old-baby-girl-in-pink-sweater.jpg",
                ClassroomId = Guid.Parse("958B5667-9055-40A7-B7B2-81C19AFE3329"),
                ParentGuardianContact = "+1234567890",
                ParentGuardianId = Guid.Parse("B785B0D0-3D8C-4C37-A304-E2C41DCAB31A")
            };

            children.Add(child);

            children.Add(new Child()
            {
                FirstName = "Ethan",
                LastName = "Mathews",
                DateOfBirth = DateTime.ParseExact("20/01/2018 09:30", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 6,
                Gender = "male",
                ImageUrl = "https://cdn.cdnparenting.com/articles/2018/08/643990666-H.webp",
                ClassroomId = Guid.Parse("C12F8035-D854-4CDC-BAD7-489237B10FDF"),
                ParentGuardianContact = "+1122334455",
                ParentGuardianId = Guid.Parse("73690111-8CDC-4E37-91C2-143C674F324F")
            });

            children.Add(new Child()
            {
                FirstName = "Ava",
                LastName = "Mathews",
                DateOfBirth = DateTime.ParseExact("25/04/2017 11:45", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 7,
                Gender = "female",
                ImageUrl = "https://images.fineartamerica.com/images/artworkimages/mediumlarge/1/portrait-of-a-girl-seven-years-old-with-blond-hair-and-white-dress-elena-saulich.jpg",
                ClassroomId = Guid.Parse("C12F8035-D854-4CDC-BAD7-489237B10FDF"),
                ParentGuardianContact = "+1122334455",
                ParentGuardianId = Guid.Parse("73690111-8CDC-4E37-91C2-143C674F324F")
            });

            children.Add(new Child()
            {
                FirstName = "Oliver",
                LastName = "Techton",
                DateOfBirth = DateTime.ParseExact("12/08/2013 13:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 10,
                Gender = "male",
                ImageUrl = "https://www.telegram.com/gcdn/authoring/2019/10/21/NTEG/ghows-WT-955ebf6b-6734-21c5-e053-0100007f81d9-9950fec9.jpeg",
                ClassroomId = Guid.Parse("4FAA63AB-F5F8-45AE-BDC4-2EB42CA9B266"),
                ParentGuardianContact = "+9988776655",
                ParentGuardianId = Guid.Parse("C3010F38-EC8B-4C80-9599-E8FDADA9299F")
            });

            children.Add(new Child()
            {
                FirstName = "Sophie",
                LastName = "Techton",
                DateOfBirth = DateTime.ParseExact("08/11/2012 15:30", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                Age = 11,
                Gender = "female",
                ImageUrl = "https://media.istockphoto.com/id/1035407268/photo/portrait-of-beautiful-girl-of-10-11-years-old-child-with-perfect-white-smile-isolated-on.jpg?s=612x612&w=0&k=20&c=wW_X1ZqF-i5acks0o_nSaL3yuDQgxIhmbCyXXUMMIBE=",
                ClassroomId = Guid.Parse("4FAA63AB-F5F8-45AE-BDC4-2EB42CA9B266"),
                ParentGuardianContact = "+9988776655",
                ParentGuardianId = Guid.Parse("C3010F38-EC8B-4C80-9599-E8FDADA9299F")
            });

            return children.ToArray();
        }
    }
}
