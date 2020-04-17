namespace p1_UnitTesting
{
    using NUnit.Framework;
    using p1.Core;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using System.IO;

    public class Tests
    {
        private Engin engin;
        private string[] args;
        private Controller controller;

        [SetUp]
        public void Setup()
        {
            engin = new Engin();
            args = new string[256];
            controller = new Controller();
        }

        [Test]
        public void testCountOfElements()
        {
            List<int> numbers = controller.Gen().Split(", ").Select(int.Parse).ToList();
            Assert.IsTrue(10==numbers.Count);
        }
        [Test]
        public void TestClearOfOldElements()
        {
            List<int> OldNumbers = controller.Gen().Split(", ").Select(int.Parse).ToList();
            List<int> newNumbers = controller.Gen().Split(", ").Select(int.Parse).ToList();

            Assert.IsTrue(OldNumbers != newNumbers);
        }
        [TestCase("Invalid name")]
        [TestCase("")]
        [TestCase("name.txxt")]
        [TestCase("name.")]
        public void SaveErrorWrongName(string fileName)
        {
            Assert.Throws<Exception>(() => controller.Save(fileName));
        }
        [Test]
        public void SuccessfullSave()
        {
            Assert.IsTrue("Successfully saved!"==controller.Save("corect.txt"));
        }
        [TestCase("Invalid name")]
        [TestCase("")]
        [TestCase("name.txxt")]
        [TestCase("name.")]
        public void LoadErrorWrongName(string fileName)
        {
            Assert.Throws<Exception>(() => controller.Load(fileName));
        }
        [Test]
        public void Test3()
        {
            Assert.Pass();
        }
        [Test]
        public void Test4()
        {
            Assert.Pass();
        }
        [Test]
        public void Test5()
        {
            Assert.Pass();
        }
    }
}