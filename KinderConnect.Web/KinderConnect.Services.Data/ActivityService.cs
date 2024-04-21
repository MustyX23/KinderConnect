using KinderConnect.Data;
using KinderConnect.Data.Models;
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

        public async Task CreateAsync(ActivityFormModel model)
        {
            Activity activity = new Activity()
            {
                Name = model.Name,
                Description = model.Description,
                IsActive = true
            };

            dbContext.Activities.Add(activity);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditByIdAsync(int id, ActivityFormModel model)
        {
            var activity = dbContext
                .Activities
                .Where(a => a.IsActive && a.Id == id)
                .FirstOrDefault();

            if (activity != null)
            {
                activity.Name = model.Name;
                activity.Description = model.Description;

                await dbContext.SaveChangesAsync();
            }                        
        }

        public async Task<ActivityFormModel> GetActivityForEditByIdAsync(int id)
        {
            ActivityFormModel? activity = await dbContext
                .Activities
                .Where(a => a.Id == id && a.IsActive)
                .Select(a => new ActivityFormModel
                {
                    Name = a.Name,
                    Description = a.Description,
                })
                .FirstOrDefaultAsync();

            return activity;
        }

        public async Task<IEnumerable<AllActivitiesViewModel>> GetAllActivitiesAsync()
        {
            var activities = await dbContext.Activities
                .Where(a => a.IsActive)
                .Select(a => new AllActivitiesViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                })
                .ToArrayAsync();

            return activities;
        }

        public async Task<IEnumerable<AllActivitiesViewModel>> GetThreeActivitiesAsync()
        {
            var lastThreeActivities = await dbContext
                .Activities
                .Where(a => a.IsActive)
                .Select(a => new AllActivitiesViewModel()
                {
                    Name = a.Name,
                    Description = a.Description,
                })
                .OrderByDescending(a => a.Name)
                .Take(3)
                .ToArrayAsync();

            return lastThreeActivities;
        }

        public async Task SoftRemoveByIdAsync(int id)
        {
            var activity = await dbContext
                .Activities
                .FirstOrDefaultAsync(c => c.IsActive && c.Id == id);

            if (activity != null)
            {
                activity.IsActive = false;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
