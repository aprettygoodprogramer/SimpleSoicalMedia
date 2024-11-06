using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    public static UserInputTextHandler inputHandler = new UserInputTextHandler();
    public static  AccountHandle accountHandle = new AccountHandle(); 
    public static FileWriter fileWriter = new FileWriter();
    public static List<string> yesNo = new List<string> { "y", "n"}; 
    public static List<string> LookOrCreate = new List<string> { "C", "L" }; 
        static string inputPassword;
       static string inputEmail;
        static string CurrentUsername; 
        static string input="";
    public static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            FileWriter.DeleteAllUsernames();
            Console.WriteLine("deleted all usernames");
        }
    
        //FileWriter.ListAllData();
        fileWriter.SetUpSQLDataBase();
        
        Console.WriteLine("Welcome to Evan's Simple Social Media");
        Console.WriteLine("Have you already made an account? y or n");

        input = inputHandler.caseSensitiveInput(yesNo); 
        if (input == "n")
        {
            accountHandle.CreateAccount();
 
        }
        else if (input == "y")
        {
            attemptToLogIn();

        }
        Console.WriteLine("Would You Like to Create A post or Look at posts? Type C for create and L for look");
        input = inputHandler.caseSensitiveInput(LookOrCreate); 
        if (input == "L")
        {   
            FileWriter.LookAtPosts(); 
        }
        if (input == "C")
        {
            inputHandler.makePost();
        }

    }
    
    public static void attemptToLogIn()
    {
        Console.WriteLine("What Is Your Username?");
            input = inputHandler.CannotBeNull();
            Console.WriteLine("What is your password?");
            inputPassword = inputHandler.CannotBeNull();
            Console.WriteLine("What is your email?");
            inputEmail = inputHandler.CannotBeNull();
            if (fileWriter.LogIntAcountDataBase(input, inputPassword,  inputEmail))
            {
                Console.WriteLine("Succesful!");
                CurrentUsername = input;
            }
            else
            {
                Console.WriteLine("Failed");
                Console.WriteLine("Please Try Again To Log In!");
                attemptToLogIn();
            }
        }

    }



