using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bojechki_server.Helpers;

namespace Bojechki_tests
{
    [TestClass]
    public class PasswordHelperTests
    {
        [TestMethod]
        public void HashPassword()
        {
            string hash = PasswordHelper.HashPassword("test");
            Assert.IsNotNull(hash);
            Assert.IsTrue(hash.Length > 0);
        }

        [TestMethod]
        public void HashPassword1()
        {
            string pwd = "secret";
            string hash1 = PasswordHelper.HashPassword(pwd);
            string hash2 = PasswordHelper.HashPassword(pwd);
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void HashPassword2()
        {
            string hash1 = PasswordHelper.HashPassword("qwerty123");
            string hash2 = PasswordHelper.HashPassword("qwerty1488");
            Assert.AreNotEqual(hash1, hash2);
        }
    }
}