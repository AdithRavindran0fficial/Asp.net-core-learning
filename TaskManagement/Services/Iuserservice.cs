using TaskManagement.Models;

namespace TaskManagement.Services
{
    public interface Iuserservice
    {
        List<Userscs> GetUsers();
        Userscs GetUser_id(int id);

        Userscs Registration(Userscs user);

        void Delete_User(int id);

        Userscs Login_(Login user);
    }
}
