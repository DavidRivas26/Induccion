using Proposed_Exercises.Enum;
using Proposed_Exercises.Exercises;

namespace Proposed_Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string displayMenu = string.Empty, lineBreak = "\n";
            
            for (int counter = 1; counter <= 24; counter++)
            {
                displayMenu += $"{(counter == 1 ? "" : lineBreak)}{counter}. Ejercicio {counter}.";
            }
            
            int option;

            Console.Clear();

            Console.WriteLine(displayMenu);

            Console.Write("\nIngrese una opción: ");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case (int)MenuOptions.Exercise1:
                    Exercises.Exercises.Exercise1();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise2:
                    Exercises.Exercises.Exercise2();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise3:
                    Exercises.Exercises.Exercise3();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise4:
                    Exercises.Exercises.Exercise4();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise5:
                    Exercises.Exercises.Exercise5();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise6:
                    Exercises.Exercises.Exercise6();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise7:
                    Exercises.Exercises.Exercise7();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise8:
                    Exercises.Exercises.Exercise8();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise9:
                    Exercises.Exercises.Exercise9();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise10:
                    Exercises.Exercises.Exercise10();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise11:
                    Exercises.Exercises.Exercise11();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise12:
                    Exercises.Exercises.Exercise12();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise13:
                    Exercises.Exercises.Exercise13();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise14:
                    Exercises.Exercises.Exercise14();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise15:
                    Exercises.Exercises.Exercise15();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise16:
                    Exercises.Exercises.Exercise16();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise17:
                    Exercises.Exercises.Exercise17();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise18:
                    Exercises.Exercises.Exercise18();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise19:
                    Exercises.Exercises.Exercise19();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise20:
                    Exercises.Exercises.Exercise20();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise21:
                    Exercises.Exercises.Exercise21();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise22:
                    Exercises.Exercises.Exercise22();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise23:
                    Exercises.Exercises.Exercise23();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.Exercise24:
                    Exercises.Exercises.Exercise24();
                    Console.ReadKey();
                    Main(args);
                    break;
                default:
                    Main(args);
                    break;
            }
        }
    }
}