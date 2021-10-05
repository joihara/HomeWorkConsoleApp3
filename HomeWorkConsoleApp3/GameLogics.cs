using System;

namespace HomeWorkConsoleApp3
{
    public class GameLogics
    {
        private StructGameVariables gameVariables;

        public GameLogics() {
            gameVariables.SetDefault();
        }


        #region Логика игры
        /// <summary>
        /// Создание игры на два игрока
        /// </summary>
        public void Logic1() {

            var playersName = EnterNamePlayers();

            //Игра
            bool endGame = false; //Переменная говорящая о том что игра закончена
            if (gameVariables.complexityIndex <= 3) {
                Console.WriteLine($"Число для игры: {gameVariables.gameNumber}");
                Console.ReadLine(); 
            }
            while (!endGame)//цикл выполнения основной логики игры
            {
                Console.Clear();
                var selectPlayer = gameVariables.selectPlayerIndex;

                

                SwitchPlayer(playersName); //Смена игроков пока не завершиться игра
                bool checkEntetMaxvalue = gameVariables.GetCheckMaxEnterValue(); //Проверка на максимально допустимое выводимое число
                int maxUserTry = checkEntetMaxvalue ? gameVariables.maxUserTry : gameVariables.gameNumber;
                
                string addNumberEnterUserTry = $"от {gameVariables.minUserTry} до {maxUserTry}";

                string textEnterUserTry = $"Введите число {(gameVariables.complexityIndex <= 2?addNumberEnterUserTry:"")}";

                int userTry = 0;

                if (gameVariables.aiEnabled && selectPlayer > 0)
                {
                    switch (gameVariables.aiIndex)
                    {
                        case 0:
                            userTry = new Random().Next(gameVariables.minUserTry, maxUserTry);
                            break;
                        case 1:
                            userTry = maxUserTry;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    userTry = WaitEnterPassAddText(textEnterUserTry, gameVariables.minUserTry, maxUserTry);
                }
                

                gameVariables.gameNumber -= userTry; //Вычитание числа введёного игроком из общих баллов

                Console.Clear();

                gameVariables.GetAddOneSelectPlayerIndex();

                endGame = EndGame(playersName, endGame, selectPlayer);
            }
        }

        

        /// <summary>
        /// Повышение уровня сложности игры или увеличение числа игроков
        /// </summary>
        public void Logic2()
        {
            Complexity();
            int playersCount = WaitEnterPassAddText("Введите количество игроков:", 2, 99);
            gameVariables.SetCountPlayers(playersCount);

            Logic1();
        }

        /// <summary>
        /// Реализация игры с компьютером
        /// </summary>
        public void Logic3()
        {
            AiLogic();

            Logic2();
        }
        #endregion
        #region Вспомогательные функции
        /// <summary>
        /// Наказание
        /// </summary>
        public void Complexity()
        {
            string text =
                        "Выберите сложность игры:\n" +
                        "1)Лёгкая\n" +
                        "2)Средняя\n" +
                        "3)Тяжёлая\n" +
                        "4)Адская";
            var readSelectCoplexity = WaitEnterPassAddText(text, 1, 4);
            gameVariables.SetComplexityIndex (readSelectCoplexity);
            gameVariables.SetComplexityState(true);
        }

        /// <summary>
        /// Смена игрока
        /// </summary>
        /// <param name="playersName"></param>
        public void SwitchPlayer(string[] playersName)
        {
            int selectPlayer = gameVariables.selectPlayerIndex;

            if (gameVariables.complexityIndex<=1)
            {
                    Console.WriteLine($"Число: {gameVariables.gameNumber}");
            }

            int NextPlayer = selectPlayer == gameVariables.countPlayers - 1 ? 0 : selectPlayer + 1; //Логика получения имени Следующего игрока

            Console.WriteLine($"Текущий ход игрока> {playersName[selectPlayer]}");
            Console.WriteLine($"Следующий ход игрока>> {playersName[NextPlayer]}");
        }
        /// <summary>
        /// не реализованно
        /// </summary>
        /// <param name="enumTypeComplexity"></param>
        public void AiLogic()
        {
            string textAiState =
                        "Выберите с кем будете играть:\n" +
                        "1)Игроки\n" +
                        "2)Компютеры";
            var readSelectAiState = WaitEnterPassAddText(textAiState, 1, 2);

            bool aiState = readSelectAiState == 2;

            gameVariables.SetAiState(aiState);
            if (aiState)
            {
                string text =
                            "Выберите сложность игры с компютером:\n" +
                            "1)Лёгкая\n" +
                            "2)Тяжёлая";
                var readSelectCoplexity = WaitEnterPassAddText(text, 1, 2);

                gameVariables.SetAiIndex(readSelectCoplexity);
            }
        }

        /// <summary>
        /// Ввод имени для игроков
        /// </summary>
        /// <returns>Массив имён пользователей</returns>
        private string[] EnterNamePlayers()
        {
            string[] playersName = new string[gameVariables.countPlayers];//Создание массива для игроков
            //Ввод имён для игроков
            for (int selectPlayer = 0; selectPlayer < gameVariables.countPlayers; selectPlayer++)
            {
                Console.WriteLine($"Введите имя для игрока №{selectPlayer + 1}");
                playersName[selectPlayer] = Console.ReadLine(); //Чтение строки и запись в массив с игроками имени
            }
            return playersName;
        }

        /// <summary>
        /// Завершение игры с выводом на экран победителя
        /// </summary>
        /// <param name="playersName">Имена игроков</param>
        /// <param name="endGame">Переменная говорящая о том что игра закончена</param>
        /// <param name="selectPlayer">Индекс победившего игрока</param>
        /// <returns></returns>
        private bool EndGame(string[] playersName, bool endGame, int selectPlayer)
        {
            if (gameVariables.gameNumber == 0)
            {
                Console.WriteLine($"Победил игрок {playersName[selectPlayer]}");
                Console.WriteLine($"Вы хотите реванш? Для реванша нажмите кнопку \"Y\"");
                var keyPressedEndGame = Console.ReadKey();//Чтение нажатой кнопки
                if (keyPressedEndGame.Key != ConsoleKey.Y)//Проверка что клавиша Y не нажата
                {
                    endGame = true;
                }
                else //Перезапуск игры
                {
                    gameVariables.ResetGame();
                }
            }

            return endGame;
        }

        /// <summary>
        /// Проверка на правильность введённых данных с клавиатуры
        /// </summary>
        /// <param name="minValue">Минимальное допустимое значение</param>
        /// <param name="maxValue">Максимальное допустимое значение</param>
        /// <returns>Результат чтения строки (null не проходит по условиям)</returns>
        private int? WaitEnterPass(int minValue, int maxValue)
        {
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out int outNumber);
            if (result && outNumber >= minValue && outNumber <= maxValue)
            {
                return outNumber;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Ожидает пока игрок введёт число в правильном диапазоне
        /// </summary>
        /// <param name="text">Текст который выводиться перед тем как ввести число</param>
        /// <param name="minValue">Минимальное допустимое значение</param>
        /// <param name="maxValue">Максимальное допустимое значение</param>
        /// <returns>правильно введенное число</returns>
        public int WaitEnterPassAddText(string text, int minValue, int maxValue)
        {
            while (true)
            {
                Console.WriteLine(text);
                var readNumberOrNull = WaitEnterPass(minValue, maxValue);
                if (readNumberOrNull != null)
                {
                    return (int)readNumberOrNull;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
        }
        #endregion
    }
}
