using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2_statichen_atribut_i_metod
{
    class Program
    {
        static void Main(string[] args)
        {
            //Достъпване на статичното поле hair
            Person.hair = "Blond";

            Person person1 = new Person();
            person1.name = "Mimi";
            person1.age = 15;
            person1.Print();

            //Извикване на статичен метод
            Person.PrintHair();

            Person person2 = new Person();
            person2.name = "Lili";
            person2.age = 35;
            person2.Print();

            Person.PrintHair();
        }
    }
}
