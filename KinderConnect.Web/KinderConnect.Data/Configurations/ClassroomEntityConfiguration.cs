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

            classroom = new Classroom()
            {
                Name = "Math Whizzes",
                Information = "Hands-on math activities." +
                  "Problem-solving challenges." +
                  "Introduction to basic math concepts." +
                  "Fun math games.",
                MinimumAge = 6,
                MaximumAge = 9,
                TotalSeats = 30,
                TutionFee = 180,
                ImageUrl = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjy2CRd52Daq6LiABMz5N0pCnh9Ac9o4ccMvXoxUPmMPMyF9zhxcywuRhwWc2JA6NFcyrDc_j79bmvDk3V15JwmEuJ0v6LVC1bE_0V9W0WSOGs7nwDwyIJ707ej3Kz4QiAdw9ufVec4GAF18Cm5D-UJufeUzMIkqnaOVYWHrk44DbfkaDgKJIto6T02/s1748/teacher%20teaching%20math.png"
            };

            classrooms.Add(classroom);

            classroom = new Classroom()
            {
                Name = "Tech Explorers",
                Information = "Basic coding for kids." +
                              "Robotics and engineering projects." +
                              "Introduction to technology." +
                              "Creative digital art.",
                MinimumAge = 7,
                MaximumAge = 10,
                TotalSeats = 30,
                TutionFee = 200,
                ImageUrl = "https://www.nationalgeographic.org/wp-content/uploads/2021/10/Explorer-Classroom-Ryan-Carney_National-Geographic-scaled.jpeg"
            };

            classrooms.Add(classroom);

            classroom = new Classroom()
            {
                Name = "Music Makers",
                Information = "Introduction to musical instruments." +
                              "Music theory basics." +
                              "Group singing and performances." +
                              "Fun rhythm and melody activities.",
                MinimumAge = 5,
                MaximumAge = 8,
                TotalSeats = 20,
                TutionFee = 170,
                ImageUrl = "https://beauvoirmusic.com/wp-content/uploads/2022/08/BMMClass.ILA0070edit1-1024x768.jpg"
            };

            classrooms.Add(classroom);

            classroom = new Classroom()
            {
                Name = "Science Explorers",
                Information = "Hands-on science experiments." +
                              "Discovering nature and the universe." +
                              "Introduction to scientific concepts." +
                              "Creative science projects.",
                MinimumAge = 8,
                MaximumAge = 12,
                TotalSeats = 35,
                TutionFee = 190,
                ImageUrl = "https://scienceexplorers.com/wp-content/uploads/2023/09/Academic-Overview-Science-Explorers-01.jpg"
            };

            classrooms.Add(classroom);

            classroom = new Classroom()
            {
                Name = "Language Learners",
                Information = "Introduction to new languages." +
                              "Interactive language games." +
                              "Cultural learning experiences." +
                              "Basic vocabulary and phrases.",
                MinimumAge = 6,
                MaximumAge = 9,
                TotalSeats = 25,
                TutionFee = 160,
                ImageUrl = "https://ksspreschool.com/wp-content/uploads/2021/12/KSS-Preschool-English-Skills-and-Language-Immersion.jpeg"
            };

            classrooms.Add(classroom);

            classroom = new Classroom()
            {
                Name = "Sports Stars",
                Information = "Introduction to various sports." +
                              "Physical fitness activities." +
                              "Team-building exercises." +
                              "Healthy competition and fun.",
                MinimumAge = 7,
                MaximumAge = 11,
                TotalSeats = 40,
                TutionFee = 210,
                ImageUrl = "https://i.ytimg.com/vi/fIZR5Ib1p_w/maxresdefault.jpg"
            };

            classrooms.Add(classroom);

            return classrooms.ToArray();
        }
    }
}
