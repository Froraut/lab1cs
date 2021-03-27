using System;

namespace lab1cs
{
    class Program
    {
        public static void GameField(char[] NField)
        {
            const string line = "-+-+-";
            const string vert = "|";
            Console.WriteLine($"{NField[0]}{vert}{NField[1]}{vert}{NField[2]}");
            Console.WriteLine(line);
            Console.WriteLine($"{NField[3]}{vert}{NField[4]}{vert}{NField[5]}");
            Console.WriteLine(line);
            Console.WriteLine($"{NField[6]}{vert}{NField[7]}{vert}{NField[8]}");
        }
        public static bool DeterminWinner(char Empty, char[] NField, bool Game, int turn, int counter)
        {
            const char X = 'X';
            const char O = 'O';
            int player, number, n;
            string s;
            bool mark = true;
            player = (turn % 2) + 1;

            do
            {
                try
                {
                    Console.WriteLine("Игрок " + player + " выберите клетку от 1 до 9: ");
                    s = Console.ReadLine();
                    n = Convert.ToInt32(s);
                    number = n - 1;

                    if ((number >= 0) && (number <= 8))
                    {
                        if (NField[number] == Empty)
                        {
                            if (player == 1)
                            {
                                NField[number] = X;
                                counter = 0;
                            }
                            else
                            {
                                NField[number] = O;
                                counter = 0;
                            }
                            mark = false;
                        }
                        else
                        {
                            if (counter == 2)
                            {
                                Console.WriteLine("И снова ошибка... Может давайте играть, а не искать баги :) ? ");
                                counter += 1;

                            }
                            else if (counter == 3)
                            {
                                Console.WriteLine("И снова ошибка... А я думал мы тут собрались чтобы поиграть :( ");
                                counter += 1;
                            }
                            else if (counter == 4)
                            {
                                Console.WriteLine("И снова ошибка... :( ");
                                counter = 0;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка. Выбранная клетка занята.");
                                counter += 1;
                            }
                        }
                    }

                    else if ((number < 0) || (number > 8))
                    {
                        if (counter == 2)
                        {
                            Console.WriteLine("И снова ошибка... Может давайте играть, а не искать баги :) ? ");
                            counter += 1;
                        }
                        else if (counter == 3)
                        {
                            Console.WriteLine("И снова ошибка... А я думал мы тут собрались чтобы поиграть :( ");
                            counter += 1;
                        }
                        else if (counter == 4)
                        {
                            Console.WriteLine("И снова ошибка... :( ");
                            counter = 0;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. Введите номер клетки от 0 до 9.");
                            counter += 1;
                        }
                    }
                }
                catch (FormatException)
                {
                    if (counter == 2)
                    {
                        Console.WriteLine("И снова ошибка... Может давайте играть, а не искать баги :) ? ");
                        counter += 1;
                    }
                    else if (counter == 3)
                    {
                        Console.WriteLine("И снова ошибка... А я думал мы тут собрались чтобы поиграть :( ");
                        counter += 1;
                    }
                    else if (counter == 4)
                    {
                        Console.WriteLine("И снова ошибка... :( ");
                        counter = 0;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка формата ввода. Введите номер клетки от 0 до 9.");
                        counter += 1;
                    }
                }
            }
            while (mark);

            Game = (Empty != NField[0]) && (NField[0] == NField[1]) && (NField[1] == NField[2]) ||
                   (Empty != NField[3]) && (NField[3] == NField[4]) && (NField[4] == NField[5]) ||
                   (Empty != NField[6]) && (NField[6] == NField[7]) && (NField[7] == NField[8]) ||
                   (Empty != NField[0]) && (NField[0] == NField[3]) && (NField[3] == NField[6]) ||
                   (Empty != NField[1]) && (NField[1] == NField[4]) && (NField[4] == NField[7]) ||
                   (Empty != NField[2]) && (NField[2] == NField[5]) && (NField[5] == NField[8]) ||
                   (Empty != NField[0]) && (NField[0] == NField[4]) && (NField[4] == NField[8]) ||
                   (Empty != NField[2]) && (NField[2] == NField[4]) && (NField[4] == NField[6]);

            GameField(NField);
            if (Game)
                Console.WriteLine("Победил игрок " + player);
            else if (turn == 8)
            {
                Game = true;
                Console.WriteLine("Ничья");
            }
            return Game;
        }

        static void Training()
        {
            Console.WriteLine("Дорогие игроки, добро пожаловать в игру Крестики - Нолики! Правила в ней довольно просты. Каждый игрок ходит по очереди крестиками и ноликами. " +
                "Побеждает тот кто первый выставит в ряд по вертикали, горизонтали или диагонали 3 своих фигуры. \nКак у нас считается номер клеточки который надо вводить показано на иллюстрации внизу:\n" +
                "\n1|2|3" +
                "\n-+-+-" +
                "\n4|5|6" +
                "\n-+-+-" +
                "\n7|8|9\n" +
                "\nВам требуется лишь вводить номер клетки куда вы хотите поставить свою фигуру. Желаю вам удачи и побольше побед!\n" +
                "\nИГРА НАЧАЛАСЬ:\n");
        }
        static void Main(string[] args)
        {
            const char empty = ' ';
            char[] Field = new char[9];
            int turn = 0, counter = 0;
            bool game = false;
            Training();
            Array.Fill(Field, empty);
            GameField(Field);
            while (game == false)

            {
                game = DeterminWinner(empty, Field, game, turn, counter);
                turn += 1;
            }

        }
    }
}