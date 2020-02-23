using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace TeamPS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This is for educational purposes only");
            string Hash = "";
            Console.Write("Enter Your MD5 Hash :");
            Hash = Console.ReadLine().ToUpper();

            string pass = "";
            int count = 0;
            bool closeloop = true;

            StreamReader file = new StreamReader(@"ps.txt");

            while (closeloop == true && (pass = file.ReadLine()) != null)
            {
                if (MD5Hash(pass) == Hash)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(pass);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cracked Hash = " + pass + "\n\r" + MD5Hash(pass));

                    Console.ResetColor();
                    Console.ReadKey();

                    closeloop = false;
                    file.Close(); //close file stream

                }
                else
                {
                    Console.WriteLine(pass);
                }
                count++;
                Console.Title = "Current Password Count :" + count.ToString();
                Thread.Sleep(5); //cpu handler
            }
            file.Close();
            Console.ReadKey();
        }
        public static string MD5Hash(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            MD5CryptoServiceProvider MD5Provider = new MD5CryptoServiceProvider();
            byte[] bytes = MD5Provider.ComputeHash(new UTF8Encoding().GetBytes(inputString));

            for (int i = 0; i < bytes.Length; i++)
            {
                StringBuilder StringBuilder = sb.Append(bytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
