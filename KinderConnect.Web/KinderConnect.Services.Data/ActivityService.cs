using KinderConnect.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Activity;
using Microsoft.EntityFrameworkCore;

namespace KinderConnect.Services.Data
{
    public class ActivityService : IActivityService
    {
        private readonly KinderConnectDbContext dbContext;

        public ActivityService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<AllActivitiesViewModel>> GetAllActivitiesAsync()
        {
            var activities = await dbContext.Activities
                .Select(a => new AllActivitiesViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                })
                .ToArrayAsync();

            return activities;
        }
    }
}
