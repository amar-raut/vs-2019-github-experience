using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Db.DBOperations
{
    public class EmployeeRepository
    {

        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities())
            {
                Employee emp = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Code = model.Code,

                    Address = new Address()
                    {
                        Details = model.Address.Details,
                        State = model.Address.State,
                        Country = model.Address.Country

                    }
                };

                context.Employee.Add(emp);

                context.SaveChanges();

                return emp.Id;
            }

        }


        public List<EmployeeModel> GetAllEmployee()
        {


            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.Id,
                     //   AddressId = x.AddressId,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Code = x.Code,
                        Email = x.Email,

                        Address = new AddressModel()
                        {
                       //     Id = x.Address.Id,
                            Country = x.Address.Country,
                            Details = x.Address.Details,
                            State = x.Address.State

                        }
                    }
                ).ToList();

                return result;
            }



        }
        public EmployeeModel GetEmployee(int id)
        {


            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .Where(x => x.Id == id)
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.Id,
                        AddressId = x.AddressId,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Code = x.Code,
                        Email = x.Email,

                        Address = new AddressModel()
                        {
                            Id = x.Address.Id,
                            Country = x.Address.Country,
                            Details = x.Address.Details,
                            State = x.Address.State

                        }
                    }
                ).FirstOrDefault();

                return result;
            }


        }

        public bool EditEmployee(EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .FirstOrDefault(x => x.Id == model.Id);

                if (result!=null)
                {
                    result.FirstName = model.FirstName;
                    result.LastName = model.LastName;
                    result.Email = model.Email;
                    result.Code = model.Code;
                }

                context.SaveChanges();

                return true;
            }
        }

        public bool DeleteEmployee (int id)
        {
            using (var context=new EmployeeDBEntities())

            { 
                var result = context.Employee
                        .FirstOrDefault(x => x.Id == id);


                if (result != null)
                {
                    context.Employee.Remove(result);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
