using System;
using System.Collections.Generic;

public class UserInputTextHandler
{
    public static List<string> yesNO = new List<string> { "y", "n" };  

    public string caseSensitiveInput(List<string> possibleAnswers)
    {
        string input;
        while (true)
        {
            input = Console.ReadLine(); 
            foreach (string possibleAnswer in possibleAnswers)
            {
                if (possibleAnswer == input)
                {
                    return input; 
                } 
            }
            Console.WriteLine("Please type: " + string.Join(" or ", possibleAnswers)); 
        } 
    }

    public string CannotBeNull()
    {
        string input;
        do
        {
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please Do Not Enter nothing");
            }
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    public void makePost()
    {
        Console.WriteLine("Please Enter The Post Content");
        string input = CannotBeNull();

        Console.WriteLine("This is What Your Post Will Look Like: " + input);
        Console.WriteLine("Do you like what it looks like? Type 'y' or 'n'");

        string input2 = caseSensitiveInput(yesNO);

        if (input2 == "y")
        {
            FileWriter.CreatePost(input); 
        }
        else
        {
            makePost();
        }
    }
}
