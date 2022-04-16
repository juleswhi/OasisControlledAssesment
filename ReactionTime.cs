using System;
using System.Diagnostics;
using static System.Console;
using System.Threading;
// using System.Threading.Tasks;

class ReactionTime : Competitors
{

    private int[] reactionTimes;


    public ReactionTime() => ReactionTest();



    private void ReactionTest()
    {

        var timer = new Stopwatch();
        var rand = new Random();
        string[] ElapsedTimes = new string[3];


        for(int i = 0; i < 3; i++)
        {
            ResetColor();
            Clear();
            WriteLine("Reaction Time Test Is About To Commence");
            Thread.Sleep(1500);
            WriteLine("Please Press [Enter] When Prompted");
            Thread.Sleep(1500);
            Clear();
            int rnd = rand.Next(1000, 2000);
            ConsoleKey keyPressed;

            timer.Start();
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Wait...");
            Thread.Sleep(rnd);
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Go!");
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            while(true)
            {
                if(keyPressed == ConsoleKey.Enter)
                    break;
            }       

            timer.Stop();
            Clear();
            WriteLine("Well Done!");

            TimeSpan ts = timer.Elapsed;
            ElapsedTimes[i] = String.Format("{0:00}{1:00}",
            ts.Seconds, ts.Milliseconds / 10);

            WriteLine($"Your Time Was {ElapsedTimes[i]}!");

            if(i != 3)
            {
                WriteLine("Press Any Key To Proceed To The Next Test");
                ReadKey(true);
                continue;
            }
            else
            {
                WriteLine("Press Any Key To Finish");
                break;
            }

        }

        reactionTimes = new int[3];

        for(int j = 0; j < ElapsedTimes.Length; j++)
        {
            reactionTimes[j] = Convert.ToInt16(ElapsedTimes[j]);
        }

        LogTestTimes();
        
    }




    private void LogTestTimes()
    {

         if(dataAccessed != true)
         {
             ReadInCsvCompetitors();
         }

        string[,] competitorDetails = getCompetitorDetails();

        string[,] reactionCompetitorDetails = new string[competitorDetails.GetLength(0),5];

            



    }

}