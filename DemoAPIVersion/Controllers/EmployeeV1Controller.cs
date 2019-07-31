using DemoAPIVersion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DemoAPIVersion.Controllers
{
    public class EmployeeV1Controller : ApiController
    {
        List<EmployeeV1> _employees = new List<EmployeeV1>()
        {
            new EmployeeV1() { Id = 1, Name = "Anoop Sharma", Age = 26, City = "New Delhi" },
            new EmployeeV1() { Id = 2, Name = "Ramesh Sharma", Age = 30, City = "Amritsar" },
        };

        public EmployeeV1 Get(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}