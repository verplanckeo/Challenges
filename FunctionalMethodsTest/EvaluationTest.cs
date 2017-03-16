using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsoleApplication1.EvaluateStatic;

namespace FunctionalMethodsTest
{
    [TestClass]
    public class EvaluationTest
    {
        [TestMethod]
        public void Evaluation_Test_MethodChaining()
        {
            Eval((1 == 2), (3 == 5), ("test" == "anothertest"))
                   .When(true, true, true)
                       .Then(() => { Console.WriteLine("ok"); })
                       .Else(() => { Console.WriteLine("nok"); })
                   .When(false, false, false)
                       .Then(() => { Console.WriteLine("ok - second check"); })
                       .Else(() => { Console.WriteLine("nok - second run"); })
                   ;
        }
    }
}
