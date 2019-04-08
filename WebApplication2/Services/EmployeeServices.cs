using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication2.ApplicationEnums;
using WebApplication2.APIModel;
using WebApplication2.CommonMethods;
using WebApplication2;
using Employee = WebApplication2.Employee;

#pragma warning disable

namespace WebApplication2.Services
{

    public class EmployeeServices
    {
        private EmployeeContext db = new EmployeeContext();


        public List<WebApplication2.APIModel.Employee> Get()
        {
            var allEmployees = db.Employees.Select(employee => new WebApplication2.APIModel.Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Address = employee.Address,
                Gender = employee.Gender,
                Age = employee.Age,
                Salary = employee.Salary,
                ProfileImage = employee.ProfileImage,
                Telephone = new Telephone
                {
                    WorkContact = employee.WorkContact,
                    Mobile = employee.Mobile
                }
            }).ToList();
            return allEmployees;
        }

        public WebApplication2.APIModel.Employee Get(int id)
        {
            var emp = db.Employees.Where(t => t.Id == id).Select(employee => new WebApplication2.APIModel.Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Address = employee.Address,
                Gender = employee.Gender,
                Age = employee.Age,
                Salary = employee.Salary,
                ProfileImage = employee.ProfileImage,
                Telephone = new Telephone
                {
                    WorkContact = employee.WorkContact,
                    Mobile = employee.Mobile
                }
            }).FirstOrDefault();
            return emp;
        }

        public string Add(WebApplication2.APIModel.Employee employee)
        {
            ValidateEmployee(employee);
            var emp = new Employee
            {
                Name = employee.Name,
                Address = employee.Address,
                Gender = employee.Gender,
                Age = employee.Age,
                Salary = employee.Salary,
                WorkContact = employee.Telephone.WorkContact,
                Mobile = employee.Telephone.Mobile,
                ProfileImage = employee.ProfileImage
            };
            db.Employees.Add(emp);
            db.SaveChanges();
            return "Employee Id:" + emp.Id;
        }

        public void Delete(int id)
        {
            var empToDelete = db.Employees.FirstOrDefault(t => t.Id == id);
            if (empToDelete == null)
            {
                throw new Exception("Employee does not exist.");
            }
            db.Employees.Remove(empToDelete);
            db.SaveChanges();
        }

        public WebApplication2.APIModel.Employee Update(WebApplication2.APIModel.Employee employee)
        {
            ValidateEmployee(employee);
            var emp = db.Employees.Where(t => t.Id == employee.Id).FirstOrDefault();
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Address = employee.Address;
                emp.Gender = employee.Gender;
                emp.Age = employee.Age;
                emp.Salary = employee.Salary;
                emp.WorkContact = employee.Telephone.WorkContact;
                emp.Mobile = employee.Telephone.Mobile;
                emp.ProfileImage = employee.ProfileImage;

                db.SaveChanges();

                return db.Employees.Where(t => t.Id == emp.Id).Select(t => new WebApplication2.APIModel.Employee
                {
                    Id = t.Id,
                    Name = t.Name,
                    Address = t.Address,
                    Gender = t.Gender,
                    Age = t.Age,
                    Salary = t.Salary,
                    ProfileImage = t.ProfileImage,
                    Telephone = new Telephone
                    {
                        WorkContact = t.WorkContact,
                        Mobile = t.Mobile
                    }
                }).FirstOrDefault();
            }
            return null;
        }

        public void ValidateEmployee(WebApplication2.APIModel.Employee employee)
        {
            ValidateName(employee.Name);
            ValidateAge(employee.Age);
            ValidateGender(employee.Gender);
            ValidateSalary(employee.Salary);
            ValidateAddress(employee.Address);
            ValidateImage(employee);
        }

        private static void ValidateImage(WebApplication2.APIModel.Employee employee)
        {
            if (!HelperFunctions.IsBase64String(employee.ProfileImage))
            {
                throw new ValidationException("Invalid Image,Please provide valid Base64 string of image.");
            }
        }

        private static void ValidateSalary(decimal salary)
        {
            if (salary > decimal.MaxValue)
            {
                throw new ValidationException("Invalid Salary");
            }
        }

        private static void ValidateGender(byte gender)
        {
            if ((gender == 0) || (gender > Enum.GetNames(typeof(WebApplication2.ApplicationEnums.Enums.Gender)).Length))
            {
                throw new ValidationException("Invalid Gender");
            }
        }

        private static void ValidateAge(int age)
        {
            if (age == 0)
            {
                throw new ValidationException("Please provide valid age.");
            }
        }

        private static void ValidateName(string name)
        {
            int num;
            if (int.TryParse(name, out num))
            {
                throw new ValidationException("Name can not be a number.");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ValidationException("Name is Empty.");
            }
            if (name.Length > 50)
            {
                throw new ValidationException("Number of character in Employee is greater than 50.");
            }
        }
        private static void ValidateAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ValidationException("Address is Empty.");
            }
            if (address.Length > 150)
            {
                throw new ValidationException("Number of character in Address is greater than 150.");
            }
        }
    }
}