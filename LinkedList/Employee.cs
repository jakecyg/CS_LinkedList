using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Employee : IComparable<Employee>
    {
        internal int EmployeeID { get; }
        internal string FirstName { get; }
        internal string LastName { get; }

        public Employee(int employeeId, string firstName = null, string lastName = null)
        {
            this.EmployeeID = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int CompareTo(Employee other) => EmployeeID.CompareTo(other.EmployeeID);

        public override string ToString() => $"{EmployeeID} {(FirstName ?? "null")} {(LastName ?? "null")}";

    }
}
