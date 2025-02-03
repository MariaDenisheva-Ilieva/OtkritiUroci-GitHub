using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача2_Статични_атрибути_и_методи_Банкова_система
{
    class Bank
    {
        // Статично поле: Общите средства в банката
        private static double totalFunds = 0;

        // Статичен метод: Добавяне на средства
        public static void AddFunds(double amount)
        {
            if (amount > 0)
            {
                totalFunds += amount;
                Console.WriteLine("Added {0} to the bank. Total funds: {1}", amount, totalFunds);
            }
            else
            {
                Console.WriteLine("The amount must be greater than 0.");
            }
        }

        // Статичен метод: Показване на общите средства
        public static double GetTotalFunds()
        {
            return totalFunds;
        }
    }
}
