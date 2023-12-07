﻿/******************************************************************************
* Filename    = TestAbstractClassNamingChecker.cs
*
* Author      = Monesh Vanga 
* 
* Product     = Analyzer
* 
* Project     = AnalyzerTests
*
* Description = Unit Tests for AbstractClassNamingChecker.cs
*****************************************************************************/

using Analyzer.Parsing;
using Analyzer.Pipeline;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AnalyzerTests.Pipeline
{
    /// <summary>
    /// Test class for testing the analyzer - PrefixChecker.
    /// </summary>
    [TestClass()]
    public class TestAbstractClassNaming
    {
        /// <summary>
        /// Test method for a case in which all classes follow the rule 
        /// </summary>

        //Abstract1.cs

        //namespace ClassLibrary1
        //{
        //    public abstract class GoodBase
        //    {
        //        //..
        //    }
        //}

        [TestMethod()]
        public void TestGoodExample()
        {
            List<ParsedDLLFile> DllFileObjs = new();

            string path = "..\\..\\..\\TestDLLs\\Abstract1.dll";
            var parsedDllObj = new ParsedDLLFile( path );

            DllFileObjs.Add( parsedDllObj );

            AbstractClassNamingChecker abstractClassNamingChecker = new( DllFileObjs );

            Dictionary<string , Analyzer.AnalyzerResult> resultObj = abstractClassNamingChecker.AnalyzeAllDLLs();

            Analyzer.AnalyzerResult result = resultObj["Abstract1.dll"];
            Assert.AreEqual( 1 , result.Verdict );
        }

        /// <summary>
        /// Test method for a case in which classes don't follow the above mentioned rule.
        /// </summary>
        /// 

        //Abstract.cs

        //namespace ClassLibrary1
        //{
        //    public abstract class badBase
        //    {
        //        //..
        //    }

        //    public abstract class badabstractclass
        //    {
        //        //..
        //    }
        //}


        [TestMethod()]
        public void TestBadExample()
        {
            List<ParsedDLLFile> DllFileObjs = new();

            string path = "..\\..\\..\\TestDLLs\\Abstract.dll";
            var parsedDllObj = new ParsedDLLFile( path );

            DllFileObjs.Add( parsedDllObj );

            AbstractClassNamingChecker abstractClassNamingChecker = new( DllFileObjs );

            Dictionary<string , Analyzer.AnalyzerResult> resultObj = abstractClassNamingChecker.AnalyzeAllDLLs();

            Analyzer.AnalyzerResult result = resultObj["Abstract.dll"];
            Assert.AreEqual( 0 , result.Verdict );
        }

    }
}
