using KinderConnect.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Qualification;
using Microsoft.EntityFrameworkCore;

namespace KinderConnect.Services.Data
{
    public class QualificationService : IQualificationService
    {
        private readonly KinderConnectDbContext dbContext;
        public QualificationService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<QualificationViewModel>> GetAllQualificationsViewModels()
        {
            var allQualification = await dbContext
                .Qualifications
                .Select (q => new QualificationViewModel 
                {
                    Id = q.Id,
                    Name = q.Name,
                })
                .ToArrayAsync();

            return allQualification;
        }
    }
}
