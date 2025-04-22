
# ASP.NET Core MVC CRUD Application using Entity Framework Core

This is a simple CRUD (Create, Read, Update, Delete) application built using **ASP.NET Core MVC** and **Entity Framework Core** with SQL Server.

🎯 **Purpose:** I'm currently learning ASP.NET Core MVC and Entity Framework Core, and this project is part of my hands-on practice to strengthen those concepts.

---

## 🛠 Technologies Used

- ASP.NET Core MVC (.NET 6/7)
- Entity Framework Core
- SQL Server (LocalDB)
- Razor Views
- Dependency Injection (DI)
- LINQ for data access

---

## 📁 Folder Structure

```
├── Models
│   └── Employee.cs
├── Repository
│   └── AppDbContext.cs
├── Services
│   ├── IEmployeeRepository.cs
│   └── SQLEmployeeRepository.cs
├── Controllers
│   └── EmployeeController.cs
├── Views
│   └── Employee
│       ├── Index.cshtml
│       ├── Details.cshtml
│       ├── Edit.cshtml
│       ├── Delete.cshtml
│       └── Create.cshtml
```

---

## 🚀 Getting Started

### 1. Create the Model

```csharp
public class Employee
{
    [Key]
    public int AId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int salary { get; set; }
}
```

### 2. Install Required Packages

```powershell
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.Extensions.Configuration.Json
```

### 3. Setup DbContext

```csharp
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
}
```

### 4. Create Repository Interface

```csharp
public interface IEmployeeRepository
{
    Employee GetEmployee(int Id);
    IEnumerable<Employee> GetAllEmployee();
    Employee Update(Employee employeeChanges);
    Employee Delete(int Id);
}
```

### 5. Implement Repository

```csharp
public class SQLEmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext Connect;

    public SQLEmployeeRepository(AppDbContext connect)
    {
        Connect = connect;
    }

    public IEnumerable<Employee> GetAllEmployee() => Connect.Employees;

    public Employee GetEmployee(int Id) => Connect.Employees.Find(Id);

    public Employee Update(Employee employeeChanges)
    {
        Connect.Entry(employeeChanges).State = EntityState.Modified;
        Connect.SaveChanges();
        return employeeChanges;
    }

    public Employee Delete(int Id)
    {
        var employee = Connect.Employees.Find(Id);
        if (employee != null)
        {
            Connect.Employees.Remove(employee);
            Connect.SaveChanges();
        }
        return employee;
    }
}
```

### 6. Setup Connection String

```json
"ConnectionStrings": {
  "EmployeeDBConnection": "Data Source=(localdb)\ProjectModels;Initial Catalog=WebAppDb;Integrated Security=True"
}
```

### 7. Configure Program.cs

```csharp
builder.Services.AddDbContextPool<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection"))
);
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
```

### 8. Run Migration

```bash
Add-Migration InitialCreate
Update-Database -Verbose
```

### 9. Create Controller and Views

Create `EmployeeController` and use scaffolding to generate views like:

- Index
- Details
- Edit
- Delete
- Create

Right-click on action methods → Add View → Choose Razor template

---

## 💡 Notes

- I'm currently learning, so feel free to share suggestions or improvements.
- This is a practice project to explore CRUD operations using best practices.

---

## ✍️ Author

**Adwyait Pawar**  
🎓 PG-DAC | B.Tech in CSE from VIT  
💬 Exploring .NET one bug at a time!
_Clean code, caffeine, and just enough sarcasm._


---

Happy Building! 🚀 Star this repo if you like it!
