using ASP_Vidly_Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ASP_Vidly_Udemy.Dtos;
using AutoMapper;

using System.Data.Entity;

namespace ASP_Vidly_Udemy.Controllers.Api
{
    public class CustomersController : ApiController
    {

        public ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)//optional parameter use in Views at New.cshtml in Rentals (send by typeahead plugin)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);//IQueryable Object

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);//use Select method to Map Customer object(getFrom_context) to customerDto 
                                                           //Generic <Source,Target> and send delegate to SelectMethod
            return Ok(customerDtos);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer)); //Generic <Source,Target> so its return CustomerDto
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)//IHttpActionResult similar to actionResult it had many HelperMethod
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto); //Generic <Source,Target> so its return Customer

            _context.Customers.Add(customer);
            _context.SaveChanges();//Generate Id to customer

            customerDto.Id = customer.Id;//to show Id when customerDto send back to client
            return Created(new Uri(Request.RequestUri + "/" +customer.Id),customerDto);//RESTFul convention had Uri(Unified Resource Identifier) 
                                                                                       //Uri use  /api/customers/10 || {/api/customers + /10} as parameter   
        }

        //PUT //api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb==null)
                return NotFound();


            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);//We have existing object(customerInDb) so we can use overload method to set customerInDb
                                                                         //And DBContext must be able to track changing this object

            /*customerInDb.Name = customerDto.Name;         NO NEED ANYMORE BECAUSE WE DONE IT ON MAPPER!
            customerInDb.BirthDate = customerDto.BirthDate;
            customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;*/
            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
