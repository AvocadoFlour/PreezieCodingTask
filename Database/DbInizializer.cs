using PreezieCodingTask.Entities.User;

namespace PreezieCodingTask.Database
{
    public class DbInizializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<UsersContext>();
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new User { Id = 1, DisplayName = "1", Email = "14@14.14", Password = "test" },
                    new User { Id = 2, DisplayName = "2", Email = "13@13.13", Password = "test" },
                    new User { Id = 3, DisplayName = "3", Email = "12@14.14", Password = "test" },
                    new User { Id = 4, DisplayName = "4", Email = "11@14.14", Password = "test" },
                    new User { Id = 5, DisplayName = "5", Email = "10@14.14", Password = "test" },
                    new User { Id = 6, DisplayName = "6", Email = "9@14.14", Password = "test" },
                    new User { Id = 7, DisplayName = "7", Email = "8@14.14", Password = "test" },
                    new User { Id = 8, DisplayName = "9", Email = "6@14.14", Password = "test" },
                    new User { Id = 9, DisplayName = "10", Email = "5@14.14", Password = "test" },
                    new User { Id = 10, DisplayName = "11", Email = "4@14.14", Password = "test" },
                    new User { Id = 11, DisplayName = "12", Email = "3@14.14", Password = "test" },
                    new User { Id = 12, DisplayName = "13", Email = "2@14.14", Password = "test" },
                    new User { Id = 13, DisplayName = "14", Email = "1@14.14", Password = "test" },
                    new User { Id = 14, DisplayName = "15", Email = "0@14.14", Password = "test" },
                    new User { Id = 15, DisplayName = "16", Email = "-1@14.14", Password = "test" },
                    new User { Id = 16, DisplayName = "17", Email = "-2@14.14", Password = "test" },
                    new User { Id = 17, DisplayName = "18", Email = "-3@14.14", Password = "test" },
                    new User { Id = 18, DisplayName = "19", Email = "-4@14.14", Password = "test" },
                    new User { Id = 19, DisplayName = "20", Email = "-5@14.14", Password = "test" },
                    new User { Id = 20, DisplayName = "21", Email = "-6@14.14", Password = "test" },
                    new User { Id = 21, DisplayName = "22", Email = "-7@14.14", Password = "test" },
                    new User { Id = 22, DisplayName = "23", Email = "-8@-8.14", Password = "test" });
                    context.SaveChanges();
                }

            }
        }
    }
}
