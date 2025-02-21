using AjaxWebApp.WebUI.Context;
using AjaxWebApp.WebUI.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjaxWebApp.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly RepositoryContext _context;

        public CustomerController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerList()
        {
            var values=_context.Customers.ToList();
            var jsonData=JsonConvert.SerializeObject(values);
            return Json(jsonData);  
        }

        public IActionResult CreateOneCustumer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            var jsonData=JsonConvert.SerializeObject(customer);
            return Json(jsonData);
        }  

        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return NoContent();
        }

        public IActionResult GetCustomer(int id)
        {
            var value=_context.Customers.Find(id);
            var jsonData = JsonConvert.SerializeObject(value);  
            return Json(jsonData);  
        }
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return NoContent() ;    
        }
    }
}
