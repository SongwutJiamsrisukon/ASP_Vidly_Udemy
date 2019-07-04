using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ASP_Vidly_Udemy.Models;

using System.Data.Entity;

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