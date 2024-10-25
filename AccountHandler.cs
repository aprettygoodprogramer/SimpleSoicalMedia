public class AccountHandle
{
    private string input;
    private static FileWriter fileWriter = new FileWriter();

    public void CreateAccount()
    {
        makeUsername();
        fileWriter.WriteToUserDataBase(input);
        Console.WriteLine("Please Enter a password");
        input = Console.ReadLine();
        fileWriter.WriteToUserDataBase(input);

    }

    public string makeUsername()
    {
        Console.WriteLine("Please Enter a username");

        input = Console.ReadLine();
        if (fileWriter.lookForLine(input))
        {
            makeUsername();
            return "F";
        }
        else
        {
            Console.WriteLine("Username Has Not Been Taken!");
            return input;
        }
    }
}