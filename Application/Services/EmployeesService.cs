 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastruktura.Models;
using Infrastruktura.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeService(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Task <IEnumerable<Employees>> Get() {

            return employeeRepository.GetEmployees();
        }
        
        public async Task<Employees> GetId(int id)
        {
            return await employeeRepository.GetEmployeesById(id);
        }

        public async Task Put(int id, Employees employees)
        {
            await employeeRepository.Put(id, employees);
        }

        public async Task Post(Employees employees)
        {
           await employeeRepository.PostEmployees(employees);
           
        }

        public async Task Delete(int id, bool archive)
        {
            await employeeRepository.DeleteEmployee(id, archive);
        }

        public async Task <IEnumerable<Employees>> GetArchived(bool archived)
        {
            return await employeeRepository.GetArchived(archived);
        }
        public async Task Archive(int id, Employees employees)
        {
            await employeeRepository.Archive(id,employees);
        }
       
    }   
}   
