<<<<<<< HEAD
   using System;
=======
using System;
>>>>>>> 7cd4a1c51dc52a41138c98092120d17645f67429
   //using System.Security.Cryptography; I tried to Encrypt the message
   //using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();
        //using (Aes aesAlg=Aes.Create())
           // {
              //  byte[]
           //     EncryptedMessage=EncryptMessage(aesAlg,message);
        //    }
        DateTime current_time=DateTime.Now;
        Console.WriteLine("Sorry for the late assignment due to my personal problem.");
        Console.WriteLine($"Today is:{current_time} \n Your name is {last}, {first} {last}.");
    }
}
