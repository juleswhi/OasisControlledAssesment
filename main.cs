using System;
using System.IO;
using System.Threading;
using System.Linq;

class Program {

    static string competitorPath, passwPath;

    
    
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
      }


      AddCompetitor();
  }

    static bool Login()
    {
        ReadInCsv();

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
        string[] readIn = new string[File.ReadAllLines(competitorPath).Length];
        int coloums = 2;
        int rows = readIn.Length;

        userDetails = new string[rows, coloums];

        readIn = File.ReadAllLines(competitorPath);

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
        try
        {
            using(StreamWriter file = new StreamWriter(@userpath, true))
            {
                file.Write("\n");
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
    }
}
