using Domain.Base;

namespace Domain.Entities
{
    public class Employee : Entity<int>
    {
        public string EmployeName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Designation { get; set; }
    }
}