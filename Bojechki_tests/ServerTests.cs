using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Sockets;
using System.Text;

namespace Bojechki_tests
{
    [TestClass]
    public class ServerTests
    {
        private string SendCommand(string command)
        {
            using (var client = new TcpClient("127.0.0.1", 5001))
            using (var stream = client.GetStream())
            {
                byte[] data = Encoding.UTF8.GetBytes(command);
                stream.Write(data, 0, data.Length);
                byte[] buffer = new byte[8192];
                int bytes = stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytes);
            }
        }

        [TestMethod]
        public void Register()
        {
            string email = $"test_{System.Guid.NewGuid():N}@yandex.ru";
            string cmd = $"REGISTER|test|test|+71488148867|{email}|test";
            string response = SendCommand(cmd);
            Assert.AreEqual("SUCCESS", response);
        }

        [TestMethod]
        public void Register_DuplicateEmail_ReturnsError()
        {
            string email = $"dup_{System.Guid.NewGuid():N}@yandex.ru";
            string cmd = $"REGISTER|dup|dup|+71481111111|{email}|dup";
            string firstResponse = SendCommand(cmd);
            Assert.AreEqual("SUCCESS", firstResponse);

            string secondResponse = SendCommand(cmd);
            Assert.IsTrue(secondResponse.Contains("FAIL"));
        }

        [TestMethod]
        public void Login_ReturnsSuccess()
        {
            string email = $"test_{System.Guid.NewGuid():N}@yandex.ru";
            string registerCmd = $"REGISTER|fio|dno|+79991234567|{email}|pass";
            SendCommand(registerCmd);

            string loginCmd = $"LOGIN|{email}|pass";
            string response = SendCommand(loginCmd);
            Assert.IsTrue(response.Contains("SUCCESS"));
        }

        [TestMethod]
        public void Login_ReturnsError()
        {
            string response = SendCommand("LOGIN|wronguser|wrongpass");
            Assert.IsTrue(response.Contains("FAIL"));
        }

        [TestMethod]
        public void GetComponents_ReturnsJsonArray()
        {
            string response = SendCommand("GET_COMPONENTS");
            Assert.IsTrue(response.StartsWith("["));
        }

        [TestMethod]
        public void GetCatalogs_ReturnsJsonArray()
        {
            string response = SendCommand("GET_CATALOGS");
            Assert.IsTrue(response.StartsWith("["));
        }

        [TestMethod]
        public void SearchCatalogs()
        {
            string searchCmd = "SEARCH_CATALOGS|Сборка||";
            string response = SendCommand(searchCmd);
            Assert.IsTrue(response.Contains("["));
        }

        [TestMethod]
        public void SearchCatalogs_WithFilters()
        {
            string searchCmd = "SEARCH_CATALOGS|Сборка|name|1";
            string response = SendCommand(searchCmd);
            Assert.IsTrue(response.Contains("["));
        }

        [TestMethod]
        public void UnknownCommand_ReturnsError()
        {
            string response = SendCommand("UNKNOWN_COMMAND|test");
            Assert.IsTrue(response.Contains("UNKNOWN"));
        }

        [TestMethod]
        public void EndToEnd_UserRegistrationAndCatalogSearch()
        {
            string email = $"e2e_{Guid.NewGuid():N}@test.ru";
            string registerCmd = $"REGISTER|Иванов Иван Иванович|г. Дно|++71488148867|{email}|14881488";
            string registerResponse = SendCommand(registerCmd);
            Assert.AreEqual("SUCCESS", registerResponse);

            string loginCmd = $"LOGIN|{email}|14881488";
            string loginResponse = SendCommand(loginCmd);
            Assert.IsTrue(loginResponse.Contains("SUCCESS"));

            string catalogsResponse = SendCommand("GET_CATALOGS");
            Assert.IsTrue(catalogsResponse.StartsWith("["));

            string searchResponse = SendCommand("SEARCH_CATALOGS|Сборка||");
            Assert.IsTrue(searchResponse.StartsWith("["));

            string componentsResponse = SendCommand("GET_COMPONENTS");
            Assert.IsTrue(componentsResponse.StartsWith("["));

            string unknownResponse = SendCommand("RANDOM_COMMAND|arg");
            Assert.IsTrue(unknownResponse.Contains("UNKNOWN"));
        }
    }
}