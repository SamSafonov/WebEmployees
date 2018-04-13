using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEmployees.Models
{
    public class Position
    {
        public int PositionID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}