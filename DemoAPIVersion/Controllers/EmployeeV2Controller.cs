using DemoAPIVersion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DemoAPIVersion.Controllers
{
    public class EmployeeV2Controller : ApiController
    {
        List<EmployeeV2> _employees = new List<EmployeeV2>()
        {
            new EmployeeV2() { Id = 1, FirstName = "Anoop", LastName = "Sharma", City = "New Delhi" },
            new EmployeeV2() { Id = 2, FirstName = "Ramesh", LastName = "Sharma", City = "Amritsar" },
        };

        public EmployeeV2 Get(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}