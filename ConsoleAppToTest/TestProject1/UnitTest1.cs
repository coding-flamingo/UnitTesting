using ConsoleAppToTest.Managers;
using ConsoleAppToTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestRecordManager()
        {
            var iDbServiceMock = new Mock<IDBService>();
            iDbServiceMock.Setup(r => r.GetRecordAsync(It.Is<string>(g =>
                g.Equals("Rob")))).ReturnsAsync("");
            iDbServiceMock.Setup(r => r.GetRecordAsync(It.Is<string>(g => 
                g.Equals("Peter")))).ReturnsAsync("Peter");
            iDbServiceMock.Setup(r => r.AddRecordAsync(It.Is<string>(g =>
                !string.IsNullOrWhiteSpace(g)))).ReturnsAsync(true);
            iDbServiceMock.Setup(r => r.AddRecordAsync(It.Is<string>(g =>
                string.IsNullOrWhiteSpace(g)))).ReturnsAsync(false);
            RecordManager recordManager= new RecordManager(iDbServiceMock.Object);
            ArgumentNullException ex = await 
                Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => 
                await recordManager.AddRecordAsync(""));
            bool testPass = await recordManager.AddRecordAsync("Rob");
            bool testFail = await recordManager.AddRecordAsync("Peter");

            Assert.IsFalse(testFail);
            Assert.IsTrue(testPass);
            Assert.AreEqual("Value cannot be null. (Parameter 'id is null')", ex.Message);
        }
    }
}