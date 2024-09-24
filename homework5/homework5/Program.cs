using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Xml.Linq;

namespace homework5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank b1 = new Bank("Alex", 5000, 56287023);
            Console.WriteLine(b1.getInfo());
            b1.deposit(500);
            Console.WriteLine(b1.checkBalance());
            b1.draw(600);



        }
    }
    public class Bank
    {
        public string user;
        public int cash;
        public int usernumber;

        public Bank(string user, int cash, int usernumber)
        {
            this.user = user;
            this.usernumber = usernumber;
            this.cash = cash;
        }
        public int getInfo()
        {
            return cash;
        }
    
        public int checkBalance()
        {
            return cash;
        }
        public void deposit(int amount)
        {

            if (cash >= 0) 
            {
                cash += amount;
                Console.WriteLine($"Счет пополнен на {amount}. Текущий баланс: {cash}");
            }
            else
            {
                Console.WriteLine("Сумма пополнения должна быть больше нуля.");
            }
        }
        public void draw(int amount)
        {
            if (amount > 0)
            {
                if (cash >= amount)
                {
                    cash -= amount;
                    Console.WriteLine($"Снято {amount}. Текущий баланс: {cash}");
                }
                else
                {
                    Console.WriteLine("Недостаточно средств на счете.");
                }
            }
            else
            {
                Console.WriteLine("Сумма снятия должна быть больше нуля.");
            }
        }

    }
}
    

