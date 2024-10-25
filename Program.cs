using System;
using System.Collections.Generic;

class Program
{
    public static UserInputTextHandler inputHandler = new UserInputTextHandler();
    public static  AccountHandle accountHandle = new AccountHandle(); 
    
    public static List<string> yesNo = new List<string> { "y", "n" }; 

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Evan's Simple Social Media");
        Console.WriteLine("Have you already made an account? y or n");

        string input = inputHandler.caseSensitiveInput(yesNo); 
        if (input == "n")
        {
            accountHandle.CreateAccount();
                    Console.WriteLine("asdfasdfdas");
 
        }



    }
}

