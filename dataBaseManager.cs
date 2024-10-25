using System.IO;


public class FileWriter
{


    public void WriteToUserDataBase (string whatToWrite)
    {
        File.AppendAllText("localDataBase.txt", whatToWrite);
    }
    public bool lookForLine(string whatToLookFor)
    {
        string[] lines = File.ReadAllLines("localDataBase.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(whatToLookFor))
            {
                
                
                return true;
            }
        }
        return false;

    }
}