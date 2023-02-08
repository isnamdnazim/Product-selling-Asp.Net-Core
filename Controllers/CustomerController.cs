using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TestProject.Data;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DataContext _context;
        private readonly IToastNotification _toastNotification;


        public CustomerController(DataContext context)
        {
            _context = context;


        }
        public IActionResult CustomerIndex()
        {
            var customer = _context.CustomerInfos.ToList();
            return View(customer);
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerInfo customerInfo)
        {
            var alcus = _context.CustomerInfos.Where(x => x.CustomerName == customerInfo.CustomerName).FirstOrDefault();
            if (alcus != null)
            {
                //_toastNotification.AddErrorToastMessage("An existing Supplier exists in the same name");
                return View(customerInfo);
            }

            _context.Add(customerInfo);
            _context.SaveChanges();
            //_toastNotification.AddSuccessToastMessage("Supplier added successfully");
            return RedirectToAction("CustomerIndex");

        }

        public IActionResult DeleteCustomer(int Id)
        {
            var dat = _context.CustomerInfos.Where(x => x.CustomerID == Id).FirstOrDefault();
            _context.Remove(dat);
            _context.SaveChanges();
            return RedirectToAction("CustomerIndex");
        }
    }
}
