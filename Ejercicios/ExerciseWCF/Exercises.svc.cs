using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ExerciseWCF.DataContracts;
using ExerciseWCF.Contracts;
using System.Drawing.Drawing2D;

namespace ExerciseWCF
{
    public class Exercises : IExcercises
    {
        public string GetExercise1(Exercise exercise)
        {
            return $"La división es: {exercise.firtsNumber / exercise.secondNumber} El residuo es: {exercise.firtsNumber % exercise.secondNumber}";
        }

        public string GetExercise2(Exercise exercise)
        {
            if (exercise.firtsNumber % exercise.secondNumber == 0)
                return $"El primer número es ({exercise.firtsNumber}) y es multiplo del segundo número ({exercise.secondNumber})";
            else
                return $"El primer número es ({exercise.firtsNumber}) y no es multiplo del segundo número ({exercise.secondNumber})";
        }

        public string GetExercise3(Exercise exercise)
        {
            return $"El producto es: {exercise.firtsNumber * exercise.secondNumber}";
        }

        public string GetExercise4(Exercise exercise)
        {
            if (exercise.firtsNumber == 0)
                return "Error: No se puede dividir entre cero";

            else
                return $"El resultado es: {exercise.firtsNumber / exercise.secondNumber}";
        }

        public string GetExercise5(Exercise exercise)
        {
            char[] vocals = { 'a', 'e', 'i', 'o', 'u' };
            string response = string.Empty;

            foreach (char vocal in vocals)
            {
                if (exercise.vocal == vocal)
                    response = $"Has insertado la vocal: {vocal}";
            }

            return response;
        }

        public string GetExercise6(Exercise exercise)
        {
            string response = string.Empty;

            if (exercise.firtsNumber > 0 || exercise.secondNumber > 0)
                response = "Uno de los números es positivo";
            if (exercise.firtsNumber > 0 && exercise.secondNumber > 0)
                response = "Los dos números son positivo";
            if (exercise.firtsNumber < 0 && exercise.secondNumber < 0)
                response = "Ninguno de los números es positivo";

            return response;
        }

        public string GetExercise7(Exercise exercise)
        {
            return $"El numero absoluto es: {Math.Abs(exercise.firtsNumber)}";
        }

        public string[] GetExercise8()
        {
            int counter = 1;
            string[] response = new string[10];

            while (counter <= 10)
            {
                response[counter-1] = $"{counter}";
                counter++;
            }

            return response;
        }

        public string[] GetExercise9()
        {
            int counter = 26, index = -1;
            string[] response = new string[9];

            while (counter >= 10)
            {
                if (counter % 2 == 0)
                {
                    index++;
                    response[index] = $"{counter}";
                }
                counter--;
            }

            return response;
        }

        public string[] GetExercise10()
        {
            int counter = 1;
            string[] response = new string[10];

            do
            {
                response[counter-1] = $"{counter}";
                counter++;
            }
            while (counter <= 10);

            return response;
        }

        public string[] GetExercise11()
        {
            int counter = 26, index = -1;
            string[] response = new string[9];

            do
            {
                if (counter % 2 == 0)
                {
                    index++;
                    response[index] = $"{counter}";
                }
                counter--;
            }
            while (counter >= 10);

            return response;
        }

        public string[] GetExercise12()
        {
            int counter = 15, index = -1;
            string[] response = new string[11];

            while (counter >= 5)
            {
                index++;
                response[index] = $"{counter}";
                counter--;
            }

            return response;
        }

        public string[] GetExercise13()
        {
            int index = -1;
            string[] response = new string[8];

            for (int counter = 2; counter <= 16; counter = counter + 2)
            {
                index++;
                response[index] = $"{counter}";
            }

            return response;
        }

        public string[] GetExercise14()
        {
            int counter = 1, index = -1;
            string[] response = new string[16];

            while (counter <= 50)
            {
                if (counter % 3 == 0)
                {
                    index++;
                    response[index] = $"{counter}";
                }
                counter++;
            }

            return response;
        }

        public string GetExercise15(Exercise exercise)
        {
            string response = string.Empty;

            int minor = exercise.numbers[0];
            for (int counter = 0; counter < exercise.numbers.Length; counter++)
            {
                if (exercise.numbers[counter] < minor)
                    minor = exercise.numbers[counter];
            }

            int count = 0;
            for (int counter = 0; counter < exercise.numbers.Length; counter++)
            {
                if (exercise.numbers[counter] == minor)
                    count++;
            }

            response += $"El menor es {minor}";

            if (count > 1)
                response += $", El menor se repite";

            return response;
        }

        public string GetExercise16(Exercise exercise)
        {
            string response = string.Empty;

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (exercise.salaries[counter] > exercise.salaries[counter + 1])
                    {
                        double major = exercise.salaries[counter];
                        exercise.salaries[counter] = exercise.salaries[counter + 1];
                        exercise.salaries[counter + 1] = major;
                    }
                }
            }

            foreach (double salary in exercise.salaries)
            {
                response += $" {salary},";
            }

            return response;
        }

        public string GetExercise17(Exercise exercise)
        {
            string response = "";

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (exercise.countries[counter].CompareTo(exercise.countries[counter + 1]) > 0)
                    {
                        string major = exercise.countries[counter];
                        exercise.countries[counter] = exercise.countries[counter + 1];
                        exercise.countries[counter + 1] = major;
                    }
                }
            }

            foreach (string country in exercise.countries)
            {
                response += $" {country},";
            }

            return response;
        }

        public string GetExercise18(Exercise exercise)
        {
            string response = "";

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (exercise.populations[counter] < exercise.populations[counter + 1])
                    {
                        int major = exercise.populations[counter];
                        exercise.populations[counter] = exercise.populations[counter + 1];
                        exercise.populations[counter + 1] = major;
                    }
                }
            }

            for (int counter = 0; counter < 5; counter++)
            {
                response += $" {exercise.countries[counter]}: {exercise.populations[counter]},";
            }

            for (int iterator = 0; iterator < 4; iterator++)
            {
                for (int counter = 0; counter < 4; counter++)
                {
                    if (exercise.countries[counter].CompareTo(exercise.countries[counter + 1]) > 0)
                    {
                        string major = exercise.countries[counter];
                        exercise.countries[counter] = exercise.countries[counter + 1];
                        exercise.countries[counter + 1] = major;
                    }
                }
            }

            response += "";

            for (int counter = 0; counter < 5; counter++)
            {
                response += $" {exercise.countries[counter]}: {exercise.populations[counter]},";
            }

            return response;
        }

        public string GetExercise19(Exercise exercise)
        {
            string response = "";

            for (int rows = 0; rows < exercise.matrix.Length; rows++)
            {

                for (int columns = 0; columns < exercise.matrix[rows].Length; columns++)
                {
                    response += $" {exercise.matrix[rows][columns]},";
                }
            }

            return response;
        }

        public string GetExercise20(Exercise exercise)
        {
            exercise.temperatureQuarterly = new int[3];
            string response = string.Empty;

            for (int rows = 0; rows < exercise.countries.Length; rows++)
            {
                response += $" Provincia: {exercise.countries[rows]}: ";
                for (int columns = 0; columns < exercise.temperature[rows].Length; columns++)
                {
                    response += $" {exercise.temperature[rows][columns]},";
                }
            }

            for (int rows = 0; rows < exercise.temperature.Length; rows++)
            {
                int sum = 0;
                for (int columns = 0; columns < exercise.temperature[rows].Length; columns++)
                {
                    sum = sum + exercise.temperature[rows][columns];
                }
                exercise.temperatureQuarterly[rows] = sum / 3;
            }

            response += " Temperaturas trimestrales.";
            for (int rows = 0; rows < exercise.countries.Length; rows++)
            {
                response += $" {exercise.countries[rows]}: {exercise.temperatureQuarterly[rows]},";
            }

            int HigherTemp = exercise.temperatureQuarterly[0];
            string HigherCountry = exercise.countries[0];
            for (int rows = 0; rows < exercise.countries.Length; rows++)
            {
                if (exercise.temperatureQuarterly[rows] > HigherTemp)
                {
                    HigherTemp = exercise.temperatureQuarterly[rows];
                    HigherCountry = exercise.countries[rows];
                }
            }
            response += $" La provincia con temperatura trimestral mayor es" +
                $" {HigherCountry} que tiene una temperatura de {HigherTemp}";

            return response;
        }

        public string GetExercise21(Exercise exercise)
        {
            string response = "";

            for (int rows = 0; rows < exercise.matrix.Length; rows++)
            {
                for (int columns = 0; columns < exercise.matrix[rows].Length; columns++)
                {
                    response += $" {exercise.matrix[rows][columns]},";
                }
            }

            return response;
        }

        public string GetExercise22(Exercise exercise)
        {
            string response = "";

            for (int rows = 0; rows < exercise.absences.Length; rows++)
            {
                response += $" {exercise.nameEmployee[rows]},";
                for (int column = 0; column < exercise.absences[rows].Length; column++)
                {
                    response += $" {exercise.absences[rows][column]}";
                }
            }

            return response;
        }

        public string GetExercise23(Exercise exercise)
        {
            string element;
            string response = "";

            for (int numberRows = 0; numberRows < exercise.matrix.Length; numberRows++)
            {
                element = exercise.matrix[0][numberRows];
                exercise.matrix[0][numberRows] = exercise.matrix[1][numberRows];
                exercise.matrix[1][numberRows] = element;
            }

            for (int numberRows = 0; numberRows < exercise.matrix.Length; numberRows++)
            {
                for (int numberColumns = 0; numberColumns < exercise.matrix[numberRows].Length; numberColumns++)
                {
                    response += $" {exercise.matrix[numberRows][numberColumns]},";
                }
                response += "";
            }

            return response;
        }

        public string GetExercise24(Exercise exercise)
        {
            int lastRowIndex = exercise.matrix.Length - 1;
            int lastColumnIndex = exercise.matrix[0].Length - 1;

            return $"Vertices: {exercise.matrix[0][0]}, {exercise.matrix[0][lastColumnIndex]}, " +
                $"{exercise.matrix[lastRowIndex][0]}, {exercise.matrix[lastRowIndex][lastColumnIndex]}";

        }
    }
}
