using Task_Day_2.Models;

namespace Task_Day_2.Services
{
    public class Employees :IEmployees
    {
        public List<Employ_data>?Employee_list = new List<Employ_data>();
        public async Task<List<Employ_data>> Get()
        {
            await Task.Delay(1000);
            return Employee_list;
        }
        public async Task<Employ_data> Get_id(int id)
        {
            var existing = Employee_list.FirstOrDefault(emp => emp.Id==id);
            if (existing == null)
            {
                throw new Exception("Emplyee not found");
            }
            await Task.Delay(1000);
            return existing;
        }
        public Employ_data Post(Employ_data employ)
        {
            if (employ == null)
            {
                throw new Exception("emplye should be contain some value");
            }
            Employee_list.Add(employ);
            return employ;
        }
        public Employ_data Put(int id ,Employ_data employ)
        {
            var updating = Employee_list.FirstOrDefault(f => f.Id == id);
            if (updating == null)
            {
                throw new Exception("emplyee with this id not found");
            }
            updating.Dept = employ.Dept;
            updating.Name = employ.Name;
            return updating;
        }
        public void Delete(int id)
        {
            var delete = Employee_list.FirstOrDefault(emp => emp.Id == id);
            if (delete == null)
            {
                throw new Exception("this employee is not found");
            }
            Employee_list.Remove(delete);
        }
    }
}
