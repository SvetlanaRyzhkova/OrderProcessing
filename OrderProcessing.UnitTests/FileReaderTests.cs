namespace OrderProcessing.UnitTests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void ParseLine_ValidLine_ProductAddedToDictionary()
        {
            // Arrange
            string line = "product,10";
            Dictionary<string, int> order = new Dictionary<string, int>();
            FileReader fileReader = new FileReader();

            // Act
            fileReader.parseLine(line, order);

            // Assert
            Assert.IsTrue(order.ContainsKey("product"));
            Assert.AreEqual(10, order["product"]);
        }

        [TestMethod]
        public void ParseLine_ProductExists_QuantityAddedToExistingProduct()
        {
            // Arrange
            string line = "product,10";
            Dictionary<string, int> order = new Dictionary<string, int>();
            order["product"] = 5;
            FileReader fileReader = new FileReader();

            // Act
            fileReader.parseLine(line, order);

            // Assert
            Assert.IsTrue(order.ContainsKey("product"));
            Assert.AreEqual(15, order["product"]);
        }

        [DataRow("product,invalid")]
        [DataRow("product10")]
        [TestMethod]
        public void ParseLine_InvalidLine_ThrowsFormatException(string line)
        {
            // Arrange
            Dictionary<string, int> order = new Dictionary<string, int>();
            FileReader fileReader = new FileReader();

            // Act & Assert
            Assert.ThrowsException<FormatException>(() => fileReader.parseLine(line, order));
        }
    }
}