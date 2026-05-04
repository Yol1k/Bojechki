using System.Linq;
using Bojechki_server.Helpers;
using Bojechki_server.Database;

namespace Bojechki_server.Handlers
{
    public static class RegisterHandler
    {
        public static string HandleRegister(AppDbContext db, string[] parts)
        {
            if (parts.Length != 6) return "FAIL|Неверный формат запроса";
            string fullName = parts[1];
            string address = parts[2];
            string phone = parts[3];
            string email = parts[4];
            string password = parts[5];

            if (db.Clients.Any(c => c.Email == email))
                return "FAIL|Пользователь с такой почтой уже зарегистрирован";

            var newClient = new Client
            {
                Email = email,
                Password = PasswordHelper.HashPassword(password),
                Full_Name = fullName,
                Address = address,
                Phone = phone,
            };
            db.Clients.Add(newClient);
            db.SaveChanges();
            return "SUCCESS";
        }
    }
}
