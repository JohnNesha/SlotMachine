﻿namespace SlotMachine;

class Program
{
    public const double COST_PER_SPIN = 2.00; //Example Cost
    public const int MAX_NUMBER = 9;
    public const char START_SPIN = 'Y';
    public const int VERTICAL_LINES = 3;
    public const int HORIZONTAL_LINES = 3;
    public const char ACCEPTED_KEY = 'Y';
    public static readonly Random RAN_NUM = new Random();
    public const char ANY_HORIZONTAL_WIN = 'H';
    public const char ANY_VERTICAL_WIN = 'V';
    public const string HORIZONTAL_CENTER_WIN = "HC";
    public const string VERTICAL_CENTER_WIN = "VC";
    public const char ANY_DIAGONAL_WIN = 'D';
    public const string DIAGONAL_LEFT_WIN = "DL";
    public const string DIAGONAL_RIGHT_WIN = "DR";


    static void Main(string[] args)
    {
        Console.WriteLine("Let's play Slot Machine!\n");
        Console.WriteLine($"Each spin costs ${COST_PER_SPIN}.\n");

        //Amount entered from player to begin the game
        double playerMoney = 0;

        while (true)
        {
            Console.Write("Enter an amount to begin the game: ");
            Console.WriteLine("\n");

            //Read user input
            string userInput = Console.ReadLine();

            if (double.TryParse(userInput, out playerMoney))
            {
                break;
            }
        }

        // double playerMoney = double.Parse(Console.ReadLine());
        while (true)
        {
            if (playerMoney >= COST_PER_SPIN)
            {
                Console.WriteLine($"\nYou have entered ${playerMoney}. Let the games begin!\n");
                break;
            }
            else
            //If player doesn't enter an amount over spin costs player will be advised to enter more money
            {
                Console.WriteLine($"You have entered ${playerMoney}. Please enter more money to begin the game.\n");
                playerMoney = double.Parse(Console.ReadLine());
            }
        }

        //Ask Player what type of line to play
        {
            Console.WriteLine("What type of line or lines would you like to play? Please select an option: " +
            "(H) All Horizontal Lines, " +
            "(HC) Horizontal Center Line, " +
            "(V) All Vertical Lines, " +
            "(VC) Vertical Center Line, " +
            "(DL) Diagonal Left Line, " +
            "(DR) Diagonal Right Line, " +
            "or (D) All Diagonal lines\n");

            char gameType = char.ToUpper(Console.ReadKey().KeyChar);

            //If player enter line choice to play
            if (gameType == ANY_HORIZONTAL_WIN)
            {

            }
        }

        //Player hits Y to start or spin the game 
        Console.WriteLine($"\n\nHit the {ACCEPTED_KEY} button to spin\n");
        char spinButton = char.ToUpper(Console.ReadKey().KeyChar);

        while (spinButton != START_SPIN)
        {
            //If user enters any other letter or character besides 'Y' or 'y
            Console.WriteLine($"\nInvalid character chosen. Please hit {ACCEPTED_KEY} to spin\n");
            spinButton = char.ToUpper(Console.ReadKey().KeyChar);
        }

        Console.WriteLine("\n");

        bool continuePlaying = spinButton == START_SPIN;

        while (continuePlaying)
        {
            playerMoney -= COST_PER_SPIN;

            Console.WriteLine("\nSpinning...");
            Console.WriteLine("\nSpinning...");

            //Insert numbers into 2DArray using Random Numbers
            int numberOfWins = 0;
            double amountWon = 1.00;

            int[,] slotNumbers = new int[VERTICAL_LINES, HORIZONTAL_LINES];

            Console.WriteLine("\n");

            for (int row = 0; row < HORIZONTAL_LINES; row++)
            {
                for (int col = 0; col < VERTICAL_LINES; col++)
                {
                    //Numbers will display after spin 
                    slotNumbers[row, col] = RAN_NUM.Next(1, MAX_NUMBER + 1);
                }

                Console.WriteLine("\n");

                //Print Slot numbers
                for (int col = 0; col < VERTICAL_LINES; col++)
                {
                    Console.Write(slotNumbers[row, col] + " ");
                }
            }
            //Check for one win at a time
            //loops checks each element in array to see if theres a match
            //checks whether first number matches the other two numbers in row
            bool rowMatch = false;

            for (int row = 0; row < slotNumbers.GetLength(1); row++)
            {
                rowMatch = false;

                for (int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                    if (slotNumbers[row, col] == slotNumbers[row + 1, col] && slotNumbers[row + 1, col] == slotNumbers[row + 2, col])
                    {
                        rowMatch = true;
                        Console.WriteLine("\nYou got three in a row! You win!", col + 1);
                        playerMoney += COST_PER_SPIN;
                        numberOfWins++;
                        amountWon++;
                        break;
                    }
                }

                if (rowMatch)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nTry Again.\n");
                    Console.WriteLine($"Hit the {ACCEPTED_KEY} button to spin again\n");
                    Console.ReadKey();
                    break;
                }
            }
            for (int col = 0; col < slotNumbers.GetLength(0); col++)
            {
                bool diagonalMatch = false;

                for (int row = 0; row < slotNumbers.GetLength(1); row++)
                {
                    if (slotNumbers[row,col] < 2 && slotNumbers[row, col] == slotNumbers[row + 1, col] && slotNumbers[row, col] == slotNumbers[row + 2, col])
                    {
                        diagonalMatch = true;
                        Console.WriteLine("\nYou got three in a row diagonally! You win!", col + 1);
                        playerMoney += COST_PER_SPIN;
                        numberOfWins++;
                        amountWon++;
                        break;
                    }
                }

                if (diagonalMatch)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nTry Again.\n");
                    Console.WriteLine($"Hit the {ACCEPTED_KEY} button to spin again\n");
                    Console.ReadKey();
                    break;
                }
            }

            for (int col = 0; col < slotNumbers.GetLength(0); col++)
            {
                bool columnMatch = false;

                for (int row = 0; row < slotNumbers.GetLength(1) -2; row++)
                {

                    if (slotNumbers[row, col] == slotNumbers[row + 1, col] && slotNumbers[row + 1, col] == slotNumbers[row + 2, col])
                    {
                        columnMatch = true;
                        Console.WriteLine("\nYou got three in a row! You win!", col + 1);
                        playerMoney += COST_PER_SPIN;
                        numberOfWins++;
                        amountWon++;
                        break;
                    }
                }

                if (columnMatch)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nTry Again.\n");
                    Console.WriteLine($"Hit the {ACCEPTED_KEY} button to spin again\n");
                    Console.ReadKey();
                    break;
                }
            }

            for (int row = 0; row < slotNumbers.GetLength(1); row++)
            {
                bool diagonalWin = false;

                for (int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                    if (slotNumbers[row, col] == slotNumbers[row + 1, col] && slotNumbers[row, col] == slotNumbers[row + 2, col + 1])
                    {
                        diagonalWin = true;
                        Console.WriteLine("\nYou got three in a row diagonally! You win!", col + 1);
                        playerMoney += COST_PER_SPIN;
                        numberOfWins++;
                        amountWon += COST_PER_SPIN;
                    }
                }

                if (diagonalWin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nTry Again.\n");
                    Console.WriteLine($"Hit the {ACCEPTED_KEY} button to spin again\n");
                    spinButton = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.ReadKey();
                    break;
                }
            }
        }

        Console.WriteLine("You have run out of money! Better luck next time.");
    }
}
