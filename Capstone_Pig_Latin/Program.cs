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

                Console.WriteLine("Hello, I am creating a merge conflict");

                Console.Write("Let's fix this merge issue!");

                string userInput = GetUserInput("word or sentence");
                userInput = userInput.ToLower();
                userInput = userInput.Trim();


                string giveBack;

                bool resultOfChar = userInput.All(c => Char.IsLetter(c) || c == ' '); ;

            
                if (resultOfChar == false)
                {
                    while (userInput.All(c => Char.IsLetter(c) || c == ' ')== false)
                    {
                        Console.WriteLine("Your input has a character that we don't accepted, input text only next time.");
                        userInput = GetUserInput("please enter a word");
                    }

                    giveBack = Translating(userInput);
                    Console.WriteLine(giveBack);

                }
                else
                {
                    giveBack = Translating(userInput);
                    Console.WriteLine(giveBack);
                }


                goOn = GetContinue();
            }

        }

        
      
// method for Pig Latin

public static string Translating(string userInput)
        {
            string vowels = "aeiou";
            //This is where we will keep our new word when the computer is currently working on it 
            string newWord;
            //This is where ALL of our new words will be stored
            string newSentence = "This is your translated input:";
            //breaking up our sentence into words, for some reason it has trouble when there is a space at the end. 
            string[] sentenceBroken = userInput.Split().ToArray();
          


            foreach (string word in sentenceBroken)
            {
                //getting the first letter by indexing it 
                string firstLetter = word.Substring(0, 1);
                //compare the first later to vowels, IndexOf will return -1 you try to look up something and it's not found
                int currentLetter = vowels.IndexOf(firstLetter);
                bool find = false;
                int index = -1;


                //If the first letter is not -1 it MUST be a vowel, there for we can go ahead and add "way to the end"
                if (currentLetter > -1)
                {
                    newWord = word + "way ";
                    newSentence += " " + newWord;
        
                }
                //If it doesn't start with a vowel then.. 
                else
                {
                    //spliting the word into letters
                    char[] wordBroken = word.ToArray();
                   

                    //run this while loop until the computer finds a vowel (it will true find == true when it does, and it will index where its found)
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
                    //now that we know where our vowels are we can break it on that 
                    string backSide = word.Substring(0, index);
                    string frontSide = word.Substring(index);
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
