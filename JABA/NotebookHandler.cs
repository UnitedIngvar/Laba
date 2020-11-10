using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using System.Reflection;

namespace Laba
{
    public class NotebookHandler
    {
        public void AddInfo(ref List<Notebook> notes)
        {
            while (true)
            {
                Console.Clear();
                if (notes.Count == 0)
                {
                    Console.WriteLine("Looks like there are no contacts yet! Add some");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                string userCommand =""; // 1)get user input 2)if input is not number
                int index = 0; //if input is a number

                GetCommand(ref userCommand, ref index, notes, "change");

                if(userCommand == "n")
                {
                    break;
                }

                //Change the information
                bool isOK = true;
                while (isOK)
                {
                    Console.Clear();
                    Console.WriteLine("Specify what field do you want to change? Type:");
                    Console.WriteLine("1: First Name");
                    Console.WriteLine("2: Second Name");
                    Console.WriteLine("3: Middle Name");
                    Console.WriteLine("4: Phone Number");
                    Console.WriteLine("5: Birth Date");
                    Console.WriteLine("6: Organization");
                    Console.WriteLine("7: Position");
                    Console.WriteLine("8: Other notes");
                    Console.WriteLine("n: No (exit from this menu)");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Write("Type First Name: ");
                            notes[index-1].Name = Console.ReadLine();
                            Console.WriteLine("Name changed! Please, press any key to continue");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Write("Type Second Name: ");
                            notes[index-1].SecondName = Console.ReadLine();
                            Console.WriteLine("Second Name changed! Please, press any key to continue");
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.Write("Type Middle Name: ");
                            notes[index-1].MiddleName = Console.ReadLine();
                            Console.WriteLine("Middle Name changed! Please, press any key to continue");
                            Console.ReadKey();
                            break;
                        case "4":
                            Console.Write("Type Phone Number: ");
                            notes[index-1].PhoneNumber = Console.ReadLine();
                            Console.WriteLine("Phone Number changed! Please, press any key to continue");
                            Console.ReadKey();
                            break;
                        case "5":
                            Console.Write("Type Birth Date: "); // to change
                            while (true)
                            {
                                Console.Write("Enter day of month (e.g. 01, 21): ");
                                string day = Console.ReadLine();
                                Console.Write("Enter month (e.g. 11, 09): ");
                                string month = Console.ReadLine();
                                Console.Write("Enter year (e.g. 2003, 1999)");
                                string year = Console.ReadLine();
                                try
                                {
                                    notes[index -1].BirthDate = DateTime.Parse($"{day}.{month}.{year}");
                                    break;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Wrong format! Try again!");
                                }
                            }
                            Console.WriteLine("Birth Date changed! Please, press any key to continue");
                            Console.ReadKey();
                            break;
                        case "6":
                            Console.Write("Type Organization: ");
                            notes[index-1].Organization = Console.ReadLine();
                            Console.WriteLine("Organization changed! Please, press any key to continue");
                            Console.ReadKey();
                            break;
                        case "7":
                            Console.Write("Type Position: ");
                            notes[index-1].Position = Console.ReadLine();
                            Console.WriteLine("Position changed! Please, press any key to continue");
                            Console.ReadKey();
                            break;
                        case "8":
                            bool isFormat = false;
                            while (!isFormat)
                            {
                                Console.Write("Add(type 1) or Change(type 2)?");
                                string AddOrType = Console.ReadLine();
                                switch (AddOrType)
                                {
                                    case "1":
                                        Console.Write("Type: ");
                                        notes[index-1].OtherNotes += $", {Console.ReadLine()}";
                                        Console.WriteLine("Other Notes changed! Please, press any key to continue");
                                        Console.ReadKey();
                                        isFormat = true;
                                        break;
                                    case "2":
                                        notes[index-1].OtherNotes = Console.ReadLine();
                                        Console.WriteLine("Other Notes changed! Please, press any key to continue");
                                        Console.ReadKey();
                                        isFormat = true;
                                        break;
                                    default:
                                        Console.WriteLine("Wrong command! Try again!");
                                        Console.WriteLine("Please, press any key to continue");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            break;
                        case "n":
                            isOK = false;
                            Console.Clear();
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
        public void Delete(ref List<Notebook> notes, ref int counter)
        {
            while (true)
            {
                Console.Clear();
                if (notes.Count == 0)
                {
                    Console.WriteLine("Looks like there are no contacts yet! Add some");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                
                string userCommand = "";
                int index = 0;

                GetCommand(ref userCommand, ref index, notes, "delete");

                if(userCommand == "n")
                {
                    break;
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Delete this contact? Type:");
                    Console.WriteLine("y: yes");
                    Console.WriteLine("n: no");
                    string input = Console.ReadLine();
                    if(input == "y")
                    {
                        notes.RemoveAt(index - 1);
                        Console.WriteLine("Contact is deleted!");
                        Console.WriteLine("Please, press any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                    else if(input == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong format! Please, type 'y' or 'n'!");
                        Console.WriteLine("Please, press any key to continue.");
                        Console.ReadKey();
                    }
                }
                
            }
        }
        public void Create(ref List<Notebook> notes)
        {
            Console.Clear();
            bool isOK = true;
            string name;
            string secondName;
            string phoneNumber;
            string country;
            Console.WriteLine("Enter the necessary information");

            Console.Write("Name: ");
            name = AddIfNotEmpty();

            Console.Write("Second Name: ");
            secondName = AddIfNotEmpty();

            Console.Write("Phone Number: ");
            phoneNumber = AddIfNotEmpty();

            Console.Write("Country: ");
            country = AddIfNotEmpty();

            notes.Add(new Notebook(name, secondName, phoneNumber, country));
            Notebook.conatactsCounter++;
            Console.WriteLine("New contact is created! Please, press any key to continue");
            Console.ReadKey();

            while (isOK)
            {
                Console.Clear();
                Console.WriteLine("Do you want to add some additional information? Type:");
                Console.WriteLine("1: Add Middle Name");
                Console.WriteLine("2: Add Birth Date");
                Console.WriteLine("3: Add Organization");
                Console.WriteLine("4: Add Position");
                Console.WriteLine("5: Add other notes");
                Console.WriteLine("n: No (exit from this contact)");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Type Middle Name: ");
                        notes[Notebook.conatactsCounter - 1].MiddleName = Console.ReadLine();
                        Console.WriteLine("Middle Name added! Please, press any key to continue");
                        Console.ReadKey();
                        break;
                    case "2":
                        while (true)
                        {
                            Console.Write("Enter day of month (e.g. 01, 21): ");
                            string day = Console.ReadLine();
                            Console.Write("Enter month (e.g. 11, 09): ");
                            string month = Console.ReadLine();
                            Console.Write("Enter year (e.g. 2003, 1999): ");
                            string year = Console.ReadLine();
                            try
                            {
                                notes[Notebook.conatactsCounter - 1].BirthDate = DateTime.Parse($"{day}.{month}.{year}");
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Wrong format! Try again!");
                            }
                        }
                        Console.WriteLine("Birth Date added! Please, press any key to continue");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Write("Type Organization: ");
                        notes[Notebook.conatactsCounter - 1].Organization = Console.ReadLine();
                        Console.WriteLine("Organization added! Please, press any key to continue");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Write("Type Position: ");
                        notes[Notebook.conatactsCounter - 1].Position = Console.ReadLine();
                        Console.WriteLine("Position added! Please, press any key to continue");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Write("Type your note: ");
                        notes[Notebook.conatactsCounter - 1].OtherNotes = Console.ReadLine();
                        Console.WriteLine("Note added! Please, press any key to continue");
                        Console.ReadKey();
                        break;
                    case "n":
                        isOK = false;
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
        public void ViewContact(ref List<Notebook> notes)
        {
            while (true)
            {
                Console.Clear();
                if (notes.Count == 0)
                {
                    Console.WriteLine("Looks like there are no contacts yet! Add some");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                
                string userCommand = "";
                int index = 0;
                GetCommand(ref userCommand, ref index, notes, "view");
                if(userCommand == "n")
                {
                    break;
                }

                Console.Clear();

                Console.WriteLine($"Second Name: {notes[index - 1].SecondName}");

                Console.WriteLine($"Name: {notes[index - 1].Name}");

                if (!String.IsNullOrEmpty(notes[index - 1].MiddleName))
                {
                    Console.WriteLine($"Middle Name: {notes[index - 1].MiddleName}");
                }

                Console.WriteLine($"Phone Number: {notes[index - 1].PhoneNumber}");

                Console.WriteLine($"Country: {notes[index - 1].Country}");

                if (notes[index - 1].BirthDate != DateTime.MinValue)
                {
                    Console.WriteLine($"Birh Date: {notes[index - 1].BirthDate.ToShortDateString()}");
                }
                if (!String.IsNullOrEmpty(notes[index - 1].Organization))
                {
                    Console.WriteLine($"Organisation: {notes[index - 1].Organization}");
                }
                if (!String.IsNullOrEmpty(notes[index - 1].Position))
                {
                    Console.WriteLine($"Position: {notes[index - 1].Position}");
                }
                if (!String.IsNullOrEmpty(notes[index - 1].OtherNotes))
                {
                    Console.WriteLine($"Other Notes: {notes[index - 1].OtherNotes}");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
  
        public void ViewAllContacts(ref List<Notebook> notes)
        {
            while (true)
            {                
                Console.Clear();
                if (notes.Count == 0)
                {
                    Console.WriteLine("Looks like there are no contacts yet! Add some");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }

                int indexCounter = 0;
                foreach (var item in notes)
                {
                    indexCounter++;
                    Console.WriteLine($"{indexCounter}: {item.Name} {item.SecondName}, {item.PhoneNumber}");
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Please, press any key to exit");
                Console.ReadKey();
                break;
            }
        }

        //Method that processes user's commands
        public void GetCommand(ref string userCommand, ref int index, List<Notebook> notes, string action)
        {
            while (true)
            {
                Console.Clear();
                int indexCounter = 0;
                Console.WriteLine($"Choose which contact you want to {action} (type index):");

                foreach (var item in notes)
                {
                    indexCounter++;
                    Console.WriteLine($"{indexCounter}: {item.Name} {item.SecondName}, {item.PhoneNumber}");
                }
                Console.WriteLine("n: exit from this menu");

                userCommand = Console.ReadLine();
                bool isNumber = Int32.TryParse(userCommand, out index);

                if (isNumber)
                {
                    if (index < 0 || index > indexCounter)
                    {
                        Console.WriteLine("Wrong command! Please, type a valid one");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (userCommand != "n")
                    {
                        Console.WriteLine("Wrong command! Please, type a valid one");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public static string AddIfNotEmpty()
        {
            string s;
            while (true)
            {
                s = Console.ReadLine();
                if (String.IsNullOrEmpty(s))
                {
                    Console.WriteLine("This field can't be empty! Try again.");
                    continue;
                }
                else
                    return s;
            }
        }
    }
}
