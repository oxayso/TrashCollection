using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTrashCollector.Models
{
    public class Customer
    {
        public int Id  { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

    }
}