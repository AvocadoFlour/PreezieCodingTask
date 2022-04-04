using PreezieCodingTask.Entities;
using System.Data.Entity;

namespace PreezieCodingTask.Database
{

    public interface IUsersContext{
        public void CreateUser(string email, string password, string displayName);
        public List<User> ListUsers();
        public User GetUser(int id);
        public bool UpdateUser(int id);
    }

    public class UsersContext : DbContext, IUsersContext
    {
        public UsersContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }

        public void CreateUser(string email, string password, string displayName)
        {
            Users.Add(new User
            {
                DisplayName = "TestName",
                Password = "requires",
                Email = "testEMail"
            }); ;
            this.SaveChanges();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> ListUsers()
        {
            return Users.ToList();
        }

        public bool UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
