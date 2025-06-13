using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {


//Svar på frågor:
//Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion?

//Stack har ett snabbt och “stapelbart” minne där värden och referenser till objekt sparas.
//I Stacken är det ordningen “Last in, First out” som gäller. Heapen har flexibelt minne och är större.
//Här lagras exempelvis objekt och klasser. Det är långsammare(pga av sin flexibilitet).

//Vad är Value Types respektive Reference Types och vad skiljer dem åt?
//Värdetyper lagras på stacken och är det “direkta värdet”. Exempelvis på värdetyper är int, double, bool.
//Referenspekare lagras också på Stacken…men pekar på något som finns i Heapen. Exempel på Referenser är string, interface, klasser.

//Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?
//En int är en värdetyp.Det vill säga att värdet sparas direkt på stacken.
//I bilden på raden: x= y så betyder det att x får en kopia av själva värdet i y.När sedan y ändras till 4 så ändras inte x eftersom x och y är separata värdetyper.
//Den andra bilden där man anropar MyInt.Så betyder det att man skapar ett objekt av klassen MyInt.
//Det vill säga att x nu håller en referens.Y får också en ny referens.
//Men igenom x= y raden så får nu x en kopia av referensen i y…så när man nu ändrar i y så ändras även x.


            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            Console.WriteLine("Add a word to the list by using (+) before the word. Or (-) to remove the word. 0 exists to main menu.");

            List<string> myList = new List<string>();
            string inStr = string.Empty;
            do
            {
                char nav = '?';
                string value = string.Empty;


                Console.Write("Please enter input: ");
                inStr = Console.ReadLine();

                if (inStr.Length > 1)
                {
                    nav = inStr[0];
                    value = inStr.Substring(1);
                }

                switch (nav)
                {
                    case '+':
                        myList.Add(value);
                        Console.WriteLine($"\"{value}\" was added to the list.");
                        ShowListInfo(myList);
                        break;
                    case
                        '-':
                        if (myList.Remove(value))
                        {
                            Console.WriteLine($"\"{value}\" was removed to the list.");
                            ShowListInfo(myList);
                        }
                        else
                            Console.WriteLine($"\"{value}\" could not be from removed from the list.");

                        break;
                    default: Console.WriteLine("Incorrect input. Example \"+kalle\" will add \"kalle\", \"-kalle\" will remove \"kalle\".");
                        break;
                }

            } while (inStr != "0");


        }

        private static void ShowListInfo(List<string> list)
        {
            Console.WriteLine();
            Console.WriteLine($"Number of items in the List: {list.Count}");
            Console.WriteLine($"Capacaity of the List: {list.Capacity}");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Console.WriteLine("Use (+) before the word to enqueue to the Queue. Or (-) to dequeue. 0 exists to main menu.");


            Queue<string> myQueue = new Queue<string>();
            string inStr = string.Empty;

            do
            {
                char nav = '?';
                string value = string.Empty;

                Console.Write("Please enter input: ");
                inStr = Console.ReadLine();

                if (inStr.Length > 1)
                {
                    nav = inStr[0];
                    value = inStr.Substring(1);
                }

                if (inStr == "-")
                    nav = inStr[0];

                switch (nav)
                {
                    case '+': myQueue.Enqueue(value);
                        break;
                    case
                        '-':
                        if (myQueue.Count > 0)
                            Console.WriteLine($"{myQueue.Dequeue()} was removed.");
                        else
                            Console.WriteLine("The Queue is empty.");
                        break;
                    default: Console.WriteLine("Incorrect input. Example \"+kalle\" will add \"kalle\", \"-\" will remove an item.");
                        break;
                }

                Console.WriteLine("Current queue:");
                foreach (var item in myQueue)
                    Console.WriteLine(item);

            } while (inStr != "0");
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Console.WriteLine("Use (+) before the word to start a \"reverse string operation\". 0 exists to main menu.");

            Stack<string> myStack = new Stack<string>();
            string inStr = string.Empty;

            do
            {
                char nav = '?';
                string value = string.Empty;

                Console.Write("Please enter input: ");
                inStr = Console.ReadLine();

                if (inStr.Length > 1)
                {
                    nav = inStr[0];
                    value = inStr.Substring(1);
                }

                switch (nav)
                {
                    case '+':
                        for (int i = 0; i < value.Length; i++)
                            myStack.Push(value[i].ToString());
                        break;
                    case '0': return;
                    default: Console.WriteLine("Incorrect input. Example \"+kalle\" will reverse \"kalle\" or enter \"0\" to exit");
                        break;
                }

                if (myStack.Count < 0)
                    return;

                Console.Write("Your input reversed: ");

                while (myStack.Count > 0)
                    Console.Write(myStack.Pop());

                Console.WriteLine();

            } while (inStr != "0");
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("Please input a string with \"+[({})]\". A test will be formed on the input if it is \"well formed\". 0 exists to main menu.");

            string inStr = string.Empty;

            do
            {
                char nav = '?';
                string value = string.Empty;

                Console.Write("Please enter input: ");
                inStr = Console.ReadLine();

                if (inStr.Length > 1)
                {
                    nav = inStr[0];
                    value = inStr.Substring(1);
                }

                switch (nav)
                {
                    case '+':
                        if (IsWellFormed(value))
                            Console.WriteLine("Your string is wellformed");
                        else
                            Console.WriteLine("Your string is NOT wellformed");
                            break;
                    case '0': return;
                    default:
                        Console.WriteLine("Incorrect input. Example \"+kalle\" will reverse \"kalle\" or enter \"0\" to exit");
                        break;
                }

                Console.WriteLine();

            } while (inStr != "0");
        }
            

        static bool IsWellFormed(string input)
        {
            Stack<char> myStack = new Stack<char>();

            //Loop though string using char
            foreach (char item in input)
            {
                //Find any opening parenthesis
                if (item == '(' || item == '[' || item == '{')
                {
                    //Add to myStack
                    myStack.Push(item);
                }
                //If closing patenthesis is found...does it match the top(There have to be an opening somewhere)?
                else if (item == ')' || item == ']' || item == '}')
                {
                    if (myStack.Count == 0)
                        return false;

                    //Remove top of the stack
                    char top = myStack.Pop();

                    //It did NOT match!
                    if (!IsMatching(top, item))
                        return false;
                }
            }

            //if stack did not contain any paranthesis, great!
            return myStack.Count == 0;
        }

        static bool IsMatching(char start, char end)
        {
            if (start == '{' && end == '}') 
                return true;
            if (start == '(' && end == ')')
                return true;
            if (start == '[' && end == ']')
                return true;

            return false;
        }

    }
}

