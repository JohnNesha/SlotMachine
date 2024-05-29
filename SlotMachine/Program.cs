namespace SlotMachine;

class Program
{
    public const double COST_PER_SPIN = 2.00;
    public const int MAX_NUMBER = 9;
    public const char START_SPIN = 'Y';
    public const int VERTICAL_LINES = 3;
    public const int HORIZONTAL_LINES = 3;
    public const char ACCEPTED_KEY = 'Y';
    public const int FIRST_NUM = 0;
    public const int SECOND_NUM = 1;
    public const int THIRD_NUM = 2;
    public static readonly Random RAN_NUM = new Random();

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
        //Player hits Y to start or spin the game 
        Console.WriteLine($"Hit the {ACCEPTED_KEY} button to spin\n");
        char spinButton = char.ToUpper(Console.ReadKey().KeyChar);

        while (spinButton != START_SPIN)
        {
            //If user enters any other letter or character besides 'Y' or 'y
            Console.WriteLine($"\nInvalid character chosen. Please hit {ACCEPTED_KEY} to spin\n");
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
                for (int row = 0; row < slotNumbers.GetLength(1); row++)
                {
                    bool match = false;
                    for (int col = 0; col < slotNumbers.GetLength(0); col++)
                    {
                        if (slotNumbers[row,FIRST_NUM] == slotNumbers[row,SECOND_NUM])
                        {
                            if (match)
                                break;
                        }

                        match = true;
                        {
                            Console.WriteLine("\nYou got three in a row! You win!", row + 1);
                            playerMoney += COST_PER_SPIN;
                            numberOfWins++;
                            amountWon++;
                            break;
                        }
                    }
                }
        
                    else
                    {
                        Console.WriteLine("\n\nTry Again.\n");
                        Console.WriteLine("Hit the 'Y' button to spin again\n");
                        Console.ReadKey();
                    }

                }
                for (int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                    bool match = false;
                    for (int row = 0; row < slotNumbers.GetLength(1); row++)
                    {  
                    if (match)
                    break;
                    }

                    match = true;
                        
                    {
                        Console.WriteLine("\nYou got three in a row! You win!", col + 1);
                        playerMoney += COST_PER_SPIN;
                        numberOfWins++;
                        amountWon++;
                        break;
                    }
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
}
