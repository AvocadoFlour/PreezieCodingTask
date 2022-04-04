using PreezieCodingTask.Entities;
using System.Data.Entity;
using PreezieCodingTask.Helpers;

namespace PreezieCodingTask.Database
{

    public interface IUsersContext{
        public void CreateUser(User user);
        public List<User> ListUsers();
        public User GetUser(long id);
        public bool UpdateUser(long id, UserUpdateDTO userUpdate);
    }

    public class UsersContext : DbContext, IUsersContext
    {
        public UsersContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }

        public void CreateUser(User user)
        {
            user.Password = Sha256.GetHash(user.Password);
            Users.Add(user);
            this.SaveChanges();
        }

        public User GetUser(long id)
        {
            throw new NotImplementedException();
        }

        public List<User> ListUsers()
        {
            return Users.ToList();
        }

        public bool UpdateUser(long id, UserUpdateDTO userUpdate)
        {
            var userToUpdate = Users.Find(id);
            if (!(userToUpdate != null))
            {
                userToUpdate.DisplayName = userUpdate.DisplayName;
                userToUpdate.Password = Sha256.GetHash(userUpdate.Password);
                return true;
            }
            return false;
        }

    }
}
