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

        [HttpPost]
        public IActionResult Create([FromBody] Customer item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            this.CustomersDataRepo.Add(item);

            return CreatedAtRoute("GetTodo", new { id = item.id }, item);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Customer item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            try
            {
                this.CustomersDataRepo.Update(item);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Int64 id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            try
            {
                this.CustomersDataRepo.Remove(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(true);
        }

        private CustomersRepository CustomersDataRepo { get; set; }
    }
}