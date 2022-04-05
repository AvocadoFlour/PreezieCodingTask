using Microsoft.EntityFrameworkCore;
using PreezieCodingTask.Helpers;
using PreezieCodingTask.Entities.User;
using PreezieCodingTask.Helpers.Users;
using PreezieCodingTask.Entities.User.DTOs;
using System.Linq.Expressions;

namespace PreezieCodingTask.Database
{

    public interface IUsersContext{
        public void CreateUser(User user);
        public List<UserDTO> ListUsers(RequestUsersDTO listUsersDTO);
        public User GetUser(long id);
        public bool UpdateUser(long id, UserUpdateDTO userUpdate); 
    }

    public class UsersContext : DbContext, IUsersContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        //// Makes sure that the tables aren't named using plural (user, not users)
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

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

        public List<UserDTO> ListUsers(RequestUsersDTO listUsersDTO)
        {
            if(listUsersDTO == null)
            {
                return Users.Select(x => UserToUserDto(x)).ToList();
            }

            var query = from u in Users
                        select u;

            if(!listUsersDTO.Email.Equals(string.Empty))
            {
                query = query.Where(u => u.Email.Equals(listUsersDTO.Email));
            }

            query = query.Skip(listUsersDTO.Page * listUsersDTO.PageSize);
            query = query.Take(listUsersDTO.PageSize);

            var finalQuery = query.OrderBy(u => u.Email);

            var result = finalQuery.ToList();

            List<UserDTO> dtoList = result.Select(x => UserToUserDto(x)).ToList();

            return dtoList;
        }

        public bool UpdateUser(long id, UserUpdateDTO userUpdate)
        {
            var userToUpdate = Users.FirstOrDefault(x => x.Id == id);
            if (!(userToUpdate == null))
            {
                userToUpdate.DisplayName = userUpdate.DisplayName;
                userToUpdate.Password = Sha256.GetHash(userUpdate.Password);
                this.SaveChanges();
                return true;
            }
            return false;
        }

        private UserDTO UserToUserDto(User user)
        {
            return new UserDTO { DisplayName = user.DisplayName, Email = user.Email };
        }

    }
}
