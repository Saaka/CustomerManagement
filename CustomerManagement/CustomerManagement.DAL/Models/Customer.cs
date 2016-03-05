using CustomerManagement.DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Models
{
    public class Customer : IIdentifiable<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [MaxLength(50)]
        public string Street { get; set; }
        [MaxLength(10)]
        public string HomeNumber { get; set; }
        [MaxLength(10)]
        public string FlatNumber { get; set; }
    }
}
