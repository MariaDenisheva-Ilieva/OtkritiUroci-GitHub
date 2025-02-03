using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Doctor
    {
        private string name;
        private int age;
       
        //Статично поле
        private static string hospitalName;
        
        //Свойства
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        //Свойство на статичното поле
        public static string HospitalName
        {
            get { return hospitalName; }
            set { hospitalName = value; }
        }

        //Статичен метод
        public static string HospitalName1()
        {
            return hospitalName;
        }

        //void метод
        public void Print()
        {
            Console.WriteLine("The name is: {0}, the age is: {1}", name, age);
        }
    }
}
