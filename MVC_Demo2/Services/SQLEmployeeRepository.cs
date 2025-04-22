using System;
using MVC_Demo2.Models;
using MVC_Demo2.Repository;

namespace MVC_Demo2.Services
{
    public class SQLEmployeeRepository : IEmployeeRepo
    {
        private readonly AppDbContext Cont;
        public SQLEmployeeRepository(AppDbContext Cont)
        {
            this.Cont = Cont;
        }

       

        public Employee Delete(int Id)
        {
            //var result = (from g in Connect Employees where g.Id == Id select g).SingleOrDefault();
            //Or	
            Employee employee = Cont.Employees.Find(Id);
            if (employee != null)
            {
                Cont.Employees.Remove(employee);
                Cont.SaveChanges();
            }
            return employee;
        }

        public Employee Delete(Employee emp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return Cont.Employees;
        }

        public Employee GetEmployee(int id)
        {
            var emp = Cont.Employees.FirstOrDefault(e => e.Eid == id);
            return emp;
        }

        public Employee Update(Employee empchg)
        {
            Cont.Employees.Update(empchg).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return empchg;
        }
    }
}
