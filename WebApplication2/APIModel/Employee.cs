using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.APIModel
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public byte Gender { get; set; }
        public decimal Salary { get; set; }

        public string ProfileImage { get; set; }

        public string Address { get; set; }

        public Telephone Telephone { get; set; }
    }

    public class Telephone
    {
        public int WorkContact { get; set; }
        public int Mobile { get; set; }
    }
}