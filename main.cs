using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OasisControlledAssesment
{
class Program {


    static string competitorPath, passwPath;

    static string[,] competitorDetails;
    

    
  public static void Main (string[] args) {

        Console.Clear();
        competitorPath = "competitors.csv";
        passwPath = "passw.csv";


        var login = new Login();

        login.Run();


  }

    


    



    static void ReadInCsvCompetitors()
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




    

   

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Hello, What Would You Like To Do?");

        string[] options = {
              "" , "Add New Username And Password" , "Add New Competitor" , "Exit"
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
        else if(spellingCorrected == "Add New Competitor")
        {
            var competitor = NewCompetitor();
        }
        else if(spellingCorrected == "Exit")
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
        string lInput = input.ToLower();
        int length = CorrectString.Length;
        for(int i = 0; i < length; i++)
        {
            string lCorrect = CorrectString[i].ToLower();
            if(Compare(input, lCorrect) < ((lCorrect.Length / 3) + 1))
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


    static async Task NewCompetitor()
    {
        string newCompetitorFirst;
        string newCompetitorLast;
        Console.Clear();
        Console.WriteLine("Please Enter Your New Competitor Details.");
        Thread.Sleep(800);
        Console.WriteLine("Please Enter Your New Competitor's First Name");
        Console.Write("> ");
        newCompetitorFirst = Console.ReadLine();
        Thread.Sleep(500);
        Console.WriteLine("Please Enter New Competitor Surname");
        Console.Write("> ");
        newCompetitorLast = Console.ReadLine();

        
        ReadInCsvCompetitors();
        

        // allocate random number
        

        string allocatedNumber = checkNum();

        Console.WriteLine("Alloacted Number");


        var sw = new StreamWriter(@competitorPath, true);
        
        try{
            sw.Write($"\n" + newCompetitorFirst + "," + newCompetitorLast + "," + allocatedNumber);
           }
        catch(Exception e)
        {
            throw new Exception("oopsie daisesi " + e);
        }

        Console.WriteLine("Written");

        Thread.Sleep(1000);

        var pro = new Program();
        pro.MainMenu();
        
    
              
    }

    static string checkNum()
    {

        var random = new Random();
        
        string randomAllocated = Convert.ToString(random.Next(0,1000));
        
        for(int i =0; i < competitorDetails.Length; i++)
        {
            if(randomAllocated == competitorDetails[i,2])
            {
                checkNum();
            }
        }

        return randomAllocated;
    }
}
}
