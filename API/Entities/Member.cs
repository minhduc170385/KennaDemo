using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Member
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string City { get; set; }
        public int Age { get; set; }
        
        //public DateTime StartDate { get; set; }
    }
}
