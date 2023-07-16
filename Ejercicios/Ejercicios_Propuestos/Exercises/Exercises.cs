using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Proposed_Exercises.Exercises
{
    public class Exercises
    {
        public static void Exercise1()
        {
            int firtsNumber, secondNumber;
            string response = string.Empty;

            Console.Write("\nIngrese el primer número: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese el segundo número: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            response = $"\nLa división es: {firtsNumber / secondNumber}\nEl residuo es: {firtsNumber % secondNumber}";

            Console.WriteLine(response);
        }

        public static void Exercise2()
        {
            int firtsNumber, secondNumber;
            string response = string.Empty;

            Console.Write("\nIngrese el primer número entero: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese el segundo número entero: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            if (firtsNumber % secondNumber == 0)
                response = $"\nEl primer número es ({firtsNumber}) y es multiplo del segundo número ({secondNumber})";
            else
                response = $"\nEl primer número no es ({firtsNumber}) y no es multiplo del segundo número ({secondNumber})";

            Console.WriteLine(response);
        }

        public static void Exercise3()
        {
            int firtsNumber, secondNumber;
            string response = string.Empty;

            Console.Write("\nIngrese el primer número entero: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            if (firtsNumber == 0)
            {
                response = "\nEl producto de 0 por cualquier número es 0";
            }

            else
            {
                Console.Write("\nIngrese el segundo número entero: ");
                secondNumber = Convert.ToInt32(Console.ReadLine());

                response = $"\nEl producto es: {firtsNumber * secondNumber}";
            }

            Console.WriteLine(response);

        }

        public static void Exercise4()
        {
            int firtsNumber, secondNumber;
            string response = string.Empty;

            Console.Write("\nIngrese el primer número real: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese el segundo número real: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            if (secondNumber == 0)
                response = "\nError: No se puede dividir entre cero";

            else
                response = $"\nEl resultado es: {firtsNumber / secondNumber}";

            Console.WriteLine(response);
        }

        public static void Exercise5()
        {
            char[] vocals = { 'a', 'e', 'i', 'o', 'u' };
            char input;

            Console.Write("\nIngrese una letra: ");
            input = Convert.ToChar(Console.ReadLine());

            foreach (char vocal in vocals)
            {
                if (input == vocal)
                    Console.WriteLine($"\nHas insertado la vocal: {vocal}");
            }
        }

        public static void Exercise6()
        {
            int firtsNumber, secondNumber;
            string response = string.Empty;

            Console.Write("\nIngrese el primer número entero: ");
            firtsNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese el segundo número entero: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());

            if (firtsNumber > 0 || secondNumber > 0)
                response = "\nUno de los números es positivo";
            if (firtsNumber > 0 && secondNumber > 0)
                response = "\nLos dos números son positivo";
            if (firtsNumber < 0 && secondNumber < 0)
                response = "\nNinguno de los números es positivo";

            Console.WriteLine(response);
        }

        public static void Exercise7()
        {
            int number;
            string response = string.Empty;

            Console.Write("\nIngrese un número: ");
            number = Convert.ToInt32(Console.ReadLine());

            if (number > 0)
                response = $"\nEl numero absoluto es: {number}";
            else
                response = $"\nEl numero absoluto es: {Math.Abs(number)}";

            Console.WriteLine(response);
        }

        public static void Exercise8()
        {
            int counter = 1;
            string lineBreak = "\n";

            while (counter <= 10)
            {
                Console.WriteLine($"{(counter == 1 ? lineBreak : "")} {counter}");
                counter++;
            }
        }

        public static void Exercise9()
        {
            int counter = 26;
            string lineBreak = "\n";

            while (counter >= 10)
            {
                if (counter % 2 == 0)
                    Console.WriteLine($"{(counter == 26 ? lineBreak : "")} {counter}");
                counter--;
            }
        }

        public static void Exercise10()
        {
            int counter = 1;
            string lineBreak = "\n";

            do
            {
                Console.WriteLine($"{(counter == 1 ? lineBreak : "")} {counter}");
                counter++;
            }
            while (counter <= 10);
        }

        public static void Exercise11()
        {
            int counter = 26;
            string lineBreak = "\n";

            do
            {
                if (counter % 2 == 0)
                    Console.WriteLine($"{(counter == 26 ? lineBreak : "")} {counter}");
                counter--;
            }
            while (counter >= 10);
        }

        public static void Exercise12()
        {
            int counter = 15;
            string lineBreak = "\n";

            while (counter >= 5)
            {
                Console.WriteLine($"{(counter == 15 ? lineBreak : "")} {counter}");
                counter--;
            }
        }

        public static void Exercise13()
        {
            string lineBreak = "\n";

            for (int counter = 2; counter <= 16; counter = counter + 2)
            {
                Console.WriteLine($"{(counter == 2 ? lineBreak : "")} {counter}");
            }
        }

        public static void Exercise14()
        {
            int counter = 1;
            string lineBreak = "\n";

            while (counter <= 50)
            {
                if (counter % 3 == 0)
                    Console.WriteLine($"{(counter == 3 ? lineBreak : "")} {counter}");
                counter++;
            }
        }

        public static void Exercise15()
        {
            int vectorSize;
            int[] numbers;
            string response = string.Empty;

            Console.Write("\nIngrese el tamaño del vector: ");
            vectorSize = Convert.ToInt32(Console.ReadLine());

            numbers = new int[vectorSize];

            for (int counter = 0; counter < vectorSize; counter++)
            {
                Console.Write("\nIngrese un valor: ");
                numbers[counter] = Convert.ToInt32(Console.ReadLine());
            }

            int minor = numbers[0];
            for (int counter = 0; counter < vectorSize; counter++) 
            {
                if (numbers[counter] < minor)
                    minor = numbers[counter];
            }

            int count = 0;
            for (int counter = 0; counter < vectorSize; counter++)
            {
                if (numbers[counter] == minor)
                    count++;
            }
            
            response += $"\nEl menor es {minor}";

            if(count > 1)
                response += $", El menor se repite";

            Console.Write(response);
        }

        public static void Exercise16()
        {
            double[] salaries = new double[5];

            for (int counter = 0; counter < 5; counter++)
            {
                Console.Write("\nIngrese el sueldo: ");
                salaries[counter] = Convert.ToDouble(Console.ReadLine());
            }

            for(int iterator = 0; iterator <  4; iterator++) 
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (salaries[counter] > salaries[counter + 1])
                    {
                        double major = salaries[counter];
                        salaries[counter] = salaries[counter + 1];
                        salaries[counter + 1] = major;
                    }
                }
            }

            foreach (double salary in salaries)
            {
                Console.Write($"\n{salary}");
            }
        }

        public static void Exercise17()
        {
            string[] countries = new string[5];
            string response = "\n";

            for (int counter = 0; counter < 5; counter++)
            {
                Console.Write("\nIngrese el pais: ");
                countries[counter] = Console.ReadLine();
            }

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (countries[counter].CompareTo(countries[counter + 1]) > 0)
                    {
                        string major = countries[counter];
                        countries[counter] = countries[counter + 1];
                        countries[counter + 1] = major;
                    }
                }
            }

            foreach (string country in countries)
            {
                response += $"{country}\n";
            }

            Console.WriteLine(response);
        }

        public static void Exercise18()
        {
            string[] countries = new string[5];
            int[] populations = new int[5];
            string response = "\n";

            for (int counter = 0; counter < 5; counter++)
            {
                Console.Write("\nIngrese el pais: ");
                countries[counter] = Console.ReadLine();

                Console.Write("\nIngrese los habitantes: ");
                populations[counter] = Convert.ToInt32(Console.ReadLine());
            }

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (populations[counter] < populations[counter + 1])
                    {
                        int major = populations[counter];
                        populations[counter] = populations[counter + 1];
                        populations[counter + 1] = major;
                    }
                }
            }

            for (int counter = 0; counter < 5; counter++)
            {
                response += $"{countries[counter]}\t{populations[counter]}\n";
            }

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (countries[counter].CompareTo(countries[counter + 1]) > 0)
                    {
                        string major = countries[counter];
                        countries[counter] = countries[counter + 1];
                        countries[counter + 1] = major;
                    }
                }
            }

            response += "\n";

            for (int counter = 0; counter < 5; counter++)
            {
                response += $"{countries[counter]}\t{populations[counter]}\n";
            }

            Console.WriteLine(response);
        }

        public static void Exercise19()
        {
            string[,] matrix = new string[2, 5];
            string response = "\n";

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    Console.Write("\nIngrese componente: ");
                    matrix[rows, columns] = Console.ReadLine();
                }

            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    response += $"{matrix[rows, columns]}\t";
                }
                response += "\n";
            }

            Console.WriteLine(response);
        }

        public static void Exercise20()
        {
            string[] countries = new string[4];
            int[,] temperature = new int[4, 3];
            int[] temperatureQuarterly = new int[4];
            string response = string.Empty;

            for (int rows = 0; rows < countries.Length; rows++)
            {
                Console.Write($"\nIngrese el nombre de la provincia {rows + 1}: ");
                countries[rows] = Console.ReadLine();
                
                for (int columns = 0; columns < temperature.GetLength(1); columns++)
                {
                    Console.Write($"\nIngrese temperatura mensual {columns + 1}: ");
                    temperature[rows, columns] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int rows = 0; rows < countries.Length; rows++)
            {
                response += $"\nProvincia: {countries[rows]}:";
                for (int columns = 0; columns < temperature.GetLength(1); columns++)
                {
                    response += temperature[rows, columns] + "\t";
                }
                response += "\n";
            }

            for (int rows = 0; rows < temperature.GetLength(0); rows++)
            {
                int sum = 0;
                for (int columns = 0; columns < temperature.GetLength(1); columns++)
                {
                    sum = sum + temperature[rows, columns];
                }
                temperatureQuarterly[rows] = sum / 3;
            }

            response += "\nTemperaturas trimestrales.";
            for (int rows = 0; rows < countries.Length; rows++)
            {
                response += $"\n\n{countries[rows]}: {temperatureQuarterly[rows]}";
            }

            int HigherTemp = temperatureQuarterly[0];
            string HigherCountry = countries[0];
            for (int rows = 0; rows < countries.Length; rows++)
            {
                if (temperatureQuarterly[rows] > HigherTemp)
                {
                    HigherTemp = temperatureQuarterly[rows];
                    HigherCountry = countries[rows];
                }
            }
            response += $"\n\nLa provincia con temperatura trimestral mayor es" +
                $" {HigherCountry} que tiene una temperatura de {HigherTemp}";

            Console.WriteLine(response);
        }

        public static void Exercise21()
        {
            string[][] matrix = new string[5][];
            string response = "\n";

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                matrix[rows] = new string[rows + 1];

                for (int columns = 0; columns < matrix[rows].Length; columns++)
                {
                    Console.Write("\nIngrese el componente: ");
                    matrix[rows][columns] = Console.ReadLine();
                }
            }

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                for (int columns = 0; columns < matrix[rows].Length; columns++)
                {
                    response += $"{matrix[rows][columns]}\t";
                }
                response += "\n";
            }
            Console.WriteLine(response);
        }

        public static void Exercise22()
        {
            string[] nameEmployee = new string[3];
            int[][] absences = new int[3][];
            int QuantityAbsences, position = 0, lessAbsences = 0;
            string response = "\n";

            for (int counter = 0; counter < 3; counter++) 
            {
                Console.Write("\nIngrese el nombre del empleado: ");
                nameEmployee[counter] = Console.ReadLine();

                Console.Write("\nIngrese la cantidad de ausencias: ");
                QuantityAbsences = Convert.ToInt32(Console.ReadLine());

                if (QuantityAbsences < lessAbsences)
                    position = counter;

                lessAbsences = QuantityAbsences;

                absences[counter] = new int[QuantityAbsences];

                for (int quantity = 0; quantity < QuantityAbsences; quantity++) 
                {
                    Console.Write("\nIngrese el dia la ausencia: ");
                    absences[counter][quantity] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int rows = 0; rows < absences.Length; rows++) 
            {
                response += $"{nameEmployee[rows]}\t";
                for (int column = 0; column < absences[rows].Length; column++)
                {
                    response += $"{absences[rows][column]}\t";
                }
                response += "\n";
            }

            response += $"\nEl empleado que menos falto fue: {nameEmployee[position]}";

            Console.WriteLine(response);
        }

        public static void Exercise23()
        {
            int rows, columns;
            string[,] matrix;
            string element;
            string response = "\n";

            Console.Write("\nIngrese la cantidad de filas: ");
            rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese la cantidad de columnas: ");
            columns = Convert.ToInt32(Console.ReadLine());

            matrix = new string[rows,columns];

            for (int numberRows = 0; numberRows < matrix.GetLength(0); numberRows++)
            {
                for (int numberColumns = 0; numberColumns < matrix.GetLength(1); numberColumns++)
                {
                    Console.Write("\nIngrese componente: ");
                    matrix[numberRows, numberColumns] = Console.ReadLine();
                }
            }

            for (int numberRows = 0; numberRows < matrix.GetLength(0); numberRows++) 
            {
                element = matrix[0, numberRows];
                matrix[0, numberRows] = matrix[1, numberRows];
                matrix[1, numberRows] = element;
            }

            for (int numberRows = 0; numberRows < matrix.GetLength(0); numberRows++)
            {
                for (int numberColumns = 0; numberColumns < matrix.GetLength(1); numberColumns++)
                {
                    response += $"{matrix[numberRows, numberColumns]}\t";
                }
                response += "\n";
            }

            Console.WriteLine(response);

        }

        public static void Exercise24()
        {
            int rows, columns;
            string[,] matrix;

            Console.Write("\nIngrese la cantidad de filas: ");
            rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIngrese la cantidad de columnas: ");
            columns = Convert.ToInt32(Console.ReadLine());

            matrix = new string[rows, columns];

            for (int numberRows = 0; numberRows < matrix.GetLength(0); numberRows++)
            {
                for (int numberColumns = 0; numberColumns < matrix.GetLength(0); numberColumns++)
                {
                    Console.Write("\nIngrese componente: ");
                    matrix[numberRows, numberColumns] = Console.ReadLine();
                }
            }

            int lastRowIndex = matrix.GetLength(0) - 1, lastColumnIndex = matrix.GetLength(1) - 1;
            Console.Write($"\nVertices: {matrix[0, 0]}, {matrix[0, lastColumnIndex]}, " +
                $"{matrix[lastRowIndex, 0]}, {matrix[lastRowIndex, lastColumnIndex]}");

        }

    }
}
