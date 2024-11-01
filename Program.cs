using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    public static UserInputTextHandler inputHandler = new UserInputTextHandler();
    public static  AccountHandle accountHandle = new AccountHandle(); 
    public static FileWriter fileWriter = new FileWriter();
    public static List<string> yesNo = new List<string> { "y", "n" }; 


    public static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            FileWriter.DeleteAllUsernames();
            Console.WriteLine("deleted all usernames");
        }
        //
        //FileWriter.ListAllData();
        fileWriter.SetUpSQLDataBase();
        Console.WriteLine("Welcome to Evan's Simple Social Media");
        Console.WriteLine("Have you already made an account? y or n");
        string inputPassword;
        string inputEmail;
        string CurrentUsername; 
        string input = inputHandler.caseSensitiveInput(yesNo); 
        if (input == "n")
        {
            accountHandle.CreateAccount();
 
        }
        else if (input == "y")
        {
            Console.WriteLine("What Is Your Username?");
            input = Console.ReadLine();
            Console.WriteLine("What is your password?");
            inputPassword = Console.ReadLine();
            Console.WriteLine("What is your email?");
            inputEmail = Console.ReadLine();
            if (fileWriter.LogIntAcountDataBase(input, inputPassword,  inputEmail))
            {
                Console.WriteLine("Succesful!");
                CurrentUsername = input;
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }



    }
}

