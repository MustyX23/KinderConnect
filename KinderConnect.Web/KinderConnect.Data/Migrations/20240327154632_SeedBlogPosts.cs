using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedBlogPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "Content", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "KinderConnect's Headmaster", "Outdoor play is crucial for children's development. It provides them with opportunities to explore their environment, develop their physical skills, and engage in imaginative play.\r\nResearch has shown that children who engage in regular outdoor play have better physical health, including stronger immune systems and reduced risk of obesity. Outdoor play also promotes mental well-being, as it allows children to release energy, reduce stress, and improve their mood.\r\nAdditionally, outdoor play encourages creativity and problem-solving skills. When children play outdoors, they are free to explore and interact with their surroundings, which stimulates their imagination and encourages them to think critically.\r\nFurthermore, outdoor play fosters social skills and cooperation. Children who play together outdoors learn to share, take turns, and communicate effectively with their peers. They also develop empathy and understanding as they navigate social interactions and resolve conflicts.\r\nIn conclusion, outdoor play is essential for children's overall development. It provides numerous physical, mental, and social benefits that contribute to their health and well-being.", "https://domf5oio6qrcr.cloudfront.net/medialibrary/10992/b8b237ee-7cfe-4eab-b79b-dac389707899.jpg", "The Importance of Outdoor Play for Children" },
                    { 2, "KinderConnect's Headmaster", "Ensuring a safe environment is essential for preschoolers to thrive. Young children are naturally curious and eager to explore their surroundings, so it's important to take steps to prevent accidents and injuries.\r\nOne way to create a safe environment for preschoolers is to childproof the space. This includes securing furniture and appliances, covering electrical outlets, and removing small objects that could be choking hazards. It's also important to keep hazardous substances out of reach and store them securely.\r\nIn addition to childproofing, it's essential to supervise preschoolers closely, especially when they're engaged in activities that pose a risk of injury. By keeping a watchful eye on them, caregivers can quickly intervene if they encounter any dangers.\r\nFurthermore, teaching preschoolers about safety rules and procedures is crucial. This includes educating them about fire safety, road safety, and personal boundaries. By empowering children with knowledge and skills, caregivers can help them make safer choices and avoid accidents.\r\nOverall, creating a safe environment for preschoolers requires careful planning, supervision, and education. By taking these steps, caregivers can ensure that young children have the opportunity to learn and grow in a secure and nurturing environment.", "https://i.natgeofe.com/k/6020d8d7-e976-4ff7-a81b-3d42e54ead42/saveearth_ngkhub_16x9.jpg?w=1200", "Creating a Safe Environment for Preschoolers" },
                    { 3, "KinderConnect's Headmaster", "Storytelling has numerous benefits for young children, including enhancing their language development, cognitive skills, and emotional intelligence.\r\nFirstly, storytelling promotes language development by exposing children to rich and varied vocabulary. When children listen to stories, they learn new words and phrases, which helps expand their vocabulary and improve their comprehension skills. Additionally, storytelling helps children develop their speaking skills as they retell stories and engage in discussions about the plot, characters, and themes.\r\nFurthermore, storytelling stimulates cognitive skills such as memory, imagination, and problem-solving. When children listen to stories, they use their imagination to visualize the characters and events, which enhances their creativity and critical thinking skills. Additionally, storytelling helps children develop their memory skills as they recall details from the story and make connections between different events.\r\nMoreover, storytelling encourages emotional intelligence by helping children identify and express their feelings. When children listen to stories with relatable characters and themes, they learn about empathy, compassion, and resilience. Storytelling also provides children with opportunities to explore complex emotions and learn coping strategies for dealing with difficult situations.\r\nIn conclusion, storytelling is a valuable tool for early childhood education. It promotes language development, cognitive skills, and emotional intelligence, providing children with a solid foundation for learning and growth.", "https://www.edencastleschool.com/wp-content/uploads/2018/03/The-Importance-Amazing-Benefits-of-Storytelling-for-Children.jpg", "Benefits of Storytelling in Early Childhood Education" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
