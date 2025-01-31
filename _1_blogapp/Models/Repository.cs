using System.Collections.Generic;

namespace _1_blogapp.Models
{
    public class Repository
    {
        private static readonly List<Product> _product = new();

        static Repository()
        {
            _product = new List<Product>()
            {
                new Product() {
                    Id = 1,
                    Title = "The Role of Technology in Education",
                    Subheading = "Digital Transformation",
                    Content = "Technology has brought significant changes to the field of education. Remote learning and e-learning have increased student participation and provided teachers with new methods. Smart boards, tablets, and educational apps make lessons more interactive. Visual and auditory materials facilitate learning and boost student motivation.",
                    ImgUrl = "https://images.unsplash.com/photo-1571171637578-41bc2dd41cd2?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Author = "Pounter",
                },
                new Product() {
                    Id = 2,
                    Title = "The Influence of Technology on Learning",
                    Subheading = "Shaping Modern Education",
                    Content = "Technology is reshaping the landscape of education. From online classes to interactive learning tools, digital innovation has transformed how knowledge is delivered and received. Digital platforms and educational software engage students in ways traditional methods cannot. Gamification and multimedia resources make learning more enjoyable, fostering greater interest and participation.",
                    ImgUrl = "https://images.unsplash.com/photo-1556742044-3c52d6e88c62?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Author = "Pounter"
                },
                new Product() {
                    Id = 3,
                    Title = "The Evolution of Software Development",
                    Subheading = "Transforming Industries",
                    Content = "Software development has rapidly evolved, influencing various industries from finance to healthcare. The rise of agile methodologies and DevOps practices has streamlined the development process, making it more efficient and collaborative. Innovations like artificial intelligence, machine learning, and blockchain are reshaping software capabilities. These technologies enable developers to create smarter applications that can adapt and learn over time.",
                    ImgUrl = "https://images.unsplash.com/photo-1534665482403-a909d0d97c67?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Author = "Pounter"
                },
                new Product() {
                    Id = 4,
                    Title = "The Importance of Software Testing",
                    Subheading = "Ensuring Quality and Reliability",
                    Content = "Software testing is a critical phase in the software development lifecycle. It helps identify bugs and issues before the product reaches the end-user, ensuring a reliable and high-quality experience. Various testing methods, such as unit testing, integration testing, and user acceptance testing, are employed to cover different aspects of the software. Automated testing tools are increasingly used to enhance efficiency and accuracy.",
                    ImgUrl = "https://images.unsplash.com/photo-1553877522-43269d4ea984?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Author = "Pounter"
                },
                new Product() {
                    Id = 5,
                    Title = "The Rise of Open Source Software",
                    Subheading = "Collaborative Development",
                    Content = "Open source software has revolutionized the way applications are built and shared. By allowing users to access and modify the source code, it fosters collaboration and innovation across diverse communities.",
                    ImgUrl = "https://images.unsplash.com/photo-1615522310480-a76fc24ee5da?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Author = "Pounter",
                },
                new Product() {
                    Id = 6,
                    Title = "The Role of Artificial Intelligence in Software Development",
                    Subheading = "Enhancing Productivity",
                    Content = "Artificial intelligence (AI) is transforming software development by automating repetitive tasks and providing intelligent insights. Developers can focus more on creative aspects while AI handles routine processes.",
                    ImgUrl = "https://images.unsplash.com/photo-1580983703451-bf6bb44a9917?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Author = "Pounter",
                },
                new Product() {
                    Id = 7,
                    Title = "The Significance of User Experience (UX) Design",
                    Subheading = "Prioritizing the User",
                    Content = "User experience design is essential in creating software that meets the needs and expectations of users. A well-designed interface can significantly impact user satisfaction and engagement.",
                    ImgUrl = "https://images.unsplash.com/photo-1531403009284-440f080d1e12?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Author = "Pounter",
                }
            };
        }

        public static List<Product> Products => _product;

        public static Product? GetById(int id)
        {
            return _product.FirstOrDefault(p => p.Id == id);
        }
    }
}
