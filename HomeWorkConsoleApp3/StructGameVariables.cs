using System;

namespace HomeWorkConsoleApp3
{
    public struct StructGameVariables
    {
        public int minGameNumber, maxGameNumber;//Минимальное и максимальное число диапазон генерации игрового числа
        public int minUserTry, maxUserTry; //Минимальное и максимальное число которое можно использовать игрокам в игре
        public int countPlayers; //Количество игроков участвующих в игре
        public int complexityIndex; //Индекс выбранной сложности
        public int gameNumber; //Число сгенерированное для игры
        public int selectPlayerIndex; //Индекс выбранного игрока
        public int aiIndex; //Индекс сложности компьютера

        public bool complexity; //Включает сложность в игре
        public bool aiEnabled; //Включает управление компютером для противников

        /// <summary>
        /// Сброс игровых параметров для последующей игры
        /// </summary>
        public void ResetGame() {
            selectPlayerIndex = 0;
            GenerateGameNumber();
        }

        /// <summary>
        /// Проверка на максимально допустимо выводимое число
        /// </summary>
        public bool GetCheckMaxEnterValue() {
            return gameNumber >= maxUserTry;
        }
        /// <summary>
        /// Получение индекса игрока добавленного на 1 
        /// если позволяет максимальное количесто игроков
        /// </summary>
        /// <returns></returns>
        public int GetAddOneSelectPlayerIndex()
        {
            if ((selectPlayerIndex + 2) <= countPlayers)
            {
                selectPlayerIndex++;
            }
            else {
                selectPlayerIndex = 0;
            }
            return selectPlayerIndex;
        }
        /// <summary>
        /// Установка индекса выбора игрока
        /// </summary>
        /// <param name="index"></param>
        public void SetSelectPlayerIndex(int index)
        {
            selectPlayerIndex = index;
        }

        /// <summary>
        /// Установка включён ли искусственный интелект
        /// </summary>
        /// <param name="state"></param>
        public void SetAiState(bool state) {
            aiEnabled = state;
        }

        /// <summary>
        /// Установка сложности
        /// </summary>
        /// <param name="state"></param>
        public void SetComplexityState(bool state)
        {
            complexity = state;
        }

        /// <summary>
        /// Установка вводимого числа пользователем
        /// </summary>
        /// <param name="min">Минимальное число</param>
        /// <param name="max">Максимальое число</param>
        public void SetUserTryValue(int min, int max)
        {
            minUserTry = min;
            maxUserTry = max;
        }

        /// <summary>
        /// Установка генерируемого числа для игры
        /// </summary>
        /// <param name="min">Минимальное число</param>
        /// <param name="max">Максимальое число</param>
        public void SetGameNumberValue(int min, int max)
        {
            minGameNumber = min;
            maxGameNumber = max;
        }

        /// <summary>
        /// Установка количества игроков
        /// </summary>
        /// <param name="count"></param>
        public void SetCountPlayers(int count)
        {
            countPlayers = count;
        }

        /// <summary>
        /// Установка индекса сложности
        /// </summary>
        /// <param name="index"></param>
        public void SetComplexityIndex(int index)
        {
            complexityIndex = index;
        }

        /// <summary>
        /// Установка числа для игры
        /// </summary>
        /// <param name="value"></param>
        public void SetGameNumber(int value)
        {
            gameNumber = value;
        }

        /// <summary>
        /// Сгенерировать случайное число для игры
        /// </summary>
        public void GenerateGameNumber()
        {
            Random randomize = new();
            gameNumber = randomize.Next(minGameNumber, maxGameNumber);
        }
        /// <summary>
        /// Установка сложности компьютера 0(Лёгкий) или 1(Сложный)
        /// </summary>
        /// <param name=""></param>
        public void SetAiIndex(int index) {
            aiIndex = index;
        }

        /// <summary>
        /// Установка стандартных параметров для игры
        /// </summary>
        public void SetDefault() {
            aiIndex = 0;
            selectPlayerIndex = 0;
            aiEnabled = false;
            complexity = false;
            complexityIndex = 0;
            countPlayers = 2;
            maxGameNumber = 121;
            minGameNumber = 12;
            maxUserTry = 4;
            minUserTry = 1;
            GenerateGameNumber();
        }
    }
}
