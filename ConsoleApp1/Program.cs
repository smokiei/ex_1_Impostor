using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    /// <summary>
    /// Организации состоит из N сотрудников.
    /// Каждый из сотрудников может владеть информацией о других сотрудниках.
    /// В организации может быть (может не быть) шпион. Это сотрудник, который владеет инфомацией о всех других сотрудниках,
    /// но ни один из сотрудников не владеет инфомацией о нём.

    /// Реализовать метод, в котором проводится поиска шпиона.
    /// Входные аргументы: список сотрудников, массив значений [сотрудник - владеет информацией о -сотруднике]
    /// В случае, если шпион не найден вернуть null, иначе инфо о сотруднике-шпионе.
    /// </summary>
    class Program
    {
        class Employee
        {
            public int Id { get; set; }
            public string Fio { get; set; }
        }

        class EmployeeFamiliarness
        {
            public Employee Iam { get; set; }
            public Employee FamiliarWith { get; set; }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var employees = new List<Employee>
            {
                new Employee{ Id = 0, Fio = "Max"},
                new Employee{ Id = 1, Fio = "Kostya"},
                new Employee{ Id = 2, Fio = "Katya"},
                new Employee{ Id = 3, Fio = "Sonya"},
                new Employee{ Id = 4, Fio = "Andrey"},
                new Employee{ Id = 5, Fio = "Impostor"}
            };

            var familiarness = new List<EmployeeFamiliarness> {
                new EmployeeFamiliarness{Iam = employees[0], FamiliarWith = employees[1] },
                new EmployeeFamiliarness{Iam = employees[0], FamiliarWith = employees[2] },
                new EmployeeFamiliarness{Iam = employees[1], FamiliarWith = employees[0] },
                new EmployeeFamiliarness{Iam = employees[1], FamiliarWith = employees[3] },
                new EmployeeFamiliarness{Iam = employees[1], FamiliarWith = employees[4] },
                new EmployeeFamiliarness{Iam = employees[2], FamiliarWith = employees[0] },
                new EmployeeFamiliarness{Iam = employees[3], FamiliarWith = employees[1] },
                new EmployeeFamiliarness{Iam = employees[3], FamiliarWith = employees[4] },
                new EmployeeFamiliarness{Iam = employees[4], FamiliarWith = employees[3] },
                new EmployeeFamiliarness{Iam = employees[5], FamiliarWith = employees[0] },
                new EmployeeFamiliarness{Iam = employees[5], FamiliarWith = employees[1] },
                new EmployeeFamiliarness{Iam = employees[5], FamiliarWith = employees[2] },
                new EmployeeFamiliarness{Iam = employees[5], FamiliarWith = employees[3] },
                new EmployeeFamiliarness{Iam = employees[5], FamiliarWith = employees[4] },

            };

            printFamiriarness(familiarness);
            var impostor = findImpostor_BruteForce(employees, familiarness);
            Console.WriteLine("------------------");
            Console.WriteLine("Impostor is {0}", impostor == null ? "not found" : impostor.Fio);
        }


        static Employee findImpostor_BruteForce(List<Employee> employees, List<EmployeeFamiliarness> familiarnesses)
        {
            // предположения:
            // 1. в организации может работать только один шпион
            // 2. для этого шпиона количество записей в списке знакомств будет = кол-ву сотрудников - 1 (исключает себя)
            foreach (var empl in employees)
            {
                if (familiarnesses.Count(e => e.Iam == empl) == employees.Count() - 1)
                    return empl;
            }
            return null;
        }

        static void printFamiriarness(List<EmployeeFamiliarness> familiarnesses)
        {
            var sorted = familiarnesses.OrderBy(x => x.Iam.Fio);
            foreach (var empl in sorted)
            {
                Console.WriteLine($"{empl.Iam.Fio}\tfamiliar with\t{empl.FamiliarWith.Fio}");
            }
        }
    }
}
