public class User
{
    public string UserName { get; set;}
    public string Password { get; set;}
    public string UserEmail { get; set;}
    public User(string userName, string password, string userEmail)
    {
        UserName = userName;
        Password = password;
        UserEmail = userEmail;
    }

}