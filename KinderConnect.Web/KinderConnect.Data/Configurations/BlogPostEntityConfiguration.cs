using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinderConnect.Data.Configurations
{
    public class BlogPostEntityConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasData(GenerateBlogPosts());
        }

        private BlogPost[] GenerateBlogPosts()
        {
            ICollection<BlogPost> blogposts = new HashSet<BlogPost>();

            BlogPost blogPost;

            blogPost = new BlogPost()
            {
                Id = 1,
                Title = "The Importance of Outdoor Play for Children",
                Content = @"Outdoor play is crucial for children's development. It provides them with opportunities to explore their environment, develop their physical skills, and engage in imaginative play.
Research has shown that children who engage in regular outdoor play have better physical health, including stronger immune systems and reduced risk of obesity. Outdoor play also promotes mental well-being, as it allows children to release energy, reduce stress, and improve their mood.
Additionally, outdoor play encourages creativity and problem-solving skills. When children play outdoors, they are free to explore and interact with their surroundings, which stimulates their imagination and encourages them to think critically.
Furthermore, outdoor play fosters social skills and cooperation. Children who play together outdoors learn to share, take turns, and communicate effectively with their peers. They also develop empathy and understanding as they navigate social interactions and resolve conflicts.
In conclusion, outdoor play is essential for children's overall development. It provides numerous physical, mental, and social benefits that contribute to their health and well-being.",
                Author = "KinderConnect's Headmaster",
                ImageUrl = "https://example.com/outdoor-play-image.jpg"
            };
            blogposts.Add(blogPost);

            blogPost = new BlogPost()
            {
                Id = 2,
                Title = "Creating a Safe Environment for Preschoolers",
                Content = @"Ensuring a safe environment is essential for preschoolers to thrive. Young children are naturally curious and eager to explore their surroundings, so it's important to take steps to prevent accidents and injuries.
One way to create a safe environment for preschoolers is to childproof the space. This includes securing furniture and appliances, covering electrical outlets, and removing small objects that could be choking hazards. It's also important to keep hazardous substances out of reach and store them securely.
In addition to childproofing, it's essential to supervise preschoolers closely, especially when they're engaged in activities that pose a risk of injury. By keeping a watchful eye on them, caregivers can quickly intervene if they encounter any dangers.
Furthermore, teaching preschoolers about safety rules and procedures is crucial. This includes educating them about fire safety, road safety, and personal boundaries. By empowering children with knowledge and skills, caregivers can help them make safer choices and avoid accidents.
Overall, creating a safe environment for preschoolers requires careful planning, supervision, and education. By taking these steps, caregivers can ensure that young children have the opportunity to learn and grow in a secure and nurturing environment.",
                Author = "KinderConnect's Headmaster",
                ImageUrl = "https://example.com/safe-environment-image.jpg"
            };
            blogposts.Add(blogPost);

            blogPost = new BlogPost()
            {
                Id = 3,
                Title = "Benefits of Storytelling in Early Childhood Education",
                Content = @"Storytelling has numerous benefits for young children, including enhancing their language development, cognitive skills, and emotional intelligence.
Firstly, storytelling promotes language development by exposing children to rich and varied vocabulary. When children listen to stories, they learn new words and phrases, which helps expand their vocabulary and improve their comprehension skills. Additionally, storytelling helps children develop their speaking skills as they retell stories and engage in discussions about the plot, characters, and themes.
Furthermore, storytelling stimulates cognitive skills such as memory, imagination, and problem-solving. When children listen to stories, they use their imagination to visualize the characters and events, which enhances their creativity and critical thinking skills. Additionally, storytelling helps children develop their memory skills as they recall details from the story and make connections between different events.
Moreover, storytelling encourages emotional intelligence by helping children identify and express their feelings. When children listen to stories with relatable characters and themes, they learn about empathy, compassion, and resilience. Storytelling also provides children with opportunities to explore complex emotions and learn coping strategies for dealing with difficult situations.
In conclusion, storytelling is a valuable tool for early childhood education. It promotes language development, cognitive skills, and emotional intelligence, providing children with a solid foundation for learning and growth.",
                Author = "KinderConnect's Headmaster",
                ImageUrl = "https://example.com/storytelling-image.jpg"
            };
            blogposts.Add(blogPost);

            return blogposts.ToArray();
        }
    }
}
