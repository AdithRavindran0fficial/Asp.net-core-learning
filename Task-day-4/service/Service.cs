using Task_day_4.Models;

namespace Task_day_4.service
{
    public class Service : IService
    {
        public static readonly List<Items> Collections = new List<Items>();
        public List<Items> GetItems()
        {
            return Collections;
        }
        public Items GetItem_id(int id)
        {
            var item = Collections.FirstOrDefault(x => x.Id == id);
            if(item == null)
            {
                return null;
            }
            return item; 
        } 
        public Items Post(Items item)
        {
            Collections.Add(item);
            return item;
        }
        public Items Put(int id,Items item)
        {
            var existing = Collections.FirstOrDefault(x => x.Id == id);
            if(existing == null)
            {
                return null;
            }
            existing.Description=item.Description;
            existing.Titile=item.Titile;
            existing.Name=item.Name;
            return existing;
        }
        public Items Delete(int id)
        {
            var Dele = Collections.FirstOrDefault(x => x.Id == id);
            if(Dele == null)
            {
                return null;

            }
            Collections.Remove(Dele);
            return Dele;
            
        }
    }
}
