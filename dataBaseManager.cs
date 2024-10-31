using System.IO;

using System.Data.SQLite;
using Microsoft.VisualBasic;

public class FileWriter
{



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
        Console.WriteLine("What is Your User Name?");
        string input = Console.ReadLine();
        
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
}


   