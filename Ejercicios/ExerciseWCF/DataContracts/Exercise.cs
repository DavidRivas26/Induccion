using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ExerciseWCF.DataContracts
{
    [DataContract(Name = "Exercise", Namespace = "http://schemas.datacontract.org/2004/07/ExerciseWCF.DataContracts")]
    public class Exercise
    {
        [DataMember]
        public int firtsNumber { get; set; }
        [DataMember]
        public int secondNumber { get; set; }
        [DataMember]
        public char vocal { get; set; }
        [DataMember]
        public int[] numbers { get; set; }
        [DataMember]
        public double[] salaries { get; set; }
        [DataMember]
        public string[] countries { get; set; }
        [DataMember]
        public int[] populations { get; set; }
        [DataMember]
        public string[][] matrix { get; set; }
        [DataMember]
        public string[] nameEmployee { get; set; }
        [DataMember]
        public int[][] absences { get; set; }
        [DataMember]
        public int[][] temperature { get; set; }
        [DataMember]
        public int[] temperatureQuarterly { get; set; }
    }
}