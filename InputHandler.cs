using System;
using System.Collections.Generic;
using System.Reflection;

public class UserInputTextHandler
{
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
        string input = null;
        while(input == null || input.Length == 0 || input == "")
        {
        input = Console.ReadLine();
        
        if (input == null || input.Length == 0 || input == "")
        {
            Console.WriteLine("Please Do Not Enter nothing");
        }
        }
        return input;
    }
    
}
