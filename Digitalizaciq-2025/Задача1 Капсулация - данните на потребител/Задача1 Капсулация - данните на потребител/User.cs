using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача1_Капсулация___данните_на_потребител
{
    class User
    {
        //Капсулация - private полета
        private string username; 
        private string password;

        //Свойства
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        //Конструктор без параметри
        public User()
        {
            this.username = null;
            this.password = null;
        }

        //Конструктор с параметри
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        //void метод - отпечатва данните
        public void PrintUserData()
        {
            Console.WriteLine($"Username: {username}, Password: {password}");
        }
    }
}
