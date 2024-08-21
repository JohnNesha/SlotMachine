namespace SlotMachine;

class Program
{
    public const double COST_PER_SPIN = 2.00; //Example Cost
    public const int MAX_NUMBER = 9;
    public const char START_SPIN = 'Y';
    public const int VERTICAL_LINES = 3;
    public const int HORIZONTAL_LINES = 3;
    public const char ACCEPTED_KEY = 'Y';
    public static readonly Random RAN_NUM = new Random();

    public enum TypeOfGamePlay
    {
        AllHorizontalLines,
        HorizontalCenterLine,
        AllVerticalLines,
        VerticalCenterLine,
        DiagonalLeftLine,
        DiagonalRightLine,
        AllDiagonalLines
    }

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
            }
            else
            //If player doesn't enter an amount over spin costs player will be advised to enter more money
            {
                Console.WriteLine($"You have entered ${playerMoney}. Please enter more money to begin the game.\n");
                playerMoney = double.Parse(Console.ReadLine());
            }
            //Ask Player what type of line to play
            while (true)
            {
                Console.WriteLine("What type of line or lines would you like to play? Please select an option: " +
                "(0) All Horizontal Lines, " +
                "(1) Horizontal Center Line, " +
                "(2) All Vertical Lines, " +
                "(3) Vertical Center Line, " +
                "(4) Diagonal Left Line, " +
                "(5) Diagonal Right Line, " +
                "(6) All Diagonal lines\n");

                string gameTypeString = Console.ReadLine().ToUpper();
                TypeOfGamePlay gameType;

                if (!Enum.TryParse(gameTypeString, out gameType))
                {
                    Console.WriteLine("Invalid selection. Please choose a valid option.");
                    continue;
                }

                //Player hits Y to start or spin the game 
                Console.WriteLine($"\n\nHit the {ACCEPTED_KEY} button to spin\n");
                char spinButton = char.ToUpper(Console.ReadKey().KeyChar);

                while (spinButton != START_SPIN)
                {
                    //If user enters any other letter or character besides 'Y' 
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

                    if (gameType == TypeOfGamePlay.AllHorizontalLines || gameType == TypeOfGamePlay.HorizontalCenterLine)
                    {
                        //Process Horizontal Wins
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

                    if (gameType == TypeOfGamePlay.AllDiagonalLines)
                    {
                        for (int col = 0; col < slotNumbers.GetLength(0); col++)
                        {
                            bool diagonalMatch = false;

                            for (int row = 0; row < slotNumbers.GetLength(1); row++)
                            {
                                if (slotNumbers[row, col] < 2 && slotNumbers[row, col] == slotNumbers[row + 1, col] && slotNumbers[row, col] == slotNumbers[row + 2, col])
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
                        if (gameType == TypeOfGamePlay.AllVerticalLines || gameType == TypeOfGamePlay.VerticalCenterLine)
                        {
                            for (int col = 0; col < slotNumbers.GetLength(0); col++)
                            {
                                bool columnMatch = false;

                                for (int row = 0; row < slotNumbers.GetLength(1) - 2; row++)
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
                        }

                        if (gameType == TypeOfGamePlay.DiagonalLeftLine || gameType == TypeOfGamePlay.DiagonalRightLine)
                        {
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

                        Console.WriteLine($"Your remainining balance: ${playerMoney}");
                        if (playerMoney < COST_PER_SPIN)
                        {
                            Console.WriteLine("You have run out of money! Better luck next time.");
                        }
                    }
                }
            }
        }
    }
}