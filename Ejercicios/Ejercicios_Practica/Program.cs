using Practice_Exercises.Enum;
using Practice_Exercises.Exercises;

namespace Practice_Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string displayMenu = "1. Invertir número de dos cifras." +
                                 "\n2. Invertir número de tres cifras." +
                                 "\n3. Operaciones básicas." +
                                 "\n4. Compra en restaurant." +
                                 "\n5. Funciones básicas librería Math." +
                                 "\n6. Formatos de salida." +
                                 "\n7. Ejercicio propuesto." +
                                 "\n8. Mayor de dos números." +
                                 "\n9. Mayor de tres números.";
            int option;

            Console.Clear();

            Console.WriteLine(displayMenu);

            Console.Write("\nIngrese una opción: ");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option) 
            {
                case (int)MenuOptions.InvertTwoDigits:
                    Exercises.Exercises.InvertTwoDigits();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.InvertThreeDigits:
                    Exercises.Exercises.InvertThreeDigits();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.BasicOperations:
                    Exercises.Exercises.BasicOperations();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.RestaurantBuy:
                    Exercises.Exercises.RestaurantBuy();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.MathBasicOperations:
                    Exercises.Exercises.MathBasicOperations();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.OutputFormat:
                    Exercises.Exercises.OutputFormat();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.ProposedExercise:
                    Exercises.Exercises.ProposedExercise();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.GreaterOfTwoNumbers:
                    Exercises.Exercises.GreaterOfTwoNumbers();
                    Console.ReadKey();
                    Main(args);
                    break;
                case (int)MenuOptions.GreaterOfThreeNumbers:
                    Exercises.Exercises.GreaterOfThreeNumbers();
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