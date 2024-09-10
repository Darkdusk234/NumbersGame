using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while(run)
            {
                //Introduces what the program does and asks the user to input max number for the game
                Write("Vi kommer spela ett spel av gissa numret. " +
                    "Skriv vilken siffra som jag mellan noll och det ska välja ett nummer från.");
                int maxNum = Convert.ToInt32(Console.ReadLine());

                //Asks the user how many tries they want
                Write("Hur många försök vill du ha?");
                int tries = Convert.ToInt32(Console.ReadLine());

                //Starts the game and generates the number for the user to guess
                Write($"Välkommen! Jag tänker nu på ett nummer. Kan du gissa vilket? Du får {tries} försök");
                Random rnd = new Random();
                int number = rnd.Next(1, maxNum + 1);

                //The loop where the player can guess the number
                for (int i = 0; i <= tries; i++)
                {
                    //If the player hasn't guessed the number within the number of tries.
                    //Breaks the loop and tells the user he ran out of tries
                    if (i == tries)
                    {
                        Write($"Tyvärr lyckades du inte gissa talet i {tries} försök");
                        break;
                    }

                    
                    //Takes in the users guess and calls on the correctGuess method to check if it is correct, if it is breaks the loop
                    string guess = Console.ReadLine();
                    int guessNum = Convert.ToInt32(guess);
                    bool correctGuess = CheckGuess(guessNum, number);
                    if (correctGuess)
                    {
                        break;
                    }
                }

                //Checks if the user wants to play again and if not breaks the while loop
                Write("Vill du spela igen skriv då ja?");
                string cont = Console.ReadLine();

                if(cont.ToUpper() != "JA")
                {
                    run = false;
                }
            }

        }

        //Takes in the user guess and the generated number and checks if the guess is correct. It then generates a response depending on how close the user is.
        static bool CheckGuess(int guess, int number)
        {
            bool correct = false;
            Random rnd = new Random();


            if (guess == number)
            {
                int correctAnswer = rnd.Next(0, 5);
                switch (correctAnswer)
                {
                    case 1:
                        Write("Yay! Du vann!");
                        break;

                    case 2:
                        Write("Bra jobbat! Du gissade rätt!");
                        break;

                    case 3:
                        Write("Snyggt gjort! Du hittade rätt siffra!");
                        break;

                    case 4:
                        Write("Du lyckades! Du listade ut vilket nummer jag tänkte på!");
                        break;

                    default:
                        Write("Wohoo! Du gjorde det!");
                        break;
                }
                correct = true;
            }
            //Checks if the guess is 
            else if (number - guess <= 5 && number - guess >= 0 || number - guess >= -5 && number - guess <= 0)
            {
                int close = rnd.Next(0, 3);
                switch (close)
                {
                    case 0:
                        Write("Det bränns verkligen av hur nära du är!");
                        break;

                    case 1:
                        Write("Du är så nära!");
                        break;

                    default:
                        Write("Nu bränns det!");
                        break;
                }
            }
            else if (number - guess >= 15 || number - guess <= -15)
            {
                int far = rnd.Next(0, 3);
                switch (far)
                {
                    case 0:
                        Write("Oj det var långt ifån!");
                        break;

                    case 1:
                        Write("Nu är det svin kallt, du är långt ifrån!");
                        break;

                    default:
                        Write("Du är väldigt långt ifrån!");
                        break;
                }
            }
            else if (guess > number)
            {
                int highAnswer = rnd.Next(0, 5);
                switch (highAnswer)
                {
                    case 0:
                        Write("Din gissning var för högt!");
                        break;

                    case 1:
                        Write("Oj det var för högt gissat!");
                        break;

                    case 2:
                        Write("Du gissade för högt!");
                        break;

                    case 3:
                        Write("Testa att gissa en lägre siffra!");
                        break;

                    default:
                        Write("Tyvärr gissade du för högt!");
                        break;
                }
                
            }
            else if (guess < number)
            {
                int lowAnswer = rnd.Next(0, 5);
                switch (lowAnswer)
                {
                    case 0:
                        Write("Det var lågt gissat!");
                        break;

                    case 1:
                        Write("Tror du att jag skulle tänka på ett så lågt tal!");
                        break;

                    case 2:
                        Write("Gissa ett högre tal!");
                        break;

                    case 3:
                        Write("Testa att gissa högre!");
                        break;

                    default:
                        Write("Tyvärr gissade du för lågt!");
                        break;
                }
            }
            return correct;
        }

        //Writes text in a rainbow-like pattern
        static void Write(string text)
        {
            ConsoleColor[] pallette = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta };
            int color = 0;

            foreach (char c in text)
            {
                Console.ForegroundColor = pallette[color];
                Console.Write(c);

                if (char.IsWhiteSpace(c) == false)
                {
                    color++;
                }
                if (color > 4)
                {
                    color = 0;
                }
            }
            Console.ResetColor();
            Console.Write("\n");
        }
    }
}
