//Program that asks for an array, prints it, sorts it or searches it depending on user input

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            int flg = 0;
            int flg2 = 0;
            string fname;
            string lname;
            int studentnum = 0;
            int count = 0;
            string answ;
            int opt = 0;
            int[] array;

            //loops for control of program
            while (flg == 0)
            {
                Console.Clear();
                Console.WriteLine("This program asks for your information, a series of numbers, and either sorts it or searches for a number");
                //asking for user info
                Console.WriteLine("Enter your First Name:");
                fname = Console.ReadLine();
                if (string.IsNullOrEmpty(fname))
                {
                    continue;
                }
                Console.WriteLine("Enter your Last Name:");
                lname = Console.ReadLine();
                if (string.IsNullOrEmpty(lname))
                {
                    continue;
                }
                Console.WriteLine("Enter your Student Number:");
                if (!int.TryParse(Console.ReadLine(), out studentnum))
                {
                    continue;
                }
                Console.WriteLine($"Hi {fname} {lname}, Your Student number is: {studentnum}");

                //asking for num of elements in array and option
                Console.WriteLine("Enter the count value for the array:");
                if (!int.TryParse(Console.ReadLine(), out count))
                {
                    continue;
                }
                array = makearray(count);
                Console.WriteLine("1. Array Sort operation.\n2. Array Search operation.");
                if (!int.TryParse(Console.ReadLine(), out opt))
                {
                    continue;
                }
                while (flg2 == 0)
                {
                    switch (opt)
                    {
                        case 1:
                            //sorting
                            Console.WriteLine($"Hi {fname}, you have chosen array sort operation.\nThe sorted array is:");
                            Array.Sort(array);
                            foreach (int i in array)
                            {
                                Console.WriteLine(i);
                            }
                            Console.WriteLine("Do you want to continue execution (Y/N)?");
                            answ = Console.ReadLine().ToLower();
                            if (!string.IsNullOrEmpty(answ))
                            {
                                if (string.Equals(answ, "y"))
                                {
                                    opt++;
                                }
                                else if (string.Equals(answ, "n"))
                                {
                                    flg2++;
                                }
                            }
                            else
                            {
                                flg2++;
                            }
                            break;
                        case 2:
                            //searching
                            Console.WriteLine($"Hi {lname}, you have chosen array search operation.\nEnter the number to be searched:");
                            if (int.TryParse(Console.ReadLine(), out int srch))
                                if (array.Contains(srch))
                                {
                                    Console.WriteLine($"The number {srch} is found in the array");
                                }
                                else
                                {
                                    Console.WriteLine($"The number {srch} is not found in the array");
                                }
                            Console.WriteLine("Do you want to continue execution (Y/N)?");
                            answ = Console.ReadLine() ?? "n".ToLower();
                            if (string.Equals(answ, "y"))
                            {
                                opt--;
                            }
                            else if (string.Equals(answ, "n"))
                            {
                                flg2++;
                            }
                            break;
                        default:
                            flg2++;
                            break;
                    }
                }
                //asking if want to exit or not
                Console.WriteLine("Do you want to exit? (Y/N)?");
                answ = Console.ReadLine() ?? "n".ToLower();
                if (string.Equals(answ, "y"))
                {
                    flg++;
                }
            }
        }

        //method for making an array and listing it
        public static int[] makearray(int count)
        {
            int flg = 0;
            int[] array;
            array = new int[count];
            int num = 0;
            for (int i = 0; i < count; i++)
            {

                while (flg == 0)
                {
                    Console.Write($"Enter element[{i + 1}]:");
                    if (int.TryParse(Console.ReadLine(), out num))
                    {
                        array[i] = num;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine("The entered array elements are:");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            return array;
        }
    }
}