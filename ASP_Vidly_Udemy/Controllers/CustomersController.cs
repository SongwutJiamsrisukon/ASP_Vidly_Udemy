using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ASP_Vidly_Udemy.Models;

using System.Data.Entity;
using ASP_Vidly_Udemy.ViewModels;

namespace ASP_Vidly_Udemy.Controllers
{
    public class CustomersController : Controller
    {
        public ApplicationDbContext _context;//declare property for DbConnection
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();//delete after used(same db.closed())
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customerViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(), //set property with default value to fix hiddden propery in Html form like Customer.Id = 0
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",customerViewModel);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var customerFormViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", customerFormViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)//model binding from request date with framework
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);//Db_context marking add,update,delete in memories
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);//no need default(when not found these throw exception)

                //way 1 update all object | disadventage force to update all data
                //TryUpdateModel(customerInDb);

                //way 2 updatate selecting object | disadvantage on magic string
                //TryUpdateModel(customerInDb, "", new String[] { "Name","BirthDate,", "MembershipTypeId", "IsSubscribedToNewsletter" });

                //way 3 updatate selecting object | disadvantage many line
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();          //Db_context save(generate sql and run to database on this line)

            return RedirectToAction("Index","Customers");//redirect to CustomersController with Index action(method)
        }



        // GET: Customer
        public ActionResult Index()
        {
            //var Customers = _context.Customers;//DbSet(all table) || This is Defered excution(not query{using SQL} in this line) so it query in Html when someone need property in Table
            var Customers = _context.Customers.Include(c => c.MembershipType).ToList();//DbSet(all table) || This query{using SQL} in this line
            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);//DbSet(all table) || This query{using SQL} in this line

            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}