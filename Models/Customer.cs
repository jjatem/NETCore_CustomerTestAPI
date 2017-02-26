using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CustomersAPI.Data
{
    public class Customer
    {
        public Int64 id {get;set;}
        public string customer_name {get;set;}
        public string city {get;set;}
        public string region_state {get;set;}
        
        public DateTime date_added {get;set;}
    }
}