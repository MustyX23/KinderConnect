using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinderConnect.Data.Configurations
{
    public class ActivityEntityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(GenerateActivities());
        }

        private Activity[] GenerateActivities()
        {
            ICollection<Activity> activities = new HashSet<Activity>();

            Activity activity;

            activity = new Activity()
            {
                Id = 1,
                Name = "Drawing",
                Description = "We learn to draw circles and triangles :)"
            };

            activities.Add(activity);

            activity = new Activity()
            {
                Id = 2,
                Name = "Writing",
                Description = "We learn to write the Alphabet :)"
            };

            activities.Add(activity);

            activity = new Activity()
            {
                Id = 3,
                Name = "Play",
                Description = "We play a lot of football and volleyball :)"
            };

            activities.Add(activity);

            return activities.ToArray();
        }
    }
}
