using System;
using System.Reflection;
using Xunit;

namespace InheritedAutoMapper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var exeWrapper = new ExecutorWrapper(Assembly.GetExecutingAssembly().Location, null, true);
            var builder = TestAssemblyBuilder.Build(exeWrapper);

            Console.WriteLine("AutoMapper Inheritance Extension Sample\n\n");
            builder.Run(builder.EnumerateTestMethods(), new TestRunnerCallback());
        }

    }


    public class TestRunnerCallback : ITestMethodRunnerCallback
    {
        public void AssemblyFinished(TestAssembly testAssembly, int total, int failed, int skipped, double time)
        {
        }

        public void AssemblyStart(TestAssembly testAssembly)
        {
        }

        public bool ClassFailed(TestClass testClass, string exceptionType, string message, string stackTrace)
        {
            return true;
        }

        public void ExceptionThrown(TestAssembly testAssembly, Exception exception)
        {
        }

        public bool TestFinished(TestMethod testMethod)
        {
            Console.WriteLine("{0} :: {1}\n", testMethod.RunStatus, testMethod.MethodName);
            return true;
        }

        public bool TestStart(TestMethod testMethod)
        {
            return true;
        }
    }
}