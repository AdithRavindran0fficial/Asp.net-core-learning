using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class Userservicecs : Iuserservice
    {
        public static readonly List<Userscs> User_list = new List<Userscs>
        {
            new Userscs{Name="adith",Email="adith@gmail.com",Password="1234",Role="user",Id=1},
            new Userscs{Name="anandhu",Email="anandhu@gmail.com",Password="12345",Role="admin",Id=2}
        };

        public List<Userscs> GetUsers()
        {
            return User_list;
        }
        public Userscs GetUser_id(int id)
        {
            var user = User_list.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new KeyNotFoundException($"User with {id} not found");
            }
            return user;
        }
        public Userscs Registration(Userscs user)
        {
            var exist = User_list.FirstOrDefault(u => u.Email == user.Email && u.Password==user.Password);
            if (exist != null)
            {
                throw new Exception("Please login");

            }
            else
            {
                user.Id = User_list.Any() ? User_list.Max(u => u.Id) + 1 : 1;
                User_list.Add(user);
                return null;
            }
            
        }
        public void Delete_User(int id)
        {
            var dele = User_list.FirstOrDefault(user => user.Id == id);
            if(dele == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            User_list.Remove(dele);
        }
        public Userscs Login_(Login user)
        {
            var exist= User_list.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if(exist == null)
            {
                throw new KeyNotFoundException("wrong email or password");
            }
            else { return exist; }
           
        }
    }
}
