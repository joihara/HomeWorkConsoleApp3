using System;

namespace HomeWorkConsoleApp3
{
    class Program
    {
        private static readonly Rules_for_the_game rules_For_The_Game = new();
        private static readonly GameLogics gameLogics = new();

        static void Main(string[] args)
        {
            string textWork = "Выберите работу от 1 до 3 включительно";

            Work(gameLogics.WaitEnterPassAddText(textWork,1,3));
        }

        static void Work(int selectWork) {

            //Вывод правил в консоль
            rules_For_The_Game.PrintRules(selectWork);
            //Выбор задания
            switch (selectWork)
            {
                case 1:
                    gameLogics.Logic1();
                    break;
                case 2:
                    gameLogics.Logic2();
                    break;
                case 3:
                    gameLogics.Logic3();
                    break;
                default:
                    //Недостижимый код
                    break;
            }

            Console.ReadLine();
        }


        
    }
}
