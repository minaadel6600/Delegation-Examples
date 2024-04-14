namespace Delegation
{

    class Employee
    {
        public string Name { get; set; }
        public int BasicSalary { get; set; }
        public int Deduction { get; set; }
        public int Bouns { get; set; }
    }



    internal class Program
    {
         
        // delegation to pass parameters and make different calculations 
        delegate int CalculateDelegate(int x, int y);

        //delegate to calculate the salary when employees salary is less than or 2000
        delegate bool ShouldCalculateDelegate(Employee employee);

        // delegate to sum odd numbers only
        delegate bool SumOddDelegate(int num);
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            // generate 100 employees
            for (int i = 0; i < 100; i++)
            {
                employees.Add(new Employee
                    {
                    Name = $"employee {i}",
                    BasicSalary = Random.Shared.Next(1, 5000),
                    Bouns = Random.Shared.Next(1, 5000),
                    Deduction = Random.Shared.Next(1, 5000)
                }
                    );
            }

            // delegate to sum odd numbers only
            OddSumNubers([1, 2, 3, 4, 5, 6], n => n % 2 != 0);

            //delegate to calculate the salary when employees salary is less than or 2000
            CalculateEmpSalary(employees, (emp) => emp.BasicSalary <= 2000);


            // delegation to pass parameters and make different calculations 
            var result = Calculate(2, 30, (x, y) => { return x + y; });

            Console.WriteLine(result); 

        }

        private static void OddSumNubers(int[] arr, SumOddDelegate predicate)
        {
            int res = 0;
            for (int i = 0;i < arr.Length;i++)
            {
                if (predicate(arr[i])) res += arr[i];
            }
            Console.WriteLine(res);
        }

        private static void CalculateEmpSalary(List<Employee> employees , ShouldCalculateDelegate predicate)
        {
            foreach (var emp in employees)
            {
                if (predicate(emp))
                {
                    int salary = emp.BasicSalary + emp.Bouns - emp.Deduction;
                    Console.WriteLine(salary);
                }
            }
        }

        static int Calculate(int x, int y,CalculateDelegate delegatMethod)
        {
            return delegatMethod(x,y);
        }

    }
}
