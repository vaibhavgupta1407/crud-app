using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class employee
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="* Name can't be blank.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* City can't be blank.")]
        public string City { get; set; }
        [Required(ErrorMessage = "* Name can't be blank.")]
        public string State { get; set; }
        [Required(ErrorMessage = "* State can't be blank.")]
        public decimal Salary { get; set; }
    }
    
}
