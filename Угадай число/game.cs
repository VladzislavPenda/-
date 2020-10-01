using System;
using System.Collections.Generic;
using System.Text;

namespace Угадай_число
{
    class game
    {
        public void game_menu()
        {
            Console.WriteLine("Выберите режим игры");
            Console.WriteLine("1) Компьютер угадывает число");
            Console.WriteLine("2) Человек угадывает число");
            Console.WriteLine("3) Выход");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": computer_mod();  break;
                case "2": people_mod(); break;
                case "3": Environment.Exit(1); break;
                default: game_menu(); break;
            }
        }

        public void computer_mod()
        {
            int searchingNumber = NumberGenerationByPerson();
            Console.WriteLine("Компьютер начал подбор");
            int max = 100, min = 0, counter = 0;
            while(true)
            {
                counter++;
                Console.WriteLine($"Попытка №{counter}");
                int testNumber = (max + min) / 2;
                if (testNumber == searchingNumber)
                {
                    Console.WriteLine("Ура, компьтер угадал, возвращаемся обратно в меню\n");
                    Console.ReadLine();
                    Console.Clear();
                    game_menu();
                }
                else if (testNumber < searchingNumber)
                {
                    Console.WriteLine($"Загаданное число больше чем {testNumber}");
                    min = testNumber;
                }
                else
                {
                    Console.WriteLine($"Загаданное число меньше чем {testNumber}");
                    max = testNumber;
                }
            }
        }
        public void people_mod()
        {
            int searchingNumber = NumberGenerationByComputer();
            Console.WriteLine("Число загадано, угадывайте");
            string testNumber;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Попытка №{i + 1}");
                testNumber = Console.ReadLine();
                int intTestNumber = int.Parse(testNumber);
                if (intTestNumber == searchingNumber)
                {
                    Console.WriteLine("Ура, вы угадали, возвращаемся обратно в меню\n");
                    Console.ReadLine();
                    Console.Clear();
                    game_menu();
                }
                else if (intTestNumber < searchingNumber)
                {
                    Console.WriteLine($"Загаданное число больше чем {intTestNumber}");
                }
                else
                {
                    Console.WriteLine($"Загаданное число меньше чем {intTestNumber}");
                }
            }
            Console.WriteLine("Попытки закончились, вы проиграли");
            Console.ReadLine();
            Console.Clear();
            game_menu();
        }
        private int NumberGenerationByPerson()
        {
            Console.WriteLine("Загадайте число от 0 до 100");
            string number = Console.ReadLine();
            int res = int.Parse(number);
            if (res <= 100 && res >= 0)
            {
                return res;
            }
            else
            {
                Console.WriteLine("Введите число правильно");
                return NumberGenerationByPerson();
            }
            
        }
        private int NumberGenerationByComputer()
        {
            Random rnd = new Random();
            int res = rnd.Next(0, 100);
            Console.WriteLine(res);
            return res;
        }
    }
}
