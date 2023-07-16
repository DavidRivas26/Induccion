using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Exercises.Exercises
{
    public class Exercises
    {
        public static void InvertTwoDigits()
        {
            int Number, invertedNumber, Unity, Ten;

            Console.Write("\nIngrese un número de dos cifras: ");
            Number = Convert.ToInt32(Console.ReadLine());

            Ten = Number / 10;
            Unity = Number % 10;
            invertedNumber = (Unity * 10) + Ten;

            Console.WriteLine($"\nEl número invertido es: {invertedNumber}"); 
        }

        public static void InvertThreeDigits()
        {
            int Number, invertedNumber, Unity, Ten, Hundred;

            Console.Write("\nIngrese un número de tres cifras: ");
            Number = Convert.ToInt32(Console.ReadLine());

            Hundred = Number / 100;
            Number = Number % 100;
            Ten = Number / 10;
            Unity = Number % 10;
            invertedNumber = (Unity * 100) + (Ten * 10) + Hundred;

            Console.WriteLine($"\nEl número invertido es: {invertedNumber}");
        }

        public static void BasicOperations()
        {
            int firtsNumber, secondNumber;
            string response = string.Empty;

            Console.Write("\nIngrese el primer número: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese el segundo número: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            response =  $"\nLa suma es: {firtsNumber + secondNumber}\nLa resta es: {firtsNumber - secondNumber}" +
                        $"\nLa división es: {firtsNumber / secondNumber}\nEl residuo es: {firtsNumber % secondNumber}" +
                        $"\nLa multiplicación es: {firtsNumber * secondNumber}";

            Console.WriteLine(response);
        }

        public static void RestaurantBuy()
        {
            byte qtyHamburguer, qtyFrench, qtyDrinks;
            double amount, priceHamburguer = 2, priceFrench = 1.2, priceDrinks = 0.8;

            Console.WriteLine($"\nPrecios: 1. Hamburguesa {priceHamburguer}$. 2. Papas {priceFrench}$. 3. Bebida {priceDrinks}$.");

            Console.Write("\nIngrese la cantidad de hamburguesas: ");
            qtyHamburguer = Convert.ToByte(Console.ReadLine());

            Console.Write("\nIngrese la cantidad de papas: ");
            qtyFrench = Convert.ToByte(Console.ReadLine());

            Console.Write("\nIngrese la cantidad de bebidas: ");
            qtyDrinks = Convert.ToByte(Console.ReadLine());

            amount = (qtyHamburguer * priceHamburguer) + (qtyFrench * priceFrench) + (qtyDrinks * priceDrinks);

            Console.WriteLine($"\nMonto a pagar: {amount}");
        }

        public static void MathBasicOperations()
        {
            int firtsNumber;
            decimal secondNumber;
            string response = string.Empty;

            Console.Write("\nIngrese un número entero: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese un número decimal: ");
            secondNumber = Convert.ToDecimal(Console.ReadLine());

            response =  $"\nEl valor absoluto es: {Math.Abs(secondNumber)}\nLa potencia cuadrada es: {Math.Pow(firtsNumber, 2)}" +
                        $"\nEl seno es: {Math.Sin(firtsNumber)}\nEl coseno es: {Math.Cos(firtsNumber)}" +
                        $"\nEl número máximo es: {Math.Max(firtsNumber, secondNumber)}\nEl número mínimo es: {Math.Min(firtsNumber, secondNumber)}" +
                        $"\nLa parte entera es: {Math.Truncate(secondNumber)}\nEl redondeo es: {Math.Round(secondNumber)}";

            Console.WriteLine(response);
        }

        public static void OutputFormat()
        {
            int Base, Height, Area;
            string response = string.Empty, description = "El area del triagulo es";

            Console.Write("\nIngrese la base: ");
            Base = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese la altura: ");
            Height = Convert.ToInt32(Console.ReadLine());

            Area = (Base * Height) / 2;

            response =  $"\n{description}: {String.Format("{0:####.00}", Area)}\n{description}: {String.Format("{0:c}", Area)}" +
                        $"\n{description}: {String.Format("{0:f}", Area)}\n{description}: {String.Format("{0:g}", Area)}" +
                        $"\n\nHoy es: {String.Format("Hoy es {0:F}", DateTime.Now)}" +
                        $"\nHoy es: {String.Format("Hoy es {0:dddd}{0:dd/MM/yyy}", DateTime.Now)}";

            Console.WriteLine(response);
        }

        public static void ProposedExercise()
        {
            //El usuario debe ingresar dos números y el programa mostrará el resultado de la operación (a+b)*(a-b)

            int firtsNumber, secondNumber, result;

            Console.Write("\nIngrese el primer número: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese el segundo número: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            result = (firtsNumber + secondNumber) * (firtsNumber - secondNumber);

            Console.WriteLine($"\nEl resultado es: {result}");
        }

        public static void GreaterOfTwoNumbers()
        {
            int firtsNumber, secondNumber;
            string response = string.Empty;

            Console.Write("\nIngrese el primer número: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese el segundo número: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            if (firtsNumber == secondNumber)
                response = $"\nLos números ingresados son iguales";
            else if (firtsNumber > secondNumber)
                response = $"\nEl primer número {firtsNumber} es mayor que el segundo número {secondNumber}";
            else if (firtsNumber < secondNumber)
                response = $"\nEl segundo número {secondNumber} es mayor que el primer número {firtsNumber}";

            Console.WriteLine(response);
        }

        public static void GreaterOfThreeNumbers()
        {
            int firtsNumber, secondNumber, thirdNumber, major, minor;

            Console.Write("\nIngrese el primer número: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese el segundo número: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese el tercer número: ");
            thirdNumber = Convert.ToInt32(Console.ReadLine());

            major = firtsNumber; minor = firtsNumber;

            if (secondNumber > major) major = secondNumber;
            if (thirdNumber > major) major = thirdNumber;
            if (secondNumber > minor) minor = secondNumber;
            if (thirdNumber < minor) minor = thirdNumber;

            Console.WriteLine($"\nEl mayor es: {major} \nEl menor es: {minor}");
        }
    }
}
