using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastruktura.Models;

namespace Infrastruktura.Repositories
{
    public class EmployeeRepository
    {
        private readonly EmployeesDbContext _context;

        public EmployeeRepository(EmployeesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employees>> GetEmployees()
        {
            var a = await _context.Employees.Include(e => e.Positions).ToListAsync();
            return a;

        }

        public async Task<Employees> GetEmployeesById(int id)
        {
            var employees = await _context.Employees.Include(e => e.Positions).FirstOrDefaultAsync(e => e.EmployeeId == id);
            return employees;

        }

        public async Task<IEnumerable<Employees>> GetArchived(bool Archived)
        {

            if (Archived)
            {
                var ArchivedEmployee = from emp in _context.Employees
                                     where emp.Archived == true
                                     select emp;

                return await ArchivedEmployee.Include(e => e.Positions).ToListAsync();
            }
            else
            {
                var archivedEmp = from emp in _context.Employees
                                     where emp.Archived == false
                                     select emp;
                return await archivedEmp.Include(e => e.Positions).ToListAsync();
            }




        }

        public async Task Archive(int id, Employees employee)
        {


            employee.Archived = true;
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task Put(int id, Employees employee)
        {


            var employeeBefore = employee.PositionId;


            try
            {



                var employeeAfter = _context.Employees.Include(e => e.Positions).Where(q => q.EmployeeId == id).Select(x => x.PositionId).SingleOrDefault();
                
                _context.Entry(employee).State = EntityState.Modified;





                if (employeeBefore != employeeAfter)
                {
                    _context.LastPositions.Add(new LastPositions { EmployeeId = employee.EmployeeId, PositionId = employee.PositionId, DateOfEntry = employee.DateOfEntry, DateOfLeave = DateTime.Now });

                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "Wrong ID");
                }
            }
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        public async Task PostEmployees(Employees employees)
        {
            DateTime StartDate = new DateTime(2004, 1, 1);
            DateTime EntryDate = DateTime.Now.Date;
            
            if(employees.DateOfBirth < StartDate && employees.DateOfEntry >= EntryDate)
            {
                _context.Employees.Add(employees);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployee(int id, bool archive)
        {

            var employees = await _context.Employees.FindAsync(id);

            if (archive)
            {
                employees.Archived = true;
            }
            else
            {
                _context.Employees.Remove(employees);
                var predosle = _context.LastPositions.Where(x => x.EmployeeId == id).ToList();
                foreach(var Predosla in predosle)
                {
                    _context.LastPositions.Remove(Predosla);
                }
            }

            await _context.SaveChangesAsync();
        }


    }
}
