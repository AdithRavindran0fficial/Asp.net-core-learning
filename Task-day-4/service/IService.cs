using Task_day_4.Models;

namespace Task_day_4.service
{
    public interface IService
    {
        List<Items> GetItems();
        Items GetItem_id(int id);
        Items Post(Items item);
        Items Put(int id,Items item);
        Items  Delete(int id);

    }
}
