using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2_statichen_atribut_i_metod
{
    class Person
    {
        public string name;
        public int age;

        //Статичен атрибут
        public static string hair; 

        //Метод void за отпечатване на данните
        public void Print()
        {
            Console.WriteLine("The name is: {0}, the age is: {1}", name, age);
        }

        public static void PrintHair()
        {
            Console.WriteLine("The hair is: {0}", hair);
        }
    }
}
