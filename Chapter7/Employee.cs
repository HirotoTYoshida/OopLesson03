using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Employee(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
