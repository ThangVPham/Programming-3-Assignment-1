using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP212Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selection Questions: ");
            Console.WriteLine("1. Question 1");
            Console.WriteLine("2. Question 2");
            int question = Int32.Parse(Console.ReadLine());
            Console.Clear();

            //Question 1
            if(question == 1) { 
                Student[] students = new Student[5];
                int[] numberArray = new int[5];

                Console.WriteLine("Please Select From The Following: ");
                Console.WriteLine("1. Input Integers");
                Console.WriteLine("2. Input Student Names");
                int choice = Int32.Parse(Console.ReadLine());
                Console.Clear();
                //Option 1
                if (choice == 1)
                {
                    for (int a = 0; a < numberArray.Length; a++)
                    {
                        Console.WriteLine("Enter integer: ");
                        numberArray[a] = Int32.Parse(Console.ReadLine());
                    }

                    //Display Input Array
                    Console.Write("Array: {");
                    int k = 0;
                    for (k = 0; k < numberArray.Length - 1; k++)
                    {
                        Console.Write(numberArray[k] + ", ");
                    }
                    Console.Write(numberArray[k]);
                    Console.WriteLine("}");

                    //Search through number array for match
                    Console.Write("Search: ");
                    int input = Int32.Parse(Console.ReadLine());
                    int numberExist = 1;
                    int location = 0;
                    for (int j = 0; j < numberArray.Length; j++)
                    {
                        numberExist = Search<int>(input, numberArray[j]);
                        if (numberExist == 0)
                        {
                            location = j;
                            break;
                        }
                    }
                    if (numberExist == 0)
                    {
                        Console.WriteLine("Response: " + input + " exists at index " + location);
                    }
                    else
                    {
                        Console.WriteLine("Response: -1");
                    }
                }

                //Option 2
                if (choice == 2)
                {
                    string input;
                    Console.WriteLine("Please Enter Student's Name");
                    for (int i = 0; i < students.Length; i++)
                    {
                        Console.Write("Student's Name: ");
                        input = Console.ReadLine();
                        students[i] = new Student(input);
                    }

                    //Display Student Array
                    Console.Write("Array: {");
                    int k = 0;
                    for (k = 0; k < students.Length - 1; k++)
                    {
                        Console.Write(students[k].Name + ", ");
                    }
                    Console.Write(students[k].Name);
                    Console.WriteLine("}");

                    //Search through Student array for match
                    Console.Write("Search: ");
                    input = Console.ReadLine();
                    int studentExist = 1;
                    int location = 0;
                    for (int i = 0; i < students.Length; i++)
                    {
                        studentExist = students[i].CompareTo(input);
                        if (studentExist == 0)
                        {
                            location = i;
                            break;
                        }
                    }

                    if (studentExist == 0)
                    {
                        Console.WriteLine("Response: " + input + " exists at index " + location);
                    }
                    else
                    {
                        Console.WriteLine("Response: -1");
                    }

                }
            }

            //-----------------------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------------------
            //Question 2:
            else if (question == 2)
            {
                int x = 10;
                Console.Write("Enter a sentence: ");
                string test = Console.ReadLine();              
                int result = x.NumOfWords(test);
                Console.WriteLine("Number of words: " + result);
            }


            Console.ReadKey();
        }

        //Generic Search Method
        public static int Search<T>(T item, T arrayElement) where T : IComparable<T>
        {
            int exist = 0;
            exist = item.CompareTo(arrayElement);

            return exist;
        }
    }



    public class Student : IComparable<string>
    {
        public string Name
        {
            get; set;
        }
        public Student(string name)
        {
            Name = name;
        }
        public int CompareTo(string other)
        {
            if (this.Name.ToLower() == other.ToLower())
                return 0;
            else
                return 1;
        }
    }

    public static class StringBuilder
    {
        public static int NumOfWords(this int i, string sentence)
        {
           
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            int num =  sentence.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

            return num;
        }
    }

    


}
