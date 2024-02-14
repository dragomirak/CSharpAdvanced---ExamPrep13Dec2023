namespace TheGambler;

public class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[,] gameBoard = new char[size, size];
        int money = 100;
        int currentRow = -1;
        int currentCol = -1;

        for (int row = 0; row < gameBoard.GetLength(0); row++)
        {
            char[] rowArray = Console.ReadLine().ToCharArray();
            for (int col = 0; col < gameBoard.GetLength(1); col++)
            {
                gameBoard[row, col] = rowArray[col];
                if (gameBoard[row, col] == 'G')
                {
                    currentRow = row;
                    currentCol = col;
                }
            }
        }

        bool isJackpotTaken = false;
        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            if (command == "up" && currentRow == 0
                || command == "down" && currentRow == size - 1
                || command == "left" && currentCol == 0
                || command == "right" && currentCol == size - 1)
            {
                Console.WriteLine("Game over! You lost everything!");
                return;
            }

            if (command == "up")
            {
                if (gameBoard[currentRow - 1, currentCol] == '-')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentRow--;
                    gameBoard[currentRow, currentCol] = 'G';
                }
                else if (gameBoard[currentRow - 1, currentCol] == 'W')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentRow--;
                    gameBoard[currentRow, currentCol] = 'G';
                    money += 100;
                }
                else if (gameBoard[currentRow - 1, currentCol] == 'P')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentRow--;
                    gameBoard[currentRow, currentCol] = 'G';
                    money -= 200;
                    if (money <= 0)
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        return;
                    }
                }
                else if (gameBoard[currentRow - 1, currentCol] == 'J')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentRow--;
                    gameBoard[currentRow, currentCol] = 'G';
                    money += 100000;
                    isJackpotTaken = true;
                    break;
                }
            }
            else if (command == "down")
            {
                if (gameBoard[currentRow + 1, currentCol] == '-')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentRow++;
                    gameBoard[currentRow, currentCol] = 'G';
                }
                else if (gameBoard[currentRow + 1, currentCol] == 'W')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentRow++;
                    gameBoard[currentRow, currentCol] = 'G';
                    money += 100;
                }
                else if (gameBoard[currentRow + 1, currentCol] == 'P')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentRow++;
                    gameBoard[currentRow, currentCol] = 'G';
                    money -= 200;
                    if (money <= 0)
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        return;
                    }
                }
                else if (gameBoard[currentRow + 1, currentCol] == 'J')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentRow++;
                    gameBoard[currentRow, currentCol] = 'G';
                    money += 100000;
                    isJackpotTaken = true;
                    break;
                }
            }
            else if (command == "left")
            {
                if (gameBoard[currentRow, currentCol - 1] == '-')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentCol--;
                    gameBoard[currentRow, currentCol] = 'G';
                }
                else if (gameBoard[currentRow, currentCol - 1] == 'W')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentCol--;
                    gameBoard[currentRow, currentCol] = 'G';
                    money += 100;
                }
                else if (gameBoard[currentRow, currentCol - 1] == 'P')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentCol--;
                    gameBoard[currentRow, currentCol] = 'G';
                    money -= 200;
                    if (money <= 0)
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        return;
                    }
                }
                else if (gameBoard[currentRow, currentCol - 1] == 'J')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentCol--;
                    gameBoard[currentRow, currentCol] = 'G';
                    money += 100000;
                    isJackpotTaken = true;
                    break;
                }
            }
            else if (command == "right")
            {
                if (gameBoard[currentRow, currentCol + 1] == '-')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentCol++;
                    gameBoard[currentRow, currentCol] = 'G';
                }
                else if (gameBoard[currentRow, currentCol + 1] == 'W')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentCol++;
                    gameBoard[currentRow, currentCol] = 'G';
                    money += 100;
                }
                else if (gameBoard[currentRow, currentCol + 1] == 'P')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentCol++;
                    gameBoard[currentRow, currentCol] = 'G';
                    money -= 200;
                    if (money <= 0)
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        return;
                    }
                }
                else if (gameBoard[currentRow, currentCol + 1] == 'J')
                {
                    gameBoard[currentRow, currentCol] = '-';
                    currentCol++;
                    gameBoard[currentRow, currentCol] = 'G';
                    money += 100000;
                    isJackpotTaken = true;
                    break;
                }
            }

        }

        if (isJackpotTaken)
        {
            Console.WriteLine("You win the Jackpot!");
            Console.WriteLine($"End of the game. Total amount: {money}$");
        }
        else
        {
            Console.WriteLine($"End of the game. Total amount: {money}$");
        }

        for (int row = 0; row < gameBoard.GetLength(0); row++)
        {
            for (int col = 0; col < gameBoard.GetLength(1); col++)
            {
                Console.Write(gameBoard[row, col]);
            }

            Console.WriteLine();
        }
    }
}