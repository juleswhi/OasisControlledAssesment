using System;
using System.Threading;
using System.IO;

    class Login
    {


        public static void Main(string[] args)
        {
            var login = new Login();
            login.Run(true);
        }

        public Login() => passwPath = "passw.csv";


        private string[,] userDetails;
        private string passwPath;

        public void Run(bool yn)
        {
            if(yn == true)
            {
                ReadinCsvPass();
                EnterDetails();
            }
            else
            {
                AddNewUser();
            }
        }




        private void EnterDetails()
        {
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

                        runMainMenu();
                } 
                else {
                    continue;
                }
            }
        }


        public void runMainMenu()
        {
            string prompt = "What Would You Like To Do?";

            string[] options = {
                "Add New Username And Password",
                "Add New Competitor", "Exit"
            };
            var menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            if(selectedIndex == 0)
            {
                AddNewUser();
            }
            else if(selectedIndex == 1)
            {
                Competitors comp = new Competitors();
                comp.NewCompetitor();
            }
            else if(selectedIndex == 2)
            {
                Environment.Exit(0);
            }

        }






        private void ReadinCsvPass()
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



        private void AddNewUser()
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


            runMainMenu();
        }





        private void TypeWriter(string str)
        {
            for(int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }
    }
