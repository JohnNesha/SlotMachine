namespace SlotMachine;

class Program
{
    public const double COST_PER_SPIN = 2.00;
    public const int MAX_NUMBER = 9;
    public const char START_SPIN = 'Y';

    static void Main(string[] args)
    {
            Console.WriteLine("Let's play Slot Machine!\n");
            Console.WriteLine("Each spin costs $2.00. Enter the amount of money you would like to play with: \n");

            //Amount entered from player to begin the game
            double playerMoney = double.Parse(Console.ReadLine());

        while (true)
        {
            if (playerMoney >= COST_PER_SPIN)
            {
                Console.WriteLine($"You have entered ${playerMoney}. Let the games begin!\n");
                break;
            }

            else
            {
                Console.WriteLine($"You have entered ${playerMoney}. Please enter more money to begin the game.\n");
                playerMoney = double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Hit the 'Y' button to spin\n");
        char spinButton = char.ToUpper(Console.ReadKey().KeyChar);
        
        if (spinButton == START_SPIN)
        {
            //Insert numbers into 2DArray using Random Numbers
            int[,] slotNumbers = new int[3, 3];
            Random ranNum = new Random();
            for (int i = 0; i < slotNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < slotNumbers.GetLength(1); j++)
                {
                    slotNumbers[i, j] = ranNum.Next(1, MAX_NUMBER + 1);
                }

                if (i == 1 && slotNumbers[i, 0] == slotNumbers[i, 1] && slotNumbers[i, 1] == slotNumbers[i, 2])
                {
                    Console.WriteLine("You got three in a row! You win!");
                    break;
                }

                else
                {
                    Console.WriteLine("\nTry Again.");
                }

            }
        }

        else
        {
            Console.WriteLine("\nInvalid character chosen. Please hit 'Y' to spin");
        }
        
    }
}
