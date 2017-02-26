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
        public CustomersRepository CustomersDataRepo { get; set; }
    }
}