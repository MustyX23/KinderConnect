using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KinderConnect.Data.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(u => u.IsActive)
                .HasDefaultValue(true);

            builder.HasData(GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

            ApplicationUser user;

            user = new ApplicationUser()
            {
                Id = Guid.Parse("702DE3DD-C1E7-4F40-9131-623AADB7E765"),
                FirstName = "Lyubomir",
                LastName = "Popov",
                DateOfBirth = DateTime.Parse("1972/03/26"),
                Gender = "male",
                UserName = "Mr.Popov",
                NormalizedUserName = "MR.POPOV",
                Email = "mrpopov@gmail.com",
                NormalizedEmail = "MRPOPOV@gmail.com",
                PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            };

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = Guid.Parse("C3010F38-EC8B-4C80-9599-E8FDADA9299F"),
                FirstName = "Mustafa",
                LastName = "Buhov",
                UserName = "Mr.Buhov",
                DateOfBirth = DateTime.Parse("1971/3/26"),
                Gender = "male",
                NormalizedUserName = "MR.BUHOV",
                Email = "mrbuhov@gmail.com",
                NormalizedEmail = "MRBUHOV@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            };

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = Guid.Parse("BBFE1B04-2741-4440-9334-595CB40A9F64"),
                FirstName = "Father",
                LastName = "Mitev",
                UserName = "Parent1",
                DateOfBirth = DateTime.Parse("1990/4/13"),
                Gender = "male",
                NormalizedUserName = "PARENT1",
                Email = "parent1@gmail.com",
                NormalizedEmail = "PARENT1@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            };

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = Guid.Parse("B785B0D0-3D8C-4C37-A304-E2C41DCAB31A"),
                FirstName = "Mother",
                LastName = "Ivanova",
                DateOfBirth = DateTime.Parse("1992/4/13"),
                Gender = "female",
                UserName = "Parent2",
                NormalizedUserName = "PARENT2",
                Email = "parent2@gmail.com",
                NormalizedEmail = "PARENT2@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            };

            users.Add(user);

            user = new ApplicationUser()
            {
                FirstName = "Emily",
                LastName = "Cankova",
                UserName = "Parent3",
                DateOfBirth = DateTime.Parse("2000/2/10"),
                Gender = "female",
                NormalizedUserName = "PARENT3",
                Email = "parent3@gmail.com",
                NormalizedEmail = "PARENT3@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            };

            users.Add(user);

            return users.ToArray();
        }
    }
}
