namespace SlotMachine;

class Program
{
    public const double COST_PER_SPIN = 2.00;
    public const int MAX_NUMBER = 9;
    public const char START_SPIN = 'Y';
    public const int VERTICAL_LINE = 3;
    public const int HORIZONTAL_LINE = 3; 

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
                Console.WriteLine($"\nYou have entered ${playerMoney}. Let the games begin!\n");
                break;
            }
            //If player doesn't enter an amount over spin costs player will be advised to enter more money
            {
               Console.WriteLine($"You have entered ${playerMoney}. Please enter more money to begin the game.\n");
               playerMoney = double.Parse(Console.ReadLine());
            }
        }
        //Player hits Y to start or spin the game 
        Console.WriteLine("Hit the 'Y' button to spin\n");
        char spinButton = char.ToUpper(Console.ReadKey().KeyChar);

        Console.WriteLine("\n");
        
        if (spinButton == START_SPIN)
        {
          Console.WriteLine("\nSpinning...");
          Console.WriteLine("\nSpinning...");

          //Insert numbers into 2DArray using Random Numbers
          int[,] slotNumbers = new int[VERTICAL_LINE, HORIZONTAL_LINE];
          Random ranNum = new Random();

         Console.WriteLine("\n");

            for (int i = 0; i < slotNumbers.GetLength(0); i++)
            {
               for (int j = 0; j < slotNumbers.GetLength(1); j++)
               {
               //Numbers will display after spin 
               slotNumbers[i, j] = ranNum.Next(1, MAX_NUMBER + 1);
               Console.Write(slotNumbers[i, j] + " ");
               }

               Console.WriteLine("\n");

               if (i == 1 && slotNumbers[i, 0] == slotNumbers[i, 1] && slotNumbers[i, 1] == slotNumbers[i, 2])
               {
               //If there are 3 matching numbers in the center row
               Console.WriteLine("You got three in a row! You win!");
               break;
               }

               else
               {
               Console.WriteLine("\nTry Again.\n");
               }
            }    
        }
        //If user enters any other letter or character besides 'Y' or 'y'
        else
        {
            Console.WriteLine("\nInvalid character chosen. Please hit 'Y' to spin");
        }    
    }
}
