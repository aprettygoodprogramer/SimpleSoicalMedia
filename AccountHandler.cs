public class AccountHandle
{
    private string inputName;
    private string inputEmail;
    private string inputPassword;


    private static FileWriter fileWriter = new FileWriter();

    public void CreateAccount()
    {
        FileWriter.DoesUsernameExist();
        //fileWriter.WriteToUserDataBase(input);
        Console.WriteLine("Please Enter a password");
        inputPassword = Console.ReadLine();
        //fileWriter.WriteToUserDataBase(input);

        FileWriter.AddUser(inputName, inputEmail, inputPassword);

    }


}