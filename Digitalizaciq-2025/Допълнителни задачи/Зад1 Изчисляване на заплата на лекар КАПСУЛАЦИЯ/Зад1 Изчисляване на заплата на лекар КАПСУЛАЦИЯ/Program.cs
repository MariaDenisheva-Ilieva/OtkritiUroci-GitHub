using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад1_Изчисляване_на_заплата_на_лекар_КАПСУЛАЦИЯ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create doctor objects (Създаване на обекти на лекаря)
            Doctor doctor1 = new Doctor("Ivan Petrov", "Cardiologist", 10);
            Doctor doctor2 = new Doctor("Anna Ivanova", "Neurologist", 5);

            // Print doctor information (Извеждане на информация)
            Console.WriteLine(doctor1.GetDoctorInfo());
            Console.WriteLine(doctor2.GetDoctorInfo());
        }
    }
}
