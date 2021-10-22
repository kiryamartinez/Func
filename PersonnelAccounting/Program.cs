using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelAccounting
{
    class Program
    {
        static void Main(string[] args)
        {
            bool working = true;
            string[,] dossier ={{"Иван","Директор"}};
            NewDossier(ref dossier,"Катя","Менеджер");
            while (working)
            {
                Console.WriteLine("Выберите действие: \n 1-Добавить досье. \n 2-Вывести все досье. \n 3-Удалить досье. \n 4-Поиск по именя. \n 5-Выход ");
                int userInpuct = Convert.ToInt32(Console.ReadLine());
                switch (userInpuct)
                {
                    case 1:
                        Console.Write("Введите имя: ");
                        string newName = Console.ReadLine();
                        Console.Write("Введите должность: ");
                        string newPosition = Console.ReadLine();
                        NewDossier(ref dossier, newName, newPosition);
                        break;
                    case 2:
                        AllDossier(dossier);
                        break;
                    case 3:
                        Console.Write("Введите имя досье которого хотите удалить: ");
                        string removeName = Console.ReadLine();
                        DeleeteDossier(ref dossier, removeName);
                        break;
                    case 4:
                        Console.Write("Введите имя: ");
                        string findName = Console.ReadLine();
                        FindPosition(dossier, findName);
                        break;
                    case 5:
                        working = false;
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void FindPosition(string[,] dossier, string findName)
        {
            for (int i = 0; i < dossier.GetLength(0); i++)
            {
                for (int j = 0; j < dossier.GetLength(1); j++)
                {
                    if (dossier[i, j] == findName)
                    {
                        Console.WriteLine($"{dossier[i, j]} - {dossier[i, j + 1]}");
                    }
                }
            }
        }
        static void DeleeteDossier(ref string[,] dossier, string removeName)
        {
            for (int i = 0; i < dossier.GetLength(0); i++)
            {
                for (int j = 0; j < dossier.GetLength(1); j++)
                {
                    if (dossier[i, j] == removeName)
                    {
                        RemoveAt(ref dossier, removeName);
                        break;
                    }
                }
            }
        }
        static void AllDossier(string[,] dossier)
        {
            for (int i = 0; i < dossier.GetLength(0); i++)
            {
                for (int j = 0; j < dossier.GetLength(1); j++)
                {
                    Console.Write("-" + dossier[i, j]);
                }
                Console.WriteLine(";");
            }
        }
        static void RemoveAt(ref string[,] dossier, string removeName)
        {
            int removeIndex = -1;
            string[,] newArray = new string[dossier.GetLength(0) - 1, dossier.GetLength(1)];
            for (int i = 0; i < dossier.GetLength(0); i++)
            {
                for (int j = 0; j < dossier.GetLength(1); j++)
                {
                    if (dossier[i, j] == removeName)
                    {
                        removeIndex = i;
                    }
                }
            }
            if (removeIndex >-1)
            {
                for (int i = 0; i < removeIndex; i++)
                {
                    for (int j = 0; j < removeIndex; j++)
                    {
                        newArray[i, j] = dossier[i, j];
                    }
                }
                for (int i = removeIndex +1; i < dossier.GetLength(0); i++)
                {
                    for (int j = removeIndex +1; j < dossier.GetLength(1); j++)
                    {
                        newArray[i, j] = dossier[i, j];
                    }
                }
            }
            dossier = newArray;
            Console.WriteLine("Досье удалено");
        }
        static void NewDossier(ref string[,] dossier, string name, string position)
        {
            string[,] newArray = new string [dossier.GetLength(0) + 1, dossier.GetLength(1)];
            for (int i = 0; i < dossier.GetLength(0); i++)
            {
                for (int j = 0; j < dossier.GetLength(1); j++)
                {
                    newArray[i,j] = dossier[i,j];
                }
            }
            newArray[newArray.GetLength(0) - 1 , newArray.GetLength(1) - 2] = name;
            newArray[newArray.GetLength(0) - 1  , newArray.GetLength(1) - 1] = position;
            dossier = newArray;
        }
    }
}
