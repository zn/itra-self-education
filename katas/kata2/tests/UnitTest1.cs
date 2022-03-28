using Microsoft.VisualStudio.TestTools.UnitTesting;
using kata2;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IterativeChopTest()
        {
            runTests(Program.IterativeBinarySearch);
        }

        [TestMethod]
        public void RecursiveChopTest()
        {
            runTests(Program.RecursiveBinarySearch);    
        }

        [TestMethod]
        public void FunctionalChopTest()
        {
            runTests(Program.FunctionalBinarySearch);    
        }
        
        [TestMethod]
        public void UnsafeChopTest()
        {
            runTests(Program.UnsafeBinarySearch);    
        }
        
        [TestMethod]
        public void ThirdPartyChopTest()
        {
            runTests(Program.ThirdPartyBinarySearch);    
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
