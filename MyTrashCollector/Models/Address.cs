using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTrashCollector.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Day")]
        public int DayID { get; set; }
        public Day Day { get; set; }


    }
}