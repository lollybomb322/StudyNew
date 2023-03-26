namespace EmployeesConsoleCommand
{
    class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public Employee(Guid id, string firstName, string lastName, string phoneNumber, string description)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Description = description;
        }
    }
}
