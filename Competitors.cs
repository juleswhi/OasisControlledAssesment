using System;
using System.IO;
using System.Threading;


    class Competitors
    {

        private string competitorPath = "competitors.csv";

        private string[,] competitorDetails;


        public Competitors() => ReadInCsvCompetitors();


        public void NewCompetitor()
        {


            Console.Clear();
            Console.WriteLine("Please Enter Your New Competitors' First Name");
            Console.Write("> ");
            string competFirst = Console.ReadLine();
            Console.WriteLine("Please Enter Your New Competitors' Last Name");
            Console.Write("> ");
            string competLast = Console.ReadLine();
            Console.WriteLine("Gotten User Details");

            string fString = $"{competFirst},{competLast},{checkNum()}";


            Console.WriteLine("Formatted String");
            try
            {
                Console.WriteLine("Trying Streamwriter");
                using(StreamWriter file = new StreamWriter(@competitorPath, true))
                {
                    Console.WriteLine("using StreamWriter");
                    file.Write("\n");
                    file.Write(fString);
                }
            }
            catch(Exception e)
            {
                throw new ArgumentNullException("Oopsie DAises" + e);
            }

            Console.WriteLine("Login Method");
            var log = new Login();
            log.runMainMenu();

        }



        private string checkNum()
        {
            var random = new Random();
        
            string randomAllocated = Convert.ToString(random.Next(0,1000));


            for(int i =0; i < competitorDetails.GetLength(0); i++)
            {
                if(randomAllocated == competitorDetails[i,2])
                {
                    var comp = new Competitors();
                    comp.checkNum();
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
