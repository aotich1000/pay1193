﻿using Microsoft.EntityFrameworkCore;
using Pay1193.Entity;
using Pay1193.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay1193.Services.Implement
{
    public class EmployeeService : IEmployee
    {
        private readonly ApplicationDbContext _context;
        private decimal studentLoanAmount;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

       

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            var employee = GetById(id);
            if (employee.StudentLoan == StudentLoan.Yes && totalAmount > 1577)
            {
                studentLoanAmount = (totalAmount - 1577) * 0.09m;
            }
            else
            {
                studentLoanAmount = 0;
            }
            return studentLoanAmount;
        }

        public decimal UnionFee(int id)
        {
            var employee = GetById(id);
            var fee = employee.UnionMember == UnionMember.Yes ? 10m : 0;
            return fee;
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public Task UpdateById(int id)
        {
            throw new NotImplementedException();
        }

        public dynamic GetAllEmployeeForPayroll()
        {
            throw new NotImplementedException();
        }

        public object UnionFees(int employeeId)
        {
            throw new NotImplementedException();
        }

        public dynamic GetAllEmployeesForPayroll()
        {
            throw new NotImplementedException();
        }
    }
}
