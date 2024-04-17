using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data;
using KinderConnect.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace KinderConnect.Services.Tests.BlogPostServiceTests
{
    public class BlogPostRetrievalTests
    {
        private DbContextOptions<KinderConnectDbContext> options;
        private KinderConnectDbContext dbContext;
        private IBlogPostService blogPostService; // Use interface type here

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<KinderConnectDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            dbContext = new KinderConnectDbContext(options);
            blogPostService = new BlogPostService(dbContext); // Use interface type here

            // Seed data
            dbContext.BlogPosts.AddRange(new[]
            {
                new BlogPost { Id = 1, Title = "Post 1", Content = "Content 1", Author = "Author 1", ImageUrl = "image1.jpg", CreatedOn = DateTime.Parse("2024-04-01") },
                new BlogPost { Id = 2, Title = "Post 2", Content = "Content 2", Author = "Author 2", ImageUrl = "image2.jpg", CreatedOn = DateTime.Parse("2024-04-02") },
                new BlogPost { Id = 3, Title = "Post 3", Content = "Content 3", Author = "Author 3", ImageUrl = "image3.jpg", CreatedOn = DateTime.Parse("2024-04-03") }
            });

            dbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task GetThreeLastBlogPostsAsync_ShouldReturnThreeLatestBlogPosts()
        {
            // Act
            var result = await blogPostService.GetThreeLastBlogPostsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());

            var lastPost = result.Last();
            Assert.AreEqual(1, lastPost.Id);
            Assert.AreEqual("Post 1", lastPost.Title);
            Assert.AreEqual("Content 1", lastPost.Content);
            Assert.AreEqual("Author 1", lastPost.Author);
            Assert.AreEqual("image1.jpg", lastPost.ImageUrl);
        }
    }
}