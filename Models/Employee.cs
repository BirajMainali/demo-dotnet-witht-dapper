namespace DapperDemo.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int Age { get; protected set; }
        public double Salary { get; protected set; }
        
        protected Employee()
        {
        }

        public Employee(string firstName, string lastName, int age, double salary)
            => Copy(firstName, lastName, age, salary);


        public void Update(string firstName, string lastName, int age, double salary)
            => Copy(firstName, lastName, age, salary);


        private void Copy(string firstName, string lastName, int age, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
    }
}