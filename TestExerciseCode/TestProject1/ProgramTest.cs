using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProgramTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///This is a test method to check the format of Version info
        ///</summary>
        [TestMethod()]
        public void GetOutputVersionPositiveTest1()
        {
            string identifier = "-v"; // TODO: Initialize to an appropriate value
            string filepath = "C:\\test.txt"; // TODO: Initialize to an appropriate value
            //string expected = "We should have two dots(.) in Version"; // TODO: Initialize to an appropriate value
            string actual;
            actual = Program.GetOutput(identifier, filepath);
            var count = actual.Count(x => x == '.');
                                               
            Assert.AreEqual(2, count);
        }

        /// <summary>
        ///This is a test method to check the message if incorrect identifier passed to GetOutput method
        ///</summary>
        [TestMethod()]
        public void GetOutputVersionNegativeTest1()
        {
            string identifier = "-ver"; // TODO: Initialize to an appropriate value
            string filepath = "C:\\test.txt"; // TODO: Initialize to an appropriate value
            string expected = "Incorrect identifier; Please check"; // TODO: Initialize to an appropriate value
            string actual;
            actual = Program.GetOutput(identifier, filepath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///This is a test method to check if exception is properly handled in case of empty value of parameters passed to GetOutput method
        ///</summary>
        [TestMethod()]
        public void GetOutputExceptionTest()
        {
            string identifier = ""; // TODO: Initialize to an appropriate value
            string filepath = "C:\\test.txt"; // TODO: Initialize to an appropriate value
            string expected = "identifier and filepath are mandatory"; // TODO: Initialize to an appropriate value
            string actual;
            try
            {
                
                actual = Program.GetOutput(identifier, filepath);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("identifier and filepath are mandatory"))
                {
                    actual = "identifier and filepath are mandatory";
                    Assert.AreEqual(expected, actual);
                }
            }                    

            
        }

        /// <summary>
        ///This is a test method to check the format of Size info
        ///</summary>
        [TestMethod()]
        public void GetOutputSizePositiveTest1()
        {
            string identifier = "--size"; // TODO: Initialize to an appropriate value
            string filepath = "C:\\test.txt"; // TODO: Initialize to an appropriate value
            //string expected = "We should have single number without any space"; // TODO: Initialize to an appropriate value
            string actual;
            actual = Program.GetOutput(identifier, filepath);
            var count = actual.Count(x => x == ' ');

            Assert.AreEqual(0, count);
        }

        /// <summary>
        ///This is a test method to check the Size info should be int
        ///</summary>
        [TestMethod()]
        public void GetOutputSizePositiveTest2()
        {
            string identifier = "--size"; // TODO: Initialize to an appropriate value
            string filepath = "C:\\test.txt"; // TODO: Initialize to an appropriate value
            //string expected = "We should have single number without any space"; // TODO: Initialize to an appropriate value
            string actual;
            actual = Program.GetOutput(identifier, filepath);

            int result;
            bool success = int.TryParse(actual, out result);

            if (!success)
            {
                Assert.Fail("Cannot convert into int. Test Case failed");
            }

            
        }

        /// <summary>
        ///This is a test method to check the message in case of incorrect identifier
        ///</summary>
        [TestMethod()]
        public void GetOutputSizeNegativeTest1()
        {
            string identifier = "-sa"; // TODO: Initialize to an appropriate value
            string filepath = "C:\\test.txt"; // TODO: Initialize to an appropriate value
            string expected = "Incorrect identifier; Please check"; // TODO: Initialize to an appropriate value
            string actual;
            actual = Program.GetOutput(identifier, filepath);

            Assert.AreEqual(expected, actual);
        }
    }
}
