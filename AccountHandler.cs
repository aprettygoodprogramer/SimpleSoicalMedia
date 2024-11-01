
public class AccountHandle
{
    private string inputName;
    private string inputEmail = null;
    private string inputPassword = null;
    private static UserInputTextHandler userInputTextHandler = new UserInputTextHandler(); 
    private static FileWriter fileWriter = new FileWriter();

    public string CreateAccount()
    {
        inputName = FileWriter.DoesUsernameExist();
        Console.WriteLine("Please Enter a password");
        inputPassword = userInputTextHandler.CannotBeNull();
        Console.WriteLine("Please Enter Your Email.");
        inputEmail = userInputTextHandler.CannotBeNull();
        FileWriter.AddUser(inputName, inputEmail, inputPassword);
        return inputName;
    }
    public void LogIntAcount()
    {
        
    }
}