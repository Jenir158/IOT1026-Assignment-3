using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Pack;

namespace AssignmentTest
{
    [TestClass]
    public class PackTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new Pack(PackMaxItems, PackMaxVolume, PackMaxWeight);

            Assert.AreEqual(PackMaxItems, pack.GetMaxCount());
            Assert.AreEqual(0, pack.GetVolume());
            Assert.AreEqual(0, pack.GetWeight());
        }

        [TestMethod]
        public void AddItem_ValidItem_ReturnsTrue()
        {
            Pack pack = new Pack(10, 20, 30);
            InventoryItem item = new Bow();

            bool result = pack.Add(item);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddItem_PackFull_ReturnsFalse()
        {
            Pack pack = new Pack(1, 1, 1);
            InventoryItem item1 = new Arrow();
            InventoryItem item2 = new Bow();

            pack.Add(item1);
            bool result = pack.Add(item2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectPackStatus()
        {
            Pack pack = new Pack(10, 20, 30);
            InventoryItem item = new Bow();
            pack.Add(item);

            string expected = "The pack capacity:\n" +
                "The pack is not full, it can still store 9 more items" +
                ", the remaining weight capacity is 28 and the remaining volume capacity is 18";

            Assert.AreEqual(expected, pack.ToString());
        }
    }
}
