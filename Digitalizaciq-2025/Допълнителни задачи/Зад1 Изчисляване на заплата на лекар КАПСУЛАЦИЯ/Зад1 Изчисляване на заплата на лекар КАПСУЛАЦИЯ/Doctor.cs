using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад1_Изчисляване_на_заплата_на_лекар_КАПСУЛАЦИЯ
{
    class Doctor
    {
        // Private fields (частни полета)
        private string name; // Name of the doctor (Име на лекаря)
        private string specialization; // Specialization of the doctor (Специализация)
        private int experience; // Years of experience (Години опит)

        // Constructor (Конструктор)
        public Doctor(string name, string specialization, int experience)
        {
            this.name = name;
            this.specialization = specialization;
            this.experience = experience;
        }

        // Public method to calculate salary (Метод за изчисление на заплата)
        public double CalculateSalary()
        {
            double baseSalary = 1500; // Base salary (Основна заплата)
            double experienceBonus = 200; // Bonus per year of experience (Бонус за всяка година опит)

            return baseSalary + (experienceBonus * experience); // Total salary (Обща заплата)
        }

        // Public method to get doctor info (Метод за връщане на информация)
        public string GetDoctorInfo()
        {
            return $"Dr. {name}, Specialization: {specialization}, Experience: {experience} years, Salary: {CalculateSalary():F2} USD";
        }
    }
}
