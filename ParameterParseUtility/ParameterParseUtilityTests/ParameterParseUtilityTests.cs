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
            foreach(Parameter a in list)
            {
                if(a.ParameterType == "a")
                {
                    Assert.IsTrue(a.ParameterString == "xxx");
                }
                if (a.ParameterType == "b")
                {
                    Assert.IsTrue(a.ParameterString == "xyz");
                }
            }
        }
    }
}