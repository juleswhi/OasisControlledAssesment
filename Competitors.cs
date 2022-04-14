using System;
using System.IO;
using System.Threading;


    class Competitors
    {

        private string competitorPath;

        private string[,] competitorDetails;


        public Competitors() => competitorPath = "competitors.csv";


        public void NewCompetitor()
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
            var log = new Login();
            log.runMainMenu();

        }



        private string checkNum()
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







        private void ReadInCsvCompetitors()
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
    }
