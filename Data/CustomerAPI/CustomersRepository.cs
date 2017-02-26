using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomersAPI.Data
{
    public class CustomersRepository
    {
        private readonly CustomersContext _context;

        public CustomersRepository(CustomersContext context)
        {
            _context = context;            
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.customer.ToList();
        }

        public void Add(Customer customer)
        {
            _context.customer.Add(customer);
            _context.SaveChanges();
        }

        public Customer Find(Int64 key)
        {
            return _context.customer.FirstOrDefault(t => t.id == key);
        }

        public void Remove(Int64 key)
        {
            var entity = _context.customer.First(t => t.id == key);
            _context.customer.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.customer.Update(customer);
            _context.SaveChanges();
        }
    }
}