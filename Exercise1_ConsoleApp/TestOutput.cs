using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Exercise1_ConsoleApp;

namespace Exercise1_ConsoleApp_Test
{
    [TestFixture]
    public class TestOutput
    {
        [Test]
        public void IsOuputAsExpected()
        {
            //given
            string actualString = Program.CreateTable();
            string expectedString =
                "| Pub Date    |                       Title | Authors                         |\r\n" +
                "|=============================================================================|\r\n" +
                "| 28 Nov 2008 |             Learning C# 3.0 | Jesse Liberty & Brian MacDonald |\r\n" +
                "| 16 Sep 2013 |               Head First C# | Jennifer Greene & Andrew Ste... |\r\n" +
                "| 27 Oct 2015 | Learn C# in One Day and ... | Jamie Chan                      |\r\n";


            //then
            Assert.AreEqual(expectedString, actualString);
        }
    }
}