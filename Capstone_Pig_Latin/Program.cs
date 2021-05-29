using System;
using System.Linq;

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
                
                string giveBack = Translating(userInput);

                Console.WriteLine(giveBack);

                goOn = GetContinue();
            }

        }

        // method for Pig Latin

        public static string Translating(string userInput)
        {
            string vowels = "aeiou";
            //This is where we will keep our new word
            string newWord;
            string newSentence = "This is your translated input:";


            foreach (string word in userInput.Split( ))
            {
                //getting th first letter by indexing it 
                string firstLetter = userInput.Substring(0, 1);
                //compare the first later to vowels, IndexOf will return -1 you try to look up something and it's not found
                int currentLetter = vowels.IndexOf(firstLetter);
                bool find = false;
                int index = -1;


                //So if the first letter is not -1 it must be a vowel, there for we can go ahead and add "way to the end"
                if (currentLetter > -1)
                {
                    newWord = word + "way ";
                    newSentence += " " + newWord;
                }
                else
                {
                    char[] wordBroken = word.ToArray();
                   

                    while (find == false)
                    {
                        
                        foreach (char letter in wordBroken)
                        {
                            currentLetter = vowels.IndexOf(letter);
                            index++;
                            if (currentLetter > -1)
                            {
                                find = true;
                                break;
                            }
                            else
                                continue;
                        }
                    }

                    string backSide = word.Substring(0, index);
                    string frontSide = word.Substring(index, word.Length-1);
                    newWord = frontSide + backSide + "ay" ;
                    newSentence += " " + newWord;
      
                }
                
            }

            return newSentence;
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
