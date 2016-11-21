using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParameterParseUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterParseUtility.Tests
{
    [TestClass()]
    public class ParameterParseUtilityTests
    {
        [TestMethod()]
        public void ParseParameterTest()
        {
            string paramString = "-a xxx -b xyz";
            var list = ParameterParseUtility.ParseParameter(paramString);
            Assert.IsTrue(list.Count == 2);
            foreach (Parameter a in list)
            {
                if (a.ParameterType == "-a")
                {
                    Assert.IsTrue(a.ParameterTypeTrim == "a");
                    Assert.IsTrue(a.ParameterString == "xxx");
                }
                if (a.ParameterType == "-b")
                {
                    Assert.IsTrue(a.ParameterTypeTrim == "b");
                    Assert.IsTrue(a.ParameterString == "xyz");
                }
            }
        }

        [TestMethod()]
        public void ParseParameterTest1()
        {
            string[] arges = { "-d", "-a", "xxx", "-b","xyz", "-c"};
            var list = ParameterParseUtility.ParseParameter(arges);
            Assert.IsTrue(list.Count == 4);
            foreach (Parameter a in list)
            {
                if (a.ParameterType == "-a")
                {
                    Assert.IsTrue(a.ParameterTypeTrim == "a");
                    Assert.IsTrue(a.ParameterString == "xxx");
                }
                if (a.ParameterType == "-b")
                {
                    Assert.IsTrue(a.ParameterTypeTrim == "b");
                    Assert.IsTrue(a.ParameterString == "xyz");
                }
                if (a.ParameterType == "-c")
                {
                    Assert.IsTrue(a.ParameterTypeTrim == "c");
                    Assert.IsTrue(string.IsNullOrEmpty(a.ParameterString));
                }
                if (a.ParameterType == "-d")
                {
                    Assert.IsTrue(a.ParameterTypeTrim == "d");
                    Assert.IsTrue(string.IsNullOrEmpty(a.ParameterString));
                }
            }
        }

        [TestMethod()]
        public void ParseParameterTest2()
        {
            string[] arges = { "-bgworker" };
            var list = ParameterParseUtility.ParseParameter(arges);
            Assert.IsTrue(list.Count == 1);
            foreach (Parameter a in list)
            {
                if (a.ParameterType == "-bgworker")
                {
                    Assert.IsTrue(string.IsNullOrEmpty(a.ParameterString));
                }
            }
        }

        
    }
}