public class AccountHandle
{
    private string inputName;
    private string inputEmail;
    private string inputPassword;


    private static FileWriter fileWriter = new FileWriter();

    public void CreateAccount()
    {
        inputName = FileWriter.DoesUsernameExist();
        Console.WriteLine("Please Enter a password");
        inputPassword = Console.ReadLine();
        Console.WriteLine("Please Enter Your Email.");
        inputEmail = Console.ReadLine();
        FileWriter.AddUser(inputName, inputEmail, inputPassword);

    }
    public void LogIntAcount()
    {
        
    }


}