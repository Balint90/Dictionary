using System;
using System.Collections.Generic;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees =
            {
                new Employee("CEO", "Gwyn", 95, 200),
                new Employee("Manager", "Joe", 35, 25),
                new Employee("HR", "Lora", 32, 21),
                new Employee("Secretary", "Petra", 28, 18),
                new Employee("Lead Developer", "Artorias", 55, 35),
                new Employee("Intern", "Ernest", 22, 8),
            };

            Dictionary<int, string> myDictionary = new Dictionary<int, string>()
            {
                {1,"one" },
                {2,"two"},
                {3,"three" }
            };

            Dictionary<string, Employee> employeesDirectory = new Dictionary<string, Employee>();

            foreach (Employee employee in employees)
            {
                employeesDirectory.Add(employee.Role, employee);
            }

            foreach (KeyValuePair<string, Employee> keyValuePair in employeesDirectory)
            {
                Console.WriteLine(keyValuePair.Key);
                Employee employee = keyValuePair.Value;

                Console.WriteLine("Employee name: {0}", employee.Name);
                Console.WriteLine("Employee role: {0}", employee.Role);
                Console.WriteLine("Employee age: {0}", employee.Age);
                Console.WriteLine("Employee salary: {0}", employee.Salary);
            }

            string keyToUpdate = "HR";
            if (employeesDirectory.ContainsKey(keyToUpdate))
            {
                employeesDirectory[keyToUpdate] = new Employee("HR", "Eleka", 26, 18);
                Console.WriteLine("Employee with Role/Key {0} was updated!", keyToUpdate);
            }
            else
            {
                Console.WriteLine("No employee found with this key {0}", keyToUpdate);
            }

            string key = "CEO";
            if (employeesDirectory.ContainsKey(key))
            {
                Employee emp = employeesDirectory[key];
                Console.WriteLine("Employee name: {0}, role: {1}, salary: {2}", emp.Name, emp.Role, emp.Salary);
            }
            else
            {
                Console.WriteLine("There is no employee with key: {0}", key);
            }

            Employee result = null;

            if (employeesDirectory.TryGetValue("Intern", out result))
            {
                Console.WriteLine("Value retrieved");

                Console.WriteLine("Employee name: {0}", result.Name);
                Console.WriteLine("Employee role: {0}", result.Role);
                Console.WriteLine("Employee age: {0}", result.Age);
                Console.WriteLine("Employee salary: {0}", result.Salary);
            }
            else
            {
                Console.WriteLine("The key does not exist");
            }
        }

        class Employee
        {
            public string Role { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public float Rate { get; set; }

            public float Salary { get
                {
                    return Rate * 8 * 5 * 4 * 12;
                }
            }

            public Employee(string role, string name, int age, float rate)
            {
                this.Role = role;
                this.Name = name;
                this.Age = age;
                this.Rate = rate;
            }
        }
    }
}
