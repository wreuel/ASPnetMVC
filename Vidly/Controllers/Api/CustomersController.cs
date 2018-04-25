using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }


        //GET /api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Mapper.Map<Customer, CustomerDto>(customer);
            }
        }

        //POST /api/customers
        //[HttpPost]
        public CustomerDto PostCreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {

                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDto.Id = customer.Id;

                return customerDto;
            }
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UdpateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                if(customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

                    /*customerInDb.Name = customerDto.Name;
                    customerInDb.Birthdate = customerDto.Birthdate;
                    customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
                    customerDto.MembershipTypeId = customerDto.MembershipTypeId;*/
                   

                    _context.SaveChanges();
                }
            }
        }

        //DELETE /api/customer/
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }

        }

    }
}
