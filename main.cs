using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


class Program {


    static string competitorPath, passwPath;

    static string[,] competitorDetails;
    
    static string[,] userDetails;

    
  public static void Main (string[] args) {

      Console.Clear();
      competitorPath = "competitors.csv";
      passwPath = "passw.csv";

      var log = Login();
      
  }

    static async Task Login()
    {
        await ReadInCsvPass();
        await ReadInCsvCompetitors();

        // read in details

        Console.Clear();
        TypeWriter("Please Enter Your Username");
        Console.Write("> ");
        string enteredUsername = Console.ReadLine();
        Console.Clear();
        TypeWriter("Please Enter Your Password");
        Console.Write("> ");
        string enteredPassword = Console.ReadLine();
        Console.Clear();

        // check for correct uname and pass

        for(int i = 0; i < userDetails.GetLength(0); i++)
        {
            if(enteredUsername == userDetails[i,0]){
                if(enteredPassword == userDetails[i,1])
                    TypeWriter("Entered Details Correctly");
                    Thread.Sleep(800);
                    MainMenu();
            } 
            else {
                continue;
            }
        }
        // recursion

        await Login();
        
    }


    static async Task ReadInCsvPass()
    {
        try{
        // reads in csv file
        string[] readIn = new string[File.ReadAllLines(passwPath).Length];
        int coloums = 2;
        int rows = readIn.Length;

        userDetails = new string[rows, coloums];

        readIn = File.ReadAllLines(passwPath);

        string[] temp = new string[coloums];
        
        for(int i = 0; i < rows; i++)
        {
            temp = readIn[i].Split(',');
            for(int j = 0; j < coloums; j++)
            {
                userDetails[i,j] = temp[j];
            }
        }
        }
        catch(Exception e)
        {
            throw new FieldAccessException($"oopsie daises {e}");
        }

       
    }



    static async Task ReadInCsvCompetitors()
    {
        try{
            string[] readIn = new string[File.ReadAllLines(competitorPath).Length];
            int coluoms = 3;
            int rows = readIn.Length;

            competitorDetails = new string[rows,coluoms];

            readIn = File.ReadAllLines(competitorPath);

            string[] temp = new string[coluoms];
        
        
        for(int i = 0; i < rows; i++)
        {
            temp = readIn[i].Split(',');
            for(int j = 0; j < coluoms; j++)
            {
                competitorDetails[i,j] = temp[j];
            }
        }
        }
        catch(Exception e)
        {
            throw new FieldAccessException($"oopsie daises {e}");
        }
    }




    // TYPEWRITER METHOD

    


    static void TypeWriter(string str)
    {
        for(int i = 0; i < str.Length; i++)
        {
            Console.Write(str[i]);
            Thread.Sleep(30);
        }
        Console.WriteLine();
    }




    

    static void AddUser()
    {

        Console.Clear();
        Console.WriteLine("Please Enter Your New Username");
        Console.Write("> ");
        string NewEnteredUsername  = Console.ReadLine();
        Console.WriteLine("Please Enter Your New Password");
        Console.Write("> ");
        string NewEnteredPassword = Console.ReadLine();

        
        try
        {
            using(StreamWriter file = new StreamWriter(@passwPath, true))
            {
                file.Write("\n");
                file.Write(NewEnteredUsername + "," + NewEnteredPassword);
            }
        }
        catch(Exception e)
        {
            throw new ArithmeticException("Oopsie Daises " + e);
        }
    }

    static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Hello, What Would You Like To Do?");

        string[] options = {
              "" , "Add New Username And Password" , "Exit"
        };

        for(int i = 1; i < options.Length; i++)
        {

            TypeWriter(options[i]);
            Thread.Sleep(500);
                
        }

        Console.Write("> ");
        string enteredOption = Console.ReadLine();
        string spellingCorrected = CheckSpelling(enteredOption, options);
        if(spellingCorrected == "Add New Username And Password")
        {
            AddUser();
        }
        else if(spellingCorrected == options[2])
        {
            Environment.Exit(0);
        }
    }


    static int Compare(string s, string t)
    {
            // checks that both strings actually have values
        if(string.IsNullOrEmpty(s))
        {
          if(string.IsNullOrEmpty(t))
          {
            return 0;
          }
          return t.Length;
        }
        if(string.IsNullOrEmpty(t))
          return s.Length;
        int n = s.Length;
        int m = t.Length;
        // creates a 2d array 
        int[,] d = new int[n + 1, m + 1];
        // initiales the size of the array
        for(int i = 0; i <= n; d[i,0] = i++);
        for(int j = 1; j <= m; d[0,j] = j++);
        // uses the 'Damereau Levenshein' algorithm to check difference 
        // between the two strings
        for(int i = 1; i <= n; i++)
        {
          for(int j = 1; j <= m; j++)
          {
            int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
            int min1 = d[i - 1, j] + 1;
            int min2 = d[i, j - 1] + 1;
            int min3 = d[i - 1, j - 1] + cost;
            d[i, j] = Math.Min(Math.Min(min1, min2), min3);
          }
        }
        // returns an int value based on difference
        return d[n, m];
    }


    static string CheckSpelling(string input, string[] CorrectString)
    {
        string correct = null;
        int length = CorrectString.Length;
        for(int i = 0; i < length; i++)
        {
            if(Compare(input, CorrectString[i]) < ((CorrectString[i].Length / 4) + 1))
            {
                correct = CorrectString[i];
            }
            else 
            {
                correct = input;
            }
        }
        return correct;
    }
}
