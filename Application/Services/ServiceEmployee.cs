using System.Collections.Generic;
using System.Linq;
using Application.Base;
using Application.Models;
using Domain.Contract;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class ServiceEmployee : Service<Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ServiceEmployee(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _employeeRepository = unitOfWork.EmployeeRepository;
        }

        public List<EmployeeModel> GetAll()
        {
            return _employeeRepository.FindBy().ToList().ConvertAll(x => new EmployeeModel(x));
        }

        public bool Insert(EmployeeModel employee)
        {
            var entity = new Employee
            {
                EmployeName = employee.EmployeName,
                Gender = employee.Gender,
                City = employee.City,
                Designation = employee.Designation,
            };
            _employeeRepository.Add(entity);
            return UnitOfWork.Commit() >= 1;
        }

        public EmployeeModel GetById(int id)
        {
            var employee = _employeeRepository.Find(id);
            return new EmployeeModel(employee);
        }

        public bool Update(EmployeeModel employee)
        {
            var entity = _employeeRepository.Find(employee.Id);
            entity.EmployeName = employee.EmployeName;
            entity.City = employee.City;
            entity.Gender = employee.Gender;
            entity.Designation = employee.Designation;
            
            _employeeRepository.Edit(entity);
            return UnitOfWork.Commit() > 0;
        }

        public bool Delete(EmployeeModel employee)
        {
            var entity = _employeeRepository.Find(employee.Id);
            _employeeRepository.Delete(entity);
            return UnitOfWork.Commit() > 0;
        }
    }
}