using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ExerciseWCF.DataContracts;

namespace ExerciseWCF.Contracts
{
    [ServiceContract]
    public interface IExcercises
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/1/", RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml, Method = "POST")]
        string GetExercise1(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/2/", RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml, Method = "POST")]
        string GetExercise2(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/3/", RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml, Method = "POST")]
        string GetExercise3(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/4/", RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml, Method = "POST")]
        string GetExercise4(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/5/", RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml, Method = "POST")]
        string GetExercise5(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/6/", RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml, Method = "POST")]
        string GetExercise6(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/7/", RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml, Method = "POST")]
        string GetExercise7(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/8/",
            ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        string[] GetExercise8();

        [OperationContract]
        [WebInvoke(UriTemplate = "/9/",
            ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        string[] GetExercise9();

        [OperationContract]
        [WebInvoke(UriTemplate = "/10/",
            ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        string[] GetExercise10();

        [OperationContract]
        [WebInvoke(UriTemplate = "/11/",
            ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        string[] GetExercise11();

        [OperationContract]
        [WebInvoke(UriTemplate = "/12/",
            ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        string[] GetExercise12();

        [OperationContract]
        [WebInvoke(UriTemplate = "/13/",
            ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        string[] GetExercise13();

        [OperationContract]
        [WebInvoke(UriTemplate = "/14/",
            ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        string[] GetExercise14();

        [OperationContract]
        [WebInvoke(UriTemplate = "/15/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise15(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/16/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise16(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/17/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise17(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/18/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise18(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/19/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise19(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/20/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise20(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/21/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise21(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/22/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise22(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/23/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise23(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/24/", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string GetExercise24(Exercise exercise);
    }
}
