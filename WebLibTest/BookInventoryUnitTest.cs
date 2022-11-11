using Microsoft.VisualStudio.TestTools.UnitTesting;
using DALLib;

namespace WebLibTest
{
    [TestClass]
    public class BookInventoryUnitTest
    {

        [TestMethod]
        public void TestBookInventory()
        {
            int actual;
            int expected;
            DABookInventory Book = new DABookInventory();
            actual = Book.GetBookInventory(3).BookId;
            expected = 1;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAuthor()
        {
            string actual;
            string expected;
            DABookInventory Book = new DABookInventory();
            actual = Book.get(3).Author;
            expected = "Hero";
            Assert.AreEqual(expected, actual);
        }
    }
}
