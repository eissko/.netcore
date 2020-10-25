using System;
using System.Net;

namespace networkCredential
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string userName = "user1";
            string password = "Pwd1";
            NetworkCredential credentials = new NetworkCredential(userName,password);
            Console.WriteLine(string.Format("Password is: {0}", credentials.Password));
        }
    }
}
