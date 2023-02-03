using NUnit.Framework;

namespace HexTest.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
		{
			
		}

        [Test]
        [TestCase(10, Author="AiSciPro", Category="UnitTestCase")]
        public void ModelNameTest(int val)
        {   
            Assert.Pass();
        }
    }
}