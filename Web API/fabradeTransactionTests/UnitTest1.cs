using FABRADE.Controllers;
using FABRADE.Models;
using FABRADE.Services;
using Moq;

namespace fabradeTransactionTests
{
    public class Tests
    {
        public Mock<IfabradeTransactionService> mock = new Mock<IfabradeTransactionService>();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetfabradeTransactionByID()
        {
            mock.Setup(p => p.GetfabradeTransactionByID(4)).ReturnsAsync("Leather Jacket, Brown");
            fabradeTransactionsController emp = new fabradeTransactionsController(mock.Object);
            string result = await emp.GetfabradeTransactionByID(4);
            Assert.AreEqual("Leather Jacket, Brown", result);
        }

        [Test]
        public async Task GetfabradeTransactionDetails()
        {
            var fabradeTransactionDTO = new fabradeTransaction()
            {
                id = 4,
                contact_name = "Nina",
                contact_no = "9517530258",
                dress_type = "Leather Jacket, Brown",
                size = "M",
                age = "21 - 25",
                gender = "F"

            };
            mock.Setup(p => p.GetfabradeTransactionDetails(4)).ReturnsAsync(fabradeTransactionDTO);
            fabradeTransactionsController emp = new fabradeTransactionsController(mock.Object);
            var result = await emp.GetfabradeTransactionDetails(4);
            Assert.True(fabradeTransactionDTO.Equals(result));
        }
    }
}