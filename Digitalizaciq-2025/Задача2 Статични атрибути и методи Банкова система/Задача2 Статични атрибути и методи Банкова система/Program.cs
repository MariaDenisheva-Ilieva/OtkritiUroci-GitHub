using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача2_Статични_атрибути_и_методи_Банкова_система
{
    class Program
    {
        static void Main(string[] args)
        {
            // Добавяне на средства чрез статичния метод
            Bank.AddFunds(500);
            Bank.AddFunds(300);

            // Показване на общите средства
            Console.WriteLine("Total funds in the bank: {0}", Bank.GetTotalFunds());
        }
    } 
}
