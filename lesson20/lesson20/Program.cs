using Lesson20.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson20
{
    internal class Program
    {
        ////////////// declaration of delegate /////////////////////////
        public delegate string StringDelegate(string firstName, string lastName, int age);
        public delegate int SumNumbersDelegate(int number1, int number2);
        public delegate List<int> ListEditDelegate(List<int> list, int step);
        public delegate string TypeDelegate<T>(T type);
        public delegate bool FilterDelegate(Person person);
        //////////////////////////////////////////////////////////

        static void Main(string[] args)
        {
            Console.WriteLine("lesson 20 delegates and anonymous methods");
            Console.WriteLine();

            //////////// delagate test ////////////////////////////
            var testString = new StringDelegate(ConvertToString);
            Console.WriteLine(testString("Audrius", "Bukis", 36));
            Console.WriteLine();
            var testInteger = new SumNumbersDelegate(SumTwoIntegers);
            Console.WriteLine(testInteger(-16, 36));
            Console.WriteLine();
            var newList = new List<int>() { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
            var testlist = new ListEditDelegate(EveryOtherWord);
            foreach (var item in testlist(newList, 3))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(  );
            var testFunction = new TypeDelegate<int>(GetTypes);
            Console.WriteLine(testFunction(5));
            var testFunction2 = new TypeDelegate<double>(GetTypes);
            Console.WriteLine(testFunction2(5));
            Console.WriteLine();
            //////////////////////////////////////////////

            ////////// anonymous methods ////////////////
            Console.WriteLine();
            StringDelegate stringDelegate = delegate (string firstName, string lastName, int age)
            {
               return $"{firstName} {lastName} age {age}";
            };
            Console.WriteLine(stringDelegate("Audrius", "Bukis", 36));
            Console.WriteLine();

            SumNumbersDelegate sumNumbersDelegate = delegate (int number1, int number2)
            {
                return number1 + number2;
            };
            Console.WriteLine(sumNumbersDelegate(-16, 36));
            ListEditDelegate listEditDelegate = delegate (List<int> list, int step)
            {
                return list.Where((line, index) => index % step == 0).ToList();
            };
            var newList2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            foreach (var item in listEditDelegate(newList2, 2))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            TypeDelegate<int> typeDelegate = delegate (int type)
            {
                return type.GetType().ToString();
            };
            Console.WriteLine(typeDelegate(5));

            /////////// third TASK //////////////////////////////
            var personList = new List<Person>();
            personList.Add(new Person(36, "Audrius"));
            personList.Add(new Person(12, "Tadas"));
            personList.Add(new Person(18, "Marius"));
            personList.Add(new Person(66, "Pranas"));
            personList.Add(new Person(86, "Antanas"));
            personList.Add(new Person(55, "Gytis"));
            personList.Add(new Person(6, "Mindaugas"));
            personList.Add(new Person(25, "Andrius"));

            var isChild = new FilterDelegate(IsChild);
            var isAdult = new FilterDelegate(IsAdult);
            var isSenior = new FilterDelegate(IsSenior);
            Console.WriteLine();
            DisplayPeople("Children:", personList, isChild);
            Console.WriteLine();
            DisplayPeople("Adults:", personList, isAdult);
            Console.WriteLine();
            DisplayPeople("Seniors:", personList, isSenior);
            Console.WriteLine();
        }

        ////////////////// delegate methods //////////////////////////////////
        static string ConvertToString(string firstName, string lastName, int age)
        {
            return $"{firstName} {lastName} age {age}";
        }
        static int SumTwoIntegers(int number1, int number2)
        {
            return number1 + number2;
        }
        static List<int> EveryOtherWord(List<int> list, int step)
        {
            return list.Where((line, index) => index % step == 0).ToList();
        }
        public static string GetTypes<T>(T type)
        {
            return type.GetType().ToString();
        }
        /////////////////////////////////////////////////////////// 
        static bool IsChild(Person person)
        {
            return person.Age < 18; 
        }
        static bool IsAdult(Person person)
        {
            return person.Age >= 18 && person.Age < 65;
        }
        static bool IsSenior(Person person)
        {
            return person.Age >= 65;
        }
        static void DisplayPeople(string category, List<Person> people, FilterDelegate filterDelegate)
        {
            foreach (var person in people)
            {
                if (filterDelegate(person))
                {
                    Console.WriteLine($"{category} {person.Name} age {person.Age}");
                }
            }
        }
    }
}
