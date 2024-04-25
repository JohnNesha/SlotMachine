namespace SlotMachine;

class Program
{
    public const double COST_PER_SPIN = 2.00;
    public const int MAX_NUMBER = 9;
    public const char START_SPIN = 'Y';
    public const int VERTICAL_LINE = 3;
    public const int HORIZONTAL_LINE = 3;
    public readonly Random ranNum = new Random();

    static void Main(string[] args)
    {
        Console.WriteLine("Let's play Slot Machine!\n");
        Console.WriteLine("Each spin costs $2.00.\n");

        //Amount entered from player to begin the game
        bool invalidAmount = false;
        double playerMoney = 0;

        while (!invalidAmount)
        {
            Console.Write("Enter an amount to begin the game: ");
            Console.WriteLine("\n");
            string userInput = Console.ReadLine();

            if (double.TryParse(userInput, out playerMoney))
            {
                if (playerMoney >= COST_PER_SPIN)
                {
                    invalidAmount = true;
                }
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
        //Player hits Y to start or spin the game 
        Console.WriteLine("Hit the 'Y' button to spin\n");
        char spinButton = char.ToUpper(Console.ReadKey().KeyChar);

        while (spinButton != START_SPIN)
        {
            //If user enters any other letter or character besides 'Y' or 'y
            if (spinButton != START_SPIN)
            {
                Console.WriteLine("\nInvalid character chosen. Please hit 'Y' to spin\n");
            }
            spinButton = char.ToUpper(Console.ReadKey().KeyChar);
        }

        Console.WriteLine("\n");

        while (playerMoney > 0)
        {
            playerMoney -= COST_PER_SPIN;

            Console.WriteLine("\nSpinning...");
            Console.WriteLine("\nSpinning...");

            //Insert numbers into 2DArray using Random Numbers
            int numberOfWins = 0;
            double amountWon = 1.00;

            int[,] slotNumbers = new int[VERTICAL_LINE, HORIZONTAL_LINE];

            Console.WriteLine("\n");

            for (int i = 0; i < HORIZONTAL_LINE; i++)
            {
                for (int j = 0; j < VERTICAL_LINE; j++)
                {
                    //Numbers will display after spin 
                    slotNumbers[i, j] = ranNum.Next(1, MAX_NUMBER + 1);
                }

                Console.WriteLine("\n");

                //Print Slot numbers
                for (int j = 0; j < VERTICAL_LINE; j++)
                {
                    Console.Write(slotNumbers[i, j] + " ");
                }
            }

            //Check for one win at a time
            for (int i = 0; i < HORIZONTAL_LINE; i++)
            {
                if (i == 0)
                {
                    if (slotNumbers[i, 0] == slotNumbers[i, 1] && slotNumbers[i, 1] == slotNumbers[i, 2])
                    {
                        Console.WriteLine("\nYou got three in a row! You win!", i + 1);
                        playerMoney += COST_PER_SPIN;
                        numberOfWins++;
                        amountWon++;
                        break;
                    }
                }

                else
                {
                    Console.WriteLine("\n\nTry Again.\n");
                    Console.WriteLine("Hit the 'Y' button to spin again\n");
                    Console.ReadKey();
                }

            }
            for (int j = 0; j < HORIZONTAL_LINE; j++)
            {
                if (j == 0)
                {
                    if (slotNumbers[0, j] == slotNumbers[1, j] && slotNumbers[1, j] == slotNumbers[2, j])
                    {
                        Console.WriteLine("\nYou got three in a row! You win!", j + 1);
                        playerMoney += COST_PER_SPIN;
                        numberOfWins++;
                        amountWon++;
                        break;
                    }
                }

                else
                {
                    Console.WriteLine("\n\nTry Again.\n");
                    Console.WriteLine("Hit the 'Y' button to spin again\n");
                    Console.ReadKey();
                }
            }

        }
    }
}
