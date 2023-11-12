using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpReflectionApp
{

    public interface IMovable
    {
        void Move();
    }

    public interface IWorkable
    {
        void Work();
    }


    public class Employee : IWorkable, IMovable
    {
        int id = -1;

        public string? Name { get; set; }
        public int Age { get; }

        public Employee()
        {
            Name = "Anonim";
            Age = 0;
        }

        public Employee(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Work()
        {
            Console.WriteLine($"{Name} work");
        }

        public void Move()
        {
            Console.WriteLine($"{Name} move");
        }

        public int AgeMult(int mult = 1)
        {
            return Age * mult;
        }

        public override string ToString()
        {
            return $"Employee id:{id} name: {Name}, age: {Age}";
        }
    }
}
