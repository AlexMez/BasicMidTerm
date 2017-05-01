using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu)
            {

                displayMenu = MainMenu();

            }

        }


        public static bool MainMenu()
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("1) Search for Title by Author");
            Console.WriteLine("2) Search for title by Keyword");
            Console.WriteLine("3) Checkout");
            Console.WriteLine("4) Return");
            Console.WriteLine("5) Donate a Book");
            Console.WriteLine("6) Quit");
            int userInput = Validate.RangeValidator(1, 6);

            if (userInput == 1)
            {
                //search by author

                PrintList(GetList());

                SearchByAuthor(GetList());


                return true;
            }
            else if (userInput == 2)
            {
                //search by keyword



                SearchbyKeyWord(GetList());


                return true;
            }
            else if (userInput == 3)
            {
                //checkout

                PrintList(GetList());

                Checkout(GetList());


                return true;
            }
            else if (userInput == 4)
            {
                //return

                PrintList(GetList());

                Return(GetList());


                return true;
            }
            else if (userInput == 5)
            {

                Console.WriteLine("Donate a book coming soon");
                
                return true;
            }
            else if (userInput == 6)
            {

                //quit
                
                return false;
            }
            else
            {
                return true;
            }
        }



        public static void WriteToText(List<Books> inputList)
        {
            StreamWriter sw = new StreamWriter("../../TextFile1.txt", false);

            foreach (var item in inputList)
            {
                sw.WriteLine(item.BTitle + "," + item.BAuthor + "," + item.BStatus + ","
                    + item.BDueDate);

            }
            sw.Close();
        }

        public static void PrintList(List<Books> InputList)
        {
            foreach (var item in InputList)
            {
                Console.WriteLine("Title:\t" + item.BTitle);
                Console.WriteLine("Author:\t" + item.BAuthor);
                Console.WriteLine("Status:\t" + item.BStatus);
                Console.WriteLine("DueDate:\t" + item.BDueDate);
                Console.WriteLine("\n=====================================\n");
            }
        }

        public static List<Books> GetList()
        {

            //new list called catalogue
            List<Books> Catalogue = new List<Books>();
            StreamReader reader = new StreamReader("../../TextFile1.txt ");
            //this is one line from text file or one book
            char[] comma = { ',' };
            for (int i = 0; i < 14; i++)

            {
                string line = reader.ReadLine();
                //string[] book = new string[4];
                string[] book = line.Split(comma);
                string Title = book[0];
                string Author = book[1];
                string Status = book[2];
                string DueDate = book[3];
                Catalogue.Add(new Books(Title, Author, Status, DueDate));
            }
            reader.Close();
            return Catalogue;
        }

        public static void Return(List<Books> inputCatalogue)
        {
            Console.Write("Return: ");
            string ItemToReturn = Console.ReadLine().ToLower();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string Titlelower = item.BTitle.ToLower();
                if (Titlelower == ItemToReturn && !(item.BStatus == "Avaiable"))
                {
                    item.BStatus = "Available";
                    item.BDueDate = "N/A";
                    Console.WriteLine($"thank you for returning {item.BTitle}.");
                    //if (Convert.ToDouble(item.BDueDate) > Convert.ToDouble(myDateTime))
                    //{
                    //    Console.WriteLine("your item is late you owe us money");
                    //}
                }
                else
                {
                    count++;
                }

            }
            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("that book is already returned or not in our system");
            }

            WriteToText(inputCatalogue);


        }

        public static void Checkout(List<Books> inputCatalogue)
        {
            Console.Write("Check out: ");
            string ItemToCheckOut = Console.ReadLine().ToLower();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string Titlelower = item.BTitle.ToLower();
                if (Titlelower == ItemToCheckOut && !(item.BStatus == "Checked-out"))
                {
                    item.BStatus = "Checked-out";
                    item.BDueDate = myDateTime.AddDays(14).ToShortDateString();
                    Console.WriteLine($"{item.BTitle} is checked out.");
                    Console.WriteLine($"and is due on {item.BDueDate}");
                }
                else
                {
                    count++;
                }

            }
            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("not available");
            }

            WriteToText(inputCatalogue);

        }

        public static void SearchbyKeyWord(List<Books> inputCatalogue)
        {
            Console.WriteLine("Enter a keyword search: ");
            int count = 0;
            char[] space = { ' ' };
            string KeyWordSearch = Console.ReadLine().ToLower();

            foreach (var item in inputCatalogue)
            {
                string titleToLower = item.BTitle.ToLower();
                if (titleToLower.Split(space).Contains(KeyWordSearch))
                {
                    Console.WriteLine("yes we have: ");

                    Console.WriteLine("Title:\t" + item.BTitle);
                    Console.WriteLine("Author:\t" + item.BAuthor);
                    Console.WriteLine("Status:\t" + item.BStatus);
                    Console.WriteLine("DueDate:\t" + item.BDueDate);
                    Console.WriteLine("\n=====================================\n");


                }
                else
                {
                    count++;
                }

            }
            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("That does not match anything in our records");
            }
        }

        public static void SearchByAuthor(List<Books> inputCatalogue)
        {
            Console.Write("Search by Author: ");
            string AuthorSearch = Console.ReadLine().ToLower();

            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string Titlelower = item.BAuthor.ToLower();
                if (Titlelower == AuthorSearch)
                {
                    Console.WriteLine("Yes we have: ");
                    Console.WriteLine("Title:\t" + item.BTitle);
                    Console.WriteLine("Author:\t" + item.BAuthor);
                    Console.WriteLine("Status:\t" + item.BStatus);
                    Console.WriteLine("DueDate:\t" + item.BDueDate);
                    Console.WriteLine("\n=====================================\n");
                }
                else
                {
                    count++;
                }

            }
            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("We do not have a book that matches that author");
            }

            WriteToText(inputCatalogue);

        }
    }
}
