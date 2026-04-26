using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bojechki_server.Helpers;
using Bojechki_server.Database;

namespace Bojechki_server.Handlers
{
    public static class LoginHandler
    {
        public static string HandleLogin(AppDbContext db, string[] parts)
        {
            if (parts.Length != 3) return "FAIL|Неверный формат запроса";
            string email = parts[1];
            string password = parts[2];
            string hash = PasswordHelper.HashPassword(password);
            var user = db.Clients.FirstOrDefault(c => c.Email == email && c.Password == hash);
            return user != null ? "SUCCESS" : "FAIL|Неверная почта или пароль";
        }
    }
}
