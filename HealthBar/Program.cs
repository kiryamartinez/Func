using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBar
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 5, maxHealth = 15;
            int mana = 2, maxMana = 15;
            while (true)
            {
                DrawBar(health,maxHealth,ConsoleColor.Red,0);
                DrawBar(mana, maxMana, ConsoleColor.Blue,1);
                Console.SetCursorPosition(0, 5);
                Console.Write("Введите на какое количество хотите изменить жизнь: ");
                int healthChange = Convert.ToInt32(Console.ReadLine());
                if (health + healthChange <= maxHealth && health + healthChange >=0  )
                {
                    health += healthChange;
                }
                Console.Write("Введите на какое количество хотите изменить ману: ");
                int manaChange= Convert.ToInt32(Console.ReadLine());              
                if (mana + healthChange <= maxHealth && mana + healthChange >= 0)
                {
                    mana += healthChange;
                }
                Console.Clear();
            }
        }
        static void DrawBar(int value, int maxValue, ConsoleColor color, int position, char symbol = ' ')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar ="";
            for (int i = 0; i<value; i++)
            {
                bar += symbol;
            }
            Console.SetCursorPosition(0, position);
            Console.Write("{");
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;
            bar = "";
            for (int i=value; i<maxValue; i++)
            {
                bar += symbol;
            }
            Console.Write(bar+"}");
        }
    }
}
