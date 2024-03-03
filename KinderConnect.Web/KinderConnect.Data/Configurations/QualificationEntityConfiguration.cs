using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderConnect.Data.Configurations
{
    public class QualificationEntityConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.HasData(GenerateQualifications());
        }
        private Qualification[] GenerateQualifications()
        {
            ICollection<Qualification> qualifications = new HashSet<Qualification>();

            Qualification qualification;

            qualification = new Qualification()
            {
                Id = 1,
                Name = "Bachelor's Degree in Early Childhood Education",
                Description = "A bachelor's degree in early childhood education" +
                " prepares teachers with comprehensive knowledge and skills in child development," +
                " curriculum design, assessment, and family engagement. This qualification enables educators" +
                " to implement evidence-based practices and support children's holistic development."
            };

            qualifications.Add(qualification);

            qualification = new Qualification()
            {
                Id = 2,
                Name = "Early Childhood Education Certificate",
                Description = "This qualification equips teachers with" +
                " essential knowledge and skills to effectively engage" +
                " and educate young children in a kindergarten setting." +
                " It covers topics such as child development, curriculum planning," +
                " and fost" +
                "ering a nurturing learning environment.",
            };            

            qualifications.Add(qualification);

            qualification = new Qualification()
            {
                Id = 3,
                Name = "Child Development Associate (CDA) Credential",
                Description = "The CDA credential is a nationally" +
                " recognized certification for early childhood professionals." +
                " It emphasizes the importance of nurturing children's physical," +
                " social, emotional, and cognitive development. " +
                "Teachers with a CDA credential demonstrate competence in providing " +
                "high-quality care and education to young children."
            };

            qualifications.Add(qualification);

            return qualifications.ToArray();
        }
    }
}
