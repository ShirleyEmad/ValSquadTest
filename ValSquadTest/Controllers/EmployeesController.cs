using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValSquadTest.Models;

namespace ValSquadTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ValTestContext ctx ;

        public EmployeesController(ValTestContext context)
        {
            ctx = context;
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            List<Employee> employees = ctx.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = ctx.Employees.Where(s => s.Id == id).FirstOrDefault();
            return Ok(employee);
        }
    }
}
