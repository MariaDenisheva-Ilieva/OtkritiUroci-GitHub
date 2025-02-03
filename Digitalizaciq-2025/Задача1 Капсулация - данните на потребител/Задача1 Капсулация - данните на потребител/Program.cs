using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача1_Капсулация___данните_на_потребител
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //Създаване на първи обект, с помощта на конструктор без параметри
                User user1 = new User();
                user1.Username = "Maria";
                user1.Password = "12345";
                user1.PrintUserData();

                //Създаване на втори обект, с помощта на конструктор с параметри
                User user2 = new User("Ivan", "1111");
                user2.PrintUserData();
            }
        }
    }
}
