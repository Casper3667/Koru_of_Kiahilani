using Koru_of_Kiahilani.Commands;

namespace Koru_Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestTheCommand()
        {
            string testResult = TestCommand.CommandoTest();
            string expectedResult = "Hello";
            Assert.AreEqual(testResult, expectedResult);
        }
    }
}
