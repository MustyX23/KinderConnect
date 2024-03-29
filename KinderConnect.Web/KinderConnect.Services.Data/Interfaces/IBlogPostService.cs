using KinderConnect.Web.ViewModels.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IBlogPostService
    {
        Task<IEnumerable<IndexBlogPost>> GetThreeBlogPostsAsync();
    }
}
