using MVC_Demo2.Models;

namespace MVC_Demo2.Services
{
    public interface IEmployeeRepo
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();

        public Employee Update(Employee emp);
        public Employee Delete(int id);

        //public Employee Edit(int id);
    }
}
