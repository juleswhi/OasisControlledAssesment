using System;
using System.IO;
using System.Threading;
using System.Linq;

class Program {

    static string competitorPath, passwPath;

    static string[,] competitorDetails;
    
    static string[,] userDetails;

    
  public static void Main (string[] args) {

      competitorPath = "competitors.csv";
      passwPath = "passw.csv";



      
      if(Login())
      {
          TypeWriter("Entered Details Correctly");
      }
      else
      {
          TypeWriter("Entered Details Incorreactly");
          Environment.Exit(0);
      }

    Thread.Sleep(1000);

      MainMenu();

      


  }

    static bool Login()
    {
        ReadInCsvPass();

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
                    return true;
            } 
            else {
                continue;
            }
        }
        return false;
        
    }


    static void ReadInCsvPass()
    {

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



    static void ReadInCsvCompetitors()
    {
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




    // TYPEWRITER METHOD

    


    static void TypeWriter(string str)
    {
        for(int i = 0; i < str.Length; i++)
        {
            Console.Write(str[i]);
            Thread.Sleep(50);
        }
        Console.WriteLine();
    }




    

    static void AddCompetitor()
    {

        Console.Clear();

        Console.Write("> ");
        string balgkn = Console.ReadLine();
        Console.Write("> ");
        string blasPass = Console.ReadLine();

        
        try
        {
            using(StreamWriter file = new StreamWriter(@passwPath, true))
            {
                file.Write("\n");
                file.Write(balgkn + "," + blasPass);
            }
        }
        catch(Exception E)
        {
            throw new ArithmeticException("Oopsie Daises " + E);
        }
    }

    static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Hello, What Would You Like To Do?");

        string[] options = {
              "Add Competitor", "Exit" 
        };

        for(int i = 0; i < options.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (options[i] != options[options.Length])
                Console.WriteLine(options[i]);
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(options[i]);
            }

            Thread.Sleep(500);
                
        }
    }
}
