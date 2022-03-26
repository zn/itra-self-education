using Microsoft.VisualStudio.TestTools.UnitTesting;
using kata2;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        Program p = new Program();

        [TestMethod]
        public void IterativeChopTest()
        {
            runTests(p.IterativeChop);
        }

        [TestMethod]
        public void RecursiveChopTest()
        {
            runTests(p.RecursiveChop);    
        }

        private void runTests(Chop chop)
        {
            Assert.AreEqual(-1, chop(3, new int[] { }));
            Assert.AreEqual(-1, chop(3, new[] { 1 }));
            Assert.AreEqual(0, chop(1, new[] { 1 }));
            Assert.AreEqual(0, chop(1, new[] { 1, 3, 5 }));
            Assert.AreEqual(1, chop(3, new[] { 1, 3, 5 }));
            Assert.AreEqual(2, chop(5, new[] { 1, 3, 5 }));
            Assert.AreEqual(-1, chop(0, new[] { 1, 3, 5 }));
            Assert.AreEqual(-1, chop(2, new[] { 1, 3, 5 }));
            Assert.AreEqual(-1, chop(4, new[] { 1, 3, 5 }));
            Assert.AreEqual(-1, chop(6, new[] { 1, 3, 5 }));
            Assert.AreEqual(0, chop(1, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(1, chop(3, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(2, chop(5, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(3, chop(7, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chop(0, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chop(2, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chop(4, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chop(6, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chop(8, new[] { 1, 3, 5, 7}));
            Assert.AreEqual(2, chop(4, new[] { 1, 3, 4, 5, 7}));
        }
    }
}
