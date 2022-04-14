using System;
using System.IO;
using System.Linq;
using System.Threading;
namespace OasisControlledAssesment{
class Program {
    
  public static void Main (string[] args) {

        Console.Clear();
   
        var login = new Login();
        login.Run(true);

  }

    
}
}
