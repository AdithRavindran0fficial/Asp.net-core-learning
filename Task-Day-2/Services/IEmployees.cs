using Task_Day_2.Models;

namespace Task_Day_2.Services
{
    public interface IEmployees
    {
        List<Employ_data> Get();
        Employ_data Get_id(int id);
        Employ_data Post(Employ_data employee);
        Employ_data Put(int id , Employ_data employee);
        void Delete(int id);
        
    }
}
