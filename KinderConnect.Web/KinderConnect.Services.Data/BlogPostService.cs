using KinderConnect.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.BlogPost;
using Microsoft.EntityFrameworkCore;

namespace KinderConnect.Services.Data
{
    public class BlogPostService : IBlogPostService
    {

        private readonly KinderConnectDbContext dbContext;

        public BlogPostService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<BlogPostViewModel>> GetThreeLastBlogPostsAsync()
        {
            var blogPosts = await dbContext.BlogPosts
                .OrderByDescending(b => b.CreatedOn)
                .Select(bp => new BlogPostViewModel()
                {
                    Id = bp.Id,
                    Title = bp.Title,
                    Content = bp.Content,
                    Author = bp.Author,
                    ImageUrl = bp.ImageUrl
                })
                .Take(3)
                .ToArrayAsync();

            return blogPosts;

        }
    }
}
