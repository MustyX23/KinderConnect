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

            //user = new ApplicationUser()
            //{
            //    Id = Guid.Parse("702DE3DD-C1E7-4F40-9131-623AADB7E765"),
            //    FirstName = "Lyubomir",
            //    LastName = "Popov",
            //    DateOfBirth = DateTime.Parse("1972/03/26"),
            //    Gender = "male",
            //    UserName = "Mr.Popov",
            //    NormalizedUserName = "MR.POPOV",
            //    Email = "mrpopov@gmail.com",
            //    NormalizedEmail = "MRPOPOV@gmail.com",
            //    PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            //};

            //users.Add(user);

            //user = new ApplicationUser()
            //{
            //    Id = Guid.Parse("C3010F38-EC8B-4C80-9599-E8FDADA9299F"),
            //    FirstName = "Mustafa",
            //    LastName = "Buhov",
            //    UserName = "Mr.Buhov",
            //    DateOfBirth = DateTime.Parse("1971/3/26"),
            //    Gender = "male",
            //    NormalizedUserName = "MR.BUHOV",
            //    Email = "mrbuhov@gmail.com",
            //    NormalizedEmail = "MRBUHOV@GMAIL.COM",
            //    PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            //};

            //users.Add(user);

            //user = new ApplicationUser()
            //{
            //    Id = Guid.Parse("BBFE1B04-2741-4440-9334-595CB40A9F64"),
            //    FirstName = "Father",
            //    LastName = "Mitev",
            //    UserName = "Parent1",
            //    DateOfBirth = DateTime.Parse("1990/4/13"),
            //    Gender = "male",
            //    NormalizedUserName = "PARENT1",
            //    Email = "parent1@gmail.com",
            //    NormalizedEmail = "PARENT1@GMAIL.COM",
            //    PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            //};

            //users.Add(user);

            //user = new ApplicationUser()
            //{
            //    Id = Guid.Parse("B785B0D0-3D8C-4C37-A304-E2C41DCAB31A"),
            //    FirstName = "Mother",
            //    LastName = "Ivanova",
            //    DateOfBirth = DateTime.Parse("1992/4/13"),
            //    Gender = "female",
            //    UserName = "Parent2",
            //    NormalizedUserName = "PARENT2",
            //    Email = "parent2@gmail.com",
            //    NormalizedEmail = "PARENT2@GMAIL.COM",
            //    PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            //};

            //users.Add(user);

            //user = new ApplicationUser()
            //{
            //    FirstName = "Emily",
            //    LastName = "Cankova",
            //    UserName = "Parent3",
            //    DateOfBirth = DateTime.Parse("2000/2/10"),
            //    Gender = "female",
            //    NormalizedUserName = "PARENT3",
            //    Email = "parent3@gmail.com",
            //    NormalizedEmail = "PARENT3@GMAIL.COM",
            //    PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            //};

            //users.Add(user);

            //user = new ApplicationUser()
            //{
            //    FirstName = "Amelia",
            //    LastName = "Avita",
            //    DateOfBirth = DateTime.Parse("2000/04/27"),
            //    Gender = "female",
            //    UserName = "Mrs.Amelia",
            //    NormalizedUserName = "MRS.AMELIA",
            //    Email = "mrsamelia@gmail.com",
            //    NormalizedEmail = "MRSAMELIA@GMAIL.COM",
            //    SecurityStamp = "Z9Y8X7W6V5U4T3S2R1Q0P9O8N7M6L5K",
            //    PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            //};

            //users.Add(user);

            //user = new ApplicationUser()
            //{
            //    FirstName = "Ava",
            //    LastName = "Alita",
            //    DateOfBirth = DateTime.Parse("1999/03/25"),
            //    Gender = "female",
            //    UserName = "Mrs.Ava",
            //    NormalizedUserName = "MRS.AVA",
            //    Email = "mrsava@gmail.com",
            //    NormalizedEmail = "MRSAVA@GMAIL.COM",
            //    SecurityStamp = "H2G3F4E5D6C7B8A9Z0Y1X2W3V4U5T6S",
            //    PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            //};

            //users.Add(user);

            //user = new ApplicationUser()
            //{
            //    FirstName = "Aurora",
            //    LastName = "Gastambide",
            //    DateOfBirth = DateTime.Parse("1998/02/12"),
            //    Gender = "female",
            //    UserName = "Mrs.Aurora",
            //    NormalizedUserName = "MRS.AURORA",
            //    Email = "mrsaurora@gmail.com",
            //    NormalizedEmail = "MRSAURORA@GMAIL.COM",
            //    SecurityStamp = "M1N2O3P4Q5R6S7T8U9V0A1B2C3D4E5F",
            //    PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            //};

            //users.Add(user);

            //user = new ApplicationUser()
            //{
            //    FirstName = "Savka",
            //    LastName = "Ivanovich",
            //    DateOfBirth = DateTime.Parse("2001/09/26"),
            //    Gender = "female",
            //    UserName = "Mrs.Savka",
            //    NormalizedUserName = "MRS.SAVKA",
            //    Email = "mrssavka@gmail.com",
            //    NormalizedEmail = "MRSSAVKA@GMAIL.COM",
            //    SecurityStamp = "J9K8L7M6N5O4P3Q2R1S0T9U8V7W6X5Y",
            //    PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            //};

            //users.Add(user);

            user = new ApplicationUser()
            {
                Id = Guid.Parse("30F0662A-29C5-48DF-8B57-9C61C671E0FB"),
                FirstName = "Admin",
                LastName = "Admin",
                DateOfBirth = DateTime.Parse("1972/03/26"),
                Gender = "male",
                UserName = "Admin",
                NormalizedUserName = "admin",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.com",
                PasswordHash = "AQAAAAEAACcQAAAAEKD7ue2lT9/3kT1BsIV9uXwJgQ+j1atLihMxsAncN8qXuiOy5j7pTDYoKPLiS3Sslg==",
            };

            users.Add(user);

            return users.ToArray();
        }
    }
}
