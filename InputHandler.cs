using System;
using System.Collections.Generic;

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
    
}
