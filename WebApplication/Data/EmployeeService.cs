using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Services;
using Domain.Contract;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Data
{
    public class EmployeeService
    {
        #region Property

        private readonly ServiceEmployee _employeeService;
        #endregion

        #region Constructor
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _employeeService = new ServiceEmployee(unitOfWork);
        }
        #endregion

        #region Get List of Employees
        public List<EmployeeModel> GetAllEmployees()
        {
            return _employeeService.GetAll();
        }
        #endregion

        #region Insert Employee
        public bool InsertEmployee(EmployeeModel employee)
        {
            return _employeeService.Insert(employee);
        }
        #endregion

        #region Get Employee by Id
        public EmployeeModel GetEmployee(int Id)
        {
            return _employeeService.GetById(Id);
        }
        #endregion

        #region Update Employee
        public bool UpdateEmployee(EmployeeModel employee)
        {
            return _employeeService.Update(employee);
        }
        #endregion

        #region DeleteEmployee
        public bool DeleteEmployee(EmployeeModel employee)
        {
            return _employeeService.Delete(employee);
        }
        #endregion
    }
}