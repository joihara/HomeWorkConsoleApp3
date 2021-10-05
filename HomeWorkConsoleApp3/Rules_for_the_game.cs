using System;

namespace HomeWorkConsoleApp3
{
    public class Rules_for_the_game
    {
        /// <summary>
        /// Пункты правил
        /// </summary>
        private string[] rulesArray = new string[] {
            "Количество игроков игроков указыветься от 2 до ...",                                       //0
            "Имена для игроков указываються для каждого игрока",                                        //1
            "Выбирается сложность игры с компьютером",                                                  //2
            "Игроки по очереди выбирают число от 1 до ...",                                             //3
            "Установите диапазон чисел которые могут использовать игроки от 1 до ...",                  //4
            "Установите диапазон чисел которые будут генерировать число для игры 1 до ...",             //5
            "Если после хода игрока очки равняется нулю, то походивший игрок оказывается победителем",  //6
            "Выбирите с кем будете играть (Игра с компьютером или человеком)",                          //7
            "Не вводить число больше установленного т.к. вы можете быть оштрафованны",                  //8
            "После каждого хода очки введённые игроком вычитается из общего количества очков"           //9
        };

        /// <summary>
        /// Получение правил игры
        /// </summary>
        /// <param name="enumTypeWork">Выбранная работа</param>
        /// <returns>Возвращает строку с правилами</returns>
        public string GetRules(EnumTypeWork enumTypeWork) {
            return enumTypeWork switch
            {
                EnumTypeWork.Работа1 => "Правила игры:\n" + 
                $"1){rulesArray[1]}\n" +
                $"2){rulesArray[3]}\n" +
                $"3){rulesArray[6]}\n" +
                $"4){rulesArray[9]}\n" +
                $"!){rulesArray[8]}\n",
                EnumTypeWork.Работа2 => "Правила игры:\n" +
                $"1){rulesArray[5]}\n" +
                $"2){rulesArray[4]}\n" +
                $"3){rulesArray[0]}\n" +
                $"4){rulesArray[1]}\n" +
                $"5){rulesArray[3]}\n" +
                $"6){rulesArray[6]}\n" +
                $"7){rulesArray[9]}\n" +
                $"!){rulesArray[8]}\n",
                EnumTypeWork.Работа3 => "Правила игры:\n" +
                $"1){rulesArray[7]}\n" +
                $"2){rulesArray[2]}\n" +
                $"3){rulesArray[5]}\n" +
                $"4){rulesArray[4]}\n" +
                $"5){rulesArray[0]}\n" +
                $"6){rulesArray[1]}\n" +
                $"7){rulesArray[3]}\n" +
                $"8){rulesArray[6]}\n" +
                $"9){rulesArray[9]}\n" +
                $"!){rulesArray[8]}\n",
                _ => "Недостижимый Код"
            };
        }

        public void PrintRules(int TypeWork)
        {
            var valuesAsArraySelectWork = Enum.GetValues(typeof(EnumTypeWork));
            string rules = GetRules((EnumTypeWork)valuesAsArraySelectWork.GetValue(TypeWork-1));
            Console.WriteLine(rules);
        }
    }
}
