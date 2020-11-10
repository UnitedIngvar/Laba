using System;
using System.Collections.Generic;

namespace Laba
{
    class Program
    {
        static void Main(string[] args)
        {
            NotebookHandler handler = new NotebookHandler();
            Console.WriteLine("Welcome to your Notebook!");
            Console.WriteLine("To start work, please press any key");
            Console.ReadKey();
            bool isOn = true;
            while (isOn)
            {
                Console.Clear();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine();
                Console.WriteLine("Please, type a number to choose action:");
                Console.WriteLine("1: create contact");
                Console.WriteLine("2: edit contact");
                Console.WriteLine("3: delete contact");
                Console.WriteLine("4: view contact");
                Console.WriteLine("5: view all existing contacts (First name, Second name, Phone number)");
                switch (Console.ReadLine())
                {
                    case "1":
                        handler.Create(ref Notebook.notes);
                        break;
                    case "2":
                        handler.AddInfo(ref Notebook.notes);
                        break;
                    case "3":
                        handler.Delete(ref Notebook.notes, ref Notebook.conatactsCounter);
                        break;
                    case "4":
                        handler.ViewContact(ref Notebook.notes);
                        break;
                    case "5":
                        handler.ViewAllContacts(ref Notebook.notes);
                        break;
                        
                    default:
                        Console.WriteLine("There's no such command! Try again.");
                        Console.WriteLine("Please, press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
            
        }
    }
    
    
}
