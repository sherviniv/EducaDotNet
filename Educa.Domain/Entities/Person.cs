using Educa.Domain.Common;
using Educa.Domain.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Educa.Domain.Entities
{
    public class Person : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public PersonTypes PersonType { get; set; }
    }
}
