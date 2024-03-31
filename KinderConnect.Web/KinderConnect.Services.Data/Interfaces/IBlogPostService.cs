using KinderConnect.Web.ViewModels.BlogPost;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostViewModel>> GetThreeLastBlogPostsAsync();

        //Task<BlogPostViewModel> GetAttendanceRecordByIdAsync(int id);
        //Task RecordAttendanceAsync(BlogPostViewModel attendanceRecordDto);
        //Task UpdateAttendanceAsync(int id, BlogPostViewModel attendanceRecordDto);
        //Task DeleteAttendanceAsync(int id);
    }
}
