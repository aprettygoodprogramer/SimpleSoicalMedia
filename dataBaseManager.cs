using System.IO;

using System.Data.SQLite;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data.Entity.Core.Common.EntitySql;

public class FileWriter
{

  public static Random rnd = new Random();
    public static int currentPostId;
    public static List<int> postIdList = new List<int>();
    public static List<string> yesNo = new List<string>() {"y", "n"};
    public static List<string> LookCreate = new List<string>() {"l", "c"};
    public static int amtPost = 0;

    public static UserInputTextHandler userInputTextHandler = new UserInputTextHandler(); 

    public void SetUpSQLDataBase()
    {
        string connectionString = "Data Source=local_database.db;Version=3;";
            
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
            connection.Open();

            // Users table remains the same
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

        // Update Posts table to include a Comments table reference
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

        // Create a separate Comments table to store comments for each post
        createTableQuery = @"CREATE TABLE IF NOT EXISTS Comments (
                                        CommentId INTEGER PRIMARY KEY AUTOINCREMENT,
                                        PostId INTEGER,
                                        UserId INTEGER,
                                        Content TEXT NOT NULL,
                                        Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
                                        FOREIGN KEY (PostId) REFERENCES Posts(PostId),
                                        FOREIGN KEY (UserId) REFERENCES Users(Id))";

        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection1))
        {
            command.ExecuteNonQuery();
        }
        Console.WriteLine("Comments table set up successfully.");

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
    amtPost = 0;
    int pressAmtPost;
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
                    amtPost++;
                    int postID = Convert.ToInt32(reader["PostId"]);
                    postIdList.Add(postID);
                    Console.WriteLine(reader["Content"]);
                    pressAmtPost = amtPost-1; 
                    Console.WriteLine("Press " + pressAmtPost.ToString() + " to go into that post if you would like to.");
                    
                }
            }
        }
    }

    if (amtPost == 0)
    {
        Console.WriteLine("No posts available.");
        return; 
    }

    Console.WriteLine("Would you like to go into a post? Type 'y' for yes and 'n' for no.");
    string input = userInputTextHandler.caseSensitiveInput(yesNo);
    if (input == "y")
    {
        int NEWi;
        List<string> ThingsCanChoose = new List<string>();
        for (int i = 0; i < amtPost; i++)
        {
            //Console.WriteLine("THings you can choose" + i+1);
            NEWi = i;
            //NEWi++;
            ThingsCanChoose.Add(NEWi.ToString());
        }

        Console.WriteLine("Which post would you like to look at?");
        input = userInputTextHandler.caseSensitiveInput(ThingsCanChoose);

        if (int.TryParse(input, out int selectedIndex) &&
            selectedIndex >= 0 && selectedIndex < postIdList.Count)
        {
            int trueID = postIdList[selectedIndex];

            Console.WriteLine("Would you like to look at comments, or write a comment? Type 'l' for look and 'c' for create.");
            string input4 = userInputTextHandler.caseSensitiveInput(LookCreate);

            if (input4 == "c")
            {
                CommentUnderPost(trueID);
            }
            else if (input4 == "l")
            {
                FillInPost(trueID);
            }
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }
    else
    {
        Console.WriteLine("Would you like to make a post then?");
        input = userInputTextHandler.caseSensitiveInput(yesNo);
        if (input == "y")
        {
            userInputTextHandler.makePost();
        }
        else
        {
            Console.WriteLine("**Well, too bad :D**");
            userInputTextHandler.makePost();
        }
    }
}

public static void CommentUnderPost(int postID)
{


    Console.WriteLine("Please enter your comment:");
    string commentContent = userInputTextHandler.CannotBeNull();

    int userId = 0; 

    string connectionString = "Data Source=local_database.db;Version=3;";
    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    {
        connection.Open();

        string insertQuery = "INSERT INTO Comments (PostId, UserId, Content) VALUES (@PostId, @UserId, @Content)";
        using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
        {
            command.Parameters.AddWithValue("@PostId", postID);
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@Content", commentContent);

            command.ExecuteNonQuery();
        }
    }

    Console.WriteLine("Comment added successfully!");
}

public static void FillInPost(int postId)
{
    string connectionString = "Data Source=local_database.db;Version=3;";
    string postContent = string.Empty;
    string postTimestamp = string.Empty;
    List<string> comments = new List<string>();

    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    {
        connection.Open();

        // Retrieve post details
        string selectPostQuery = "SELECT Content, Timestamp FROM Posts WHERE PostId = @PostId";
        using (SQLiteCommand command = new SQLiteCommand(selectPostQuery, connection))
        {
            command.Parameters.AddWithValue("@PostId", postId);

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) // Ensure there's a row to read
                {
                    postContent = reader["Content"].ToString();
                    postTimestamp = reader["Timestamp"].ToString();
                }
                else
                {
                    Console.WriteLine("Post not found.");
                    return;
                }
            }
        }

        // Retrieve comments for the post
        string selectCommentsQuery = "SELECT Content FROM Comments WHERE PostId = @PostId";
        using (SQLiteCommand command = new SQLiteCommand(selectCommentsQuery, connection))
        {
            command.Parameters.AddWithValue("@PostId", postId);

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comments.Add(reader["Content"].ToString());
                }
            }
        }
    }

    // Display post and comments
    Console.WriteLine("Post Details:");
    Console.WriteLine($"Content: {postContent}");
    Console.WriteLine($"Timestamp: {postTimestamp}");
    Console.WriteLine("\nComments:");

    if (comments.Count > 0)
    {
        for (int i = 0; i < comments.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {comments[i]}");
        }
    }
    else
    {
        Console.WriteLine("No comments for this post.");
    }
}







}


   
