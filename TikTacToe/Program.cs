using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        char[,] board = new char[3, 3]
        {
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' }
        };

        char currentPlayer = 'X';
        bool gameWon = false;
        bool gameDraw = false;

        while (!gameWon && !gameDraw)
        {
            DisplayBoard(board);
            Console.WriteLine($"Player {currentPlayer}, enter your move (1-9):");
            int move = int.Parse(Console.ReadLine());

            if (MakeMove(board, move, currentPlayer))
            {
                gameWon = CheckWin(board, currentPlayer);
                gameDraw = CheckDraw(board);

                if (gameWon)
                {
                    DisplayBoard(board);
                    Console.WriteLine($"Player {currentPlayer} wins!");
                }
                else if (gameDraw)
                {
                    DisplayBoard(board);
                    Console.WriteLine("It's a draw!");
                }
                else
                {
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }
            }
        }
        
        Console.WriteLine("Game Over");
        Console.ReadLine();
    }


    static bool CheckWin(char[,] board, char player)
    {
        // Check rows, columns, and diagonals
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                (board[0, i] == player && board[1, i] == player && board[2, i] == player))
            {
                return true;
            }
        }
        if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
            (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
        {
            return true;
        }

        return false;
    }

    static bool CheckDraw(char[,] board)
    {
        foreach (char c in board)
        {
            if (c != 'X' && c != 'O')
            {
                return false;
            }
        }
        return true;
    }

    static bool MakeMove(char[,] board, int move, char player)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;

        if (board[row, col] != 'X' && board[row, col] != 'O')
        {
            board[row, col] = player;
            return true;
        }
        else
        {
            Console.WriteLine("Invalid move! Try again.");
            return false;
        }
    }

    static void DisplayBoard(char[,] board)
    {
        Console.Clear();
        Console.WriteLine("  {0} | {1} | {2} ", board[0, 0], board[0, 1], board[0, 2]);
        Console.WriteLine(" ---|---|---");
        Console.WriteLine("  {0} | {1} | {2} ", board[1, 0], board[1, 1], board[1, 2]);
        Console.WriteLine(" ---|---|---");
        Console.WriteLine("  {0} | {1} | {2} ", board[2, 0], board[2, 1], board[2, 2]);
    }

}