using Domain.Entities;

namespace Application.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string EmployeName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Designation { get; set; }

        public EmployeeModel(Employee employee)
        {
            Id = employee.Id;
            EmployeName = employee.EmployeName;
            Gender = employee.Gender;
            City = employee.City;
            Designation = employee.Designation;
        }

        public EmployeeModel()
        {
            
        }
    }
}