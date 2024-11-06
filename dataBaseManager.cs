using System.IO;

using System.Data.SQLite;
using Microsoft.VisualBasic;
using System.Configuration;

public class FileWriter
{

    public static Random rnd = new Random();

    public static UserInputTextHandler userInputTextHandler = new UserInputTextHandler(); 
    public void SetUpSQLDataBase()
    {
        string connectionString = "Data Source=local_database.db;Version=3;";
            
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
            connection.Open();

            string createTableQuery = @"CREATE TABLE IF NOT EXISTS Users (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Username TEXT NOT NULL,
                                            Password TEXT NOT NULL,
                                            Email TEXT NOT NULL)";
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                        command.ExecuteNonQuery();
                }
                    Console.WriteLine("succres");
            }
            string connectionString1 = "Data Source=local_database.db;Version=3;";

    using (SQLiteConnection connection1 = new SQLiteConnection(connectionString1))
    {
        connection1.Open();

        string createTableQuery = @"CREATE TABLE IF NOT EXISTS Posts (
                                        PostId INTEGER PRIMARY KEY AUTOINCREMENT,
                                        UserId INTEGER,
                                        Content TEXT NOT NULL,
                                        Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
                                        FOREIGN KEY (UserId) REFERENCES Users(Id))";

        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection1))
        {
            command.ExecuteNonQuery();
        }
        Console.WriteLine("Posts table set up successfully.");

        }
    }
    public static void AddUser(string username, string password, string email)
        {
            string connectionString = "Data Source=local_database.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Users (Username, Password, Email) VALUES (@username, @password, @Email)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@Email", email);

                    command.ExecuteNonQuery();
                }
            }
        }
 public static string DoesUsernameExist()
    {
        string input;
        Console.WriteLine("What is Your User Name?");
        input = userInputTextHandler.CannotBeNull();
        
        string connectionString = "Data Source=local_database.db;Version=3;";
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * FROM Users WHERE Username = @username LIMIT 1";
            using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@username", input);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Username already exists, Please try another.");
                        return DoesUsernameExist(); 
                    }
                    else
                    {
                        return input; 
                    }
                }
            }
        }
    }
    public static void DeleteAllUsernames()
{
    string connectionString = "Data Source=local_database.db;Version=3;";
    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    {
        connection.Open();

        string deleteQuery = "DELETE FROM Users";

        using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
        {
            command.ExecuteNonQuery();
            Console.WriteLine("All usernames, passwords, and emails deleted successfully.");
        }
    }
}
public static void ListAllData()
{
    string connectionString = "Data Source=local_database.db;Version=3;";
    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    {
        connection.Open();

        string selectQuery = "SELECT * FROM Users";
        using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
        {
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["Id"]);
                    Console.WriteLine("Username: " + reader["Username"]);
                    Console.WriteLine("Password: " + reader["Password"]);
                    Console.WriteLine("Email: " + reader["Email"]);
                    Console.WriteLine(); 

                }
            }
        }
    }
}
    public bool LogIntAcountDataBase(string UserName, string Password, string email)
    {   
        string connectionString = "Data Source=local_database.db;Version=3;";
    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    {
        connection.Open();

        string selectQuery = "SELECT * FROM Users WHERE Username = @username AND Password = @password LIMIT 1";
        using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
        {
            command.Parameters.AddWithValue("@username", UserName);
            command.Parameters.AddWithValue("@password", Password);

            using (SQLiteDataReader reader = command.ExecuteReader())   

            {
                return reader.HasRows;
            }
        }
    }
    }
    public static void CreatePost(string content)
{
    int userId = 0;
    string connectionString = "Data Source=local_database.db;Version=3;";
    int postId = rnd.Next(0, 1000000000);

    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    {
        connection.Open();

        string insertQuery = "INSERT INTO Posts (UserId, Content, PostId) VALUES (@UserId, @Content, @PostId)";
        using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
        {
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@Content", content);
            command.Parameters.AddWithValue("@PostId", postId);
            command.ExecuteNonQuery();
        }
    }
}
public static void LookAtPosts()
{
    string connectionString = "Data Source=local_database.db;Version=3;";
     using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    {
        connection.Open();

        string selectQuery = "SELECT * FROM Posts";
        using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
        {
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    Console.WriteLine(reader["Content"]); 
                }
            }
        }
    }

}






}


   
