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
    
}
