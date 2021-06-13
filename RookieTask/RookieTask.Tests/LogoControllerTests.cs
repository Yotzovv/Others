using NUnit.Framework;
using RookieTask.Client.Controllers;
using RookieTask.Client.Interfaces;
using RookieTask.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieTask.Tests
{
    public class LogoControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UpperPartConstructedSuccessful()
        {
            ILogoController logoController = new LogoController();
            var dashesRepetition = 5;
            var middle = 3;
            var starsCount = 9;
            var dashesCount = 1;
            var n = 5;
            var loop = 0;

            var row = logoController.ConstructRow(dashesRepetition, middle, ref starsCount, ref dashesCount, n, loop);

            Assert.AreNotSame(row, "-----*****-----*****----------*****-----*****-----");
        }

        [Test]
        public void LowerPartConstructsSuccessful()
        {
            ILogoController logoController = new LogoController();
            var dashesRepetition = 2;
            var middle = 3;
            var starsCount = 9;
            var dashesCount = 1;
            var n = 5;
            var loop = 3;

            var row = logoController.ConstructRow(dashesRepetition, middle, ref starsCount, ref dashesCount, n, loop);

            Assert.AreNotSame(row, "--*****-*********-*****----*****-*********-*****--");
        }
       
        [Test]
        public void OutputsSuccessful()
        {
            ILogoController logoController = new LogoController();

            var logo = new Logo()
            {
                N = 5
            };

            int dashesCount = 1;
            int starsCount = 2 * (logo.N - 1) + 1;

            for (int loop = 0; loop < logo.N + 1; loop++)
            {
                var middle = (logo.N + 1) / 2;
                var dashesRepetition = (logo.N - loop) > 0 ? (logo.N - loop) : 0;

                var row = logoController.ConstructRow(dashesRepetition, middle, ref starsCount, ref dashesCount, logo.N, loop);

                logo.Result += row;
            }

            var expectedResult = @"-----*****-----*****----------*****-----*****-----
----*******---*******--------*******---*******----
---*********-*********------*********-*********---
--*****-*********-*****----*****-*********-*****--
-*****---*******---*****--*****---*******---*****-
*****-----*****-----**********-----*****-----*****" + Environment.NewLine;

            var actualResult = logo.Result;

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }        
    }
}
