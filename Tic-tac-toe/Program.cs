using System;

namespace Tic_tac_toe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char player = 'X';

        static void Main(string[] args)
        {
            int turn = 1;
            int input;
            bool inputCorrect = true;

            do
            {
                Console.Clear();
                SetBoard();

                if (turn % 2 == 0)
                {
                    player = 'O';
                }
                else
                {
                    player = 'X';
                }

                Console.WriteLine($"Player {player}, choose your position: ");
                while (true)
                {
                    inputCorrect = int.TryParse(Console.ReadLine(), out input);

                    if (inputCorrect && input > 0 && input < 10 && board[input - 1] != 'X' && board[input - 1] != 'O')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a number from 1 to 9 that has not been chosen: ");
                    }
                }

                board[input - 1] = player;
                turn++;

            } while (!CheckWin() && turn <= 9);

            Console.Clear();
            SetBoard();

            if (CheckWin())
            {
                Console.WriteLine($"Player {player} won!");
            }
            else
            {
                Console.WriteLine("Draw!");
            }

            Console.ReadLine();
        }

        static void SetBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]} ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]} ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]} ");
            Console.WriteLine("     |     |      ");
        }

        static bool CheckWin()
        {
            // Horizontal wins
            if (board[0] == board[1] && board[1] == board[2] ||
                board[3] == board[4] && board[4] == board[5] ||
                board[6] == board[7] && board[7] == board[8])
            {
                return true;
            }

            // Vertical wins
            if (board[0] == board[3] && board[3] == board[6] ||
                board[1] == board[4] && board[4] == board[7] ||
                board[2] == board[5] && board[5] == board[8])
            {
                return true;
            }

            // Diagonal wins
            if (board[0] == board[4] && board[4] == board[8] ||
                board[2] == board[4] && board[4] == board[6])
            {
                return true;
            }

            return false;
        }
    }
}