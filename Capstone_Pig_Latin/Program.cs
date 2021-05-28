using System;

namespace Capstone_Pig_Latin
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool goOn = true;
            while (goOn == true)
            {
                string userInput = GetUserInput("word or sentence");
                Console.WriteLine(Translating(userInput));
                goOn = GetContinue();
            }

        }

        // method for Pig Latin

        public static string Translating(string userInput)
        {
            string vowels = "aeiou";
            //This is where we will keep our new words
            string newWord = "null";


            foreach (string word in userInput.Split( ))
            {
                //getting th first letter by indexing it 
                string firstLetter = userInput.Substring(0, 1);
                //
                string restOfWord = userInput.Substring(1, userInput.Length - 1);
                //compare the first later to vowels, IndexOf will return -1 you try to look up something and it's not found
                int currentLetter = vowels.IndexOf(firstLetter);
                //to count our loops
                int i = 0;

                //So if the first letter is not -1 it must be a vowel, there for we can go ahead and add "way to the end"
                if (currentLetter > -1)
                {
                    newWord = word + "way";
                }
                else
                {
                    //we will loop through the word while the currently letter is not a vowel
                    while (currentLetter> -1)
                    {
                        //we will count our loops so we can change what letter we are on, and so we know what letter it stops on
                        string goingThoughLetters = userInput.Substring(i,(i+1));
                        currentLetter = vowels.IndexOf(goingThoughLetters);
                        i++;
                        Console.Write(i);
                        string backSide = word.Substring(0, i);
                        string frontSide = word.Substring(i, word.Length);
                        newWord = frontSide+backSide;


                    }
            }
            return newWord;

        }

        //functions for getting user data
        public static string GetUserInput(string desiredInput)
        {
            Console.WriteLine($"Please input a {desiredInput}");
            string input = Console.ReadLine();
            return input;
        }




        //Method for con
        public static bool GetContinue()
        {
            Console.WriteLine("Would you like to continue? y/n");
            string answer = Console.ReadLine();

            //There are 3 cases we care about 
            //1) y - we want to continue 
            //2) n - we want to stop 
            //3) anything else - we want to try again

            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that, please try again");
                //Calling a method inside itself is called recursion
                //Think of this as just trying again 
                return GetContinue();
            }
        }
    }
}
