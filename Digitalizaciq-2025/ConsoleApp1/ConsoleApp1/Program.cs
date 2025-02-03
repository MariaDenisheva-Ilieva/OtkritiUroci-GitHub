using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor1 = new Doctor();
            doctor1.Name = "Ivan";
            doctor1.Age = 50;
            doctor1.Print();

            Doctor.HospitalName = "Ivan Rilski";
            Doctor.HospitalName1();

            Doctor doctor2 = new Doctor();
            doctor2.Name = "Milena";
            doctor2.Age = 62 ;
            doctor2.Print();

            Doctor.HospitalName1();
        }
    }
}
