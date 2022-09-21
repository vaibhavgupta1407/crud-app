using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models.Cascade
{
    public class State
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Country Country { get; set; }
    }
}
