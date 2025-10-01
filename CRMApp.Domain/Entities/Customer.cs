using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMApp.Domain.Entities
{
    public class Customer
    {
        public int AccountId { get; set; } // Auto-generated primary key  
        public string FirstName { get; set; } = string.Empty; // Required  
        public string LastName { get; set; } = string.Empty; // Required  
        public string Email { get; set; } = string.Empty; // Required, unique  
        public string? PhoneNumber { get; set; } // Optional  
        public string? Address { get; set; } // Optional  
        public string? City { get; set; } // Optional  
        public string? State { get; set; } // Optional  
        public string? Country { get; set; } // Optional  
        public DateTime DateCreated { get; set; } = DateTime.UtcNow; // Auto-generated  
    }
}

