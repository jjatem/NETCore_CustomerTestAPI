using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CustomersAPI.Data;

namespace CustomersAPI.Controllers
{
     [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomersContext _dbContext;

        public CustomerController(CustomersContext dbContext)
        {        
            _dbContext = dbContext;
            this.CustomersDataRepo = new CustomersRepository(this._dbContext);
        }

        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return this.CustomersDataRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public Customer GetById(Int64 id)
        {
            return this.CustomersDataRepo.Find(id);
        }
        private CustomersRepository CustomersDataRepo { get; set; }
    }
}